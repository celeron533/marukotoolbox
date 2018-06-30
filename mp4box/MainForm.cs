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
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using static mp4box.DialogUtil;

namespace mp4box
{
    public partial class MainForm : Form
    {
        static Logger logger = LogManager.GetCurrentClassLogger();

        private Preset.Preset preset;
        Settings settings = Global.Running.settings;

        #region Private Members Declaration

        private int sourceIndex;    // used for ListBox Drag & Drop
        private int targetIndex;    // used for ListBox Drag & Drop

        private X264Mode x264mode = X264Mode.Crf;

        private string audioInput = "";
        private string audioOutput;
        private string videoInput = "";
        private string videoOutput;
        private string videoSubtitle = "";

        private string x264;
        private string aextract;

        #endregion Private Members Declaration

        public MainForm()
        {
            Global.Running.logFileName = ((NLog.Targets.FileTarget)LogManager.Configuration.FindTargetByName("f")).FileName.Render(null);
            preset = Preset.Preset.Load();
            //settings = new Settings();
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo toolsFolder = new DirectoryInfo(ToolsUtil.ToolsFolder);
                if (!toolsFolder.Exists)
                {
                    throw new ToolsDirectoryNotFoundException();
                }

                // load x264, x265 list
                bool useX265 = settings.ConfigFunctionEnableX265Check;
                IEnumerable<FileInfo> x264exe = toolsFolder.GetFiles("*.exe")
                    .Where(fileInfo =>
                    {
                        string fileName = fileInfo.Name.ToLower();
                        return fileName.Contains("x264") || (useX265 && fileName.Contains("x265"));
                    });
                VideoEncoderComboBox.Items.AddRange(x264exe.Select(file => file.Name).ToArray());

                // Manipulate AviSynth.dll and DevIL.dll file
                // TODO: is it necessary?
                AvsUtil.ManipulateAVSFiles();

                // Load avs plugin list
                DirectoryInfo avsPluginFolder = new DirectoryInfo(ToolsUtil.AvsPluginFolder);
                if (avsPluginFolder.Exists)
                {
                    IEnumerable<FileInfo> avsfilters = avsPluginFolder.GetFiles("*.dll");
                    AvsFilterComboBox.Items.AddRange(avsfilters.Select(fileInfo => fileInfo.Name).ToArray());
                }
            }
            catch (ToolsDirectoryNotFoundException)
            {
                logger.Error("Tools folder not found.");
                MessageBox.Show("tools文件夹没有解压喔~ 工具箱里没有工具的话运行不起来的喔~", "（这只丸子）",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBoxExt.ShowWarningMessage(ex.Message);
            }

            LoadSettings();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (settings.ConfigFunctionDeleteTempFileCheck)
                DeleteTempFiles();

            SaveSettings();
        }

        /// <summary>
        /// Delete temporary and intermediate files 
        /// </summary>
        /// <returns>False: do not need to delete files now.</returns>
        private bool DeleteTempFiles()
        {
            string fileName = System.Reflection.Assembly.GetExecutingAssembly().Location;
            Process[] processes = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);

            // If there are other running instances, abort
            if (processes.Count(p => p.MainModule.FileName == fileName) > 1)
                return false;

            List<string> deleteFileList = new List<string>();

            if (Directory.Exists(Global.Running.tempFolder))
                deleteFileList.AddRange(Directory.GetFiles(Global.Running.tempFolder));

            string[] deletedfiles = { "concat.txt", Global.Running.tempAvsFile, Global.Running.tempImgFile };
            deleteFileList.AddRange(deletedfiles);

            string[] batFiles = Directory.GetFiles(ToolsUtil.ToolsFolder, "*.bat");
            deleteFileList.AddRange(batFiles);

            deleteFileList.ForEach(f => File.Delete(f));
            return true;
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




        public XvSettings GetXvSettings()
        {
            var xvs = new XvSettings();
            xvs.CrfValue = VideoCrfNumericUpDown.Value;
            xvs.ExtParameter = settings.ConfigX264ExtraParameterText;
            xvs.CustomParameter = VideoCustomParameterTextBox.Text;
            xvs.V_width = (int)VideoWidthNumericUpDown.Value;
            xvs.V_height = (int)VideoHeightNumericUpDown.Value;
            xvs.X26xThreads = settings.ConfigX264Threads;
            xvs.X26xDemuxer = VideoDemuxerComboBox.Text;
            xvs.X26xBitrate = (int)VideoBitrateNumericUpDown.Value;
            xvs.X26xSeek = (int)VideoSeekNumericUpDown.Value;
            xvs.X26xFrames = (int)VideoFramesNumericUpDown.Value;
            xvs.IsResizeChecked = VideoMaintainResolutionCheckBox.Checked;
            return xvs;
        }

        public string X264bat(string input, string output, int pass = 1, string sub = "")
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
                if (xvs.X26xThreads != 0)
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

        public string X265bat(string input, string output, int pass = 1, string sub = "")
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


