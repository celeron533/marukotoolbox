﻿// ------------------------------------------------------------------
// Copyright (C) 2011-2017 Maruko Toolbox Project
//
//  Authors: komaruchan <sandy_0308@hotmail.com>
//           LunarShaddow <aflyhorse@hotmail.com>
//           LYF <lyfjxymf@sina.com>
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
// express or implied.
// See the License for the specific language governing permissions
// and limitations under the License.
// -------------------------------------------------------------------
//

using ControlExs;
using MediaInfoLib;
using mp4box.Extension;
using mp4box.Procedure;
using mp4box.Utility;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using static mp4box.Utility.DialogUtil;

namespace mp4box
{
    public partial class MainForm : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private string logFileName = ((NLog.Targets.FileTarget)LogManager.Configuration.FindTargetByName("f")).FileName.Render(null);
        private readonly DateTime ReleaseDate = AssemblyUtil.GetAssemblyVersionTime();

        private Preset preset;
        private Settings settings;

        #region Private Members Declaration

        private int sourceIndex;    // used for ListBox Drag & Drop
        private int targetIndex;    // used for ListBox Drag & Drop

        private X264Mode x264mode = X264Mode.Crf;

        private string audioInput = "";
        private string audioOutput;
        private string videoInput = "";
        private string videoOutput;
        private string videoSubtitle = "";

        private string mediaInfoFile;

        private string x264;
        private string aextract;
        
        #endregion Private Members Declaration

        public MainForm()
        {
            preset = new Preset();
            settings = new Settings();
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ToolsVerification();

            // Detect processor count
            ConfigX264ThreadsComboBox.Items.Add("auto");
            for (int i = 1; i <= Environment.ProcessorCount; i++)
            {
                ConfigX264ThreadsComboBox.Items.Add(i.ToString());
            }

            //load x264 exe
            DirectoryInfo folder = new DirectoryInfo(ToolsUtil.ToolsFolder);
            List<string> x264exe = new List<string>();
            try
            {
                bool usex265 = settings.ConfigFunctionEnableX265Check;
                foreach (FileInfo FileName in folder.GetFiles())
                {
                    if ((FileName.Name.ToLower().Contains("x264") || FileName.Name.ToLower().Contains(usex265 ? "x265" : "xxxx")) && Path.GetExtension(FileName.Name) == ".exe")
                    {
                        x264exe.Add(FileName.Name);
                    }
                }
                x264exe = x264exe.OrderByDescending(i => i.Substring(7)).ToList();
                VideoEncoderComboBox.Items.AddRange(x264exe.ToArray());
            }
            catch { }

            //ReleaseDate = System.IO.File.GetLastWriteTime(this.GetType().Assembly.Location); //获得程序编译时间
            HelpReleaseDateLabel.Text = ReleaseDate.ToString("yyyy-M-d");

            // load Help Text
            if (File.Exists(Global.Running.startPath + "\\help.rtf"))
            {
                HelpContentRichTextBox.LoadFile(Global.Running.startPath + "\\help.rtf");
            }
            else
            {
                HelpContentRichTextBox.Text = "help.rtf is not found.";
            }
            CheckAVS();
            LoadAVS();
            LoadSettings();
        }

        private void LoadAVS()
        {
            //load AVS filter
            DirectoryInfo avspath = new DirectoryInfo(ToolsUtil.ToolsFolder + @"\avs\plugins");
            List<string> avsfilters = new List<string>();
            if (Directory.Exists(ToolsUtil.ToolsFolder + @"\avs\plugins"))
            {
                foreach (FileInfo FileName in avspath.GetFiles())
                {
                    if (Path.GetExtension(FileName.Name) == ".dll")
                    {
                        avsfilters.Add(FileName.Name);
                    }
                }
                AvsFilterComboBox.Items.AddRange(avsfilters.ToArray());
            }
        }

        private static void CheckAVS()
        {
            // avisynth未安装使用本地内置的avs
            if (string.IsNullOrEmpty(FileStringUtil.CheckAviSynth()))
            {
                string sourceAviSynthdll = Path.Combine(ToolsUtil.ToolsFolder, @"avs\AviSynth.dll");
                string sourceDevILdll = Path.Combine(ToolsUtil.ToolsFolder, @"avs\DevIL.dll");
                if (File.Exists(sourceAviSynthdll) && File.Exists(sourceDevILdll))
                {
                    try
                    {
                        File.Copy(sourceAviSynthdll, Path.Combine(ToolsUtil.ToolsFolder, "AviSynth.dll"), true);
                        File.Copy(sourceDevILdll, Path.Combine(ToolsUtil.ToolsFolder, "DevIL.dll"), true);
                        logger.Info("未安装avisynth,使用本地内置avs.");
                    }
                    catch (IOException) { }
                }
            }
            else
            {
                File.Delete(Path.Combine(ToolsUtil.ToolsFolder, "AviSynth.dll"));
                File.Delete(Path.Combine(ToolsUtil.ToolsFolder, "DevIL.dll"));
            }
        }

