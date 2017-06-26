// ------------------------------------------------------------------
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
using mp4box.Procedure;
using mp4box.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        public static MainForm Instance;
        public string workPath = "!undefined";
        public bool shutdownState = false;
        public bool trayMode = false;
        private Preset preset;

        #region Private Members Declaration

        private StringBuilder avsBuilder = new StringBuilder(1000);

        private int indexofsource;
        private int indexoftarget;
        private byte x264mode = 1;

        private string audioInput = "";
        private string audioOutput;
        private string avsOutput;
        private string avsSubtitleInput = "subtitle";
        private string avsVideoInput = "video";
        private string extractFlvInput = "";
        private string extractMkvInput = "";
        private string extractMp4VideoInput = "";
        private string videoInput = "";
        private string videoOutput;
        private string videoSubtitle = "";

        private string mediaInfoFile;

        private string mux;
        private string x264;
        private string ffmpeg;
        private string aac;
        private string aextract;

        private string batpath;
        private string auto;
        private string startpath;
        private string avs = "";
        private string tempavspath = "";
        private string tempPic = "";
        private string logFileName, logPath;
        private string tempfilepath;
        private DateTime ReleaseDate = AssemblyUtil.GetAssemblyVersionTime();

        #endregion Private Members Declaration

        public MainForm()
        {
            Instance = this;
            logPath = Application.StartupPath + "\\logs";
            logFileName = logPath + "\\LogFile-" + DateTime.Now.ToString("yyyy'-'MM'-'dd'_'HH'-'mm'-'ss") + ".log";
            preset = new Preset();
            InitializeComponent();
        }

        public string ffmuxbat(string input1, string input2, string output)
        {
            return $"\"{workPath}\\ffmpeg.exe\" -i \"{input1}\" -i \"{input2}\" -sn -c copy -y \"{output}\"{Environment.NewLine}";
        }

        public string boxmuxbat(string input1, string input2, string output)
        {
            return $"\"{workPath}\\mp4box.exe\" -add \"{input1}#trackID=1:name=\" -add \"{input2}#trackID=1:name=\" -new \"{output}\"{Environment.NewLine}";
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
                sb.Append("\"" + workPath + "\\avs4x26x.exe\"" + " -L ");
            }
            sb.Append("\"" + Path.Combine(workPath, VideoEncoderComboBox.SelectedItem.ToString()) + "\"");
            // 编码模式
            switch (x264mode)
            {
                case 0: // 自定义
                    sb.Append(" " + xvs.CustomParameter);
                    break;

                case 1: // crf
                    sb.Append(" --crf " + xvs.CrfValue);
                    break;

                case 2: // 2pass
                    sb.Append(" --pass " + pass + " --bitrate " + xvs.X26xBitrate + " --stats \"" + Path.Combine(tempfilepath, Path.GetFileNameWithoutExtension(output)) + ".stats\"");
                    break;
            }
            if (x264mode != 0)
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
                    sb.Append(" --vf subtitles --sub \"" + sub + "\"");
                else
                {
                    Regex r = new Regex("--vf\\s\\S*");
                    Match m = r.Match(x264tmpline);
                    sb.Insert(m.Index + 5, "subtitles/").Append(" --sub \"" + sub + "\"");
                }
            }
            if (xvs.X26xSeek != 0)
                sb.Append(" --seek " + xvs.X26xSeek);
            if (xvs.X26xFrames != 0)
                sb.Append(" --frames " + xvs.X26xFrames);
            if (x264mode == 2 && pass == 1)
                sb.Append(" -o NUL");
            else if (!string.IsNullOrEmpty(output))
                sb.Append(" -o " + "\"" + output + "\"");
            if (!string.IsNullOrEmpty(input))
                sb.Append(" \"" + input + "\"");
            return sb.ToString();
        }

        public string x265bat(string input, string output, int pass = 1, string sub = "")
        {
            StringBuilder sb = new StringBuilder();
            XvSettings xvs = GetXvSettings();

            bool isAvs = Path.GetExtension(input).ToLower().Equals(".avs");
            if (isAvs)
            {
                sb.Append("\"" + workPath + "\\avs4x26x.exe\"" + " -L ");
            }
            else
            {
                sb.Append("\"" + workPath + "\\ffmpeg.exe\"" + " -i \"" + input + "\"");
                if (xvs.V_height != 0 && xvs.V_height != 0 && !xvs.IsResizeChecked)
                    sb.Append(string.Format(" -vf zscale={0}x{1}:filter=lanczos", xvs.V_width, xvs.V_height));
                if (!string.IsNullOrEmpty(sub))
                {
                    string x264tmpline = sb.ToString();
                    if (x264tmpline.IndexOf("-vf") == -1)
                        sb.Append(" -vf subtitles=\"" + FileStringUtil.GetLibassFormatPath(sub) + "\"");
                    else
                    {
                        int index = x264tmpline.IndexOf("lanczos");
                        sb.Insert(index + 7, ",subtitles=\"" + FileStringUtil.GetLibassFormatPath(sub) + "\"");
                    }
                }
                sb.Append(" -strict -1 -f yuv4mpegpipe -an - | ");
            }

            sb.Append(FileStringUtil.FormatPath(Path.Combine(workPath, VideoEncoderComboBox.SelectedItem.ToString())) + (isAvs ? string.Empty : " --y4m"));
            // 编码模式
            switch (x264mode)
            {
                case 0: // 自定义
                    sb.Append(" " + xvs.CustomParameter);
                    break;

                case 1: // crf
                    sb.Append(" --crf " + xvs.CrfValue);
                    break;

                case 2: // 2pass
                    sb.Append(" --pass " + pass + " --bitrate " + xvs.X26xBitrate + " --stats \"" + Path.Combine(tempfilepath, Path.GetFileNameWithoutExtension(output)) + ".stats\"");
                    break;
            }
            if (x264mode != 0)
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
            if (x264mode == 2 && pass == 1)
                sb.Append(" -o NUL");
            else if (!string.IsNullOrEmpty(output))
                sb.Append(" -o " + "\"" + output + "\"");
            if (!string.IsNullOrEmpty(input))
            {
                if (isAvs)
                    sb.Append(" \"" + input + "\"");
                else
                    sb.Append(" -");
            }
            return sb.ToString();
        }

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
            ffmpeg = "\"" + workPath + "\\ffmpeg.exe\" -i \"" + input + "\" -vn -sn -v 0 -c:a pcm_s16le -f wav pipe:|";
            switch (AudioEncoderComboBox.SelectedIndex)
            {
                case 0:
                    if (AudioAudioModeBitrateRadioButton.Checked)
                    {
                        ffmpeg += "\"" + workPath + "\\neroAacEnc.exe\" -ignorelength -lc -br " + br + " -if - -of \"" + output + "\"";
                    }
                    if (AudioAudioModeCustomRadioButton.Checked)
                    {
                        ffmpeg += "\"" + workPath + "\\neroAacEnc.exe\" -ignorelength " + AudioCustomParameterTextBox.Text + " -if - -of \"" + output + "\"";
                    }
                    break;

                case 1:
                    if (AudioAudioModeBitrateRadioButton.Checked)
                    {
                        ffmpeg += "\"" + workPath + "\\qaac.exe\" -q 2 --ignorelength -c " + AudioBitrateComboBox.Text + " - -o \"" + output + "\"";
                    }
                    if (AudioAudioModeCustomRadioButton.Checked)
                    {
                        ffmpeg += "\"" + workPath + "\\qaac.exe\" --ignorelength " + AudioCustomParameterTextBox.Text + " - -o \"" + output + "\"";
                    }
                    break;

                case 2:
                    if (Path.GetExtension(output) == ".aac")
                        output = Path.ChangeExtension(output, ".wav");
                    ffmpeg = "\"" + workPath + "\\ffmpeg.exe\" -y -i \"" + input + "\" -f wav \"" + output + "\"";
                    break;

                case 3:
                    ffmpeg += "\"" + workPath + "\\refalac.exe\" --ignorelength - -o \"" + output + "\"";
                    break;

                case 4:
                    ffmpeg += "\"" + workPath + "\\flac.exe\" -f --ignore-chunk-sizes -5 - -o \"" + output + "\"";
                    break;

                case 5:
                    if (AudioAudioModeBitrateRadioButton.Checked)
                    {
                        ffmpeg += "\"" + workPath + "\\fdkaac.exe\" --ignorelength -b " + AudioBitrateComboBox.Text + " - -o \"" + output + "\"";
                    }
                    if (AudioAudioModeCustomRadioButton.Checked)
                    {
                        ffmpeg += "\"" + workPath + "\\fdkaac.exe\" --ignorelength " + AudioCustomParameterTextBox.Text + " - -o \"" + output + "\"";
                    }
                    break;

                case 6:
                    ffmpeg = "\"" + workPath + "\\ffmpeg.exe\" -i \"" + input + "\" -c:a ac3 -b:a " + AudioBitrateComboBox.Text + "k \"" + output + "\"";
                    break;

                case 7:
                    if (AudioAudioModeBitrateRadioButton.Checked)
                    {
                        ffmpeg += "\"" + workPath + "\\lame.exe\" -q 3 -b " + AudioBitrateComboBox.Text + " - \"" + output + "\"";
                    }
                    if (AudioAudioModeCustomRadioButton.Checked)
                    {
                        ffmpeg += "\"" + workPath + "\\lame.exe\" " + AudioCustomParameterTextBox.Text + " - \"" + output + "\"";
                    }
                    break;

                default:
                    break;
            }
            aac = ffmpeg + "\r\n";
            return aac;
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

        private void ExtractAV(string namevideo, string av, int streamIndex)
        {
            if (string.IsNullOrEmpty(namevideo))
            {
                MessageBoxExt.ShowErrorMessage("请选择视频文件");
                return;
            }

            string ext = Path.GetExtension(namevideo);
            //aextract = "\"" + workPath + "\\mp4box.exe\" -raw 2 \"" + namevideo + "\"";
            string aextract = "";
            aextract += FileStringUtil.FormatPath(workPath + "\\ffmpeg.exe");
            aextract += " -i " + FileStringUtil.FormatPath(namevideo);
            if (av == "a")
            {
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
                    MessageBoxExt.ShowInfoMessage("该轨道无音频");
                    return;
                }
            }
            else if (av == "v")
            {
                aextract += " -an -sn -c:v copy -y -map 0:v:" + streamIndex + " ";
            }
            else
            {
                throw new Exception("未知流！");
            }
            string suf = "_audio_";
            if (av == "v")
            {
                suf = "_video_";
            }
            suf += "index" + streamIndex;
            //string outfile = FileStringUtil.GetDir(namevideo) +
            //    Path.GetFileNameWithoutExtension(namevideo) + suf + ext;
            string outfile = Path.ChangeExtension(namevideo, suf + ext);
            aextract += FileStringUtil.FormatPath(outfile);
            batpath = workPath + "\\" + av + "extract.bat";
            File.WriteAllText(batpath, aextract, Encoding.Default);
            LogRecord(aextract);
            Process.Start(batpath);
        }

        private string ExtractAudio(string namevideo, string outfile, int streamIndex = 0)
        {
            if (string.IsNullOrEmpty(namevideo))
            {
                return "";
            }
            string ext = Path.GetExtension(namevideo);
            //aextract = "\"" + workPath + "\\mp4box.exe\" -raw 2 \"" + namevideo + "\"";
            string aextract = "";
            aextract += FileStringUtil.FormatPath(workPath + "\\ffmpeg.exe");
            aextract += " -i " + FileStringUtil.FormatPath(namevideo);
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
                return "";
            }
            aextract += FileStringUtil.FormatPath(outfile) + "\r\n";
            return aextract;
        }

        private void ExtractTrack(string namevideo, int streamIndex)
        {
            if (string.IsNullOrEmpty(namevideo))
            {
                MessageBoxExt.ShowErrorMessage("请选择视频文件");
                return;
            }

            string aextract = "";
            aextract += FileStringUtil.FormatPath(workPath + "\\ffmpeg.exe");
            aextract += " -i " + FileStringUtil.FormatPath(namevideo);
            aextract += " -map 0:" + streamIndex + " -c copy ";
            string suf = "_抽取流Index" + streamIndex;
            //string outfile = FileStringUtil.GetDir(namevideo) +
            //    Path.GetFileNameWithoutExtension(namevideo) + suf + '.' +
            //    FormatExtractor.Extract(workPath, namevideo)[streamIndex].Format;
            string outfile = Path.ChangeExtension(namevideo, suf + '.' +
                             FormatExtractor.Extract(workPath, namevideo)[streamIndex].Format);
            aextract += FileStringUtil.FormatPath(outfile);
            batpath = workPath + "\\mkvextract.bat";
            File.WriteAllText(batpath, aextract, Encoding.Default);
            LogRecord(aextract);
            Process.Start(batpath);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            #region Delete Temp Files

            if (ConfigFunctionDeleteTempFileCheckBox.Checked && !workPath.Equals("!undefined"))
            {
                List<string> deleteFileList = new List<string>();

                string systemDisk = Environment.GetFolderPath(Environment.SpecialFolder.System).Substring(0, 3);
                string systemTempPath = systemDisk + @"windows\temp";

                //Delete all BAT files
                //DirectoryInfo theFolder = new DirectoryInfo(workPath);
                //foreach (FileInfo NextFile in theFolder.GetFiles())
                //{
                //    if (NextFile.Extension.Equals(".bat"))
                //        deleteFileList.Add(NextFile.FullName);
                //}
                string[] batFiles = Directory.GetFiles(workPath, "*.bat");

                if (Directory.Exists(tempfilepath))
                {
                    foreach (var item in Directory.GetFiles(tempfilepath))
                    {
                        deleteFileList.Add(item);
                    }
                }

                string[] deletedfiles = { "concat.txt", tempPic, tempavspath };
                deleteFileList.AddRange(deletedfiles);
                deleteFileList.AddRange(batFiles);

                Process currentpro = Process.GetCurrentProcess();
                Process[] processes = Process.GetProcessesByName(currentpro.ProcessName);
                List<Process> listpro = new List<Process>();
                foreach (Process ps in processes)
                {
                    if (System.Reflection.Assembly.GetExecutingAssembly().Location == ps.MainModule.FileName)
                        listpro.Add(ps);
                }
                if (listpro.Count() == 1)
                {
                    foreach (string file in deleteFileList)
                    {
                        File.Delete(file);
                    }
                }
            }

            #endregion Delete Temp Files

            #region Save Settings

            SaveSettings();

            #endregion Save Settings
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

                if (int.Parse(ConfigurationManager.AppSettings["x264Exe"]) > VideoEncoderComboBox.Items.Count - 1)
                    VideoEncoderComboBox.SelectedIndex = 0;
                else
                    VideoEncoderComboBox.SelectedIndex = Convert.ToInt32(ConfigurationManager.AppSettings["x264Exe"]);
                AudioBitrateComboBox.Text = ConfigurationManager.AppSettings["AudioBitrate"];
                AudioEncoderComboBox.SelectedIndex = Convert.ToInt32(ConfigurationManager.AppSettings["AudioEncoder"]);
                AvsScriptTextBox.Text = ConfigurationManager.AppSettings["AVSScript"];
                ConfigFunctionAutoCheckUpdateCheckBox.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["CheckUpdate"]);
                ConfigFunctionDeleteTempFileCheckBox.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["SetupDeleteTempFile"]);
                ConfigFunctionEnableX265CheckBox.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["x265Enable"]);
                ConfigFunctionVideoPlayerTextBox.Text = ConfigurationManager.AppSettings["PreviewPlayer"];
                ConfigUiSplashScreenCheckBox.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["SplashScreen"]);
                ConfigUiTrayModeCheckBox.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["TrayMode"]);
                ConfigX264ExtraParameterTextBox.Text = ConfigurationManager.AppSettings["x264ExtraParameter"];
                ConfigX264PriorityComboBox.SelectedIndex = Convert.ToInt32(ConfigurationManager.AppSettings["x264Priority"]);
                ConfigX264ThreadsComboBox.SelectedIndex = Convert.ToInt32(ConfigurationManager.AppSettings["x264Threads"]);
                MiscBlackBitrateNumericUpDown.Value = Convert.ToDecimal(ConfigurationManager.AppSettings["BlackBitrate"]);
                MiscBlackCrfNumericUpDown.Value = Convert.ToDecimal(ConfigurationManager.AppSettings["BlackCRF"]);
                MiscBlackFpsNumericUpDown.Value = Convert.ToDecimal(ConfigurationManager.AppSettings["BlackFPS"]);
                MiscOnePicBitrateNumericUpDown.Value = Convert.ToDecimal(ConfigurationManager.AppSettings["OnePicAudioBitrate"]);
                MiscOnePicCrfNumericUpDown.Value = Convert.ToDecimal(ConfigurationManager.AppSettings["OnePicCRF"]);
                MiscOnePicFpsNumericUpDown.Value = Convert.ToDecimal(ConfigurationManager.AppSettings["OnePicFPS"]);
                MuxConvertFormatComboBox.SelectedIndex = Convert.ToInt32(ConfigurationManager.AppSettings["MuxFormat"]);
                VideoAudioModeComboBox.SelectedIndex = Convert.ToInt32(ConfigurationManager.AppSettings["x264AudioMode"]);
                VideoAudioParameterTextBox.Text = ConfigurationManager.AppSettings["x264AudioParameter"];
                VideoBatchSubtitleLanguage.DataSource = Convert.ToString(ConfigurationManager.AppSettings["SubLanguageExtension"]).Split(',');
                VideoBitrateNumericUpDown.Value = Convert.ToDecimal(ConfigurationManager.AppSettings["x264Bitrate"]);
                VideoCrfNumericUpDown.Value = Convert.ToDecimal(ConfigurationManager.AppSettings["x264CRF"]);
                VideoCustomParameterTextBox.Text = ConfigurationManager.AppSettings["x264CustomParameter"];
                VideoDemuxerComboBox.SelectedIndex = Convert.ToInt32(ConfigurationManager.AppSettings["x264Demuxer"]);
                VideoHeightNumericUpDown.Value = Convert.ToDecimal(ConfigurationManager.AppSettings["x264Height"]);
                VideoWidthNumericUpDown.Value = Convert.ToDecimal(ConfigurationManager.AppSettings["x264Width"]);
                if (VideoEncoderComboBox.SelectedIndex == -1)
                {
                    VideoEncoderComboBox.SelectedIndex = VideoEncoderComboBox.Items.IndexOf("x264_32-8bit");
                }

                if (int.Parse(ConfigurationManager.AppSettings["LanguageIndex"]) == -1)  //First Startup
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
                    ConfigUiLanguageComboBox.SelectedIndex = int.Parse(ConfigurationManager.AppSettings["LanguageIndex"]);

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
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cfa.AppSettings.Settings["x264CRF"].Value = VideoCrfNumericUpDown.Value.ToString();
            cfa.AppSettings.Settings["x264Bitrate"].Value = VideoBitrateNumericUpDown.Value.ToString();
            cfa.AppSettings.Settings["x264AudioParameter"].Value = VideoAudioParameterTextBox.Text;
            cfa.AppSettings.Settings["x264AudioMode"].Value = VideoAudioModeComboBox.SelectedIndex.ToString();
            cfa.AppSettings.Settings["x264Exe"].Value = VideoEncoderComboBox.SelectedIndex.ToString();
            cfa.AppSettings.Settings["x264Demuxer"].Value = VideoDemuxerComboBox.SelectedIndex.ToString();
            cfa.AppSettings.Settings["x264Width"].Value = VideoWidthNumericUpDown.Value.ToString();
            cfa.AppSettings.Settings["x264Height"].Value = VideoHeightNumericUpDown.Value.ToString();
            cfa.AppSettings.Settings["x264CustomParameter"].Value = VideoCustomParameterTextBox.Text;
            cfa.AppSettings.Settings["x264Priority"].Value = ConfigX264PriorityComboBox.SelectedIndex.ToString();
            cfa.AppSettings.Settings["x264ExtraParameter"].Value = ConfigX264ExtraParameterTextBox.Text;
            cfa.AppSettings.Settings["AVSScript"].Value = AvsScriptTextBox.Text;
            cfa.AppSettings.Settings["AudioEncoder"].Value = AudioEncoderComboBox.SelectedIndex.ToString();
            cfa.AppSettings.Settings["AudioParameter"].Value = AudioBitrateComboBox.Text;
            cfa.AppSettings.Settings["OnePicAudioBitrate"].Value = MiscOnePicBitrateNumericUpDown.Value.ToString();
            cfa.AppSettings.Settings["OnePicFPS"].Value = MiscOnePicFpsNumericUpDown.Value.ToString();
            cfa.AppSettings.Settings["OnePicCRF"].Value = MiscOnePicCrfNumericUpDown.Value.ToString();
            cfa.AppSettings.Settings["BlackFPS"].Value = MiscBlackFpsNumericUpDown.Value.ToString();
            cfa.AppSettings.Settings["BlackCRF"].Value = MiscBlackCrfNumericUpDown.Value.ToString();
            cfa.AppSettings.Settings["BlackBitrate"].Value = MiscBlackBitrateNumericUpDown.Value.ToString();
            cfa.AppSettings.Settings["SetupDeleteTempFile"].Value = ConfigFunctionDeleteTempFileCheckBox.Checked.ToString();
            cfa.AppSettings.Settings["CheckUpdate"].Value = ConfigFunctionAutoCheckUpdateCheckBox.Checked.ToString();
            cfa.AppSettings.Settings["TrayMode"].Value = ConfigUiTrayModeCheckBox.Checked.ToString();
            cfa.AppSettings.Settings["LanguageIndex"].Value = ConfigUiLanguageComboBox.SelectedIndex.ToString();
            cfa.AppSettings.Settings["SplashScreen"].Value = ConfigUiSplashScreenCheckBox.Checked.ToString();
            cfa.AppSettings.Settings["x264Threads"].Value = ConfigX264ThreadsComboBox.SelectedIndex.ToString();
            cfa.AppSettings.Settings["x265Enable"].Value = ConfigFunctionEnableX265CheckBox.Checked.ToString();
            cfa.AppSettings.Settings["PreviewPlayer"].Value = ConfigFunctionVideoPlayerTextBox.Text;
            cfa.AppSettings.Settings["MuxFormat"].Value = MuxConvertFormatComboBox.SelectedIndex.ToString(); ;
            cfa.Save();
            ConfigurationManager.RefreshSection("appSettings"); // 刷新命名节，在下次检索它时将从磁盘重新读取它。记住应用程序要刷新节点
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            int processorNumber = Environment.ProcessorCount;

            ConfigX264ThreadsComboBox.Items.Add("auto");
            for (int i = 1; i <= 16; i++)
            {
                ConfigX264ThreadsComboBox.Items.Add(i.ToString());
            }

            //define workpath
            startpath = System.Windows.Forms.Application.StartupPath;
            workPath = startpath + "\\tools";
            if (!Directory.Exists(workPath))
            {
                MessageBox.Show("tools文件夹没有解压喔~ 工具箱里没有工具的话运行不起来的喔~", "（这只丸子）",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
            //Directory.CreateDirectory(workPath);
            //string diskSymbol = startpath.Substring(0, 1);

            //string systemDisk = Environment.GetFolderPath(Environment.SpecialFolder.System).Substring(0, 3);
            //string systemTempPath = systemDisk + @"windows\temp";
            string systemTempPath = Environment.GetEnvironmentVariable("TEMP", EnvironmentVariableTarget.Machine);
            tempavspath = systemTempPath + "\\temp.avs";
            tempPic = systemTempPath + "\\marukotemp.jpg";
            tempfilepath = startpath + "\\temp";

            //load x264 exe
            DirectoryInfo folder = new DirectoryInfo(workPath);
            List<string> x264exe = new List<string>();
            try
            {
                bool usex265 = bool.Parse(ConfigurationManager.AppSettings["x265Enable"].ToString());
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

            // avisynth未安装使用本地内置的avs
            if (string.IsNullOrEmpty(FileStringUtil.CheckAviSynth()))
            {
                string sourceAviSynthdll = Path.Combine(workPath, @"avs\AviSynth.dll");
                string sourceDevILdll = Path.Combine(workPath, @"avs\DevIL.dll");
                if (File.Exists(sourceAviSynthdll) && File.Exists(sourceDevILdll))
                {
                    try
                    {
                        File.Copy(sourceAviSynthdll, Path.Combine(workPath, "AviSynth.dll"), true);
                        File.Copy(sourceDevILdll, Path.Combine(workPath, "DevIL.dll"), true);
                        LogRecord("未安装avisynth,使用本地内置avs.");
                    }
                    catch (IOException) { }
                }
            }
            else
            {
                File.Delete(Path.Combine(workPath, "AviSynth.dll"));
                File.Delete(Path.Combine(workPath, "DevIL.dll"));
            }

            //load AVS filter
            DirectoryInfo avspath = new DirectoryInfo(workPath + @"\avs\plugins");
            List<string> avsfilters = new List<string>();
            if (Directory.Exists(workPath + @"\avs\plugins"))
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

            //ReleaseDate = System.IO.File.GetLastWriteTime(this.GetType().Assembly.Location); //获得程序编译时间
            HelpReleaseDateLabel.Text = ReleaseDate.ToString("yyyy-M-d");

            // load Help Text
            if (File.Exists(startpath + "\\help.rtf"))
            {
                HelpContentRichTextBox.LoadFile(startpath + "\\help.rtf");
            }

            LoadSettings();
        }

        #region VideoBatch

        public string VideoBatch(string input, string output)
        {
            bool hasAudio = false;
            string bat = "";
            string inputName = Path.GetFileNameWithoutExtension(input);
            string tempVideo = Path.Combine(tempfilepath, inputName + "_vtemp.mp4");
            string tempAudio = Path.Combine(tempfilepath, inputName + "_atemp" + getAudioExt());
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
                        tempAudio = Path.Combine(tempfilepath, inputName + "_atemp.aac");
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
                if (x264mode == 2)
                    x264 = x264bat(input, tempVideo, 1, sub) + "\r\n" +
                           x264bat(input, tempVideo, 2, sub);
                else x264 = x264bat(input, tempVideo, 0, sub);
                if (audioMode == 1 || !hasAudio)
                    x264 = x264.Replace(tempVideo, output);
            }
            else if (VideoEncoderComboBox.SelectedItem.ToString().ToLower().Contains("x265"))
            {
                tempVideo = Path.Combine(tempfilepath, inputName + "_vtemp.hevc");
                if (x264mode == 2)
                    x264 = x265bat(input, tempVideo, 1, sub) + "\r\n" +
                           x265bat(input, tempVideo, 2, sub);
                else x264 = x265bat(input, tempVideo, 0, sub);
                if (audioMode == 1 || !hasAudio)
                    x264 += "\r\n\"" + workPath + "\\mp4box.exe\"  -add  \"" + tempVideo + "#trackID=1:name=\" -new \"" + output + "\" \r\n";
            }
            x264 += "\r\n";

            //封装
            if (VideoBatchFormatComboBox.Text == "mp4")
                mux = boxmuxbat(tempVideo, tempAudio, output);
            else
                mux = ffmuxbat(tempVideo, tempAudio, output);
            if (audioMode != 1 && hasAudio) //如果压制音频
                bat += aextract + x264 + mux + " \r\n";
            else
                bat += x264 + " \r\n";

            bat += "del \"" + tempAudio + "\"\r\n";
            bat += "del \"" + tempVideo + "\"\r\n";
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
            indexoftarget = listbox.IndexFromPoint(listbox.PointToClient(new Point(e.X, e.Y)));
            if (indexoftarget != ListBox.NoMatches)
            {
                string temp = listbox.Items[indexoftarget].ToString();
                listbox.Items[indexoftarget] = listbox.Items[indexofsource];
                listbox.Items[indexofsource] = temp;
                listbox.SelectedIndex = indexoftarget;
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
            indexofsource = ((ListBox)sender).IndexFromPoint(e.X, e.Y);
            if (indexofsource == 65535)
                return;
            if (indexofsource != ListBox.NoMatches)
            {
                ((ListBox)sender).DoDragDrop(((ListBox)sender).Items[indexofsource].ToString(), DragDropEffects.All);
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

            FileStringUtil.ensureDirectoryExists(tempfilepath);
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

            LogRecord(bat);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(GetCultureName());
            WorkingForm wf = new WorkingForm(bat, VideoBatchItemListbox.Items.Count);
            wf.Owner = this;
            wf.Show();
            //batpath = workPath + "\\auto.bat";
            //File.WriteAllText(batpath, bat, Encoding.Default);
            //Process.Start(batpath);
        }

        #endregion VideoBatch

        private void AudioOutputTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (File.Exists(AudioOutputTextBox.Text))
            {
                Process.Start(AudioOutputTextBox.Text);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcesses();
            for (int i = 0; i < processes.GetLength(0); i++)
            {
                //我是要找到我需要的YZT.exe的进程,可以根据ProcessName属性判断
                if (processes[i].ProcessName.Equals(Path.GetFileNameWithoutExtension(VideoEncoderComboBox.Text)))
                {
                    switch (ConfigX264PriorityComboBox.SelectedIndex)
                    {
                        case 0: processes[i].PriorityClass = ProcessPriorityClass.Idle; break;
                        case 1: processes[i].PriorityClass = ProcessPriorityClass.BelowNormal; break;
                        case 2: processes[i].PriorityClass = ProcessPriorityClass.Normal; break;
                        case 3: processes[i].PriorityClass = ProcessPriorityClass.AboveNormal; break;
                        case 4: processes[i].PriorityClass = ProcessPriorityClass.High; break;
                        case 5: processes[i].PriorityClass = ProcessPriorityClass.RealTime; break;
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

        #region Mux Tab

        #region MuxMkv

        private void MuxMkvVideoInputButton_Click(object sender, EventArgs e)
        {
            new OpenFileDialog()
                .Prepare(DialogFilter.ALL, MuxMkvVideoInputTextBox.Text)
                .ShowDialogExt(MuxMkvVideoInputTextBox);

            //openFileDialog1.Filter = DialogFilter.ALL); //"所有文件(*.*)|*.*";
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    MuxMkvVideoInputTextBox.Text = openFileDialog1.FileName;
            //}
        }

        private void MuxMkvStartButton_Click(object sender, EventArgs e)
        {
            if (MuxMkvVideoInputTextBox.Text == "" && MuxMkvAudioInputTextBox.Text == "")
            {
                MessageBoxExt.ShowErrorMessage("请选择文件");
                return;
            }

            MuxMkvProcedure muxMkvProcedure = new MuxMkvProcedure(workPath);
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
            new OpenFileDialog()
                .Prepare(DialogFilter.AUDIO_1, MuxMkvAudioInputTextBox.Text)
                .ShowDialogExt(MuxMkvAudioInputTextBox);

            //openFileDialog1.Filter = DialogFilter.AUDIO_1; //"音频(*.mp3;*.aac;*.ac3)|*.mp3;*.aac;*.ac3|所有文件(*.*)|*.*";
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    MuxMkvAudioInputTextBox.Text = openFileDialog1.FileName;
            //}
        }

        private void MuxMkvSubtitleButton_Click(object sender, EventArgs e)
        {
            new OpenFileDialog()
                .Prepare(DialogFilter.SUBTITLE_2, MuxMkvSubtitleTextBox.Text)
                .ShowDialogExt(MuxMkvSubtitleTextBox);

            //openFileDialog1.Filter = DialogFilter.SUBTITLE_2; //"字幕(*.ass;*.ssa;*.srt;*.idx;*.sup)|*.ass;*.ssa;*.srt;*.idx;*.sup|所有文件(*.*)|*.*";
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    MuxMkvSubtitleTextBox.Text = openFileDialog1.FileName;
            //}
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
            new OpenFileDialog()
                .Prepare(DialogFilter.AUDIO_3, MuxMp4AudioInputTextBox.Text)
                .ShowDialogExt(MuxMp4AudioInputTextBox);

            //openFileDialog1.Filter = DialogFilter.AUDIO_3; //"音频(*.mp4;*.aac;*.mp2;*.mp3;*.m4a;*.ac3)|*.mp4;*.aac;*.mp2;*.mp3;*.m4a;*.ac3|所有文件(*.*)|*.*";
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    MuxMp4AudioInputTextBox.Text = openFileDialog1.FileName;
            //}
        }

        private void MuxMp4VideoInputButton_Click(object sender, EventArgs e)
        {
            new OpenFileDialog()
                .Prepare(DialogFilter.VIDEO_9, MuxMp4VideoInputTextBox.Text)
                .ShowDialogExt(MuxMp4VideoInputTextBox);

            //openFileDialog1.Filter = DialogFilter.VIDEO_9;//"视频(*.avi;*.mp4;*.m1v;*.m2v;*.m4v;*.264;*.h264;*.hevc)|*.avi;*.mp4;*.m1v;*.m2v;*.m4v;*.264;*.h264;*.hevc|所有文件(*.*)|*.*";
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    MuxMp4VideoInputTextBox.Text = openFileDialog1.FileName;
            //}
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

            MuxMp4Procedure procedure = new MuxMp4Procedure(workPath);
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

            MuxMp4Procedure procedure = new MuxMp4Procedure(workPath);
            procedure.GetDataFromUI(GetMuxMp4DataFromUI);
            procedure.ExecuteReplaceAudio();

        }

        #endregion MuxMp4

        #region MuxConvert

        private void MuxConvertItemListBox_MouseDown(object sender, MouseEventArgs e)
        {
            indexofsource = ((ListBox)sender).IndexFromPoint(e.X, e.Y);
            if (indexofsource != ListBox.NoMatches)
            {
                ((ListBox)sender).DoDragDrop(((ListBox)sender).Items[indexofsource].ToString(), DragDropEffects.All);
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
            indexoftarget = listbox.IndexFromPoint(listbox.PointToClient(new Point(e.X, e.Y)));
            if (indexoftarget != ListBox.NoMatches)
            {
                string temp = listbox.Items[indexoftarget].ToString();
                listbox.Items[indexoftarget] = listbox.Items[indexofsource];
                listbox.Items[indexofsource] = temp;
                listbox.SelectedIndex = indexoftarget;
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
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = DialogFilter.ALL; //"所有文件(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MuxConvertItemListBox.Items.AddRange(openFileDialog1.FileNames);
            }
            openFileDialog1.Multiselect = false;
        }

        private void MuxConvertDeleteButton_Click(object sender, EventArgs e)
        {
            if (MuxConvertItemListBox.Items.Count > 0)
            {
                if (MuxConvertItemListBox.SelectedItems.Count > 0)
                {
                    int index = MuxConvertItemListBox.SelectedIndex;
                    MuxConvertItemListBox.Items.RemoveAt(MuxConvertItemListBox.SelectedIndex);
                    if (index == MuxConvertItemListBox.Items.Count)
                    {
                        MuxConvertItemListBox.SelectedIndex = index - 1;
                    }
                    if (index >= 0 && index < MuxConvertItemListBox.Items.Count && MuxConvertItemListBox.Items.Count > 0)
                    {
                        MuxConvertItemListBox.SelectedIndex = index;
                    }
                }
            }
        }

        private void MuxConvertClearButton_Click(object sender, EventArgs e)
        {
            MuxConvertItemListBox.Items.Clear();
        }

        private void MuxConvertStartButton_Click(object sender, EventArgs e)
        {
            if (MuxConvertItemListBox.Items.Count != 0)
            {
                string ext = MuxConvertFormatComboBox.Text;
                string mux = "";
                for (int i = 0; i < MuxConvertItemListBox.Items.Count; i++)
                {
                    string filePath = MuxConvertItemListBox.Items[i].ToString();
                    //如果是源文件的格式和目标格式相同则跳过
                    if (Path.GetExtension(filePath).Contains(ext))
                        continue;
                    string finish = Path.ChangeExtension(filePath, ext);
                    aextract = "";

                    //检测音频是否需要转换为AAC
                    string audio = new MediaInfoWrapper(filePath).a_format;
                    if (audio.ToLower() != "aac" && MuxConvertFormatComboBox.Text != "mkv")
                    {
                        mux += "\"" + workPath + "\\ffmpeg.exe\" -y -i \"" + MuxConvertItemListBox.Items[i].ToString() + "\" -c:v copy -c:a " + MuxConvertAacEncoderComboBox.Text + " -strict -2 \"" + finish + "\" \r\n";
                    }
                    else
                    {
                        mux += "\"" + workPath + "\\ffmpeg.exe\" -y -i \"" + MuxConvertItemListBox.Items[i].ToString() + "\" -c copy \"" + finish + "\" \r\n";
                    }
                }
                mux += "\r\ncmd";
                batpath = workPath + "\\mux.bat";
                File.WriteAllText(batpath, mux, Encoding.Default);
                LogRecord(mux);
                Process.Start(batpath);
            }
            else MessageBoxExt.ShowErrorMessage("请输入视频！");
        }

        #endregion MuxConvert

        #endregion Mux Tab

        #region Extract Tab

        #region ExtractMkv

        private void ExtractMkvInputTextBox_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(ExtractMkvInputTextBox.Text))
            {
                extractMkvInput = ExtractMkvInputTextBox.Text;
            }
        }

        private void ExtractMkvInputTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (File.Exists(ExtractMkvInputTextBox.Text))
            {
                Process.Start(ExtractMkvInputTextBox.Text);
            }
        }

        private void ExtractMkvExtractByExternalButton_Click(object sender, EventArgs e)
        {
            string path = workPath + "\\gMKVExtractGUI.exe";
            if (File.Exists(path))
                Process.Start(path);
            else
                MessageBoxExt.ShowErrorMessage("请检查\r\n\r\n" + path + "\r\n\r\n是否存在", "未找到程序!");
        }

        private void ExtractMkvInputButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = DialogFilter.VIDEO_2; //"视频(*.mkv)|*.mkv";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                extractMkvInput = openFileDialog1.FileName;
                ExtractMkvInputTextBox.Text = extractMkvInput;
            }
        }

        private void ExtractMkvExtractTrack0Button_Click(object sender, EventArgs e)
        {
            //MKV抽0
            ExtractTrack(extractMkvInput, 0);
        }

        private void ExtractMkvExtractTrack1Button_Click(object sender, EventArgs e)
        {
            //MKV 抽1
            ExtractTrack(extractMkvInput, 1);
        }

        private void ExtractMkvExtractTrack2Button_Click(object sender, EventArgs e)
        {
            //MKV 抽2
            ExtractTrack(extractMkvInput, 2);
        }

        private void ExtractMkvExtractTrack3Button_Click(object sender, EventArgs e)
        {
            //MKV 抽3
            ExtractTrack(extractMkvInput, 3);
        }

        private void ExtractMkvExtractTrack4Button_Click(object sender, EventArgs e)
        {
            //MKV 抽4
            ExtractTrack(extractMkvInput, 4);
        }

        #endregion ExtractMkv

        #region ExtractFlv

        private void ExtractFlvInputTextBox_TextChanged(object sender, EventArgs e)
        {
            extractFlvInput = ExtractFlvInputTextBox.Text;
        }

        private void ExtractFlvExtractVideoButton_Click(object sender, EventArgs e)
        {
            //FLV vcopy
            ExtractAV(extractFlvInput, "v", 0);
            //if (namevideo8 == "")
            //{
            //    MessageBox.Show("请选择视频文件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else
            //{
            //    vextract = "\"" + workPath + "\\FLVExtractCL.exe\" -v \"" + namevideo8 + "\"";
            //    batpath = workPath + "\\vextract.bat";
            //    File.WriteAllText(batpath, vextract, Encoding.Default);
            //    LogRecord(vextract);
            //    Process.Start(batpath);
            //}
        }

        private void ExtractFlvExtractAudioButton_Click(object sender, EventArgs e)
        {
            //FLV acopy
            ExtractAV(extractFlvInput, "a", 0);
            //if (namevideo8 == "")
            //{
            //    MessageBox.Show("请选择视频文件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else
            //{
            //    aextract = "\"" + workPath + "\\FLVExtractCL.exe\" -a \"" + namevideo8 + "\"";
            //    batpath = workPath + "\\aextract.bat";
            //    File.WriteAllText(batpath, aextract, Encoding.Default);
            //    LogRecord(aextract);
            //    Process.Start(batpath);
            //}
        }

        private void ExtractFlvInputButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = DialogFilter.VIDEO_4; //"视频(*.flv;*.hlv)|*.flv;*.hlv";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                extractFlvInput = openFileDialog1.FileName;
                ExtractFlvInputTextBox.Text = extractFlvInput;
            }
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
            openFileDialog1.Filter = DialogFilter.VIDEO_5; //"视频(*.mp4)|*.mp4|所有文件(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                extractMp4VideoInput = openFileDialog1.FileName;
                ExtractMp4InputTextBox.Text = extractMp4VideoInput;
            }
        }

        private void ExtractMp4InputTextBox_TextChanged(object sender, EventArgs e)
        {
            extractMp4VideoInput = ExtractMp4InputTextBox.Text;
        }

        private void ExtractMp4ExtractAudio1Button_Click(object sender, EventArgs e)
        {
            //MP4 抽取音频1
            ExtractAV(extractMp4VideoInput, "a", 0);
            //if (namevideo == "")
            //{
            //    MessageBox.Show("请选择视频文件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else
            //{
            //    //aextract = "\"" + workPath + "\\mp4box.exe\" -raw 2 \"" + namevideo + "\"";
            //    aextract = "";
            //    aextract += Cmd.FormatPath(workPath + "\\ffmpeg.exe");
            //    aextract += " -i " + Cmd.FormatPath(namevideo);
            //    aextract += " -vn -sn -c:a:0 copy ";
            //    string outfile = Cmd.GetDir(namevideo) +
            //        Path.GetFileNameWithoutExtension(namevideo) + "_抽取音频1" + Path.GetExtension(namevideo);
            //    aextract += Cmd.FormatPath(outfile);
            //    batpath = workPath + "\\aextract.bat";
            //    File.WriteAllText(batpath, aextract, Encoding.Default);
            //    LogRecord(aextract);
            //    Process.Start(batpath);
            //}
        }

        private void ExtractMp4ExtractAudio2Button_Click(object sender, EventArgs e)
        {
            //MP4 抽取音频2
            ExtractAV(extractMp4VideoInput, "a", 1);
            //if (namevideo == "")
            //{
            //    MessageBox.Show("请选择视频文件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else
            //{
            //    //aextract = "\"" + workPath + "\\mp4box.exe\" -raw 3 \"" + namevideo + "\"";
            //    aextract = "";
            //    aextract += Cmd.FormatPath(workPath + "\\ffmpeg.exe");
            //    aextract += " -i " + Cmd.FormatPath(namevideo);
            //    aextract += " -vn -sn -c:a:1 copy ";
            //    string outfile = Cmd.GetDir(namevideo) +
            //        Path.GetFileNameWithoutExtension(namevideo) + "_抽取音频2" + Path.GetExtension(namevideo);
            //    aextract += Cmd.FormatPath(outfile);
            //    batpath = workPath + "\\aextract.bat";
            //    File.WriteAllText(batpath, aextract, Encoding.Default);
            //    LogRecord(aextract);
            //    Process.Start(batpath);
            //}
        }

        private void ExtractMp4ExtractAudio3Button_Click(object sender, EventArgs e)
        {
            //MP4 抽取音频3
            ExtractAV(extractMp4VideoInput, "a", 2);
            //if (namevideo == "")
            //{
            //    MessageBox.Show("请选择视频文件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else
            //{
            //    //aextract = "\"" + workPath + "\\mp4box.exe\" -raw 4 \"" + namevideo + "\"";
            //    aextract = "";
            //    aextract += Cmd.FormatPath(workPath + "\\ffmpeg.exe");
            //    aextract += " -i " + Cmd.FormatPath(namevideo);
            //    aextract += " -vn -sn -c:a:2 copy ";
            //    string outfile = Cmd.GetDir(namevideo) +
            //        Path.GetFileNameWithoutExtension(namevideo) + "_抽取音频3" + Path.GetExtension(namevideo);
            //    aextract += Cmd.FormatPath(outfile);
            //    batpath = workPath + "\\aextract.bat";
            //    File.WriteAllText(batpath, aextract, Encoding.Default);
            //    LogRecord(aextract);
            //    Process.Start(batpath);
            //}
        }

        private void ExtractMp4ExtractVideoButton_Click(object sender, EventArgs e)
        {
            //MP4抽取视频1
            ExtractAV(extractMp4VideoInput, "v", 0);
            //if (namevideo == "")
            //{
            //    MessageBox.Show("请选择视频文件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else
            //{
            //    //vextract = "\"" + workPath + "\\mp4box.exe\" -raw 1 \"" + namevideo + "\"";
            //    vextract = "";
            //    vextract += Cmd.FormatPath(workPath + "\\ffmpeg.exe");
            //    vextract += " -i " + Cmd.FormatPath(namevideo);
            //    vextract += " -an -sn -c:v:0 copy ";
            //    string outfile = Cmd.GetDir(namevideo) +
            //        Path.GetFileNameWithoutExtension(namevideo) + "_抽取视频1" + Path.GetExtension(namevideo);
            //    vextract += Cmd.FormatPath(outfile);
            //    batpath = workPath + "\\vextract.bat";
            //    File.WriteAllText(batpath, vextract, Encoding.Default);
            //    LogRecord(vextract);
            //    Process.Start(batpath);
            //}
        }

        #endregion ExtractMp4

        #endregion Extract Tab

        [Obsolete("Not used")]
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.sosg.net/read.php?tid=480646");
        }

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
            FeedbackForm ff = new FeedbackForm();
            ff.ShowDialog();
        }

        private void HelpReleaseDateLabel_DoubleClick(object sender, EventArgs e)
        {
            SplashForm sf = new SplashForm();
            sf.Owner = this;
            sf.Show();
        }

        #endregion Help Tab

        #region 视频页面

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
                File.Copy(VideoInputTextBox.Text, tempavspath, true);
                videoInput = tempavspath;
                VideoDemuxerComboBox.SelectedIndex = 0; //压制AVS始终使用分离器为auto
            }

            #endregion validation

            string ext = Path.GetExtension(videoOutput).ToLower();
            bool hasAudio = false;
            string inputName = Path.GetFileNameWithoutExtension(videoInput);
            string tempVideo = Path.Combine(tempfilepath, inputName + "_vtemp.mp4");
            string tempAudio = Path.Combine(tempfilepath, inputName + "_atemp" + getAudioExt());
            FileStringUtil.ensureDirectoryExists(tempfilepath);
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
                DialogResult r = MessageBoxExt.ShowQuestionWithCancel("原视频不包含音频流，音频模式是否改为无音频流？", "提示");
                if (r == DialogResult.Yes)
                    audioMode = 1;
                else if (r == DialogResult.Cancel)
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
                        tempAudio = Path.Combine(tempfilepath, inputName + "_atemp.aac");
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
                if (x264mode == 2)
                    x264 = x264bat(videoInput, tempVideo, 1, videoSubtitle) + "\r\n" +
                           x264bat(videoInput, tempVideo, 2, videoSubtitle);
                else x264 = x264bat(videoInput, tempVideo, 0, videoSubtitle);
                if (audioMode == 1)
                    x264 = x264.Replace(tempVideo, videoOutput);
            }
            else if (VideoEncoderComboBox.SelectedItem.ToString().ToLower().Contains("x265"))
            {
                tempVideo = Path.Combine(tempfilepath, inputName + "_vtemp.hevc");
                if (ext != ".mp4")
                {
                    MessageBoxExt.ShowErrorMessage("不支持的格式输出,x265当前工具箱仅支持MP4输出");
                    return;
                }
                if (x264mode == 2)
                    x264 = x265bat(videoInput, tempVideo, 1, videoSubtitle) + "\r\n" +
                           x265bat(videoInput, tempVideo, 2, videoSubtitle);
                else x264 = x265bat(videoInput, tempVideo, 0, videoSubtitle);
                if (audioMode == 1)
                {
                    x264 += "\r\n\"" + workPath + "\\mp4box.exe\" -add  \"" + tempVideo + "#trackID=1:name=\" -new \"" + Path.ChangeExtension(videoOutput, ".mp4") + "\" \r\n";
                    x264 += "del \"" + tempVideo + "\"";
                }
            }
            x264 += "\r\n";

            #endregion Video

            #region Mux

            //封装
            if (audioMode != 1)
            {
                if (ext == ".mp4")
                    mux = boxmuxbat(tempVideo, tempAudio, Path.ChangeExtension(videoOutput, ext));
                else
                    mux = ffmuxbat(tempVideo, tempAudio, Path.ChangeExtension(videoOutput, ext));
                x264 = aextract + x264 + mux + "\r\n"
                    + "del \"" + tempVideo + "\"\r\n"
                    + "del \"" + tempAudio + "\"\r\n";
            }
            x264 += "\r\necho ===== one file is completed! =====\r\n";

            #endregion Mux

            LogRecord(x264);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(GetCultureName());
            WorkingForm wf = new WorkingForm(x264);
            wf.Owner = this;
            wf.Show();
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
            x264mode = 2;

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
            x264mode = 0;
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
            x264mode = 1;
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

        private void ConfigX264PriorityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string processName = VideoEncoderComboBox.Text;
            processName = processName.Replace(".exe", "");
            Process[] processes = Process.GetProcesses();
            //if (x264PriorityComboBox.SelectedIndex == 4 || x264PriorityComboBox.SelectedIndex == 5)
            //{
            //    if (MessageBox.Show("优先级那么高的话会严重影响其他进程的运行速度，\r\n是否继续？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //    {
            //        x264PriorityComboBox.SelectedIndex = 2;
            //    }
            //}
            //遍历电脑中的进程
            for (int i = 0; i < processes.GetLength(0); i++)
            {
                //我是要找到我需要的YZT.exe的进程,可以根据ProcessName属性判断
                if (processes[i].ProcessName.Equals(processName))
                {
                    switch (ConfigX264PriorityComboBox.SelectedIndex)
                    {
                        case 0: processes[i].PriorityClass = ProcessPriorityClass.Idle; break;
                        case 1: processes[i].PriorityClass = ProcessPriorityClass.BelowNormal; break;
                        case 2: processes[i].PriorityClass = ProcessPriorityClass.Normal; break;
                        case 3: processes[i].PriorityClass = ProcessPriorityClass.AboveNormal; break;
                        case 4: processes[i].PriorityClass = ProcessPriorityClass.High; break;
                        case 5: processes[i].PriorityClass = ProcessPriorityClass.RealTime; break;
                    }
                }
            }
        }

        private void VideoInputTextBox_TextChanged(object sender, EventArgs e)
        {
            string path = VideoInputTextBox.Text;
            if (File.Exists(path))
            {
                videoInput = path;
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
                    string[] subExt = { ".ass", ".ssa", ".srt" };
                    foreach (string ext in subExt)
                    {
                        if (File.Exists(Path.ChangeExtension(videoInput, ext)))
                        {
                            VideoSubtitleTextBox.Text = Path.ChangeExtension(videoInput, ext);
                            break;
                        }
                        else
                            VideoSubtitleTextBox.Text = string.Empty;
                    }
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
            if (VideoBatchItemListbox.Items.Count > 0)
            {
                if (VideoBatchItemListbox.SelectedItems.Count > 0)
                {
                    int index = VideoBatchItemListbox.SelectedIndex;
                    VideoBatchItemListbox.Items.RemoveAt(VideoBatchItemListbox.SelectedIndex);
                    if (index == VideoBatchItemListbox.Items.Count)
                    {
                        VideoBatchItemListbox.SelectedIndex = index - 1;
                    }
                    if (index >= 0 && index < VideoBatchItemListbox.Items.Count && VideoBatchItemListbox.Items.Count > 0)
                    {
                        VideoBatchItemListbox.SelectedIndex = index;
                    }
                }
            }
        }

        private void VideoBatchAddButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = DialogFilter.ALL; //"所有文件(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                VideoBatchItemListbox.Items.AddRange(openFileDialog1.FileNames);
            }
            openFileDialog1.Multiselect = false;
        }

        #endregion 视频页面

        #region 音频界面

        private void AudioEncoderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (AudioEncoderComboBox.SelectedIndex)
            {
                case 0:
                    if (File.Exists(AudioInputTextBox.Text))
                        AudioOutputTextBox.Text = Path.ChangeExtension(AudioInputTextBox.Text, "_AAC.mp4");
                    AudioBitrateComboBox.Enabled = true;
                    AudioAudioModeBitrateRadioButton.Enabled = true;
                    AudioAudioModeCustomRadioButton.Enabled = true;
                    if (AudioAudioModeCustomRadioButton.Checked)
                    {
                        AudioPresetDeleteButton.Visible = true;
                        AudioPresetAddButton.Visible = true;
                    }
                    break;

                case 1:
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
                        AudioPresetDeleteButton.Visible = true;
                        AudioPresetAddButton.Visible = true;
                    }
                    break;

                case 2:
                    if (File.Exists(AudioInputTextBox.Text))
                        AudioOutputTextBox.Text = Path.ChangeExtension(AudioInputTextBox.Text, "_WAV.wav");
                    AudioBitrateComboBox.Enabled = false;
                    AudioAudioModeBitrateRadioButton.Enabled = false;
                    AudioAudioModeCustomRadioButton.Enabled = false;
                    AudioPresetDeleteButton.Visible = false;
                    AudioPresetAddButton.Visible = false;
                    break;

                case 3:
                    if (File.Exists(AudioInputTextBox.Text))
                        AudioOutputTextBox.Text = Path.ChangeExtension(AudioInputTextBox.Text, "_ALAC.m4a");
                    AudioBitrateComboBox.Enabled = false;
                    AudioAudioModeBitrateRadioButton.Enabled = false;
                    AudioAudioModeCustomRadioButton.Enabled = false;
                    AudioPresetDeleteButton.Visible = false;
                    AudioPresetAddButton.Visible = false;
                    break;

                case 4:
                    if (File.Exists(AudioInputTextBox.Text))
                        AudioOutputTextBox.Text = Path.ChangeExtension(AudioInputTextBox.Text, "_FLAC.flac");
                    AudioBitrateComboBox.Enabled = false;
                    AudioAudioModeBitrateRadioButton.Enabled = false;
                    AudioAudioModeCustomRadioButton.Enabled = false;
                    AudioPresetDeleteButton.Visible = false;
                    AudioPresetAddButton.Visible = false;
                    break;

                case 5:
                    if (File.Exists(AudioInputTextBox.Text))
                        AudioOutputTextBox.Text = Path.ChangeExtension(AudioInputTextBox.Text, "_AAC.m4a");
                    AudioBitrateComboBox.Enabled = true;
                    AudioAudioModeBitrateRadioButton.Enabled = true;
                    AudioAudioModeCustomRadioButton.Enabled = true;
                    if (AudioAudioModeCustomRadioButton.Checked)
                    {
                        AudioPresetDeleteButton.Visible = true;
                        AudioPresetAddButton.Visible = true;
                    }
                    break;

                case 6:
                    if (File.Exists(AudioInputTextBox.Text))
                        AudioOutputTextBox.Text = Path.ChangeExtension(AudioInputTextBox.Text, "_AC3.ac3");
                    AudioBitrateComboBox.Enabled = true;
                    AudioAudioModeBitrateRadioButton.Enabled = true;
                    AudioAudioModeCustomRadioButton.Enabled = false;
                    AudioPresetDeleteButton.Visible = false;
                    AudioPresetAddButton.Visible = false;
                    break;

                case 7:
                    if (File.Exists(AudioInputTextBox.Text))
                        AudioOutputTextBox.Text = Path.ChangeExtension(AudioInputTextBox.Text, "_MP3.mp3");
                    AudioBitrateComboBox.Enabled = true;
                    AudioAudioModeBitrateRadioButton.Enabled = true;
                    AudioAudioModeCustomRadioButton.Enabled = true;
                    AudioPresetDeleteButton.Visible = false;
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
            indexoftarget = listbox.IndexFromPoint(listbox.PointToClient(new Point(e.X, e.Y)));
            if (indexoftarget != ListBox.NoMatches)
            {
                string temp = listbox.Items[indexoftarget].ToString();
                listbox.Items[indexoftarget] = listbox.Items[indexofsource];
                listbox.Items[indexofsource] = temp;
                listbox.SelectedIndex = indexoftarget;
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
            indexofsource = ((ListBox)sender).IndexFromPoint(e.X, e.Y);
            if (indexofsource != ListBox.NoMatches)
            {
                ((ListBox)sender).DoDragDrop(((ListBox)sender).Items[indexofsource].ToString(), DragDropEffects.All);
            }
        }

        private void AudioBatchStartButton_Click(object sender, EventArgs e)
        {
            if (AudioBatchItemListBox.Items.Count != 0)
            {
                string finish, outputExt, codec;
                aac = "";
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
                batpath = workPath + "\\aac.bat";
                File.WriteAllText(batpath, aac, Encoding.Default);
                LogRecord(aac);
                Process.Start(batpath);
            }
            else MessageBoxExt.ShowErrorMessage("请输入文件！");
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
                batpath = workPath + "\\aac.bat";
                File.WriteAllText(batpath, audiobat(audioInput, audioOutput), Encoding.Default);
                LogRecord(audiobat(audioInput, audioOutput));
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
            AudioBitrateLabel.Visible = false;
            AudioKbpsLabel.Visible = false;
            AudioBitrateComboBox.Visible = false;
            AudioCustomParameterTextBox.Visible = true;
            AudioPresetLabel.Visible = true;
            AudioPresetComboBox.Visible = true;
            AudioPresetDeleteButton.Visible = true;
            AudioPresetAddButton.Visible = true;
        }

        private void AudioAudioModeBitrateRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            AudioBitrateLabel.Visible = true;
            AudioKbpsLabel.Visible = true;
            AudioBitrateComboBox.Visible = true;
            AudioCustomParameterTextBox.Visible = false;
            AudioPresetLabel.Visible = false;
            AudioPresetComboBox.Visible = false;
            AudioPresetDeleteButton.Visible = false;
            AudioPresetAddButton.Visible = false;
        }

        private void AudioBatchAddButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = DialogFilter.ALL; //"所有文件(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                AudioBatchItemListBox.Items.AddRange(openFileDialog1.FileNames);
            }
            openFileDialog1.Multiselect = false;
        }

        private void AudioBatchDeleteButton_Click(object sender, EventArgs e)
        {
            if (AudioBatchItemListBox.Items.Count > 0)
            {
                if (AudioBatchItemListBox.SelectedItems.Count > 0)
                {
                    int index = AudioBatchItemListBox.SelectedIndex;
                    AudioBatchItemListBox.Items.RemoveAt(AudioBatchItemListBox.SelectedIndex);
                    if (index == AudioBatchItemListBox.Items.Count)
                    {
                        AudioBatchItemListBox.SelectedIndex = index - 1;
                    }
                    if (index >= 0 && index < AudioBatchItemListBox.Items.Count && AudioBatchItemListBox.Items.Count > 0)
                    {
                        AudioBatchItemListBox.SelectedIndex = index;
                    }
                }
            }
        }

        private void AudioBatchClearButton_Click(object sender, EventArgs e)
        {
            AudioBatchItemListBox.Items.Clear();
        }

        #endregion 音频界面

        #region Avs Tab

        private void AvsPreviewButton_Click(object sender, EventArgs e)
        {
            if (AvsScriptTextBox.Text != "")
            {
                string filepath = workPath + "\\temp.avs";
                File.WriteAllText(filepath, AvsScriptTextBox.Text, Encoding.Default);
                if (File.Exists(ConfigFunctionVideoPlayerTextBox.Text))
                {
                    Process.Start(ConfigFunctionVideoPlayerTextBox.Text, filepath);
                }
                else
                {
                    string ffplayer = Path.Combine(workPath, "ffplay.exe");
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
                avsVideoInput = AvsVideoInputTextBox.Text;
                string finish = avsVideoInput.Remove(avsVideoInput.LastIndexOf("."));
                finish += "_AVS压制.mp4";
                AvsOutputTextBox.Text = finish;
                GenerateAVS();
            }
            //if (txtvideo9.Text != "")
            //{
            //    if (txtAVS.Text != "")
            //    {
            //        txtAVS.Text = txtAVS.Text.Replace(prevideo9, txtvideo9.Text);
            //    }
            //    else
            //    {
            //        DirectoryInfo TheFolder = new DirectoryInfo("avsfilter");
            //        foreach (FileInfo FileName in TheFolder.GetFiles())
            //        {
            //            avs += "LoadPlugin(\"" + workpath + "\\avsfilter\\" + FileName + "\")\r\n";
            //        }
            //        avs += "\r\nDirectShowSource(\"" + namevideo9 + "\",23.976,convertFPS=True)\r\nConvertToYV12()\r\n" + "TextSub(\"" + namesub9 + "\")\r\n";
            //        txtAVS.Text = avs;
            //        avs = "";
            //    }
            //    prevideo9 = txtvideo9.Text;
            //}
        }

        private void AvsSubtitleInputTextBox_TextChanged(object sender, EventArgs e)
        {
            avsSubtitleInput = AvsSubtitleInputTextBox.Text;
            GenerateAVS();
            //if (txtAVS.Text != "")
            //{
            //    txtAVS.Text=txtAVS.Text.Replace(namesub9, txtsub9.Text);
            //    namesub9 = txtsub9.Text;
            //}
            //else
            //{
            //    namesub9 = txtsub9.Text;
            //    DirectoryInfo TheFolder = new DirectoryInfo("avsfilter");
            //    foreach (FileInfo FileName in TheFolder.GetFiles())
            //    {
            //        avs += "LoadPlugin(\"" + workpath + "\\avsfilter\\" + FileName + "\")\r\n";
            //    }
            //    avs += "\r\nDirectShowSource(\"" + namevideo9 + "\",23.976,convertFPS=True)\r\nConvertToYV12()\r\n" + "TextSub(\"" + namesub9 + "\")\r\n";
            //    txtAVS.Text = avs;
            //    avs = "";
            //}
        }

        private void AvsOutputTextBox_TextChanged(object sender, EventArgs e)
        {
            avsOutput = AvsOutputTextBox.Text;
        }

        private void AvsStartButton_Click(object sender, EventArgs e)
        {
            VideoDemuxerComboBox.SelectedIndex = 0; //压制AVS始终使用分离器为auto

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

            string inputName = Path.GetFileNameWithoutExtension(avsVideoInput);
            string tempVideo = Path.Combine(tempfilepath, inputName + "_vtemp.mp4");
            string tempAudio = Path.Combine(tempfilepath, inputName + "_atemp" + getAudioExt());
            FileStringUtil.ensureDirectoryExists(tempfilepath);
            // 避免编码失败最后混流使用上次的同名临时文件造成编码成功的假象
            if (File.Exists(tempVideo)) File.Delete(tempVideo);
            if (File.Exists(tempAudio)) File.Delete(tempAudio);

            string filepath = tempavspath;
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
                if (x264mode == 2)
                    x264 = x264bat(filepath, tempVideo, 1) + "\r\n" +
                           x264bat(filepath, tempVideo, 2);
                else x264 = x264bat(filepath, tempVideo);
                if (!AvsIncludeAudioCheckBox.Checked || !hasAudio)
                    x264 = x264.Replace(tempVideo, avsOutput);
            }
            else if (VideoEncoderComboBox.SelectedItem.ToString().ToLower().Contains("x265"))
            {
                tempVideo = Path.Combine(tempfilepath, inputName + "_vtemp.hevc");
                if (x264mode == 2)
                    x264 = x265bat(filepath, tempVideo, 1) + "\r\n" +
                           x265bat(filepath, tempVideo, 2);
                else x264 = x265bat(filepath, tempVideo);
                if (!AvsIncludeAudioCheckBox.Checked || !hasAudio)
                {
                    x264 += "\r\n\"" + workPath + "\\mp4box.exe\"  -add  \"" + tempVideo + "#trackID=1:name=\" -new \"" + avsOutput + "\" \r\n";
                    x264 += "del \"" + tempVideo + "\"";
                }
            }
            //mux
            if (AvsIncludeAudioCheckBox.Checked && hasAudio) //如果包含音频
                mux = boxmuxbat(tempVideo, tempAudio, avsOutput);
            else
                mux = string.Empty;

            auto = aextract + x264 + "\r\n" + mux + " \r\n";
            auto += "\r\necho ===== one file is completed! =====\r\n";
            LogRecord(auto);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(GetCultureName());
            WorkingForm wf = new WorkingForm(auto);
            wf.Owner = this;
            wf.Show();
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
                AvsOutputTextBox.Text = avsOutput = savefile.FileName;
            }
        }

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
            avs += "LoadPlugin(\"avs\\plugins\\VSFilter.DLL\")\r\n";
            avs += string.Format("\r\nLWLibavVideoSource(\"{0}\",23.976,convertFPS=True)\r\nConvertToYV12()\r\nCrop(0,0,0,0)\r\nAddBorders(0,0,0,0)\r\n" + "TextSub(\"{1}\")\r\n#LanczosResize(1280,960)\r\n", avsVideoInput, avsSubtitleInput);
            //avs += "\r\nDirectShowSource(\"" + namevideo9 + "\",23.976,convertFPS=True)\r\nConvertToYV12()\r\nCrop(0,0,0,0)\r\nAddBorders(0,0,0,0)\r\n" + "TextSub(\"" + namesub9 + "\")\r\n#LanczosResize(1280,960)\r\n";
            AvsScriptTextBox.Text = avs;
            avs = "";
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
            openFileDialog1.Filter = DialogFilter.SUBTITLE_2; //"字幕(*.ass;*.ssa;*.srt;*.idx;*.sup)|*.ass;*.ssa;*.srt;*.idx;*.sup|所有文件(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                avsSubtitleInput = openFileDialog1.FileName;
                AvsSubtitleInputTextBox.Text = avsSubtitleInput;
            }
        }

        private void AvsVideoInputButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = DialogFilter.VIDEO_7; //"视频(*.mp4;*.flv;*.mkv;*.wmv)|*.mp4;*.flv;*.mkv;*.wmv|所有文件(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                avsVideoInput = openFileDialog1.FileName;
                AvsVideoInputTextBox.Text = avsVideoInput;
            }
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
            string vsfilterDLLPath = Path.Combine(workPath, @"avs\plugins\" + AvsFilterComboBox.Text);
            string text = "LoadPlugin(\"" + vsfilterDLLPath + "\")" + "\r\n";
            AvsScriptTextBox.Text = text + AvsScriptTextBox.Text;
        }

        private void AvsScriptTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBoxSelectAll(sender, e);
        }

        private void GenerateAVS()
        {
            avsBuilder.Remove(0, avsBuilder.Length);
            string vsfilterDLLPath = Path.Combine(workPath, @"avs\plugins\VSFilter.DLL");
            string SupTitleDLLPath = Path.Combine(workPath, @"avs\plugins\SupTitle.dll");
            string LSMASHSourceDLLPath = Path.Combine(workPath, @"avs\plugins\LSMASHSource.DLL");
            string undotDLLPath = Path.Combine(workPath, @"avs\plugins\UnDot.DLL");
            string extInput = Path.GetExtension(avsVideoInput).ToLower();
            avsBuilder.AppendLine("LoadPlugin(\"" + LSMASHSourceDLLPath + "\")");
            if (Path.GetExtension(avsSubtitleInput).ToLower() == ".sup")
                avsBuilder.AppendLine("LoadPlugin(\"" + SupTitleDLLPath + "\")");
            else
                avsBuilder.AppendLine("LoadPlugin(\"" + vsfilterDLLPath + "\")");
            if (AvsUndotCheckBox.Checked)
                avsBuilder.AppendLine("LoadPlugin(\"" + undotDLLPath + "\")");
            if (extInput == ".mp4"
                   || extInput == ".mov"
                   || extInput == ".qt"
                   || extInput == ".3gp"
                   || extInput == ".3g2")
                avsBuilder.AppendLine("LSMASHVideoSource(\"" + avsVideoInput + "\",format=\"YUV420P8\")");
            else
                avsBuilder.AppendLine("LWLibavVideoSource(\"" + avsVideoInput + "\",format=\"YUV420P8\")");
            avsBuilder.AppendLine("ConvertToYV12()");
            if (AvsUndotCheckBox.Checked)
                avsBuilder.AppendLine("Undot()");
            if (AvsTweakCheckBox.Checked)
                avsBuilder.AppendLine("Tweak(" + AvsTweakChromaNumericUpDown.Value.ToString() + ", " + AvsTweakSaturationNumericUpDown.Value.ToString() + ", " + AvsTweakBrightnessNumericUpDown.Value.ToString() + ", " + AvsTweakContrastNumericUpDown.Value.ToString() + ")");
            if (AvsLevelsCheckBox.Checked)
                avsBuilder.AppendLine("Levels(0," + AvsLevelsNumericUpDown.Value.ToString() + ",255,0,255)");
            if (AvsLanczosResizeCheckBox.Checked)
                avsBuilder.AppendLine("LanczosResize(" + AvsLanczosResizeWidthNumericUpDown.Value.ToString() + "," + AvsLanczosResizeHeightNumericUpDown.Value.ToString() + ")");
            if (AvsSharpenCheckBox.Checked)
                avsBuilder.AppendLine("Sharpen(" + AvsSharpenNumericUpDown.Value.ToString() + ")");
            if (AvsCropCheckBox.Checked)
                avsBuilder.AppendLine("Crop(" + AvsCropTextBox.Text + ")");
            if (AvsAddBordersCheckBox.Checked)
                avsBuilder.AppendLine("AddBorders(" + AvsAddBordersLeftNumericUpDown.Value.ToString() + "," + AvsAddBordersTopNumericUpDown.Value.ToString() + "," + AvsAddBordersRightNumericUpDown.Value.ToString() + "," + AvsAddBordersBottomNumericUpDown.Value.ToString() + ")");
            if (!string.IsNullOrEmpty(AvsSubtitleInputTextBox.Text))
            {
                if (Path.GetExtension(avsSubtitleInput).ToLower() == ".idx")
                    avsBuilder.AppendLine("vobsub(\"" + avsSubtitleInput + "\")");
                else if (Path.GetExtension(avsSubtitleInput).ToLower() == ".sup")
                    avsBuilder.AppendLine("SupTitle(\"" + avsSubtitleInput + "\")");
                else
                    avsBuilder.AppendLine("TextSub(\"" + avsSubtitleInput + "\")");
            }
            if (AvsTrimCheckBox.Checked)
                avsBuilder.AppendLine("Trim(" + AvsTrimStartNumericUpDown.Value.ToString() + "," + AvsTrimEndNumericUpDown.Value.ToString() + ")");
            AvsScriptTextBox.Text = avsBuilder.ToString();
        }

        #region 更改AVS

        private void AvsTweakCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void AvsLanczosResizeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void AvsAddBordersCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void AvsCropCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void AvsTrimCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void AvsLevelsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void AvsSharpenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void AvsUndotCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void AvsTweakChromaNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void AvsTweakSaturationNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void AvsTweakBrightnessNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void AvsTweakContrastNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void AvsLanczosResizeWidthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void AvsLanczosResizeHeightNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void AvsAddBordersLeftNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void AvsAddBordersTopNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void AvsAddBordersRightNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void AvsAddBordersBottomNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void AvsCropTextBox_TextChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void AvsTrimStartNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void AvsTrimEndNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void AvsLevelsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void AvsSharpenNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        #endregion 更改AVS

        #endregion Avs Tab

        #region Log

        public void Log(string path)
        {
            ProcessStartInfo start = new ProcessStartInfo(path);//设置运行的命令行文件问ping.exe文件，这个文件系统会自己找到
            //如果是其它exe文件，则有可能需要指定详细路径，如运行winRar.exe
            start.CreateNoWindow = false;//不显示dos命令行窗口
            start.RedirectStandardOutput = true;//
            start.RedirectStandardInput = true;//
            start.UseShellExecute = false;//是否指定操作系统外壳进程启动程序
            Process p = Process.Start(start);
            StreamReader reader = p.StandardOutput;//截取输出流
            string line = reader.ReadLine();//每次读取一行
            StringBuilder log = new StringBuilder(2000);
            while (!reader.EndOfStream)
            {
                log.Append(line + "\r\n");
                line = reader.ReadLine();
            }
            p.WaitForExit();//等待程序执行完退出进程
            File.WriteAllText(startpath + "\\log.txt", log.ToString(), Encoding.Default);
            p.Close();//关闭进程
            reader.Close();//关闭流
        }

        public void LogRecord(string log)
        {
            FileStringUtil.ensureDirectoryExists(logPath);
            File.AppendAllText(logFileName,
                "===========" + DateTime.Now.ToString() + "===========\r\n" + log + "\r\n\r\n", Encoding.Default);
        }

        #endregion Log

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
                    if (File.Exists(startpath + "\\help.rtf"))
                    {
                        HelpContentRichTextBox.LoadFile(startpath + "\\help.rtf");
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
                    if (File.Exists(startpath + "\\help_zh_tw.rtf"))
                    {
                        HelpContentRichTextBox.LoadFile(startpath + "\\help_zh_tw.rtf");
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
                    if (File.Exists(startpath + "\\help.rtf"))
                    {
                        HelpContentRichTextBox.LoadFile(startpath + "\\help.rtf");
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
                    if (File.Exists(startpath + "\\help.rtf"))
                    {
                        HelpContentRichTextBox.LoadFile(startpath + "\\help.rtf");
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

        public static void RunProcess(string exe, string arg)
        {
            Thread thread = new Thread(() =>
            {
                ProcessStartInfo psi = new ProcessStartInfo(exe, arg);
                psi.CreateNoWindow = true;
                Process p = new Process();
                p.StartInfo = psi;
                p.Start();
                p.WaitForExit();
                MessageBox.Show("ts");
                p.Close();
            });
            thread.IsBackground = true;
            thread.Start();
        }

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
            new OpenFileDialog()
                .Prepare(DialogFilter.IMAGE, MiscOnePicInputTextBox.Text)
                .ShowDialogExt(MiscOnePicInputTextBox);

            //openFileDialog1.Filter = DialogFilter.IMAGE; //"图片(*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif|所有文件(*.*)|*.*";
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    MiscOnePicInputTextBox.Text = openFileDialog1.FileName;
            //}
        }

        private void MiscOnePicAudioInputButton_Click(object sender, EventArgs e)
        {
            new OpenFileDialog()
                .Prepare(DialogFilter.AUDIO_2, MiscOnePicAudioInputTextBox.Text)
                .ShowDialogExt(MiscOnePicAudioInputTextBox);

            //openFileDialog1.Filter = DialogFilter.AUDIO_2; //"音频(*.aac;*.mp3;*.mp4;*.wav)|*.aac;*.mp3;*.mp4;*.wav|所有文件(*.*)|*.*";
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    MiscOnePicAudioInputTextBox.Text = openFileDialog1.FileName;
            //}
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
                OnePicProcedure procedure = new OnePicProcedure(tempPic, workPath);
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
            new OpenFileDialog()
                .Prepare(DialogFilter.VIDEO_6, MiscMiscVideoInputTextBox.Text)
                .ShowDialogExt(MiscMiscVideoInputTextBox);

            //openFileDialog1.Filter = DialogFilter.VIDEO_6; //"视频(*.mp4;*.flv;*.mkv)|*.mp4;*.flv;*.mkv|所有文件(*.*)|*.*";
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    MiscMiscVideoInputTextBox.Text = openFileDialog1.FileName;
            //}
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
                MiscProcedure miscProcedure = new MiscProcedure(workPath);
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
                MiscProcedure miscProcedure = new MiscProcedure(workPath);
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
            new OpenFileDialog()
                .Prepare(DialogFilter.VIDEO_D_1, MiscBlackVideoInputTextBox.Text)
                .ShowDialogExt(MiscBlackVideoInputTextBox);

            //openFileDialog1.Filter = DialogFilter.VIDEO_D_1; //"FLV视频(*.flv)|*.flv";
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    MiscBlackVideoInputTextBox.Text = openFileDialog1.FileName;
            //}
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
            new OpenFileDialog()
                .Prepare(DialogFilter.IMAGE, MiscBlackPicInputTextBox.Text)
                .ShowDialogExt(MiscBlackPicInputTextBox);

            //openFileDialog1.Filter = DialogFilter.IMAGE; //"图片(*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif|所有文件(*.*)|*.*";
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    MiscBlackPicInputTextBox.Text = openFileDialog1.FileName;
            //}
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

            BlackProcedure blackProcedure = new BlackProcedure(tempPic, workPath);
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
            trayMode = ConfigUiTrayModeCheckBox.Checked;
        }
        private void ConfigFunctionRestoreDefaultButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBoxExt.ShowQuestion(string.Format("是否将所有界面参数恢复到默认设置？"), "提示");
            if (result == DialogResult.Yes)
            {
                ResetParameters();
                MessageBoxExt.ShowInfoMessage("恢复默认设置完成！");
            }
        }
        private void ConfigFunctionDeleteLogButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(logPath))
            {
                Directory.Delete(logPath, true);
                MessageBoxExt.ShowInfoMessage("已经删除日志文件。");
            }
            else MessageBoxExt.ShowInfoMessage("没有找到日志文件。");
        }

        private void ConfigFunctionViewLogButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(logFileName))
            {
                Process.Start(logFileName);
            }
            else MessageBoxExt.ShowInfoMessage("没有找到日志文件。");
        }
        private void ConfigFunctionVideoPlayerButton_Click(object sender, EventArgs e)
        {
            new OpenFileDialog()
                .Prepare(DialogFilter.PROGRAM, ConfigFunctionVideoPlayerTextBox.Text)
                .ShowDialogExt(ConfigFunctionVideoPlayerTextBox);

            //openFileDialog1.Filter = DialogFilter.PROGRAM; //"程序(*.exe)|*.exe|所有文件(*.*)|*.*";
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    ConfigFunctionVideoPlayerTextBox.Text = openFileDialog1.FileName;
            //}
        }
        private void ConfigFunctionEnableX265CheckBox_Click(object sender, EventArgs e)
        {
            if (MessageBoxExt.ShowQuestion("你必须重新启动小丸工具箱才能使设置的生效 是否现在重新启动？", "需要重新启动") == DialogResult.Yes)
                Application.Restart();
        }

        #endregion Config Tab

        private void VideoCustomParameterTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBoxSelectAll(sender, e);
        }

        //Ctrl+A 可以全选文本
        private void TextBoxSelectAll(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
                ((TextBoxBase)sender).SelectAll();  // using TextBoxBase to include TextBox, RichTextBox and MaskedTextBox
        }

        #region MediaInfo Tab

        public string GetMediaInfoString(string mediaFileName)
        {
            try
            {
                return new MediaInfoWrapper(mediaFileName).ToString();
            }
            catch (FileNotFoundException ex)
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
            openFileDialog1.Filter = DialogFilter.VIDEO_6; //"视频(*.mp4;*.flv;*.mkv)|*.mp4;*.flv;*.mkv|所有文件(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                mediaInfoFile = openFileDialog1.FileName;
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
                            FormUpdater formUpdater = new FormUpdater(startpath, NewDate.ToString());
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
            NewDate = DateTime.Parse("1990-03-08");
            isFullUpdate = false;
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
                            FormUpdater formUpdater = new FormUpdater(startpath, date);
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

        private void VideoAutoShutdownCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            shutdownState = VideoAutoShutdownCheckBox.Checked;
        }

        private void VideoGoToAudioLabel_Click(object sender, EventArgs e)
        {
            MainTabControl.SelectedIndex = 1;
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
            ffmpeg = "";
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
                ffmpeg = "\"" + workPath + "\\ffmpeg.exe\" -f concat  -i concat.txt -y -c copy " + finish;
            }
            ffmpeg += "\r\ncmd";
            batpath = workPath + "\\concat.bat";
            File.WriteAllText(batpath, ffmpeg, Encoding.Default);
            LogRecord(aac);
            Process.Start(batpath);
        }

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

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Keys.D0 = 48, Keys.D1 = 49, ... , Keys.D9 = 57
            // The following code uses number key 1 to 9, and 0 is still available for furture use.
            if (e.Modifiers == Keys.Control && Keys.D1 <= e.KeyCode && e.KeyCode <= Keys.D9)
            {
                MainTabControl.SelectedIndex = e.KeyCode - Keys.D1;
            }
        }

        #endregion TabControl

        private void VideoSubtitleTextBox_DoubleClick(object sender, EventArgs e)
        {
            VideoSubtitleTextBox.Clear();
        }

        private void AudioPresetComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            XElement x = preset.GetAudioPreset(AudioEncoderComboBox.Text).Elements()
                             .Where(_ => _.Attribute("Name").Value == AudioPresetComboBox.Text).First();
            AudioCustomParameterTextBox.Text = x.Value;
        }

        private void VideoBatchItemListbox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= 65535)
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
    }
}