        public string AudioBat(string input, string output)
        {
            // Use enum instead of bool
            AudioMode audioMode = AudioAudioModeBitrateRadioButton.Checked ? AudioMode.Bitrate : AudioMode.Custom;
            AudioEncoderType audioEncoder = (AudioEncoderType)AudioEncoderComboBox.SelectedIndex;
            string audioBitrate = AudioBitrateComboBox.Text;
            string audioCustomParam = AudioCustomParameterTextBox.Text;

            return Shared.AudioBat(input, output, audioMode, audioEncoder, audioBitrate, audioCustomParam);
        }

        /// <summary>
        /// Get the new extension of audio file based on selected audio encoder.
        /// </summary>
        /// <returns></returns>
        private string GetAudioExt()
        {
            return GenerateAudioOutputExt((AudioEncoderType)AudioEncoderComboBox.SelectedIndex, ".{1}");
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
                string aextract = Shared.ExtractAV(out ext, namevideo, av, streamIndex);
            }
            catch (Exception e)
            {
                MessageBoxExt.ShowInfoMessage(e.Message);
                return;
            }

            string suf = (av == MediaType.Audio ? "_audio_" : "_video_");

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
                string aextract = Shared.ExtractAV(out ext, namevideo, MediaType.Audio, streamIndex);
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
                             FormatExtractUtil.Extract(namevideo)[streamIndex].Format);
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
        public void ResetUIFieldParameters()
        {
            AudioAudioModeBitrateRadioButton.Checked = true;
            AudioBitrateComboBox.Text = "128";
            AudioEncoderComboBox.SelectedIndex = 0;
            AudioPresetComboBox.SelectedIndex = 0;

            AvsIncludeAudioCheckBox.Checked = false;

            //ConfigFunctionAutoCheckUpdateCheckBox.Checked = true;
            //ConfigFunctionDeleteTempFileCheckBox.Checked = true;
            //ConfigFunctionEnableX265CheckBox.Checked = false;
            //ConfigUiSplashScreenCheckBox.Checked = true;
            //ConfigUiTrayModeCheckBox.Checked = false;
            //ConfigX264PriorityComboBox.SelectedIndex = 2;
            //ConfigX264PriorityComboBox.SelectedIndex = 2;
            //ConfigX264ThreadsComboBox.SelectedIndex = 0;

            //MiscMiscBeginTimeMaskedTextBox.Text = "000000";
            //MiscMiscEndTimeMaskedTextBox.Text = "000020";
            //MiscMiscTransposeComboBox.SelectedIndex = 1;
            //MiscOnePicBitrateNumericUpDown.Value = 128;
            //MiscOnePicCrfNumericUpDown.Value = 24;
            //MiscOnePicFpsNumericUpDown.Value = 1;

            //MuxConvertAacEncoderComboBox.SelectedIndex = 0;
            //MuxConvertFormatComboBox.Text = "flv";
            //MuxMp4FpsComboBox.SelectedIndex = 0;
            //MuxMp4ParComboBox.SelectedIndex = 0;

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
            //load settings
            settings.Load();

            AudioBitrateComboBox.Text = settings.AudioBitrateComboText;
            AudioEncoderComboBox.SelectedIndex = settings.AudioEncoderIndex;
            AvsScriptTextBox.Text = settings.AvsScriptText;
            //ConfigFunctionAutoCheckUpdateCheckBox.Checked = settings.ConfigFunctionAutoCheckUpdateCheck;
            //ConfigFunctionDeleteTempFileCheckBox.Checked = settings.ConfigFunctionDeleteTempFileCheck;
            //ConfigFunctionEnableX265CheckBox.Checked = settings.ConfigFunctionEnableX265Check;
            //ConfigFunctionVideoPlayerTextBox.Text = settings.ConfigFunctionVideoPlayerText;
            //ConfigUiSplashScreenCheckBox.Checked = settings.ConfigUiSplashScreenCheck;
            //ConfigUiTrayModeCheckBox.Checked = settings.ConfigUiTrayModeCheck;
            //ConfigX264ExtraParameterTextBox.Text = settings.ConfigX264ExtraParameterText;
            //ConfigX264PriorityComboBox.SelectedIndex = settings.ConfigX264PriorityIndex;
            //ConfigX264ThreadsComboBox.SelectedIndex = settings.ConfigX264Threads;
            //MiscOnePicBitrateNumericUpDown.Value = settings.MiscOnePicBitrateValue;
            //MiscOnePicCrfNumericUpDown.Value = settings.MiscOnePicCrfValue;
            //MiscOnePicFpsNumericUpDown.Value = settings.MiscOnePicFpsValue;
            //MuxConvertFormatComboBox.SelectedIndex = settings.MuxConvertFormatIndex;
            VideoAudioModeComboBox.SelectedIndex = settings.VideoAudioModeIndex;
            VideoAudioParameterTextBox.Text = settings.VideoAudioParameterText;
            VideoBatchSubtitleLanguage.DataSource = settings.VideoBatchSubtitleLanguage.Split(',');
            VideoBitrateNumericUpDown.Value = settings.VideoBitrateValue;
            VideoCrfNumericUpDown.Value = settings.VideoCrfValue;
            VideoCustomParameterTextBox.Text = settings.VideoCustomParameterText;
            VideoDemuxerComboBox.SelectedIndex = settings.VideoDemuxerIndex;
            VideoHeightNumericUpDown.Value = settings.VideoHeightValue;
            VideoWidthNumericUpDown.Value = settings.VideoWidthValue;

            if (settings.VideoEncoderIndex > VideoEncoderComboBox.Items.Count - 1)
            {
                VideoEncoderComboBox.SelectedIndex = 0;
            }
            else
            {
                VideoEncoderComboBox.SelectedIndex = settings.VideoEncoderIndex;
            }
            if (VideoEncoderComboBox.SelectedIndex == -1)  //First Startup
            {
                VideoEncoderComboBox.SelectedIndex = VideoEncoderComboBox.Items.IndexOf(ToolsUtil.X264_32_8.fileName);//"x264_32-8bit"
            }
            VideoEncoderComboBox_SelectedIndexChanged(null, null);

            //if (settings.ConfigUiLanguageIndex == -1)  //First Startup
            //{
            //    string culture = Thread.CurrentThread.CurrentCulture.Name;
            //    switch (culture)
            //    {
            //        case "zh-CN":
            //        case "zh-SG":
            //            ConfigUiLanguageComboBox.SelectedIndex = 0;
            //            break;

            //        case "zh-TW":
            //        case "zh-HK":
            //        case "zh-MO":
            //            ConfigUiLanguageComboBox.SelectedIndex = 1;
            //            break;

            //        case "en-US":
            //            ConfigUiLanguageComboBox.SelectedIndex = 2;
            //            break;

            //        case "ja-JP":
            //            ConfigUiLanguageComboBox.SelectedIndex = 3;
            //            break;

            //        default:
            //            break;
            //    }
            //}
            //else
            //    ConfigUiLanguageComboBox.SelectedIndex = settings.ConfigUiLanguageIndex;

            if (settings.ConfigFunctionAutoCheckUpdateCheck) //&& NetworkUtil.IsConnectInternet())
            {
                new UpdateCheckerUtil().CheckUpdate(false);
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
            //settings.ConfigX264PriorityIndex = ConfigX264PriorityComboBox.SelectedIndex;
            //settings.ConfigX264ExtraParameterText = ConfigX264ExtraParameterTextBox.Text;
            settings.AvsScriptText = AvsScriptTextBox.Text;
            settings.AudioEncoderIndex = AudioEncoderComboBox.SelectedIndex;
            settings.AudioBitrateComboText = AudioBitrateComboBox.Text;
            //settings.MiscOnePicBitrateValue = MiscOnePicBitrateNumericUpDown.Value;
            //settings.MiscOnePicFpsValue = MiscOnePicFpsNumericUpDown.Value;
            //settings.MiscOnePicCrfValue = MiscOnePicCrfNumericUpDown.Value;
            //settings.ConfigFunctionDeleteTempFileCheck = ConfigFunctionDeleteTempFileCheckBox.Checked;
            //settings.ConfigFunctionAutoCheckUpdateCheck = ConfigFunctionAutoCheckUpdateCheckBox.Checked;
            //settings.ConfigUiTrayModeCheck = ConfigUiTrayModeCheckBox.Checked;
            //settings.ConfigUiLanguageIndex = ConfigUiLanguageComboBox.SelectedIndex;
            //settings.ConfigUiSplashScreenCheck = ConfigUiSplashScreenCheckBox.Checked;
            //settings.ConfigX264Threads = ConfigX264ThreadsComboBox.SelectedIndex;
            //settings.ConfigFunctionEnableX265Check = ConfigFunctionEnableX265CheckBox.Checked;
            //settings.ConfigFunctionVideoPlayerText = ConfigFunctionVideoPlayerTextBox.Text;
            //settings.MuxConvertFormatIndex = MuxConvertFormatComboBox.SelectedIndex;
            settings.VideoBatchSubtitleLanguage = "none,sc,tc,chs,cht,en,jp";

            settings.Save();
        }

        #endregion Settings


        #region Preset

        private void LoadVideoPreset(VideoEncoderType videoEncoder, bool resetIndex = false)
        {
            VideoPresetComboBox.Items.Clear();
            foreach (var item in GetVideoEncoderParameters(videoEncoder))
            {
                VideoPresetComboBox.Items.Add(item.name);
            }
            if (VideoPresetComboBox.Items.Count > 0 &&
                (VideoPresetComboBox.SelectedIndex == -1 || resetIndex))
            {
                VideoPresetComboBox.SelectedIndex = 0;
            }
        }

        private void AddVideoPreset(VideoEncoderType videoEncoder, Preset.Parameter newParameter)
        {
            List<Preset.Parameter> parameters = GetVideoEncoderParameters(videoEncoder);
            if (parameters.Exists(p => p.name == newParameter.name))
            {
                throw new ArgumentException("Duplicated name");
            }
            parameters.Add(newParameter);
        }

        private void DeleteVideoPreset(VideoEncoderType videoEncoder, string name)
        {
            List<Preset.Parameter> parameters = GetVideoEncoderParameters(videoEncoder);
            parameters.RemoveAll(p => p.name == name);
        }

        private Preset.Parameter LoadVideoPresetParameter(VideoEncoderType videoEncoder, string name)
        {
            return GetVideoEncoderParameters(videoEncoder).Find(p => p.name == name);
        }

        private VideoEncoderType GetVideoEncoderEnum()
        {
            string keyword = VideoEncoderComboBox.SelectedItem.ToString();
            if (keyword.Contains("x264"))
                return VideoEncoderType.X264;
            else if (keyword.Contains("x265"))
                return VideoEncoderType.X265;
            else
                return VideoEncoderType.NA;
        }

        private List<Preset.Parameter> GetVideoEncoderParameters(VideoEncoderType videoEncoder)
        {
            List<Preset.Parameter> parameters;
            switch (videoEncoder)
            {
                case VideoEncoderType.X264:
                    parameters = preset.video.videoEncoder.x264;
                    break;
                case VideoEncoderType.X265:
                    parameters = preset.video.videoEncoder.x265;
                    break;
                default:
                    parameters = new List<Preset.Parameter>();
                    break;
            }
            return parameters;
        }

        private void LoadAudioPreset(AudioEncoderType audioEncoder, bool resetIndex = false)
        {
            AudioPresetComboBox.Items.Clear();
            foreach (var item in GetAudioEncoderParameters(audioEncoder))
            {
                AudioPresetComboBox.Items.Add(item.name);
            }
            if (AudioPresetComboBox.Items.Count > 0 &&
                (AudioPresetComboBox.SelectedIndex == -1 || resetIndex))
            {
                AudioPresetComboBox.SelectedIndex = 0;
            }
        }

        private void AddAudioPreset(AudioEncoderType audioEncoder, Preset.Parameter newParameter)
        {
            List<Preset.Parameter> parameters = GetAudioEncoderParameters(audioEncoder);
            if (parameters.Exists(p => p.name == newParameter.name))
            {
                throw new ArgumentException("Duplicated name");
            }
            parameters.Add(newParameter);
        }

        private void DeleteAudioPreset(AudioEncoderType audioEncoder, string name)
        {
            List<Preset.Parameter> parameters = GetAudioEncoderParameters(audioEncoder);
            parameters.RemoveAll(p => p.name == name);
        }

        private Preset.Parameter LoadAudioPresetParameter(AudioEncoderType audioEncoder, string name)
        {
            return GetAudioEncoderParameters(audioEncoder).Find(p => p.name == name);
        }

        private AudioEncoderType GetAudioEncoderEnum()
        {
            return (AudioEncoderType)AudioEncoderComboBox.SelectedIndex;
        }

        private List<Preset.Parameter> GetAudioEncoderParameters(AudioEncoderType audioEncoder)
        {
            List<Preset.Parameter> parameters;
            switch (audioEncoder)
            {
                case AudioEncoderType.NeroAAC:
                    parameters = preset.audio.audioEncoder.NeroAAC;
                    break;
                case AudioEncoderType.FDKAAC:
                    parameters = preset.audio.audioEncoder.FDKAAC;
                    break;
                case AudioEncoderType.QAAC:
                    parameters = preset.audio.audioEncoder.QAAC;
                    break;
                case AudioEncoderType.MP3:
                    parameters = preset.audio.audioEncoder.MP3;
                    break;
                default:
                    parameters = new List<Preset.Parameter>();
                    break;
            }
            return parameters;
        }

        #endregion Preset End

        #region VideoBatch

        public string VideoBatch(string input, string output)
        {
            bool hasAudio = false;
            string bat = "";
            string inputName = Path.GetFileNameWithoutExtension(input);
            string tempVideo = Path.Combine(Global.Running.tempFolder, inputName + "_vtemp.mp4");
            string tempAudio = Path.Combine(Global.Running.tempFolder, inputName + "_atemp" + GetAudioExt());
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
                    aextract = AudioBat(input, tempAudio);
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
                        aextract = AudioBat(input, tempAudio);
                    break;

                default:
                    break;
            }

            if (VideoEncoderComboBox.SelectedItem.ToString().ToLower().Contains("x264"))
            {
                if (x264mode == X264Mode.TwoPass)
                    x264 = X264bat(input, tempVideo, 1, sub) + "\r\n" +
                           X264bat(input, tempVideo, 2, sub);
                else x264 = X264bat(input, tempVideo, 0, sub);
                if (audioMode == 1 || !hasAudio)
                    x264 = x264.Replace(tempVideo, output);
            }
            else if (VideoEncoderComboBox.SelectedItem.ToString().ToLower().Contains("x265"))
            {
                tempVideo = Path.Combine(Global.Running.tempFolder, inputName + "_vtemp.hevc");
                if (x264mode == X264Mode.TwoPass)
                    x264 = X265bat(input, tempVideo, 1, sub) + "\r\n" +
                           X265bat(input, tempVideo, 2, sub);
                else x264 = X265bat(input, tempVideo, 0, sub);
                if (audioMode == 1 || !hasAudio)
                    x264 += "\r\n" + ToolsUtil.MP4BOX.quotedPath + "  -add  \"" + tempVideo + "#trackID=1:name=\" -new " + output.Quote() + " \r\n";
            }
            x264 += "\r\n";

            //封装
            string mux = string.Empty;
            if (VideoBatchFormatComboBox.Text == "mp4")
                mux = Shared.MP4MuxCommand(tempVideo, tempAudio, output);
            else
                mux = Shared.FFMpegMuxCommand(tempVideo, tempAudio, output);

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


            if (AudioEncoderComboBox.SelectedIndex != (int)AudioEncoderType.QAAC
                && AudioEncoderComboBox.SelectedIndex != (int)AudioEncoderType.NeroAAC
                && AudioEncoderComboBox.SelectedIndex != (int)AudioEncoderType.FDKAAC)
            {
                DialogResult r = MessageBoxExt.ShowQuestion("音频页面中的编码器未采用AAC将可能导致压制失败，建议将编码器改为QAAC、NeroAAC或FDKAAC。是否继续压制？", "提示");
                if (r == DialogResult.No)
                    return;
            }

            FileStringUtil.EnsureDirectoryExists(Global.Running.tempFolder);
            string bat = string.Empty;
            foreach (var item in VideoBatchItemListbox.Items)
            {
                string input = item.ToString();
                string output;
                if (Directory.Exists(VideoBatchOutputFolderTextBox.Text))
                    output = VideoBatchOutputFolderTextBox.Text + "\\" + Path.GetFileNameWithoutExtension(input) + "_batch." + VideoBatchFormatComboBox.Text;
                else
                    output = Path.ChangeExtension(input, "_batch." + VideoBatchFormatComboBox.Text);
                bat += VideoBatch(input, output);
            }

            logger.Info(bat);
            //Thread.CurrentThread.CurrentUICulture = GetCultureFromComboBox();
            new WorkingForm(bat, VideoBatchItemListbox.Items.Count) { Owner = this }.Show();
            //batpath = workPath + "\\auto.bat";
            //File.WriteAllText(batpath, bat, Encoding.Default);
            //Process.Start(batpath);
        }