        private static void ToolsVerification()
        {
            if (!Directory.Exists(ToolsUtil.ToolsFolder))
            {
                logger.Error("tools not found.");
                MessageBox.Show("tools文件夹没有解压喔~ 工具箱里没有工具的话运行不起来的喔~", "（这只丸子）",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DeleteTempFiles();
            SaveSettings();
        }

        private void DeleteTempFiles()
        {
            if (ConfigFunctionDeleteTempFileCheckBox.Checked && Directory.Exists(ToolsUtil.ToolsFolder))
            {
                List<string> deleteFileList = new List<string>();

                if (Directory.Exists(Global.Running.tempFolder))
                    deleteFileList.AddRange(Directory.GetFiles(Global.Running.tempFolder));

                string[] deletedfiles = { "concat.txt", Global.Running.tempAvsFile, Global.Running.tempImgFile };
                deleteFileList.AddRange(deletedfiles);

                string[] batFiles = Directory.GetFiles(ToolsUtil.ToolsFolder, "*.bat");
                deleteFileList.AddRange(batFiles);

                string fileName = System.Reflection.Assembly.GetExecutingAssembly().Location;
                Process[] processes = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);

                // If there is no other running instances, delete files
                if (processes.Count(p => p.MainModule.FileName == fileName) == 1)
                {
                    deleteFileList.ForEach(f => File.Delete(f));
                }
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Keys.D0 = 48, Keys.D1 = 49, ... , Keys.D9 = 57
            // The following code uses number key 1 to 9, and 0 is still available for furture use.
            if (e.Modifiers == Keys.Control && Keys.D1 <= e.KeyCode && e.KeyCode <= Keys.D9)
            {
                MainTabControl.SelectedIndex = e.KeyCode - Keys.D1;
            }
        }


        public string FFMpegMuxCommand(string input1, string input2, string output)
        {
            return $"{ToolsUtil.FFMPEG.quotedPath} -i {input1.Quote()} -i {input2.Quote()} -sn -c copy -y {output.Quote()}";
        }

        public string MP4MuxCommand(string input1, string input2, string output)
        {
            return $"{ToolsUtil.MP4BOX.quotedPath} -add \"{input1}#trackID=1:name=\" -add \"{input2}#trackID=1:name=\" -new {output.Quote()}";
        }

        public XvSettings GetXvSettings()
        {
            var xvs = new XvSettings();
            xvs.CrfValue = VideoCrfNumericUpDown.Value;
            xvs.ExtParameter = ConfigX264ExtraParameterTextBox.Text;
            xvs.CustomParameter = VideoCustomParameterTextBox.Text;
            xvs.V_width = (int)VideoWidthNumericUpDown.Value;
            xvs.V_height = (int)VideoHeightNumericUpDown.Value;
            xvs.X26xThreads = ConfigX264ThreadsComboBox.SelectedItem.ToString();
            xvs.X26xDemuxer = VideoDemuxerComboBox.Text;
            xvs.X26xBitrate = (int)VideoBitrateNumericUpDown.Value;
            xvs.X26xSeek = (int)VideoSeekNumericUpDown.Value;
            xvs.X26xFrames = (int)VideoFramesNumericUpDown.Value;
            xvs.IsResizeChecked = VideoMaintainResolutionCheckBox.Checked;
            return xvs;
        }

        public string x264bat(string input, string output, int pass = 1, string sub = "")
        {
            StringBuilder sb = new StringBuilder();
            XvSettings xvs = GetXvSettings();

            //keyint设为fps的10倍
            double fps;
            string keyint = "-1";
            MediaInfoWrapper MIW = new MediaInfoWrapper(input);
            if (double.TryParse(MIW.v_frameRate2, out fps))
            {
                fps = Math.Round(fps);
                keyint = (fps * 10).ToString();
            }

            if (Path.GetExtension(input).ToLower().Equals(".avs"))
            {
                /*
                 * AVS文件建议在avs脚本中修改分辨率和添加字幕
                 */
                xvs.V_width = 0;
                xvs.V_height = 0;
                sub = string.Empty;
                sb.Append(ToolsUtil.AVS4X26X.quotedPath + " -L ");
            }
            sb.Append("\"" + Path.Combine(ToolsUtil.ToolsFolder, VideoEncoderComboBox.SelectedItem.ToString()) + "\"");
            // 编码模式
            switch (x264mode)
            {
                case X264Mode.Custom: // 自定义
                    sb.Append(" " + xvs.CustomParameter);
                    break;

                case X264Mode.Crf: // crf
                    sb.Append(" --crf " + xvs.CrfValue);
                    break;

                case X264Mode.TwoPass: // 2pass
                    sb.Append(" --pass " + pass + " --bitrate " + xvs.X26xBitrate + " --stats \"" + Path.Combine(Global.Running.tempFolder, Path.GetFileNameWithoutExtension(output)) + ".stats\"");
                    break;
            }
            if (x264mode != X264Mode.Custom)
            {
                if (xvs.X26xDemuxer != "auto" && xvs.X26xDemuxer != string.Empty)
                    sb.Append(" --demuxer " + xvs.X26xDemuxer);
                if (xvs.X26xThreads != "auto" && xvs.X26xThreads != string.Empty)
                    sb.Append(" --threads " + xvs.X26xThreads);
                if (xvs.ExtParameter != string.Empty)
                    sb.Append(" " + xvs.ExtParameter);
                else
                    sb.Append(" --preset 8 " + " -I " + keyint + " -r 4 -b 3 --me umh -i 1 --scenecut 60 -f 1:1 --qcomp 0.5 --psy-rd 0.3:0 --aq-mode 2 --aq-strength 0.8");
                if (xvs.V_height != 0 && xvs.V_height != 0 && !xvs.IsResizeChecked)
                    sb.Append(" --vf resize:" + xvs.V_width + "," + xvs.V_height + ",,,,lanczos");
            }
            if (!string.IsNullOrEmpty(sub))
            {
                string x264tmpline = sb.ToString();
                if (x264tmpline.IndexOf("--vf") == -1)
                    sb.Append(" --vf subtitles --sub " + sub.Quote());
                else
                {
                    Regex r = new Regex("--vf\\s\\S*");
                    Match m = r.Match(x264tmpline);
                    sb.Insert(m.Index + 5, "subtitles/").Append(" --sub " + sub.Quote());
                }
            }
            if (xvs.X26xSeek != 0)
                sb.Append(" --seek " + xvs.X26xSeek);
            if (xvs.X26xFrames != 0)
                sb.Append(" --frames " + xvs.X26xFrames);
            if (x264mode == X264Mode.TwoPass && pass == 1)
                sb.Append(" -o NUL");
            else if (!string.IsNullOrEmpty(output))
                sb.Append(" -o " + output.Quote());
            if (!string.IsNullOrEmpty(input))
                sb.Append(" " + input.Quote());
            return sb.ToString();
        }

        public string x265bat(string input, string output, int pass = 1, string sub = "")
        {
            StringBuilder sb = new StringBuilder();
            XvSettings xvs = GetXvSettings();

            bool isAvs = Path.GetExtension(input).ToLower().Equals(".avs");
            if (isAvs)
            {
                sb.Append(ToolsUtil.AVS4X26X.quotedPath + " -L ");
            }
            else
            {
                sb.Append(ToolsUtil.FFMPEG.quotedPath + " -i " + input.Quote());
                if (xvs.V_height != 0 && xvs.V_height != 0 && !xvs.IsResizeChecked)
                    sb.Append(string.Format(" -vf zscale={0}x{1}:filter=lanczos", xvs.V_width, xvs.V_height));
                if (!string.IsNullOrEmpty(sub))
                {
                    string x264tmpline = sb.ToString();
                    if (x264tmpline.IndexOf("-vf") == -1)
                        sb.Append(" -vf subtitles=" + FileStringUtil.GetLibassFormatPath(sub).Quote());
                    else
                    {
                        int index = x264tmpline.IndexOf("lanczos");
                        sb.Insert(index + 7, ",subtitles=" + FileStringUtil.GetLibassFormatPath(sub).Quote());
                    }
                }
                sb.Append(" -strict -1 -f yuv4mpegpipe -an - | ");
            }

            sb.Append(FileStringUtil.FormatPath(Path.Combine(ToolsUtil.ToolsFolder, VideoEncoderComboBox.SelectedItem.ToString())) + (isAvs ? string.Empty : " --y4m"));
            // 编码模式
            switch (x264mode)
            {
                case X264Mode.Custom: // 自定义
                    sb.Append(" " + xvs.CustomParameter);
                    break;

                case X264Mode.Crf: // crf
                    sb.Append(" --crf " + xvs.CrfValue);
                    break;

                case X264Mode.TwoPass: // 2pass
                    sb.Append(" --pass " + pass + " --bitrate " + xvs.X26xBitrate + " --stats \"" + Path.Combine(Global.Running.tempFolder, Path.GetFileNameWithoutExtension(output)) + ".stats\"");
                    break;
            }
            if (x264mode != X264Mode.Custom)
            {
                if (xvs.ExtParameter != string.Empty)
                    sb.Append(" " + xvs.ExtParameter);
                else
                    sb.Append(" --preset slower --tu-intra-depth 3 --tu-inter-depth 3 --rdpenalty 2 --me 3 --subme 5 --merange 44 --b-intra --no-rect --no-amp --ref 5 --weightb --bframes 8 --aq-mode 1 --aq-strength 1.0 --rd 5 --psy-rd 0.7 --psy-rdoq 5.0 --rdoq-level 1 --no-sao --no-open-gop --rc-lookahead 80 --scenecut 40 --max-merge 4 --qcomp 0.7 --no-strong-intra-smoothing --deblock -1:-1 --qg-size 16");
            }
            if (xvs.X26xSeek != 0)
                sb.Append(" --seek " + xvs.X26xSeek);
            if (xvs.X26xFrames != 0)
                sb.Append(" --frames " + xvs.X26xFrames);
            if (x264mode == X264Mode.TwoPass && pass == 1)
                sb.Append(" -o NUL");
            else if (!string.IsNullOrEmpty(output))
                sb.Append(" -o " + output.Quote());
            if (!string.IsNullOrEmpty(input))
            {
                if (isAvs)
                    sb.Append(" " + input.Quote());
                else
                    sb.Append(" -");
            }
            return sb.ToString();
        }

        [Obsolete("Not used")]
        public static bool stringCheck(string str, string info = "")
        {
            if (string.IsNullOrEmpty(str))
            {
                MessageBox.Show("发现空或者无效的字符串 " + info);
            }
            return string.IsNullOrEmpty(str);
        }

        public string audiobat(string input, string output)
        {
            int AACbr = 1000 * Convert.ToInt32(AudioBitrateComboBox.Text);
            string br = AACbr.ToString();
            string ffmpeg = ToolsUtil.FFMPEG.quotedPath + " -i " + input.Quote() + " -vn -sn -v 0 -c:a pcm_s16le -f wav pipe:|";
            switch (AudioEncoderComboBox.SelectedIndex)
            {
                case 0:
                    if (AudioAudioModeBitrateRadioButton.Checked)
                    {
                        ffmpeg += ToolsUtil.NEROAACENC.quotedPath + " -ignorelength -lc -br " + br + " -if - -of " + output.Quote();
                    }
                    if (AudioAudioModeCustomRadioButton.Checked)
                    {
                        ffmpeg += ToolsUtil.NEROAACENC.quotedPath + " -ignorelength " + AudioCustomParameterTextBox.Text + " -if - -of " + output.Quote();
                    }
                    break;

                case 1:
                    if (AudioAudioModeBitrateRadioButton.Checked)
                    {
                        ffmpeg += ToolsUtil.QAAC.quotedPath + " -q 2 --ignorelength -c " + AudioBitrateComboBox.Text + " - -o " + output.Quote();
                    }
                    if (AudioAudioModeCustomRadioButton.Checked)
                    {
                        ffmpeg += ToolsUtil.QAAC.quotedPath + " --ignorelength " + AudioCustomParameterTextBox.Text + " - -o " + output.Quote();
                    }
                    break;

                case 2:
                    if (Path.GetExtension(output) == ".aac")
                        output = Path.ChangeExtension(output, ".wav");
                    ffmpeg = ToolsUtil.FFMPEG.quotedPath + " -y -i " + input.Quote() + " -f wav " + output.Quote();
                    break;

                case 3:
                    ffmpeg += ToolsUtil.REFALAC.quotedPath + " --ignorelength - -o " + output.Quote();
                    break;

                case 4:
                    ffmpeg += ToolsUtil.FLAC.quotedPath + " -f --ignore-chunk-sizes -5 - -o " + output.Quote();
                    break;

                case 5:
                    if (AudioAudioModeBitrateRadioButton.Checked)
                    {
                        ffmpeg += ToolsUtil.FDKAAC.quotedPath + " --ignorelength -b " + AudioBitrateComboBox.Text + " - -o " + output.Quote();
                    }
                    if (AudioAudioModeCustomRadioButton.Checked)
                    {
                        ffmpeg += ToolsUtil.FDKAAC.quotedPath + " --ignorelength " + AudioCustomParameterTextBox.Text + " - -o " + output.Quote();
                    }
                    break;

                case 6:
                    ffmpeg = ToolsUtil.FFMPEG.quotedPath + " -i " + input.Quote() + " -c:a ac3 -b:a " + AudioBitrateComboBox.Text + "k " + output.Quote();
                    break;

                case 7:
                    if (AudioAudioModeBitrateRadioButton.Checked)
                    {
                        ffmpeg += ToolsUtil.LAME.quotedPath + " -q 3 -b " + AudioBitrateComboBox.Text + " - " + output.Quote();
                    }
                    if (AudioAudioModeCustomRadioButton.Checked)
                    {
                        ffmpeg += ToolsUtil.LAME.quotedPath + " " + AudioCustomParameterTextBox.Text + " - " + output.Quote();
                    }
                    break;

                default:
                    break;
            }
            return ffmpeg + "\r\n";
        }

        private string getAudioExt()
        {
            string ext = ".aac";
            switch (AudioEncoderComboBox.SelectedIndex)
            {
                case 0: ext = ".mp4"; break;
                case 1: ext = ".m4a"; break;
                case 2: ext = ".wav"; break;
                case 3: ext = ".m4a"; break;
                case 4: ext = ".flac"; break;
                case 5: ext = ".m4a"; break;
                case 6: ext = ".ac3"; break;
                case 7: ext = ".mp3"; break;
                default: ext = ".aac"; break;
            }
            return ext;
        }

        private string ExtractAV(out string ext, string namevideo, MediaType av, int streamIndex = 0)
        {
            ext = Path.GetExtension(namevideo);
            //aextract = "\"" + workPath + "\\mp4box.exe\" -raw 2 \"" + namevideo + "\"";
            string aextract = "";
            aextract += FileStringUtil.FormatPath(ToolsUtil.FFMPEG.fullPath);
            aextract += " -i " + FileStringUtil.FormatPath(namevideo);

            switch (av)
            {
                case MediaType.Audio:
                    aextract += " -vn -sn -c:a copy -y -map 0:a:" + streamIndex + " ";

                    MediaInfoWrapper MIW = new MediaInfoWrapper(namevideo);
                    string audioFormat = MIW.a_format;
                    string audioProfile = MIW.a_formatProfile;
                    if (!string.IsNullOrEmpty(audioFormat))
                    {
                        if (audioFormat.Contains("MPEG") && audioProfile == "Layer 3")
                            ext = ".mp3";
                        else if (audioFormat.Contains("MPEG") && audioProfile == "Layer 2")
                            ext = ".mp2";
                        else if (audioFormat.Contains("PCM")) //flv support(PCM_U8 * PCM_S16BE * PCM_MULAW * PCM_ALAW * ADPCM_SWF)
                            ext = ".wav";
                        else if (audioFormat == "AAC")
                            ext = ".aac";
                        else if (audioFormat == "AC-3")
                            ext = ".ac3";
                        else if (audioFormat == "ALAC")
                            ext = ".m4a";
                        else
                            ext = ".mka";
                    }
                    else
                    {
                        //MessageBoxExt.ShowInfoMessage("该轨道无音频");
                        throw new Exception("该轨道无音频");
                    }
                    break;

                case MediaType.Video:
                    aextract += " -an -sn -c:v copy -y -map 0:v:" + streamIndex + " ";
                    break;

                default:
                    throw new InvalidEnumArgumentException();
            }

            return aextract;
        }

        private void ExecuteExtractAV(string namevideo, MediaType av, int streamIndex = 0)
        {
            if (string.IsNullOrEmpty(namevideo))
            {
                MessageBoxExt.ShowErrorMessage("请选择视频文件");
                return;
            }

            string ext = "";

            try
            {
                string aextract = ExtractAV(out ext, namevideo, av, streamIndex);
            }
            catch (Exception e)
            {
                MessageBoxExt.ShowInfoMessage(e.Message);
                return;
            }

            string suf = av == MediaType.Audio ? "_audio_" : "_video_";

            suf += "index" + streamIndex;
            string outfile = Path.ChangeExtension(namevideo, suf + ext);
            aextract += FileStringUtil.FormatPath(outfile);
            string batpath = ToolsUtil.ToolsFolder + "\\" + av + "extract.bat";
            File.WriteAllText(batpath, aextract, Encoding.Default);
            logger.Info(aextract);
            Process.Start(batpath);
        }

        private string ExtractAudio(string namevideo, string outfile, int streamIndex = 0)
        {
            if (string.IsNullOrEmpty(namevideo))
            {
                return "";
            }

            string ext;

            try
            {
                string aextract = ExtractAV(out ext, namevideo, MediaType.Audio, streamIndex);
                aextract += FileStringUtil.FormatPath(outfile) + "\r\n";
                return aextract;
            }
            catch
            {
                return "";
            }
        }

        private void ExtractTrack(string namevideo, int streamIndex)
        {
            if (string.IsNullOrEmpty(namevideo))
            {
                MessageBoxExt.ShowErrorMessage("请选择视频文件");
                return;
            }

            string aextract = "";
            aextract += FileStringUtil.FormatPath(ToolsUtil.FFMPEG.fullPath);
            aextract += " -i " + FileStringUtil.FormatPath(namevideo);
            aextract += " -map 0:" + streamIndex + " -c copy ";
            string suf = "_抽取流Index" + streamIndex;
            //string outfile = FileStringUtil.GetDir(namevideo) +
            //    Path.GetFileNameWithoutExtension(namevideo) + suf + '.' +
            //    FormatExtractor.Extract(workPath, namevideo)[streamIndex].Format;
            string outfile = Path.ChangeExtension(namevideo, suf + '.' +
                             FormatExtractor.Extract(namevideo)[streamIndex].Format);
            aextract += FileStringUtil.FormatPath(outfile);
            string batpath = ToolsUtil.ToolsFolder + "\\mkvextract.bat";
            File.WriteAllText(batpath, aextract, Encoding.Default);
            logger.Info(aextract);
            Process.Start(batpath);
        }

        #region Settings

        /// <summary>
        /// 还原默认参数
        /// </summary>
        private void ResetParameters()
        {
            AudioAudioModeBitrateRadioButton.Checked = true;
            AudioBitrateComboBox.Text = "128";
            AudioEncoderComboBox.SelectedIndex = 0;
            AudioPresetComboBox.SelectedIndex = 0;

            AvsIncludeAudioCheckBox.Checked = false;

            ConfigFunctionAutoCheckUpdateCheckBox.Checked = true;
            ConfigFunctionDeleteTempFileCheckBox.Checked = true;
            ConfigFunctionEnableX265CheckBox.Checked = false;
            ConfigUiSplashScreenCheckBox.Checked = true;
            ConfigUiTrayModeCheckBox.Checked = false;
            ConfigX264PriorityComboBox.SelectedIndex = 2;
            ConfigX264PriorityComboBox.SelectedIndex = 2;
            ConfigX264ThreadsComboBox.SelectedIndex = 0;

            MiscBlackBitrateNumericUpDown.Value = 900;
            MiscBlackCrfNumericUpDown.Value = 51;
            MiscBlackFpsNumericUpDown.Value = 1;
            MiscMiscBeginTimeMaskedTextBox.Text = "000000";
            MiscMiscEndTimeMaskedTextBox.Text = "000020";
            MiscMiscTransposeComboBox.SelectedIndex = 1;
            MiscOnePicBitrateNumericUpDown.Value = 128;
            MiscOnePicCrfNumericUpDown.Value = 24;
            MiscOnePicFpsNumericUpDown.Value = 1;

            MuxConvertAacEncoderComboBox.SelectedIndex = 0;
            MuxConvertFormatComboBox.Text = "flv";
            MuxMp4FpsComboBox.SelectedIndex = 0;
            MuxMp4ParComboBox.SelectedIndex = 0;

            VideoAudioModeComboBox.SelectedIndex = 0;
            VideoAudioParameterTextBox.Text = "--abitrate 128";
            VideoAutoShutdownCheckBox.Checked = false;
            VideoBitrateNumericUpDown.Value = 800;
            VideoCrfNumericUpDown.Value = 23.5m;
            VideoCustomParameterTextBox.Text = "";
            VideoDemuxerComboBox.SelectedIndex = 0;
            VideoFramesNumericUpDown.Value = 0;
            VideoHeightNumericUpDown.Value = 0;
            VideoModeCrfRadioButton.Checked = true;
            VideoSeekNumericUpDown.Value = 0;
            VideoWidthNumericUpDown.Value = 0;
        }

        private void LoadSettings()
        {
            try
            {
                //load settings

                if (settings.VideoEncoderIndex > VideoEncoderComboBox.Items.Count - 1)
                    VideoEncoderComboBox.SelectedIndex = 0;
                else
                    VideoEncoderComboBox.SelectedIndex = settings.VideoEncoderIndex;

                if (VideoEncoderComboBox.SelectedIndex == -1)
                {
                    VideoEncoderComboBox.SelectedIndex = VideoEncoderComboBox.Items.IndexOf(ToolsUtil.X264_32_8.fileName);//"x264_32-8bit"
                }

                AudioBitrateComboBox.Text = settings.AudioBitrateComboText;
                AudioEncoderComboBox.SelectedIndex = settings.AudioEncoderIndex;
                AvsScriptTextBox.Text = settings.AvsScriptText;
                ConfigFunctionAutoCheckUpdateCheckBox.Checked = settings.ConfigFunctionAutoCheckUpdateCheck;
                ConfigFunctionDeleteTempFileCheckBox.Checked = settings.ConfigFunctionDeleteTempFileCheck;
                ConfigFunctionEnableX265CheckBox.Checked = settings.ConfigFunctionEnableX265Check;
                ConfigFunctionVideoPlayerTextBox.Text = settings.ConfigFunctionVideoPlayerText;
                ConfigUiSplashScreenCheckBox.Checked = settings.ConfigUiSplashScreenCheck;
                ConfigUiTrayModeCheckBox.Checked = settings.ConfigUiTrayModeCheck;
                ConfigX264ExtraParameterTextBox.Text = settings.ConfigX264ExtraParameterText;
                ConfigX264PriorityComboBox.SelectedIndex = settings.ConfigX264PriorityIndex;
                ConfigX264ThreadsComboBox.SelectedIndex = settings.ConfigX264Threads;
                MiscBlackBitrateNumericUpDown.Value = settings.MiscBlackBitrateValue;
                MiscBlackCrfNumericUpDown.Value = settings.MiscBlackCrfValue;
                MiscBlackFpsNumericUpDown.Value = settings.MiscBlackFpsValue;
                MiscOnePicBitrateNumericUpDown.Value = settings.MiscOnePicBitrateValue;
                MiscOnePicCrfNumericUpDown.Value = settings.MiscOnePicCrfValue;
                MiscOnePicFpsNumericUpDown.Value = settings.MiscOnePicFpsValue;
                MuxConvertFormatComboBox.SelectedIndex = settings.MuxConvertFormatIndex;
                VideoAudioModeComboBox.SelectedIndex = settings.VideoAudioModeIndex;
                VideoAudioParameterTextBox.Text = settings.VideoAudioParameterText;
                VideoBatchSubtitleLanguage.DataSource = settings.VideoBatchSubtitleLanguage.Split(',');
                VideoBitrateNumericUpDown.Value = settings.VideoBitrateValue;
                VideoCrfNumericUpDown.Value = settings.VideoCrfValue;
                VideoCustomParameterTextBox.Text = settings.VideoCustomParameterText;
                VideoDemuxerComboBox.SelectedIndex = settings.VideoDemuxerIndex;
                VideoHeightNumericUpDown.Value = settings.VideoHeightValue;
                VideoWidthNumericUpDown.Value = settings.VideoWidthValue;

                if (settings.ConfigUiLanguageIndex == -1)  //First Startup
                {
                    string culture = Thread.CurrentThread.CurrentCulture.Name;
                    switch (culture)
                    {
                        case "zh-CN":
                        case "zh-SG":
                            ConfigUiLanguageComboBox.SelectedIndex = 0;
                            break;

                        case "zh-TW":
                        case "zh-HK":
                        case "zh-MO":
                            ConfigUiLanguageComboBox.SelectedIndex = 1;
                            break;

                        case "en-US":
                            ConfigUiLanguageComboBox.SelectedIndex = 2;
                            break;

                        case "ja-JP":
                            ConfigUiLanguageComboBox.SelectedIndex = 3;
                            break;

                        default:
                            break;
                    }
                }
                else
                    ConfigUiLanguageComboBox.SelectedIndex = settings.ConfigUiLanguageIndex;

                if (ConfigFunctionAutoCheckUpdateCheckBox.Checked && NetworkUtil.IsConnectInternet())
                {
                    DateTime d;
                    bool f;
                    CheckUpadateDelegate checkUpdateDelegate = CheckUpdate;
                    checkUpdateDelegate.BeginInvoke(out d, out f, new AsyncCallback(CheckUpdateCallBack), null);
                }
                VideoEncoderComboBox_SelectedIndexChanged(null, null);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SaveSettings()
        {
            settings.VideoCrfValue = VideoCrfNumericUpDown.Value;
            settings.VideoBitrateValue = VideoBitrateNumericUpDown.Value;
            settings.VideoAudioParameterText = VideoAudioParameterTextBox.Text;
            settings.VideoAudioModeIndex = VideoAudioModeComboBox.SelectedIndex;
            settings.VideoEncoderIndex = VideoEncoderComboBox.SelectedIndex;
            settings.VideoDemuxerIndex = VideoDemuxerComboBox.SelectedIndex;
            settings.VideoWidthValue = VideoWidthNumericUpDown.Value;
            settings.VideoHeightValue = VideoHeightNumericUpDown.Value;
            settings.VideoCustomParameterText = VideoCustomParameterTextBox.Text;
            settings.ConfigX264PriorityIndex = ConfigX264PriorityComboBox.SelectedIndex;
            settings.ConfigX264ExtraParameterText = ConfigX264ExtraParameterTextBox.Text;
            settings.AvsScriptText = AvsScriptTextBox.Text;
            settings.AudioEncoderIndex = AudioEncoderComboBox.SelectedIndex;
            settings.AudioBitrateComboText = AudioBitrateComboBox.Text;
            settings.MiscOnePicBitrateValue = MiscOnePicBitrateNumericUpDown.Value;
            settings.MiscOnePicFpsValue = MiscOnePicFpsNumericUpDown.Value;
            settings.MiscOnePicCrfValue = MiscOnePicCrfNumericUpDown.Value;
            settings.MiscBlackFpsValue = MiscBlackFpsNumericUpDown.Value;
            settings.MiscBlackCrfValue = MiscBlackCrfNumericUpDown.Value;
            settings.MiscBlackBitrateValue = MiscBlackBitrateNumericUpDown.Value;
            settings.ConfigFunctionDeleteTempFileCheck = ConfigFunctionDeleteTempFileCheckBox.Checked;
            settings.ConfigFunctionAutoCheckUpdateCheck = ConfigFunctionAutoCheckUpdateCheckBox.Checked;
            settings.ConfigUiTrayModeCheck = ConfigUiTrayModeCheckBox.Checked;
            settings.ConfigUiLanguageIndex = ConfigUiLanguageComboBox.SelectedIndex;
            settings.ConfigUiSplashScreenCheck = ConfigUiSplashScreenCheckBox.Checked;
            settings.ConfigX264Threads = ConfigX264ThreadsComboBox.SelectedIndex;
            settings.ConfigFunctionEnableX265Check = ConfigFunctionEnableX265CheckBox.Checked;
            settings.ConfigFunctionVideoPlayerText = ConfigFunctionVideoPlayerTextBox.Text;
            settings.MuxConvertFormatIndex = MuxConvertFormatComboBox.SelectedIndex;
            settings.VideoBatchSubtitleLanguage = "none,sc,tc,chs,cht,en,jp";

            settings.Save();
        }

        #endregion Settings

        private void LoadVideoPreset()
        {
            VideoPresetComboBox.Items.Clear();
            string encType = VideoEncoderComboBox.SelectedItem.ToString().Contains("x265") ? "x265" : "x264";
            var xlsv = preset.GetVideoPreset(encType).Elements();
            foreach (var item in xlsv)
            {
                VideoPresetComboBox.Items.Add(item.Attribute("Name").Value);
            }
            if (VideoPresetComboBox.Items.Count > 0 && VideoPresetComboBox.SelectedIndex == -1)
                VideoPresetComboBox.SelectedIndex = 0;
        }

        private void LoadAudioPreset()
        {
            AudioPresetComboBox.Items.Clear();
            var xlsa = preset.GetAudioPreset(AudioEncoderComboBox.Text).Elements();
            foreach (var item in xlsa)
            {
                AudioPresetComboBox.Items.Add(item.Attribute("Name").Value);
            }
            if (AudioPresetComboBox.Items.Count > 0 && AudioPresetComboBox.SelectedIndex == -1)
                AudioPresetComboBox.SelectedIndex = 0;
        }

        #region VideoBatch

        public string VideoBatch(string input, string output)
        {
            bool hasAudio = false;
            string bat = "";
            string inputName = Path.GetFileNameWithoutExtension(input);
            string tempVideo = Path.Combine(Global.Running.tempFolder, inputName + "_vtemp.mp4");
            string tempAudio = Path.Combine(Global.Running.tempFolder, inputName + "_atemp" + getAudioExt());
            // 避免编码失败最后混流使用上次的同名临时文件造成编码成功的假象
            if (File.Exists(tempVideo)) File.Delete(tempVideo);
            if (File.Exists(tempAudio)) File.Delete(tempAudio);

            //检测是否含有音频
            string audio = new MediaInfoWrapper(input).a_format;
            if (!string.IsNullOrEmpty(audio)) { hasAudio = true; }
            string language = VideoBatchSubtitleLanguage.Text == "none" ? string.Empty : VideoBatchSubtitleLanguage.Text;
            string sub = (VideoBatchSubtitleCheckBox.Checked) ? FileStringUtil.SpeculateSubtitlePath(input, language) : string.Empty;

            int audioMode = VideoAudioModeComboBox.SelectedIndex;
            if (!hasAudio)
                audioMode = 1;
            switch (audioMode)
            {
                case 0:
                    aextract = audiobat(input, tempAudio);
                    break;

                case 1:
                    aextract = string.Empty;
                    break;

                case 2:
                    if (audio.ToLower() == "aac")
                    {
                        tempAudio = Path.Combine(Global.Running.tempFolder, inputName + "_atemp.aac");
                        aextract = ExtractAudio(input, tempAudio);
                    }
                    else
                        aextract = audiobat(input, tempAudio);
                    break;

                default:
                    break;
            }

            if (VideoEncoderComboBox.SelectedItem.ToString().ToLower().Contains("x264"))
            {
                if (x264mode == X264Mode.TwoPass)
                    x264 = x264bat(input, tempVideo, 1, sub) + "\r\n" +
                           x264bat(input, tempVideo, 2, sub);
                else x264 = x264bat(input, tempVideo, 0, sub);
                if (audioMode == 1 || !hasAudio)
                    x264 = x264.Replace(tempVideo, output);
            }
            else if (VideoEncoderComboBox.SelectedItem.ToString().ToLower().Contains("x265"))
            {
                tempVideo = Path.Combine(Global.Running.tempFolder, inputName + "_vtemp.hevc");
                if (x264mode == X264Mode.TwoPass)
                    x264 = x265bat(input, tempVideo, 1, sub) + "\r\n" +
                           x265bat(input, tempVideo, 2, sub);
                else x264 = x265bat(input, tempVideo, 0, sub);
                if (audioMode == 1 || !hasAudio)
                    x264 += "\r\n" + ToolsUtil.MP4BOX.quotedPath + "  -add  \"" + tempVideo + "#trackID=1:name=\" -new " + output.Quote() + " \r\n";
            }
            x264 += "\r\n";

            //封装
            string mux = string.Empty;
            if (VideoBatchFormatComboBox.Text == "mp4")
                mux = MP4MuxCommand(tempVideo, tempAudio, output);
            else
                mux = FFMpegMuxCommand(tempVideo, tempAudio, output);

            if (audioMode != 1 && hasAudio) //如果压制音频
                bat += aextract + x264 + mux + " \r\n";
            else
                bat += x264 + " \r\n";

            bat += "del " + tempAudio.Quote() + "\r\n";
            bat += "del " + tempVideo.Quote() + "\r\n";
            bat += "echo ===== one file is completed! =====\r\n";
            return bat;
        }

        private void VideoBatchItemListbox_DragDrop(object sender, DragEventArgs e)
        {
            ListBox listbox = (ListBox)sender;
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                String[] files = (String[])e.Data.GetData(DataFormats.FileDrop);
                foreach (String s in files)
                {
                    listbox.Items.Add(s);
                }
                return;
            }
            targetIndex = listbox.IndexFromPoint(listbox.PointToClient(new Point(e.X, e.Y)));
            if (targetIndex != ListBox.NoMatches)
            {
                string temp = listbox.Items[targetIndex].ToString();
                listbox.Items[targetIndex] = listbox.Items[sourceIndex];
                listbox.Items[sourceIndex] = temp;
                listbox.SelectedIndex = targetIndex;
            }
        }

        private void VideoBatchItemListbox_DragEnter(object sender, DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(DataFormats.FileDrop))
            //    e.Effect = DragDropEffects.All;
            //else e.Effect = DragDropEffects.None;
        }

        private void VideoBatchItemListbox_DragOver(object sender, DragEventArgs e)
        {
            //拖动源和放置的目的地一定是一个ListBox
            ListBox listbox = (ListBox)sender;
            if (e.Data.GetDataPresent(typeof(System.String)) && ((ListBox)sender).Equals(listbox))
            {
                e.Effect = DragDropEffects.Move;
            }
            else if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else e.Effect = DragDropEffects.None;
        }

        private void VideoBatchItemListbox_MouseDown(object sender, MouseEventArgs e)
        {
            sourceIndex = ((ListBox)sender).IndexFromPoint(e.X, e.Y);
            if (sourceIndex == 65535)   // when the listbox is empty
                return;
            if (sourceIndex != ListBox.NoMatches)
            {
                ((ListBox)sender).DoDragDrop(((ListBox)sender).Items[sourceIndex].ToString(), DragDropEffects.All);
            }
        }

        private void VideoBatchStartButton_Click(object sender, EventArgs e)
        {
            if (VideoBatchItemListbox.Items.Count == 0)
            {
                MessageBoxExt.ShowErrorMessage("请输入视频！");
                return;
            }

            if (VideoEncoderComboBox.SelectedIndex == -1)
            {
                MessageBoxExt.ShowErrorMessage("请选择X264程序");
                return;
            }

            if (AudioEncoderComboBox.SelectedIndex != 0 && AudioEncoderComboBox.SelectedIndex != 1 && AudioEncoderComboBox.SelectedIndex != 5)
            {
                DialogResult r = MessageBoxExt.ShowQuestion("音频页面中的编码器未采用AAC将可能导致压制失败，建议将编码器改为QAAC、NeroAAC或FDKAAC。是否继续压制？", "提示");
                if (r == DialogResult.No)
                    return;
            }

            FileStringUtil.ensureDirectoryExists(Global.Running.tempFolder);
            string bat = string.Empty;
            for (int i = 0; i < this.VideoBatchItemListbox.Items.Count; i++)
            {
                string input = VideoBatchItemListbox.Items[i].ToString();
                string output;
                if (Directory.Exists(VideoBatchOutputFolderTextBox.Text))
                    output = VideoBatchOutputFolderTextBox.Text + "\\" + Path.GetFileNameWithoutExtension(input) + "_batch." + VideoBatchFormatComboBox.Text;
                else
                    output = Path.ChangeExtension(input, "_batch." + VideoBatchFormatComboBox.Text);
                bat += VideoBatch(VideoBatchItemListbox.Items[i].ToString(), output);
            }

            logger.Info(bat);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(GetCultureName());
            new WorkingForm(bat, VideoBatchItemListbox.Items.Count) { Owner = this }.Show();
            //batpath = workPath + "\\auto.bat";
            //File.WriteAllText(batpath, bat, Encoding.Default);
            //Process.Start(batpath);
        }

        #endregion VideoBatch

        #region Mux Tab

        #region MuxMkv

        private void MuxMkvVideoInputButton_Click(object sender, EventArgs e)
        {
            new OpenFileDialog() //"所有文件(*.*)|*.*"
                .Prepare(DialogFilter.ALL, MuxMkvVideoInputTextBox.Text)
                .ShowDialogExt(MuxMkvVideoInputTextBox);
        }

        private void MuxMkvStartButton_Click(object sender, EventArgs e)
        {
            if (MuxMkvVideoInputTextBox.Text == "" && MuxMkvAudioInputTextBox.Text == "")
            {
                MessageBoxExt.ShowErrorMessage("请选择文件");
                return;
            }

            MuxMkvProcedure muxMkvProcedure = new MuxMkvProcedure();
            muxMkvProcedure.GetDataFromUI(p =>
            {
                p.output = MuxMkvOutputTextBox.Text;
                p.videoInput = MuxMkvVideoInputTextBox.Text;
                p.audioInput = MuxMkvAudioInputTextBox.Text;
                p.subtitleInput = MuxMkvSubtitleTextBox.Text;
            });
            muxMkvProcedure.Execute();
        }

        private void MuxMkvOutputButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = DialogFilter.VIDEO_2; //"视频(*.mkv)|*.mkv";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                MuxMkvOutputTextBox.Text = saveFileDialog.FileName;
            }
        }

