using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaInfoLib;
using System.IO;
using System.Diagnostics;
using mp4box.Extension;
using static mp4box.DialogUtil;
using mp4box.Utility;

namespace mp4box.UserCtrl
{
    public partial class MediaInfoUserControl : UserControl
    {
        public MediaInfoUserControl()
        {
            InitializeComponent();
        }

        private string mediaInfoFile;

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
            UIUtil.TextBoxSelectAll(sender, e);
        }

        private void MediaInfoCopyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(MediaInfoTextBox.Text);
        }
    }
}
