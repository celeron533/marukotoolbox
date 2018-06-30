using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MediaInfoLib;
using mp4box.Extension;
using System.Diagnostics;
using mp4box.Procedure;
using static mp4box.DialogUtil;
using NLog;

namespace mp4box.UserCtrl
{
    public partial class MuxUserControl : UserControl
    {
        public MuxUserControl()
        {
            InitializeComponent();
        }

        static Logger logger = LogManager.GetCurrentClassLogger();

        private int sourceIndex;    // used for ListBox Drag & Drop
        private int targetIndex;    // used for ListBox Drag & Drop

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
    }
}