        private void MuxMkvAudioInputButton_Click(object sender, EventArgs e)
        {
            new OpenFileDialog() //"音频(*.mp3;*.aac;*.ac3)|*.mp3;*.aac;*.ac3|所有文件(*.*)|*.*"
                .Prepare(DialogFilter.AUDIO_1, MuxMkvAudioInputTextBox.Text)
                .ShowDialogExt(MuxMkvAudioInputTextBox);
        }

        private void MuxMkvSubtitleButton_Click(object sender, EventArgs e)
        {
            new OpenFileDialog() //"字幕(*.ass;*.ssa;*.srt;*.idx;*.sup)|*.ass;*.ssa;*.srt;*.idx;*.sup|所有文件(*.*)|*.*"
                .Prepare(DialogFilter.SUBTITLE_2, MuxMkvSubtitleTextBox.Text)
                .ShowDialogExt(MuxMkvSubtitleTextBox);
        }

        private void MuxMkvVideoInputTextBox_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(MuxMkvVideoInputTextBox.Text))
            {
                string muxMkvVideoInput = MuxMkvVideoInputTextBox.Text;
                string outputFileName = muxMkvVideoInput.Remove(muxMkvVideoInput.LastIndexOf("."));
                outputFileName += "_mkv封装.mkv";
                MuxMkvOutputTextBox.Text = outputFileName;
            }
        }

        private void MuxMkvOutputTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (File.Exists(MuxMkvOutputTextBox.Text))
            {
                Process.Start(MuxMkvOutputTextBox.Text);
            }
        }

        private void MuxMkvVideoInputTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (File.Exists(MuxMkvVideoInputTextBox.Text))
            {
                Process.Start(MuxMkvVideoInputTextBox.Text);
            }
        }

        private void MuxMkvAudioInputTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (File.Exists(MuxMkvAudioInputTextBox.Text))
            {
                Process.Start(MuxMkvAudioInputTextBox.Text);
            }
        }

        #endregion MuxMkv

        #region MuxMp4

        private void MuxMp4VideoInputTextBox_TextChanged(object sender, EventArgs e)
        {
            MuxMp4OutputTextBox.Text = Path.ChangeExtension(MuxMp4VideoInputTextBox.Text, "_Mux.mp4");
        }

        public bool MuxMp4Validation()
        {
            if (MuxMp4VideoInputTextBox.Text == "")
            {
                MessageBoxExt.ShowErrorMessage("请选择视频文件");
                return false;
            }
            if (MuxMp4AudioInputTextBox.Text == "")
            {
                MessageBoxExt.ShowErrorMessage("请选择音频文件");
                return false;
            }
            if (MuxMp4OutputTextBox.Text == "")
            {
                MessageBoxExt.ShowErrorMessage("请选择输出文件");
                return false;
            }

            if (MuxMp4VideoInputTextBox.Text.Length > 0)
            {
                if (!File.Exists(MuxMp4VideoInputTextBox.Text))
                {
                    MessageBoxExt.ShowErrorMessage("输入文件: \r\n\r\n" + MuxMp4VideoInputTextBox.Text + "\r\n\r\n不存在!");
                    return false;
                }
                string inputExt = Path.GetExtension(MuxMp4VideoInputTextBox.Text).ToLower();
                if (inputExt != ".avi"  //Only MPEG-4 SP/ASP video and MP3 audio supported at the current time. To import AVC/H264 video, you must first extract the avi track.
                        && inputExt != ".mp4" //MPEG-4 Video
                        && inputExt != ".m1v" //MPEG-1 Video
                        && inputExt != ".m2v" //MPEG-2 Video
                        && inputExt != ".m4v" //MPEG-4 Video
                        && inputExt != ".264" //AVC/H264 Video
                        && inputExt != ".h264" //AVC/H264 Video
                        && inputExt != ".hevc") //HEVC/H265 Video
                {
                    MessageBoxExt.ShowWarningMessage("输入文件: \r\n\r\n" + MuxMp4VideoInputTextBox.Text + "\r\n\r\n是一个mp4box不支持的视频文件!");
                    return false;
                }
                if (inputExt == ".264" || inputExt == ".h264" || inputExt == ".hevc")
                {
                    MessageBoxExt.ShowWarningMessage("H.264或者HEVC流文件mp4box将会自动侦测帧率\r\n如果侦测不到将默认为25fps\r\n如果你知道该文件的帧率建议手动设置");
                    return false;
                }

            }

            if (MuxMp4AudioInputTextBox.Text.Length > 0)
            {
                if (!File.Exists(MuxMp4AudioInputTextBox.Text))
                {
                    MessageBoxExt.ShowErrorMessage("输入文件: \r\n\r\n" + MuxMp4AudioInputTextBox.Text + "\r\n\r\n不存在!");
                    return false;
                }
                string inputExt = Path.GetExtension(MuxMp4AudioInputTextBox.Text).ToLower();
                if (inputExt != ".mp4"
                        && inputExt != ".aac" //ADIF or RAW formats not supported
                        && inputExt != ".mp3"
                        && inputExt != ".m4a"
                        && inputExt != ".mp2"
                        && inputExt != ".ac3")
                {
                    MessageBoxExt.ShowErrorMessage("输入文件: \r\n\r\n" + MuxMp4AudioInputTextBox.Text.Trim() + "\r\n\r\n是一个mp4box不支持的音频文件!");
                    return false;
                }
            }
            return true;
        }

        private void MuxMp4AudioInputButton_Click(object sender, EventArgs e)
        {
            new OpenFileDialog() //"音频(*.mp4;*.aac;*.mp2;*.mp3;*.m4a;*.ac3)|*.mp4;*.aac;*.mp2;*.mp3;*.m4a;*.ac3|所有文件(*.*)|*.*"
                .Prepare(DialogFilter.AUDIO_3, MuxMp4AudioInputTextBox.Text)
                .ShowDialogExt(MuxMp4AudioInputTextBox);
        }

        private void MuxMp4VideoInputButton_Click(object sender, EventArgs e)
        {
            new OpenFileDialog() //"视频(*.avi;*.mp4;*.m1v;*.m2v;*.m4v;*.264;*.h264;*.hevc)|*.avi;*.mp4;*.m1v;*.m2v;*.m4v;*.264;*.h264;*.hevc|所有文件(*.*)|*.*"
                .Prepare(DialogFilter.VIDEO_9, MuxMp4VideoInputTextBox.Text)
                .ShowDialogExt(MuxMp4VideoInputTextBox);
        }

        private void MuxMp4OutputButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = DialogFilter.VIDEO_3;  //"视频(*.mp4)|*.mp4";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                MuxMp4OutputTextBox.Text = savefile.FileName;
            }
        }

        private void GetMuxMp4DataFromUI(MuxMp4Procedure p)
        {
            p.videoInputFile = MuxMp4VideoInputTextBox.Text;
            p.audioInputFile = MuxMp4AudioInputTextBox.Text;
            p.outputFile = MuxMp4OutputTextBox.Text;
            p.fpsStr = MuxMp4FpsComboBox.Text;
            p.parStr = MuxMp4ParComboBox.Text;
        }

        private void MuxMp4StartButton_Click(object sender, EventArgs e)
        {
            if (!MuxMp4Validation())
                return;

            MuxMp4Procedure procedure = new MuxMp4Procedure();
            procedure.GetDataFromUI(GetMuxMp4DataFromUI);
            procedure.Execute();
        }

        private void MuxMp4OutputTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (File.Exists(MuxMp4OutputTextBox.Text))
            {
                Process.Start(MuxMp4OutputTextBox.Text);
            }
        }

        private void MuxMp4VideoInputTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (File.Exists(MuxMp4VideoInputTextBox.Text))
            {
                Process.Start(MuxMp4VideoInputTextBox.Text);
            }
        }

        private void MuxMp4FpsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ext = Path.GetExtension(MuxMp4VideoInputTextBox.Text).ToLower();
            if (MuxMp4FpsComboBox.SelectedIndex != 0 && ext != ".264" && ext != ".h264" && ext != ".hevc")
            {
                MessageBoxExt.ShowWarningMessage("只有扩展名为.264 .h264 .hevc的流文件设置帧率(fps)才有效");
                MuxMp4FpsComboBox.SelectedIndex = 0;
            }
        }

        private void MuxMp4ReplaceAudioButton_Click(object sender, EventArgs e)
        {
            if (!MuxMp4Validation())
                return;

            MuxMp4Procedure procedure = new MuxMp4Procedure();
            procedure.GetDataFromUI(GetMuxMp4DataFromUI);
            procedure.ExecuteReplaceAudio();

        }

        #endregion MuxMp4

        #region MuxConvert

        private void MuxConvertItemListBox_MouseDown(object sender, MouseEventArgs e)
        {
            sourceIndex = ((ListBox)sender).IndexFromPoint(e.X, e.Y);
            if (sourceIndex != ListBox.NoMatches)
            {
                ((ListBox)sender).DoDragDrop(((ListBox)sender).Items[sourceIndex].ToString(), DragDropEffects.All);
            }
        }

        private void MuxConvertItemListBox_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                String[] files = (String[])e.Data.GetData(DataFormats.FileDrop);
                foreach (String s in files)
                {
                    (sender as ListBox).Items.Add(s);
                }
            }
            ListBox listbox = (ListBox)sender;
            targetIndex = listbox.IndexFromPoint(listbox.PointToClient(new Point(e.X, e.Y)));
            if (targetIndex != ListBox.NoMatches)
            {
                string temp = listbox.Items[targetIndex].ToString();
                listbox.Items[targetIndex] = listbox.Items[sourceIndex];
                listbox.Items[sourceIndex] = temp;
                listbox.SelectedIndex = targetIndex;
            }
        }

        private void MuxConvertItemListBox_DragOver(object sender, DragEventArgs e)
        {
            //拖动源和放置的目的地一定是一个ListBox
            if (e.Data.GetDataPresent(typeof(System.String)) && ((ListBox)sender).Equals(MuxConvertItemListBox))
            {
                e.Effect = DragDropEffects.Move;
            }
            else if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else e.Effect = DragDropEffects.None;
        }

        private void MuxConvertAddButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog().Prepare(DialogFilter.ALL); //"所有文件(*.*)|*.*";
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                MuxConvertItemListBox.Items.AddRange(openFileDialog.FileNames);
            }
        }

        private void MuxConvertDeleteButton_Click(object sender, EventArgs e)
        {
            RemoveSelectedItemFromListBox(MuxConvertItemListBox);
        }

        private void MuxConvertClearButton_Click(object sender, EventArgs e)
        {
            MuxConvertItemListBox.Items.Clear();
        }

        private void MuxConvertStartButton_Click(object sender, EventArgs e)
        {
            if (MuxConvertItemListBox.Items.Count == 0)
            {
                MessageBoxExt.ShowErrorMessage("请输入视频！");
                return;
            }

            string ext = MuxConvertFormatComboBox.Text;
            string mux = "";

            foreach (var sourceItem in MuxConvertItemListBox.Items)
            {
                string sourceFilePath = sourceItem.ToString();
                //如果是源文件的格式和目标格式相同则跳过
                if (Path.GetExtension(sourceFilePath).Contains(ext))
                    continue;
                string targetFilePath = Path.ChangeExtension(sourceFilePath, ext);
                aextract = "";

                //检测音频是否需要转换为AAC
                string audio = new MediaInfoWrapper(sourceFilePath).a_format;
                if (audio.ToLower() != "aac" && MuxConvertFormatComboBox.Text != "mkv")
                {
                    mux += ToolsUtil.FFMPEG.quotedPath + " -y -i " + sourceFilePath.Quote() + " -c:v copy -c:a " + MuxConvertAacEncoderComboBox.Text + " -strict -2 " + targetFilePath.Quote() + " \r\n";
                }
                else
                {
                    mux += ToolsUtil.FFMPEG.quotedPath + " -y -i " + sourceFilePath.Quote() + " -c copy " + targetFilePath.Quote() + " \r\n";
                }
            }
            mux += "\r\ncmd";
            string batpath = ToolsUtil.ToolsFolder + "\\mux.bat";
            File.WriteAllText(batpath, mux, Encoding.Default);
            logger.Info(mux);
            Process.Start(batpath);

        }

        #endregion MuxConvert

        #endregion Mux Tab

        #region Extract Tab

        #region ExtractMkv

        private void ExtractMkvInputTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (File.Exists(ExtractMkvInputTextBox.Text))
            {
                Process.Start(ExtractMkvInputTextBox.Text);
            }
        }

        private void ExtractMkvExtractByExternalButton_Click(object sender, EventArgs e)
        {
            string path = ToolsUtil.GMKVEXTRACTGUI.fullPath;
            if (File.Exists(path))
                Process.Start(path);
            else
                MessageBoxExt.ShowErrorMessage("请检查\r\n\r\n" + path + "\r\n\r\n是否存在", "未找到程序!");
        }

        private void ExtractMkvInputButton_Click(object sender, EventArgs e)
        {
            new OpenFileDialog() //"视频(*.mkv)|*.mkv"
                .Prepare(DialogFilter.VIDEO_2, ExtractMkvInputTextBox.Text)
                .ShowDialogExt(ExtractMkvInputTextBox);
        }

        private void ExtractMkvExtractTrack0Button_Click(object sender, EventArgs e)
        {
            //MKV 抽0
            ExtractTrack(ExtractMkvInputTextBox.Text, 0);
        }

        private void ExtractMkvExtractTrack1Button_Click(object sender, EventArgs e)
        {
            //MKV 抽1
            ExtractTrack(ExtractMkvInputTextBox.Text, 1);
        }

        private void ExtractMkvExtractTrack2Button_Click(object sender, EventArgs e)
        {
            //MKV 抽2
            ExtractTrack(ExtractMkvInputTextBox.Text, 2);
        }

        private void ExtractMkvExtractTrack3Button_Click(object sender, EventArgs e)
        {
            //MKV 抽3
            ExtractTrack(ExtractMkvInputTextBox.Text, 3);
        }

        private void ExtractMkvExtractTrack4Button_Click(object sender, EventArgs e)
        {
            //MKV 抽4
            ExtractTrack(ExtractMkvInputTextBox.Text, 4);
        }

        #endregion ExtractMkv

        #region ExtractFlv

        private void ExtractFlvExtractVideoButton_Click(object sender, EventArgs e)
        {
            //FLV vcopy
            ExecuteExtractAV(ExtractFlvInputTextBox.Text, MediaType.Video, 0);
        }

        private void ExtractFlvExtractAudioButton_Click(object sender, EventArgs e)
        {
            //FLV acopy
            ExecuteExtractAV(ExtractFlvInputTextBox.Text, MediaType.Audio, 0);
        }

        private void ExtractFlvInputButton_Click(object sender, EventArgs e)
        {
            new OpenFileDialog() //"视频(*.flv;*.hlv)|*.flv;*.hlv"
                .Prepare(DialogFilter.VIDEO_4, ExtractFlvInputTextBox.Text)
                .ShowDialogExt(ExtractFlvInputTextBox);
        }

        private void ExtractFlvInputTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (File.Exists(ExtractFlvInputTextBox.Text))
            {
                Process.Start(ExtractFlvInputTextBox.Text);
            }
        }

        #endregion ExtractFlv

        #region ExtractMp4

        private void ExtractMp4InputButton_Click(object sender, EventArgs e)
        {
            new OpenFileDialog() //"视频(*.mp4)|*.mp4|所有文件(*.*)|*.*"
                .Prepare(DialogFilter.VIDEO_5, ExtractMp4InputTextBox.Text)
                .ShowDialogExt(ExtractMp4InputTextBox);
        }

        private void ExtractMp4ExtractAudio1Button_Click(object sender, EventArgs e)
        {
            //MP4 抽取音频1
            ExecuteExtractAV(ExtractMp4InputTextBox.Text, MediaType.Audio, 0);
        }

        private void ExtractMp4ExtractAudio2Button_Click(object sender, EventArgs e)
        {
            //MP4 抽取音频2
            ExecuteExtractAV(ExtractMp4InputTextBox.Text, MediaType.Audio, 1);
        }

        private void ExtractMp4ExtractAudio3Button_Click(object sender, EventArgs e)
        {
            //MP4 抽取音频3
            ExecuteExtractAV(ExtractMp4InputTextBox.Text, MediaType.Audio, 2);
        }

        private void ExtractMp4ExtractVideoButton_Click(object sender, EventArgs e)
        {
            //MP4 抽取视频1
            ExecuteExtractAV(ExtractMp4InputTextBox.Text, MediaType.Video, 0);
        }

        #endregion ExtractMp4

        #endregion Extract Tab

        #region Help Tab

        private void HelpAboutButton_Click(object sender, EventArgs e)
        {
            DateTime CompileDate = File.GetLastWriteTime(this.GetType().Assembly.Location); //获得程序编译时间
            QQMessageBox.Show(
                this,
                "主页：http://maruko.appinn.me/ \r\n编译日期：" + ReleaseDate.ToString() + "\r\n作者：小七、月儿、小丸",
                "关于",
                QQMessageBoxIcon.Information,
                QQMessageBoxButtons.OK);
        }

        private void HelpHomepageButton_Click(object sender, EventArgs e)
        {
            Process.Start("http://maruko.appinn.me/");
        }

        private void HelpContentRichTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        private void HelpFeedbackButton_Click(object sender, EventArgs e)
        {
            new FeedbackForm().ShowDialog();
        }

        private void HelpReleaseDateLabel_DoubleClick(object sender, EventArgs e)
        {
            new SplashForm() { Owner = this }.Show();
        }

        #endregion Help Tab

        #region Video Tab

        private void VideoInputButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = DialogFilter.VIDEO_8; //"视频(*.mp4;*.flv;*.mkv;*.avi;*.wmv;*.mpg;*.avs)|*.mp4;*.flv;*.mkv;*.avi;*.wmv;*.mpg;*.avs|所有文件(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                videoInput = openFileDialog1.FileName;
                VideoInputTextBox.Text = videoInput;
            }
        }

        private void VideoOutputButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = DialogFilter.VIDEO_D_3; //"MPEG-4 视频(*.mp4)|*.mp4|Flash 视频(*.flv)|*.flv|Matroska 视频(*.mkv)|*.mkv|AVI 视频(*.avi)|*.avi|H.264 流(*.raw)|*.raw";
            savefile.FileName = Path.GetFileName(VideoOutputTextBox.Text);
            DialogResult result = savefile.ShowDialog();
            if (result == DialogResult.OK)
            {
                videoOutput = savefile.FileName;
                VideoOutputTextBox.Text = videoOutput;
            }
        }

        private void VideoSubtitleButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = DialogFilter.SUBTITLE_1; //"字幕(*.ass;*.ssa;*.srt)|*.ass;*.ssa;*.srt|所有文件(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                videoSubtitle = openFileDialog1.FileName;
                VideoSubtitleTextBox.Text = videoSubtitle;
            }
        }

        private void VideoStartButton_Click(object sender, EventArgs e)
        {
            #region validation

            if (string.IsNullOrEmpty(videoInput))
            {
                MessageBoxExt.ShowErrorMessage("请选择视频文件");
                return;
            }

            if (!string.IsNullOrEmpty(videoSubtitle) && !File.Exists(videoSubtitle))
            {
                MessageBoxExt.ShowErrorMessage("字幕文件不存在，请重新选择");
                return;
            }

            if (string.IsNullOrEmpty(videoOutput))
            {
                MessageBoxExt.ShowErrorMessage("请选择输出文件");
                return;
            }

            if (VideoEncoderComboBox.SelectedIndex == -1)
            {
                MessageBoxExt.ShowErrorMessage("请选择X264程序");
                return;
            }

            if (AudioEncoderComboBox.SelectedIndex != 0 && AudioEncoderComboBox.SelectedIndex != 1 && AudioEncoderComboBox.SelectedIndex != 5)
            {
                DialogResult r = MessageBoxExt.ShowQuestion("音频页面中的编码器未采用AAC将可能导致压制失败，建议将编码器改为QAAC、NeroAAC或FDKAAC。是否继续压制？", "提示");
                if (r == DialogResult.No)
                    return;
            }

            //防止未选择 x264 thread
            if (ConfigX264ThreadsComboBox.SelectedIndex == -1)
            {
                ConfigX264ThreadsComboBox.SelectedIndex = 0;
            }

            //目标文件已经存在提示是否覆盖
            if (File.Exists(VideoOutputTextBox.Text.Trim()))
            {
                DialogResult dgs = MessageBoxExt.ShowQuestion("目标文件:\r\n\r\n" + VideoOutputTextBox.Text.Trim() + "\r\n\r\n已经存在,是否覆盖继续压制？", "目标文件已经存在");
                if (dgs == DialogResult.No) return;
            }

            //如果是AVS复制到C盘根目录
            if (Path.GetExtension(VideoInputTextBox.Text) == ".avs")
            {
                if (string.IsNullOrEmpty(FileStringUtil.CheckAviSynth()) && string.IsNullOrEmpty(FileStringUtil.CheckInternalAviSynth()))
                {
                    if (MessageBoxExt.ShowQuestion("检测到本机未安装avisynth无法继续压制，是否去下载安装", "avisynth未安装") == DialogResult.Yes)
                        Process.Start("http://sourceforge.net/projects/avisynth2/");
                    return;
                }
                //if (File.Exists(tempavspath)) File.Delete(tempavspath);
                File.Copy(VideoInputTextBox.Text, Global.Running.tempAvsFile, true);
                videoInput = Global.Running.tempAvsFile;
                VideoDemuxerComboBox.SelectedIndex = 0; //压制AVS始终使用分离器为auto
            }

            #endregion validation

            string targetExt = Path.GetExtension(videoOutput).ToLower();
            bool hasAudio = false;
            string inputName = Path.GetFileNameWithoutExtension(videoInput);
            string tempVideo = Path.Combine(Global.Running.tempFolder, inputName + "_vtemp.mp4");
            string tempAudio = Path.Combine(Global.Running.tempFolder, inputName + "_atemp" + getAudioExt());
            FileStringUtil.ensureDirectoryExists(Global.Running.tempFolder);
            // 避免编码失败最后混流使用上次的同名临时文件造成编码成功的假象
            if (File.Exists(tempVideo)) File.Delete(tempVideo);
            if (File.Exists(tempAudio)) File.Delete(tempAudio);

            #region Audio

            //检测是否含有音频
            string audio = new MediaInfoWrapper(videoInput).a_format;
            if (!string.IsNullOrEmpty(audio))
                hasAudio = true;
            int audioMode = VideoAudioModeComboBox.SelectedIndex;
            if (!hasAudio && VideoAudioModeComboBox.SelectedIndex != 1)
            {
                if (DialogResult.Yes == MessageBoxExt.ShowQuestionWithCancel(
                                        "原视频不包含音频流，音频模式是否改为无音频流？", "提示"))
                    audioMode = 1;
                else
                    return;
            }
            switch (audioMode)
            {
                case 0:
                    aextract = audiobat(videoInput, tempAudio);
                    break;

                case 1:
                    aextract = string.Empty;
                    break;

                case 2:
                    if (audio.ToLower() == "aac")
                    {
                        tempAudio = Path.Combine(Global.Running.tempFolder, inputName + "_atemp.aac");
                        aextract = ExtractAudio(videoInput, tempAudio);
                    }
                    else
                    {
                        MessageBoxExt.ShowInfoMessage("因音频编码非AAC故无法复制音频流，音频将被重编码。");
                        aextract = audiobat(videoInput, tempAudio);
                    }
                    break;

                default:
                    break;
            }

            #endregion Audio

            #region Video

            if (VideoEncoderComboBox.SelectedItem.ToString().ToLower().Contains("x264"))
            {
                if (x264mode == X264Mode.TwoPass)
                    x264 = x264bat(videoInput, tempVideo, 1, videoSubtitle) + "\r\n" +
                           x264bat(videoInput, tempVideo, 2, videoSubtitle);
                else x264 = x264bat(videoInput, tempVideo, 0, videoSubtitle);
                if (audioMode == 1)
                    x264 = x264.Replace(tempVideo, videoOutput);
            }
            else if (VideoEncoderComboBox.SelectedItem.ToString().ToLower().Contains("x265"))
            {
                tempVideo = Path.Combine(Global.Running.tempFolder, inputName + "_vtemp.hevc");
                if (targetExt != ".mp4")
                {
                    MessageBoxExt.ShowErrorMessage("不支持的格式输出,x265当前工具箱仅支持MP4输出");
                    return;
                }
                if (x264mode == X264Mode.TwoPass)
                    x264 = x265bat(videoInput, tempVideo, 1, videoSubtitle) + "\r\n" +
                           x265bat(videoInput, tempVideo, 2, videoSubtitle);
                else x264 = x265bat(videoInput, tempVideo, 0, videoSubtitle);
                if (audioMode == 1)
                {
                    x264 += "\r\n" + ToolsUtil.MP4BOX.quotedPath + " -add  \"" + tempVideo + "#trackID=1:name=\" -new " + Path.ChangeExtension(videoOutput, ".mp4").Quote() + " \r\n";
                    x264 += "del " + tempVideo.Quote();
                }
            }
            x264 += "\r\n";

            #endregion Video

            #region Mux

            //封装
            if (audioMode != 1)
            {
                string mux = string.Empty;
                if (targetExt == ".mp4")
                    mux = MP4MuxCommand(tempVideo, tempAudio, Path.ChangeExtension(videoOutput, targetExt));
                else
                    mux = FFMpegMuxCommand(tempVideo, tempAudio, Path.ChangeExtension(videoOutput, targetExt));
                x264 = aextract + x264 + mux + "\r\n"
                    + "del " + tempVideo.Quote() + "\r\n"
                    + "del " + tempAudio.Quote() + "\r\n";
            }
            x264 += "\r\necho ===== one file is completed! =====\r\n";

            #endregion Mux

            logger.Info(x264);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(GetCultureName());
            new WorkingForm(x264) { Owner = this }.Show();
            //x264 += "\r\ncmd";
            //batpath = workPath + "\\x264.bat";
            //File.WriteAllText(batpath, x264, Encoding.Default);
            //Process.Start(batpath);
        }

        private void VideoAddPresetButton_Click(object sender, EventArgs e)
        {
            try
            {
                string vPresetName = InputBox.Show("请输入这个预设名称", "请为预置配置命名", "新预置名称");
                if (!string.IsNullOrEmpty(vPresetName))
                {
                    string encType = VideoEncoderComboBox.SelectedItem.ToString().Contains("x265") ? "x265" : "x264";
                    var xl = preset.GetVideoPreset(encType);
                    XElement xelnew = new XElement("Parameter", VideoCustomParameterTextBox.Text,
                                          new XAttribute("Name", vPresetName));
                    foreach (var item in xl.Elements())
                    {
                        if (item.Attribute("Name").Value == vPresetName)
                        {
                            MessageBoxExt.ShowErrorMessage("预设名称已经存在", "预设名称重复");
                            return;
                        }
                    }
                    xl.Add(xelnew);
                    preset.Save();
                    LoadVideoPreset();
                    VideoPresetComboBox.SelectedIndex = VideoPresetComboBox.FindString(vPresetName);
                }
            }
            catch (Exception ex)
            {
                MessageBoxExt.ShowErrorMessage("添加失败! Reason: " + ex.Message);
            }
        }

        private void VideoDeletePresetButton_Click(object sender, EventArgs e)
        {
            if (MessageBoxExt.ShowQuestion("确定要删除这条预设参数？", "提示") == DialogResult.Yes)
            {
                try
                {
                    string encType = VideoEncoderComboBox.SelectedItem.ToString().Contains("x265") ? "x265" : "x264";
                    var xls = preset.GetVideoPreset(encType).Elements();
                    foreach (var item in xls)
                    {
                        if (item.Attribute("Name").Value == VideoPresetComboBox.Text)
                        {
                            item.Remove();
                            break;
                        }
                    }
                    preset.Save();
                    LoadVideoPreset();
                }
                catch (Exception ex)
                {
                    MessageBoxExt.ShowErrorMessage("删除失败! Reason: " + ex.Message);
                }
            }
        }

        #region VideoMode RadioButtonGroup

        private void VideoMode2PassRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            x264mode = X264Mode.TwoPass;

            // Bitrate
            VideoBitrateLabel.Visible =
            VideoBitrateNumericUpDown.Visible =
            VideoBitrateKbpsLabel.Visible = true;
            // Crf
            VideoCrfLabel.Visible =
            VideoCrfNumericUpDown.Visible = false;
            // Custom parameter
            VideoCustomParameterTextBox.Visible = false;
            // Resolution
            VideoHeightLabel.Visible =
            VideoHeightNumericUpDown.Visible =
            VideoWidthLabel.Visible =
            VideoWidthNumericUpDown.Visible =
            VideoMaintainResolutionCheckBox.Visible = true;
            // Preset
            VideoAddPresetButton.Visible =
            VideoDeletePresetButton.Visible =
            VideoPresetComboBox.Visible =
            VideoPresetLabel.Visible = false;
        }

        private void VideoModeCustomRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            x264mode = X264Mode.Custom;
            // Bitrate
            VideoBitrateLabel.Visible =
            VideoBitrateNumericUpDown.Visible =
            VideoBitrateKbpsLabel.Visible = false;
            // Crf
            VideoCrfLabel.Visible =
            VideoCrfNumericUpDown.Visible = false;
            // Custom parameter
            VideoCustomParameterTextBox.Visible = true;
            // Resolution
            VideoHeightLabel.Visible =
            VideoHeightNumericUpDown.Visible =
            VideoWidthLabel.Visible =
            VideoWidthNumericUpDown.Visible =
            VideoMaintainResolutionCheckBox.Visible = false;
            // Preset
            VideoAddPresetButton.Visible =
            VideoDeletePresetButton.Visible =
            VideoPresetComboBox.Visible =
            VideoPresetLabel.Visible = true;

        }

        private void VideoModeCrfRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            x264mode = X264Mode.Crf;
            // Bitrate
            VideoBitrateLabel.Visible =
            VideoBitrateNumericUpDown.Visible =
            VideoBitrateKbpsLabel.Visible = false;
            // Crf
            VideoCrfLabel.Visible =
            VideoCrfNumericUpDown.Visible = true;
            // Custom parameter
            VideoCustomParameterTextBox.Visible = false;
            // Resolution
            VideoHeightLabel.Visible =
            VideoHeightNumericUpDown.Visible =
            VideoWidthLabel.Visible =
            VideoWidthNumericUpDown.Visible =
            VideoMaintainResolutionCheckBox.Visible = true;
            // Preset
            VideoAddPresetButton.Visible =
            VideoDeletePresetButton.Visible =
            VideoPresetComboBox.Visible =
            VideoPresetLabel.Visible = false;
        }

        #endregion VideoMode RadioButtonGroup

        private void VideoInputTextBox_TextChanged(object sender, EventArgs e)
        {
            string videoInput = VideoInputTextBox.Text;
            if (File.Exists(videoInput))
            {
                int num = 1;
                string encType = "x264";
                if (VideoEncoderComboBox.SelectedItem != null)
                    encType = VideoEncoderComboBox.SelectedItem.ToString().Contains("x265") ? "x265" : "x264";
                VideoOutputTextBox.Text = Path.ChangeExtension(videoInput, string.Format("_{0}.mp4", encType));
                while (videoInput.Equals(VideoOutputTextBox.Text) || File.Exists(VideoOutputTextBox.Text))
                {
                    VideoOutputTextBox.Text = Path.ChangeExtension(videoInput, string.Format("_new_file({0})_{1}.mp4", num, encType));
                    num++;
                }

                if (Path.GetExtension(videoInput) != ".avs" && encType == "x264")
                {
                    VideoSubtitleTextBox.Text = FileStringUtil.SpeculateSubtitlePath(videoInput);
                }
            }
        }

        private void VideoOutputTextBox_TextChanged(object sender, EventArgs e)
        {
            videoOutput = VideoOutputTextBox.Text;
        }

        private void VideoSubtitleTextBox_TextChanged(object sender, EventArgs e)
        {
            videoSubtitle = VideoSubtitleTextBox.Text;
        }

        private void VideoBatchClearButton_Click(object sender, EventArgs e)
        {
            VideoBatchItemListbox.Items.Clear();
        }

        private void VideoBatchDeleteButton_Click(object sender, EventArgs e)
        {
            RemoveSelectedItemFromListBox(VideoBatchItemListbox);
        }

        private void VideoBatchAddButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
                .Prepare(DialogFilter.ALL); //"所有文件(*.*)|*.*"
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                VideoBatchItemListbox.Items.AddRange(openFileDialog.FileNames);
            }
        }

        private void VideoBatchOutputFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowerDialog = new FolderBrowserDialog();
            if (folderBrowerDialog.ShowDialog() == DialogResult.OK)
                VideoBatchOutputFolderTextBox.Text = folderBrowerDialog.SelectedPath;
        }

        private void VideoMaintainResolutionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (VideoMaintainResolutionCheckBox.Checked)
            {
                VideoWidthNumericUpDown.Value = 0;
                VideoHeightNumericUpDown.Value = 0;
                VideoWidthNumericUpDown.Enabled = false;
                VideoHeightNumericUpDown.Enabled = false;
            }
            else
            {
                VideoWidthNumericUpDown.Enabled = true;
                VideoHeightNumericUpDown.Enabled = true;
            }
        }

        private void VideoCustomParameterTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBoxSelectAll(sender, e);
        }

        private void VideoAutoShutdownCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Global.Running.shutdownState = VideoAutoShutdownCheckBox.Checked;
        }

        private void VideoGoToAudioLabel_Click(object sender, EventArgs e)
        {
            MainTabControl.SelectedIndex = 1;
        }

        private void VideoSubtitleTextBox_DoubleClick(object sender, EventArgs e)
        {
            VideoSubtitleTextBox.Clear();
        }

        private void VideoBatchItemListbox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= 65535)    // question: why 65535?
                return;

            e.DrawBackground();
            SolidBrush BlueBrush = new SolidBrush(Color.Blue);
            SolidBrush BlackBrush = new SolidBrush(Color.Black);
            Color vColor = Color.Black;
            string input = VideoBatchItemListbox.Items[e.Index].ToString();
            string language = VideoBatchSubtitleLanguage.Text == "none" ? "" : VideoBatchSubtitleLanguage.Text;
            if (!string.IsNullOrEmpty(FileStringUtil.SpeculateSubtitlePath(input, language)))
            {
                e.Graphics.DrawString(Convert.ToString(VideoBatchItemListbox.Items[e.Index]), e.Font, BlueBrush, e.Bounds);
            }
            else
            {
                e.Graphics.DrawString(Convert.ToString(VideoBatchItemListbox.Items[e.Index]), e.Font, BlackBrush, e.Bounds);
            }
        }

        private void VideoEncoderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VideoEncoderComboBox.SelectedIndex == -1)
                return;

            if (VideoEncoderComboBox.SelectedItem.ToString().ToLower().Contains("x265"))
            {
                if (VideoOutputTextBox.Text.Contains("_x264."))
                    VideoOutputTextBox.Text = VideoOutputTextBox.Text.Replace("_x264.", "_x265.");

                //x264SubTextBox.Text = string.Empty;
                //x264SubTextBox.Enabled = false;
                //x264SubBtn.Enabled = false;
                //x264BatchSubCheckBox.Enabled = false;
                //x264BatchSubSpecialLanguage.Enabled = false;
                VideoDemuxerComboBox.Enabled = false;
                VideoBatchFormatComboBox.Text = "mp4";
                VideoBatchFormatComboBox.Enabled = false;

                VideoPresetComboBox.Items.Clear();
                VideoCustomParameterTextBox.Text = string.Empty;
                var xVideos = preset.GetVideoPreset("x265");
                if (xVideos != null)
                {
                    foreach (XElement item in xVideos.Elements())
                    {
                        VideoPresetComboBox.Items.Add(item.Attribute("Name").Value);
                        VideoPresetComboBox.SelectedIndex = 0;
                    }
                }
            }
            else
            {
                if (VideoOutputTextBox.Text.Contains("_x265."))
                    VideoOutputTextBox.Text = VideoOutputTextBox.Text.Replace("_x265.", "_x264.");

                VideoSubtitleTextBox.Enabled = true;
                VideoSubtitleButton.Enabled = true;
                VideoBatchSubtitleCheckBox.Enabled = true;
                VideoBatchSubtitleLanguage.Enabled = true;
                VideoDemuxerComboBox.Enabled = true;
                VideoBatchFormatComboBox.Enabled = true;

                VideoPresetComboBox.Items.Clear();
                VideoCustomParameterTextBox.Text = string.Empty;
                var xVideos = preset.GetVideoPreset("x264");
                if (xVideos != null)
                {
                    foreach (XElement item in xVideos.Elements())
                    {
                        VideoPresetComboBox.Items.Add(item.Attribute("Name").Value);
                        VideoPresetComboBox.SelectedIndex = 0;
                    }
                }
            }
        }

        private void VideoPresetComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VideoEncoderComboBox.Items != null)
            {
                string encType = VideoEncoderComboBox.SelectedItem.ToString().Contains("x265") ? "x265" : "x264";
                XElement xel = preset.GetVideoPreset(encType).Elements()
                                  .Where(x => x.Attribute("Name").Value == VideoPresetComboBox.Text).First();
                VideoCustomParameterTextBox.Text = xel.Value;
            }
        }

        #endregion Video Tab

        #region Audio Tab

        private void AudioEncoderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (AudioEncoderComboBox.SelectedIndex)
            {
                case 0: //NeroAAC
                    if (File.Exists(AudioInputTextBox.Text))
                        AudioOutputTextBox.Text = Path.ChangeExtension(AudioInputTextBox.Text, "_AAC.mp4");
                    AudioBitrateComboBox.Enabled = true;
                    AudioAudioModeBitrateRadioButton.Enabled = true;
                    AudioAudioModeCustomRadioButton.Enabled = true;
                    if (AudioAudioModeCustomRadioButton.Checked)
                    {
                        AudioPresetDeleteButton.Visible =
                        AudioPresetAddButton.Visible = true;
                    }
                    break;

                case 1: //  QAAC
                    //if (!isAppleAppSupportInstalled())
                    //{
                    //    if (MessageBoxExtension.ShowQuestion("Apple Application Support未安装.\r\n音频编码器QAAC可能无法使用.\r\n\r\n是否前往QuickTime下载页面?", "Apple Application Support未安装") == DialogResult.Yes)
                    //        Process.Start("http://www.apple.com/cn/quicktime/download");
                    //}
                    if (File.Exists(AudioInputTextBox.Text))
                        AudioOutputTextBox.Text = Path.ChangeExtension(AudioInputTextBox.Text, "_AAC.m4a");
                    AudioBitrateComboBox.Enabled = true;
                    AudioAudioModeBitrateRadioButton.Enabled = true;
                    AudioAudioModeCustomRadioButton.Enabled = true;
                    if (AudioAudioModeCustomRadioButton.Checked)
                    {
                        AudioPresetDeleteButton.Visible =
                        AudioPresetAddButton.Visible = true;
                    }
                    break;

                case 2: //WAV
                    if (File.Exists(AudioInputTextBox.Text))
                        AudioOutputTextBox.Text = Path.ChangeExtension(AudioInputTextBox.Text, "_WAV.wav");
                    AudioBitrateComboBox.Enabled = false;
                    AudioAudioModeBitrateRadioButton.Enabled = false;
                    AudioAudioModeCustomRadioButton.Enabled = false;
                    AudioPresetDeleteButton.Visible =
                    AudioPresetAddButton.Visible = false;
                    break;

                case 3: //ALAC
                    if (File.Exists(AudioInputTextBox.Text))
                        AudioOutputTextBox.Text = Path.ChangeExtension(AudioInputTextBox.Text, "_ALAC.m4a");
                    AudioBitrateComboBox.Enabled = false;
                    AudioAudioModeBitrateRadioButton.Enabled = false;
                    AudioAudioModeCustomRadioButton.Enabled = false;
                    AudioPresetDeleteButton.Visible =
                    AudioPresetAddButton.Visible = false;
                    break;

                case 4: //FLAC
                    if (File.Exists(AudioInputTextBox.Text))
                        AudioOutputTextBox.Text = Path.ChangeExtension(AudioInputTextBox.Text, "_FLAC.flac");
                    AudioBitrateComboBox.Enabled = false;
                    AudioAudioModeBitrateRadioButton.Enabled = false;
                    AudioAudioModeCustomRadioButton.Enabled = false;
                    AudioPresetDeleteButton.Visible =
                    AudioPresetAddButton.Visible = false;
                    break;

                case 5: //FDKAAC
                    if (File.Exists(AudioInputTextBox.Text))
                        AudioOutputTextBox.Text = Path.ChangeExtension(AudioInputTextBox.Text, "_AAC.m4a");
                    AudioBitrateComboBox.Enabled = true;
                    AudioAudioModeBitrateRadioButton.Enabled = true;
                    AudioAudioModeCustomRadioButton.Enabled = true;
                    if (AudioAudioModeCustomRadioButton.Checked)
                    {
                        AudioPresetDeleteButton.Visible =
                        AudioPresetAddButton.Visible = true;
                    }
                    break;

                case 6: //AC3
                    if (File.Exists(AudioInputTextBox.Text))
                        AudioOutputTextBox.Text = Path.ChangeExtension(AudioInputTextBox.Text, "_AC3.ac3");
                    AudioBitrateComboBox.Enabled = true;
                    AudioAudioModeBitrateRadioButton.Enabled = true;
                    AudioAudioModeCustomRadioButton.Enabled = false;
                    AudioPresetDeleteButton.Visible =
                    AudioPresetAddButton.Visible = false;
                    break;

                case 7: //MP3
                    if (File.Exists(AudioInputTextBox.Text))
                        AudioOutputTextBox.Text = Path.ChangeExtension(AudioInputTextBox.Text, "_MP3.mp3");
                    AudioBitrateComboBox.Enabled = true;
                    AudioAudioModeBitrateRadioButton.Enabled = true;
                    AudioAudioModeCustomRadioButton.Enabled = true;
                    AudioPresetDeleteButton.Visible =
                    AudioPresetAddButton.Visible = false;
                    break;

                default:
                    break;
            }

            AudioPresetComboBox.Items.Clear();
            AudioCustomParameterTextBox.Text = string.Empty;
            var xAudios = preset.GetAudioPreset(AudioEncoderComboBox.Text);
            if (xAudios != null)
            {
                foreach (XElement item in xAudios.Elements())
                {
                    AudioPresetComboBox.Items.Add(item.Attribute("Name").Value);
                    AudioPresetComboBox.SelectedIndex = 0;
                }
            }
        }

        private void AudioBatchItemListBox_DragDrop(object sender, DragEventArgs e)
        {
            ListBox listbox = (ListBox)sender;
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                String[] files = (String[])e.Data.GetData(DataFormats.FileDrop);
                listbox.Items.AddRange(files);
                return;
            }
            targetIndex = listbox.IndexFromPoint(listbox.PointToClient(new Point(e.X, e.Y)));
            if (targetIndex != ListBox.NoMatches)
            {
                string temp = listbox.Items[targetIndex].ToString();
                listbox.Items[targetIndex] = listbox.Items[sourceIndex];
                listbox.Items[sourceIndex] = temp;
                listbox.SelectedIndex = targetIndex;
            }
        }

        private void AudioBatchItemListBox_DragOver(object sender, DragEventArgs e)
        {
            ListBox listbox = (ListBox)sender;
            if (e.Data.GetDataPresent(typeof(System.String)) && ((ListBox)sender).Equals(listbox))
            {
                e.Effect = DragDropEffects.Move;
            }
            else if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else e.Effect = DragDropEffects.None;
        }

        private void AudioBatchItemListBox_MouseDown(object sender, MouseEventArgs e)
        {
            sourceIndex = ((ListBox)sender).IndexFromPoint(e.X, e.Y);
            if (sourceIndex != ListBox.NoMatches)
            {
                ((ListBox)sender).DoDragDrop(((ListBox)sender).Items[sourceIndex].ToString(), DragDropEffects.All);
            }
        }

        private void AudioBatchStartButton_Click(object sender, EventArgs e)
        {
            if (AudioBatchItemListBox.Items.Count == 0)
            {
                MessageBoxExt.ShowErrorMessage("请输入文件！");
                return;
            }

            string finish, outputExt, codec;
            string aac = "";
            switch (AudioEncoderComboBox.SelectedIndex)
            {
                case 0: outputExt = "mp4"; codec = "AAC"; break;
                case 1: outputExt = "m4a"; codec = "AAC"; break;
                case 2: outputExt = "wav"; codec = "WAV"; break;
                case 3: outputExt = "m4a"; codec = "ALAC"; break;
                case 4: outputExt = "flac"; codec = "FLAC"; break;
                case 5: outputExt = "m4a"; codec = "AAC"; break;
                case 6: outputExt = "ac3"; codec = "AC3"; break;
                case 7: outputExt = "mp3"; codec = "MP3"; break;
                default: outputExt = "aac"; codec = "AAC"; break;
            }
            for (int i = 0; i < this.AudioBatchItemListBox.Items.Count; i++)
            {
                string outname = "_" + codec + "." + outputExt;
                finish = Path.ChangeExtension(AudioBatchItemListBox.Items[i].ToString(), outname);
                aac += audiobat(AudioBatchItemListBox.Items[i].ToString(), finish);
                aac += "\r\n";
            }
            aac += "\r\ncmd";
            string batpath = ToolsUtil.ToolsFolder + "\\aac.bat";
            File.WriteAllText(batpath, aac, Encoding.Default);
            logger.Info(aac);
            Process.Start(batpath);


        }

        private void AudioInputButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = DialogFilter.ALL; //"所有文件(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                audioInput = openFileDialog1.FileName;
                AudioInputTextBox.Text = audioInput;
            }
        }

        private void AudioOutputBotton_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = DialogFilter.ALL; //"所有文件(*.*)|*.*";
            //savefile.Filter = "音频(*.aac;*.wav;*.m4a;*.flac)|*.aac*.wav;*.m4a;*.flac;";
            DialogResult result = savefile.ShowDialog();
            if (result == DialogResult.OK)
            {
                audioOutput = savefile.FileName + getAudioExt();
                AudioOutputTextBox.Text = audioOutput;
            }
        }

        private void AudioStartButton_Click(object sender, EventArgs e)
        {
            if (audioInput == "")
            {
                MessageBoxExt.ShowErrorMessage("请选择音频文件");
            }
            else if (audioOutput == "")
            {
                MessageBoxExt.ShowErrorMessage("请选择输出文件");
            }
            else
            {
                string batpath = ToolsUtil.ToolsFolder + "\\aac.bat";
                File.WriteAllText(batpath, audiobat(audioInput, audioOutput), Encoding.Default);
                logger.Info(audiobat(audioInput, audioOutput));
                Process.Start(batpath);
            }
        }

        private void AudioInputTextBox_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(AudioInputTextBox.Text))
            {
                audioInput = AudioInputTextBox.Text;
                switch (AudioEncoderComboBox.SelectedIndex)
                {
                    case 0: AudioOutputTextBox.Text = Path.ChangeExtension(AudioInputTextBox.Text, "_AAC.mp4"); break;
                    case 1: AudioOutputTextBox.Text = Path.ChangeExtension(AudioInputTextBox.Text, "_AAC.m4a"); break;
                    case 2: AudioOutputTextBox.Text = Path.ChangeExtension(AudioInputTextBox.Text, "_WAV.wav"); break;
                    case 3: AudioOutputTextBox.Text = Path.ChangeExtension(AudioInputTextBox.Text, "_ALAC.m4a"); break;
                    case 4: AudioOutputTextBox.Text = Path.ChangeExtension(AudioInputTextBox.Text, "_FLAC.flac"); break;
                    case 5: AudioOutputTextBox.Text = Path.ChangeExtension(AudioInputTextBox.Text, "_AAC.m4a"); break;
                    case 6: AudioOutputTextBox.Text = Path.ChangeExtension(AudioInputTextBox.Text, "_AC3.ac3"); break;
                    case 7: AudioOutputTextBox.Text = Path.ChangeExtension(AudioInputTextBox.Text, "_MP3.mp3"); break;
                    default: AudioOutputTextBox.Text = Path.ChangeExtension(AudioInputTextBox.Text, "_AAC.aac"); break;
                }
            }
        }

        private void AudioOutputTextBox_TextChanged(object sender, EventArgs e)
        {
            audioOutput = AudioOutputTextBox.Text;
        }

        private void AudioInputTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (File.Exists(AudioInputTextBox.Text))
            {
                Process.Start(AudioInputTextBox.Text);
            }
        }

        private void AudioAudioModeCustomRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            AudioBitrateLabel.Visible =
            AudioKbpsLabel.Visible =
            AudioBitrateComboBox.Visible = false;

            AudioCustomParameterTextBox.Visible =
            AudioPresetLabel.Visible =
            AudioPresetComboBox.Visible =
            AudioPresetDeleteButton.Visible =
            AudioPresetAddButton.Visible = true;
        }

        private void AudioAudioModeBitrateRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            AudioBitrateLabel.Visible =
            AudioKbpsLabel.Visible =
            AudioBitrateComboBox.Visible = true;

            AudioCustomParameterTextBox.Visible =
            AudioPresetLabel.Visible =
            AudioPresetComboBox.Visible =
            AudioPresetDeleteButton.Visible =
            AudioPresetAddButton.Visible = false;
        }

        private void AudioBatchAddButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
                .Prepare(DialogFilter.ALL); //"所有文件(*.*)|*.*"
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                AudioBatchItemListBox.Items.AddRange(openFileDialog.FileNames);
            }
        }

        private void AudioBatchDeleteButton_Click(object sender, EventArgs e)
        {
            RemoveSelectedItemFromListBox(AudioBatchItemListBox);
        }

        private void AudioBatchClearButton_Click(object sender, EventArgs e)
        {
            AudioBatchItemListBox.Items.Clear();
        }

        private void AudioPresetComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            XElement x = preset.GetAudioPreset(AudioEncoderComboBox.Text).Elements()
                             .Where(_ => _.Attribute("Name").Value == AudioPresetComboBox.Text).First();
            AudioCustomParameterTextBox.Text = x.Value;
        }

        private void AudioPresetDeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBoxExt.ShowQuestion("确定要删除这条预设参数？", "提示") == DialogResult.Yes)
            {
                try
                {
                    var xls = preset.GetAudioPreset(AudioEncoderComboBox.Text).Elements();
                    foreach (var item in xls)
                    {
                        if (item.Attribute("Name").Value == AudioPresetComboBox.Text)
                        {
                            item.Remove();
                            break;
                        }
                    }
                    preset.Save();
                    LoadAudioPreset();
                }
                catch (Exception ex)
                {
                    MessageBoxExt.ShowErrorMessage("删除失败! Reason: " + ex.Message);
                }
            }
        }

        private void AudioPresetAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                string aPresetName = InputBox.Show("请输入这个预设名称", "请为预置配置命名", "新预置名称");
                if (!string.IsNullOrEmpty(aPresetName))
                {
                    var xl = preset.GetAudioPreset(AudioEncoderComboBox.Text);
                    XElement xelnew = new XElement("Parameter", AudioCustomParameterTextBox.Text,
                                          new XAttribute("Name", aPresetName));
                    foreach (var item in xl.Elements())
                    {
                        if (item.Attribute("Name").Value == aPresetName)
                        {
                            MessageBoxExt.ShowErrorMessage("预设名称已经存在", "预设名称重复");
                            return;
                        }
                    }
                    xl.Add(xelnew);
                    preset.Save();
                    LoadAudioPreset();
                    AudioPresetComboBox.SelectedIndex = AudioPresetComboBox.FindString(aPresetName);
                }
            }
            catch (Exception ex)
            {
                MessageBoxExt.ShowErrorMessage("添加失败! Reason: " + ex.Message);
            }
        }

        private void AudioBatchConcatButton_Click(object sender, EventArgs e)
        {
            if (AudioBatchItemListBox.Items.Count == 0)
            {
                MessageBoxExt.ShowErrorMessage("请输入文件！");
                return;
            }
            else if (AudioOutputTextBox.Text == "")
            {
                MessageBoxExt.ShowErrorMessage("请选择输出文件");
                return;
            }
            StringBuilder sb = new StringBuilder();
            string ffmpeg = "";
            string ext = Path.GetExtension(AudioBatchItemListBox.Items[0].ToString());
            string finish = Path.ChangeExtension(AudioOutputTextBox.Text, ext);
            for (int i = 0; i < this.AudioBatchItemListBox.Items.Count; i++)
            {
                if (Path.GetExtension(AudioBatchItemListBox.Items[i].ToString()) != ext)
                {
                    MessageBoxExt.ShowErrorMessage("只允许合并相同格式文件。");
                    return;
                }
                sb.AppendLine("file '" + AudioBatchItemListBox.Items[i].ToString() + "'");
                File.WriteAllText("concat.txt", sb.ToString());
                ffmpeg = ToolsUtil.FFMPEG.quotedPath + " -f concat  -i concat.txt -y -c copy " + finish;
            }
            ffmpeg += "\r\ncmd";
            string batpath = ToolsUtil.ToolsFolder + "\\concat.bat";
            File.WriteAllText(batpath, ffmpeg, Encoding.Default);
            logger.Info(ffmpeg);
            Process.Start(batpath);
        }

        private void AudioOutputTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (File.Exists(AudioOutputTextBox.Text))
            {
                Process.Start(AudioOutputTextBox.Text);
            }
        }

        #endregion Audio Tab

        #region Avs Tab

        private void AvsPreviewButton_Click(object sender, EventArgs e)
        {
            if (AvsScriptTextBox.Text != "")
            {
                string filepath = ToolsUtil.ToolsFolder + "\\temp.avs";
                File.WriteAllText(filepath, AvsScriptTextBox.Text, Encoding.Default);
                if (File.Exists(ConfigFunctionVideoPlayerTextBox.Text))
                {
                    Process.Start(ConfigFunctionVideoPlayerTextBox.Text, filepath);
                }
                else
                {
                    string ffplayer = ToolsUtil.FFPLAY.fullPath;
                    if (File.Exists(ffplayer))
                        Process.Start(FileStringUtil.FormatPath(ffplayer), " -i " + FileStringUtil.FormatPath(filepath));
                    else
                    {
                        new PreviewForm(filepath).Show();
                    }
                }
            }
            else
            {
                MessageBoxExt.ShowErrorMessage("请输入正确的AVS脚本！");
            }
        }

        private void AvsOutputTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (File.Exists(AvsOutputTextBox.Text))
            {
                Process.Start(AvsOutputTextBox.Text);
            }
        }

        private void AvsVideoInputTextBox_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(AvsVideoInputTextBox.Text))
            {
                string avsVideoInput = AvsVideoInputTextBox.Text;
                AvsOutputTextBox.Text = Path.ChangeExtension(AvsVideoInputTextBox.Text, "_AVS压制.mp4");
                GenerateAVS();
            }
        }

        private void AvsStartButton_Click(object sender, EventArgs e)
        {
            VideoDemuxerComboBox.SelectedIndex = 0; //压制AVS始终使用分离器为auto
            string avsOutput = AvsOutputTextBox.Text;
            if (string.IsNullOrEmpty(avsOutput))
            {
                MessageBoxExt.ShowErrorMessage("请选择输出文件");
                return;
            }

            if (Path.GetExtension(avsOutput).ToLower() != ".mp4")
            {
                MessageBoxExt.ShowErrorMessage("仅支持MP4输出", "不支持的输出格式");
                return;
            }

            if (File.Exists(AvsOutputTextBox.Text.Trim()))
            {
                DialogResult dgs = MessageBoxExt.ShowQuestion("目标文件:\r\n\r\n" + AvsOutputTextBox.Text.Trim() + "\r\n\r\n已经存在,是否覆盖继续压制？", "目标文件已经存在");
                if (dgs == DialogResult.No) return;
            }

            if (string.IsNullOrEmpty(FileStringUtil.CheckAviSynth()) && string.IsNullOrEmpty(FileStringUtil.CheckInternalAviSynth()))
            {
                if (MessageBoxExt.ShowQuestion("检测到本机未安装avisynth无法继续压制，是否去下载安装", "avisynth未安装") == DialogResult.Yes)
                    Process.Start("http://sourceforge.net/projects/avisynth2/");
                return;
            }
            string avsVideoInput = AvsVideoInputTextBox.Text;
            string inputName = Path.GetFileNameWithoutExtension(avsVideoInput);
            string tempVideo = Path.Combine(Global.Running.tempFolder, inputName + "_vtemp.mp4");
            string tempAudio = Path.Combine(Global.Running.tempFolder, inputName + "_atemp" + getAudioExt());
            FileStringUtil.ensureDirectoryExists(Global.Running.tempFolder);
            // 避免编码失败最后混流使用上次的同名临时文件造成编码成功的假象
            if (File.Exists(tempVideo)) File.Delete(tempVideo);
            if (File.Exists(tempAudio)) File.Delete(tempAudio);

            string filepath = Global.Running.tempAvsFile;
            //string filepath = workpath + "\\temp.avs";
            File.WriteAllText(filepath, AvsScriptTextBox.Text, Encoding.Default);

            //检测是否含有音频
            bool hasAudio = false;
            string audio = new MediaInfoWrapper(avsVideoInput).a_format;
            if (!string.IsNullOrEmpty(audio)) { hasAudio = true; }

            //audio
            if (AvsIncludeAudioCheckBox.Checked && hasAudio)
            {
                if (!File.Exists(AvsVideoInputTextBox.Text))
                {
                    MessageBoxExt.ShowErrorMessage("请选择视频文件");
                    return;
                }
                aextract = audiobat(avsVideoInput, tempAudio);
            }
            else
                aextract = string.Empty;

            //video
            if (VideoEncoderComboBox.SelectedItem.ToString().ToLower().Contains("x264"))
            {
                if (x264mode == X264Mode.TwoPass)
                    x264 = x264bat(filepath, tempVideo, 1) + "\r\n" +
                           x264bat(filepath, tempVideo, 2);
                else x264 = x264bat(filepath, tempVideo);
                if (!AvsIncludeAudioCheckBox.Checked || !hasAudio)
                    x264 = x264.Replace(tempVideo, avsOutput);
            }
            else if (VideoEncoderComboBox.SelectedItem.ToString().ToLower().Contains("x265"))
            {
                tempVideo = Path.Combine(Global.Running.tempFolder, inputName + "_vtemp.hevc");
                if (x264mode == X264Mode.TwoPass)
                    x264 = x265bat(filepath, tempVideo, 1) + "\r\n" +
                           x265bat(filepath, tempVideo, 2);
                else x264 = x265bat(filepath, tempVideo);
                if (!AvsIncludeAudioCheckBox.Checked || !hasAudio)
                {
                    x264 += "\r\n" + ToolsUtil.MP4BOX.quotedPath + " -add  \"" + tempVideo + "#trackID=1:name=\" -new " + avsOutput.Quote() + " \r\n";
                    x264 += "del " + tempVideo.Quote();
                }
            }
            //mux
            string mux = string.Empty;
            if (AvsIncludeAudioCheckBox.Checked && hasAudio) //如果包含音频
                mux = MP4MuxCommand(tempVideo, tempAudio, avsOutput);

            string auto = aextract + x264 + "\r\n" + mux + " \r\n";
            auto += "\r\necho ===== one file is completed! =====\r\n";
            logger.Info(auto);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(GetCultureName());
            new WorkingForm(auto) { Owner = this }.Show();
            //auto += "\r\ncmd";
            //batpath = workPath + "\\x264avs.bat";
            //File.WriteAllText(batpath, auto, Encoding.Default);
            //Process.Start(batpath);
        }

        private void AvsOutputButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = DialogFilter.VIDEO_3; //"视频(*.mp4)|*.mp4";
            DialogResult result = savefile.ShowDialog();
            if (result == DialogResult.OK)
            {
                AvsOutputTextBox.Text = savefile.FileName;
            }
        }

        [Obsolete("This button is always hidden and unaccessable")]
        private void AvsGenerateButton_Click(object sender, EventArgs e)
        {
            //if (Directory.Exists("avsfilter"))
            //{
            //    DirectoryInfo TheFolder = new DirectoryInfo("avsfilter");
            //    foreach (FileInfo FileName in TheFolder.GetFiles())
            //    {
            //        avs += "LoadPlugin(\"" + workpath + "\\avsfilter\\" + FileName + "\")\r\n";
            //    }
            //}
            string avsSubtitleInput = AvsSubtitleInputTextBox.Text;
            string avsVideoInput = AvsVideoInputTextBox.Text;
            string avsScript = "LoadPlugin(\"avs\\plugins\\VSFilter.DLL\")\r\n";
            avsScript += string.Format("\r\nLWLibavVideoSource(\"{0}\",23.976,convertFPS=True)\r\nConvertToYV12()\r\nCrop(0,0,0,0)\r\nAddBorders(0,0,0,0)\r\n" + "TextSub(\"{1}\")\r\n#LanczosResize(1280,960)\r\n", avsVideoInput, avsSubtitleInput);
            //avs += "\r\nDirectShowSource(\"" + namevideo9 + "\",23.976,convertFPS=True)\r\nConvertToYV12()\r\nCrop(0,0,0,0)\r\nAddBorders(0,0,0,0)\r\n" + "TextSub(\"" + namesub9 + "\")\r\n#LanczosResize(1280,960)\r\n";
            AvsScriptTextBox.Text = avsScript;
        }

        private void AvsVideoInputTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (File.Exists(AvsVideoInputTextBox.Text))
            {
                Process.Start(AvsVideoInputTextBox.Text);
            }
        }

        private void AvsSubtitleInputButton_Click(object sender, EventArgs e)
        {
            new OpenFileDialog()//"字幕(*.ass;*.ssa;*.srt;*.idx;*.sup)|*.ass;*.ssa;*.srt;*.idx;*.sup|所有文件(*.*)|*.*";
                .Prepare(DialogFilter.SUBTITLE_2, AvsSubtitleInputTextBox.Text)
                .ShowDialogExt(AvsSubtitleInputTextBox);
        }

        private void AvsVideoInputButton_Click(object sender, EventArgs e)
        {
            new OpenFileDialog() //"视频(*.mp4;*.flv;*.mkv;*.wmv)|*.mp4;*.flv;*.mkv;*.wmv|所有文件(*.*)|*.*"
                .Prepare(DialogFilter.VIDEO_7, AvsVideoInputTextBox.Text)
                .ShowDialogExt(AvsVideoInputTextBox);
        }

        private void AvsClearButton_Click(object sender, EventArgs e)
        {
            AvsScriptTextBox.Clear();
        }

        private void AvsScriptTextBox_TextChanged(object sender, EventArgs e)
        {
            Match m = Regex.Match(AvsScriptTextBox.Text, "ource\\(\"[a-zA-Z]:\\\\.+\\.\\w+\"");
            if (m.Success)
            {
                string str = m.ToString();
                str = str.Replace("ource(\"", "");
                str = str.Replace("\"", "");
                str = Path.ChangeExtension(str, "_AVS.mp4");
                AvsOutputTextBox.Text = str;
            }
        }

        private void AvsSaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = DialogFilter.AVS; //"AVS(*.avs)|*.avs";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, AvsScriptTextBox.Text, Encoding.Default);
            }
        }

        private void AvsAddFilterButton_Click(object sender, EventArgs e)
        {
            string vsfilterDLLPath = Path.Combine(ToolsUtil.ToolsFolder, @"avs\plugins\" + AvsFilterComboBox.Text);
            string text = "LoadPlugin(\"" + vsfilterDLLPath + "\")" + "\r\n";
            AvsScriptTextBox.Text = text + AvsScriptTextBox.Text;
        }

        private void AvsScriptTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBoxSelectAll(sender, e);
        }

        private void GenerateAVS()
        {
            string avsSubtitleInput = AvsSubtitleInputTextBox.Text;
            string avsVideoInput = AvsVideoInputTextBox.Text;
            StringBuilder avsBuilder = new StringBuilder(1000);

            string vsfilterDLLPath = Path.Combine(ToolsUtil.ToolsFolder, @"avs\plugins\VSFilter.DLL");
            string SupTitleDLLPath = Path.Combine(ToolsUtil.ToolsFolder, @"avs\plugins\SupTitle.dll");
            string LSMASHSourceDLLPath = Path.Combine(ToolsUtil.ToolsFolder, @"avs\plugins\LSMASHSource.DLL");
            string undotDLLPath = Path.Combine(ToolsUtil.ToolsFolder, @"avs\plugins\UnDot.DLL");

            avsBuilder.AppendLine($"LoadPlugin(\"{LSMASHSourceDLLPath}\")");
            if (Path.GetExtension(avsSubtitleInput).ToLower() == ".sup")
                avsBuilder.AppendLine($"LoadPlugin(\"{SupTitleDLLPath}\")");
            else
                avsBuilder.AppendLine($"LoadPlugin(\"{vsfilterDLLPath}\")");
            if (AvsUndotCheckBox.Checked)
                avsBuilder.AppendLine($"LoadPlugin(\"{undotDLLPath}\")");

            string extInput = Path.GetExtension(avsVideoInput).ToLower();
            if (extInput == ".mp4"
                   || extInput == ".mov"
                   || extInput == ".qt"
                   || extInput == ".3gp"
                   || extInput == ".3g2")
                avsBuilder.AppendLine($"LSMASHVideoSource(\"{avsVideoInput}\",format=\"YUV420P8\")");
            else
                avsBuilder.AppendLine($"LWLibavVideoSource(\"{avsVideoInput}\",format=\"YUV420P8\")");
            avsBuilder.AppendLine("ConvertToYV12()");

            if (AvsUndotCheckBox.Checked)
                avsBuilder.AppendLine("Undot()");
            if (AvsTweakCheckBox.Checked)
                avsBuilder.AppendLine($"Tweak({AvsTweakChromaNumericUpDown.Value}, {AvsTweakSaturationNumericUpDown.Value}, {AvsTweakBrightnessNumericUpDown.Value}, {AvsTweakContrastNumericUpDown.Value})");
            if (AvsLevelsCheckBox.Checked)
                avsBuilder.AppendLine($"Levels(0,{AvsLevelsNumericUpDown.Value},255,0,255)");
            if (AvsLanczosResizeCheckBox.Checked)
                avsBuilder.AppendLine($"LanczosResize({AvsLanczosResizeWidthNumericUpDown.Value},{AvsLanczosResizeHeightNumericUpDown.Value})");
            if (AvsSharpenCheckBox.Checked)
                avsBuilder.AppendLine($"Sharpen({AvsSharpenNumericUpDown.Value})");
            if (AvsCropCheckBox.Checked)
                avsBuilder.AppendLine($"Crop({AvsCropTextBox.Text})");
            if (AvsAddBordersCheckBox.Checked)
                avsBuilder.AppendLine($"AddBorders({AvsAddBordersLeftNumericUpDown.Value},{AvsAddBordersTopNumericUpDown.Value},{AvsAddBordersRightNumericUpDown.Value},{AvsAddBordersBottomNumericUpDown.Value})");
            if (!string.IsNullOrEmpty(AvsSubtitleInputTextBox.Text))
            {
                if (Path.GetExtension(avsSubtitleInput).ToLower() == ".idx")
                    avsBuilder.AppendLine($"vobsub(\"{avsSubtitleInput}\")");
                else if (Path.GetExtension(avsSubtitleInput).ToLower() == ".sup")
                    avsBuilder.AppendLine($"SupTitle(\"{avsSubtitleInput}\")");
                else
                    avsBuilder.AppendLine($"TextSub(\"{avsSubtitleInput}\")");
            }
            if (AvsTrimCheckBox.Checked)
                avsBuilder.AppendLine($"Trim({AvsTrimStartNumericUpDown.Value},{AvsTrimEndNumericUpDown.Value})");

            AvsScriptTextBox.Text = avsBuilder.ToString();
        }

        // Triggered when AVS related controls changed, such as AvsCheckBox.CheckedChanged, AvsTrimCheckBox.CheckedChanged
        private void GenerateAVSHandler(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        #endregion Avs Tab

        #region globalization

        public static void SetLang(string lang, Form form, Type formType)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
            if (form != null)
            {
                ComponentResourceManager resources = new ComponentResourceManager(formType);
                resources.ApplyResources(form, "$this");
                AppLang(form, resources);
            }
        }

        private static void AppLang(Control control, ComponentResourceManager resources)
        {
            foreach (Control c in control.Controls)
            {
                resources.ApplyResources(c, c.Name);
                AppLang(c, resources);
            }
        }

        private void ConfigUiLanguageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //StreamReader sr;
            VideoModeCrfRadioButton.Checked = true;
            AudioAudioModeBitrateRadioButton.Checked = true;
            int x264AudioModeComboBoxIndex = 0;
            switch (ConfigUiLanguageComboBox.SelectedIndex)
            {
                case 0:
                    SetLang("zh-CN", this, typeof(MainForm));
                    //this.Text = string.Format("小丸工具箱 {0}", Assembly.GetExecutingAssembly().GetName().Version.Build);
                    this.Text = string.Format("小丸工具箱 {0}", Utility.AssemblyUtil.GetAssemblyFileVersion());
                    ConfigX264PriorityComboBox.Items.Clear();
                    ConfigX264PriorityComboBox.Items.AddRange(new string[] { "低", "低于标准", "普通", "高于标准", "高", "实时" });
                    ConfigX264PriorityComboBox.SelectedIndex = 2;
                    x264AudioModeComboBoxIndex = VideoAudioModeComboBox.SelectedIndex;
                    VideoAudioModeComboBox.Items.Clear();
                    VideoAudioModeComboBox.Items.Add("压制音频");
                    VideoAudioModeComboBox.Items.Add("无音频流");
                    VideoAudioModeComboBox.Items.Add("复制音频流");
                    VideoAudioModeComboBox.SelectedIndex = x264AudioModeComboBoxIndex;
                    VideoInputTextBox.EmptyTextTip = "可以把文件拖拽到这里";
                    VideoSubtitleTextBox.EmptyTextTip = "双击清空字幕文件文本框";
                    //x264OutTextBox.EmptyTextTip = "宽度和高度全为0即不改变分辨率";
                    VideoBatchOutputFolderTextBox.EmptyTextTip = "字幕文件和视频文件在同一目录下且同名，不同名仅有语言后缀时请在右方选择或输入";
                    //txtvideo3.EmptyTextTip = "音频参数在音频选项卡设定";
                    ExtractMp4InputTextBox.EmptyTextTip = "抽取的视频或音频在原视频目录下";
                    ExtractFlvInputTextBox.EmptyTextTip = "抽取的视频或音频在原视频目录下";
                    ExtractMkvInputTextBox.EmptyTextTip = "抽取的视频或音频在原视频目录下";
                    //load Help Text
                    if (File.Exists(Global.Running.startPath + "\\help.rtf"))
                    {
                        HelpContentRichTextBox.LoadFile(Global.Running.startPath + "\\help.rtf");
                    }
                    break;

                case 1:
                    SetLang("zh-TW", this, typeof(MainForm));
                    this.Text = string.Format("小丸工具箱 {0}", Utility.AssemblyUtil.GetAssemblyFileVersion());
                    ConfigX264PriorityComboBox.Items.Clear();
                    ConfigX264PriorityComboBox.Items.AddRange(new string[] { "低", "在標準以下", "標準", "在標準以上", "高", "即時" });
                    ConfigX264PriorityComboBox.SelectedIndex = 2;
                    x264AudioModeComboBoxIndex = VideoAudioModeComboBox.SelectedIndex;
                    VideoAudioModeComboBox.Items.Clear();
                    VideoAudioModeComboBox.Items.Add("壓制音頻");
                    VideoAudioModeComboBox.Items.Add("無音頻流");
                    VideoAudioModeComboBox.Items.Add("拷貝音頻流");
                    VideoAudioModeComboBox.SelectedIndex = x264AudioModeComboBoxIndex;
                    VideoInputTextBox.EmptyTextTip = "可以把档案拖拽到這裡";
                    VideoSubtitleTextBox.EmptyTextTip = "雙擊清空字幕檔案文本框";
                    //x264OutTextBox.EmptyTextTip = "寬度和高度全為0即不改變解析度";
                    VideoBatchOutputFolderTextBox.EmptyTextTip = "字幕和視頻在同一資料夾下且同名，不同名僅有語言後綴時請在右方選擇或輸入";
                    //txtvideo3.EmptyTextTip = "音頻參數需在音頻選項卡设定";
                    ExtractMp4InputTextBox.EmptyTextTip = "新檔案生成在原資料夾";
                    ExtractFlvInputTextBox.EmptyTextTip = "新檔案生成在原資料夾";
                    ExtractMkvInputTextBox.EmptyTextTip = "新檔案生成在原資料夾";
                    //load Help Text
                    if (File.Exists(Global.Running.startPath + "\\help_zh_tw.rtf"))
                    {
                        HelpContentRichTextBox.LoadFile(Global.Running.startPath + "\\help_zh_tw.rtf");
                    }
                    break;

                case 2:
                    SetLang("en-US", this, typeof(MainForm));
                    this.Text = string.Format("Maruko Toolbox {0}", Utility.AssemblyUtil.GetAssemblyFileVersion());
                    ConfigX264PriorityComboBox.Items.Clear();
                    ConfigX264PriorityComboBox.Items.AddRange(new string[] { "Idle", "BelowNormal", "Normal", "AboveNormal", "High", "RealTime" });
                    ConfigX264PriorityComboBox.SelectedIndex = 2;
                    x264AudioModeComboBoxIndex = VideoAudioModeComboBox.SelectedIndex;
                    VideoAudioModeComboBox.Items.Clear();
                    VideoAudioModeComboBox.Items.Add("with audio");
                    VideoAudioModeComboBox.Items.Add("no audio");
                    VideoAudioModeComboBox.Items.Add("copy audio");
                    VideoAudioModeComboBox.SelectedIndex = x264AudioModeComboBoxIndex;
                    VideoInputTextBox.EmptyTextTip = "Drag file here";
                    VideoSubtitleTextBox.EmptyTextTip = "Clear subtitle text box by double click";
                    //x264OutTextBox.EmptyTextTip = "Both the width and height equal zero means using original resolution";
                    VideoBatchOutputFolderTextBox.EmptyTextTip = "Subtitle and Video must be of the same name and in the same folder";
                    //txtvideo3.EmptyTextTip = "It is necessary to set audio parameter in the Audio tab";
                    ExtractMp4InputTextBox.EmptyTextTip = "New file will be created in the original folder";
                    ExtractFlvInputTextBox.EmptyTextTip = "New file will be created in the original folder";
                    ExtractMkvInputTextBox.EmptyTextTip = "New file will be created in the original folder";
                    //load Help Text
                    if (File.Exists(Global.Running.startPath + "\\help.rtf"))
                    {
                        HelpContentRichTextBox.LoadFile(Global.Running.startPath + "\\help.rtf");
                    }
                    break;

                case 3:
                    SetLang("ja-JP", this, typeof(MainForm));
                    this.Text = string.Format("小丸道具箱 {0}", Utility.AssemblyUtil.GetAssemblyFileVersion());
                    ConfigX264PriorityComboBox.Items.Clear();
                    ConfigX264PriorityComboBox.Items.AddRange(new string[] { "低", "通常以下", "通常", "通常以上", "高", "リアルタイム" });
                    ConfigX264PriorityComboBox.SelectedIndex = 2;
                    x264AudioModeComboBoxIndex = VideoAudioModeComboBox.SelectedIndex;
                    VideoAudioModeComboBox.Items.Clear();
                    VideoAudioModeComboBox.Items.Add("オーディオ付き");
                    VideoAudioModeComboBox.Items.Add("オーディオなし");
                    VideoAudioModeComboBox.Items.Add("オーディオ コピー");
                    VideoAudioModeComboBox.SelectedIndex = x264AudioModeComboBoxIndex;
                    VideoInputTextBox.EmptyTextTip = "ビデオファイルをここに引きずってください";
                    VideoSubtitleTextBox.EmptyTextTip = "ダブルクリックで字幕を削除する";
                    //x264OutTextBox.EmptyTextTip = "Both the width and height equal zero means using original resolution";
                    VideoBatchOutputFolderTextBox.EmptyTextTip = "字幕とビデオは同じ名前と同じフォルダにある必要があります";
                    //txtvideo3.EmptyTextTip = "It is necessary to set audio parameter in the Audio tab";
                    ExtractMp4InputTextBox.EmptyTextTip = "新しいファイルはビデオファイルのあるディレクトリに生成する";
                    ExtractFlvInputTextBox.EmptyTextTip = "新しいファイルはビデオファイルのあるディレクトリに生成する";
                    ExtractMkvInputTextBox.EmptyTextTip = "新しいファイルはビデオファイルのあるディレクトリに生成する";
                    if (File.Exists(Global.Running.startPath + "\\help.rtf"))
                    {
                        HelpContentRichTextBox.LoadFile(Global.Running.startPath + "\\help.rtf");
                    }
                    break;

                default:
                    break;
            }
        }

        private string GetCultureName()
        {
            string name = "zh-CN";
            switch (ConfigUiLanguageComboBox.SelectedIndex)
            {
                case 0:
                    name = "zh-CN";
                    break;

                case 1:
                    name = "zh-TW";
                    break;

                case 2:
                    name = "en-US";
                    break;

                case 3:
                    name = "ja-JP";
                    break;

                default:
                    break;
            }
            return name;
        }

        #endregion globalization

        #region Misc Tab

        private void GetMiscDataFromUI(MiscProcedure p)
        {
            p.inputVideoFilePath = MiscMiscVideoInputTextBox.Text;
            p.outputVideoFilePath = MiscMiscVideoOutputTextBox.Text;
            p.beginTimeStr = MiscMiscBeginTimeMaskedTextBox.Text;
            p.endTimeStr = MiscMiscEndTimeMaskedTextBox.Text;
            p.transposeIndex = MiscMiscTransposeComboBox.SelectedIndex;
        }

        #region MiscOnePic

        private void MiscOnePicInputButton_Click(object sender, EventArgs e)
        {
            new OpenFileDialog() //"图片(*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif|所有文件(*.*)|*.*"
                .Prepare(DialogFilter.IMAGE, MiscOnePicInputTextBox.Text)
                .ShowDialogExt(MiscOnePicInputTextBox);
        }

        private void MiscOnePicAudioInputButton_Click(object sender, EventArgs e)
        {
            new OpenFileDialog() //"音频(*.aac;*.mp3;*.mp4;*.wav)|*.aac;*.mp3;*.mp4;*.wav|所有文件(*.*)|*.*";
                .Prepare(DialogFilter.AUDIO_2, MiscOnePicAudioInputTextBox.Text)
                .ShowDialogExt(MiscOnePicAudioInputTextBox);
        }

        private void MiscOnePicOutputButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = DialogFilter.VIDEO_D_2; //"MP4视频(*.mp4)|*.mp4|FLV视频(*.flv)|*.flv";
            saveFileDialog.FileName = "Single";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                MiscOnePicOutputTextBox.Text = saveFileDialog.FileName;
            }
        }

        private void MiscOnePicAudioInputTextBox_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(MiscOnePicAudioInputTextBox.Text))
            {
                MiscOnePicOutputTextBox.Text = Path.ChangeExtension(MiscOnePicAudioInputTextBox.Text, "_SP.flv");
            }
        }

        private void MiscOnePicCopyAudioCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MiscOnePicBitrateNumericUpDown.Enabled = !MiscOnePicCopyAudioCheckBox.Checked;
        }

        private void GetOnePicDataFromUI(OnePicProcedure p)
        {
            p.imageFilePath = MiscOnePicInputTextBox.Text;
            p.audioFilePath = MiscOnePicAudioInputTextBox.Text;
            p.outputFilePath = MiscOnePicOutputTextBox.Text;
            p.audioBitrate = (int)MiscOnePicBitrateNumericUpDown.Value;
            p.fps = (int)MiscOnePicFpsNumericUpDown.Value;
            p.crf = (float)MiscOnePicCrfNumericUpDown.Value;
            int duration = 0;
            int.TryParse(MiscOnePicDurationSecondsTextBox.Text, out duration);
            p.duration = duration;
            p.copyAudio = MiscOnePicCopyAudioCheckBox.Checked;
        }

        private void MiscOnePicStartButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(MiscOnePicInputTextBox.Text))
            {
                MessageBoxExt.ShowErrorMessage("请选择图片文件");
            }
            else if (!File.Exists(MiscOnePicAudioInputTextBox.Text))
            {
                MessageBoxExt.ShowErrorMessage("请选择音频文件");
            }
            else if (MiscOnePicOutputTextBox.Text == "")
            {
                MessageBoxExt.ShowErrorMessage("请选择输出文件");
            }
            else
            {
                OnePicProcedure procedure = new OnePicProcedure();
                procedure.GetDataFromUI(GetOnePicDataFromUI);
                procedure.Execute();
            }
        }

        #endregion MiscOnePic

        #region MiscMisc

        private void MiscMiscVideoInputTextBox_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(MiscMiscVideoInputTextBox.Text))
            {
                string inputFileName = MiscMiscVideoInputTextBox.Text;
                //string finish = namevideo4.Insert(namevideo4.LastIndexOf(".")-1,"");
                //string ext = namevideo4.Substring(namevideo4.LastIndexOf(".") + 1, 3);
                //finish += "_clip." + ext;
                string outputFileName = inputFileName.Insert(inputFileName.LastIndexOf("."), "_output");
                MiscMiscVideoOutputTextBox.Text = outputFileName;
            }
        }

        private void MiscMiscVideoInputButton_Click(object sender, EventArgs e)
        {
            new OpenFileDialog() //"视频(*.mp4;*.flv;*.mkv)|*.mp4;*.flv;*.mkv|所有文件(*.*)|*.*";
                .Prepare(DialogFilter.VIDEO_6, MiscMiscVideoInputTextBox.Text)
                .ShowDialogExt(MiscMiscVideoInputTextBox);
        }

        private void MiscMiscVideoOutputButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = DialogFilter.VIDEO_1; //"视频(*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                MiscMiscVideoOutputTextBox.Text = saveFileDialog.FileName;
            }
        }

        private void MiscMiscStartClipButton_Click(object sender, EventArgs e)
        {
            if (MiscMiscVideoInputTextBox.Text == "")
            {
                MessageBoxExt.ShowErrorMessage("请选择视频文件");
            }
            else if (MiscMiscVideoOutputTextBox.Text == "")
            {
                MessageBoxExt.ShowErrorMessage("请选择输出文件");
            }
            else
            {
                MiscProcedure miscProcedure = new MiscProcedure();
                miscProcedure.GetDataFromUI(GetMiscDataFromUI);
                miscProcedure.Execute();
            }
        }

        private void MiscMiscStartRotateButton_Click(object sender, EventArgs e)
        {
            if (MiscMiscVideoInputTextBox.Text == "")
            {
                MessageBoxExt.ShowErrorMessage("请选择视频文件");
            }
            else if (MiscMiscVideoOutputTextBox.Text == "")
            {
                MessageBoxExt.ShowErrorMessage("请选择输出文件");
            }
            else
            {
                MiscProcedure miscProcedure = new MiscProcedure();
                miscProcedure.GetDataFromUI(GetMiscDataFromUI);
                miscProcedure.ExecuteRotate();
            }
        }

        private void MiscMiscVideoInputTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (File.Exists(MiscMiscVideoInputTextBox.Text))
            {
                Process.Start(MiscMiscVideoInputTextBox.Text);
            }
        }

        private void MiscMiscVideoOutputTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (File.Exists(MiscMiscVideoOutputTextBox.Text))
            {
                Process.Start(MiscMiscVideoOutputTextBox.Text);
            }
        }

        #endregion MiscMisc

        #region MiscBlack

        private void MiscBlackVideoInputButton_Click(object sender, EventArgs e)
        {
            new OpenFileDialog() //"FLV视频(*.flv)|*.flv"
                .Prepare(DialogFilter.VIDEO_D_1, MiscBlackVideoInputTextBox.Text)
                .ShowDialogExt(MiscBlackVideoInputTextBox);
        }

        private void MiscBlackOutputButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = DialogFilter.VIDEO_D_1; //"FLV视频(*.flv)|*.flv";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                MiscBlackOutputTextBox.Text = saveFileDialog.FileName;
            }
        }

        private void MiscBlackPicInputButton_Click(object sender, EventArgs e)
        {
            new OpenFileDialog() //"图片(*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif|所有文件(*.*)|*.*"
                .Prepare(DialogFilter.IMAGE, MiscBlackPicInputTextBox.Text)
                .ShowDialogExt(MiscBlackPicInputTextBox);
        }

        private void MiscBlackNoPicCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MiscBlackPicInputTextBox.Enabled = !MiscBlackNoPicCheckBox.Checked;
            MiscBlackPicInputButton.Enabled = !MiscBlackNoPicCheckBox.Checked;
        }

        private void MiscBlackDurationSecondsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MiscBlackDurationSecondsComboBox.Text != "auto")
            {
                MiscBlackBitrateNumericUpDown.Enabled = false;
            }
            else
            {
                MiscBlackBitrateNumericUpDown.Enabled = true;
            }
        }

        private void MiscBlackStartButton_Click(object sender, EventArgs e)
        {
            //验证
            if (!File.Exists(MiscBlackVideoInputTextBox.Text) || Path.GetExtension(MiscBlackVideoInputTextBox.Text) != ".flv")
            {
                MessageBoxExt.ShowErrorMessage("请选择FLV视频文件");
                return;
            }
            if (!File.Exists(MiscBlackPicInputTextBox.Text) && MiscBlackNoPicCheckBox.Checked == false)
            {
                MessageBoxExt.ShowErrorMessage("请选择图片文件或勾选使用黑屏");
                return;
            }
            if (MiscBlackOutputTextBox.Text == "")
            {
                MessageBoxExt.ShowErrorMessage("请选择输出文件");
                return;
            }
            if (MiscBlackBitrateNumericUpDown.Value <= 1)
            {
                MessageBoxExt.ShowErrorMessage("请填写目标码率");
                return;
            }

            BlackProcedure blackProcedure = new BlackProcedure();
            blackProcedure.GetDataFromUI(p =>
            {
                p.inputVideoFile = MiscBlackVideoInputTextBox.Text;
                p.inputImageFile = MiscBlackPicInputTextBox.Text;
                p.outputVideoFile = MiscBlackOutputTextBox.Text;
                p.targetBitrate = (int)MiscBlackBitrateNumericUpDown.Value;
                p.fps = (int)MiscBlackFpsNumericUpDown.Value;
                p.crf = (float)MiscBlackCrfNumericUpDown.Value;
                p.doNotUseImg = MiscBlackNoPicCheckBox.Checked;
            });

            blackProcedure.Execute();

            blackProcedure.SetDataToUI(p =>
            {
                MiscBlackDurationSecondsComboBox.Text = p.durationStr;
            }
            );
        }

        private void MiscBlackVideoInputTextBox_TextChanged(object sender, EventArgs e)
        {
            string path = MiscBlackVideoInputTextBox.Text;
            if (File.Exists(path))
            {
                MiscBlackOutputTextBox.Text = Path.ChangeExtension(path, "_black.flv");
            }
        }

        #endregion MiscBlack

        #endregion Misc Tab

        #region Config Tab

        private void ConfigUiTrayModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Global.Running.trayMode = ConfigUiTrayModeCheckBox.Checked;
        }
        private void ConfigX264PriorityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeProcessPriority();
        }
        private void ConfigFunctionViewLogButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(logFileName))
            {
                Process.Start(logFileName);
            }
            else MessageBoxExt.ShowInfoMessage("没有找到日志文件。");
        }
        private void ConfigFunctionAllLogButton_Click(object sender, EventArgs e)
        {
            string logPath = Path.GetDirectoryName(logFileName);
            if (Directory.Exists(logPath))
            {
                Process.Start(logPath);
            }
            else MessageBoxExt.ShowInfoMessage("没有找到日志文件夹。");
        }
        private void ConfigFunctionRestoreDefaultButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBoxExt.ShowQuestion("是否将所有界面参数恢复到默认设置？", "提示");
            if (result == DialogResult.Yes)
            {
                ResetParameters();
                MessageBoxExt.ShowInfoMessage("已恢复默认设置！");
            }
        }
        private void ConfigFunctionVideoPlayerButton_Click(object sender, EventArgs e)
        {
            new OpenFileDialog()    //"程序(*.exe)|*.exe|所有文件(*.*)|*.*";
                .Prepare(DialogFilter.PROGRAM, ConfigFunctionVideoPlayerTextBox.Text)
                .ShowDialogExt(ConfigFunctionVideoPlayerTextBox);
        }
        private void ConfigFunctionEnableX265CheckBox_Click(object sender, EventArgs e)
        {
            if (MessageBoxExt.ShowQuestion("你必须重新启动小丸工具箱才能使设置的生效 是否现在重新启动？", "需要重新启动") == DialogResult.Yes)
                Application.Restart();
        }

        #endregion Config Tab

        //Ctrl+A 可以全选文本
        private void TextBoxSelectAll(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
                ((TextBoxBase)sender).SelectAll();  // using TextBoxBase to include TextBox, RichTextBox and MaskedTextBox
        }

        private void RemoveSelectedItemFromListBox(ListBox listBox)
        {
            if (listBox.Items.Count > 0 && listBox.SelectedItems.Count > 0)
            {
                int index = listBox.SelectedIndex;
                listBox.Items.RemoveAt(listBox.SelectedIndex);
                if (listBox.Items.Count == 0)   // nothing left in the list
                    return;
                else
                {
                    if (index >= listBox.Items.Count)   // selectIndex is beyond the last item
                        listBox.SelectedIndex = listBox.Items.Count - 1;
                    else
                        listBox.SelectedIndex = index;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ChangeProcessPriority();
        }

        private void ChangeProcessPriority()
        {
            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName.Equals(Path.GetFileNameWithoutExtension(VideoEncoderComboBox.Text)))
                {
                    switch (ConfigX264PriorityComboBox.SelectedIndex)
                    {
                        case 0: process.PriorityClass = ProcessPriorityClass.Idle; break;
                        case 1: process.PriorityClass = ProcessPriorityClass.BelowNormal; break;
                        case 2: process.PriorityClass = ProcessPriorityClass.Normal; break;
                        case 3: process.PriorityClass = ProcessPriorityClass.AboveNormal; break;
                        case 4: process.PriorityClass = ProcessPriorityClass.High; break;
                        case 5: process.PriorityClass = ProcessPriorityClass.RealTime; break;
                    }
                }
            }
        }

        [Obsolete("Not used")]
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.sosg.net/read.php?tid=480646");
        }

        #region MediaInfo Tab

        public string GetMediaInfoString(string mediaFileName)
        {
            try
            {
                return new MediaInfoWrapper(mediaFileName).ToString();
            }
            catch (FileNotFoundException)
            {
                return "文件不存在、非有效文件或者文件夹 无视频信息";
            }
        }

        private void MediaInfoTextBox_DragEnter(object sender, DragEventArgs e)
        {
            // Only allows file drop as link
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else e.Effect = DragDropEffects.None;
        }

        private void MediaInfoTextBox_DragDrop(object sender, DragEventArgs e)
        {
            mediaInfoFile = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            MediaInfoTextBox.Text = GetMediaInfoString(mediaInfoFile);
        }

        private void MediaInfoVideoInputButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() //"视频(*.mp4;*.flv;*.mkv)|*.mp4;*.flv;*.mkv|所有文件(*.*)|*.*"
                .Prepare(DialogFilter.VIDEO_6, mediaInfoFile);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                mediaInfoFile = openFileDialog.FileName;
                MediaInfoTextBox.Text = GetMediaInfoString(mediaInfoFile);
            }
        }

        private void MediaInfoPlayVideoButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(mediaInfoFile))
                Process.Start(mediaInfoFile);
        }

        private void MediaInfoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBoxSelectAll(sender, e);
        }

        private void MediaInfoCopyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(MediaInfoTextBox.Text);
        }

        #endregion MediaInfo Tab

        #region CheckUpdate

        public delegate bool CheckUpadateDelegate(out DateTime newdate, out bool isFullUpdate);

        public void CheckUpdateCallBack(IAsyncResult ar)
        {
            DateTime NewDate;
            bool isFullUpdate;
            AsyncResult result = (AsyncResult)ar;
            CheckUpadateDelegate func = (CheckUpadateDelegate)result.AsyncDelegate;

            try
            {
                bool needUpdate = func.EndInvoke(out NewDate, out isFullUpdate, ar);
                if (needUpdate)
                {
                    if (isFullUpdate)
                    {
                        DialogResult dr = MessageBoxExt.ShowQuestion(string.Format("新版已于{0}发布，是否前往官网下载？", NewDate.ToString("yyyy-M-d")), "喜大普奔");
                        if (dr == DialogResult.Yes)
                        {
                            Process.Start("http://maruko.appinn.me/");
                        }
                    }
                    else
                    {
                        DialogResult dr = MessageBoxExt.ShowQuestion(string.Format("新版已于{0}发布，是否自动升级？（文件约1.5MB）", NewDate.ToString("yyyy-M-d")), "喜大普奔");
                        if (dr == DialogResult.Yes)
                        {
                            FormUpdater formUpdater = new FormUpdater(Global.Running.startPath, NewDate.ToString());
                            formUpdater.ShowDialog(this);
                        }
                    }
                }
                else
                {
                    //MessageBox.Show("已经是最新版了喵！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception) { }
        }

        public bool CheckUpdate(out DateTime NewDate, out bool isFullUpdate)
        {
            // init
            NewDate = DateTime.Parse("1990-03-08");
            isFullUpdate = false;

            WebRequest request = WebRequest.Create("http://maruko.appinn.me/config/version.html");
            WebResponse wrs = request.GetResponse();
            // read the response ...
            Stream dataStream = wrs.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();

            Regex dateReg = new Regex(@"Date20\S+Date");
            Regex VersionReg = new Regex(@"Version\d+Version");
            Match dateMatch = dateReg.Match(responseFromServer);
            Match versionMatch = VersionReg.Match(responseFromServer);

            if (dateMatch.Success)
            {
                string date = dateMatch.Value.Replace("Date", "");
                string version = versionMatch.Value.Replace("Version", "");
                NewDate = DateTime.Parse(date);
                int NewVersion = int.Parse(version);
                int s = DateTime.Compare(NewDate, ReleaseDate);

                int currentVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor;
                if (NewVersion > currentVersion)
                {
                    isFullUpdate = true;
                }
                else
                {
                    isFullUpdate = false;
                }
                //DateTime CompileDate = System.IO.File.GetLastWriteTime(this.GetType().Assembly.Location); //获得程序编译时间
                if (s == 1) //NewDate is later than ReleaseDate
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        private void HelpCheckUpdateButton_Click(object sender, EventArgs e)
        {
            if (NetworkUtil.IsConnectInternet())
            {
                WebRequest request = WebRequest.Create("http://maruko.appinn.me/config/version.html");
                request.Credentials = CredentialCache.DefaultCredentials;
                // Get the response.
                request.BeginGetResponse(new AsyncCallback(OnResponse), request);
            }
            else
            {
                MessageBoxExt.ShowErrorMessage("这台电脑似乎没有联网呢~");
            }
        }

        protected void OnResponse(IAsyncResult ar)
        {
            WebRequest wrq = (WebRequest)ar.AsyncState;
            WebResponse wrs = wrq.EndGetResponse(ar);
            // read the response ...
            Stream dataStream = wrs.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            Regex dateReg = new Regex(@"Date20\S+Date");
            Regex VersionReg = new Regex(@"Version\d+Version");
            Match dateMatch = dateReg.Match(responseFromServer);
            Match versionMatch = VersionReg.Match(responseFromServer);
            DateTime NewDate = DateTime.Parse("1990-03-08");
            bool isFullUpdate = false;
            if (dateMatch.Success)
            {
                string date = dateMatch.Value.Replace("Date", "");
                string version = versionMatch.Value.Replace("Version", "");
                NewDate = DateTime.Parse(date);
                int NewVersion = int.Parse(version);
                int s = DateTime.Compare(NewDate, ReleaseDate);

                int currentVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor;
                if (NewVersion > currentVersion)
                {
                    isFullUpdate = true;
                }
                else
                {
                    isFullUpdate = false;
                }
                //DateTime CompileDate = System.IO.File.GetLastWriteTime(this.GetType().Assembly.Location); //获得程序编译时间
                if (s == 1) //NewDate is later than ReleaseDate
                {
                    if (isFullUpdate)
                    {
                        DialogResult dr = MessageBoxExt.ShowQuestion(string.Format("新版已于{0}发布，是否前往官网下载？", NewDate.ToString("yyyy-M-d")), "喜大普奔");
                        if (dr == DialogResult.Yes)
                        {
                            Process.Start("http://maruko.appinn.me/");
                        }
                    }
                    else
                    {
                        DialogResult dr = MessageBoxExt.ShowQuestion(string.Format("新版已于{0}发布，是否自动升级？（文件约1.5MB）", NewDate.ToString("yyyy-M-d")), "喜大普奔");
                        if (dr == DialogResult.Yes)
                        {
                            FormUpdater formUpdater = new FormUpdater(Global.Running.startPath, date);
                            formUpdater.ShowDialog(this);
                        }
                    }
                }
                else
                {
                    MessageBoxExt.ShowInfoMessage("已经是最新版了喵！");
                }
            }
            else
            {
                MessageBoxExt.ShowInfoMessage("啊咧~似乎未能获取版本信息，请点击软件主页按钮查看最新版本。");
            }
        }

        #endregion CheckUpdate

        #region TabControl

        private void MainTabControl_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
                Point pt = new Point(e.X + 2, e.Y + 2);
                pt = PointToClient(pt);
                int pi = GetTabPageByTab(pt);
                if (pi != -1)
                {
                    MainTabControl.SelectedIndex = pi;
                }
            }
            else e.Effect = DragDropEffects.None;
        }

        /// <summary>
        /// Finds the TabPage whose tab is contains the given point.
        /// </summary>
        /// <param name="pt">The point (given in client coordinates) to look for a TabPage.</param>
        /// <returns>The TabPage whose tab is at the given point (null if there isn't one).</returns>
        private int GetTabPageByTab(Point pt)
        {
            TabPage tp = null;
            int pageIndex = -1;
            for (int i = 0; i < MainTabControl.TabPages.Count; i++)
            {
                Rectangle a = MainTabControl.GetTabRect(i);

                if (MainTabControl.GetTabRect(i).Contains(pt))
                {
                    tp = MainTabControl.TabPages[i];
                    pageIndex = i;
                    break;
                }
            }
            return pageIndex;
        }

        #endregion TabControl
    }
}