        #endregion VideoBatch

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

            if (AudioEncoderComboBox.SelectedIndex != (int)AudioEncoderType.QAAC
                && AudioEncoderComboBox.SelectedIndex != (int)AudioEncoderType.NeroAAC
                && AudioEncoderComboBox.SelectedIndex != (int)AudioEncoderType.FDKAAC)
            {
                DialogResult r = MessageBoxExt.ShowQuestion("音频页面中的编码器未采用AAC将可能导致压制失败，建议将编码器改为QAAC、NeroAAC或FDKAAC。是否继续压制？", "提示");
                if (r == DialogResult.No)
                    return;
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
                if (!(AvsUtil.IsEmbeddedAvsInstalled() || AvsUtil.IsSystemAvsInstalled()))
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
            string tempAudio = Path.Combine(Global.Running.tempFolder, inputName + "_atemp" + GetAudioExt());
            FileStringUtil.EnsureDirectoryExists(Global.Running.tempFolder);
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
                    aextract = AudioBat(videoInput, tempAudio);
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
                        aextract = AudioBat(videoInput, tempAudio);
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
                    x264 = X264bat(videoInput, tempVideo, 1, videoSubtitle) + "\r\n" +
                           X264bat(videoInput, tempVideo, 2, videoSubtitle);
                else x264 = X264bat(videoInput, tempVideo, 0, videoSubtitle);
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
                    x264 = X265bat(videoInput, tempVideo, 1, videoSubtitle) + "\r\n" +
                           X265bat(videoInput, tempVideo, 2, videoSubtitle);
                else x264 = X265bat(videoInput, tempVideo, 0, videoSubtitle);
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
                    mux = Shared.MP4MuxCommand(tempVideo, tempAudio, Path.ChangeExtension(videoOutput, targetExt));
                else
                    mux = Shared.FFMpegMuxCommand(tempVideo, tempAudio, Path.ChangeExtension(videoOutput, targetExt));
                x264 = aextract + x264 + mux + "\r\n"
                    + "del " + tempVideo.Quote() + "\r\n"
                    + "del " + tempAudio.Quote() + "\r\n";
            }
            x264 += "\r\necho ===== one file is completed! =====\r\n";

