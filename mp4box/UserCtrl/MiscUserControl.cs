using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mp4box.Extension;
using static mp4box.DialogUtil;
using System.IO;
using mp4box.Procedure;
using System.Diagnostics;

namespace mp4box.UserCtrl
{
    public partial class MiscUserControl : UserControl
    {
        public MiscUserControl()
        {
            InitializeComponent();
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

        private void GetMiscDataFromUI(MiscProcedure p)
        {
            p.inputVideoFilePath = MiscMiscVideoInputTextBox.Text;
            p.outputVideoFilePath = MiscMiscVideoOutputTextBox.Text;
            p.beginTimeStr = MiscMiscBeginTimeMaskedTextBox.Text;
            p.endTimeStr = MiscMiscEndTimeMaskedTextBox.Text;
            p.transposeIndex = MiscMiscTransposeComboBox.SelectedIndex;
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
    }
}
