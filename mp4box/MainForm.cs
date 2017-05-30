// ------------------------------------------------------------------
// Copyright (C) 2011-2016 Maruko Toolbox Project
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
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

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
        private string syspath = Environment.GetFolderPath(Environment.SpecialFolder.System).Remove(1);
        private int indexofsource;
        private int indexoftarget;
        private byte x264mode = 1;
        private string clip = "";
        private string MIvideo = "";
        private string namevideo = "";
        private string namevideo2 = "";
        private string namevideo4 = "";
        private string namevideo5 = "";
        private string namevideo6 = "";
        private string nameaudio = "";
        private string nameaudio2 = "";
        private string nameaudio3 = "";
        private string namevideo8 = "";
        private string namevideo9 = "video";
        private string nameout;
        private string nameout2;
        private string nameout3;
        private string nameout5;
        private string nameout6;
        private string nameout9;
        private string namesub;
        private string namesub2 = "";
        private string namesub9 = "subtitle";
        private string MItext = "把视频文件拖到这里";
        private string mkvextract;
        private string mkvmerge;
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
        private DateTime ReleaseDate = Utility.Assembly.GetAssemblyVersionTime();

        #endregion Private Members Declaration

        public MainForm()
        {
            Instance = this;
            logPath = Application.StartupPath + "\\logs";
            logFileName = logPath + "\\LogFile-" + DateTime.Now.ToString("yyyy'-'MM'-'dd'_'HH'-'mm'-'ss") + ".log";
            preset = new Preset();
            InitializeComponent();
        }

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
                        sb.Append(" -vf subtitles=\"" + FileString.GetLibassFormatPath(sub) + "\"");
                    else
                    {
                        int index = x264tmpline.IndexOf("lanczos");
                        sb.Insert(index + 7, ",subtitles=\"" + FileString.GetLibassFormatPath(sub) + "\"");
                    }
                }
                sb.Append(" -strict -1 -f yuv4mpegpipe -an - | ");
            }

            sb.Append(FileString.FormatPath(Path.Combine(workPath, VideoEncoderComboBox.SelectedItem.ToString())) + (isAvs ? string.Empty : " --y4m"));
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

        public string timeSubtract(int[] beginTimeInt, int[] endTimeInt)
        {
            // endTimeInt must later than beginTimeInt
            // TimeSpan not able to direct parse greater than 24 hours without day specified
            TimeSpan beginTime = new TimeSpan(beginTimeInt[0], beginTimeInt[1], beginTimeInt[2]);
            TimeSpan endTime = new TimeSpan(endTimeInt[0], endTimeInt[1], endTimeInt[2]);
            TimeSpan result = endTime.Subtract(beginTime);
            // Do not use TimeSpan.ToString(), which converts hours to day when it is greater than 24h
            return $"{(int)result.TotalHours}:{result.Minutes}:{result.Seconds}";
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
                        ffmpeg += "\"" + workPath + "\\neroAacEnc.exe\" -ignorelength " + AudioCustomParameterTextBox.Text.ToString() + " -if - -of \"" + output + "\"";
                    }
                    break;

                case 1:
                    if (AudioAudioModeBitrateRadioButton.Checked)
                    {
                        ffmpeg += "\"" + workPath + "\\qaac.exe\" -q 2 --ignorelength -c " + AudioBitrateComboBox.Text + " - -o \"" + output + "\"";
                    }
                    if (AudioAudioModeCustomRadioButton.Checked)
                    {
                        ffmpeg += "\"" + workPath + "\\qaac.exe\" --ignorelength " + AudioCustomParameterTextBox.Text.ToString() + " - -o \"" + output + "\"";
                    }
                    break;

                case 2:
                    if (Path.GetExtension(output) == ".aac")
                        output = FileString.ChangeExt(output, ".wav");
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
                        ffmpeg += "\"" + workPath + "\\fdkaac.exe\" --ignorelength " + AudioCustomParameterTextBox.Text.ToString() + " - -o \"" + output + "\"";
                    }
                    break;

                case 6:
                    ffmpeg = "\"" + workPath + "\\ffmpeg.exe\" -i \"" + input + "\" -c:a ac3 -b:a " + AudioBitrateComboBox.Text.ToString() + "k \"" + output + "\"";
                    break;

                case 7:
                    if (AudioAudioModeBitrateRadioButton.Checked)
                    {
                        ffmpeg += "\"" + workPath + "\\lame.exe\" -q 3 -b " + AudioBitrateComboBox.Text + " - \"" + output + "\"";
                    }
                    if (AudioAudioModeCustomRadioButton.Checked)
                    {
                        ffmpeg += "\"" + workPath + "\\lame.exe\" " + AudioCustomParameterTextBox.Text.ToString() + " - \"" + output + "\"";
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

        private void btnaudio_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.AUDIO_5); //"音频(*.mp4;*.aac;*.mp2;*.mp3;*.m4a;*.ac3)|*.mp4;*.aac;*.mp2;*.mp3;*.m4a;*.ac3|所有文件(*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                nameaudio = openFileDialog1.FileName;
                MuxMp4AudioInputTextBox.Text = nameaudio;
            }
        }

        private void btnvideo_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.VIDEO_9);//"视频(*.avi;*.mp4;*.m1v;*.m2v;*.m4v;*.264;*.h264;*.hevc)|*.avi;*.mp4;*.m1v;*.m2v;*.m4v;*.264;*.h264;*.hevc|所有文件(*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                namevideo = openFileDialog1.FileName;
                MuxMp4VideoInputTextBox.Text = namevideo;
            }
        }

        private void btnout_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.VIDEO_3);  //"视频(*.mp4)|*.mp4";
            DialogResult result = savefile.ShowDialog();
            if (result == DialogResult.OK)
            {
                nameout = savefile.FileName;
                MuxMp4OutputTextBox.Text = nameout;
            }
        }

        private void btnmux_Click(object sender, EventArgs e)
        {
            if (namevideo == "")
            {
                MessageBoxExtension.ShowErrorMessage("请选择视频文件");
                return;
            }
            string inputExt = Path.GetExtension(MuxMp4VideoInputTextBox.Text.Trim()).ToLower();
            if (inputExt != ".avi"  //Only MPEG-4 SP/ASP video and MP3 audio supported at the current time. To import AVC/H264 video, you must first extract the avi track.
                    && inputExt != ".mp4" //MPEG-4 Video
                    && inputExt != ".m1v" //MPEG-1 Video
                    && inputExt != ".m2v" //MPEG-2 Video
                    && inputExt != ".m4v" //MPEG-4 Video
                    && inputExt != ".264" //AVC/H264 Video
                    && inputExt != ".h264" //AVC/H264 Video
                    && inputExt != ".hevc") //HEVC/H265 Video
            {
                MessageBoxExtension.ShowErrorMessage("输入文件: \r\n\r\n" + MuxMp4VideoInputTextBox.Text.Trim() + "\r\n\r\n是一个mp4box不支持的视频文件!");
                return;
            }

            if (nameout == "")
            {
                MessageBoxExtension.ShowErrorMessage("请选择输出文件");
                return;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(FileString.FormatPath(workPath + "\\mp4box.exe") + " -add \"" + namevideo + "#trackID=1");
            if (MuxMp4ParComboBox.Text != "")
                sb.Append(":par=" + MuxMp4ParComboBox.Text);
            if (MuxMp4FpsComboBox.Text != "auto" && MuxMp4FpsComboBox.Text != "")
                sb.Append(":fps=" + MuxMp4FpsComboBox.Text);
            sb.Append(":name=\""); //输入raw时删除默认添加的gpac字符串
            if (nameaudio != "")
                sb.Append(" -add \"" + nameaudio + ":name=\"");
            sb.Append(" -new \"" + nameout + "\" \r\n cmd");
            mux = sb.ToString();
            batpath = workPath + "\\mux.bat";
            File.WriteAllText(batpath, mux, Encoding.Default);
            LogRecord(mux);
            Process.Start(batpath);
        }

        private void btnaextract_Click(object sender, EventArgs e)
        {
            //MP4 抽取音频1
            ExtractAV(namevideo, "a", 0);
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

        private void ExtractAV(string namevideo, string av, int streamIndex)
        {
            if (string.IsNullOrEmpty(namevideo))
            {
                MessageBoxExtension.ShowErrorMessage("请选择视频文件");
                return;
            }

            string ext = Path.GetExtension(namevideo);
            //aextract = "\"" + workPath + "\\mp4box.exe\" -raw 2 \"" + namevideo + "\"";
            string aextract = "";
            aextract += FileString.FormatPath(workPath + "\\ffmpeg.exe");
            aextract += " -i " + FileString.FormatPath(namevideo);
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
                    MessageBoxExtension.ShowInfoMessage("该轨道无音频");
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
            string outfile = FileString.GetDir(namevideo) +
                Path.GetFileNameWithoutExtension(namevideo) + suf + ext;
            aextract += FileString.FormatPath(outfile);
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
            aextract += FileString.FormatPath(workPath + "\\ffmpeg.exe");
            aextract += " -i " + FileString.FormatPath(namevideo);
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
            aextract += FileString.FormatPath(outfile) + "\r\n";
            return aextract;
        }

        private void ExtractTrack(string namevideo, int streamIndex)
        {
            if (string.IsNullOrEmpty(namevideo))
            {
                MessageBoxExtension.ShowErrorMessage("请选择视频文件");
                return;
            }

            string aextract = "";
            aextract += FileString.FormatPath(workPath + "\\ffmpeg.exe");
            aextract += " -i " + FileString.FormatPath(namevideo);
            aextract += " -map 0:" + streamIndex + " -c copy ";
            string suf = "_抽取流Index" + streamIndex;
            string outfile = FileString.GetDir(namevideo) +
                Path.GetFileNameWithoutExtension(namevideo) + suf + '.' +
                FormatExtractor.Extract(workPath, namevideo)[streamIndex].Format;
            aextract += FileString.FormatPath(outfile);
            batpath = workPath + "\\mkvextract.bat";
            File.WriteAllText(batpath, aextract, Encoding.Default);
            LogRecord(aextract);
            Process.Start(batpath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBoxExtension.ShowInfoMessage(string.Format(" \r\n有任何建议或疑问可以通过以下方式联系小丸。\nQQ：57655408\n微博：weibo.com/xiaowan3\n百度贴吧ID：小丸到达\n\n\t\t\t发布日期：2012年10月17日\n\t\t\t- ( ゜- ゜)つロ 乾杯~"), "关于");
        }

        private void btnvextract_Click(object sender, EventArgs e)
        {
            //MP4抽取视频1
            ExtractAV(namevideo, "v", 0);
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

        private void txtvideo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (MuxMp4VideoInputTextBox.Text.Trim().Length > 0)
                {
                    if (!File.Exists(MuxMp4VideoInputTextBox.Text.Trim()))
                    {
                        throw new Exception("输入文件: \r\n\r\n" + MuxMp4VideoInputTextBox.Text.Trim() + "\r\n\r\n不存在!");
                    }
                    string inputExt = Path.GetExtension(MuxMp4VideoInputTextBox.Text.Trim()).ToLower();
                    //if (inputExt != ".avi"  //Only MPEG-4 SP/ASP video and MP3 audio supported at the current time. To import AVC/H264 video, you must first extract the avi track.
                    //        && inputExt != ".mp4" //MPEG-4 Video
                    //        && inputExt != ".m1v" //MPEG-1 Video
                    //        && inputExt != ".m2v" //MPEG-2 Video
                    //        && inputExt != ".m4v" //MPEG-4 Video
                    //        && inputExt != ".264" //AVC/H264 Video
                    //        && inputExt != ".h264" //AVC/H264 Video
                    //        && inputExt != ".hevc") //HEVC/H265 Video
                    //{
                    //    throw new Exception("输入文件: \r\n\r\n" + txtvideo.Text.Trim() + "\r\n\r\n是一个mp4box不支持的视频文件!");
                    //}
                    if (inputExt == ".264" || inputExt == ".h264" || inputExt == ".hevc")
                    {
                        MessageBoxExtension.ShowWarningMessage("H.264或者HEVC流文件mp4box将会自动侦测帧率\r\n如果侦测不到将默认为25fps\r\n如果你知道该文件的帧率建议手动设置");
                    }
                    namevideo = MuxMp4VideoInputTextBox.Text;
                    MuxMp4OutputTextBox.Text = FileString.ChangeExt(MuxMp4VideoInputTextBox.Text, "_Mux.mp4");
                }
            }
            catch (Exception ex)
            {
                MuxMp4VideoInputTextBox.Text = string.Empty;
                MessageBoxExtension.ShowErrorMessage(ex.Message);
            }
        }

        private void txtaudio_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (MuxMp4AudioInputTextBox.Text.Trim().Length > 0)
                {
                    if (!File.Exists(MuxMp4AudioInputTextBox.Text.Trim()))
                    {
                        throw new Exception("输入文件: \r\n\r\n" + MuxMp4AudioInputTextBox.Text.Trim() + "\r\n\r\n不存在!");
                    }
                    string inputExt = Path.GetExtension(MuxMp4AudioInputTextBox.Text.Trim()).ToLower();
                    if (inputExt != ".mp4"
                            && inputExt != ".aac" //ADIF or RAW formats not supported
                            && inputExt != ".mp3"
                            && inputExt != ".m4a"
                            && inputExt != ".mp2"
                            && inputExt != ".ac3")
                    {
                        throw new Exception("输入文件: \r\n\r\n" + MuxMp4AudioInputTextBox.Text.Trim() + "\r\n\r\n是一个mp4box不支持的音频文件!");
                    }
                    nameaudio = MuxMp4AudioInputTextBox.Text;
                }
            }
            catch (Exception ex)
            {
                MuxMp4AudioInputTextBox.Text = string.Empty;
                MessageBoxExtension.ShowErrorMessage(ex.Message);
            }
        }

        private void txtout_TextChanged(object sender, EventArgs e)
        {
            nameout = MuxMp4OutputTextBox.Text;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
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

        private void txtvideo4_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(MiscMiscVideoInputTextBox.Text.ToString()))
            {
                namevideo4 = MiscMiscVideoInputTextBox.Text;
                //string finish = namevideo4.Insert(namevideo4.LastIndexOf(".")-1,"");
                //string ext = namevideo4.Substring(namevideo4.LastIndexOf(".") + 1, 3);
                //finish += "_clip." + ext;
                string finish = namevideo4.Insert(namevideo4.LastIndexOf("."), "_output");
                MiscMiscVideoOutputTextBox.Text = finish;
            }
        }

        private void txtout5_TextChanged(object sender, EventArgs e)
        {
            nameout5 = MiscMiscVideoOutputTextBox.Text;
        }

        private void btnvideo4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.VIDEO_6); //"视频(*.mp4;*.flv;*.mkv)|*.mp4;*.flv;*.mkv|所有文件(*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                namevideo4 = openFileDialog1.FileName;
                MiscMiscVideoInputTextBox.Text = namevideo4;
            }
        }

        private void btnout5_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.VIDEO_1); //"视频(*.*)|*.*";
            DialogResult result = savefile.ShowDialog();
            if (result == DialogResult.OK)
            {
                nameout5 = savefile.FileName;
                MiscMiscVideoOutputTextBox.Text = nameout5;
            }
        }

        #region Settings

        /// <summary>
        /// 还原默认参数
        /// </summary>
        private void InitParameter()
        {
            #region Video Tab

            VideoCrfNumericUpDown.Value = 23.5m;
            VideoBitrateNumericUpDown.Value = 800;
            VideoAudioParameterTextBox.Text = "--abitrate 128";
            VideoAudioModeComboBox.SelectedIndex = 0;
            VideoDemuxerComboBox.SelectedIndex = 0;
            VideoWidthNumericUpDown.Value = 0;
            VideoHeightNumericUpDown.Value = 0;
            VideoCustomParameterTextBox.Text = "";
            ConfigX264PriorityComboBox.SelectedIndex = 2;
            VideoFramesNumericUpDown.Value = 0;
            VideoSeekNumericUpDown.Value = 0;
            VideoModeCrfRadioButton.Checked = true;
            VideoAutoShutdownCheckBox.Checked = false;

            #endregion Video Tab

            #region Audio Tab

            AudioEncoderComboBox.SelectedIndex = 0;
            AudioPresetComboBox.SelectedIndex = 0;
            AudioBitrateComboBox.Text = "128";
            AudioAudioModeBitrateRadioButton.Checked = true;

            #endregion Audio Tab

            #region General Tab

            MiscOnePicBitrateNumericUpDown.Value = 128;
            MiscOnePicFpsNumericUpDown.Value = 1;
            MiscOnePicCrfNumericUpDown.Value = 24;

            MiscBlackFpsNumericUpDown.Value = 1;
            MiscBlackCrfNumericUpDown.Value = 51;
            MiscBlackBitrateNumericUpDown.Value = 900;

            MiscMiscBeginTimeMaskedTextBox.Text = "000000";
            MiscMiscEndTimeMaskedTextBox.Text = "000020";

            MiscMiscTransposeComboBox.SelectedIndex = 1;

            #endregion General Tab

            #region Mux Tab

            MuxMp4FpsComboBox.SelectedIndex = 0;
            MuxMp4ParComboBox.SelectedIndex = 0;
            MuxConvertAacEncoderComboBox.SelectedIndex = 0;
            MuxConvertFormatComboBox.Text = "flv";

            #endregion Mux Tab

            #region AVS Tab

            AvsIncludeAudioCheckBox.Checked = false;

            #endregion AVS Tab

            #region Setup Tab

            ConfigUiSplashScreenCheckBox.Checked = true;
            ConfigUiTrayModeCheckBox.Checked = false;
            ConfigX264PriorityComboBox.SelectedIndex = 2;
            ConfigX264ThreadsComboBox.SelectedIndex = 0;
            ConfigFunctionDeleteTempFileCheckBox.Checked = true;
            ConfigFunctionAutoCheckUpdateCheckBox.Checked = true;
            ConfigFunctionEnableX265CheckBox.Checked = false;

            #endregion Setup Tab
        }

        private void LoadSettings()
        {
            try
            {
                //load settings
                VideoCrfNumericUpDown.Value = Convert.ToDecimal(ConfigurationManager.AppSettings["x264CRF"]);
                VideoBitrateNumericUpDown.Value = Convert.ToDecimal(ConfigurationManager.AppSettings["x264Bitrate"]);
                VideoAudioParameterTextBox.Text = ConfigurationManager.AppSettings["x264AudioParameter"];
                VideoAudioModeComboBox.SelectedIndex = Convert.ToInt32(ConfigurationManager.AppSettings["x264AudioMode"]);
                if (int.Parse(ConfigurationManager.AppSettings["x264Exe"]) > VideoEncoderComboBox.Items.Count - 1)
                    VideoEncoderComboBox.SelectedIndex = 0;
                else
                    VideoEncoderComboBox.SelectedIndex = Convert.ToInt32(ConfigurationManager.AppSettings["x264Exe"]);
                VideoDemuxerComboBox.SelectedIndex = Convert.ToInt32(ConfigurationManager.AppSettings["x264Demuxer"]);
                VideoWidthNumericUpDown.Value = Convert.ToDecimal(ConfigurationManager.AppSettings["x264Width"]);
                VideoHeightNumericUpDown.Value = Convert.ToDecimal(ConfigurationManager.AppSettings["x264Height"]);
                VideoCustomParameterTextBox.Text = ConfigurationManager.AppSettings["x264CustomParameter"];
                ConfigX264PriorityComboBox.SelectedIndex = Convert.ToInt32(ConfigurationManager.AppSettings["x264Priority"]);
                ConfigX264ExtraParameterTextBox.Text = ConfigurationManager.AppSettings["x264ExtraParameter"];
                AvsScriptTextBox.Text = ConfigurationManager.AppSettings["AVSScript"];
                AudioEncoderComboBox.SelectedIndex = Convert.ToInt32(ConfigurationManager.AppSettings["AudioEncoder"]);
                AudioBitrateComboBox.Text = ConfigurationManager.AppSettings["AudioBitrate"];
                MiscOnePicBitrateNumericUpDown.Value = Convert.ToDecimal(ConfigurationManager.AppSettings["OnePicAudioBitrate"]);
                MiscOnePicFpsNumericUpDown.Value = Convert.ToDecimal(ConfigurationManager.AppSettings["OnePicFPS"]);
                MiscOnePicCrfNumericUpDown.Value = Convert.ToDecimal(ConfigurationManager.AppSettings["OnePicCRF"]);
                MiscBlackFpsNumericUpDown.Value = Convert.ToDecimal(ConfigurationManager.AppSettings["BlackFPS"]);
                MiscBlackCrfNumericUpDown.Value = Convert.ToDecimal(ConfigurationManager.AppSettings["BlackCRF"]);
                MiscBlackBitrateNumericUpDown.Value = Convert.ToDecimal(ConfigurationManager.AppSettings["BlackBitrate"]);
                ConfigFunctionDeleteTempFileCheckBox.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["SetupDeleteTempFile"]);
                ConfigFunctionAutoCheckUpdateCheckBox.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["CheckUpdate"]);
                ConfigX264ThreadsComboBox.SelectedIndex = Convert.ToInt32(ConfigurationManager.AppSettings["x264Threads"]);
                ConfigFunctionEnableX265CheckBox.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["x265Enable"]);
                ConfigUiTrayModeCheckBox.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["TrayMode"]);
                ConfigUiSplashScreenCheckBox.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["SplashScreen"]);
                ConfigFunctionVideoPlayerTextBox.Text = ConfigurationManager.AppSettings["PreviewPlayer"];
                string SubLangExt = Convert.ToString(ConfigurationManager.AppSettings["SubLanguageExtension"]);
                MuxConvertFormatComboBox.SelectedIndex = Convert.ToInt32(ConfigurationManager.AppSettings["MuxFormat"]);
                VideoBatchSubtitleLanguage.DataSource = SubLangExt.Split(',');
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

                if (ConfigFunctionAutoCheckUpdateCheckBox.Checked && Network.IsConnectInternet())
                {
                    DateTime d;
                    bool f;
                    CheckUpadateDelegate checkUpdateDelegate = CheckUpdate;
                    checkUpdateDelegate.BeginInvoke(out d, out f, new AsyncCallback(CheckUpdateCallBack), null);
                }
                x264ExeComboBox_SelectedIndexChanged(null, null);
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

        #endregion

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

        private void Form1_Load(object sender, EventArgs e)
        {
            int processorNumber = Environment.ProcessorCount;

            ConfigX264ThreadsComboBox.Items.Add("auto");
            for (int i = 1; i <= 16; i++)
            {
                ConfigX264ThreadsComboBox.Items.Add(i.ToString());
            }
            //Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("zh-TW");
            //use YAHEI in VistaOrNewer
            //if (IsWindowsVistaOrNewer)
            //{
            //    FontFamily myFontFamily = new FontFamily("微软雅黑"); //采用哪种字体
            //    Font myFont = new Font(myFontFamily, 9, FontStyle.Regular); //字是那种字体，显示的风格
            //    this.Font = myFont;
            //}

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
            if (string.IsNullOrEmpty(FileString.CheckAviSynth()))
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
            ReleaseDateLabel.Text = ReleaseDate.ToString("yyyy-M-d");

            // load Help Text
            if (File.Exists(startpath + "\\help.rtf"))
            {
                HelpContentRichTextBox.LoadFile(startpath + "\\help.rtf");
            }

            LoadSettings();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.VIDEO_2);//"视频(*.mkv)|*.mkv";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                namevideo6 = openFileDialog1.FileName;
                ExtractMkvInputTextBox.Text = namevideo6;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (namevideo6 == "")
            {
                MessageBoxExtension.ShowErrorMessage("请选择视频文件");
            }
            else
            {
                mkvextract = workPath + "\\ mkvextract.exe tracks \"" + namevideo6 + "\" 1:video.h264 2:audio.aac";
                batpath = workPath + "\\mkvextract.bat";
                File.WriteAllText(batpath, mkvextract, Encoding.Default);
                Process.Start(batpath);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.VIDEO_3); //"视频(*.mp4)|*.mp4|所有文件(*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                namevideo5 = openFileDialog1.FileName;
                MuxMkvVideoInputTextBox.Text = namevideo5;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.AUDIO_1); //"音频(*.mp3)|*.mp3|音频(*.aac)|*.aac|所有文件(*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                nameaudio3 = openFileDialog1.FileName;
                MuxMkvAudioInputTextBox.Text = nameaudio3;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.VIDEO_2); //"视频(*.mkv)|*.mkv";
            DialogResult result = savefile.ShowDialog();
            if (result == DialogResult.OK)
            {
                nameout6 = savefile.FileName;
                MuxMkvOutputTextBox.Text = nameout6;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (namevideo5 == "")
            {
                MessageBoxExtension.ShowErrorMessage("请选择视频文件");
            }
            else if (nameaudio3 == "")
            {
                MessageBoxExtension.ShowErrorMessage("请选择音频文件");
            }
            else if (nameout6 == "")
            {
                MessageBoxExtension.ShowErrorMessage("请选择输出文件");
            }
            else
            {
                mkvmerge = workPath + "\\mkvmerge.exe -o \"" + nameout6 + "\"   \"" + namevideo5 + "\"   \"" + nameaudio3 + "\"";
                batpath = workPath + "\\mkvmerge.bat";
                File.WriteAllText(batpath, mkvmerge, Encoding.Default);
                Process.Start(batpath);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.ALL); //"所有文件(*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                namevideo5 = openFileDialog1.FileName;
                MuxMkvVideoInputTextBox.Text = namevideo5;
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.VIDEO_2); //"视频(*.mkv)|*.mkv";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                namevideo6 = openFileDialog1.FileName;
                ExtractMkvInputTextBox.Text = namevideo6;
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            if (namevideo5 == "" && nameaudio3 == "")
            {
                MessageBoxExtension.ShowErrorMessage("请选择文件");
            }
            else
            {
                if (MuxMkvAudioInputTextBox.Text != "" && MuxMkvSubtitleTextBox.Text != "")
                {
                    mkvmerge = "\"" + workPath + "\\mkvmerge.exe\" -o \"" + nameout6 + "\" \"" + namevideo5 + "\" \"" + nameaudio3 + "\" \"" + namesub + "\"";
                }
                if (MuxMkvAudioInputTextBox.Text == "" && MuxMkvSubtitleTextBox.Text == "")
                {
                    mkvmerge = "\"" + workPath + "\\mkvmerge.exe\" -o \"" + nameout6 + "\" \"" + namevideo5 + "\"";
                }
                if (MuxMkvAudioInputTextBox.Text != "" && MuxMkvSubtitleTextBox.Text == "")
                {
                    mkvmerge = "\"" + workPath + "\\mkvmerge.exe\" -o \"" + nameout6 + "\" \"" + namevideo5 + "\" \"" + nameaudio3 + "\"";
                }
                if (MuxMkvAudioInputTextBox.Text == "" && MuxMkvSubtitleTextBox.Text != "")
                {
                    mkvmerge = "\"" + workPath + "\\mkvmerge.exe\" -o \"" + nameout6 + "\" \"" + namevideo5 + "\" \"" + namesub + "\"";
                }
                mkvmerge += "\r\ncmd";
                batpath = workPath + "\\mkvmerge.bat";
                File.WriteAllText(batpath, mkvmerge, Encoding.Default);
                LogRecord(mkvmerge);
                Process.Start(batpath);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.VIDEO_2); //"视频(*.mkv)|*.mkv";
            DialogResult result = savefile.ShowDialog();
            if (result == DialogResult.OK)
            {
                nameout6 = savefile.FileName;
                MuxMkvOutputTextBox.Text = nameout6;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.AUDIO_2); //"音频(*.mp3;*.aac;*.ac3)|*.mp3;*.aac;*.ac3|所有文件(*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                nameaudio3 = openFileDialog1.FileName;
                MuxMkvAudioInputTextBox.Text = nameaudio3;
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.SUBTITLE_2); //"字幕(*.ass;*.ssa;*.srt;*.idx;*.sup)|*.ass;*.ssa;*.srt;*.idx;*.sup|所有文件(*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                namesub = openFileDialog1.FileName;
                MuxMkvSubtitleTextBox.Text = namesub;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (namevideo6 == "")
            {
                MessageBoxExtension.ShowErrorMessage("请选择视频文件");
            }
            else
            {
                int i = namevideo6.IndexOf(".mkv");
                string mkvname = namevideo6.Remove(i);
                mkvextract = "\"" + workPath + "\\mkvextract.exe\" tracks \"" + namevideo6 + "\" 1:\"" + mkvname + "_video.h264\" 2:\"" + mkvname + "_audio.aac\"";
                batpath = workPath + "\\mkvextract.bat";
                File.WriteAllText(batpath, mkvextract, Encoding.Default);
                Process.Start(batpath);
            }
        }

        private void txtvideo5_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(MuxMkvVideoInputTextBox.Text.ToString()))
            {
                namevideo5 = MuxMkvVideoInputTextBox.Text;
                string finish = namevideo5.Remove(namevideo5.LastIndexOf("."));
                finish += "_mkv封装.mkv";
                MuxMkvOutputTextBox.Text = finish;
            }
        }

        private void txtaudio3_TextChanged(object sender, EventArgs e)
        {
            nameaudio3 = MuxMkvAudioInputTextBox.Text;
        }

        private void txtsub_TextChanged(object sender, EventArgs e)
        {
            namesub = MuxMkvSubtitleTextBox.Text;
        }

        private void txtout6_TextChanged_1(object sender, EventArgs e)
        {
            nameout6 = MuxMkvOutputTextBox.Text;
        }

        private void txtvideo6_TextChanged(object sender, EventArgs e)
        {
            namevideo6 = ExtractMkvInputTextBox.Text;
        }

        private void btnAutoAdd_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.ALL); //"所有文件(*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                VideoBatchItemListbox.Items.AddRange(openFileDialog1.FileNames);
            }
            openFileDialog1.Multiselect = false;
        }

        private void btnAutoDel_Click(object sender, EventArgs e)
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

        private void btnAutoClear_Click(object sender, EventArgs e)
        {
            VideoBatchItemListbox.Items.Clear();
        }

        private void lbAuto_DragDrop(object sender, DragEventArgs e)
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

        private void lbAuto_DragEnter(object sender, DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(DataFormats.FileDrop))
            //    e.Effect = DragDropEffects.All;
            //else e.Effect = DragDropEffects.None;
        }

        private void lbAuto_DragOver(object sender, DragEventArgs e)
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

        private void lbAuto_MouseDown(object sender, MouseEventArgs e)
        {
            indexofsource = ((ListBox)sender).IndexFromPoint(e.X, e.Y);
            if (indexofsource == 65535)
                return;
            if (indexofsource != ListBox.NoMatches)
            {
                ((ListBox)sender).DoDragDrop(((ListBox)sender).Items[indexofsource].ToString(), DragDropEffects.All);
            }
        }

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
            string sub = (VideoBatchSubtitleCheckBox.Checked) ? GetSubtitlePath(input) : string.Empty;

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

        private void btnBatchAuto_Click(object sender, EventArgs e)
        {
            if (VideoBatchItemListbox.Items.Count == 0)
            {
                MessageBoxExtension.ShowErrorMessage("请输入视频！");
                return;
            }

            if (VideoEncoderComboBox.SelectedIndex == -1)
            {
                MessageBoxExtension.ShowErrorMessage("请选择X264程序");
                return;
            }

            if (AudioEncoderComboBox.SelectedIndex != 0 && AudioEncoderComboBox.SelectedIndex != 1 && AudioEncoderComboBox.SelectedIndex != 5)
            {
                DialogResult r = MessageBoxExtension.ShowQuestion("音频页面中的编码器未采用AAC将可能导致压制失败，建议将编码器改为QAAC、NeroAAC或FDKAAC。是否继续压制？", "提示");
                if (r == DialogResult.No)
                    return;
            }

            FileString.ensureDirectoryExists(tempfilepath);
            string bat = string.Empty;
            for (int i = 0; i < this.VideoBatchItemListbox.Items.Count; i++)
            {
                string input = VideoBatchItemListbox.Items[i].ToString();
                string output;
                if (Directory.Exists(VideoBatchOutputFolderTextBox.Text))
                    output = VideoBatchOutputFolderTextBox.Text + "\\" + Path.GetFileNameWithoutExtension(input) + "_batch." + VideoBatchFormatComboBox.Text;
                else
                    output = FileString.ChangeExt(input, "_batch." + VideoBatchFormatComboBox.Text);
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

        private void lbffmpeg_MouseDown(object sender, MouseEventArgs e)
        {
            indexofsource = ((ListBox)sender).IndexFromPoint(e.X, e.Y);
            if (indexofsource != ListBox.NoMatches)
            {
                ((ListBox)sender).DoDragDrop(((ListBox)sender).Items[indexofsource].ToString(), DragDropEffects.All);
            }
        }

        private void lbffmpeg_DragDrop(object sender, DragEventArgs e)
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

        private void lbffmpeg_DragOver(object sender, DragEventArgs e)
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

        private void btnffmpegAdd_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.ALL); //"所有文件(*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                MuxConvertItemListBox.Items.AddRange(openFileDialog1.FileNames);
            }
            openFileDialog1.Multiselect = false;
        }

        private void btnffmpegDel_Click(object sender, EventArgs e)
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

        private void btnffmpegClear_Click(object sender, EventArgs e)
        {
            MuxConvertItemListBox.Items.Clear();
        }

        private void btnBatchMP4_Click(object sender, EventArgs e)
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
            else MessageBoxExtension.ShowErrorMessage("请输入视频！");
        }

        private void txtvideo8_TextChanged(object sender, EventArgs e)
        {
            namevideo8 = ExtractFlvInputTextBox.Text;
        }

        private void btnvextract8_Click(object sender, EventArgs e)
        {
            //FLV vcopy
            ExtractAV(namevideo8, "v", 0);
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

        private void btnaextract8_Click(object sender, EventArgs e)
        {
            //FLV acopy
            ExtractAV(namevideo8, "a", 0);
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

        private void btnvideo8_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.VIDEO_4); //"视频(*.flv;*.hlv)|*.flv;*.hlv";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                namevideo8 = openFileDialog1.FileName;
                ExtractFlvInputTextBox.Text = namevideo;
            }
        }

        private void btnpreview9_Click(object sender, EventArgs e)
        {
            if (AvsScriptTextBox.Text != "")
            {
                string filepath = workPath + "\\temp.avs";
                File.WriteAllText(filepath, AvsScriptTextBox.Text.ToString(), Encoding.Default);
                if (File.Exists(ConfigFunctionVideoPlayerTextBox.Text))
                {
                    Process.Start(ConfigFunctionVideoPlayerTextBox.Text, filepath);
                }
                else
                {
                    string ffplayer = Path.Combine(workPath, "ffplay.exe");
                    if (File.Exists(ffplayer))
                        Process.Start(FileString.FormatPath(ffplayer), " -i " + FileString.FormatPath(filepath));
                    else
                    {
                        PreviewForm pf = new PreviewForm();
                        pf.Show();
                        pf.axWindowsMediaPlayer1.URL = filepath;
                    }
                }
            }
            else
            {
                MessageBoxExtension.ShowErrorMessage("请输入正确的AVS脚本！");
            }
        }

        private void txtout_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (File.Exists(MuxMp4OutputTextBox.Text.ToString()))
            {
                Process.Start(MuxMp4OutputTextBox.Text.ToString());
            }
        }

        private void txtout3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (File.Exists(AudioOutputTextBox.Text.ToString()))
            {
                Process.Start(AudioOutputTextBox.Text.ToString());
            }
        }

        private void txtout6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (File.Exists(MuxMkvOutputTextBox.Text.ToString()))
            {
                Process.Start(MuxMkvOutputTextBox.Text.ToString());
            }
        }

        private void txtout9_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (File.Exists(AvsOutputTextBox.Text.ToString()))
            {
                Process.Start(AvsOutputTextBox.Text.ToString());
            }
        }

        private void txtvideo9_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(AvsVideoInputTextBox.Text.ToString()))
            {
                namevideo9 = AvsVideoInputTextBox.Text;
                string finish = namevideo9.Remove(namevideo9.LastIndexOf("."));
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

        private void txtsub9_TextChanged(object sender, EventArgs e)
        {
            namesub9 = AvsSubtitleInputTextBox.Text;
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

        private void txtout9_TextChanged(object sender, EventArgs e)
        {
            nameout9 = AvsOutputTextBox.Text;
        }

        private void btnAVS9_Click(object sender, EventArgs e)
        {
            VideoDemuxerComboBox.SelectedIndex = 0; //压制AVS始终使用分离器为auto

            if (string.IsNullOrEmpty(nameout9))
            {
                MessageBoxExtension.ShowErrorMessage("请选择输出文件");
                return;
            }

            if (Path.GetExtension(nameout9).ToLower() != ".mp4")
            {
                MessageBoxExtension.ShowErrorMessage("仅支持MP4输出", "不支持的输出格式");
                return;
            }

            if (File.Exists(AvsOutputTextBox.Text.Trim()))
            {
                DialogResult dgs = MessageBoxExtension.ShowQuestion("目标文件:\r\n\r\n" + AvsOutputTextBox.Text.Trim() + "\r\n\r\n已经存在,是否覆盖继续压制？", "目标文件已经存在");
                if (dgs == DialogResult.No) return;
            }

            if (string.IsNullOrEmpty(FileString.CheckAviSynth()) && string.IsNullOrEmpty(FileString.CheckinternalAviSynth()))
            {
                if (MessageBoxExtension.ShowQuestion("检测到本机未安装avisynth无法继续压制，是否去下载安装", "avisynth未安装") == DialogResult.Yes)
                    Process.Start("http://sourceforge.net/projects/avisynth2/");
                return;
            }

            string inputName = Path.GetFileNameWithoutExtension(namevideo9);
            string tempVideo = Path.Combine(tempfilepath, inputName + "_vtemp.mp4");
            string tempAudio = Path.Combine(tempfilepath, inputName + "_atemp" + getAudioExt());
            FileString.ensureDirectoryExists(tempfilepath);
            // 避免编码失败最后混流使用上次的同名临时文件造成编码成功的假象
            if (File.Exists(tempVideo)) File.Delete(tempVideo);
            if (File.Exists(tempAudio)) File.Delete(tempAudio);

            string filepath = tempavspath;
            //string filepath = workpath + "\\temp.avs";
            File.WriteAllText(filepath, AvsScriptTextBox.Text, Encoding.Default);

            //检测是否含有音频
            bool hasAudio = false;
            string audio = new MediaInfoWrapper(namevideo9).a_format;
            if (!string.IsNullOrEmpty(audio)) { hasAudio = true; }

            //audio
            if (AvsIncludeAudioCheckBox.Checked && hasAudio)
            {
                if (!File.Exists(AvsVideoInputTextBox.Text))
                {
                    MessageBoxExtension.ShowErrorMessage("请选择视频文件");
                    return;
                }
                aextract = audiobat(namevideo9, tempAudio);
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
                    x264 = x264.Replace(tempVideo, nameout9);
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
                    x264 += "\r\n\"" + workPath + "\\mp4box.exe\"  -add  \"" + tempVideo + "#trackID=1:name=\" -new \"" + nameout9 + "\" \r\n";
                    x264 += "del \"" + tempVideo + "\"";
                }
            }
            //mux
            if (AvsIncludeAudioCheckBox.Checked && hasAudio) //如果包含音频
                mux = boxmuxbat(tempVideo, tempAudio, nameout9);
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

        private void btnout9_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.VIDEO_3); //"视频(*.mp4)|*.mp4";
            DialogResult result = savefile.ShowDialog();
            if (result == DialogResult.OK)
            {
                AvsOutputTextBox.Text = nameout9 = savefile.FileName;
            }
        }

        private void button6_Click_2(object sender, EventArgs e)
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
            avs += string.Format("\r\nLWLibavVideoSource(\"{0}\",23.976,convertFPS=True)\r\nConvertToYV12()\r\nCrop(0,0,0,0)\r\nAddBorders(0,0,0,0)\r\n" + "TextSub(\"{1}\")\r\n#LanczosResize(1280,960)\r\n", namevideo9, namesub9);
            //avs += "\r\nDirectShowSource(\"" + namevideo9 + "\",23.976,convertFPS=True)\r\nConvertToYV12()\r\nCrop(0,0,0,0)\r\nAddBorders(0,0,0,0)\r\n" + "TextSub(\"" + namesub9 + "\")\r\n#LanczosResize(1280,960)\r\n";
            AvsScriptTextBox.Text = avs;
            avs = "";
        }

        private void txtvideo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (File.Exists(MuxMp4VideoInputTextBox.Text.ToString()))
            {
                Process.Start(MuxMp4VideoInputTextBox.Text.ToString());
            }
        }

        private void txtvideo4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (File.Exists(MiscMiscVideoInputTextBox.Text.ToString()))
            {
                Process.Start(MiscMiscVideoInputTextBox.Text.ToString());
            }
        }

        private void txtout5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (File.Exists(MiscMiscVideoOutputTextBox.Text.ToString()))
            {
                Process.Start(MiscMiscVideoOutputTextBox.Text.ToString());
            }
        }

        private void txtvideo8_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (File.Exists(ExtractFlvInputTextBox.Text.ToString()))
            {
                Process.Start(ExtractFlvInputTextBox.Text.ToString());
            }
        }

        private void txtvideo9_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (File.Exists(AvsVideoInputTextBox.Text.ToString()))
            {
                Process.Start(AvsVideoInputTextBox.Text.ToString());
            }
        }

        private void txtvideo6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (File.Exists(ExtractMkvInputTextBox.Text.ToString()))
            {
                Process.Start(ExtractMkvInputTextBox.Text.ToString());
            }
        }

        private void txtvideo5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (File.Exists(MuxMkvVideoInputTextBox.Text.ToString()))
            {
                Process.Start(MuxMkvVideoInputTextBox.Text.ToString());
            }
        }

        private void txtaudio3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (File.Exists(MuxMkvAudioInputTextBox.Text.ToString()))
            {
                Process.Start(MuxMkvAudioInputTextBox.Text.ToString());
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

        private void btnsub9_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.SUBTITLE_2); //"字幕(*.ass;*.ssa;*.srt;*.idx;*.sup)|*.ass;*.ssa;*.srt;*.idx;*.sup|所有文件(*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                namesub9 = openFileDialog1.FileName;
                AvsSubtitleInputTextBox.Text = namesub9;
            }
        }

        private void btnvideo9_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.VIDEO_7); //"视频(*.mp4;*.flv;*.mkv;*.wmv)|*.mp4;*.flv;*.mkv;*.wmv|所有文件(*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                namevideo9 = openFileDialog1.FileName;
                AvsVideoInputTextBox.Text = namevideo9;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AvsScriptTextBox.Clear();
        }

        private void btnClip_Click(object sender, EventArgs e)
        {
            if (namevideo4 == "")
            {
                MessageBoxExtension.ShowErrorMessage("请选择视频文件");
            }
            else if (nameout5 == "")
            {
                MessageBoxExtension.ShowErrorMessage("请选择输出文件");
            }
            else
            {
                int[] begin = new int[] { int.Parse(MiscMiscBeginTimeMaskedTextBox.Text.ToString().Substring(0, 2)),
                                          int.Parse(MiscMiscBeginTimeMaskedTextBox.Text.ToString().Substring(3, 2)),
                                          int.Parse(MiscMiscBeginTimeMaskedTextBox.Text.ToString().Substring(6, 2))
                                        };
                int[] end = new int[] { int.Parse(MiscMiscEndTimeMaskedTextBox.Text.ToString().Substring(0, 2)),
                                        int.Parse(MiscMiscEndTimeMaskedTextBox.Text.ToString().Substring(3, 2)),
                                        int.Parse(MiscMiscEndTimeMaskedTextBox.Text.ToString().Substring(6, 2))
                                      };
                clip = string.Format(@"""{0}\ffmpeg.exe"" -ss {1} -t {2} -y -i ""{3}"" -c copy ""{4}""", workPath, MiscMiscBeginTimeMaskedTextBox.Text, timeSubtract(begin, end), namevideo4, nameout5) + Environment.NewLine + "cmd";
                //clip = string.Format(@"""{0}\ffmpeg.exe"" -i ""{3}"" -ss {1} -to {2} -y  -c copy ""{4}""", workPath, maskb.Text, maske.Text, namevideo4, nameout5) + Environment.NewLine + "cmd";
                batpath = workPath + "\\clip.bat";
                LogRecord(clip);
                File.WriteAllText(batpath, clip, Encoding.Default);
                Process.Start(batpath);
            }
        }

        private void cbX264_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VideoEncoderComboBox.Items != null)
            {
                string encType = VideoEncoderComboBox.SelectedItem.ToString().Contains("x265") ? "x265" : "x264";
                XElement xel = preset.GetVideoPreset(encType).Elements()
                                  .Where(x => x.Attribute("Name").Value == VideoPresetComboBox.Text).First();
                VideoCustomParameterTextBox.Text = xel.Value;
            }
        }

        private void cbFPS_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ext = Path.GetExtension(namevideo).ToLower();
            if (MuxMp4FpsComboBox.SelectedIndex != 0 && ext != ".264" && ext != ".h264" && ext != ".hevc")
            {
                MessageBoxExtension.ShowWarningMessage("只有扩展名为.264 .h264 .hevc的流文件设置帧率(fps)才有效");
                MuxMp4FpsComboBox.SelectedIndex = 0;
            }
        }

        private void btnMIopen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.VIDEO_6); //"视频(*.mp4;*.flv;*.mkv)|*.mp4;*.flv;*.mkv|所有文件(*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                MIvideo = openFileDialog1.FileName;
                MediaInfoTextBox.Text = GetMediaInfoString(MIvideo);
            }
        }

        private void btnMIplay_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(MIvideo);
            }
            catch
            { }
        }

        private void btnMIcopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(MItext);
        }

        private void btnvideo7_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.VIDEO_2); //"视频(*.mkv)|*.mkv";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                namevideo6 = openFileDialog1.FileName;
                ExtractMkvInputTextBox.Text = namevideo6;
            }
        }

        private void btnextract7_Click(object sender, EventArgs e)
        {
            //MKV抽0
            ExtractTrack(namevideo6, 0);
        }

        private void MkvExtract1Button_Click(object sender, EventArgs e)
        {
            //MKV 抽1
            ExtractTrack(namevideo6, 1);
        }

        private void MkvExtract2Button_Click(object sender, EventArgs e)
        {
            //MKV 抽2
            ExtractTrack(namevideo6, 2);
        }

        private void MkvExtract3Button_Click(object sender, EventArgs e)
        {
            //MKV 抽3
            ExtractTrack(namevideo6, 3);
        }

        private void MkvExtract4Button_Click(object sender, EventArgs e)
        {
            //MKV 抽4
            ExtractTrack(namevideo6, 4);
        }

        private void txtMI_TextChanged(object sender, EventArgs e)
        {
            MItext = MediaInfoTextBox.Text;
        }

        private void txtAVScreate_Click(object sender, EventArgs e)
        {
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.sosg.net/read.php?tid=480646");
        }

        private void btnaextract2_Click(object sender, EventArgs e)
        {
            //MP4 抽取音频2
            ExtractAV(namevideo, "a", 1);
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

        private void btnaextract3_Click(object sender, EventArgs e)
        {
            //MP4 抽取音频3
            ExtractAV(namevideo, "a", 2);
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

        private void txtvideo6_TextChanged_1(object sender, EventArgs e)
        {
            if (File.Exists(ExtractMkvInputTextBox.Text.ToString()))
            {
                namevideo6 = ExtractMkvInputTextBox.Text;
            }
        }

        #region 帮助页面

        private void AboutBtn_Click(object sender, EventArgs e)
        {
            DateTime CompileDate = File.GetLastWriteTime(this.GetType().Assembly.Location); //获得程序编译时间
            QQMessageBox.Show(
                this,
                "主页：http://maruko.appinn.me/ \r\n编译日期：" + ReleaseDate.ToString() + "\r\n作者：小七、月儿、小丸",
                "关于",
                QQMessageBoxIcon.Information,
                QQMessageBoxButtons.OK);
        }

        private void HomePageBtn_Click(object sender, EventArgs e)
        {
            Process.Start("http://maruko.appinn.me/");
        }

        #endregion 帮助页面

        #region 视频页面

        private void x264VideoBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.VIDEO_8); //"视频(*.mp4;*.flv;*.mkv;*.avi;*.wmv;*.mpg;*.avs)|*.mp4;*.flv;*.mkv;*.avi;*.wmv;*.mpg;*.avs|所有文件(*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                namevideo2 = openFileDialog1.FileName;
                VideoInputTextBox.Text = namevideo2;
            }
        }

        private void x264OutBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.VIDEO_D_3); //"MPEG-4 视频(*.mp4)|*.mp4|Flash 视频(*.flv)|*.flv|Matroska 视频(*.mkv)|*.mkv|AVI 视频(*.avi)|*.avi|H.264 流(*.raw)|*.raw";
            savefile.FileName = Path.GetFileName(VideoOutputTextBox.Text);
            DialogResult result = savefile.ShowDialog();
            if (result == DialogResult.OK)
            {
                nameout2 = savefile.FileName;
                VideoOutputTextBox.Text = nameout2;
            }
        }

        private void x264SubBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.SUBTITLE_1); //"字幕(*.ass;*.ssa;*.srt)|*.ass;*.ssa;*.srt|所有文件(*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                namesub2 = openFileDialog1.FileName;
                VideoSubtitleTextBox.Text = namesub2;
            }
        }

        private void x264StartBtn_Click(object sender, EventArgs e)
        {
            #region validation

            if (string.IsNullOrEmpty(namevideo2))
            {
                MessageBoxExtension.ShowErrorMessage("请选择视频文件");
                return;
            }

            if (!string.IsNullOrEmpty(namesub2) && !File.Exists(namesub2))
            {
                MessageBoxExtension.ShowErrorMessage("字幕文件不存在，请重新选择");
                return;
            }

            if (string.IsNullOrEmpty(nameout2))
            {
                MessageBoxExtension.ShowErrorMessage("请选择输出文件");
                return;
            }

            if (VideoEncoderComboBox.SelectedIndex == -1)
            {
                MessageBoxExtension.ShowErrorMessage("请选择X264程序");
                return;
            }

            if (AudioEncoderComboBox.SelectedIndex != 0 && AudioEncoderComboBox.SelectedIndex != 1 && AudioEncoderComboBox.SelectedIndex != 5)
            {
                DialogResult r = MessageBoxExtension.ShowQuestion("音频页面中的编码器未采用AAC将可能导致压制失败，建议将编码器改为QAAC、NeroAAC或FDKAAC。是否继续压制？", "提示");
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
                DialogResult dgs = MessageBoxExtension.ShowQuestion("目标文件:\r\n\r\n" + VideoOutputTextBox.Text.Trim() + "\r\n\r\n已经存在,是否覆盖继续压制？", "目标文件已经存在");
                if (dgs == DialogResult.No) return;
            }

            //如果是AVS复制到C盘根目录
            if (Path.GetExtension(VideoInputTextBox.Text) == ".avs")
            {
                if (string.IsNullOrEmpty(FileString.CheckAviSynth()) && string.IsNullOrEmpty(FileString.CheckinternalAviSynth()))
                {
                    if (MessageBoxExtension.ShowQuestion("检测到本机未安装avisynth无法继续压制，是否去下载安装", "avisynth未安装") == DialogResult.Yes)
                        Process.Start("http://sourceforge.net/projects/avisynth2/");
                    return;
                }
                //if (File.Exists(tempavspath)) File.Delete(tempavspath);
                File.Copy(VideoInputTextBox.Text, tempavspath, true);
                namevideo2 = tempavspath;
                VideoDemuxerComboBox.SelectedIndex = 0; //压制AVS始终使用分离器为auto
            }

            #endregion validation

            string ext = Path.GetExtension(nameout2).ToLower();
            bool hasAudio = false;
            string inputName = Path.GetFileNameWithoutExtension(namevideo2);
            string tempVideo = Path.Combine(tempfilepath, inputName + "_vtemp.mp4");
            string tempAudio = Path.Combine(tempfilepath, inputName + "_atemp" + getAudioExt());
            FileString.ensureDirectoryExists(tempfilepath);
            // 避免编码失败最后混流使用上次的同名临时文件造成编码成功的假象
            if (File.Exists(tempVideo)) File.Delete(tempVideo);
            if (File.Exists(tempAudio)) File.Delete(tempAudio);

            #region Audio

            //检测是否含有音频
            string audio = new MediaInfoWrapper(namevideo2).a_format;
            if (!string.IsNullOrEmpty(audio))
                hasAudio = true;
            int audioMode = VideoAudioModeComboBox.SelectedIndex;
            if (!hasAudio && VideoAudioModeComboBox.SelectedIndex != 1)
            {
                DialogResult r = MessageBoxExtension.ShowQuestionWithCancel("原视频不包含音频流，音频模式是否改为无音频流？", "提示");
                if (r == DialogResult.Yes)
                    audioMode = 1;
                else if (r == DialogResult.Cancel)
                    return;
            }
            switch (audioMode)
            {
                case 0:
                    aextract = audiobat(namevideo2, tempAudio);
                    break;
                case 1:
                    aextract = string.Empty;
                    break;
                case 2:
                    if (audio.ToLower() == "aac")
                    {
                        tempAudio = Path.Combine(tempfilepath, inputName + "_atemp.aac");
                        aextract = ExtractAudio(namevideo2, tempAudio);
                    }
                    else
                    {
                        MessageBoxExtension.ShowInfoMessage("因音频编码非AAC故无法复制音频流，音频将被重编码。");
                        aextract = audiobat(namevideo2, tempAudio);
                    }
                    break;
                default:
                    break;
            }

            #endregion

            #region Video
            if (VideoEncoderComboBox.SelectedItem.ToString().ToLower().Contains("x264"))
            {
                if (x264mode == 2)
                    x264 = x264bat(namevideo2, tempVideo, 1, namesub2) + "\r\n" +
                           x264bat(namevideo2, tempVideo, 2, namesub2);
                else x264 = x264bat(namevideo2, tempVideo, 0, namesub2);
                if (audioMode == 1)
                    x264 = x264.Replace(tempVideo, nameout2);
            }
            else if (VideoEncoderComboBox.SelectedItem.ToString().ToLower().Contains("x265"))
            {
                tempVideo = Path.Combine(tempfilepath, inputName + "_vtemp.hevc");
                if (ext != ".mp4")
                {
                    MessageBoxExtension.ShowErrorMessage("不支持的格式输出,x265当前工具箱仅支持MP4输出");
                    return;
                }
                if (x264mode == 2)
                    x264 = x265bat(namevideo2, tempVideo, 1, namesub2) + "\r\n" +
                           x265bat(namevideo2, tempVideo, 2, namesub2);
                else x264 = x265bat(namevideo2, tempVideo, 0, namesub2);
                if (audioMode == 1)
                {
                    x264 += "\r\n\"" + workPath + "\\mp4box.exe\" -add  \"" + tempVideo + "#trackID=1:name=\" -new \"" + FileString.ChangeExt(nameout2, ".mp4") + "\" \r\n";
                    x264 += "del \"" + tempVideo + "\"";
                }
            }
            x264 += "\r\n";

            #endregion

            #region Mux

            //封装
            if (audioMode != 1)
            {
                if (ext == ".mp4")
                    mux = boxmuxbat(tempVideo, tempAudio, FileString.ChangeExt(nameout2, ext));
                else
                    mux = ffmuxbat(tempVideo, tempAudio, FileString.ChangeExt(nameout2, ext));
                x264 = aextract + x264 + mux + "\r\n"
                    + "del \"" + tempVideo + "\"\r\n"
                    + "del \"" + tempAudio + "\"\r\n";
            }
            x264 += "\r\necho ===== one file is completed! =====\r\n";

            #endregion

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

        private void x264AddPresetBtn_Click(object sender, EventArgs e)
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
                            MessageBoxExtension.ShowErrorMessage("预设名称已经存在", "预设名称重复");
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
                MessageBoxExtension.ShowErrorMessage("添加失败! Reason: " + ex.Message);
            }
        }

        private void x264DeletePresetBtn_Click(object sender, EventArgs e)
        {
            if (MessageBoxExtension.ShowQuestion("确定要删除这条预设参数？", "提示") == DialogResult.Yes)
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
                    MessageBoxExtension.ShowErrorMessage("删除失败! Reason: " + ex.Message);
                }
            }
        }

        private void x264Mode2RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            x264mode = 2;
            VideoBitrateLabel.Visible = true;
            VideoBitrateNumericUpDown.Visible = true;
            VideoCrfKbpsLabel.Visible = true;
            VideoWidthLabel.Visible = true;
            VideoHeightLabel.Visible = true;
            VideoWidthNumericUpDown.Visible = true;
            VideoHeightNumericUpDown.Visible = true;
            VideoMaintainResolutionCheckBox.Visible = true;
            VideoCrfLabel.Visible = false;
            VideoCrfNumericUpDown.Visible = false;
            VideoPresetLabel.Visible = false;
            VideoCustomParameterTextBox.Visible = false;
            VideoPresetComboBox.Visible = false;
            VideoAddPresetButton.Visible = false;
            VideoDeletePresetButton.Visible = false;
        }

        private void x264Mode3RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            x264mode = 0;
            VideoPresetLabel.Visible = true;
            VideoCustomParameterTextBox.Visible = true;
            VideoPresetComboBox.Visible = true;
            VideoAddPresetButton.Visible = true;
            VideoDeletePresetButton.Visible = true;
            VideoWidthLabel.Visible = false;
            VideoHeightLabel.Visible = false;
            VideoWidthNumericUpDown.Visible = false;
            VideoHeightNumericUpDown.Visible = false;
            VideoMaintainResolutionCheckBox.Visible = false;
            VideoBitrateLabel.Visible = false;
            VideoBitrateNumericUpDown.Visible = false;
            VideoCrfKbpsLabel.Visible = false;
            VideoCrfLabel.Visible = false;
            VideoCrfNumericUpDown.Visible = false;
        }

        private void x264Mode1RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            x264mode = 1;
            VideoCrfLabel.Visible = true;
            VideoCrfNumericUpDown.Visible = true;
            VideoWidthLabel.Visible = true;
            VideoHeightLabel.Visible = true;
            VideoWidthNumericUpDown.Visible = true;
            VideoHeightNumericUpDown.Visible = true;
            VideoMaintainResolutionCheckBox.Visible = true;
            VideoBitrateLabel.Visible = false;
            VideoBitrateNumericUpDown.Visible = false;
            VideoCrfKbpsLabel.Visible = false;
            VideoPresetLabel.Visible = false;
            VideoCustomParameterTextBox.Visible = false;
            VideoPresetComboBox.Visible = false;
            VideoAddPresetButton.Visible = false;
            VideoDeletePresetButton.Visible = false;
        }

        private void x264PriorityComboBox_SelectedIndexChanged(object sender, EventArgs e)
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

        private void x264VideoTextBox_TextChanged(object sender, EventArgs e)
        {
            string path = VideoInputTextBox.Text;
            if (File.Exists(path))
            {
                namevideo2 = path;
                int num = 1;
                string encType = "x264";
                if (VideoEncoderComboBox.SelectedItem != null)
                    encType = VideoEncoderComboBox.SelectedItem.ToString().Contains("x265") ? "x265" : "x264";
                VideoOutputTextBox.Text = FileString.ChangeExt(namevideo2, string.Format("_{0}.mp4", encType));
                while (namevideo2.Equals(VideoOutputTextBox.Text) || File.Exists(VideoOutputTextBox.Text))
                {
                    VideoOutputTextBox.Text = FileString.ChangeExt(namevideo2, string.Format("_new_file({0})_{1}.mp4", num, encType));
                    num++;
                }

                if (Path.GetExtension(namevideo2) != ".avs" && encType == "x264")
                {
                    string[] subExt = { ".ass", ".ssa", ".srt" };
                    foreach (string ext in subExt)
                    {
                        if (File.Exists(FileString.ChangeExt(namevideo2, ext)))
                        {
                            VideoSubtitleTextBox.Text = FileString.ChangeExt(namevideo2, ext);
                            break;
                        }
                        else
                            VideoSubtitleTextBox.Text = string.Empty;
                    }
                }

            }
        }

        private void x264OutTextBox_TextChanged(object sender, EventArgs e)
        {
            nameout2 = VideoOutputTextBox.Text;
        }

        private void x264SubTextBox_TextChanged(object sender, EventArgs e)
        {
            namesub2 = VideoSubtitleTextBox.Text;
        }

        private void x264BatchClearBtn_Click(object sender, EventArgs e)
        {
            VideoBatchItemListbox.Items.Clear();
        }

        private void x264BatchDeleteBtn_Click(object sender, EventArgs e)
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

        private void x264BatchAddBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.ALL); //"所有文件(*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                VideoBatchItemListbox.Items.AddRange(openFileDialog1.FileNames);
            }
            openFileDialog1.Multiselect = false;
        }

        #endregion 视频页面

        #region 音频界面

        // <summary>
        /// 是否安装 Apple Application Support
        /// </summary>
        /// <returns>true:安装 false:没有安装</returns>
        private bool isAppleAppSupportInstalled()
        {
            Microsoft.Win32.RegistryKey uninstallNode_1 = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"Software\Wow6432Node\Apple Inc.\Apple Application Support"); //x64 OS
            Microsoft.Win32.RegistryKey uninstallNode_2 = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"Software\Apple Inc.\Apple Application Support"); //x86 OS
            if (uninstallNode_1 != null || uninstallNode_2 != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void AudioEncoderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (AudioEncoderComboBox.SelectedIndex)
            {
                case 0:
                    if (File.Exists(AudioInputTextBox.Text))
                        AudioOutputTextBox.Text = FileString.ChangeExt(AudioInputTextBox.Text, "_AAC.mp4");
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
                        AudioOutputTextBox.Text = FileString.ChangeExt(AudioInputTextBox.Text, "_AAC.m4a");
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
                        AudioOutputTextBox.Text = FileString.ChangeExt(AudioInputTextBox.Text, "_WAV.wav");
                    AudioBitrateComboBox.Enabled = false;
                    AudioAudioModeBitrateRadioButton.Enabled = false;
                    AudioAudioModeCustomRadioButton.Enabled = false;
                    AudioPresetDeleteButton.Visible = false;
                    AudioPresetAddButton.Visible = false;
                    break;

                case 3:
                    if (File.Exists(AudioInputTextBox.Text))
                        AudioOutputTextBox.Text = FileString.ChangeExt(AudioInputTextBox.Text, "_ALAC.m4a");
                    AudioBitrateComboBox.Enabled = false;
                    AudioAudioModeBitrateRadioButton.Enabled = false;
                    AudioAudioModeCustomRadioButton.Enabled = false;
                    AudioPresetDeleteButton.Visible = false;
                    AudioPresetAddButton.Visible = false;
                    break;

                case 4:
                    if (File.Exists(AudioInputTextBox.Text))
                        AudioOutputTextBox.Text = FileString.ChangeExt(AudioInputTextBox.Text, "_FLAC.flac");
                    AudioBitrateComboBox.Enabled = false;
                    AudioAudioModeBitrateRadioButton.Enabled = false;
                    AudioAudioModeCustomRadioButton.Enabled = false;
                    AudioPresetDeleteButton.Visible = false;
                    AudioPresetAddButton.Visible = false;
                    break;

                case 5:
                    if (File.Exists(AudioInputTextBox.Text))
                        AudioOutputTextBox.Text = FileString.ChangeExt(AudioInputTextBox.Text, "_AAC.m4a");
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
                        AudioOutputTextBox.Text = FileString.ChangeExt(AudioInputTextBox.Text, "_AC3.ac3");
                    AudioBitrateComboBox.Enabled = true;
                    AudioAudioModeBitrateRadioButton.Enabled = true;
                    AudioAudioModeCustomRadioButton.Enabled = false;
                    AudioPresetDeleteButton.Visible = false;
                    AudioPresetAddButton.Visible = false;
                    break;

                case 7:
                    if (File.Exists(AudioInputTextBox.Text))
                        AudioOutputTextBox.Text = FileString.ChangeExt(AudioInputTextBox.Text, "_MP3.mp3");
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

        private void AudioListBox_DragDrop(object sender, DragEventArgs e)
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

        private void AudioListBox_DragOver(object sender, DragEventArgs e)
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

        private void AudioListBox_MouseDown(object sender, MouseEventArgs e)
        {
            indexofsource = ((ListBox)sender).IndexFromPoint(e.X, e.Y);
            if (indexofsource != ListBox.NoMatches)
            {
                ((ListBox)sender).DoDragDrop(((ListBox)sender).Items[indexofsource].ToString(), DragDropEffects.All);
            }
        }

        private void AudioBatchButton_Click(object sender, EventArgs e)
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
                    finish = FileString.ChangeExt(AudioBatchItemListBox.Items[i].ToString(), outname);
                    aac += audiobat(AudioBatchItemListBox.Items[i].ToString(), finish);
                    aac += "\r\n";
                }
                aac += "\r\ncmd";
                batpath = workPath + "\\aac.bat";
                File.WriteAllText(batpath, aac, Encoding.Default);
                LogRecord(aac);
                Process.Start(batpath);
            }
            else MessageBoxExtension.ShowErrorMessage("请输入文件！");
        }

        private void btnaudio2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.ALL); //"所有文件(*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                nameaudio2 = openFileDialog1.FileName;
                AudioInputTextBox.Text = nameaudio2;
            }
        }

        private void btnout3_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.ALL); //"所有文件(*.*)|*.*";
            //savefile.Filter = "音频(*.aac;*.wav;*.m4a;*.flac)|*.aac*.wav;*.m4a;*.flac;";
            DialogResult result = savefile.ShowDialog();
            if (result == DialogResult.OK)
            {
                nameout3 = savefile.FileName + getAudioExt();
                AudioOutputTextBox.Text = nameout3;
            }
        }

        private void btnaac_Click(object sender, EventArgs e)
        {
            if (nameaudio2 == "")
            {
                MessageBoxExtension.ShowErrorMessage("请选择音频文件");
            }
            else if (nameout3 == "")
            {
                MessageBoxExtension.ShowErrorMessage("请选择输出文件");
            }
            else
            {
                batpath = workPath + "\\aac.bat";
                File.WriteAllText(batpath, audiobat(nameaudio2, nameout3), Encoding.Default);
                LogRecord(audiobat(nameaudio2, nameout3));
                Process.Start(batpath);
            }
        }

        private void txtaudio2_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(AudioInputTextBox.Text.ToString()))
            {
                nameaudio2 = AudioInputTextBox.Text;
                switch (AudioEncoderComboBox.SelectedIndex)
                {
                    case 0: AudioOutputTextBox.Text = FileString.ChangeExt(AudioInputTextBox.Text, "_AAC.mp4"); break;
                    case 1: AudioOutputTextBox.Text = FileString.ChangeExt(AudioInputTextBox.Text, "_AAC.m4a"); break;
                    case 2: AudioOutputTextBox.Text = FileString.ChangeExt(AudioInputTextBox.Text, "_WAV.wav"); break;
                    case 3: AudioOutputTextBox.Text = FileString.ChangeExt(AudioInputTextBox.Text, "_ALAC.m4a"); break;
                    case 4: AudioOutputTextBox.Text = FileString.ChangeExt(AudioInputTextBox.Text, "_FLAC.flac"); break;
                    case 5: AudioOutputTextBox.Text = FileString.ChangeExt(AudioInputTextBox.Text, "_AAC.m4a"); break;
                    case 6: AudioOutputTextBox.Text = FileString.ChangeExt(AudioInputTextBox.Text, "_AC3.ac3"); break;
                    case 7: AudioOutputTextBox.Text = FileString.ChangeExt(AudioInputTextBox.Text, "_MP3.mp3"); break;
                    default: AudioOutputTextBox.Text = FileString.ChangeExt(AudioInputTextBox.Text, "_AAC.aac"); break;
                }
            }
        }

        private void txtout3_TextChanged(object sender, EventArgs e)
        {
            nameout3 = AudioOutputTextBox.Text;
        }

        private void txtaudio2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (File.Exists(AudioInputTextBox.Text.ToString()))
            {
                Process.Start(AudioInputTextBox.Text.ToString());
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
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

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
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

        private void AudioAddButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.ALL); //"所有文件(*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                AudioBatchItemListBox.Items.AddRange(openFileDialog1.FileNames);
            }
            openFileDialog1.Multiselect = false;
        }

        private void AudioDeleteButton_Click(object sender, EventArgs e)
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

        private void AudioClearButton_Click(object sender, EventArgs e)
        {
            AudioBatchItemListBox.Items.Clear();
        }

        #endregion 音频界面

        #region AVS页面

        private void GenerateAVS()
        {
            avsBuilder.Remove(0, avsBuilder.Length);
            string vsfilterDLLPath = Path.Combine(workPath, @"avs\plugins\VSFilter.DLL");
            string SupTitleDLLPath = Path.Combine(workPath, @"avs\plugins\SupTitle.dll");
            string LSMASHSourceDLLPath = Path.Combine(workPath, @"avs\plugins\LSMASHSource.DLL");
            string undotDLLPath = Path.Combine(workPath, @"avs\plugins\UnDot.DLL");
            string extInput = Path.GetExtension(namevideo9).ToLower();
            avsBuilder.AppendLine("LoadPlugin(\"" + LSMASHSourceDLLPath + "\")");
            if (Path.GetExtension(namesub9).ToLower() == ".sup")
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
                avsBuilder.AppendLine("LSMASHVideoSource(\"" + namevideo9 + "\",format=\"YUV420P8\")");
            else
                avsBuilder.AppendLine("LWLibavVideoSource(\"" + namevideo9 + "\",format=\"YUV420P8\")");
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
                if (Path.GetExtension(namesub9).ToLower() == ".idx")
                    avsBuilder.AppendLine("vobsub(\"" + namesub9 + "\")");
                else if (Path.GetExtension(namesub9).ToLower() == ".sup")
                    avsBuilder.AppendLine("SupTitle(\"" + namesub9 + "\")");
                else
                    avsBuilder.AppendLine("TextSub(\"" + namesub9 + "\")");
            }
            if (AvsTrimCheckBox.Checked)
                avsBuilder.AppendLine("Trim(" + AvsTrimStartNumericUpDown.Value.ToString() + "," + AvsTrimEndNumericUpDown.Value.ToString() + ")");
            AvsScriptTextBox.Text = avsBuilder.ToString();
        }

        #region 更改AVS

        private void TweakCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void LanczosResizeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void AddBordersCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void CropCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void TrimCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void LevelsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void SharpenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void UndotCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void TweakChromaNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void TweakSaturationNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void TweakBrightnessNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void TweakContrastNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void AVSWidthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void AVSHeightNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void AddBorders1NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void AddBorders2NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void AddBorders3NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void AddBorders4NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void AVSCropTextBox_TextChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void TrimStartNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void TrimEndNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void LevelsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        private void SharpenNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GenerateAVS();
        }

        #endregion 更改AVS

        #endregion AVS页面

        private void ExtractMP4Button_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.VIDEO_5); //"视频(*.mp4)|*.mp4|所有文件(*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                namevideo = openFileDialog1.FileName;
                ExtractMp4InputTextBox.Text = namevideo;
            }
        }

        private void txtAVS_TextChanged(object sender, EventArgs e)
        {
            Match m = Regex.Match(AvsScriptTextBox.Text, "ource\\(\"[a-zA-Z]:\\\\.+\\.\\w+\"");
            if (m.Success)
            {
                string str = m.ToString();
                str = str.Replace("ource(\"", "");
                str = str.Replace("\"", "");
                str = FileString.ChangeExt(str, "_AVS.mp4");
                AvsOutputTextBox.Text = str;
            }
        }

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
            FileString.ensureDirectoryExists(logPath);
            File.AppendAllText(logFileName,
                "===========" + DateTime.Now.ToString() + "===========\r\n" + log + "\r\n\r\n", Encoding.Default);
        }

        private void DeleteLogButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(logPath))
            {
                FileString.DeleteDirectoryIfExists(logPath, true);
                MessageBoxExtension.ShowInfoMessage("已经删除日志文件。");
            }
            else MessageBoxExtension.ShowInfoMessage("没有找到日志文件。");
        }

        private void ViewLogButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(logFileName))
            {
                Process.Start(logFileName);
            }
            else MessageBoxExtension.ShowInfoMessage("没有找到日志文件。");
        }

        private void x264PathButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
                VideoBatchOutputFolderTextBox.Text = fbd.SelectedPath;
        }

        private void ExtractMP4TextBox_TextChanged(object sender, EventArgs e)
        {
            namevideo = ExtractMp4InputTextBox.Text;
        }

        private void MaintainResolutionCheckBox_CheckedChanged(object sender, EventArgs e)
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

        private void languageComboBox_SelectedIndexChanged(object sender, EventArgs e)
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
                    this.Text = string.Format("小丸工具箱 {0}", Utility.Assembly.GetAssemblyFileVersion());
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
                    this.Text = string.Format("小丸工具箱 {0}", Utility.Assembly.GetAssemblyFileVersion());
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
                    this.Text = string.Format("Maruko Toolbox {0}", Utility.Assembly.GetAssemblyFileVersion());
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
                    this.Text = string.Format("小丸道具箱 {0}", Utility.Assembly.GetAssemblyFileVersion());
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

        private void AVSSaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.AVS); //"AVS(*.avs)|*.avs";
            DialogResult result = savefile.ShowDialog();
            if (result == DialogResult.OK)
            {
                File.WriteAllText(savefile.FileName, AvsScriptTextBox.Text, Encoding.Default);
            }
        }

        private void MuxReplaceAudioButton_Click(object sender, EventArgs e)
        {
            if (namevideo == "")
            {
                MessageBoxExtension.ShowErrorMessage("请选择视频文件");
                return;
            }
            if (nameaudio == "")
            {
                MessageBoxExtension.ShowErrorMessage("请选择音频文件");
                return;
            }
            if (nameout == "")
            {
                MessageBoxExtension.ShowErrorMessage("请选择输出文件");
                return;
            }
            mux = "";
            //mux = "\"" + workPath + "\\ffmpeg.exe\" -y -i \"" + namevideo + "\" -c:v copy -an  \"" + workPath + "\\video_noaudio.mp4\" \r\n";
            //mux += "\"" + workPath + "\\ffmpeg.exe\" -y -i \"" + workPath + "\\video_noaudio.mp4\" -i \"" + nameaudio + "\" -vcodec copy  -acodec copy \"" + nameout + "\" \r\n";
            //mux += "del \"" + workPath + "\\video_noaudio.mp4\" \r\n";
            mux = "\"" + workPath + "\\ffmpeg.exe\" -y -i \"" + namevideo + "\" -i \"" + nameaudio + "\" -map 0:v -c:v copy -map 1:0 -c:a copy  \"" + MuxMp4OutputTextBox.Text + "\" \r\n";
            batpath = workPath + "\\mux.bat";
            File.WriteAllText(batpath, mux, Encoding.Default);
            LogRecord(mux);
            Process.Start(batpath);
        }

        #region 一图流

        private void MiscOnePicInputButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.IMAGE); //"图片(*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif|所有文件(*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                MiscOnePicInputTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void MiscOnePicAudioInputButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.AUDIO_4); //"音频(*.aac;*.mp3;*.mp4;*.wav)|*.aac;*.mp3;*.mp4;*.wav|所有文件(*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                MiscOnePicAudioInputTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void MiscOnePicOutputButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.VIDEO_D_2); //"MP4视频(*.mp4)|*.mp4|FLV视频(*.flv)|*.flv";
            savefile.FileName = "Single";
            DialogResult result = savefile.ShowDialog();
            if (result == DialogResult.OK)
            {
                MiscOnePicOutputTextBox.Text = savefile.FileName;
            }
        }

        private void MiscOnePicAudioInputTextBox_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(MiscOnePicAudioInputTextBox.Text.ToString()))
            {
                MiscOnePicOutputTextBox.Text = FileString.ChangeExt(MiscOnePicAudioInputTextBox.Text, "_SP.flv");
            }
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
                MessageBoxExtension.ShowErrorMessage("请选择图片文件");
            }
            else if (!File.Exists(MiscOnePicAudioInputTextBox.Text))
            {
                MessageBoxExtension.ShowErrorMessage("请选择音频文件");
            }
            else if (MiscOnePicOutputTextBox.Text == "")
            {
                MessageBoxExtension.ShowErrorMessage("请选择输出文件");
            }
            else
            {
                OnePicProcedure procedure = new OnePicProcedure(tempPic,workPath);
                procedure.GetDataFromUI(GetOnePicDataFromUI);
                procedure.Execute();
            }
        }

        #endregion 一图流

        #region 后黑

        private void BlackVideoButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.VIDEO_D_1); //"FLV视频(*.flv)|*.flv";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                MiscBlackVideoInputTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void BlackOutputButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.VIDEO_D_1); //"FLV视频(*.flv)|*.flv";
            DialogResult result = savefile.ShowDialog();
            if (result == DialogResult.OK)
            {
                MiscBlackOutputTextBox.Text = savefile.FileName;
            }
        }

        private void BlackPicButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.IMAGE); //"图片(*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif|所有文件(*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                MiscBlackPicInputTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void BlackNoPicCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MiscBlackPicInputTextBox.Enabled = !MiscBlackNoPicCheckBox.Checked;
            MiscBlackPicInputButton.Enabled = !MiscBlackNoPicCheckBox.Checked;
        }

        private void BlackSecondComboBox_SelectedIndexChanged(object sender, EventArgs e)
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

        private void BlackStartButton_Click(object sender, EventArgs e)
        {
            //验证
            if (!File.Exists(MiscBlackVideoInputTextBox.Text) || Path.GetExtension(MiscBlackVideoInputTextBox.Text) != ".flv")
            {
                MessageBoxExtension.ShowErrorMessage("请选择FLV视频文件");
                return;
            }

            MediaInfoWrapper MIW = new MediaInfoWrapper(MiscBlackVideoInputTextBox.Text);
            double videobitrate = double.Parse(MIW.bitRate1);
            double targetBitrate = (double)MiscBlackBitrateNumericUpDown.Value;

            if (!File.Exists(MiscBlackPicInputTextBox.Text) && MiscBlackNoPicCheckBox.Checked == false)
            {
                MessageBoxExtension.ShowErrorMessage("请选择图片文件或勾选使用黑屏");
                return;
            }
            if (MiscBlackOutputTextBox.Text == "")
            {
                MessageBoxExtension.ShowErrorMessage("请选择输出文件");
                return;
            }

            if (videobitrate < 1000000)
            {
                MessageBoxExtension.ShowInfoMessage("此视频不需要后黑。");
                return;
            }
            if (videobitrate > 5000000)
            {
                MessageBoxExtension.ShowInfoMessage("此视频码率过大，请先压制再后黑。");
                return;
            }

            //处理图片
            int videoWidth = int.Parse(MIW.v_width);
            int videoHeight = int.Parse(MIW.v_height);
            if (MiscBlackNoPicCheckBox.Checked)
            {
                Bitmap bm = new Bitmap(videoWidth, videoHeight);
                Graphics g = Graphics.FromImage(bm);
                //g.FillRectangle(Brushes.White, new Rectangle(0, 0, 800, 600));
                g.Clear(Color.Black);
                bm.Save(tempPic, ImageFormat.Jpeg);
                g.Dispose();
                bm.Dispose();
            }
            else
            {
                System.Drawing.Image img = System.Drawing.Image.FromFile(MiscBlackPicInputTextBox.Text);
                int sourceWidth = img.Width;
                int sourceHeight = img.Height;
                if (img.Width % 2 != 0 || img.Height % 2 != 0)
                {
                    MessageBoxExtension.ShowErrorMessage("图片的长和宽必须都是偶数。");
                    img.Dispose();
                    return;
                }
                if (img.Width != videoWidth || img.Height != videoHeight)
                {
                    MessageBoxExtension.ShowErrorMessage("图片的长和宽和视频不一致。");
                    img.Dispose();
                    return;
                }
                if (img.RawFormat.Equals(ImageFormat.Jpeg))
                {
                    File.Copy(MiscBlackPicInputTextBox.Text, tempPic, true);
                }
                else
                {
                    System.Drawing.Imaging.Encoder ImageEncoder = System.Drawing.Imaging.Encoder.Quality;
                    EncoderParameter ep = new EncoderParameter(ImageEncoder, 100L);
                    EncoderParameters eps = new EncoderParameters(1);
                    ImageCodecInfo ImageCoderType = Other.GetImageCoderInfo("image/jpeg");
                    eps.Param[0] = ep;
                    img.Save(tempPic, ImageCoderType, eps);
                    //img.Save(tempPic, ImageFormat.Jpeg);
                }
            }
            int blackSecond = 300;
            //计算后黑时长
            if (MiscBlackDurationSecondsComboBox.Text == "auto")
            {
                int seconds = Other.SecondsFromHHMMSS(MIW.duration3);
                double s = videobitrate / 1000.0 * (double)seconds / targetBitrate - (double)seconds;
                blackSecond = (int)s;
                MiscBlackDurationSecondsComboBox.Text = blackSecond.ToString();
            }
            else
            {
                blackSecond = int.Parse(Regex.Replace(MiscBlackDurationSecondsComboBox.Text.ToString(), @"\D", "")); //排除除数字外的所有字符
            }

            //批处理
            mux = "\"" + workPath + "\\ffmpeg\" -loop 1 -r " + MiscBlackFpsNumericUpDown.Value.ToString() + " -t " + blackSecond.ToString() + " -f image2 -i \"" + tempPic + "\" -c:v libx264 -crf " + MiscBlackCrfNumericUpDown.Value.ToString() + " -y black.flv\r\n";
            mux += string.Format("\"{0}\\flvbind\" \"{1}\"  \"{2}\"  black.flv\r\n", workPath, MiscBlackOutputTextBox.Text, MiscBlackVideoInputTextBox.Text);
            mux += "del black.flv\r\n";

            batpath = Path.Combine(workPath, Path.GetRandomFileName() + ".bat");
            File.WriteAllText(batpath, mux, Encoding.Default);
            LogRecord(mux);
            Process.Start(batpath);
        }

        private void BlackVideoTextBox_TextChanged(object sender, EventArgs e)
        {
            string path = MiscBlackVideoInputTextBox.Text;
            if (File.Exists(path))
            {
                MiscBlackOutputTextBox.Text = FileString.ChangeExt(path, "_black.flv");
            }
        }

        #endregion 后黑

        private void SetDefaultButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBoxExtension.ShowQuestion(string.Format("是否将所有界面参数恢复到默认设置？"), "提示");
            if (dr == DialogResult.Yes)
            {
                InitParameter();
                MessageBoxExtension.ShowInfoMessage("恢复默认设置完成！");
            }
        }

        //Ctrl+A 可以全选文本
        private void MediaInfoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBoxSelectAll(sender, e);
        }

        private void AVSScriptTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBoxSelectAll(sender, e);
        }

        private void x264CustomParameterTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBoxSelectAll(sender, e);
        }

        private void TextBoxSelectAll(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
                ((TextBoxBase)sender).SelectAll();  // using TextBoxBase to include TextBox, RichTextBox and MaskedTextBox
        }


        private void txtMI_DragDrop(object sender, DragEventArgs e)
        {
            MIvideo = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            MediaInfoTextBox.Text = GetMediaInfoString(MIvideo);
        }

        private void txtMI_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else e.Effect = DragDropEffects.None;
        }


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
                        DialogResult dr = MessageBoxExtension.ShowQuestion(string.Format("新版已于{0}发布，是否前往官网下载？", NewDate.ToString("yyyy-M-d")), "喜大普奔");
                        if (dr == DialogResult.Yes)
                        {
                            Process.Start("http://maruko.appinn.me/");
                        }
                    }
                    else
                    {
                        DialogResult dr = MessageBoxExtension.ShowQuestion(string.Format("新版已于{0}发布，是否自动升级？（文件约1.5MB）", NewDate.ToString("yyyy-M-d")), "喜大普奔");
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

        private void CheckUpdateButton_Click(object sender, EventArgs e)
        {
            if (Network.IsConnectInternet())
            {
                WebRequest request = WebRequest.Create("http://maruko.appinn.me/config/version.html");
                request.Credentials = CredentialCache.DefaultCredentials;
                // Get the response.
                request.BeginGetResponse(new AsyncCallback(OnResponse), request);
            }
            else
            {
                MessageBoxExtension.ShowErrorMessage("这台电脑似乎没有联网呢~");
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
                        DialogResult dr = MessageBoxExtension.ShowQuestion(string.Format("新版已于{0}发布，是否前往官网下载？", NewDate.ToString("yyyy-M-d")), "喜大普奔");
                        if (dr == DialogResult.Yes)
                        {
                            Process.Start("http://maruko.appinn.me/");
                        }
                    }
                    else
                    {
                        DialogResult dr = MessageBoxExtension.ShowQuestion(string.Format("新版已于{0}发布，是否自动升级？（文件约1.5MB）", NewDate.ToString("yyyy-M-d")), "喜大普奔");
                        if (dr == DialogResult.Yes)
                        {
                            FormUpdater formUpdater = new FormUpdater(startpath, date);
                            formUpdater.ShowDialog(this);
                        }
                    }
                }
                else
                {
                    MessageBoxExtension.ShowInfoMessage("已经是最新版了喵！");
                }
            }
            else
            {
                MessageBoxExtension.ShowInfoMessage("啊咧~似乎未能获取版本信息，请点击软件主页按钮查看最新版本。");
            }
        }

        #endregion CheckUpdate

        private void x264ShutdownCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            shutdownState = VideoAutoShutdownCheckBox.Checked;
        }

        private void TrayModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            trayMode = ConfigUiTrayModeCheckBox.Checked;
        }

        private void ReleaseDatelabel_DoubleClick(object sender, EventArgs e)
        {
            SplashForm sf = new SplashForm();
            sf.Owner = this;
            sf.Show();
        }

        private void AudioCopyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MiscOnePicBitrateNumericUpDown.Enabled = !MiscOnePicCopyAudioCheckBox.Checked;
        }

        private void HelpTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        private void labelAudio_Click(object sender, EventArgs e)
        {
            MainTabControl.SelectedIndex = 1;
        }

        private void SetupAVSPlayerButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Dialog.GetDialogFilter(Dialog.DialogFilterTypes.PROGRAM); //"程序(*.exe)|*.exe|所有文件(*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                ConfigFunctionVideoPlayerTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void AVSAddFilterButton_Click(object sender, EventArgs e)
        {
            string vsfilterDLLPath = Path.Combine(workPath, @"avs\plugins\" + AvsFilterComboBox.Text);
            string text = "LoadPlugin(\"" + vsfilterDLLPath + "\")" + "\r\n";
            AvsScriptTextBox.Text = text + AvsScriptTextBox.Text;
        }

        private void AudioJoinButton_Click(object sender, EventArgs e)
        {
            if (AudioBatchItemListBox.Items.Count == 0)
            {
                MessageBoxExtension.ShowErrorMessage("请输入文件！");
                return;
            }
            else if (AudioOutputTextBox.Text == "")
            {
                MessageBoxExtension.ShowErrorMessage("请选择输出文件");
                return;
            }
            StringBuilder sb = new StringBuilder();
            ffmpeg = "";
            string ext = Path.GetExtension(AudioBatchItemListBox.Items[0].ToString());
            string finish = FileString.ChangeExt(AudioOutputTextBox.Text, ext);
            for (int i = 0; i < this.AudioBatchItemListBox.Items.Count; i++)
            {
                if (Path.GetExtension(AudioBatchItemListBox.Items[i].ToString()) != ext)
                {
                    MessageBoxExtension.ShowErrorMessage("只允许合并相同格式文件。");
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

        private void tabControl_DragOver(object sender, DragEventArgs e)
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
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.D1)
            {
                MainTabControl.SelectedIndex = 0;
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.D2)
            {
                MainTabControl.SelectedIndex = 1;
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.D3)
            {
                MainTabControl.SelectedIndex = 2;
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.D4)
            {
                MainTabControl.SelectedIndex = 3;
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.D5)
            {
                MainTabControl.SelectedIndex = 4;
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.D6)
            {
                MainTabControl.SelectedIndex = 5;
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.D7)
            {
                MainTabControl.SelectedIndex = 6;
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.D8)
            {
                MainTabControl.SelectedIndex = 7;
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.D9)
            {
                MainTabControl.SelectedIndex = 8;
            }
        }

        #endregion TabControl

        private void gmkvextractguibButton_Click(object sender, EventArgs e)
        {
            string path = workPath + "\\gMKVExtractGUI.exe";
            if (File.Exists(path))
                Process.Start(path);
            else
                MessageBoxExtension.ShowErrorMessage("请检查\r\n\r\n" + path + "\r\n\r\n是否存在", "未找到程序!");
        }

        private void FeedbackButton_Click(object sender, EventArgs e)
        {
            FeedbackForm ff = new FeedbackForm();
            ff.ShowDialog();
        }

        private void x264SubTextBox_DoubleClick(object sender, EventArgs e)
        {
            VideoSubtitleTextBox.Clear();
        }

        private void RotateButton_Click(object sender, EventArgs e)
        {
            if (namevideo4 == "")
            {
                MessageBoxExtension.ShowErrorMessage("请选择视频文件");
            }
            else if (nameout5 == "")
            {
                MessageBoxExtension.ShowErrorMessage("请选择输出文件");
            }
            else
            {
                clip = string.Format(@"""{0}\ffmpeg.exe"" -i ""{1}"" -vf ""transpose={2}"" -y ""{3}""",
                    workPath, namevideo4, MiscMiscTransposeComboBox.SelectedIndex, nameout5) + Environment.NewLine + "cmd";
                batpath = workPath + "\\clip.bat";
                File.WriteAllText(batpath, clip, Encoding.Default);
                Process.Start(batpath);
            }
        }

        private void AudioPresetComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            XElement x = preset.GetAudioPreset(AudioEncoderComboBox.Text).Elements()
                             .Where(_ => _.Attribute("Name").Value == AudioPresetComboBox.Text).First();
            AudioCustomParameterTextBox.Text = x.Value;
        }

        private void lbAuto_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= 65535)
                return;

            e.DrawBackground();
            SolidBrush BlueBrush = new SolidBrush(Color.Blue);
            SolidBrush BlackBrush = new SolidBrush(Color.Black);
            Color vColor = Color.Black;
            string input = VideoBatchItemListbox.Items[e.Index].ToString();
            if (!string.IsNullOrEmpty(GetSubtitlePath(input)))
            {
                e.Graphics.DrawString(Convert.ToString(VideoBatchItemListbox.Items[e.Index]), e.Font, BlueBrush, e.Bounds);
            }
            else
            {
                e.Graphics.DrawString(Convert.ToString(VideoBatchItemListbox.Items[e.Index]), e.Font, BlackBrush, e.Bounds);
            }
        }

        private string GetSubtitlePath(string videoPath)
        {
            string sub = "";
            string splang = "";
            string[] subExt = { ".ass", ".ssa", ".srt" };
            if (VideoBatchSubtitleLanguage.Text != "none")
                splang = "." + VideoBatchSubtitleLanguage.Text;
            foreach (string ext in subExt)
            {
                if (File.Exists(videoPath.Remove(videoPath.LastIndexOf(".")) + splang + ext))
                {
                    sub = videoPath.Remove(videoPath.LastIndexOf(".")) + splang + ext;
                    break;
                }
            }
            return sub;
        }

        private void x264ExeComboBox_SelectedIndexChanged(object sender, EventArgs e)
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

        private void audioDeleteBt_Click(object sender, EventArgs e)
        {
            if (MessageBoxExtension.ShowQuestion("确定要删除这条预设参数？", "提示") == DialogResult.Yes)
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
                    MessageBoxExtension.ShowErrorMessage("删除失败! Reason: " + ex.Message);
                }
            }
        }

        private void audioAddBt_Click(object sender, EventArgs e)
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
                            MessageBoxExtension.ShowErrorMessage("预设名称已经存在", "预设名称重复");
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
                MessageBoxExtension.ShowErrorMessage("添加失败! Reason: " + ex.Message);
            }
        }

        private void x265CheckBox_Click(object sender, EventArgs e)
        {
            if (MessageBoxExtension.ShowQuestion("你必须重新启动小丸工具箱才能使设置的生效 是否现在重新启动？", "需要重新启动") == DialogResult.Yes)
                Application.Restart();
        }

    }
}