            #endregion Mux

            logger.Info(x264);
            //Thread.CurrentThread.CurrentUICulture = GetCultureFromComboBox();
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
                    VideoEncoderType videoEncoder = GetVideoEncoderEnum();
                    var newParameter = new Preset.Parameter
                    { name = vPresetName, value = VideoCustomParameterTextBox.Text };
                    AddVideoPreset(videoEncoder, newParameter);
                    Preset.Preset.Save(preset);
                    LoadVideoPreset(videoEncoder);
                    VideoPresetComboBox.SelectedIndex = VideoPresetComboBox.FindString(vPresetName);
                }
            }
            catch (ArgumentException)
            {
                MessageBoxExt.ShowErrorMessage("预设名称已经存在", "预设名称重复");
            }
        }

        private void VideoDeletePresetButton_Click(object sender, EventArgs e)
        {
            if (MessageBoxExt.ShowQuestion("确定要删除这条预设参数？", "提示") == DialogResult.Yes)
            {
                VideoEncoderType videoEncoder = GetVideoEncoderEnum();
                DeleteVideoPreset(videoEncoder, VideoPresetComboBox.Text);
                Preset.Preset.Save(preset);
                LoadVideoPreset(videoEncoder);
            }
        }

        #region VideoMode RadioButtonGroup

        private void VideoMode2PassRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
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
        }

        private void VideoModeCustomRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
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
        }

        private void VideoModeCrfRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
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
            UIUtil.TextBoxSelectAll(sender, e);
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

            VideoEncoderType videoEncoder = GetVideoEncoderEnum();
            switch (videoEncoder)
            {
                case VideoEncoderType.X265:
                    VideoOutputTextBox.Text = VideoOutputTextBox.Text.Replace("_x264.", "_x265.");

                    //VideoSubtitleTextBox.Text = string.Empty;
                    //VideoSubtitleTextBox.Enabled = false;
                    //VideoSubtitleButton.Enabled = false;
                    //VideoBatchSubtitleCheckBox.Enabled = false;
                    //VideoBatchSubtitleLanguage.Enabled = false;
                    VideoDemuxerComboBox.Enabled = false;
                    VideoBatchFormatComboBox.Text = "mp4";
                    VideoBatchFormatComboBox.Enabled = false;

                    VideoCustomParameterTextBox.Text = string.Empty;
                    LoadVideoPreset(videoEncoder, true);
                    break;
                case VideoEncoderType.X264:
                    VideoOutputTextBox.Text = VideoOutputTextBox.Text.Replace("_x265.", "_x264.");

                    VideoSubtitleTextBox.Enabled = true;
                    VideoSubtitleButton.Enabled = true;
                    VideoBatchSubtitleCheckBox.Enabled = true;
                    VideoBatchSubtitleLanguage.Enabled = true;
                    VideoDemuxerComboBox.Enabled = true;
                    VideoBatchFormatComboBox.Enabled = true;

                    VideoCustomParameterTextBox.Text = string.Empty;
                    LoadVideoPreset(videoEncoder, true);
                    break;
                default:
                    break;
            }

        }

        private void VideoPresetComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VideoEncoderComboBox.Items != null)
            {
                VideoCustomParameterTextBox.Text = LoadVideoPresetParameter(GetVideoEncoderEnum(), VideoPresetComboBox.Text)?.value;
            }
        }

        #endregion Video Tab

        #region Audio Tab

        private void AudioEncoderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (File.Exists(AudioInputTextBox.Text))
                AudioOutputTextBox.Text = Path.ChangeExtension(AudioInputTextBox.Text,
                    GenerateAudioOutputExt((AudioEncoderType)AudioEncoderComboBox.SelectedIndex));

            switch ((AudioEncoderType)AudioEncoderComboBox.SelectedIndex)
            {
                case AudioEncoderType.NeroAAC:
                case AudioEncoderType.QAAC:
                case AudioEncoderType.FDKAAC:
                    AudioBitrateComboBox.Enabled =
                    AudioAudioModeBitrateRadioButton.Enabled =
                    AudioAudioModeCustomRadioButton.Enabled = true;
                    if (AudioAudioModeCustomRadioButton.Checked)
                    {
                        AudioPresetDeleteButton.Visible =
                        AudioPresetAddButton.Visible = true;
                    }
                    break;

                case AudioEncoderType.WAV:
                case AudioEncoderType.ALAC:
                case AudioEncoderType.FLAC:
                    AudioBitrateComboBox.Enabled =
                    AudioAudioModeBitrateRadioButton.Enabled =
                    AudioAudioModeCustomRadioButton.Enabled = false;
                    AudioPresetDeleteButton.Visible =
                    AudioPresetAddButton.Visible = false;
                    break;

                case AudioEncoderType.AC3:
                    AudioBitrateComboBox.Enabled = true; // Why?
                    AudioAudioModeBitrateRadioButton.Enabled = true; // Why?
                    AudioAudioModeCustomRadioButton.Enabled = false; // Why just enable 1 radio button?
                    AudioPresetDeleteButton.Visible =
                    AudioPresetAddButton.Visible = false;
                    break;

                case AudioEncoderType.MP3:
                    AudioBitrateComboBox.Enabled =
                    AudioAudioModeBitrateRadioButton.Enabled =
                    AudioAudioModeCustomRadioButton.Enabled = true;
                    AudioPresetDeleteButton.Visible =
                    AudioPresetAddButton.Visible = false;
                    break;

                default:
                    break;
            }


            AudioCustomParameterTextBox.Text = string.Empty;

            LoadAudioPreset(GetAudioEncoderEnum(), true);
        }

        #region AudioAudioMode RadioButton

        private void AudioAudioModeCustomRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
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
        }

        private void AudioAudioModeBitrateRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
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
        }

        #endregion AudioAudioMode RadioButton

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

            string aac = "";
            string audioOutputExt = GenerateAudioOutputExt((AudioEncoderType)AudioEncoderComboBox.SelectedIndex);

            foreach (var item in AudioBatchItemListBox.Items)
            {
                string input = item.ToString();
                string output = Path.ChangeExtension(input, audioOutputExt);
                aac += AudioBat(input, output);
                aac += "\r\n";
            }
            aac += "\r\ncmd";
            string batpath = ToolsUtil.ToolsFolder + "\\aac.bat";
            File.WriteAllText(batpath, aac, Encoding.Default);
            logger.Info(aac);
            Process.Start(batpath);
        }

        /// <summary>
        /// Create file name's postfix and/or extension based on the audio encoder type
        /// </summary>
        /// <param name="audioEncoder">AudioEncoder</param>
        /// <param name="formatString">Format String of the new file name. Default is "_AAC.aac"</param>
        /// <returns>New postfix and/or extension</returns>
        private string GenerateAudioOutputExt(AudioEncoderType audioEncoder, string formatString = "_{0}.{1}")
        {
            string codec, outputExt;
            switch (audioEncoder)
            {
                case AudioEncoderType.NeroAAC: codec = "AAC"; outputExt = "mp4"; break;
                case AudioEncoderType.QAAC: codec = "AAC"; outputExt = "m4a"; break;
                case AudioEncoderType.WAV: codec = "WAV"; outputExt = "wav"; break;
                case AudioEncoderType.ALAC: codec = "ALAC"; outputExt = "m4a"; break;
                case AudioEncoderType.FLAC: codec = "FLAC"; outputExt = "flac"; break;
                case AudioEncoderType.FDKAAC: codec = "AAC"; outputExt = "m4a"; break;
                case AudioEncoderType.AC3: codec = "AC3"; outputExt = "ac3"; break;
                case AudioEncoderType.MP3: codec = "MP3"; outputExt = "mp3"; break;
                default: codec = "AAC"; outputExt = "aac"; break;
            }
            return string.Format(formatString, codec, outputExt);
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
                audioOutput = savefile.FileName + GetAudioExt();
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
                File.WriteAllText(batpath, AudioBat(audioInput, audioOutput), Encoding.Default);
                logger.Info(AudioBat(audioInput, audioOutput));
                Process.Start(batpath);
            }
        }

        private void AudioInputTextBox_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(AudioInputTextBox.Text))
            {
                audioInput = AudioInputTextBox.Text;
                AudioOutputTextBox.Text = Path.ChangeExtension(AudioInputTextBox.Text,
                    GenerateAudioOutputExt((AudioEncoderType)AudioEncoderComboBox.SelectedIndex));
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
            AudioCustomParameterTextBox.Text = LoadAudioPresetParameter(GetAudioEncoderEnum(), AudioPresetComboBox.Text)?.value;
        }

        private void AudioPresetAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                string aPresetName = InputBox.Show("请输入这个预设名称", "请为预置配置命名", "新预置名称");
                if (!string.IsNullOrEmpty(aPresetName))
                {
                    AudioEncoderType audioEncoder = GetAudioEncoderEnum();
                    var newParameter = new Preset.Parameter
                    { name = aPresetName, value = AudioCustomParameterTextBox.Text };
                    AddAudioPreset(audioEncoder, newParameter);
                    Preset.Preset.Save(preset);
                    LoadAudioPreset(audioEncoder);
                    AudioPresetComboBox.SelectedIndex = AudioPresetComboBox.FindString(aPresetName);
                }
            }
            catch (ArgumentException)
            {
                MessageBoxExt.ShowErrorMessage("预设名称已经存在", "预设名称重复");
            }
        }

        private void AudioPresetDeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBoxExt.ShowQuestion("确定要删除这条预设参数？", "提示") == DialogResult.Yes)
            {
                AudioEncoderType audioEncoder = GetAudioEncoderEnum();
                DeleteAudioPreset(audioEncoder, AudioPresetComboBox.Text);
                Preset.Preset.Save(preset);
                LoadAudioPreset(audioEncoder);
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
            StringBuilder fileNames = new StringBuilder();
            string ffmpeg = "";
            string ext = Path.GetExtension(AudioBatchItemListBox.Items[0].ToString());
            string output = Path.ChangeExtension(AudioOutputTextBox.Text, ext);

            foreach (var item in AudioBatchItemListBox.Items)
            {
                if (Path.GetExtension(item.ToString()) != ext)
                {
                    MessageBoxExt.ShowErrorMessage("只允许合并相同格式文件。");
                    return;
                }
                fileNames.AppendLine($"file '{item.ToString()}'");
            }
            File.WriteAllText("concat.txt", fileNames.ToString());
            ffmpeg = ToolsUtil.FFMPEG.quotedPath + " -f concat -i concat.txt -y -c copy " + output;
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

        #region Avs Tab

        private void AvsPreviewButton_Click(object sender, EventArgs e)
        {
            if (AvsScriptTextBox.Text != "")
            {
                string filepath = ToolsUtil.ToolsFolder + "\\temp.avs";
                File.WriteAllText(filepath, AvsScriptTextBox.Text, Encoding.Default);
                if (File.Exists(settings.ConfigFunctionVideoPlayerText))
                {
                    Process.Start(settings.ConfigFunctionVideoPlayerText, filepath);
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

            if (!(AvsUtil.IsEmbeddedAvsInstalled() || AvsUtil.IsSystemAvsInstalled()))
            {
                if (MessageBoxExt.ShowQuestion("检测到本机未安装avisynth无法继续压制，是否去下载安装", "avisynth未安装") == DialogResult.Yes)
                    Process.Start("http://sourceforge.net/projects/avisynth2/");
                return;
            }
            string avsVideoInput = AvsVideoInputTextBox.Text;
            string inputName = Path.GetFileNameWithoutExtension(avsVideoInput);
            string tempVideo = Path.Combine(Global.Running.tempFolder, inputName + "_vtemp.mp4");
            string tempAudio = Path.Combine(Global.Running.tempFolder, inputName + "_atemp" + GetAudioExt());
            FileStringUtil.EnsureDirectoryExists(Global.Running.tempFolder);
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
                aextract = AudioBat(avsVideoInput, tempAudio);
            }
            else
                aextract = string.Empty;

            //video
            if (VideoEncoderComboBox.SelectedItem.ToString().ToLower().Contains("x264"))
            {
                if (x264mode == X264Mode.TwoPass)
                    x264 = X264bat(filepath, tempVideo, 1) + "\r\n" +
                           X264bat(filepath, tempVideo, 2);
                else x264 = X264bat(filepath, tempVideo);
                if (!AvsIncludeAudioCheckBox.Checked || !hasAudio)
                    x264 = x264.Replace(tempVideo, avsOutput);
            }
            else if (VideoEncoderComboBox.SelectedItem.ToString().ToLower().Contains("x265"))
            {
                tempVideo = Path.Combine(Global.Running.tempFolder, inputName + "_vtemp.hevc");
                if (x264mode == X264Mode.TwoPass)
                    x264 = X265bat(filepath, tempVideo, 1) + "\r\n" +
                           X265bat(filepath, tempVideo, 2);
                else x264 = X265bat(filepath, tempVideo);
                if (!AvsIncludeAudioCheckBox.Checked || !hasAudio)
                {
                    x264 += "\r\n" + ToolsUtil.MP4BOX.quotedPath + " -add  \"" + tempVideo + "#trackID=1:name=\" -new " + avsOutput.Quote() + " \r\n";
                    x264 += "del " + tempVideo.Quote();
                }
            }
            //mux
            string mux = string.Empty;
            if (AvsIncludeAudioCheckBox.Checked && hasAudio) //如果包含音频
                mux = Shared.MP4MuxCommand(tempVideo, tempAudio, avsOutput);

            string auto = aextract + x264 + "\r\n" + mux + " \r\n";
            auto += "\r\necho ===== one file is completed! =====\r\n";
            logger.Info(auto);
            //Thread.CurrentThread.CurrentUICulture = GetCultureFromComboBox();
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
            string vsfilterDLLPath = Path.Combine(ToolsUtil.AvsPluginFolder, AvsFilterComboBox.Text);
            string text = "LoadPlugin(\"" + vsfilterDLLPath + "\")" + "\r\n";
            AvsScriptTextBox.Text = text + AvsScriptTextBox.Text;
        }

        private void AvsScriptTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            UIUtil.TextBoxSelectAll(sender, e);
        }

        private void GenerateAVS()
        {
            string avsSubtitleInput = AvsSubtitleInputTextBox.Text;
            string avsVideoInput = AvsVideoInputTextBox.Text;
            StringBuilder avsBuilder = new StringBuilder(1000);

            string vsfilterDLLPath = Path.Combine(ToolsUtil.AvsPluginFolder, "VSFilter.DLL");
            string SupTitleDLLPath = Path.Combine(ToolsUtil.AvsPluginFolder, "SupTitle.dll");
            string LSMASHSourceDLLPath = Path.Combine(ToolsUtil.AvsPluginFolder, "LSMASHSource.DLL");
            string undotDLLPath = Path.Combine(ToolsUtil.AvsPluginFolder, "UnDot.DLL");

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
            ChangeEncoderProcessPriority();
        }

        public void ChangeEncoderProcessPriority()
        {
            string encoderProcessName = Path.GetFileNameWithoutExtension(VideoEncoderComboBox.Text);
            OtherUtil.ChangeProcessesPriorityByName(encoderProcessName, (ProcessPriorityClass)settings.ConfigX264Priority);
        }

        [Obsolete("Not used")]
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.sosg.net/read.php?tid=480646");
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

        #endregion TabControl
    }
}