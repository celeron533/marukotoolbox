using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static mp4box.DialogUtil;
using mp4box.Extension;
using System.Diagnostics;
using System.IO;
using mp4box.Procedure;
using NLog;

namespace mp4box.UserCtrl
{
    public partial class ExtractUserControl : UserControl
    {
        public ExtractUserControl()
        {
            InitializeComponent();
        }

        static Logger logger = LogManager.GetCurrentClassLogger();
        private string aextract;

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
                aextract = Shared.ExtractAV(out ext, namevideo, av, streamIndex);
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

    }
}
