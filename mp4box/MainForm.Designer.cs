namespace mp4box
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.MiscMiscGroupBox = new System.Windows.Forms.GroupBox();
            this.MiscMiscTransposeLabel = new System.Windows.Forms.Label();
            this.MiscMiscTransposeComboBox = new System.Windows.Forms.ComboBox();
            this.MiscMiscStartRotateButton = new ControlExs.QQButton();
            this.MiscMiscVideoInputTextBox = new ControlExs.QQTextBox();
            this.MiscMiscVideoInputButton = new ControlExs.QQButton();
            this.MiscMiscVideoOutputButton = new ControlExs.QQButton();
            this.MiscMiscStartClipButton = new ControlExs.QQButton();
            this.MiscMiscVideoOutputTextBox = new ControlExs.QQTextBox();
            this.MiscMiscEndTimeMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.MiscMiscBeginTimeLabel = new System.Windows.Forms.Label();
            this.MiscMiscEndTimeLabel = new System.Windows.Forms.Label();
            this.MiscMiscBeginTimeMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.MediaInfoTab = new System.Windows.Forms.TabPage();
            this.mediaInfoUserControl1 = new mp4box.UserCtrl.MediaInfoUserControl();
            this.AvsTab = new System.Windows.Forms.TabPage();
            this.AvsAddFilterButton = new ControlExs.QQButton();
            this.AvsFilterLabel = new System.Windows.Forms.Label();
            this.AvsFilterComboBox = new System.Windows.Forms.ComboBox();
            this.AvsCropIntroductionLabel = new System.Windows.Forms.Label();
            this.AvsCropTextBox = new ControlExs.QQTextBox();
            this.AvsTrimEndLabel = new System.Windows.Forms.Label();
            this.AvsTrimStartLabel = new System.Windows.Forms.Label();
            this.AvsTrimEndNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AvsTrimStartNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AvsLevelsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AvsAddBordersTopLabel = new System.Windows.Forms.Label();
            this.AvsAddBordersRightLabel = new System.Windows.Forms.Label();
            this.AvsAddBordersBottomLabel = new System.Windows.Forms.Label();
            this.AvsAddBordersLeftLabel = new System.Windows.Forms.Label();
            this.AvsAddBordersBottomNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AvsAddBordersRightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AvsAddBordersTopNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AvsSharpenNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AvsAddBordersLeftNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AvsLanczosResizeHeightLabel = new System.Windows.Forms.Label();
            this.AvsLanczosResizeWidthLabel = new System.Windows.Forms.Label();
            this.AvsLanczosResizeHeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AvsLanczosResizeWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AvsTweakContrastLabel = new System.Windows.Forms.Label();
            this.AvsTweakBrightnessLabel = new System.Windows.Forms.Label();
            this.AvsTweakSaturationLabel = new System.Windows.Forms.Label();
            this.AvsTweakChromaLabel = new System.Windows.Forms.Label();
            this.AvsTweakContrastNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AvsTweakBrightnessNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AvsTweakSaturationNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AvsTweakChromaNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AvsScriptTextBox = new ControlExs.QQTextBox();
            this.AvsVideoInputTextBox = new ControlExs.QQTextBox();
            this.AvsOutputTextBox = new ControlExs.QQTextBox();
            this.AvsSubtitleInputTextBox = new ControlExs.QQTextBox();
            this.AvsIncludeAudioCheckBox = new ControlExs.QQCheckBox();
            this.AvsSaveButton = new ControlExs.QQButton();
            this.AvsLevelsCheckBox = new ControlExs.QQCheckBox();
            this.AvsCropCheckBox = new ControlExs.QQCheckBox();
            this.AvsTrimCheckBox = new ControlExs.QQCheckBox();
            this.AvsSharpenCheckBox = new ControlExs.QQCheckBox();
            this.AvsAddBordersCheckBox = new ControlExs.QQCheckBox();
            this.AvsLanczosResizeCheckBox = new ControlExs.QQCheckBox();
            this.AvsTweakCheckBox = new ControlExs.QQCheckBox();
            this.AvsUndotCheckBox = new ControlExs.QQCheckBox();
            this.AvsClearButton = new ControlExs.QQButton();
            this.AvsGenerateButton = new ControlExs.QQButton();
            this.AvsPreviewButton = new ControlExs.QQButton();
            this.AvsStartButton = new ControlExs.QQButton();
            this.AvsVideoInputButton = new ControlExs.QQButton();
            this.AvsOutputButton = new ControlExs.QQButton();
            this.AvsSubtitleInputButton = new ControlExs.QQButton();
            this.ExtractTab = new System.Windows.Forms.TabPage();
            this.ExtractMkvGroupBox = new System.Windows.Forms.GroupBox();
            this.ExtractMkvExtractByExternalButton = new ControlExs.QQButton();
            this.ExtractMkvExtractTrack4Button = new ControlExs.QQButton();
            this.ExtractMkvExtractTrack3Button = new ControlExs.QQButton();
            this.ExtractMkvExtractTrack2Button = new ControlExs.QQButton();
            this.ExtractMkvExtractTrack1Button = new ControlExs.QQButton();
            this.ExtractMkvExtractTrack0Button = new ControlExs.QQButton();
            this.ExtractMkvInputButton = new ControlExs.QQButton();
            this.ExtractMkvInputTextBox = new ControlExs.QQTextBox();
            this.ExtractFlvGroupBox = new System.Windows.Forms.GroupBox();
            this.ExtractFlvExtractVideoButton = new ControlExs.QQButton();
            this.ExtractFlvInputButton = new ControlExs.QQButton();
            this.ExtractFlvInputTextBox = new ControlExs.QQTextBox();
            this.ExtractFlvExtractAudioButton = new ControlExs.QQButton();
            this.ExtractMp4GroupBox = new System.Windows.Forms.GroupBox();
            this.ExtractMp4InputTextBox = new ControlExs.QQTextBox();
            this.ExtractMp4ExtractAudio3Button = new ControlExs.QQButton();
            this.ExtractMp4InputButton = new ControlExs.QQButton();
            this.ExtractMp4ExtractVideoButton = new ControlExs.QQButton();
            this.ExtractMp4ExtractAudio1Button = new ControlExs.QQButton();
            this.ExtractMp4ExtractAudio2Button = new ControlExs.QQButton();
            this.MuxTab = new System.Windows.Forms.TabPage();
            this.MuxConvertGroupBox = new System.Windows.Forms.GroupBox();
            this.MuxConvertAacEncoderLabel = new System.Windows.Forms.Label();
            this.MuxConvertAacEncoderComboBox = new System.Windows.Forms.ComboBox();
            this.MuxConvertFormatLabel = new System.Windows.Forms.Label();
            this.MuxConvertFormatComboBox = new System.Windows.Forms.ComboBox();
            this.MuxConvertItemListBox = new System.Windows.Forms.ListBox();
            this.MuxConvertAddButton = new ControlExs.QQButton();
            this.MuxConvertClearButton = new ControlExs.QQButton();
            this.MuxConvertOutputNotificationLabel = new System.Windows.Forms.Label();
            this.MuxConvertDeleteButton = new ControlExs.QQButton();
            this.MuxConvertStartButton = new ControlExs.QQButton();
            this.MuxMp4GroupBox = new System.Windows.Forms.GroupBox();
            this.MuxMp4ParComboBox = new System.Windows.Forms.ComboBox();
            this.MuxMp4ParLabel = new System.Windows.Forms.Label();
            this.MuxMp4ReplaceAudioButton = new ControlExs.QQButton();
            this.MuxMp4VideoInputTextBox = new ControlExs.QQTextBox();
            this.MuxMp4VideoInputButton = new ControlExs.QQButton();
            this.MuxMp4StartButton = new ControlExs.QQButton();
            this.MuxMp4FpsComboBox = new System.Windows.Forms.ComboBox();
            this.MuxMp4AudioInputButton = new ControlExs.QQButton();
            this.MuxMp4OutputButton = new ControlExs.QQButton();
            this.MuxMp4AudioInputTextBox = new ControlExs.QQTextBox();
            this.MuxMp4FpsLabel = new System.Windows.Forms.Label();
            this.MuxMp4OutputTextBox = new ControlExs.QQTextBox();
            this.MuxMkvGroupBox = new System.Windows.Forms.GroupBox();
            this.MuxMkvVideoInputTextBox = new ControlExs.QQTextBox();
            this.MuxMkvOutputButton = new ControlExs.QQButton();
            this.MuxMkvSubtitleTextBox = new ControlExs.QQTextBox();
            this.MuxMkvAudioInputButton = new ControlExs.QQButton();
            this.MuxMkvAudioInputTextBox = new ControlExs.QQTextBox();
            this.MuxMkvSubtitleButton = new ControlExs.QQButton();
            this.MuxMkvOutputTextBox = new ControlExs.QQTextBox();
            this.MuxMkvVideoInputButton = new ControlExs.QQButton();
            this.MuxMkvStartButton = new ControlExs.QQButton();
            this.AudioTab = new System.Windows.Forms.TabPage();
            this.AudioGroupBox = new System.Windows.Forms.GroupBox();
            this.AudioPresetAddButton = new ControlExs.QQButton();
            this.AudioPresetDeleteButton = new ControlExs.QQButton();
            this.AudioPresetComboBox = new System.Windows.Forms.ComboBox();
            this.AudioPresetLabel = new System.Windows.Forms.Label();
            this.AudioBitrateComboBox = new System.Windows.Forms.ComboBox();
            this.AudioEncoderLabel = new System.Windows.Forms.Label();
            this.AudioEncoderComboBox = new System.Windows.Forms.ComboBox();
            this.AudioInputTextBox = new ControlExs.QQTextBox();
            this.AudioAudioModePanel = new System.Windows.Forms.Panel();
            this.AudioAudioModeBitrateRadioButton = new ControlExs.QQRadioButton();
            this.AudioAudioModeCustomRadioButton = new ControlExs.QQRadioButton();
            this.AudioOutputTextBox = new ControlExs.QQTextBox();
            this.AudioInputButton = new ControlExs.QQButton();
            this.AudioKbpsLabel = new System.Windows.Forms.Label();
            this.AudioOutputBotton = new ControlExs.QQButton();
            this.AudioBitrateLabel = new System.Windows.Forms.Label();
            this.AudioStartButton = new ControlExs.QQButton();
            this.AudioCustomParameterTextBox = new ControlExs.QQTextBox();
            this.AudioBatchGroupBox = new System.Windows.Forms.GroupBox();
            this.AudioBatchConcatButton = new ControlExs.QQButton();
            this.AudioBatchOutputNotificationLabel = new System.Windows.Forms.Label();
            this.AudioBatchStartButton = new ControlExs.QQButton();
            this.AudioBatchItemListBox = new System.Windows.Forms.ListBox();
            this.AudioBatchAddButton = new ControlExs.QQButton();
            this.AudioBatchClearButton = new ControlExs.QQButton();
            this.AudioBatchDeleteButton = new ControlExs.QQButton();
            this.MiscOnePicGroupBox = new System.Windows.Forms.GroupBox();
            this.MiscOnePicDurationSecondsLabel = new System.Windows.Forms.Label();
            this.MiscOnePicDurationSecondsTextBox = new System.Windows.Forms.TextBox();
            this.MiscOnePicDurationLabel = new System.Windows.Forms.Label();
            this.MiscOnePicCrfNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.MiscOnePicCrfLabel = new System.Windows.Forms.Label();
            this.MiscOnePicCopyAudioCheckBox = new ControlExs.QQCheckBox();
            this.MiscOnePicFpsLabel = new System.Windows.Forms.Label();
            this.MiscOnePicFpsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.MiscOnePicKbpsLabel = new System.Windows.Forms.Label();
            this.MiscOnePicBitrateLabel = new System.Windows.Forms.Label();
            this.MiscOnePicBitrateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.MiscOnePicOutputButton = new ControlExs.QQButton();
            this.MiscOnePicStartButton = new ControlExs.QQButton();
            this.MiscOnePicAudioInputButton = new ControlExs.QQButton();
            this.MiscOnePicInputButton = new ControlExs.QQButton();
            this.MiscOnePicOutputTextBox = new ControlExs.QQTextBox();
            this.MiscOnePicAudioInputTextBox = new ControlExs.QQTextBox();
            this.MiscOnePicInputTextBox = new ControlExs.QQTextBox();
            this.VideoTab = new System.Windows.Forms.TabPage();
            this.VideoFramesLabel = new System.Windows.Forms.Label();
            this.VideoSeekLabel = new System.Windows.Forms.Label();
            this.VideoFramesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.VideoSeekNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.VideoMaintainResolutionCheckBox = new ControlExs.QQCheckBox();
            this.VideoDemuxerComboBox = new System.Windows.Forms.ComboBox();
            this.VideoBatchGroupBox = new System.Windows.Forms.GroupBox();
            this.VideoBatchFormatLabel = new System.Windows.Forms.Label();
            this.VideoBatchFormatComboBox = new System.Windows.Forms.ComboBox();
            this.VideoBatchSubtitleLanguage = new System.Windows.Forms.ComboBox();
            this.VideoBatchOutputFolderButton = new ControlExs.QQButton();
            this.VideoBatchOutputFolderTextBox = new ControlExs.QQTextBox();
            this.VideoBatchItemListbox = new System.Windows.Forms.ListBox();
            this.VideoBatchClearButton = new ControlExs.QQButton();
            this.VideoBatchSubtitleCheckBox = new ControlExs.QQCheckBox();
            this.VideoBatchDeleteButton = new ControlExs.QQButton();
            this.VideoBatchAddButton = new ControlExs.QQButton();
            this.VideoBatchStartButton = new ControlExs.QQButton();
            this.VideoAutoShutdownCheckBox = new ControlExs.QQCheckBox();
            this.VideoAudioParameterTextBox = new ControlExs.QQTextBox();
            this.VideoSubtitleTextBox = new ControlExs.QQTextBox();
            this.VideoOutputTextBox = new ControlExs.QQTextBox();
            this.VideoInputTextBox = new ControlExs.QQTextBox();
            this.VideoX264ModePanel = new System.Windows.Forms.Panel();
            this.VideoModeCrfRadioButton = new ControlExs.QQRadioButton();
            this.VideoModeCustomRadioButton = new ControlExs.QQRadioButton();
            this.VideoMode2PassRadioButton = new ControlExs.QQRadioButton();
            this.VideoDemuxerLabel = new System.Windows.Forms.Label();
            this.VideoAddPresetButton = new ControlExs.QQButton();
            this.VideoDeletePresetButton = new ControlExs.QQButton();
            this.VideoStartButton = new ControlExs.QQButton();
            this.VideoSubtitleButton = new ControlExs.QQButton();
            this.VideoOutputButton = new ControlExs.QQButton();
            this.VideoInputButton = new ControlExs.QQButton();
            this.VideoEncoderLabel = new System.Windows.Forms.Label();
            this.VideoEncoderComboBox = new System.Windows.Forms.ComboBox();
            this.VideoFpsComboBox = new System.Windows.Forms.ComboBox();
            this.VideoFpsLabel = new System.Windows.Forms.Label();
            this.VideoAudioModeComboBox = new System.Windows.Forms.ComboBox();
            this.VideoPresetComboBox = new System.Windows.Forms.ComboBox();
            this.VideoAudioModeLabel = new System.Windows.Forms.Label();
            this.VideoGoToAudioLabel = new System.Windows.Forms.Label();
            this.VideoBitrateKbpsLabel = new System.Windows.Forms.Label();
            this.VideoCrfLabel = new System.Windows.Forms.Label();
            this.VideoHeightLabel = new System.Windows.Forms.Label();
            this.VideoWidthLabel = new System.Windows.Forms.Label();
            this.VideoHeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.VideoWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.VideoCrfNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.VideoBitrateLabel = new System.Windows.Forms.Label();
            this.VideoCustomParameterTextBox = new ControlExs.QQTextBox();
            this.VideoPresetLabel = new System.Windows.Forms.Label();
            this.VideoBitrateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.HelpTab = new System.Windows.Forms.TabPage();
            this.helpUserControl = new mp4box.UserCtrl.HelpUserControl();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.MiscTab = new System.Windows.Forms.TabPage();
            this.MiscBlackGroupBox = new System.Windows.Forms.GroupBox();
            this.MiscBlackKbpsLabel = new System.Windows.Forms.Label();
            this.MiscBlackBitrateLabel = new System.Windows.Forms.Label();
            this.MiscBlackBitrateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.MiscBlackDurationSecondsLabel = new System.Windows.Forms.Label();
            this.MiscBlackDurationSecondsComboBox = new System.Windows.Forms.ComboBox();
            this.MiscBlackDurationLabel = new System.Windows.Forms.Label();
            this.MiscBlackCrfNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.MiscBlackCrfLabel = new System.Windows.Forms.Label();
            this.MiscBlackNoPicCheckBox = new ControlExs.QQCheckBox();
            this.MiscBlackFpsLabel = new System.Windows.Forms.Label();
            this.MiscBlackFpsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.MiscBlackPicInputButton = new ControlExs.QQButton();
            this.MiscBlackPicInputTextBox = new ControlExs.QQTextBox();
            this.MiscBlackStartButton = new ControlExs.QQButton();
            this.MiscBlackOutputButton = new ControlExs.QQButton();
            this.MiscBlackVideoInputButton = new ControlExs.QQButton();
            this.MiscBlackOutputTextBox = new ControlExs.QQTextBox();
            this.MiscBlackVideoInputTextBox = new ControlExs.QQTextBox();
            this.ConfigTabPage = new System.Windows.Forms.TabPage();
            this.configUserControl = new mp4box.UserCtrl.ConfigUserControl();
            this.MiscMiscGroupBox.SuspendLayout();
            this.MediaInfoTab.SuspendLayout();
            this.AvsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AvsTrimEndNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvsTrimStartNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvsLevelsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvsAddBordersBottomNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvsAddBordersRightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvsAddBordersTopNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvsSharpenNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvsAddBordersLeftNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvsLanczosResizeHeightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvsLanczosResizeWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvsTweakContrastNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvsTweakBrightnessNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvsTweakSaturationNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvsTweakChromaNumericUpDown)).BeginInit();
            this.ExtractTab.SuspendLayout();
            this.ExtractMkvGroupBox.SuspendLayout();
            this.ExtractFlvGroupBox.SuspendLayout();
            this.ExtractMp4GroupBox.SuspendLayout();
            this.MuxTab.SuspendLayout();
            this.MuxConvertGroupBox.SuspendLayout();
            this.MuxMp4GroupBox.SuspendLayout();
            this.MuxMkvGroupBox.SuspendLayout();
            this.AudioTab.SuspendLayout();
            this.AudioGroupBox.SuspendLayout();
            this.AudioAudioModePanel.SuspendLayout();
            this.AudioBatchGroupBox.SuspendLayout();
            this.MiscOnePicGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MiscOnePicCrfNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MiscOnePicFpsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MiscOnePicBitrateNumericUpDown)).BeginInit();
            this.VideoTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VideoFramesNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VideoSeekNumericUpDown)).BeginInit();
            this.VideoBatchGroupBox.SuspendLayout();
            this.VideoX264ModePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VideoHeightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VideoWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VideoCrfNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VideoBitrateNumericUpDown)).BeginInit();
            this.HelpTab.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.MiscTab.SuspendLayout();
            this.MiscBlackGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MiscBlackBitrateNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MiscBlackCrfNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MiscBlackFpsNumericUpDown)).BeginInit();
            this.ConfigTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 9000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MiscMiscGroupBox
            // 
            this.MiscMiscGroupBox.Controls.Add(this.MiscMiscTransposeLabel);
            this.MiscMiscGroupBox.Controls.Add(this.MiscMiscTransposeComboBox);
            this.MiscMiscGroupBox.Controls.Add(this.MiscMiscStartRotateButton);
            this.MiscMiscGroupBox.Controls.Add(this.MiscMiscVideoInputTextBox);
            this.MiscMiscGroupBox.Controls.Add(this.MiscMiscVideoInputButton);
            this.MiscMiscGroupBox.Controls.Add(this.MiscMiscVideoOutputButton);
            this.MiscMiscGroupBox.Controls.Add(this.MiscMiscStartClipButton);
            this.MiscMiscGroupBox.Controls.Add(this.MiscMiscVideoOutputTextBox);
            this.MiscMiscGroupBox.Controls.Add(this.MiscMiscEndTimeMaskedTextBox);
            this.MiscMiscGroupBox.Controls.Add(this.MiscMiscBeginTimeLabel);
            this.MiscMiscGroupBox.Controls.Add(this.MiscMiscEndTimeLabel);
            this.MiscMiscGroupBox.Controls.Add(this.MiscMiscBeginTimeMaskedTextBox);
            this.MiscMiscGroupBox.Location = new System.Drawing.Point(0, 175);
            this.MiscMiscGroupBox.Name = "MiscMiscGroupBox";
            this.MiscMiscGroupBox.Size = new System.Drawing.Size(566, 135);
            this.MiscMiscGroupBox.TabIndex = 21;
            this.MiscMiscGroupBox.TabStop = false;
            this.MiscMiscGroupBox.Text = "其他";
            // 
            // MiscMiscTransposeLabel
            // 
            this.MiscMiscTransposeLabel.AutoSize = true;
            this.MiscMiscTransposeLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscMiscTransposeLabel.Location = new System.Drawing.Point(92, 108);
            this.MiscMiscTransposeLabel.Name = "MiscMiscTransposeLabel";
            this.MiscMiscTransposeLabel.Size = new System.Drawing.Size(57, 13);
            this.MiscMiscTransposeLabel.TabIndex = 39;
            this.MiscMiscTransposeLabel.Text = "Transpose";
            // 
            // MiscMiscTransposeComboBox
            // 
            this.MiscMiscTransposeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MiscMiscTransposeComboBox.FormattingEnabled = true;
            this.MiscMiscTransposeComboBox.Items.AddRange(new object[] {
            "0: 逆时针旋转90°然后垂直翻转",
            "1: 顺时针旋转90°",
            "2: 逆时针旋转90°",
            "3: 顺时针旋转90°然后水平翻转"});
            this.MiscMiscTransposeComboBox.Location = new System.Drawing.Point(185, 105);
            this.MiscMiscTransposeComboBox.Name = "MiscMiscTransposeComboBox";
            this.MiscMiscTransposeComboBox.Size = new System.Drawing.Size(233, 21);
            this.MiscMiscTransposeComboBox.TabIndex = 38;
            // 
            // MiscMiscStartRotateButton
            // 
            this.MiscMiscStartRotateButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MiscMiscStartRotateButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscMiscStartRotateButton.Location = new System.Drawing.Point(483, 105);
            this.MiscMiscStartRotateButton.Name = "MiscMiscStartRotateButton";
            this.MiscMiscStartRotateButton.Size = new System.Drawing.Size(75, 23);
            this.MiscMiscStartRotateButton.TabIndex = 21;
            this.MiscMiscStartRotateButton.Text = "旋转";
            this.MiscMiscStartRotateButton.UseVisualStyleBackColor = true;
            this.MiscMiscStartRotateButton.Click += new System.EventHandler(this.MiscMiscStartRotateButton_Click);
            // 
            // MiscMiscVideoInputTextBox
            // 
            this.MiscMiscVideoInputTextBox.AllowDrop = true;
            this.MiscMiscVideoInputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MiscMiscVideoInputTextBox.EmptyTextTip = null;
            this.MiscMiscVideoInputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.MiscMiscVideoInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MiscMiscVideoInputTextBox.Location = new System.Drawing.Point(9, 18);
            this.MiscMiscVideoInputTextBox.Name = "MiscMiscVideoInputTextBox";
            this.MiscMiscVideoInputTextBox.ReadOnly = true;
            this.MiscMiscVideoInputTextBox.Size = new System.Drawing.Size(469, 21);
            this.MiscMiscVideoInputTextBox.TabIndex = 7;
            this.MiscMiscVideoInputTextBox.TextChanged += new System.EventHandler(this.MiscMiscVideoInputTextBox_TextChanged);
            this.MiscMiscVideoInputTextBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MiscMiscVideoInputTextBox_MouseDoubleClick);
            // 
            // MiscMiscVideoInputButton
            // 
            this.MiscMiscVideoInputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MiscMiscVideoInputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscMiscVideoInputButton.Location = new System.Drawing.Point(483, 17);
            this.MiscMiscVideoInputButton.Name = "MiscMiscVideoInputButton";
            this.MiscMiscVideoInputButton.Size = new System.Drawing.Size(75, 23);
            this.MiscMiscVideoInputButton.TabIndex = 5;
            this.MiscMiscVideoInputButton.Text = "视频";
            this.MiscMiscVideoInputButton.UseVisualStyleBackColor = true;
            this.MiscMiscVideoInputButton.Click += new System.EventHandler(this.MiscMiscVideoInputButton_Click);
            // 
            // MiscMiscVideoOutputButton
            // 
            this.MiscMiscVideoOutputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MiscMiscVideoOutputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscMiscVideoOutputButton.Location = new System.Drawing.Point(483, 47);
            this.MiscMiscVideoOutputButton.Name = "MiscMiscVideoOutputButton";
            this.MiscMiscVideoOutputButton.Size = new System.Drawing.Size(75, 23);
            this.MiscMiscVideoOutputButton.TabIndex = 4;
            this.MiscMiscVideoOutputButton.Text = "输出";
            this.MiscMiscVideoOutputButton.UseVisualStyleBackColor = true;
            this.MiscMiscVideoOutputButton.Click += new System.EventHandler(this.MiscMiscVideoOutputButton_Click);
            // 
            // MiscMiscStartClipButton
            // 
            this.MiscMiscStartClipButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MiscMiscStartClipButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscMiscStartClipButton.Location = new System.Drawing.Point(483, 76);
            this.MiscMiscStartClipButton.Name = "MiscMiscStartClipButton";
            this.MiscMiscStartClipButton.Size = new System.Drawing.Size(75, 23);
            this.MiscMiscStartClipButton.TabIndex = 20;
            this.MiscMiscStartClipButton.Text = "截取";
            this.MiscMiscStartClipButton.UseVisualStyleBackColor = true;
            this.MiscMiscStartClipButton.Click += new System.EventHandler(this.MiscMiscStartClipButton_Click);
            // 
            // MiscMiscVideoOutputTextBox
            // 
            this.MiscMiscVideoOutputTextBox.AllowDrop = true;
            this.MiscMiscVideoOutputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MiscMiscVideoOutputTextBox.EmptyTextTip = null;
            this.MiscMiscVideoOutputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.MiscMiscVideoOutputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MiscMiscVideoOutputTextBox.Location = new System.Drawing.Point(9, 47);
            this.MiscMiscVideoOutputTextBox.Name = "MiscMiscVideoOutputTextBox";
            this.MiscMiscVideoOutputTextBox.Size = new System.Drawing.Size(469, 21);
            this.MiscMiscVideoOutputTextBox.TabIndex = 6;
            this.MiscMiscVideoOutputTextBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MiscMiscVideoOutputTextBox_MouseDoubleClick);
            // 
            // MiscMiscEndTimeMaskedTextBox
            // 
            this.MiscMiscEndTimeMaskedTextBox.Location = new System.Drawing.Point(407, 76);
            this.MiscMiscEndTimeMaskedTextBox.Mask = "90:00:00";
            this.MiscMiscEndTimeMaskedTextBox.Name = "MiscMiscEndTimeMaskedTextBox";
            this.MiscMiscEndTimeMaskedTextBox.Size = new System.Drawing.Size(70, 20);
            this.MiscMiscEndTimeMaskedTextBox.TabIndex = 19;
            this.MiscMiscEndTimeMaskedTextBox.Text = "000020";
            this.MiscMiscEndTimeMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MiscMiscBeginTimeLabel
            // 
            this.MiscMiscBeginTimeLabel.AutoSize = true;
            this.MiscMiscBeginTimeLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscMiscBeginTimeLabel.Location = new System.Drawing.Point(92, 80);
            this.MiscMiscBeginTimeLabel.Name = "MiscMiscBeginTimeLabel";
            this.MiscMiscBeginTimeLabel.Size = new System.Drawing.Size(55, 13);
            this.MiscMiscBeginTimeLabel.TabIndex = 18;
            this.MiscMiscBeginTimeLabel.Text = "起始时刻";
            // 
            // MiscMiscEndTimeLabel
            // 
            this.MiscMiscEndTimeLabel.AutoSize = true;
            this.MiscMiscEndTimeLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscMiscEndTimeLabel.Location = new System.Drawing.Point(320, 79);
            this.MiscMiscEndTimeLabel.Name = "MiscMiscEndTimeLabel";
            this.MiscMiscEndTimeLabel.Size = new System.Drawing.Size(55, 13);
            this.MiscMiscEndTimeLabel.TabIndex = 18;
            this.MiscMiscEndTimeLabel.Text = "结束时刻";
            // 
            // MiscMiscBeginTimeMaskedTextBox
            // 
            this.MiscMiscBeginTimeMaskedTextBox.Location = new System.Drawing.Point(185, 76);
            this.MiscMiscBeginTimeMaskedTextBox.Mask = "90:00:00";
            this.MiscMiscBeginTimeMaskedTextBox.Name = "MiscMiscBeginTimeMaskedTextBox";
            this.MiscMiscBeginTimeMaskedTextBox.Size = new System.Drawing.Size(70, 20);
            this.MiscMiscBeginTimeMaskedTextBox.TabIndex = 19;
            this.MiscMiscBeginTimeMaskedTextBox.Text = "000000";
            this.MiscMiscBeginTimeMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MediaInfoTab
            // 
            this.MediaInfoTab.Controls.Add(this.mediaInfoUserControl1);
            this.MediaInfoTab.Location = new System.Drawing.Point(4, 22);
            this.MediaInfoTab.Name = "MediaInfoTab";
            this.MediaInfoTab.Padding = new System.Windows.Forms.Padding(3);
            this.MediaInfoTab.Size = new System.Drawing.Size(572, 587);
            this.MediaInfoTab.TabIndex = 9;
            this.MediaInfoTab.Text = "MediaInfo";
            this.MediaInfoTab.UseVisualStyleBackColor = true;
            // 
            // mediaInfoUserControl1
            // 
            this.mediaInfoUserControl1.Location = new System.Drawing.Point(3, 3);
            this.mediaInfoUserControl1.Name = "mediaInfoUserControl1";
            this.mediaInfoUserControl1.Size = new System.Drawing.Size(561, 588);
            this.mediaInfoUserControl1.TabIndex = 0;
            // 
            // AvsTab
            // 
            this.AvsTab.Controls.Add(this.AvsAddFilterButton);
            this.AvsTab.Controls.Add(this.AvsFilterLabel);
            this.AvsTab.Controls.Add(this.AvsFilterComboBox);
            this.AvsTab.Controls.Add(this.AvsCropIntroductionLabel);
            this.AvsTab.Controls.Add(this.AvsCropTextBox);
            this.AvsTab.Controls.Add(this.AvsTrimEndLabel);
            this.AvsTab.Controls.Add(this.AvsTrimStartLabel);
            this.AvsTab.Controls.Add(this.AvsTrimEndNumericUpDown);
            this.AvsTab.Controls.Add(this.AvsTrimStartNumericUpDown);
            this.AvsTab.Controls.Add(this.AvsLevelsNumericUpDown);
            this.AvsTab.Controls.Add(this.AvsAddBordersTopLabel);
            this.AvsTab.Controls.Add(this.AvsAddBordersRightLabel);
            this.AvsTab.Controls.Add(this.AvsAddBordersBottomLabel);
            this.AvsTab.Controls.Add(this.AvsAddBordersLeftLabel);
            this.AvsTab.Controls.Add(this.AvsAddBordersBottomNumericUpDown);
            this.AvsTab.Controls.Add(this.AvsAddBordersRightNumericUpDown);
            this.AvsTab.Controls.Add(this.AvsAddBordersTopNumericUpDown);
            this.AvsTab.Controls.Add(this.AvsSharpenNumericUpDown);
            this.AvsTab.Controls.Add(this.AvsAddBordersLeftNumericUpDown);
            this.AvsTab.Controls.Add(this.AvsLanczosResizeHeightLabel);
            this.AvsTab.Controls.Add(this.AvsLanczosResizeWidthLabel);
            this.AvsTab.Controls.Add(this.AvsLanczosResizeHeightNumericUpDown);
            this.AvsTab.Controls.Add(this.AvsLanczosResizeWidthNumericUpDown);
            this.AvsTab.Controls.Add(this.AvsTweakContrastLabel);
            this.AvsTab.Controls.Add(this.AvsTweakBrightnessLabel);
            this.AvsTab.Controls.Add(this.AvsTweakSaturationLabel);
            this.AvsTab.Controls.Add(this.AvsTweakChromaLabel);
            this.AvsTab.Controls.Add(this.AvsTweakContrastNumericUpDown);
            this.AvsTab.Controls.Add(this.AvsTweakBrightnessNumericUpDown);
            this.AvsTab.Controls.Add(this.AvsTweakSaturationNumericUpDown);
            this.AvsTab.Controls.Add(this.AvsTweakChromaNumericUpDown);
            this.AvsTab.Controls.Add(this.AvsScriptTextBox);
            this.AvsTab.Controls.Add(this.AvsVideoInputTextBox);
            this.AvsTab.Controls.Add(this.AvsOutputTextBox);
            this.AvsTab.Controls.Add(this.AvsSubtitleInputTextBox);
            this.AvsTab.Controls.Add(this.AvsIncludeAudioCheckBox);
            this.AvsTab.Controls.Add(this.AvsSaveButton);
            this.AvsTab.Controls.Add(this.AvsLevelsCheckBox);
            this.AvsTab.Controls.Add(this.AvsCropCheckBox);
            this.AvsTab.Controls.Add(this.AvsTrimCheckBox);
            this.AvsTab.Controls.Add(this.AvsSharpenCheckBox);
            this.AvsTab.Controls.Add(this.AvsAddBordersCheckBox);
            this.AvsTab.Controls.Add(this.AvsLanczosResizeCheckBox);
            this.AvsTab.Controls.Add(this.AvsTweakCheckBox);
            this.AvsTab.Controls.Add(this.AvsUndotCheckBox);
            this.AvsTab.Controls.Add(this.AvsClearButton);
            this.AvsTab.Controls.Add(this.AvsGenerateButton);
            this.AvsTab.Controls.Add(this.AvsPreviewButton);
            this.AvsTab.Controls.Add(this.AvsStartButton);
            this.AvsTab.Controls.Add(this.AvsVideoInputButton);
            this.AvsTab.Controls.Add(this.AvsOutputButton);
            this.AvsTab.Controls.Add(this.AvsSubtitleInputButton);
            this.AvsTab.Location = new System.Drawing.Point(4, 22);
            this.AvsTab.Name = "AvsTab";
            this.AvsTab.Padding = new System.Windows.Forms.Padding(3);
            this.AvsTab.Size = new System.Drawing.Size(192, 74);
            this.AvsTab.TabIndex = 8;
            this.AvsTab.Text = "AVS";
            this.AvsTab.UseVisualStyleBackColor = true;
            // 
            // AvsAddFilterButton
            // 
            this.AvsAddFilterButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.AvsAddFilterButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsAddFilterButton.Location = new System.Drawing.Point(401, 304);
            this.AvsAddFilterButton.Name = "AvsAddFilterButton";
            this.AvsAddFilterButton.Size = new System.Drawing.Size(75, 23);
            this.AvsAddFilterButton.TabIndex = 66;
            this.AvsAddFilterButton.Text = "插入";
            this.AvsAddFilterButton.UseVisualStyleBackColor = true;
            this.AvsAddFilterButton.Click += new System.EventHandler(this.AvsAddFilterButton_Click);
            // 
            // AvsFilterLabel
            // 
            this.AvsFilterLabel.AutoSize = true;
            this.AvsFilterLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsFilterLabel.Location = new System.Drawing.Point(29, 309);
            this.AvsFilterLabel.Name = "AvsFilterLabel";
            this.AvsFilterLabel.Size = new System.Drawing.Size(55, 13);
            this.AvsFilterLabel.TabIndex = 65;
            this.AvsFilterLabel.Text = "外置滤镜";
            // 
            // AvsFilterComboBox
            // 
            this.AvsFilterComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.AvsFilterComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.AvsFilterComboBox.FormattingEnabled = true;
            this.AvsFilterComboBox.Location = new System.Drawing.Point(94, 306);
            this.AvsFilterComboBox.Name = "AvsFilterComboBox";
            this.AvsFilterComboBox.Size = new System.Drawing.Size(295, 21);
            this.AvsFilterComboBox.TabIndex = 64;
            // 
            // AvsCropIntroductionLabel
            // 
            this.AvsCropIntroductionLabel.AutoSize = true;
            this.AvsCropIntroductionLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsCropIntroductionLabel.Location = new System.Drawing.Point(156, 176);
            this.AvsCropIntroductionLabel.Name = "AvsCropIntroductionLabel";
            this.AvsCropIntroductionLabel.Size = new System.Drawing.Size(163, 13);
            this.AvsCropIntroductionLabel.TabIndex = 62;
            this.AvsCropIntroductionLabel.Text = "左,上,-右,-下（或左,上,宽,高）";
            // 
            // AvsCropTextBox
            // 
            this.AvsCropTextBox.AllowDrop = true;
            this.AvsCropTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AvsCropTextBox.EmptyTextTip = null;
            this.AvsCropTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.AvsCropTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.AvsCropTextBox.Location = new System.Drawing.Point(360, 171);
            this.AvsCropTextBox.Name = "AvsCropTextBox";
            this.AvsCropTextBox.Size = new System.Drawing.Size(135, 21);
            this.AvsCropTextBox.TabIndex = 61;
            this.AvsCropTextBox.Text = "8,0,-8,-0";
            this.AvsCropTextBox.TextChanged += new System.EventHandler(this.GenerateAVSHandler);
            // 
            // AvsTrimEndLabel
            // 
            this.AvsTrimEndLabel.AutoSize = true;
            this.AvsTrimEndLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsTrimEndLabel.Location = new System.Drawing.Point(313, 204);
            this.AvsTrimEndLabel.Name = "AvsTrimEndLabel";
            this.AvsTrimEndLabel.Size = new System.Drawing.Size(43, 13);
            this.AvsTrimEndLabel.TabIndex = 60;
            this.AvsTrimEndLabel.Text = "结束帧";
            // 
            // AvsTrimStartLabel
            // 
            this.AvsTrimStartLabel.AutoSize = true;
            this.AvsTrimStartLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsTrimStartLabel.Location = new System.Drawing.Point(156, 204);
            this.AvsTrimStartLabel.Name = "AvsTrimStartLabel";
            this.AvsTrimStartLabel.Size = new System.Drawing.Size(43, 13);
            this.AvsTrimStartLabel.TabIndex = 59;
            this.AvsTrimStartLabel.Text = "起始帧";
            // 
            // AvsTrimEndNumericUpDown
            // 
            this.AvsTrimEndNumericUpDown.Location = new System.Drawing.Point(360, 200);
            this.AvsTrimEndNumericUpDown.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.AvsTrimEndNumericUpDown.Name = "AvsTrimEndNumericUpDown";
            this.AvsTrimEndNumericUpDown.Size = new System.Drawing.Size(88, 20);
            this.AvsTrimEndNumericUpDown.TabIndex = 58;
            this.AvsTrimEndNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AvsTrimEndNumericUpDown.Value = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.AvsTrimEndNumericUpDown.ValueChanged += new System.EventHandler(this.GenerateAVSHandler);
            // 
            // AvsTrimStartNumericUpDown
            // 
            this.AvsTrimStartNumericUpDown.Location = new System.Drawing.Point(203, 200);
            this.AvsTrimStartNumericUpDown.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.AvsTrimStartNumericUpDown.Name = "AvsTrimStartNumericUpDown";
            this.AvsTrimStartNumericUpDown.Size = new System.Drawing.Size(88, 20);
            this.AvsTrimStartNumericUpDown.TabIndex = 57;
            this.AvsTrimStartNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AvsTrimStartNumericUpDown.ValueChanged += new System.EventHandler(this.GenerateAVSHandler);
            // 
            // AvsLevelsNumericUpDown
            // 
            this.AvsLevelsNumericUpDown.DecimalPlaces = 1;
            this.AvsLevelsNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.AvsLevelsNumericUpDown.Location = new System.Drawing.Point(203, 227);
            this.AvsLevelsNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.AvsLevelsNumericUpDown.Name = "AvsLevelsNumericUpDown";
            this.AvsLevelsNumericUpDown.Size = new System.Drawing.Size(57, 20);
            this.AvsLevelsNumericUpDown.TabIndex = 56;
            this.AvsLevelsNumericUpDown.Value = new decimal(new int[] {
            12,
            0,
            0,
            65536});
            this.AvsLevelsNumericUpDown.ValueChanged += new System.EventHandler(this.GenerateAVSHandler);
            // 
            // AvsAddBordersTopLabel
            // 
            this.AvsAddBordersTopLabel.AutoSize = true;
            this.AvsAddBordersTopLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsAddBordersTopLabel.Location = new System.Drawing.Point(252, 150);
            this.AvsAddBordersTopLabel.Name = "AvsAddBordersTopLabel";
            this.AvsAddBordersTopLabel.Size = new System.Drawing.Size(19, 13);
            this.AvsAddBordersTopLabel.TabIndex = 47;
            this.AvsAddBordersTopLabel.Text = "上";
            // 
            // AvsAddBordersRightLabel
            // 
            this.AvsAddBordersRightLabel.AutoSize = true;
            this.AvsAddBordersRightLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsAddBordersRightLabel.Location = new System.Drawing.Point(337, 150);
            this.AvsAddBordersRightLabel.Name = "AvsAddBordersRightLabel";
            this.AvsAddBordersRightLabel.Size = new System.Drawing.Size(19, 13);
            this.AvsAddBordersRightLabel.TabIndex = 46;
            this.AvsAddBordersRightLabel.Text = "右";
            // 
            // AvsAddBordersBottomLabel
            // 
            this.AvsAddBordersBottomLabel.AutoSize = true;
            this.AvsAddBordersBottomLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsAddBordersBottomLabel.Location = new System.Drawing.Point(421, 150);
            this.AvsAddBordersBottomLabel.Name = "AvsAddBordersBottomLabel";
            this.AvsAddBordersBottomLabel.Size = new System.Drawing.Size(19, 13);
            this.AvsAddBordersBottomLabel.TabIndex = 45;
            this.AvsAddBordersBottomLabel.Text = "下";
            // 
            // AvsAddBordersLeftLabel
            // 
            this.AvsAddBordersLeftLabel.AutoSize = true;
            this.AvsAddBordersLeftLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsAddBordersLeftLabel.Location = new System.Drawing.Point(168, 150);
            this.AvsAddBordersLeftLabel.Name = "AvsAddBordersLeftLabel";
            this.AvsAddBordersLeftLabel.Size = new System.Drawing.Size(19, 13);
            this.AvsAddBordersLeftLabel.TabIndex = 44;
            this.AvsAddBordersLeftLabel.Text = "左";
            // 
            // AvsAddBordersBottomNumericUpDown
            // 
            this.AvsAddBordersBottomNumericUpDown.Location = new System.Drawing.Point(444, 148);
            this.AvsAddBordersBottomNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.AvsAddBordersBottomNumericUpDown.Name = "AvsAddBordersBottomNumericUpDown";
            this.AvsAddBordersBottomNumericUpDown.Size = new System.Drawing.Size(55, 20);
            this.AvsAddBordersBottomNumericUpDown.TabIndex = 43;
            this.AvsAddBordersBottomNumericUpDown.ValueChanged += new System.EventHandler(this.GenerateAVSHandler);
            // 
            // AvsAddBordersRightNumericUpDown
            // 
            this.AvsAddBordersRightNumericUpDown.Location = new System.Drawing.Point(360, 148);
            this.AvsAddBordersRightNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.AvsAddBordersRightNumericUpDown.Name = "AvsAddBordersRightNumericUpDown";
            this.AvsAddBordersRightNumericUpDown.Size = new System.Drawing.Size(55, 20);
            this.AvsAddBordersRightNumericUpDown.TabIndex = 42;
            this.AvsAddBordersRightNumericUpDown.ValueChanged += new System.EventHandler(this.GenerateAVSHandler);
            // 
            // AvsAddBordersTopNumericUpDown
            // 
            this.AvsAddBordersTopNumericUpDown.Location = new System.Drawing.Point(276, 148);
            this.AvsAddBordersTopNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.AvsAddBordersTopNumericUpDown.Name = "AvsAddBordersTopNumericUpDown";
            this.AvsAddBordersTopNumericUpDown.Size = new System.Drawing.Size(55, 20);
            this.AvsAddBordersTopNumericUpDown.TabIndex = 41;
            this.AvsAddBordersTopNumericUpDown.ValueChanged += new System.EventHandler(this.GenerateAVSHandler);
            // 
            // AvsSharpenNumericUpDown
            // 
            this.AvsSharpenNumericUpDown.DecimalPlaces = 1;
            this.AvsSharpenNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.AvsSharpenNumericUpDown.Location = new System.Drawing.Point(203, 254);
            this.AvsSharpenNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.AvsSharpenNumericUpDown.Name = "AvsSharpenNumericUpDown";
            this.AvsSharpenNumericUpDown.Size = new System.Drawing.Size(55, 20);
            this.AvsSharpenNumericUpDown.TabIndex = 40;
            this.AvsSharpenNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.AvsSharpenNumericUpDown.ValueChanged += new System.EventHandler(this.GenerateAVSHandler);
            // 
            // AvsAddBordersLeftNumericUpDown
            // 
            this.AvsAddBordersLeftNumericUpDown.Location = new System.Drawing.Point(191, 148);
            this.AvsAddBordersLeftNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.AvsAddBordersLeftNumericUpDown.Name = "AvsAddBordersLeftNumericUpDown";
            this.AvsAddBordersLeftNumericUpDown.Size = new System.Drawing.Size(55, 20);
            this.AvsAddBordersLeftNumericUpDown.TabIndex = 36;
            this.AvsAddBordersLeftNumericUpDown.ValueChanged += new System.EventHandler(this.GenerateAVSHandler);
            // 
            // AvsLanczosResizeHeightLabel
            // 
            this.AvsLanczosResizeHeightLabel.AutoSize = true;
            this.AvsLanczosResizeHeightLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsLanczosResizeHeightLabel.Location = new System.Drawing.Point(325, 123);
            this.AvsLanczosResizeHeightLabel.Name = "AvsLanczosResizeHeightLabel";
            this.AvsLanczosResizeHeightLabel.Size = new System.Drawing.Size(31, 13);
            this.AvsLanczosResizeHeightLabel.TabIndex = 35;
            this.AvsLanczosResizeHeightLabel.Text = "高度";
            // 
            // AvsLanczosResizeWidthLabel
            // 
            this.AvsLanczosResizeWidthLabel.AutoSize = true;
            this.AvsLanczosResizeWidthLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsLanczosResizeWidthLabel.Location = new System.Drawing.Point(156, 123);
            this.AvsLanczosResizeWidthLabel.Name = "AvsLanczosResizeWidthLabel";
            this.AvsLanczosResizeWidthLabel.Size = new System.Drawing.Size(31, 13);
            this.AvsLanczosResizeWidthLabel.TabIndex = 34;
            this.AvsLanczosResizeWidthLabel.Text = "宽度";
            // 
            // AvsLanczosResizeHeightNumericUpDown
            // 
            this.AvsLanczosResizeHeightNumericUpDown.Location = new System.Drawing.Point(360, 121);
            this.AvsLanczosResizeHeightNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.AvsLanczosResizeHeightNumericUpDown.Name = "AvsLanczosResizeHeightNumericUpDown";
            this.AvsLanczosResizeHeightNumericUpDown.Size = new System.Drawing.Size(88, 20);
            this.AvsLanczosResizeHeightNumericUpDown.TabIndex = 33;
            this.AvsLanczosResizeHeightNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AvsLanczosResizeHeightNumericUpDown.Value = new decimal(new int[] {
            720,
            0,
            0,
            0});
            this.AvsLanczosResizeHeightNumericUpDown.ValueChanged += new System.EventHandler(this.GenerateAVSHandler);
            // 
            // AvsLanczosResizeWidthNumericUpDown
            // 
            this.AvsLanczosResizeWidthNumericUpDown.Location = new System.Drawing.Point(193, 121);
            this.AvsLanczosResizeWidthNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.AvsLanczosResizeWidthNumericUpDown.Name = "AvsLanczosResizeWidthNumericUpDown";
            this.AvsLanczosResizeWidthNumericUpDown.Size = new System.Drawing.Size(88, 20);
            this.AvsLanczosResizeWidthNumericUpDown.TabIndex = 32;
            this.AvsLanczosResizeWidthNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AvsLanczosResizeWidthNumericUpDown.Value = new decimal(new int[] {
            1280,
            0,
            0,
            0});
            this.AvsLanczosResizeWidthNumericUpDown.ValueChanged += new System.EventHandler(this.GenerateAVSHandler);
            // 
            // AvsTweakContrastLabel
            // 
            this.AvsTweakContrastLabel.AutoSize = true;
            this.AvsTweakContrastLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsTweakContrastLabel.Location = new System.Drawing.Point(456, 96);
            this.AvsTweakContrastLabel.Name = "AvsTweakContrastLabel";
            this.AvsTweakContrastLabel.Size = new System.Drawing.Size(43, 13);
            this.AvsTweakContrastLabel.TabIndex = 31;
            this.AvsTweakContrastLabel.Text = "对比度";
            // 
            // AvsTweakBrightnessLabel
            // 
            this.AvsTweakBrightnessLabel.AutoSize = true;
            this.AvsTweakBrightnessLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsTweakBrightnessLabel.Location = new System.Drawing.Point(360, 96);
            this.AvsTweakBrightnessLabel.Name = "AvsTweakBrightnessLabel";
            this.AvsTweakBrightnessLabel.Size = new System.Drawing.Size(31, 13);
            this.AvsTweakBrightnessLabel.TabIndex = 31;
            this.AvsTweakBrightnessLabel.Text = "亮度";
            // 
            // AvsTweakSaturationLabel
            // 
            this.AvsTweakSaturationLabel.AutoSize = true;
            this.AvsTweakSaturationLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsTweakSaturationLabel.Location = new System.Drawing.Point(252, 96);
            this.AvsTweakSaturationLabel.Name = "AvsTweakSaturationLabel";
            this.AvsTweakSaturationLabel.Size = new System.Drawing.Size(43, 13);
            this.AvsTweakSaturationLabel.TabIndex = 31;
            this.AvsTweakSaturationLabel.Text = "饱和度";
            // 
            // AvsTweakChromaLabel
            // 
            this.AvsTweakChromaLabel.AutoSize = true;
            this.AvsTweakChromaLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsTweakChromaLabel.Location = new System.Drawing.Point(156, 96);
            this.AvsTweakChromaLabel.Name = "AvsTweakChromaLabel";
            this.AvsTweakChromaLabel.Size = new System.Drawing.Size(31, 13);
            this.AvsTweakChromaLabel.TabIndex = 31;
            this.AvsTweakChromaLabel.Text = "色度";
            // 
            // AvsTweakContrastNumericUpDown
            // 
            this.AvsTweakContrastNumericUpDown.DecimalPlaces = 1;
            this.AvsTweakContrastNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.AvsTweakContrastNumericUpDown.Location = new System.Drawing.Point(503, 92);
            this.AvsTweakContrastNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.AvsTweakContrastNumericUpDown.Name = "AvsTweakContrastNumericUpDown";
            this.AvsTweakContrastNumericUpDown.Size = new System.Drawing.Size(55, 20);
            this.AvsTweakContrastNumericUpDown.TabIndex = 30;
            this.AvsTweakContrastNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AvsTweakContrastNumericUpDown.ValueChanged += new System.EventHandler(this.GenerateAVSHandler);
            // 
            // AvsTweakBrightnessNumericUpDown
            // 
            this.AvsTweakBrightnessNumericUpDown.DecimalPlaces = 1;
            this.AvsTweakBrightnessNumericUpDown.Location = new System.Drawing.Point(395, 92);
            this.AvsTweakBrightnessNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.AvsTweakBrightnessNumericUpDown.Minimum = new decimal(new int[] {
            255,
            0,
            0,
            -2147483648});
            this.AvsTweakBrightnessNumericUpDown.Name = "AvsTweakBrightnessNumericUpDown";
            this.AvsTweakBrightnessNumericUpDown.Size = new System.Drawing.Size(55, 20);
            this.AvsTweakBrightnessNumericUpDown.TabIndex = 29;
            this.AvsTweakBrightnessNumericUpDown.ValueChanged += new System.EventHandler(this.GenerateAVSHandler);
            // 
            // AvsTweakSaturationNumericUpDown
            // 
            this.AvsTweakSaturationNumericUpDown.DecimalPlaces = 1;
            this.AvsTweakSaturationNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.AvsTweakSaturationNumericUpDown.Location = new System.Drawing.Point(299, 92);
            this.AvsTweakSaturationNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.AvsTweakSaturationNumericUpDown.Name = "AvsTweakSaturationNumericUpDown";
            this.AvsTweakSaturationNumericUpDown.Size = new System.Drawing.Size(55, 20);
            this.AvsTweakSaturationNumericUpDown.TabIndex = 28;
            this.AvsTweakSaturationNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AvsTweakSaturationNumericUpDown.ValueChanged += new System.EventHandler(this.GenerateAVSHandler);
            // 
            // AvsTweakChromaNumericUpDown
            // 
            this.AvsTweakChromaNumericUpDown.DecimalPlaces = 1;
            this.AvsTweakChromaNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.AvsTweakChromaNumericUpDown.Location = new System.Drawing.Point(191, 92);
            this.AvsTweakChromaNumericUpDown.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.AvsTweakChromaNumericUpDown.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.AvsTweakChromaNumericUpDown.Name = "AvsTweakChromaNumericUpDown";
            this.AvsTweakChromaNumericUpDown.Size = new System.Drawing.Size(55, 20);
            this.AvsTweakChromaNumericUpDown.TabIndex = 27;
            this.AvsTweakChromaNumericUpDown.ValueChanged += new System.EventHandler(this.GenerateAVSHandler);
            // 
            // AvsScriptTextBox
            // 
            this.AvsScriptTextBox.AllowDrop = true;
            this.AvsScriptTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AvsScriptTextBox.EmptyTextTip = null;
            this.AvsScriptTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.AvsScriptTextBox.Font = new System.Drawing.Font("SimSun", 9F);
            this.AvsScriptTextBox.Location = new System.Drawing.Point(8, 332);
            this.AvsScriptTextBox.Multiline = true;
            this.AvsScriptTextBox.Name = "AvsScriptTextBox";
            this.AvsScriptTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AvsScriptTextBox.Size = new System.Drawing.Size(550, 218);
            this.AvsScriptTextBox.TabIndex = 16;
            this.AvsScriptTextBox.Text = "可直接把AVS脚本粘贴到这里";
            this.AvsScriptTextBox.TextChanged += new System.EventHandler(this.AvsScriptTextBox_TextChanged);
            this.AvsScriptTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AvsScriptTextBox_KeyDown);
            // 
            // AvsVideoInputTextBox
            // 
            this.AvsVideoInputTextBox.AllowDrop = true;
            this.AvsVideoInputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AvsVideoInputTextBox.EmptyTextTip = null;
            this.AvsVideoInputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.AvsVideoInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.AvsVideoInputTextBox.Location = new System.Drawing.Point(8, 6);
            this.AvsVideoInputTextBox.Name = "AvsVideoInputTextBox";
            this.AvsVideoInputTextBox.ReadOnly = true;
            this.AvsVideoInputTextBox.Size = new System.Drawing.Size(468, 21);
            this.AvsVideoInputTextBox.TabIndex = 13;
            this.AvsVideoInputTextBox.TextChanged += new System.EventHandler(this.AvsVideoInputTextBox_TextChanged);
            this.AvsVideoInputTextBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AvsVideoInputTextBox_MouseDoubleClick);
            // 
            // AvsOutputTextBox
            // 
            this.AvsOutputTextBox.AllowDrop = true;
            this.AvsOutputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AvsOutputTextBox.EmptyTextTip = null;
            this.AvsOutputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.AvsOutputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.AvsOutputTextBox.Location = new System.Drawing.Point(8, 63);
            this.AvsOutputTextBox.Name = "AvsOutputTextBox";
            this.AvsOutputTextBox.Size = new System.Drawing.Size(468, 21);
            this.AvsOutputTextBox.TabIndex = 15;
            this.AvsOutputTextBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AvsOutputTextBox_MouseDoubleClick);
            // 
            // AvsSubtitleInputTextBox
            // 
            this.AvsSubtitleInputTextBox.AllowDrop = true;
            this.AvsSubtitleInputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AvsSubtitleInputTextBox.EmptyTextTip = null;
            this.AvsSubtitleInputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.AvsSubtitleInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.AvsSubtitleInputTextBox.Location = new System.Drawing.Point(8, 34);
            this.AvsSubtitleInputTextBox.Name = "AvsSubtitleInputTextBox";
            this.AvsSubtitleInputTextBox.ReadOnly = true;
            this.AvsSubtitleInputTextBox.Size = new System.Drawing.Size(468, 21);
            this.AvsSubtitleInputTextBox.TabIndex = 14;
            this.AvsSubtitleInputTextBox.TextChanged += new System.EventHandler(this.GenerateAVSHandler);
            // 
            // AvsIncludeAudioCheckBox
            // 
            this.AvsIncludeAudioCheckBox.AutoSize = true;
            this.AvsIncludeAudioCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.AvsIncludeAudioCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.AvsIncludeAudioCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsIncludeAudioCheckBox.Location = new System.Drawing.Point(368, 557);
            this.AvsIncludeAudioCheckBox.Name = "AvsIncludeAudioCheckBox";
            this.AvsIncludeAudioCheckBox.Size = new System.Drawing.Size(74, 19);
            this.AvsIncludeAudioCheckBox.TabIndex = 63;
            this.AvsIncludeAudioCheckBox.Text = "压制音频";
            this.AvsIncludeAudioCheckBox.UseVisualStyleBackColor = false;
            // 
            // AvsSaveButton
            // 
            this.AvsSaveButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.AvsSaveButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsSaveButton.Location = new System.Drawing.Point(188, 556);
            this.AvsSaveButton.Name = "AvsSaveButton";
            this.AvsSaveButton.Size = new System.Drawing.Size(75, 23);
            this.AvsSaveButton.TabIndex = 0;
            this.AvsSaveButton.Text = "保存AVS";
            this.AvsSaveButton.UseVisualStyleBackColor = true;
            this.AvsSaveButton.Click += new System.EventHandler(this.AvsSaveButton_Click);
            // 
            // AvsLevelsCheckBox
            // 
            this.AvsLevelsCheckBox.AutoSize = true;
            this.AvsLevelsCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.AvsLevelsCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.AvsLevelsCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsLevelsCheckBox.Location = new System.Drawing.Point(8, 227);
            this.AvsLevelsCheckBox.Name = "AvsLevelsCheckBox";
            this.AvsLevelsCheckBox.Size = new System.Drawing.Size(88, 19);
            this.AvsLevelsCheckBox.TabIndex = 39;
            this.AvsLevelsCheckBox.Text = "Levels 亮度";
            this.AvsLevelsCheckBox.UseVisualStyleBackColor = false;
            this.AvsLevelsCheckBox.CheckedChanged += new System.EventHandler(this.GenerateAVSHandler);
            // 
            // AvsCropCheckBox
            // 
            this.AvsCropCheckBox.AutoSize = true;
            this.AvsCropCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.AvsCropCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.AvsCropCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsCropCheckBox.Location = new System.Drawing.Point(8, 173);
            this.AvsCropCheckBox.Name = "AvsCropCheckBox";
            this.AvsCropCheckBox.Size = new System.Drawing.Size(79, 19);
            this.AvsCropCheckBox.TabIndex = 37;
            this.AvsCropCheckBox.Text = "Crop 裁剪";
            this.AvsCropCheckBox.UseVisualStyleBackColor = false;
            this.AvsCropCheckBox.CheckedChanged += new System.EventHandler(this.GenerateAVSHandler);
            // 
            // AvsTrimCheckBox
            // 
            this.AvsTrimCheckBox.AutoSize = true;
            this.AvsTrimCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.AvsTrimCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.AvsTrimCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsTrimCheckBox.Location = new System.Drawing.Point(8, 200);
            this.AvsTrimCheckBox.Name = "AvsTrimCheckBox";
            this.AvsTrimCheckBox.Size = new System.Drawing.Size(78, 19);
            this.AvsTrimCheckBox.TabIndex = 26;
            this.AvsTrimCheckBox.Text = "Trim 截取";
            this.AvsTrimCheckBox.UseVisualStyleBackColor = false;
            this.AvsTrimCheckBox.CheckedChanged += new System.EventHandler(this.GenerateAVSHandler);
            // 
            // AvsSharpenCheckBox
            // 
            this.AvsSharpenCheckBox.AutoSize = true;
            this.AvsSharpenCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.AvsSharpenCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.AvsSharpenCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsSharpenCheckBox.Location = new System.Drawing.Point(8, 254);
            this.AvsSharpenCheckBox.Name = "AvsSharpenCheckBox";
            this.AvsSharpenCheckBox.Size = new System.Drawing.Size(100, 19);
            this.AvsSharpenCheckBox.TabIndex = 24;
            this.AvsSharpenCheckBox.Text = "Sharpen 锐化";
            this.AvsSharpenCheckBox.UseVisualStyleBackColor = false;
            this.AvsSharpenCheckBox.CheckedChanged += new System.EventHandler(this.GenerateAVSHandler);
            // 
            // AvsAddBordersCheckBox
            // 
            this.AvsAddBordersCheckBox.AutoSize = true;
            this.AvsAddBordersCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.AvsAddBordersCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.AvsAddBordersCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsAddBordersCheckBox.Location = new System.Drawing.Point(8, 146);
            this.AvsAddBordersCheckBox.Name = "AvsAddBordersCheckBox";
            this.AvsAddBordersCheckBox.Size = new System.Drawing.Size(117, 19);
            this.AvsAddBordersCheckBox.TabIndex = 23;
            this.AvsAddBordersCheckBox.Text = "AddBorders 黑边";
            this.AvsAddBordersCheckBox.UseVisualStyleBackColor = false;
            this.AvsAddBordersCheckBox.CheckedChanged += new System.EventHandler(this.GenerateAVSHandler);
            // 
            // AvsLanczosResizeCheckBox
            // 
            this.AvsLanczosResizeCheckBox.AutoSize = true;
            this.AvsLanczosResizeCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.AvsLanczosResizeCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.AvsLanczosResizeCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsLanczosResizeCheckBox.Location = new System.Drawing.Point(8, 119);
            this.AvsLanczosResizeCheckBox.Name = "AvsLanczosResizeCheckBox";
            this.AvsLanczosResizeCheckBox.Size = new System.Drawing.Size(110, 19);
            this.AvsLanczosResizeCheckBox.TabIndex = 23;
            this.AvsLanczosResizeCheckBox.Text = "LanczosResize";
            this.AvsLanczosResizeCheckBox.UseVisualStyleBackColor = false;
            this.AvsLanczosResizeCheckBox.CheckedChanged += new System.EventHandler(this.GenerateAVSHandler);
            // 
            // AvsTweakCheckBox
            // 
            this.AvsTweakCheckBox.AutoSize = true;
            this.AvsTweakCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.AvsTweakCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.AvsTweakCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsTweakCheckBox.Location = new System.Drawing.Point(8, 92);
            this.AvsTweakCheckBox.Name = "AvsTweakCheckBox";
            this.AvsTweakCheckBox.Size = new System.Drawing.Size(62, 19);
            this.AvsTweakCheckBox.TabIndex = 23;
            this.AvsTweakCheckBox.Text = "Tweak";
            this.AvsTweakCheckBox.UseVisualStyleBackColor = false;
            this.AvsTweakCheckBox.CheckedChanged += new System.EventHandler(this.GenerateAVSHandler);
            // 
            // AvsUndotCheckBox
            // 
            this.AvsUndotCheckBox.AutoSize = true;
            this.AvsUndotCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.AvsUndotCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.AvsUndotCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsUndotCheckBox.Location = new System.Drawing.Point(8, 281);
            this.AvsUndotCheckBox.Name = "AvsUndotCheckBox";
            this.AvsUndotCheckBox.Size = new System.Drawing.Size(86, 19);
            this.AvsUndotCheckBox.TabIndex = 23;
            this.AvsUndotCheckBox.Text = "Undot 降噪";
            this.AvsUndotCheckBox.UseVisualStyleBackColor = false;
            this.AvsUndotCheckBox.CheckedChanged += new System.EventHandler(this.GenerateAVSHandler);
            // 
            // AvsClearButton
            // 
            this.AvsClearButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.AvsClearButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsClearButton.Location = new System.Drawing.Point(8, 556);
            this.AvsClearButton.Name = "AvsClearButton";
            this.AvsClearButton.Size = new System.Drawing.Size(75, 23);
            this.AvsClearButton.TabIndex = 21;
            this.AvsClearButton.Text = "清空";
            this.AvsClearButton.UseVisualStyleBackColor = true;
            this.AvsClearButton.Click += new System.EventHandler(this.AvsClearButton_Click);
            // 
            // AvsGenerateButton
            // 
            this.AvsGenerateButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.AvsGenerateButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsGenerateButton.Location = new System.Drawing.Point(99, 556);
            this.AvsGenerateButton.Name = "AvsGenerateButton";
            this.AvsGenerateButton.Size = new System.Drawing.Size(75, 23);
            this.AvsGenerateButton.TabIndex = 20;
            this.AvsGenerateButton.Text = "生成";
            this.AvsGenerateButton.UseVisualStyleBackColor = true;
            this.AvsGenerateButton.Visible = false;
            this.AvsGenerateButton.Click += new System.EventHandler(this.AvsGenerateButton_Click);
            // 
            // AvsPreviewButton
            // 
            this.AvsPreviewButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.AvsPreviewButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsPreviewButton.Location = new System.Drawing.Point(276, 556);
            this.AvsPreviewButton.Name = "AvsPreviewButton";
            this.AvsPreviewButton.Size = new System.Drawing.Size(75, 23);
            this.AvsPreviewButton.TabIndex = 17;
            this.AvsPreviewButton.Text = "预览";
            this.AvsPreviewButton.UseVisualStyleBackColor = true;
            this.AvsPreviewButton.Click += new System.EventHandler(this.AvsPreviewButton_Click);
            // 
            // AvsStartButton
            // 
            this.AvsStartButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.AvsStartButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsStartButton.Location = new System.Drawing.Point(483, 556);
            this.AvsStartButton.Name = "AvsStartButton";
            this.AvsStartButton.Size = new System.Drawing.Size(75, 23);
            this.AvsStartButton.TabIndex = 18;
            this.AvsStartButton.Text = "压制";
            this.AvsStartButton.UseVisualStyleBackColor = true;
            this.AvsStartButton.Click += new System.EventHandler(this.AvsStartButton_Click);
            // 
            // AvsVideoInputButton
            // 
            this.AvsVideoInputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.AvsVideoInputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsVideoInputButton.Location = new System.Drawing.Point(483, 6);
            this.AvsVideoInputButton.Name = "AvsVideoInputButton";
            this.AvsVideoInputButton.Size = new System.Drawing.Size(75, 23);
            this.AvsVideoInputButton.TabIndex = 10;
            this.AvsVideoInputButton.Text = "视频";
            this.AvsVideoInputButton.UseVisualStyleBackColor = true;
            this.AvsVideoInputButton.Click += new System.EventHandler(this.AvsVideoInputButton_Click);
            // 
            // AvsOutputButton
            // 
            this.AvsOutputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.AvsOutputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsOutputButton.Location = new System.Drawing.Point(483, 63);
            this.AvsOutputButton.Name = "AvsOutputButton";
            this.AvsOutputButton.Size = new System.Drawing.Size(75, 23);
            this.AvsOutputButton.TabIndex = 12;
            this.AvsOutputButton.Text = "输出";
            this.AvsOutputButton.UseVisualStyleBackColor = true;
            this.AvsOutputButton.Click += new System.EventHandler(this.AvsOutputButton_Click);
            // 
            // AvsSubtitleInputButton
            // 
            this.AvsSubtitleInputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.AvsSubtitleInputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsSubtitleInputButton.Location = new System.Drawing.Point(483, 34);
            this.AvsSubtitleInputButton.Name = "AvsSubtitleInputButton";
            this.AvsSubtitleInputButton.Size = new System.Drawing.Size(75, 23);
            this.AvsSubtitleInputButton.TabIndex = 11;
            this.AvsSubtitleInputButton.Text = "字幕";
            this.AvsSubtitleInputButton.UseVisualStyleBackColor = true;
            this.AvsSubtitleInputButton.Click += new System.EventHandler(this.AvsSubtitleInputButton_Click);
            // 
            // ExtractTab
            // 
            this.ExtractTab.AllowDrop = true;
            this.ExtractTab.Controls.Add(this.ExtractMkvGroupBox);
            this.ExtractTab.Controls.Add(this.ExtractFlvGroupBox);
            this.ExtractTab.Controls.Add(this.ExtractMp4GroupBox);
            this.ExtractTab.Location = new System.Drawing.Point(4, 22);
            this.ExtractTab.Name = "ExtractTab";
            this.ExtractTab.Padding = new System.Windows.Forms.Padding(3);
            this.ExtractTab.Size = new System.Drawing.Size(192, 74);
            this.ExtractTab.TabIndex = 0;
            this.ExtractTab.Text = "抽取";
            this.ExtractTab.UseVisualStyleBackColor = true;
            // 
            // ExtractMkvGroupBox
            // 
            this.ExtractMkvGroupBox.Controls.Add(this.ExtractMkvExtractByExternalButton);
            this.ExtractMkvGroupBox.Controls.Add(this.ExtractMkvExtractTrack4Button);
            this.ExtractMkvGroupBox.Controls.Add(this.ExtractMkvExtractTrack3Button);
            this.ExtractMkvGroupBox.Controls.Add(this.ExtractMkvExtractTrack2Button);
            this.ExtractMkvGroupBox.Controls.Add(this.ExtractMkvExtractTrack1Button);
            this.ExtractMkvGroupBox.Controls.Add(this.ExtractMkvExtractTrack0Button);
            this.ExtractMkvGroupBox.Controls.Add(this.ExtractMkvInputButton);
            this.ExtractMkvGroupBox.Controls.Add(this.ExtractMkvInputTextBox);
            this.ExtractMkvGroupBox.Location = new System.Drawing.Point(0, 180);
            this.ExtractMkvGroupBox.Name = "ExtractMkvGroupBox";
            this.ExtractMkvGroupBox.Size = new System.Drawing.Size(570, 82);
            this.ExtractMkvGroupBox.TabIndex = 21;
            this.ExtractMkvGroupBox.TabStop = false;
            this.ExtractMkvGroupBox.Text = "MKV";
            // 
            // ExtractMkvExtractByExternalButton
            // 
            this.ExtractMkvExtractByExternalButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.ExtractMkvExtractByExternalButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ExtractMkvExtractByExternalButton.Location = new System.Drawing.Point(11, 47);
            this.ExtractMkvExtractByExternalButton.Name = "ExtractMkvExtractByExternalButton";
            this.ExtractMkvExtractByExternalButton.Size = new System.Drawing.Size(122, 23);
            this.ExtractMkvExtractByExternalButton.TabIndex = 17;
            this.ExtractMkvExtractByExternalButton.Text = "使用第三方工具抽取";
            this.ExtractMkvExtractByExternalButton.UseVisualStyleBackColor = true;
            this.ExtractMkvExtractByExternalButton.Click += new System.EventHandler(this.ExtractMkvExtractByExternalButton_Click);
            // 
            // ExtractMkvExtractTrack4Button
            // 
            this.ExtractMkvExtractTrack4Button.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.ExtractMkvExtractTrack4Button.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ExtractMkvExtractTrack4Button.Location = new System.Drawing.Point(402, 47);
            this.ExtractMkvExtractTrack4Button.Name = "ExtractMkvExtractTrack4Button";
            this.ExtractMkvExtractTrack4Button.Size = new System.Drawing.Size(75, 23);
            this.ExtractMkvExtractTrack4Button.TabIndex = 16;
            this.ExtractMkvExtractTrack4Button.Text = "抽取轨道4";
            this.ExtractMkvExtractTrack4Button.UseVisualStyleBackColor = true;
            this.ExtractMkvExtractTrack4Button.Click += new System.EventHandler(this.ExtractMkvExtractTrack4Button_Click);
            // 
            // ExtractMkvExtractTrack3Button
            // 
            this.ExtractMkvExtractTrack3Button.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.ExtractMkvExtractTrack3Button.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ExtractMkvExtractTrack3Button.Location = new System.Drawing.Point(321, 47);
            this.ExtractMkvExtractTrack3Button.Name = "ExtractMkvExtractTrack3Button";
            this.ExtractMkvExtractTrack3Button.Size = new System.Drawing.Size(75, 23);
            this.ExtractMkvExtractTrack3Button.TabIndex = 16;
            this.ExtractMkvExtractTrack3Button.Text = "抽取轨道3";
            this.ExtractMkvExtractTrack3Button.UseVisualStyleBackColor = true;
            this.ExtractMkvExtractTrack3Button.Click += new System.EventHandler(this.ExtractMkvExtractTrack3Button_Click);
            // 
            // ExtractMkvExtractTrack2Button
            // 
            this.ExtractMkvExtractTrack2Button.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.ExtractMkvExtractTrack2Button.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ExtractMkvExtractTrack2Button.Location = new System.Drawing.Point(240, 47);
            this.ExtractMkvExtractTrack2Button.Name = "ExtractMkvExtractTrack2Button";
            this.ExtractMkvExtractTrack2Button.Size = new System.Drawing.Size(75, 23);
            this.ExtractMkvExtractTrack2Button.TabIndex = 16;
            this.ExtractMkvExtractTrack2Button.Text = "抽取轨道2";
            this.ExtractMkvExtractTrack2Button.UseVisualStyleBackColor = true;
            this.ExtractMkvExtractTrack2Button.Click += new System.EventHandler(this.ExtractMkvExtractTrack2Button_Click);
            // 
            // ExtractMkvExtractTrack1Button
            // 
            this.ExtractMkvExtractTrack1Button.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.ExtractMkvExtractTrack1Button.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ExtractMkvExtractTrack1Button.Location = new System.Drawing.Point(159, 47);
            this.ExtractMkvExtractTrack1Button.Name = "ExtractMkvExtractTrack1Button";
            this.ExtractMkvExtractTrack1Button.Size = new System.Drawing.Size(75, 23);
            this.ExtractMkvExtractTrack1Button.TabIndex = 16;
            this.ExtractMkvExtractTrack1Button.Text = "抽取轨道1";
            this.ExtractMkvExtractTrack1Button.UseVisualStyleBackColor = true;
            this.ExtractMkvExtractTrack1Button.Click += new System.EventHandler(this.ExtractMkvExtractTrack1Button_Click);
            // 
            // ExtractMkvExtractTrack0Button
            // 
            this.ExtractMkvExtractTrack0Button.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.ExtractMkvExtractTrack0Button.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ExtractMkvExtractTrack0Button.Location = new System.Drawing.Point(483, 47);
            this.ExtractMkvExtractTrack0Button.Name = "ExtractMkvExtractTrack0Button";
            this.ExtractMkvExtractTrack0Button.Size = new System.Drawing.Size(75, 23);
            this.ExtractMkvExtractTrack0Button.TabIndex = 16;
            this.ExtractMkvExtractTrack0Button.Text = "抽取轨道0";
            this.ExtractMkvExtractTrack0Button.UseVisualStyleBackColor = true;
            this.ExtractMkvExtractTrack0Button.Click += new System.EventHandler(this.ExtractMkvExtractTrack0Button_Click);
            // 
            // ExtractMkvInputButton
            // 
            this.ExtractMkvInputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.ExtractMkvInputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ExtractMkvInputButton.Location = new System.Drawing.Point(483, 18);
            this.ExtractMkvInputButton.Name = "ExtractMkvInputButton";
            this.ExtractMkvInputButton.Size = new System.Drawing.Size(75, 23);
            this.ExtractMkvInputButton.TabIndex = 14;
            this.ExtractMkvInputButton.Text = "视频";
            this.ExtractMkvInputButton.UseVisualStyleBackColor = true;
            this.ExtractMkvInputButton.Click += new System.EventHandler(this.ExtractMkvInputButton_Click);
            // 
            // ExtractMkvInputTextBox
            // 
            this.ExtractMkvInputTextBox.AllowDrop = true;
            this.ExtractMkvInputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ExtractMkvInputTextBox.EmptyTextTip = "";
            this.ExtractMkvInputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.ExtractMkvInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ExtractMkvInputTextBox.Location = new System.Drawing.Point(10, 18);
            this.ExtractMkvInputTextBox.Name = "ExtractMkvInputTextBox";
            this.ExtractMkvInputTextBox.ReadOnly = true;
            this.ExtractMkvInputTextBox.Size = new System.Drawing.Size(467, 21);
            this.ExtractMkvInputTextBox.TabIndex = 15;
            this.ExtractMkvInputTextBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ExtractMkvInputTextBox_MouseDoubleClick);
            // 
            // ExtractFlvGroupBox
            // 
            this.ExtractFlvGroupBox.Controls.Add(this.ExtractFlvExtractVideoButton);
            this.ExtractFlvGroupBox.Controls.Add(this.ExtractFlvInputButton);
            this.ExtractFlvGroupBox.Controls.Add(this.ExtractFlvInputTextBox);
            this.ExtractFlvGroupBox.Controls.Add(this.ExtractFlvExtractAudioButton);
            this.ExtractFlvGroupBox.Location = new System.Drawing.Point(0, 89);
            this.ExtractFlvGroupBox.Name = "ExtractFlvGroupBox";
            this.ExtractFlvGroupBox.Size = new System.Drawing.Size(570, 85);
            this.ExtractFlvGroupBox.TabIndex = 20;
            this.ExtractFlvGroupBox.TabStop = false;
            this.ExtractFlvGroupBox.Text = "FLV";
            // 
            // ExtractFlvExtractVideoButton
            // 
            this.ExtractFlvExtractVideoButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.ExtractFlvExtractVideoButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ExtractFlvExtractVideoButton.Location = new System.Drawing.Point(483, 50);
            this.ExtractFlvExtractVideoButton.Name = "ExtractFlvExtractVideoButton";
            this.ExtractFlvExtractVideoButton.Size = new System.Drawing.Size(75, 23);
            this.ExtractFlvExtractVideoButton.TabIndex = 12;
            this.ExtractFlvExtractVideoButton.Text = "抽取视频";
            this.ExtractFlvExtractVideoButton.UseVisualStyleBackColor = true;
            this.ExtractFlvExtractVideoButton.Click += new System.EventHandler(this.ExtractFlvExtractVideoButton_Click);
            // 
            // ExtractFlvInputButton
            // 
            this.ExtractFlvInputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.ExtractFlvInputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ExtractFlvInputButton.Location = new System.Drawing.Point(483, 17);
            this.ExtractFlvInputButton.Name = "ExtractFlvInputButton";
            this.ExtractFlvInputButton.Size = new System.Drawing.Size(75, 23);
            this.ExtractFlvInputButton.TabIndex = 3;
            this.ExtractFlvInputButton.Text = "视频";
            this.ExtractFlvInputButton.UseVisualStyleBackColor = true;
            this.ExtractFlvInputButton.Click += new System.EventHandler(this.ExtractFlvInputButton_Click);
            // 
            // ExtractFlvInputTextBox
            // 
            this.ExtractFlvInputTextBox.AllowDrop = true;
            this.ExtractFlvInputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ExtractFlvInputTextBox.EmptyTextTip = "";
            this.ExtractFlvInputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.ExtractFlvInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ExtractFlvInputTextBox.Location = new System.Drawing.Point(6, 17);
            this.ExtractFlvInputTextBox.Name = "ExtractFlvInputTextBox";
            this.ExtractFlvInputTextBox.ReadOnly = true;
            this.ExtractFlvInputTextBox.Size = new System.Drawing.Size(471, 21);
            this.ExtractFlvInputTextBox.TabIndex = 4;
            this.ExtractFlvInputTextBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ExtractFlvInputTextBox_MouseDoubleClick);
            // 
            // ExtractFlvExtractAudioButton
            // 
            this.ExtractFlvExtractAudioButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.ExtractFlvExtractAudioButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ExtractFlvExtractAudioButton.Location = new System.Drawing.Point(402, 50);
            this.ExtractFlvExtractAudioButton.Name = "ExtractFlvExtractAudioButton";
            this.ExtractFlvExtractAudioButton.Size = new System.Drawing.Size(75, 23);
            this.ExtractFlvExtractAudioButton.TabIndex = 13;
            this.ExtractFlvExtractAudioButton.Text = "抽取音频";
            this.ExtractFlvExtractAudioButton.UseVisualStyleBackColor = true;
            this.ExtractFlvExtractAudioButton.Click += new System.EventHandler(this.ExtractFlvExtractAudioButton_Click);
            // 
            // ExtractMp4GroupBox
            // 
            this.ExtractMp4GroupBox.Controls.Add(this.ExtractMp4InputTextBox);
            this.ExtractMp4GroupBox.Controls.Add(this.ExtractMp4ExtractAudio3Button);
            this.ExtractMp4GroupBox.Controls.Add(this.ExtractMp4InputButton);
            this.ExtractMp4GroupBox.Controls.Add(this.ExtractMp4ExtractVideoButton);
            this.ExtractMp4GroupBox.Controls.Add(this.ExtractMp4ExtractAudio1Button);
            this.ExtractMp4GroupBox.Controls.Add(this.ExtractMp4ExtractAudio2Button);
            this.ExtractMp4GroupBox.Location = new System.Drawing.Point(0, 6);
            this.ExtractMp4GroupBox.Name = "ExtractMp4GroupBox";
            this.ExtractMp4GroupBox.Size = new System.Drawing.Size(570, 83);
            this.ExtractMp4GroupBox.TabIndex = 19;
            this.ExtractMp4GroupBox.TabStop = false;
            this.ExtractMp4GroupBox.Text = "所有格式";
            // 
            // ExtractMp4InputTextBox
            // 
            this.ExtractMp4InputTextBox.AllowDrop = true;
            this.ExtractMp4InputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ExtractMp4InputTextBox.EmptyTextTip = "";
            this.ExtractMp4InputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.ExtractMp4InputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ExtractMp4InputTextBox.Location = new System.Drawing.Point(6, 18);
            this.ExtractMp4InputTextBox.Name = "ExtractMp4InputTextBox";
            this.ExtractMp4InputTextBox.ReadOnly = true;
            this.ExtractMp4InputTextBox.Size = new System.Drawing.Size(471, 21);
            this.ExtractMp4InputTextBox.TabIndex = 22;
            // 
            // ExtractMp4ExtractAudio3Button
            // 
            this.ExtractMp4ExtractAudio3Button.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.ExtractMp4ExtractAudio3Button.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ExtractMp4ExtractAudio3Button.Location = new System.Drawing.Point(402, 47);
            this.ExtractMp4ExtractAudio3Button.Name = "ExtractMp4ExtractAudio3Button";
            this.ExtractMp4ExtractAudio3Button.Size = new System.Drawing.Size(75, 23);
            this.ExtractMp4ExtractAudio3Button.TabIndex = 18;
            this.ExtractMp4ExtractAudio3Button.Text = "抽取音频3";
            this.ExtractMp4ExtractAudio3Button.UseVisualStyleBackColor = true;
            this.ExtractMp4ExtractAudio3Button.Click += new System.EventHandler(this.ExtractMp4ExtractAudio3Button_Click);
            // 
            // ExtractMp4InputButton
            // 
            this.ExtractMp4InputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.ExtractMp4InputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ExtractMp4InputButton.Location = new System.Drawing.Point(483, 18);
            this.ExtractMp4InputButton.Name = "ExtractMp4InputButton";
            this.ExtractMp4InputButton.Size = new System.Drawing.Size(75, 23);
            this.ExtractMp4InputButton.TabIndex = 21;
            this.ExtractMp4InputButton.Text = "视频";
            this.ExtractMp4InputButton.UseVisualStyleBackColor = true;
            this.ExtractMp4InputButton.Click += new System.EventHandler(this.ExtractMp4InputButton_Click);
            // 
            // ExtractMp4ExtractVideoButton
            // 
            this.ExtractMp4ExtractVideoButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.ExtractMp4ExtractVideoButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ExtractMp4ExtractVideoButton.Location = new System.Drawing.Point(483, 47);
            this.ExtractMp4ExtractVideoButton.Name = "ExtractMp4ExtractVideoButton";
            this.ExtractMp4ExtractVideoButton.Size = new System.Drawing.Size(75, 23);
            this.ExtractMp4ExtractVideoButton.TabIndex = 10;
            this.ExtractMp4ExtractVideoButton.Text = "抽取视频";
            this.ExtractMp4ExtractVideoButton.UseVisualStyleBackColor = true;
            this.ExtractMp4ExtractVideoButton.Click += new System.EventHandler(this.ExtractMp4ExtractVideoButton_Click);
            // 
            // ExtractMp4ExtractAudio1Button
            // 
            this.ExtractMp4ExtractAudio1Button.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.ExtractMp4ExtractAudio1Button.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ExtractMp4ExtractAudio1Button.Location = new System.Drawing.Point(240, 47);
            this.ExtractMp4ExtractAudio1Button.Name = "ExtractMp4ExtractAudio1Button";
            this.ExtractMp4ExtractAudio1Button.Size = new System.Drawing.Size(75, 23);
            this.ExtractMp4ExtractAudio1Button.TabIndex = 11;
            this.ExtractMp4ExtractAudio1Button.Text = "抽取音频1";
            this.ExtractMp4ExtractAudio1Button.UseVisualStyleBackColor = true;
            this.ExtractMp4ExtractAudio1Button.Click += new System.EventHandler(this.ExtractMp4ExtractAudio1Button_Click);
            // 
            // ExtractMp4ExtractAudio2Button
            // 
            this.ExtractMp4ExtractAudio2Button.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.ExtractMp4ExtractAudio2Button.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ExtractMp4ExtractAudio2Button.Location = new System.Drawing.Point(321, 47);
            this.ExtractMp4ExtractAudio2Button.Name = "ExtractMp4ExtractAudio2Button";
            this.ExtractMp4ExtractAudio2Button.Size = new System.Drawing.Size(75, 23);
            this.ExtractMp4ExtractAudio2Button.TabIndex = 17;
            this.ExtractMp4ExtractAudio2Button.Text = "抽取音频2";
            this.ExtractMp4ExtractAudio2Button.UseVisualStyleBackColor = true;
            this.ExtractMp4ExtractAudio2Button.Click += new System.EventHandler(this.ExtractMp4ExtractAudio2Button_Click);
            // 
            // MuxTab
            // 
            this.MuxTab.Controls.Add(this.MuxConvertGroupBox);
            this.MuxTab.Controls.Add(this.MuxMp4GroupBox);
            this.MuxTab.Controls.Add(this.MuxMkvGroupBox);
            this.MuxTab.Location = new System.Drawing.Point(4, 22);
            this.MuxTab.Name = "MuxTab";
            this.MuxTab.Padding = new System.Windows.Forms.Padding(3);
            this.MuxTab.Size = new System.Drawing.Size(192, 74);
            this.MuxTab.TabIndex = 7;
            this.MuxTab.Text = "封装";
            this.MuxTab.UseVisualStyleBackColor = true;
            // 
            // MuxConvertGroupBox
            // 
            this.MuxConvertGroupBox.Controls.Add(this.MuxConvertAacEncoderLabel);
            this.MuxConvertGroupBox.Controls.Add(this.MuxConvertAacEncoderComboBox);
            this.MuxConvertGroupBox.Controls.Add(this.MuxConvertFormatLabel);
            this.MuxConvertGroupBox.Controls.Add(this.MuxConvertFormatComboBox);
            this.MuxConvertGroupBox.Controls.Add(this.MuxConvertItemListBox);
            this.MuxConvertGroupBox.Controls.Add(this.MuxConvertAddButton);
            this.MuxConvertGroupBox.Controls.Add(this.MuxConvertClearButton);
            this.MuxConvertGroupBox.Controls.Add(this.MuxConvertOutputNotificationLabel);
            this.MuxConvertGroupBox.Controls.Add(this.MuxConvertDeleteButton);
            this.MuxConvertGroupBox.Controls.Add(this.MuxConvertStartButton);
            this.MuxConvertGroupBox.Location = new System.Drawing.Point(0, 321);
            this.MuxConvertGroupBox.Name = "MuxConvertGroupBox";
            this.MuxConvertGroupBox.Size = new System.Drawing.Size(570, 267);
            this.MuxConvertGroupBox.TabIndex = 23;
            this.MuxConvertGroupBox.TabStop = false;
            this.MuxConvertGroupBox.Text = "封装转换";
            // 
            // MuxConvertAacEncoderLabel
            // 
            this.MuxConvertAacEncoderLabel.AutoSize = true;
            this.MuxConvertAacEncoderLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxConvertAacEncoderLabel.Location = new System.Drawing.Point(8, 246);
            this.MuxConvertAacEncoderLabel.Name = "MuxConvertAacEncoderLabel";
            this.MuxConvertAacEncoderLabel.Size = new System.Drawing.Size(64, 13);
            this.MuxConvertAacEncoderLabel.TabIndex = 22;
            this.MuxConvertAacEncoderLabel.Text = "AAC编码器";
            // 
            // MuxConvertAacEncoderComboBox
            // 
            this.MuxConvertAacEncoderComboBox.FormattingEnabled = true;
            this.MuxConvertAacEncoderComboBox.Items.AddRange(new object[] {
            "aac",
            "libfdk_aac"});
            this.MuxConvertAacEncoderComboBox.Location = new System.Drawing.Point(91, 241);
            this.MuxConvertAacEncoderComboBox.Name = "MuxConvertAacEncoderComboBox";
            this.MuxConvertAacEncoderComboBox.Size = new System.Drawing.Size(98, 21);
            this.MuxConvertAacEncoderComboBox.TabIndex = 21;
            this.MuxConvertAacEncoderComboBox.Text = "aac";
            // 
            // MuxConvertFormatLabel
            // 
            this.MuxConvertFormatLabel.AutoSize = true;
            this.MuxConvertFormatLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxConvertFormatLabel.Location = new System.Drawing.Point(204, 246);
            this.MuxConvertFormatLabel.Name = "MuxConvertFormatLabel";
            this.MuxConvertFormatLabel.Size = new System.Drawing.Size(55, 13);
            this.MuxConvertFormatLabel.TabIndex = 20;
            this.MuxConvertFormatLabel.Text = "输出格式";
            // 
            // MuxConvertFormatComboBox
            // 
            this.MuxConvertFormatComboBox.FormattingEnabled = true;
            this.MuxConvertFormatComboBox.Items.AddRange(new object[] {
            "flv",
            "mp4",
            "mkv",
            "mov",
            "avi",
            "f4v"});
            this.MuxConvertFormatComboBox.Location = new System.Drawing.Point(269, 241);
            this.MuxConvertFormatComboBox.Name = "MuxConvertFormatComboBox";
            this.MuxConvertFormatComboBox.Size = new System.Drawing.Size(49, 21);
            this.MuxConvertFormatComboBox.TabIndex = 19;
            // 
            // MuxConvertItemListBox
            // 
            this.MuxConvertItemListBox.AllowDrop = true;
            this.MuxConvertItemListBox.FormattingEnabled = true;
            this.MuxConvertItemListBox.HorizontalScrollbar = true;
            this.MuxConvertItemListBox.Location = new System.Drawing.Point(6, 19);
            this.MuxConvertItemListBox.Name = "MuxConvertItemListBox";
            this.MuxConvertItemListBox.Size = new System.Drawing.Size(471, 212);
            this.MuxConvertItemListBox.TabIndex = 12;
            this.MuxConvertItemListBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.MuxConvertItemListBox_DragDrop);
            this.MuxConvertItemListBox.DragOver += new System.Windows.Forms.DragEventHandler(this.MuxConvertItemListBox_DragOver);
            this.MuxConvertItemListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MuxConvertItemListBox_MouseDown);
            // 
            // MuxConvertAddButton
            // 
            this.MuxConvertAddButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MuxConvertAddButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxConvertAddButton.Location = new System.Drawing.Point(483, 19);
            this.MuxConvertAddButton.Name = "MuxConvertAddButton";
            this.MuxConvertAddButton.Size = new System.Drawing.Size(75, 23);
            this.MuxConvertAddButton.TabIndex = 15;
            this.MuxConvertAddButton.Text = "添加";
            this.MuxConvertAddButton.UseVisualStyleBackColor = true;
            this.MuxConvertAddButton.Click += new System.EventHandler(this.MuxConvertAddButton_Click);
            // 
            // MuxConvertClearButton
            // 
            this.MuxConvertClearButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MuxConvertClearButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxConvertClearButton.Location = new System.Drawing.Point(483, 77);
            this.MuxConvertClearButton.Name = "MuxConvertClearButton";
            this.MuxConvertClearButton.Size = new System.Drawing.Size(75, 23);
            this.MuxConvertClearButton.TabIndex = 17;
            this.MuxConvertClearButton.Text = "清空";
            this.MuxConvertClearButton.UseVisualStyleBackColor = true;
            this.MuxConvertClearButton.Click += new System.EventHandler(this.MuxConvertClearButton_Click);
            // 
            // MuxConvertOutputNotificationLabel
            // 
            this.MuxConvertOutputNotificationLabel.AutoSize = true;
            this.MuxConvertOutputNotificationLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxConvertOutputNotificationLabel.Location = new System.Drawing.Point(357, 246);
            this.MuxConvertOutputNotificationLabel.Name = "MuxConvertOutputNotificationLabel";
            this.MuxConvertOutputNotificationLabel.Size = new System.Drawing.Size(103, 13);
            this.MuxConvertOutputNotificationLabel.TabIndex = 18;
            this.MuxConvertOutputNotificationLabel.Text = "输出到源文件目录";
            // 
            // MuxConvertDeleteButton
            // 
            this.MuxConvertDeleteButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MuxConvertDeleteButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxConvertDeleteButton.Location = new System.Drawing.Point(483, 48);
            this.MuxConvertDeleteButton.Name = "MuxConvertDeleteButton";
            this.MuxConvertDeleteButton.Size = new System.Drawing.Size(75, 23);
            this.MuxConvertDeleteButton.TabIndex = 16;
            this.MuxConvertDeleteButton.Text = "删除";
            this.MuxConvertDeleteButton.UseVisualStyleBackColor = true;
            this.MuxConvertDeleteButton.Click += new System.EventHandler(this.MuxConvertDeleteButton_Click);
            // 
            // MuxConvertStartButton
            // 
            this.MuxConvertStartButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MuxConvertStartButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxConvertStartButton.Location = new System.Drawing.Point(483, 239);
            this.MuxConvertStartButton.Name = "MuxConvertStartButton";
            this.MuxConvertStartButton.Size = new System.Drawing.Size(75, 23);
            this.MuxConvertStartButton.TabIndex = 14;
            this.MuxConvertStartButton.Text = "封装";
            this.MuxConvertStartButton.UseVisualStyleBackColor = true;
            this.MuxConvertStartButton.Click += new System.EventHandler(this.MuxConvertStartButton_Click);
            // 
            // MuxMp4GroupBox
            // 
            this.MuxMp4GroupBox.Controls.Add(this.MuxMp4ParComboBox);
            this.MuxMp4GroupBox.Controls.Add(this.MuxMp4ParLabel);
            this.MuxMp4GroupBox.Controls.Add(this.MuxMp4ReplaceAudioButton);
            this.MuxMp4GroupBox.Controls.Add(this.MuxMp4VideoInputTextBox);
            this.MuxMp4GroupBox.Controls.Add(this.MuxMp4VideoInputButton);
            this.MuxMp4GroupBox.Controls.Add(this.MuxMp4StartButton);
            this.MuxMp4GroupBox.Controls.Add(this.MuxMp4FpsComboBox);
            this.MuxMp4GroupBox.Controls.Add(this.MuxMp4AudioInputButton);
            this.MuxMp4GroupBox.Controls.Add(this.MuxMp4OutputButton);
            this.MuxMp4GroupBox.Controls.Add(this.MuxMp4AudioInputTextBox);
            this.MuxMp4GroupBox.Controls.Add(this.MuxMp4FpsLabel);
            this.MuxMp4GroupBox.Controls.Add(this.MuxMp4OutputTextBox);
            this.MuxMp4GroupBox.Location = new System.Drawing.Point(0, 6);
            this.MuxMp4GroupBox.Name = "MuxMp4GroupBox";
            this.MuxMp4GroupBox.Size = new System.Drawing.Size(570, 140);
            this.MuxMp4GroupBox.TabIndex = 22;
            this.MuxMp4GroupBox.TabStop = false;
            this.MuxMp4GroupBox.Text = "合并为MP4";
            // 
            // MuxMp4ParComboBox
            // 
            this.MuxMp4ParComboBox.FormattingEnabled = true;
            this.MuxMp4ParComboBox.Items.AddRange(new object[] {
            "1:1",
            "4:3",
            "8:9",
            "10:11",
            "12:11",
            "16:11",
            "32:27",
            "40:33",
            "64:45"});
            this.MuxMp4ParComboBox.Location = new System.Drawing.Point(195, 107);
            this.MuxMp4ParComboBox.Name = "MuxMp4ParComboBox";
            this.MuxMp4ParComboBox.Size = new System.Drawing.Size(89, 21);
            this.MuxMp4ParComboBox.TabIndex = 18;
            this.MuxMp4ParComboBox.Text = "1:1";
            // 
            // MuxMp4ParLabel
            // 
            this.MuxMp4ParLabel.AutoSize = true;
            this.MuxMp4ParLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxMp4ParLabel.Location = new System.Drawing.Point(166, 111);
            this.MuxMp4ParLabel.Name = "MuxMp4ParLabel";
            this.MuxMp4ParLabel.Size = new System.Drawing.Size(29, 13);
            this.MuxMp4ParLabel.TabIndex = 19;
            this.MuxMp4ParLabel.Text = "PAR";
            // 
            // MuxMp4ReplaceAudioButton
            // 
            this.MuxMp4ReplaceAudioButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MuxMp4ReplaceAudioButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxMp4ReplaceAudioButton.Location = new System.Drawing.Point(359, 105);
            this.MuxMp4ReplaceAudioButton.Name = "MuxMp4ReplaceAudioButton";
            this.MuxMp4ReplaceAudioButton.Size = new System.Drawing.Size(118, 23);
            this.MuxMp4ReplaceAudioButton.TabIndex = 17;
            this.MuxMp4ReplaceAudioButton.Text = "替换音频";
            this.MuxMp4ReplaceAudioButton.UseVisualStyleBackColor = true;
            this.MuxMp4ReplaceAudioButton.Click += new System.EventHandler(this.MuxMp4ReplaceAudioButton_Click);
            // 
            // MuxMp4VideoInputTextBox
            // 
            this.MuxMp4VideoInputTextBox.AllowDrop = true;
            this.MuxMp4VideoInputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MuxMp4VideoInputTextBox.EmptyTextTip = "";
            this.MuxMp4VideoInputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.MuxMp4VideoInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MuxMp4VideoInputTextBox.Location = new System.Drawing.Point(6, 18);
            this.MuxMp4VideoInputTextBox.Name = "MuxMp4VideoInputTextBox";
            this.MuxMp4VideoInputTextBox.ReadOnly = true;
            this.MuxMp4VideoInputTextBox.Size = new System.Drawing.Size(471, 21);
            this.MuxMp4VideoInputTextBox.TabIndex = 2;
            this.MuxMp4VideoInputTextBox.TextChanged += new System.EventHandler(this.MuxMp4VideoInputTextBox_TextChanged);
            this.MuxMp4VideoInputTextBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MuxMp4VideoInputTextBox_MouseDoubleClick);
            // 
            // MuxMp4VideoInputButton
            // 
            this.MuxMp4VideoInputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MuxMp4VideoInputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxMp4VideoInputButton.Location = new System.Drawing.Point(483, 18);
            this.MuxMp4VideoInputButton.Name = "MuxMp4VideoInputButton";
            this.MuxMp4VideoInputButton.Size = new System.Drawing.Size(75, 23);
            this.MuxMp4VideoInputButton.TabIndex = 0;
            this.MuxMp4VideoInputButton.Text = "视频";
            this.MuxMp4VideoInputButton.UseVisualStyleBackColor = true;
            this.MuxMp4VideoInputButton.Click += new System.EventHandler(this.MuxMp4VideoInputButton_Click);
            // 
            // MuxMp4StartButton
            // 
            this.MuxMp4StartButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MuxMp4StartButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxMp4StartButton.Location = new System.Drawing.Point(483, 105);
            this.MuxMp4StartButton.Name = "MuxMp4StartButton";
            this.MuxMp4StartButton.Size = new System.Drawing.Size(75, 23);
            this.MuxMp4StartButton.TabIndex = 6;
            this.MuxMp4StartButton.Text = "封装";
            this.MuxMp4StartButton.UseVisualStyleBackColor = true;
            this.MuxMp4StartButton.Click += new System.EventHandler(this.MuxMp4StartButton_Click);
            // 
            // MuxMp4FpsComboBox
            // 
            this.MuxMp4FpsComboBox.FormattingEnabled = true;
            this.MuxMp4FpsComboBox.Items.AddRange(new object[] {
            "auto",
            "23.976",
            "24",
            "25",
            "29.970",
            "30",
            "50",
            "59.940",
            "60"});
            this.MuxMp4FpsComboBox.Location = new System.Drawing.Point(37, 107);
            this.MuxMp4FpsComboBox.Name = "MuxMp4FpsComboBox";
            this.MuxMp4FpsComboBox.Size = new System.Drawing.Size(89, 21);
            this.MuxMp4FpsComboBox.TabIndex = 14;
            this.MuxMp4FpsComboBox.Text = "auto";
            this.MuxMp4FpsComboBox.SelectedIndexChanged += new System.EventHandler(this.MuxMp4FpsComboBox_SelectedIndexChanged);
            // 
            // MuxMp4AudioInputButton
            // 
            this.MuxMp4AudioInputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MuxMp4AudioInputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxMp4AudioInputButton.Location = new System.Drawing.Point(483, 47);
            this.MuxMp4AudioInputButton.Name = "MuxMp4AudioInputButton";
            this.MuxMp4AudioInputButton.Size = new System.Drawing.Size(75, 23);
            this.MuxMp4AudioInputButton.TabIndex = 1;
            this.MuxMp4AudioInputButton.Text = "音频";
            this.MuxMp4AudioInputButton.UseVisualStyleBackColor = true;
            this.MuxMp4AudioInputButton.Click += new System.EventHandler(this.MuxMp4AudioInputButton_Click);
            // 
            // MuxMp4OutputButton
            // 
            this.MuxMp4OutputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MuxMp4OutputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxMp4OutputButton.Location = new System.Drawing.Point(483, 76);
            this.MuxMp4OutputButton.Name = "MuxMp4OutputButton";
            this.MuxMp4OutputButton.Size = new System.Drawing.Size(75, 23);
            this.MuxMp4OutputButton.TabIndex = 5;
            this.MuxMp4OutputButton.Text = "输出";
            this.MuxMp4OutputButton.UseVisualStyleBackColor = true;
            this.MuxMp4OutputButton.Click += new System.EventHandler(this.MuxMp4OutputButton_Click);
            // 
            // MuxMp4AudioInputTextBox
            // 
            this.MuxMp4AudioInputTextBox.AllowDrop = true;
            this.MuxMp4AudioInputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MuxMp4AudioInputTextBox.EmptyTextTip = null;
            this.MuxMp4AudioInputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.MuxMp4AudioInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MuxMp4AudioInputTextBox.Location = new System.Drawing.Point(6, 47);
            this.MuxMp4AudioInputTextBox.Name = "MuxMp4AudioInputTextBox";
            this.MuxMp4AudioInputTextBox.ReadOnly = true;
            this.MuxMp4AudioInputTextBox.Size = new System.Drawing.Size(471, 21);
            this.MuxMp4AudioInputTextBox.TabIndex = 3;
            // 
            // MuxMp4FpsLabel
            // 
            this.MuxMp4FpsLabel.AutoSize = true;
            this.MuxMp4FpsLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxMp4FpsLabel.Location = new System.Drawing.Point(8, 111);
            this.MuxMp4FpsLabel.Name = "MuxMp4FpsLabel";
            this.MuxMp4FpsLabel.Size = new System.Drawing.Size(27, 13);
            this.MuxMp4FpsLabel.TabIndex = 16;
            this.MuxMp4FpsLabel.Text = "FPS";
            // 
            // MuxMp4OutputTextBox
            // 
            this.MuxMp4OutputTextBox.AllowDrop = true;
            this.MuxMp4OutputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MuxMp4OutputTextBox.EmptyTextTip = null;
            this.MuxMp4OutputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.MuxMp4OutputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MuxMp4OutputTextBox.Location = new System.Drawing.Point(6, 76);
            this.MuxMp4OutputTextBox.Name = "MuxMp4OutputTextBox";
            this.MuxMp4OutputTextBox.Size = new System.Drawing.Size(471, 21);
            this.MuxMp4OutputTextBox.TabIndex = 4;
            this.MuxMp4OutputTextBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MuxMp4OutputTextBox_MouseDoubleClick);
            // 
            // MuxMkvGroupBox
            // 
            this.MuxMkvGroupBox.Controls.Add(this.MuxMkvVideoInputTextBox);
            this.MuxMkvGroupBox.Controls.Add(this.MuxMkvOutputButton);
            this.MuxMkvGroupBox.Controls.Add(this.MuxMkvSubtitleTextBox);
            this.MuxMkvGroupBox.Controls.Add(this.MuxMkvAudioInputButton);
            this.MuxMkvGroupBox.Controls.Add(this.MuxMkvAudioInputTextBox);
            this.MuxMkvGroupBox.Controls.Add(this.MuxMkvSubtitleButton);
            this.MuxMkvGroupBox.Controls.Add(this.MuxMkvOutputTextBox);
            this.MuxMkvGroupBox.Controls.Add(this.MuxMkvVideoInputButton);
            this.MuxMkvGroupBox.Controls.Add(this.MuxMkvStartButton);
            this.MuxMkvGroupBox.Location = new System.Drawing.Point(0, 152);
            this.MuxMkvGroupBox.Name = "MuxMkvGroupBox";
            this.MuxMkvGroupBox.Size = new System.Drawing.Size(570, 163);
            this.MuxMkvGroupBox.TabIndex = 13;
            this.MuxMkvGroupBox.TabStop = false;
            this.MuxMkvGroupBox.Text = "合并为MKV";
            // 
            // MuxMkvVideoInputTextBox
            // 
            this.MuxMkvVideoInputTextBox.AllowDrop = true;
            this.MuxMkvVideoInputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MuxMkvVideoInputTextBox.EmptyTextTip = null;
            this.MuxMkvVideoInputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.MuxMkvVideoInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MuxMkvVideoInputTextBox.Location = new System.Drawing.Point(6, 18);
            this.MuxMkvVideoInputTextBox.Name = "MuxMkvVideoInputTextBox";
            this.MuxMkvVideoInputTextBox.ReadOnly = true;
            this.MuxMkvVideoInputTextBox.Size = new System.Drawing.Size(471, 21);
            this.MuxMkvVideoInputTextBox.TabIndex = 8;
            this.MuxMkvVideoInputTextBox.TextChanged += new System.EventHandler(this.MuxMkvVideoInputTextBox_TextChanged);
            this.MuxMkvVideoInputTextBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MuxMkvVideoInputTextBox_MouseDoubleClick);
            // 
            // MuxMkvOutputButton
            // 
            this.MuxMkvOutputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MuxMkvOutputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxMkvOutputButton.Location = new System.Drawing.Point(483, 105);
            this.MuxMkvOutputButton.Name = "MuxMkvOutputButton";
            this.MuxMkvOutputButton.Size = new System.Drawing.Size(75, 23);
            this.MuxMkvOutputButton.TabIndex = 11;
            this.MuxMkvOutputButton.Text = "输出";
            this.MuxMkvOutputButton.UseVisualStyleBackColor = true;
            this.MuxMkvOutputButton.Click += new System.EventHandler(this.MuxMkvOutputButton_Click);
            // 
            // MuxMkvSubtitleTextBox
            // 
            this.MuxMkvSubtitleTextBox.AllowDrop = true;
            this.MuxMkvSubtitleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MuxMkvSubtitleTextBox.EmptyTextTip = null;
            this.MuxMkvSubtitleTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.MuxMkvSubtitleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MuxMkvSubtitleTextBox.Location = new System.Drawing.Point(6, 76);
            this.MuxMkvSubtitleTextBox.Name = "MuxMkvSubtitleTextBox";
            this.MuxMkvSubtitleTextBox.ReadOnly = true;
            this.MuxMkvSubtitleTextBox.Size = new System.Drawing.Size(471, 21);
            this.MuxMkvSubtitleTextBox.TabIndex = 9;
            // 
            // MuxMkvAudioInputButton
            // 
            this.MuxMkvAudioInputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MuxMkvAudioInputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxMkvAudioInputButton.Location = new System.Drawing.Point(483, 47);
            this.MuxMkvAudioInputButton.Name = "MuxMkvAudioInputButton";
            this.MuxMkvAudioInputButton.Size = new System.Drawing.Size(75, 23);
            this.MuxMkvAudioInputButton.TabIndex = 7;
            this.MuxMkvAudioInputButton.Text = "音频";
            this.MuxMkvAudioInputButton.UseVisualStyleBackColor = true;
            this.MuxMkvAudioInputButton.Click += new System.EventHandler(this.MuxMkvAudioInputButton_Click);
            // 
            // MuxMkvAudioInputTextBox
            // 
            this.MuxMkvAudioInputTextBox.AllowDrop = true;
            this.MuxMkvAudioInputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MuxMkvAudioInputTextBox.EmptyTextTip = "";
            this.MuxMkvAudioInputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.MuxMkvAudioInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MuxMkvAudioInputTextBox.Location = new System.Drawing.Point(6, 47);
            this.MuxMkvAudioInputTextBox.Name = "MuxMkvAudioInputTextBox";
            this.MuxMkvAudioInputTextBox.ReadOnly = true;
            this.MuxMkvAudioInputTextBox.Size = new System.Drawing.Size(471, 21);
            this.MuxMkvAudioInputTextBox.TabIndex = 9;
            this.MuxMkvAudioInputTextBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MuxMkvAudioInputTextBox_MouseDoubleClick);
            // 
            // MuxMkvSubtitleButton
            // 
            this.MuxMkvSubtitleButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MuxMkvSubtitleButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxMkvSubtitleButton.Location = new System.Drawing.Point(483, 76);
            this.MuxMkvSubtitleButton.Name = "MuxMkvSubtitleButton";
            this.MuxMkvSubtitleButton.Size = new System.Drawing.Size(75, 23);
            this.MuxMkvSubtitleButton.TabIndex = 7;
            this.MuxMkvSubtitleButton.Text = "字幕";
            this.MuxMkvSubtitleButton.UseVisualStyleBackColor = true;
            this.MuxMkvSubtitleButton.Click += new System.EventHandler(this.MuxMkvSubtitleButton_Click);
            // 
            // MuxMkvOutputTextBox
            // 
            this.MuxMkvOutputTextBox.AllowDrop = true;
            this.MuxMkvOutputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MuxMkvOutputTextBox.EmptyTextTip = null;
            this.MuxMkvOutputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.MuxMkvOutputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MuxMkvOutputTextBox.Location = new System.Drawing.Point(6, 105);
            this.MuxMkvOutputTextBox.Name = "MuxMkvOutputTextBox";
            this.MuxMkvOutputTextBox.Size = new System.Drawing.Size(471, 21);
            this.MuxMkvOutputTextBox.TabIndex = 10;
            this.MuxMkvOutputTextBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MuxMkvOutputTextBox_MouseDoubleClick);
            // 
            // MuxMkvVideoInputButton
            // 
            this.MuxMkvVideoInputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MuxMkvVideoInputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxMkvVideoInputButton.Location = new System.Drawing.Point(483, 18);
            this.MuxMkvVideoInputButton.Name = "MuxMkvVideoInputButton";
            this.MuxMkvVideoInputButton.Size = new System.Drawing.Size(75, 23);
            this.MuxMkvVideoInputButton.TabIndex = 6;
            this.MuxMkvVideoInputButton.Text = "视频";
            this.MuxMkvVideoInputButton.UseVisualStyleBackColor = true;
            this.MuxMkvVideoInputButton.Click += new System.EventHandler(this.MuxMkvVideoInputButton_Click);
            // 
            // MuxMkvStartButton
            // 
            this.MuxMkvStartButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MuxMkvStartButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MuxMkvStartButton.Location = new System.Drawing.Point(483, 134);
            this.MuxMkvStartButton.Name = "MuxMkvStartButton";
            this.MuxMkvStartButton.Size = new System.Drawing.Size(75, 23);
            this.MuxMkvStartButton.TabIndex = 12;
            this.MuxMkvStartButton.Text = "封装";
            this.MuxMkvStartButton.UseVisualStyleBackColor = true;
            this.MuxMkvStartButton.Click += new System.EventHandler(this.MuxMkvStartButton_Click);
            // 
            // AudioTab
            // 
            this.AudioTab.AllowDrop = true;
            this.AudioTab.Controls.Add(this.AudioGroupBox);
            this.AudioTab.Controls.Add(this.AudioBatchGroupBox);
            this.AudioTab.Location = new System.Drawing.Point(4, 22);
            this.AudioTab.Name = "AudioTab";
            this.AudioTab.Padding = new System.Windows.Forms.Padding(3);
            this.AudioTab.Size = new System.Drawing.Size(192, 74);
            this.AudioTab.TabIndex = 2;
            this.AudioTab.Text = "音频";
            this.AudioTab.UseVisualStyleBackColor = true;
            // 
            // AudioGroupBox
            // 
            this.AudioGroupBox.Controls.Add(this.AudioPresetAddButton);
            this.AudioGroupBox.Controls.Add(this.AudioPresetDeleteButton);
            this.AudioGroupBox.Controls.Add(this.AudioPresetComboBox);
            this.AudioGroupBox.Controls.Add(this.AudioPresetLabel);
            this.AudioGroupBox.Controls.Add(this.AudioBitrateComboBox);
            this.AudioGroupBox.Controls.Add(this.AudioEncoderLabel);
            this.AudioGroupBox.Controls.Add(this.AudioEncoderComboBox);
            this.AudioGroupBox.Controls.Add(this.AudioInputTextBox);
            this.AudioGroupBox.Controls.Add(this.AudioAudioModePanel);
            this.AudioGroupBox.Controls.Add(this.AudioOutputTextBox);
            this.AudioGroupBox.Controls.Add(this.AudioInputButton);
            this.AudioGroupBox.Controls.Add(this.AudioKbpsLabel);
            this.AudioGroupBox.Controls.Add(this.AudioOutputBotton);
            this.AudioGroupBox.Controls.Add(this.AudioBitrateLabel);
            this.AudioGroupBox.Controls.Add(this.AudioStartButton);
            this.AudioGroupBox.Controls.Add(this.AudioCustomParameterTextBox);
            this.AudioGroupBox.Location = new System.Drawing.Point(0, 6);
            this.AudioGroupBox.Name = "AudioGroupBox";
            this.AudioGroupBox.Size = new System.Drawing.Size(566, 201);
            this.AudioGroupBox.TabIndex = 20;
            this.AudioGroupBox.TabStop = false;
            this.AudioGroupBox.Text = "音频压制";
            // 
            // AudioPresetAddButton
            // 
            this.AudioPresetAddButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.AudioPresetAddButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AudioPresetAddButton.Location = new System.Drawing.Point(387, 104);
            this.AudioPresetAddButton.Name = "AudioPresetAddButton";
            this.AudioPresetAddButton.Size = new System.Drawing.Size(75, 23);
            this.AudioPresetAddButton.TabIndex = 37;
            this.AudioPresetAddButton.Text = "添加";
            this.AudioPresetAddButton.UseVisualStyleBackColor = true;
            this.AudioPresetAddButton.Visible = false;
            this.AudioPresetAddButton.Click += new System.EventHandler(this.AudioPresetAddButton_Click);
            // 
            // AudioPresetDeleteButton
            // 
            this.AudioPresetDeleteButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.AudioPresetDeleteButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AudioPresetDeleteButton.Location = new System.Drawing.Point(296, 104);
            this.AudioPresetDeleteButton.Name = "AudioPresetDeleteButton";
            this.AudioPresetDeleteButton.Size = new System.Drawing.Size(75, 23);
            this.AudioPresetDeleteButton.TabIndex = 36;
            this.AudioPresetDeleteButton.Text = "删除";
            this.AudioPresetDeleteButton.UseVisualStyleBackColor = true;
            this.AudioPresetDeleteButton.Visible = false;
            this.AudioPresetDeleteButton.Click += new System.EventHandler(this.AudioPresetDeleteButton_Click);
            // 
            // AudioPresetComboBox
            // 
            this.AudioPresetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AudioPresetComboBox.FormattingEnabled = true;
            this.AudioPresetComboBox.Location = new System.Drawing.Point(103, 104);
            this.AudioPresetComboBox.Name = "AudioPresetComboBox";
            this.AudioPresetComboBox.Size = new System.Drawing.Size(122, 21);
            this.AudioPresetComboBox.TabIndex = 29;
            this.AudioPresetComboBox.Visible = false;
            this.AudioPresetComboBox.SelectedIndexChanged += new System.EventHandler(this.AudioPresetComboBox_SelectedIndexChanged);
            // 
            // AudioPresetLabel
            // 
            this.AudioPresetLabel.AutoSize = true;
            this.AudioPresetLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AudioPresetLabel.Location = new System.Drawing.Point(18, 108);
            this.AudioPresetLabel.Name = "AudioPresetLabel";
            this.AudioPresetLabel.Size = new System.Drawing.Size(31, 13);
            this.AudioPresetLabel.TabIndex = 30;
            this.AudioPresetLabel.Text = "预设";
            this.AudioPresetLabel.Visible = false;
            // 
            // AudioBitrateComboBox
            // 
            this.AudioBitrateComboBox.FormattingEnabled = true;
            this.AudioBitrateComboBox.Items.AddRange(new object[] {
            "64",
            "96",
            "128",
            "160",
            "192",
            "256",
            "320"});
            this.AudioBitrateComboBox.Location = new System.Drawing.Point(103, 104);
            this.AudioBitrateComboBox.Name = "AudioBitrateComboBox";
            this.AudioBitrateComboBox.Size = new System.Drawing.Size(122, 21);
            this.AudioBitrateComboBox.TabIndex = 20;
            this.AudioBitrateComboBox.Text = "128";
            // 
            // AudioEncoderLabel
            // 
            this.AudioEncoderLabel.AutoSize = true;
            this.AudioEncoderLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AudioEncoderLabel.Location = new System.Drawing.Point(18, 81);
            this.AudioEncoderLabel.Name = "AudioEncoderLabel";
            this.AudioEncoderLabel.Size = new System.Drawing.Size(43, 13);
            this.AudioEncoderLabel.TabIndex = 19;
            this.AudioEncoderLabel.Text = "编码器";
            // 
            // AudioEncoderComboBox
            // 
            this.AudioEncoderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AudioEncoderComboBox.FormattingEnabled = true;
            this.AudioEncoderComboBox.Items.AddRange(new object[] {
            "NeroAAC",
            "QAAC",
            "WAV",
            "ALAC",
            "FLAC",
            "FDKAAC",
            "AC3",
            "MP3"});
            this.AudioEncoderComboBox.Location = new System.Drawing.Point(103, 78);
            this.AudioEncoderComboBox.Name = "AudioEncoderComboBox";
            this.AudioEncoderComboBox.Size = new System.Drawing.Size(122, 21);
            this.AudioEncoderComboBox.TabIndex = 18;
            this.AudioEncoderComboBox.SelectedIndexChanged += new System.EventHandler(this.AudioEncoderComboBox_SelectedIndexChanged);
            // 
            // AudioInputTextBox
            // 
            this.AudioInputTextBox.AllowDrop = true;
            this.AudioInputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AudioInputTextBox.EmptyTextTip = null;
            this.AudioInputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.AudioInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.AudioInputTextBox.Location = new System.Drawing.Point(9, 20);
            this.AudioInputTextBox.Name = "AudioInputTextBox";
            this.AudioInputTextBox.ReadOnly = true;
            this.AudioInputTextBox.Size = new System.Drawing.Size(469, 21);
            this.AudioInputTextBox.TabIndex = 4;
            this.AudioInputTextBox.TextChanged += new System.EventHandler(this.AudioInputTextBox_TextChanged);
            this.AudioInputTextBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AudioInputTextBox_MouseDoubleClick);
            // 
            // AudioAudioModePanel
            // 
            this.AudioAudioModePanel.Controls.Add(this.AudioAudioModeBitrateRadioButton);
            this.AudioAudioModePanel.Controls.Add(this.AudioAudioModeCustomRadioButton);
            this.AudioAudioModePanel.Location = new System.Drawing.Point(286, 74);
            this.AudioAudioModePanel.Name = "AudioAudioModePanel";
            this.AudioAudioModePanel.Size = new System.Drawing.Size(194, 29);
            this.AudioAudioModePanel.TabIndex = 17;
            // 
            // AudioAudioModeBitrateRadioButton
            // 
            this.AudioAudioModeBitrateRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.AudioAudioModeBitrateRadioButton.Checked = true;
            this.AudioAudioModeBitrateRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.AudioAudioModeBitrateRadioButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AudioAudioModeBitrateRadioButton.Location = new System.Drawing.Point(10, 2);
            this.AudioAudioModeBitrateRadioButton.Name = "AudioAudioModeBitrateRadioButton";
            this.AudioAudioModeBitrateRadioButton.Size = new System.Drawing.Size(75, 24);
            this.AudioAudioModeBitrateRadioButton.TabIndex = 12;
            this.AudioAudioModeBitrateRadioButton.TabStop = true;
            this.AudioAudioModeBitrateRadioButton.Text = "码率";
            this.AudioAudioModeBitrateRadioButton.UseVisualStyleBackColor = true;
            this.AudioAudioModeBitrateRadioButton.CheckedChanged += new System.EventHandler(this.AudioAudioModeBitrateRadioButton_CheckedChanged);
            // 
            // AudioAudioModeCustomRadioButton
            // 
            this.AudioAudioModeCustomRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.AudioAudioModeCustomRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.AudioAudioModeCustomRadioButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AudioAudioModeCustomRadioButton.Location = new System.Drawing.Point(91, 2);
            this.AudioAudioModeCustomRadioButton.Name = "AudioAudioModeCustomRadioButton";
            this.AudioAudioModeCustomRadioButton.Size = new System.Drawing.Size(69, 24);
            this.AudioAudioModeCustomRadioButton.TabIndex = 12;
            this.AudioAudioModeCustomRadioButton.Text = "自定义";
            this.AudioAudioModeCustomRadioButton.UseVisualStyleBackColor = true;
            this.AudioAudioModeCustomRadioButton.CheckedChanged += new System.EventHandler(this.AudioAudioModeCustomRadioButton_CheckedChanged);
            // 
            // AudioOutputTextBox
            // 
            this.AudioOutputTextBox.AllowDrop = true;
            this.AudioOutputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AudioOutputTextBox.EmptyTextTip = null;
            this.AudioOutputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.AudioOutputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.AudioOutputTextBox.Location = new System.Drawing.Point(9, 49);
            this.AudioOutputTextBox.Name = "AudioOutputTextBox";
            this.AudioOutputTextBox.Size = new System.Drawing.Size(469, 21);
            this.AudioOutputTextBox.TabIndex = 4;
            this.AudioOutputTextBox.TextChanged += new System.EventHandler(this.AudioOutputTextBox_TextChanged);
            this.AudioOutputTextBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AudioOutputTextBox_MouseDoubleClick);
            // 
            // AudioInputButton
            // 
            this.AudioInputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.AudioInputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AudioInputButton.Location = new System.Drawing.Point(484, 20);
            this.AudioInputButton.Name = "AudioInputButton";
            this.AudioInputButton.Size = new System.Drawing.Size(75, 23);
            this.AudioInputButton.TabIndex = 5;
            this.AudioInputButton.Text = "输入";
            this.AudioInputButton.UseVisualStyleBackColor = true;
            this.AudioInputButton.Click += new System.EventHandler(this.AudioInputButton_Click);
            // 
            // AudioKbpsLabel
            // 
            this.AudioKbpsLabel.AutoSize = true;
            this.AudioKbpsLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AudioKbpsLabel.Location = new System.Drawing.Point(251, 110);
            this.AudioKbpsLabel.Name = "AudioKbpsLabel";
            this.AudioKbpsLabel.Size = new System.Drawing.Size(31, 13);
            this.AudioKbpsLabel.TabIndex = 7;
            this.AudioKbpsLabel.Text = "Kbps";
            // 
            // AudioOutputBotton
            // 
            this.AudioOutputBotton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.AudioOutputBotton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AudioOutputBotton.Location = new System.Drawing.Point(484, 49);
            this.AudioOutputBotton.Name = "AudioOutputBotton";
            this.AudioOutputBotton.Size = new System.Drawing.Size(75, 23);
            this.AudioOutputBotton.TabIndex = 5;
            this.AudioOutputBotton.Text = "输出";
            this.AudioOutputBotton.UseVisualStyleBackColor = true;
            this.AudioOutputBotton.Click += new System.EventHandler(this.AudioOutputBotton_Click);
            // 
            // AudioBitrateLabel
            // 
            this.AudioBitrateLabel.AutoSize = true;
            this.AudioBitrateLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AudioBitrateLabel.Location = new System.Drawing.Point(18, 108);
            this.AudioBitrateLabel.Name = "AudioBitrateLabel";
            this.AudioBitrateLabel.Size = new System.Drawing.Size(31, 13);
            this.AudioBitrateLabel.TabIndex = 7;
            this.AudioBitrateLabel.Text = "码率";
            // 
            // AudioStartButton
            // 
            this.AudioStartButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.AudioStartButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AudioStartButton.Location = new System.Drawing.Point(484, 78);
            this.AudioStartButton.Name = "AudioStartButton";
            this.AudioStartButton.Size = new System.Drawing.Size(75, 23);
            this.AudioStartButton.TabIndex = 5;
            this.AudioStartButton.Text = "压制";
            this.AudioStartButton.UseVisualStyleBackColor = true;
            this.AudioStartButton.Click += new System.EventHandler(this.AudioStartButton_Click);
            // 
            // AudioCustomParameterTextBox
            // 
            this.AudioCustomParameterTextBox.AllowDrop = true;
            this.AudioCustomParameterTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AudioCustomParameterTextBox.EmptyTextTip = null;
            this.AudioCustomParameterTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.AudioCustomParameterTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.AudioCustomParameterTextBox.Location = new System.Drawing.Point(10, 130);
            this.AudioCustomParameterTextBox.Multiline = true;
            this.AudioCustomParameterTextBox.Name = "AudioCustomParameterTextBox";
            this.AudioCustomParameterTextBox.Size = new System.Drawing.Size(468, 62);
            this.AudioCustomParameterTextBox.TabIndex = 16;
            this.AudioCustomParameterTextBox.Visible = false;
            // 
            // AudioBatchGroupBox
            // 
            this.AudioBatchGroupBox.Controls.Add(this.AudioBatchConcatButton);
            this.AudioBatchGroupBox.Controls.Add(this.AudioBatchOutputNotificationLabel);
            this.AudioBatchGroupBox.Controls.Add(this.AudioBatchStartButton);
            this.AudioBatchGroupBox.Controls.Add(this.AudioBatchItemListBox);
            this.AudioBatchGroupBox.Controls.Add(this.AudioBatchAddButton);
            this.AudioBatchGroupBox.Controls.Add(this.AudioBatchClearButton);
            this.AudioBatchGroupBox.Controls.Add(this.AudioBatchDeleteButton);
            this.AudioBatchGroupBox.Location = new System.Drawing.Point(0, 213);
            this.AudioBatchGroupBox.Name = "AudioBatchGroupBox";
            this.AudioBatchGroupBox.Size = new System.Drawing.Size(566, 375);
            this.AudioBatchGroupBox.TabIndex = 18;
            this.AudioBatchGroupBox.TabStop = false;
            this.AudioBatchGroupBox.Text = "批量压制";
            // 
            // AudioBatchConcatButton
            // 
            this.AudioBatchConcatButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.AudioBatchConcatButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AudioBatchConcatButton.Location = new System.Drawing.Point(410, 343);
            this.AudioBatchConcatButton.Name = "AudioBatchConcatButton";
            this.AudioBatchConcatButton.Size = new System.Drawing.Size(68, 23);
            this.AudioBatchConcatButton.TabIndex = 23;
            this.AudioBatchConcatButton.Text = "合并";
            this.AudioBatchConcatButton.UseVisualStyleBackColor = true;
            this.AudioBatchConcatButton.Click += new System.EventHandler(this.AudioBatchConcatButton_Click);
            // 
            // AudioBatchOutputNotificationLabel
            // 
            this.AudioBatchOutputNotificationLabel.AutoSize = true;
            this.AudioBatchOutputNotificationLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AudioBatchOutputNotificationLabel.Location = new System.Drawing.Point(8, 323);
            this.AudioBatchOutputNotificationLabel.Name = "AudioBatchOutputNotificationLabel";
            this.AudioBatchOutputNotificationLabel.Size = new System.Drawing.Size(139, 13);
            this.AudioBatchOutputNotificationLabel.TabIndex = 19;
            this.AudioBatchOutputNotificationLabel.Text = "新文件生成在源文件目录";
            // 
            // AudioBatchStartButton
            // 
            this.AudioBatchStartButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.AudioBatchStartButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AudioBatchStartButton.Location = new System.Drawing.Point(484, 343);
            this.AudioBatchStartButton.Name = "AudioBatchStartButton";
            this.AudioBatchStartButton.Size = new System.Drawing.Size(75, 23);
            this.AudioBatchStartButton.TabIndex = 22;
            this.AudioBatchStartButton.Text = "批量压制";
            this.AudioBatchStartButton.UseVisualStyleBackColor = true;
            this.AudioBatchStartButton.Click += new System.EventHandler(this.AudioBatchStartButton_Click);
            // 
            // AudioBatchItemListBox
            // 
            this.AudioBatchItemListBox.AllowDrop = true;
            this.AudioBatchItemListBox.FormattingEnabled = true;
            this.AudioBatchItemListBox.HorizontalScrollbar = true;
            this.AudioBatchItemListBox.Location = new System.Drawing.Point(9, 20);
            this.AudioBatchItemListBox.Name = "AudioBatchItemListBox";
            this.AudioBatchItemListBox.Size = new System.Drawing.Size(551, 290);
            this.AudioBatchItemListBox.TabIndex = 18;
            this.AudioBatchItemListBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.AudioBatchItemListBox_DragDrop);
            this.AudioBatchItemListBox.DragOver += new System.Windows.Forms.DragEventHandler(this.AudioBatchItemListBox_DragOver);
            this.AudioBatchItemListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AudioBatchItemListBox_MouseDown);
            // 
            // AudioBatchAddButton
            // 
            this.AudioBatchAddButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.AudioBatchAddButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AudioBatchAddButton.Location = new System.Drawing.Point(9, 343);
            this.AudioBatchAddButton.Name = "AudioBatchAddButton";
            this.AudioBatchAddButton.Size = new System.Drawing.Size(75, 23);
            this.AudioBatchAddButton.TabIndex = 19;
            this.AudioBatchAddButton.Text = "添加";
            this.AudioBatchAddButton.UseVisualStyleBackColor = true;
            this.AudioBatchAddButton.Click += new System.EventHandler(this.AudioBatchAddButton_Click);
            // 
            // AudioBatchClearButton
            // 
            this.AudioBatchClearButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.AudioBatchClearButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AudioBatchClearButton.Location = new System.Drawing.Point(171, 343);
            this.AudioBatchClearButton.Name = "AudioBatchClearButton";
            this.AudioBatchClearButton.Size = new System.Drawing.Size(75, 23);
            this.AudioBatchClearButton.TabIndex = 21;
            this.AudioBatchClearButton.Text = "清空";
            this.AudioBatchClearButton.UseVisualStyleBackColor = true;
            this.AudioBatchClearButton.Click += new System.EventHandler(this.AudioBatchClearButton_Click);
            // 
            // AudioBatchDeleteButton
            // 
            this.AudioBatchDeleteButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.AudioBatchDeleteButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AudioBatchDeleteButton.Location = new System.Drawing.Point(90, 343);
            this.AudioBatchDeleteButton.Name = "AudioBatchDeleteButton";
            this.AudioBatchDeleteButton.Size = new System.Drawing.Size(75, 23);
            this.AudioBatchDeleteButton.TabIndex = 20;
            this.AudioBatchDeleteButton.Text = "删除";
            this.AudioBatchDeleteButton.UseVisualStyleBackColor = true;
            this.AudioBatchDeleteButton.Click += new System.EventHandler(this.AudioBatchDeleteButton_Click);
            // 
            // MiscOnePicGroupBox
            // 
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicDurationSecondsLabel);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicDurationSecondsTextBox);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicDurationLabel);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicCrfNumericUpDown);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicCrfLabel);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicCopyAudioCheckBox);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicFpsLabel);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicFpsNumericUpDown);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicKbpsLabel);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicBitrateLabel);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicBitrateNumericUpDown);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicOutputButton);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicStartButton);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicAudioInputButton);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicInputButton);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicOutputTextBox);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicAudioInputTextBox);
            this.MiscOnePicGroupBox.Controls.Add(this.MiscOnePicInputTextBox);
            this.MiscOnePicGroupBox.Location = new System.Drawing.Point(0, 6);
            this.MiscOnePicGroupBox.Name = "MiscOnePicGroupBox";
            this.MiscOnePicGroupBox.Size = new System.Drawing.Size(566, 163);
            this.MiscOnePicGroupBox.TabIndex = 20;
            this.MiscOnePicGroupBox.TabStop = false;
            this.MiscOnePicGroupBox.Text = "一图流";
            // 
            // MiscOnePicDurationSecondsLabel
            // 
            this.MiscOnePicDurationSecondsLabel.AutoSize = true;
            this.MiscOnePicDurationSecondsLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscOnePicDurationSecondsLabel.Location = new System.Drawing.Point(226, 137);
            this.MiscOnePicDurationSecondsLabel.Name = "MiscOnePicDurationSecondsLabel";
            this.MiscOnePicDurationSecondsLabel.Size = new System.Drawing.Size(19, 13);
            this.MiscOnePicDurationSecondsLabel.TabIndex = 40;
            this.MiscOnePicDurationSecondsLabel.Text = "秒";
            // 
            // MiscOnePicDurationSecondsTextBox
            // 
            this.MiscOnePicDurationSecondsTextBox.Location = new System.Drawing.Point(158, 134);
            this.MiscOnePicDurationSecondsTextBox.Name = "MiscOnePicDurationSecondsTextBox";
            this.MiscOnePicDurationSecondsTextBox.Size = new System.Drawing.Size(62, 20);
            this.MiscOnePicDurationSecondsTextBox.TabIndex = 39;
            this.MiscOnePicDurationSecondsTextBox.Text = "120";
            // 
            // MiscOnePicDurationLabel
            // 
            this.MiscOnePicDurationLabel.AutoSize = true;
            this.MiscOnePicDurationLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscOnePicDurationLabel.Location = new System.Drawing.Point(105, 137);
            this.MiscOnePicDurationLabel.Name = "MiscOnePicDurationLabel";
            this.MiscOnePicDurationLabel.Size = new System.Drawing.Size(31, 13);
            this.MiscOnePicDurationLabel.TabIndex = 38;
            this.MiscOnePicDurationLabel.Text = "时间";
            // 
            // MiscOnePicCrfNumericUpDown
            // 
            this.MiscOnePicCrfNumericUpDown.DecimalPlaces = 1;
            this.MiscOnePicCrfNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.MiscOnePicCrfNumericUpDown.Location = new System.Drawing.Point(391, 107);
            this.MiscOnePicCrfNumericUpDown.Maximum = new decimal(new int[] {
            51,
            0,
            0,
            0});
            this.MiscOnePicCrfNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MiscOnePicCrfNumericUpDown.Name = "MiscOnePicCrfNumericUpDown";
            this.MiscOnePicCrfNumericUpDown.Size = new System.Drawing.Size(88, 20);
            this.MiscOnePicCrfNumericUpDown.TabIndex = 37;
            this.MiscOnePicCrfNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MiscOnePicCrfNumericUpDown.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // MiscOnePicCrfLabel
            // 
            this.MiscOnePicCrfLabel.AutoSize = true;
            this.MiscOnePicCrfLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscOnePicCrfLabel.Location = new System.Drawing.Point(362, 109);
            this.MiscOnePicCrfLabel.Name = "MiscOnePicCrfLabel";
            this.MiscOnePicCrfLabel.Size = new System.Drawing.Size(28, 13);
            this.MiscOnePicCrfLabel.TabIndex = 36;
            this.MiscOnePicCrfLabel.Text = "CRF";
            // 
            // MiscOnePicCopyAudioCheckBox
            // 
            this.MiscOnePicCopyAudioCheckBox.AutoSize = true;
            this.MiscOnePicCopyAudioCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.MiscOnePicCopyAudioCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MiscOnePicCopyAudioCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscOnePicCopyAudioCheckBox.Location = new System.Drawing.Point(390, 136);
            this.MiscOnePicCopyAudioCheckBox.Name = "MiscOnePicCopyAudioCheckBox";
            this.MiscOnePicCopyAudioCheckBox.Size = new System.Drawing.Size(74, 19);
            this.MiscOnePicCopyAudioCheckBox.TabIndex = 24;
            this.MiscOnePicCopyAudioCheckBox.Text = "复制音频";
            this.MiscOnePicCopyAudioCheckBox.UseVisualStyleBackColor = false;
            this.MiscOnePicCopyAudioCheckBox.CheckedChanged += new System.EventHandler(this.MiscOnePicCopyAudioCheckBox_CheckedChanged);
            // 
            // MiscOnePicFpsLabel
            // 
            this.MiscOnePicFpsLabel.AutoSize = true;
            this.MiscOnePicFpsLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscOnePicFpsLabel.Location = new System.Drawing.Point(275, 109);
            this.MiscOnePicFpsLabel.Name = "MiscOnePicFpsLabel";
            this.MiscOnePicFpsLabel.Size = new System.Drawing.Size(27, 13);
            this.MiscOnePicFpsLabel.TabIndex = 23;
            this.MiscOnePicFpsLabel.Text = "FPS";
            // 
            // MiscOnePicFpsNumericUpDown
            // 
            this.MiscOnePicFpsNumericUpDown.Location = new System.Drawing.Point(307, 107);
            this.MiscOnePicFpsNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.MiscOnePicFpsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MiscOnePicFpsNumericUpDown.Name = "MiscOnePicFpsNumericUpDown";
            this.MiscOnePicFpsNumericUpDown.Size = new System.Drawing.Size(48, 20);
            this.MiscOnePicFpsNumericUpDown.TabIndex = 11;
            this.MiscOnePicFpsNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MiscOnePicFpsNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MiscOnePicKbpsLabel
            // 
            this.MiscOnePicKbpsLabel.AutoSize = true;
            this.MiscOnePicKbpsLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscOnePicKbpsLabel.Location = new System.Drawing.Point(226, 109);
            this.MiscOnePicKbpsLabel.Name = "MiscOnePicKbpsLabel";
            this.MiscOnePicKbpsLabel.Size = new System.Drawing.Size(31, 13);
            this.MiscOnePicKbpsLabel.TabIndex = 9;
            this.MiscOnePicKbpsLabel.Text = "Kbps";
            // 
            // MiscOnePicBitrateLabel
            // 
            this.MiscOnePicBitrateLabel.AutoSize = true;
            this.MiscOnePicBitrateLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscOnePicBitrateLabel.Location = new System.Drawing.Point(12, 109);
            this.MiscOnePicBitrateLabel.Name = "MiscOnePicBitrateLabel";
            this.MiscOnePicBitrateLabel.Size = new System.Drawing.Size(55, 13);
            this.MiscOnePicBitrateLabel.TabIndex = 10;
            this.MiscOnePicBitrateLabel.Text = "音频码率";
            // 
            // MiscOnePicBitrateNumericUpDown
            // 
            this.MiscOnePicBitrateNumericUpDown.Location = new System.Drawing.Point(158, 107);
            this.MiscOnePicBitrateNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.MiscOnePicBitrateNumericUpDown.Name = "MiscOnePicBitrateNumericUpDown";
            this.MiscOnePicBitrateNumericUpDown.Size = new System.Drawing.Size(62, 20);
            this.MiscOnePicBitrateNumericUpDown.TabIndex = 8;
            this.MiscOnePicBitrateNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MiscOnePicBitrateNumericUpDown.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            // 
            // MiscOnePicOutputButton
            // 
            this.MiscOnePicOutputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MiscOnePicOutputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscOnePicOutputButton.Location = new System.Drawing.Point(484, 78);
            this.MiscOnePicOutputButton.Name = "MiscOnePicOutputButton";
            this.MiscOnePicOutputButton.Size = new System.Drawing.Size(75, 23);
            this.MiscOnePicOutputButton.TabIndex = 3;
            this.MiscOnePicOutputButton.Text = "输出";
            this.MiscOnePicOutputButton.UseVisualStyleBackColor = true;
            this.MiscOnePicOutputButton.Click += new System.EventHandler(this.MiscOnePicOutputButton_Click);
            // 
            // MiscOnePicStartButton
            // 
            this.MiscOnePicStartButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MiscOnePicStartButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscOnePicStartButton.Location = new System.Drawing.Point(484, 107);
            this.MiscOnePicStartButton.Name = "MiscOnePicStartButton";
            this.MiscOnePicStartButton.Size = new System.Drawing.Size(75, 23);
            this.MiscOnePicStartButton.TabIndex = 2;
            this.MiscOnePicStartButton.Text = "压制";
            this.MiscOnePicStartButton.UseVisualStyleBackColor = true;
            this.MiscOnePicStartButton.Click += new System.EventHandler(this.MiscOnePicStartButton_Click);
            // 
            // MiscOnePicAudioInputButton
            // 
            this.MiscOnePicAudioInputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MiscOnePicAudioInputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscOnePicAudioInputButton.Location = new System.Drawing.Point(484, 49);
            this.MiscOnePicAudioInputButton.Name = "MiscOnePicAudioInputButton";
            this.MiscOnePicAudioInputButton.Size = new System.Drawing.Size(75, 23);
            this.MiscOnePicAudioInputButton.TabIndex = 2;
            this.MiscOnePicAudioInputButton.Text = "音频";
            this.MiscOnePicAudioInputButton.UseVisualStyleBackColor = true;
            this.MiscOnePicAudioInputButton.Click += new System.EventHandler(this.MiscOnePicAudioInputButton_Click);
            // 
            // MiscOnePicInputButton
            // 
            this.MiscOnePicInputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MiscOnePicInputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscOnePicInputButton.Location = new System.Drawing.Point(484, 20);
            this.MiscOnePicInputButton.Name = "MiscOnePicInputButton";
            this.MiscOnePicInputButton.Size = new System.Drawing.Size(75, 23);
            this.MiscOnePicInputButton.TabIndex = 2;
            this.MiscOnePicInputButton.Text = "图片";
            this.MiscOnePicInputButton.UseVisualStyleBackColor = true;
            this.MiscOnePicInputButton.Click += new System.EventHandler(this.MiscOnePicInputButton_Click);
            // 
            // MiscOnePicOutputTextBox
            // 
            this.MiscOnePicOutputTextBox.AllowDrop = true;
            this.MiscOnePicOutputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MiscOnePicOutputTextBox.EmptyTextTip = null;
            this.MiscOnePicOutputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.MiscOnePicOutputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MiscOnePicOutputTextBox.Location = new System.Drawing.Point(10, 78);
            this.MiscOnePicOutputTextBox.Name = "MiscOnePicOutputTextBox";
            this.MiscOnePicOutputTextBox.Size = new System.Drawing.Size(469, 21);
            this.MiscOnePicOutputTextBox.TabIndex = 1;
            // 
            // MiscOnePicAudioInputTextBox
            // 
            this.MiscOnePicAudioInputTextBox.AllowDrop = true;
            this.MiscOnePicAudioInputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MiscOnePicAudioInputTextBox.EmptyTextTip = null;
            this.MiscOnePicAudioInputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.MiscOnePicAudioInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MiscOnePicAudioInputTextBox.Location = new System.Drawing.Point(10, 49);
            this.MiscOnePicAudioInputTextBox.Name = "MiscOnePicAudioInputTextBox";
            this.MiscOnePicAudioInputTextBox.ReadOnly = true;
            this.MiscOnePicAudioInputTextBox.Size = new System.Drawing.Size(469, 21);
            this.MiscOnePicAudioInputTextBox.TabIndex = 1;
            this.MiscOnePicAudioInputTextBox.TextChanged += new System.EventHandler(this.MiscOnePicAudioInputTextBox_TextChanged);
            // 
            // MiscOnePicInputTextBox
            // 
            this.MiscOnePicInputTextBox.AllowDrop = true;
            this.MiscOnePicInputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MiscOnePicInputTextBox.EmptyTextTip = null;
            this.MiscOnePicInputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.MiscOnePicInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MiscOnePicInputTextBox.Location = new System.Drawing.Point(10, 20);
            this.MiscOnePicInputTextBox.Name = "MiscOnePicInputTextBox";
            this.MiscOnePicInputTextBox.ReadOnly = true;
            this.MiscOnePicInputTextBox.Size = new System.Drawing.Size(469, 21);
            this.MiscOnePicInputTextBox.TabIndex = 0;
            // 
            // VideoTab
            // 
            this.VideoTab.AllowDrop = true;
            this.VideoTab.Controls.Add(this.VideoFramesLabel);
            this.VideoTab.Controls.Add(this.VideoSeekLabel);
            this.VideoTab.Controls.Add(this.VideoFramesNumericUpDown);
            this.VideoTab.Controls.Add(this.VideoSeekNumericUpDown);
            this.VideoTab.Controls.Add(this.VideoMaintainResolutionCheckBox);
            this.VideoTab.Controls.Add(this.VideoDemuxerComboBox);
            this.VideoTab.Controls.Add(this.VideoBatchGroupBox);
            this.VideoTab.Controls.Add(this.VideoAutoShutdownCheckBox);
            this.VideoTab.Controls.Add(this.VideoAudioParameterTextBox);
            this.VideoTab.Controls.Add(this.VideoSubtitleTextBox);
            this.VideoTab.Controls.Add(this.VideoOutputTextBox);
            this.VideoTab.Controls.Add(this.VideoInputTextBox);
            this.VideoTab.Controls.Add(this.VideoX264ModePanel);
            this.VideoTab.Controls.Add(this.VideoDemuxerLabel);
            this.VideoTab.Controls.Add(this.VideoAddPresetButton);
            this.VideoTab.Controls.Add(this.VideoDeletePresetButton);
            this.VideoTab.Controls.Add(this.VideoStartButton);
            this.VideoTab.Controls.Add(this.VideoSubtitleButton);
            this.VideoTab.Controls.Add(this.VideoOutputButton);
            this.VideoTab.Controls.Add(this.VideoInputButton);
            this.VideoTab.Controls.Add(this.VideoEncoderLabel);
            this.VideoTab.Controls.Add(this.VideoEncoderComboBox);
            this.VideoTab.Controls.Add(this.VideoFpsComboBox);
            this.VideoTab.Controls.Add(this.VideoFpsLabel);
            this.VideoTab.Controls.Add(this.VideoAudioModeComboBox);
            this.VideoTab.Controls.Add(this.VideoPresetComboBox);
            this.VideoTab.Controls.Add(this.VideoAudioModeLabel);
            this.VideoTab.Controls.Add(this.VideoGoToAudioLabel);
            this.VideoTab.Controls.Add(this.VideoBitrateKbpsLabel);
            this.VideoTab.Controls.Add(this.VideoCrfLabel);
            this.VideoTab.Controls.Add(this.VideoHeightLabel);
            this.VideoTab.Controls.Add(this.VideoWidthLabel);
            this.VideoTab.Controls.Add(this.VideoHeightNumericUpDown);
            this.VideoTab.Controls.Add(this.VideoWidthNumericUpDown);
            this.VideoTab.Controls.Add(this.VideoCrfNumericUpDown);
            this.VideoTab.Controls.Add(this.VideoBitrateLabel);
            this.VideoTab.Controls.Add(this.VideoCustomParameterTextBox);
            this.VideoTab.Controls.Add(this.VideoPresetLabel);
            this.VideoTab.Controls.Add(this.VideoBitrateNumericUpDown);
            this.VideoTab.Location = new System.Drawing.Point(4, 22);
            this.VideoTab.Name = "VideoTab";
            this.VideoTab.Padding = new System.Windows.Forms.Padding(3);
            this.VideoTab.Size = new System.Drawing.Size(572, 587);
            this.VideoTab.TabIndex = 1;
            this.VideoTab.Text = "视频";
            this.VideoTab.UseVisualStyleBackColor = true;
            // 
            // VideoFramesLabel
            // 
            this.VideoFramesLabel.AutoSize = true;
            this.VideoFramesLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoFramesLabel.Location = new System.Drawing.Point(238, 147);
            this.VideoFramesLabel.Name = "VideoFramesLabel";
            this.VideoFramesLabel.Size = new System.Drawing.Size(55, 13);
            this.VideoFramesLabel.TabIndex = 46;
            this.VideoFramesLabel.Text = "编码帧数";
            // 
            // VideoSeekLabel
            // 
            this.VideoSeekLabel.AutoSize = true;
            this.VideoSeekLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoSeekLabel.Location = new System.Drawing.Point(11, 147);
            this.VideoSeekLabel.Name = "VideoSeekLabel";
            this.VideoSeekLabel.Size = new System.Drawing.Size(43, 13);
            this.VideoSeekLabel.TabIndex = 46;
            this.VideoSeekLabel.Text = "起始帧";
            // 
            // VideoFramesNumericUpDown
            // 
            this.VideoFramesNumericUpDown.Location = new System.Drawing.Point(377, 145);
            this.VideoFramesNumericUpDown.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.VideoFramesNumericUpDown.Name = "VideoFramesNumericUpDown";
            this.VideoFramesNumericUpDown.Size = new System.Drawing.Size(100, 20);
            this.VideoFramesNumericUpDown.TabIndex = 45;
            // 
            // VideoSeekNumericUpDown
            // 
            this.VideoSeekNumericUpDown.Location = new System.Drawing.Point(117, 145);
            this.VideoSeekNumericUpDown.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.VideoSeekNumericUpDown.Name = "VideoSeekNumericUpDown";
            this.VideoSeekNumericUpDown.Size = new System.Drawing.Size(110, 20);
            this.VideoSeekNumericUpDown.TabIndex = 44;
            // 
            // VideoMaintainResolutionCheckBox
            // 
            this.VideoMaintainResolutionCheckBox.AutoSize = true;
            this.VideoMaintainResolutionCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.VideoMaintainResolutionCheckBox.Checked = true;
            this.VideoMaintainResolutionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.VideoMaintainResolutionCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.VideoMaintainResolutionCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoMaintainResolutionCheckBox.Location = new System.Drawing.Point(377, 222);
            this.VideoMaintainResolutionCheckBox.Name = "VideoMaintainResolutionCheckBox";
            this.VideoMaintainResolutionCheckBox.Size = new System.Drawing.Size(98, 19);
            this.VideoMaintainResolutionCheckBox.TabIndex = 43;
            this.VideoMaintainResolutionCheckBox.Text = "保持原分辨率";
            this.VideoMaintainResolutionCheckBox.UseVisualStyleBackColor = true;
            this.VideoMaintainResolutionCheckBox.CheckedChanged += new System.EventHandler(this.VideoMaintainResolutionCheckBox_CheckedChanged);
            // 
            // VideoDemuxerComboBox
            // 
            this.VideoDemuxerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VideoDemuxerComboBox.FormattingEnabled = true;
            this.VideoDemuxerComboBox.Items.AddRange(new object[] {
            "auto",
            "ffms",
            "lavf",
            "avs",
            "raw",
            "y4m"});
            this.VideoDemuxerComboBox.Location = new System.Drawing.Point(377, 120);
            this.VideoDemuxerComboBox.Name = "VideoDemuxerComboBox";
            this.VideoDemuxerComboBox.Size = new System.Drawing.Size(100, 21);
            this.VideoDemuxerComboBox.TabIndex = 42;
            // 
            // VideoBatchGroupBox
            // 
            this.VideoBatchGroupBox.Controls.Add(this.VideoBatchFormatLabel);
            this.VideoBatchGroupBox.Controls.Add(this.VideoBatchFormatComboBox);
            this.VideoBatchGroupBox.Controls.Add(this.VideoBatchSubtitleLanguage);
            this.VideoBatchGroupBox.Controls.Add(this.VideoBatchOutputFolderButton);
            this.VideoBatchGroupBox.Controls.Add(this.VideoBatchOutputFolderTextBox);
            this.VideoBatchGroupBox.Controls.Add(this.VideoBatchItemListbox);
            this.VideoBatchGroupBox.Controls.Add(this.VideoBatchClearButton);
            this.VideoBatchGroupBox.Controls.Add(this.VideoBatchSubtitleCheckBox);
            this.VideoBatchGroupBox.Controls.Add(this.VideoBatchDeleteButton);
            this.VideoBatchGroupBox.Controls.Add(this.VideoBatchAddButton);
            this.VideoBatchGroupBox.Controls.Add(this.VideoBatchStartButton);
            this.VideoBatchGroupBox.Location = new System.Drawing.Point(0, 283);
            this.VideoBatchGroupBox.Name = "VideoBatchGroupBox";
            this.VideoBatchGroupBox.Size = new System.Drawing.Size(570, 298);
            this.VideoBatchGroupBox.TabIndex = 14;
            this.VideoBatchGroupBox.TabStop = false;
            this.VideoBatchGroupBox.Text = "批量压制";
            // 
            // VideoBatchFormatLabel
            // 
            this.VideoBatchFormatLabel.AutoSize = true;
            this.VideoBatchFormatLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoBatchFormatLabel.Location = new System.Drawing.Point(483, 187);
            this.VideoBatchFormatLabel.Name = "VideoBatchFormatLabel";
            this.VideoBatchFormatLabel.Size = new System.Drawing.Size(31, 13);
            this.VideoBatchFormatLabel.TabIndex = 31;
            this.VideoBatchFormatLabel.Text = "格式";
            // 
            // VideoBatchFormatComboBox
            // 
            this.VideoBatchFormatComboBox.FormattingEnabled = true;
            this.VideoBatchFormatComboBox.Items.AddRange(new object[] {
            "flv",
            "mp4",
            "mkv",
            "mov",
            "avi",
            "f4v"});
            this.VideoBatchFormatComboBox.Location = new System.Drawing.Point(485, 202);
            this.VideoBatchFormatComboBox.Name = "VideoBatchFormatComboBox";
            this.VideoBatchFormatComboBox.Size = new System.Drawing.Size(72, 21);
            this.VideoBatchFormatComboBox.TabIndex = 30;
            this.VideoBatchFormatComboBox.Text = "mp4";
            // 
            // VideoBatchSubtitleLanguage
            // 
            this.VideoBatchSubtitleLanguage.FormattingEnabled = true;
            this.VideoBatchSubtitleLanguage.Location = new System.Drawing.Point(483, 158);
            this.VideoBatchSubtitleLanguage.Name = "VideoBatchSubtitleLanguage";
            this.VideoBatchSubtitleLanguage.Size = new System.Drawing.Size(75, 21);
            this.VideoBatchSubtitleLanguage.TabIndex = 29;
            // 
            // VideoBatchOutputFolderButton
            // 
            this.VideoBatchOutputFolderButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.VideoBatchOutputFolderButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoBatchOutputFolderButton.Location = new System.Drawing.Point(483, 15);
            this.VideoBatchOutputFolderButton.Name = "VideoBatchOutputFolderButton";
            this.VideoBatchOutputFolderButton.Size = new System.Drawing.Size(75, 23);
            this.VideoBatchOutputFolderButton.TabIndex = 28;
            this.VideoBatchOutputFolderButton.Text = "输出路径";
            this.VideoBatchOutputFolderButton.UseVisualStyleBackColor = true;
            this.VideoBatchOutputFolderButton.Click += new System.EventHandler(this.VideoBatchOutputFolderButton_Click);
            // 
            // VideoBatchOutputFolderTextBox
            // 
            this.VideoBatchOutputFolderTextBox.AllowDrop = true;
            this.VideoBatchOutputFolderTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VideoBatchOutputFolderTextBox.EmptyTextTip = "";
            this.VideoBatchOutputFolderTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.VideoBatchOutputFolderTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.VideoBatchOutputFolderTextBox.Location = new System.Drawing.Point(8, 15);
            this.VideoBatchOutputFolderTextBox.Name = "VideoBatchOutputFolderTextBox";
            this.VideoBatchOutputFolderTextBox.Size = new System.Drawing.Size(469, 21);
            this.VideoBatchOutputFolderTextBox.TabIndex = 27;
            // 
            // VideoBatchItemListbox
            // 
            this.VideoBatchItemListbox.AllowDrop = true;
            this.VideoBatchItemListbox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.VideoBatchItemListbox.FormattingEnabled = true;
            this.VideoBatchItemListbox.HorizontalScrollbar = true;
            this.VideoBatchItemListbox.ItemHeight = 12;
            this.VideoBatchItemListbox.Location = new System.Drawing.Point(8, 44);
            this.VideoBatchItemListbox.Name = "VideoBatchItemListbox";
            this.VideoBatchItemListbox.Size = new System.Drawing.Size(469, 244);
            this.VideoBatchItemListbox.TabIndex = 11;
            this.VideoBatchItemListbox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.VideoBatchItemListbox_DrawItem);
            this.VideoBatchItemListbox.DragDrop += new System.Windows.Forms.DragEventHandler(this.VideoBatchItemListbox_DragDrop);
            this.VideoBatchItemListbox.DragEnter += new System.Windows.Forms.DragEventHandler(this.VideoBatchItemListbox_DragEnter);
            this.VideoBatchItemListbox.DragOver += new System.Windows.Forms.DragEventHandler(this.VideoBatchItemListbox_DragOver);
            this.VideoBatchItemListbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VideoBatchItemListbox_MouseDown);
            // 
            // VideoBatchClearButton
            // 
            this.VideoBatchClearButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.VideoBatchClearButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoBatchClearButton.Location = new System.Drawing.Point(483, 102);
            this.VideoBatchClearButton.Name = "VideoBatchClearButton";
            this.VideoBatchClearButton.Size = new System.Drawing.Size(75, 23);
            this.VideoBatchClearButton.TabIndex = 26;
            this.VideoBatchClearButton.Text = "清空";
            this.VideoBatchClearButton.UseVisualStyleBackColor = true;
            this.VideoBatchClearButton.Click += new System.EventHandler(this.VideoBatchClearButton_Click);
            // 
            // VideoBatchSubtitleCheckBox
            // 
            this.VideoBatchSubtitleCheckBox.AutoSize = true;
            this.VideoBatchSubtitleCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.VideoBatchSubtitleCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.VideoBatchSubtitleCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoBatchSubtitleCheckBox.Location = new System.Drawing.Point(483, 131);
            this.VideoBatchSubtitleCheckBox.Name = "VideoBatchSubtitleCheckBox";
            this.VideoBatchSubtitleCheckBox.Size = new System.Drawing.Size(74, 19);
            this.VideoBatchSubtitleCheckBox.TabIndex = 23;
            this.VideoBatchSubtitleCheckBox.Text = "内嵌字幕";
            this.VideoBatchSubtitleCheckBox.UseVisualStyleBackColor = false;
            // 
            // VideoBatchDeleteButton
            // 
            this.VideoBatchDeleteButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.VideoBatchDeleteButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoBatchDeleteButton.Location = new System.Drawing.Point(483, 73);
            this.VideoBatchDeleteButton.Name = "VideoBatchDeleteButton";
            this.VideoBatchDeleteButton.Size = new System.Drawing.Size(75, 23);
            this.VideoBatchDeleteButton.TabIndex = 25;
            this.VideoBatchDeleteButton.Text = "删除";
            this.VideoBatchDeleteButton.UseVisualStyleBackColor = true;
            this.VideoBatchDeleteButton.Click += new System.EventHandler(this.VideoBatchDeleteButton_Click);
            // 
            // VideoBatchAddButton
            // 
            this.VideoBatchAddButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.VideoBatchAddButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoBatchAddButton.Location = new System.Drawing.Point(483, 44);
            this.VideoBatchAddButton.Name = "VideoBatchAddButton";
            this.VideoBatchAddButton.Size = new System.Drawing.Size(75, 23);
            this.VideoBatchAddButton.TabIndex = 24;
            this.VideoBatchAddButton.Text = "添加";
            this.VideoBatchAddButton.UseVisualStyleBackColor = true;
            this.VideoBatchAddButton.Click += new System.EventHandler(this.VideoBatchAddButton_Click);
            // 
            // VideoBatchStartButton
            // 
            this.VideoBatchStartButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.VideoBatchStartButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoBatchStartButton.Location = new System.Drawing.Point(483, 265);
            this.VideoBatchStartButton.Name = "VideoBatchStartButton";
            this.VideoBatchStartButton.Size = new System.Drawing.Size(75, 23);
            this.VideoBatchStartButton.TabIndex = 15;
            this.VideoBatchStartButton.Text = "压制";
            this.VideoBatchStartButton.UseVisualStyleBackColor = true;
            this.VideoBatchStartButton.Click += new System.EventHandler(this.VideoBatchStartButton_Click);
            // 
            // VideoAutoShutdownCheckBox
            // 
            this.VideoAutoShutdownCheckBox.AutoSize = true;
            this.VideoAutoShutdownCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.VideoAutoShutdownCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.VideoAutoShutdownCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoAutoShutdownCheckBox.Location = new System.Drawing.Point(401, 172);
            this.VideoAutoShutdownCheckBox.Name = "VideoAutoShutdownCheckBox";
            this.VideoAutoShutdownCheckBox.Size = new System.Drawing.Size(74, 19);
            this.VideoAutoShutdownCheckBox.TabIndex = 40;
            this.VideoAutoShutdownCheckBox.Text = "自动关机";
            this.VideoAutoShutdownCheckBox.UseVisualStyleBackColor = false;
            this.VideoAutoShutdownCheckBox.CheckedChanged += new System.EventHandler(this.VideoAutoShutdownCheckBox_CheckedChanged);
            // 
            // VideoAudioParameterTextBox
            // 
            this.VideoAudioParameterTextBox.AllowDrop = true;
            this.VideoAudioParameterTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VideoAudioParameterTextBox.EmptyTextTip = null;
            this.VideoAudioParameterTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.VideoAudioParameterTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.VideoAudioParameterTextBox.Location = new System.Drawing.Point(240, 93);
            this.VideoAudioParameterTextBox.Name = "VideoAudioParameterTextBox";
            this.VideoAudioParameterTextBox.Size = new System.Drawing.Size(68, 21);
            this.VideoAudioParameterTextBox.TabIndex = 39;
            this.VideoAudioParameterTextBox.Visible = false;
            // 
            // VideoSubtitleTextBox
            // 
            this.VideoSubtitleTextBox.AllowDrop = true;
            this.VideoSubtitleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VideoSubtitleTextBox.EmptyTextTip = null;
            this.VideoSubtitleTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.VideoSubtitleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.VideoSubtitleTextBox.Location = new System.Drawing.Point(8, 64);
            this.VideoSubtitleTextBox.Name = "VideoSubtitleTextBox";
            this.VideoSubtitleTextBox.ReadOnly = true;
            this.VideoSubtitleTextBox.Size = new System.Drawing.Size(469, 21);
            this.VideoSubtitleTextBox.TabIndex = 39;
            this.VideoSubtitleTextBox.TextChanged += new System.EventHandler(this.VideoSubtitleTextBox_TextChanged);
            this.VideoSubtitleTextBox.DoubleClick += new System.EventHandler(this.VideoSubtitleTextBox_DoubleClick);
            // 
            // VideoOutputTextBox
            // 
            this.VideoOutputTextBox.AllowDrop = true;
            this.VideoOutputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VideoOutputTextBox.EmptyTextTip = "";
            this.VideoOutputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.VideoOutputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.VideoOutputTextBox.Location = new System.Drawing.Point(8, 35);
            this.VideoOutputTextBox.Name = "VideoOutputTextBox";
            this.VideoOutputTextBox.Size = new System.Drawing.Size(469, 21);
            this.VideoOutputTextBox.TabIndex = 39;
            this.VideoOutputTextBox.TextChanged += new System.EventHandler(this.VideoOutputTextBox_TextChanged);
            // 
            // VideoInputTextBox
            // 
            this.VideoInputTextBox.AllowDrop = true;
            this.VideoInputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VideoInputTextBox.EmptyTextTip = "";
            this.VideoInputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.VideoInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.VideoInputTextBox.Location = new System.Drawing.Point(8, 6);
            this.VideoInputTextBox.Name = "VideoInputTextBox";
            this.VideoInputTextBox.ReadOnly = true;
            this.VideoInputTextBox.Size = new System.Drawing.Size(469, 21);
            this.VideoInputTextBox.TabIndex = 39;
            this.VideoInputTextBox.TextChanged += new System.EventHandler(this.VideoInputTextBox_TextChanged);
            // 
            // VideoX264ModePanel
            // 
            this.VideoX264ModePanel.Controls.Add(this.VideoModeCrfRadioButton);
            this.VideoX264ModePanel.Controls.Add(this.VideoModeCustomRadioButton);
            this.VideoX264ModePanel.Controls.Add(this.VideoMode2PassRadioButton);
            this.VideoX264ModePanel.Location = new System.Drawing.Point(6, 172);
            this.VideoX264ModePanel.Name = "VideoX264ModePanel";
            this.VideoX264ModePanel.Size = new System.Drawing.Size(249, 24);
            this.VideoX264ModePanel.TabIndex = 13;
            // 
            // VideoModeCrfRadioButton
            // 
            this.VideoModeCrfRadioButton.AutoSize = true;
            this.VideoModeCrfRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.VideoModeCrfRadioButton.Checked = true;
            this.VideoModeCrfRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.VideoModeCrfRadioButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoModeCrfRadioButton.Location = new System.Drawing.Point(13, 1);
            this.VideoModeCrfRadioButton.Name = "VideoModeCrfRadioButton";
            this.VideoModeCrfRadioButton.Size = new System.Drawing.Size(49, 19);
            this.VideoModeCrfRadioButton.TabIndex = 15;
            this.VideoModeCrfRadioButton.TabStop = true;
            this.VideoModeCrfRadioButton.Text = "CRF";
            this.VideoModeCrfRadioButton.UseVisualStyleBackColor = false;
            this.VideoModeCrfRadioButton.CheckedChanged += new System.EventHandler(this.VideoModeCrfRadioButton_CheckedChanged);
            // 
            // VideoModeCustomRadioButton
            // 
            this.VideoModeCustomRadioButton.AutoSize = true;
            this.VideoModeCustomRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.VideoModeCustomRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.VideoModeCustomRadioButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoModeCustomRadioButton.Location = new System.Drawing.Point(77, 1);
            this.VideoModeCustomRadioButton.Name = "VideoModeCustomRadioButton";
            this.VideoModeCustomRadioButton.Size = new System.Drawing.Size(61, 19);
            this.VideoModeCustomRadioButton.TabIndex = 14;
            this.VideoModeCustomRadioButton.Text = "自定义";
            this.VideoModeCustomRadioButton.UseVisualStyleBackColor = false;
            this.VideoModeCustomRadioButton.CheckedChanged += new System.EventHandler(this.VideoModeCustomRadioButton_CheckedChanged);
            // 
            // VideoMode2PassRadioButton
            // 
            this.VideoMode2PassRadioButton.AutoSize = true;
            this.VideoMode2PassRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.VideoMode2PassRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.VideoMode2PassRadioButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoMode2PassRadioButton.Location = new System.Drawing.Point(178, 1);
            this.VideoMode2PassRadioButton.Name = "VideoMode2PassRadioButton";
            this.VideoMode2PassRadioButton.Size = new System.Drawing.Size(59, 19);
            this.VideoMode2PassRadioButton.TabIndex = 13;
            this.VideoMode2PassRadioButton.Text = "2Pass";
            this.VideoMode2PassRadioButton.UseVisualStyleBackColor = false;
            this.VideoMode2PassRadioButton.CheckedChanged += new System.EventHandler(this.VideoMode2PassRadioButton_CheckedChanged);
            // 
            // VideoDemuxerLabel
            // 
            this.VideoDemuxerLabel.AutoSize = true;
            this.VideoDemuxerLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoDemuxerLabel.Location = new System.Drawing.Point(324, 123);
            this.VideoDemuxerLabel.Name = "VideoDemuxerLabel";
            this.VideoDemuxerLabel.Size = new System.Drawing.Size(43, 13);
            this.VideoDemuxerLabel.TabIndex = 11;
            this.VideoDemuxerLabel.Text = "分离器";
            // 
            // VideoAddPresetButton
            // 
            this.VideoAddPresetButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.VideoAddPresetButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoAddPresetButton.Location = new System.Drawing.Point(286, 196);
            this.VideoAddPresetButton.Name = "VideoAddPresetButton";
            this.VideoAddPresetButton.Size = new System.Drawing.Size(75, 23);
            this.VideoAddPresetButton.TabIndex = 36;
            this.VideoAddPresetButton.Text = "添加";
            this.VideoAddPresetButton.UseVisualStyleBackColor = true;
            this.VideoAddPresetButton.Visible = false;
            this.VideoAddPresetButton.Click += new System.EventHandler(this.VideoAddPresetButton_Click);
            // 
            // VideoDeletePresetButton
            // 
            this.VideoDeletePresetButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.VideoDeletePresetButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoDeletePresetButton.Location = new System.Drawing.Point(200, 196);
            this.VideoDeletePresetButton.Name = "VideoDeletePresetButton";
            this.VideoDeletePresetButton.Size = new System.Drawing.Size(75, 23);
            this.VideoDeletePresetButton.TabIndex = 35;
            this.VideoDeletePresetButton.Text = "删除";
            this.VideoDeletePresetButton.UseVisualStyleBackColor = true;
            this.VideoDeletePresetButton.Visible = false;
            this.VideoDeletePresetButton.Click += new System.EventHandler(this.VideoDeletePresetButton_Click);
            // 
            // VideoStartButton
            // 
            this.VideoStartButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.VideoStartButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoStartButton.Location = new System.Drawing.Point(483, 246);
            this.VideoStartButton.Name = "VideoStartButton";
            this.VideoStartButton.Size = new System.Drawing.Size(75, 23);
            this.VideoStartButton.TabIndex = 34;
            this.VideoStartButton.Text = "压制";
            this.VideoStartButton.UseVisualStyleBackColor = true;
            this.VideoStartButton.Click += new System.EventHandler(this.VideoStartButton_Click);
            // 
            // VideoSubtitleButton
            // 
            this.VideoSubtitleButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.VideoSubtitleButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoSubtitleButton.Location = new System.Drawing.Point(483, 64);
            this.VideoSubtitleButton.Name = "VideoSubtitleButton";
            this.VideoSubtitleButton.Size = new System.Drawing.Size(75, 23);
            this.VideoSubtitleButton.TabIndex = 34;
            this.VideoSubtitleButton.Text = "字幕";
            this.VideoSubtitleButton.UseVisualStyleBackColor = true;
            this.VideoSubtitleButton.Click += new System.EventHandler(this.VideoSubtitleButton_Click);
            // 
            // VideoOutputButton
            // 
            this.VideoOutputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.VideoOutputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoOutputButton.Location = new System.Drawing.Point(483, 35);
            this.VideoOutputButton.Name = "VideoOutputButton";
            this.VideoOutputButton.Size = new System.Drawing.Size(75, 23);
            this.VideoOutputButton.TabIndex = 34;
            this.VideoOutputButton.Text = "输出";
            this.VideoOutputButton.UseVisualStyleBackColor = true;
            this.VideoOutputButton.Click += new System.EventHandler(this.VideoOutputButton_Click);
            // 
            // VideoInputButton
            // 
            this.VideoInputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.VideoInputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoInputButton.Location = new System.Drawing.Point(483, 6);
            this.VideoInputButton.Name = "VideoInputButton";
            this.VideoInputButton.Size = new System.Drawing.Size(75, 23);
            this.VideoInputButton.TabIndex = 34;
            this.VideoInputButton.Text = "视频";
            this.VideoInputButton.UseVisualStyleBackColor = true;
            this.VideoInputButton.Click += new System.EventHandler(this.VideoInputButton_Click);
            // 
            // VideoEncoderLabel
            // 
            this.VideoEncoderLabel.AutoSize = true;
            this.VideoEncoderLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoEncoderLabel.Location = new System.Drawing.Point(11, 123);
            this.VideoEncoderLabel.Name = "VideoEncoderLabel";
            this.VideoEncoderLabel.Size = new System.Drawing.Size(43, 13);
            this.VideoEncoderLabel.TabIndex = 29;
            this.VideoEncoderLabel.Text = "编码器";
            // 
            // VideoEncoderComboBox
            // 
            this.VideoEncoderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VideoEncoderComboBox.FormattingEnabled = true;
            this.VideoEncoderComboBox.Location = new System.Drawing.Point(66, 120);
            this.VideoEncoderComboBox.Name = "VideoEncoderComboBox";
            this.VideoEncoderComboBox.Size = new System.Drawing.Size(239, 21);
            this.VideoEncoderComboBox.TabIndex = 27;
            this.VideoEncoderComboBox.SelectedIndexChanged += new System.EventHandler(this.VideoEncoderComboBox_SelectedIndexChanged);
            // 
            // VideoFpsComboBox
            // 
            this.VideoFpsComboBox.FormattingEnabled = true;
            this.VideoFpsComboBox.Items.AddRange(new object[] {
            "auto",
            "23.976",
            "24",
            "25",
            "29.970",
            "30",
            "50",
            "59.940",
            "60"});
            this.VideoFpsComboBox.Location = new System.Drawing.Point(66, 248);
            this.VideoFpsComboBox.Name = "VideoFpsComboBox";
            this.VideoFpsComboBox.Size = new System.Drawing.Size(88, 21);
            this.VideoFpsComboBox.TabIndex = 23;
            this.VideoFpsComboBox.Text = "auto";
            this.VideoFpsComboBox.Visible = false;
            // 
            // VideoFpsLabel
            // 
            this.VideoFpsLabel.AutoSize = true;
            this.VideoFpsLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoFpsLabel.Location = new System.Drawing.Point(19, 250);
            this.VideoFpsLabel.Name = "VideoFpsLabel";
            this.VideoFpsLabel.Size = new System.Drawing.Size(27, 13);
            this.VideoFpsLabel.TabIndex = 22;
            this.VideoFpsLabel.Text = "FPS";
            this.VideoFpsLabel.Visible = false;
            // 
            // VideoAudioModeComboBox
            // 
            this.VideoAudioModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VideoAudioModeComboBox.FormattingEnabled = true;
            this.VideoAudioModeComboBox.Items.AddRange(new object[] {
            "压制音频",
            "无音频流",
            "复制音频流"});
            this.VideoAudioModeComboBox.Location = new System.Drawing.Point(377, 93);
            this.VideoAudioModeComboBox.Name = "VideoAudioModeComboBox";
            this.VideoAudioModeComboBox.Size = new System.Drawing.Size(100, 21);
            this.VideoAudioModeComboBox.TabIndex = 20;
            // 
            // VideoPresetComboBox
            // 
            this.VideoPresetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VideoPresetComboBox.FormattingEnabled = true;
            this.VideoPresetComboBox.Location = new System.Drawing.Point(66, 196);
            this.VideoPresetComboBox.Name = "VideoPresetComboBox";
            this.VideoPresetComboBox.Size = new System.Drawing.Size(123, 21);
            this.VideoPresetComboBox.TabIndex = 18;
            this.VideoPresetComboBox.Visible = false;
            this.VideoPresetComboBox.SelectedIndexChanged += new System.EventHandler(this.VideoPresetComboBox_SelectedIndexChanged);
            // 
            // VideoAudioModeLabel
            // 
            this.VideoAudioModeLabel.AutoSize = true;
            this.VideoAudioModeLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoAudioModeLabel.Location = new System.Drawing.Point(312, 98);
            this.VideoAudioModeLabel.Name = "VideoAudioModeLabel";
            this.VideoAudioModeLabel.Size = new System.Drawing.Size(55, 13);
            this.VideoAudioModeLabel.TabIndex = 16;
            this.VideoAudioModeLabel.Text = "音频模式";
            // 
            // VideoGoToAudioLabel
            // 
            this.VideoGoToAudioLabel.AutoSize = true;
            this.VideoGoToAudioLabel.ForeColor = System.Drawing.Color.Blue;
            this.VideoGoToAudioLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoGoToAudioLabel.Location = new System.Drawing.Point(64, 96);
            this.VideoGoToAudioLabel.Name = "VideoGoToAudioLabel";
            this.VideoGoToAudioLabel.Size = new System.Drawing.Size(103, 13);
            this.VideoGoToAudioLabel.TabIndex = 16;
            this.VideoGoToAudioLabel.Text = "点我设置音频参数";
            this.VideoGoToAudioLabel.Click += new System.EventHandler(this.VideoGoToAudioLabel_Click);
            // 
            // VideoBitrateKbpsLabel
            // 
            this.VideoBitrateKbpsLabel.AutoSize = true;
            this.VideoBitrateKbpsLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoBitrateKbpsLabel.Location = new System.Drawing.Point(163, 223);
            this.VideoBitrateKbpsLabel.Name = "VideoBitrateKbpsLabel";
            this.VideoBitrateKbpsLabel.Size = new System.Drawing.Size(31, 13);
            this.VideoBitrateKbpsLabel.TabIndex = 14;
            this.VideoBitrateKbpsLabel.Text = "Kbps";
            this.VideoBitrateKbpsLabel.Visible = false;
            // 
            // VideoCrfLabel
            // 
            this.VideoCrfLabel.AutoSize = true;
            this.VideoCrfLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoCrfLabel.Location = new System.Drawing.Point(19, 223);
            this.VideoCrfLabel.Name = "VideoCrfLabel";
            this.VideoCrfLabel.Size = new System.Drawing.Size(28, 13);
            this.VideoCrfLabel.TabIndex = 9;
            this.VideoCrfLabel.Text = "CRF";
            // 
            // VideoHeightLabel
            // 
            this.VideoHeightLabel.AutoSize = true;
            this.VideoHeightLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoHeightLabel.Location = new System.Drawing.Point(233, 250);
            this.VideoHeightLabel.Name = "VideoHeightLabel";
            this.VideoHeightLabel.Size = new System.Drawing.Size(31, 13);
            this.VideoHeightLabel.TabIndex = 8;
            this.VideoHeightLabel.Text = "高度";
            // 
            // VideoWidthLabel
            // 
            this.VideoWidthLabel.AutoSize = true;
            this.VideoWidthLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoWidthLabel.Location = new System.Drawing.Point(233, 223);
            this.VideoWidthLabel.Name = "VideoWidthLabel";
            this.VideoWidthLabel.Size = new System.Drawing.Size(31, 13);
            this.VideoWidthLabel.TabIndex = 7;
            this.VideoWidthLabel.Text = "宽度";
            // 
            // VideoHeightNumericUpDown
            // 
            this.VideoHeightNumericUpDown.Enabled = false;
            this.VideoHeightNumericUpDown.Location = new System.Drawing.Point(277, 248);
            this.VideoHeightNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.VideoHeightNumericUpDown.Name = "VideoHeightNumericUpDown";
            this.VideoHeightNumericUpDown.Size = new System.Drawing.Size(88, 20);
            this.VideoHeightNumericUpDown.TabIndex = 6;
            this.VideoHeightNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // VideoWidthNumericUpDown
            // 
            this.VideoWidthNumericUpDown.Enabled = false;
            this.VideoWidthNumericUpDown.Location = new System.Drawing.Point(277, 221);
            this.VideoWidthNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.VideoWidthNumericUpDown.Name = "VideoWidthNumericUpDown";
            this.VideoWidthNumericUpDown.Size = new System.Drawing.Size(88, 20);
            this.VideoWidthNumericUpDown.TabIndex = 5;
            this.VideoWidthNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // VideoCrfNumericUpDown
            // 
            this.VideoCrfNumericUpDown.DecimalPlaces = 1;
            this.VideoCrfNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.VideoCrfNumericUpDown.Location = new System.Drawing.Point(66, 221);
            this.VideoCrfNumericUpDown.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.VideoCrfNumericUpDown.Minimum = new decimal(new int[] {
            12,
            0,
            0,
            -2147483648});
            this.VideoCrfNumericUpDown.Name = "VideoCrfNumericUpDown";
            this.VideoCrfNumericUpDown.Size = new System.Drawing.Size(88, 20);
            this.VideoCrfNumericUpDown.TabIndex = 4;
            this.VideoCrfNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.VideoCrfNumericUpDown.Value = new decimal(new int[] {
            235,
            0,
            0,
            65536});
            // 
            // VideoBitrateLabel
            // 
            this.VideoBitrateLabel.AutoSize = true;
            this.VideoBitrateLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoBitrateLabel.Location = new System.Drawing.Point(19, 223);
            this.VideoBitrateLabel.Name = "VideoBitrateLabel";
            this.VideoBitrateLabel.Size = new System.Drawing.Size(31, 13);
            this.VideoBitrateLabel.TabIndex = 14;
            this.VideoBitrateLabel.Text = "码率";
            this.VideoBitrateLabel.Visible = false;
            // 
            // VideoCustomParameterTextBox
            // 
            this.VideoCustomParameterTextBox.AllowDrop = true;
            this.VideoCustomParameterTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VideoCustomParameterTextBox.EmptyTextTip = null;
            this.VideoCustomParameterTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.VideoCustomParameterTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.VideoCustomParameterTextBox.Location = new System.Drawing.Point(8, 221);
            this.VideoCustomParameterTextBox.Multiline = true;
            this.VideoCustomParameterTextBox.Name = "VideoCustomParameterTextBox";
            this.VideoCustomParameterTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.VideoCustomParameterTextBox.Size = new System.Drawing.Size(469, 56);
            this.VideoCustomParameterTextBox.TabIndex = 15;
            this.VideoCustomParameterTextBox.Text = "--crf 23.5 --preset 9 -r 5 -b 5 --me umh --merange 32 -I infinite -i 1 --scenecut" +
    " 50 -f 1:1 --qcomp 0.5 --psy-rd 0.3:0 --aq-strength 0.8 --vf resize:960,540,,,,l" +
    "anczos";
            this.VideoCustomParameterTextBox.Visible = false;
            this.VideoCustomParameterTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VideoCustomParameterTextBox_KeyDown);
            // 
            // VideoPresetLabel
            // 
            this.VideoPresetLabel.AutoSize = true;
            this.VideoPresetLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoPresetLabel.Location = new System.Drawing.Point(23, 200);
            this.VideoPresetLabel.Name = "VideoPresetLabel";
            this.VideoPresetLabel.Size = new System.Drawing.Size(31, 13);
            this.VideoPresetLabel.TabIndex = 28;
            this.VideoPresetLabel.Text = "预设";
            this.VideoPresetLabel.Visible = false;
            // 
            // VideoBitrateNumericUpDown
            // 
            this.VideoBitrateNumericUpDown.Location = new System.Drawing.Point(66, 221);
            this.VideoBitrateNumericUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.VideoBitrateNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.VideoBitrateNumericUpDown.Name = "VideoBitrateNumericUpDown";
            this.VideoBitrateNumericUpDown.Size = new System.Drawing.Size(88, 20);
            this.VideoBitrateNumericUpDown.TabIndex = 4;
            this.VideoBitrateNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.VideoBitrateNumericUpDown.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.VideoBitrateNumericUpDown.Visible = false;
            // 
            // HelpTab
            // 
            this.HelpTab.Controls.Add(this.helpUserControl);
            this.HelpTab.Location = new System.Drawing.Point(4, 22);
            this.HelpTab.Name = "HelpTab";
            this.HelpTab.Padding = new System.Windows.Forms.Padding(3);
            this.HelpTab.Size = new System.Drawing.Size(572, 587);
            this.HelpTab.TabIndex = 10;
            this.HelpTab.Text = "帮助";
            this.HelpTab.UseVisualStyleBackColor = true;
            // 
            // helpUserControl
            // 
            this.helpUserControl.Location = new System.Drawing.Point(0, 0);
            this.helpUserControl.Name = "helpUserControl";
            this.helpUserControl.Size = new System.Drawing.Size(556, 582);
            this.helpUserControl.TabIndex = 0;
            // 
            // MainTabControl
            // 
            this.MainTabControl.AllowDrop = true;
            this.MainTabControl.Controls.Add(this.VideoTab);
            this.MainTabControl.Controls.Add(this.AudioTab);
            this.MainTabControl.Controls.Add(this.MiscTab);
            this.MainTabControl.Controls.Add(this.MuxTab);
            this.MainTabControl.Controls.Add(this.ExtractTab);
            this.MainTabControl.Controls.Add(this.AvsTab);
            this.MainTabControl.Controls.Add(this.MediaInfoTab);
            this.MainTabControl.Controls.Add(this.ConfigTabPage);
            this.MainTabControl.Controls.Add(this.HelpTab);
            this.MainTabControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainTabControl.HotTrack = true;
            this.MainTabControl.Location = new System.Drawing.Point(0, 0);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.Padding = new System.Drawing.Point(0, 0);
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(580, 613);
            this.MainTabControl.TabIndex = 13;
            this.MainTabControl.DragOver += new System.Windows.Forms.DragEventHandler(this.MainTabControl_DragOver);
            // 
            // MiscTab
            // 
            this.MiscTab.Controls.Add(this.MiscBlackGroupBox);
            this.MiscTab.Controls.Add(this.MiscMiscGroupBox);
            this.MiscTab.Controls.Add(this.MiscOnePicGroupBox);
            this.MiscTab.Location = new System.Drawing.Point(4, 22);
            this.MiscTab.Name = "MiscTab";
            this.MiscTab.Padding = new System.Windows.Forms.Padding(3);
            this.MiscTab.Size = new System.Drawing.Size(192, 74);
            this.MiscTab.TabIndex = 12;
            this.MiscTab.Text = "常用";
            this.MiscTab.UseVisualStyleBackColor = true;
            // 
            // MiscBlackGroupBox
            // 
            this.MiscBlackGroupBox.Controls.Add(this.MiscBlackKbpsLabel);
            this.MiscBlackGroupBox.Controls.Add(this.MiscBlackBitrateLabel);
            this.MiscBlackGroupBox.Controls.Add(this.MiscBlackBitrateNumericUpDown);
            this.MiscBlackGroupBox.Controls.Add(this.MiscBlackDurationSecondsLabel);
            this.MiscBlackGroupBox.Controls.Add(this.MiscBlackDurationSecondsComboBox);
            this.MiscBlackGroupBox.Controls.Add(this.MiscBlackDurationLabel);
            this.MiscBlackGroupBox.Controls.Add(this.MiscBlackCrfNumericUpDown);
            this.MiscBlackGroupBox.Controls.Add(this.MiscBlackCrfLabel);
            this.MiscBlackGroupBox.Controls.Add(this.MiscBlackNoPicCheckBox);
            this.MiscBlackGroupBox.Controls.Add(this.MiscBlackFpsLabel);
            this.MiscBlackGroupBox.Controls.Add(this.MiscBlackFpsNumericUpDown);
            this.MiscBlackGroupBox.Controls.Add(this.MiscBlackPicInputButton);
            this.MiscBlackGroupBox.Controls.Add(this.MiscBlackPicInputTextBox);
            this.MiscBlackGroupBox.Controls.Add(this.MiscBlackStartButton);
            this.MiscBlackGroupBox.Controls.Add(this.MiscBlackOutputButton);
            this.MiscBlackGroupBox.Controls.Add(this.MiscBlackVideoInputButton);
            this.MiscBlackGroupBox.Controls.Add(this.MiscBlackOutputTextBox);
            this.MiscBlackGroupBox.Controls.Add(this.MiscBlackVideoInputTextBox);
            this.MiscBlackGroupBox.Location = new System.Drawing.Point(0, 417);
            this.MiscBlackGroupBox.Name = "MiscBlackGroupBox";
            this.MiscBlackGroupBox.Size = new System.Drawing.Size(566, 164);
            this.MiscBlackGroupBox.TabIndex = 22;
            this.MiscBlackGroupBox.TabStop = false;
            this.MiscBlackGroupBox.Text = "后黑";
            this.MiscBlackGroupBox.Visible = false;
            // 
            // MiscBlackKbpsLabel
            // 
            this.MiscBlackKbpsLabel.AutoSize = true;
            this.MiscBlackKbpsLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscBlackKbpsLabel.Location = new System.Drawing.Point(211, 140);
            this.MiscBlackKbpsLabel.Name = "MiscBlackKbpsLabel";
            this.MiscBlackKbpsLabel.Size = new System.Drawing.Size(31, 13);
            this.MiscBlackKbpsLabel.TabIndex = 41;
            this.MiscBlackKbpsLabel.Text = "Kbps";
            // 
            // MiscBlackBitrateLabel
            // 
            this.MiscBlackBitrateLabel.AutoSize = true;
            this.MiscBlackBitrateLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscBlackBitrateLabel.Location = new System.Drawing.Point(12, 140);
            this.MiscBlackBitrateLabel.Name = "MiscBlackBitrateLabel";
            this.MiscBlackBitrateLabel.Size = new System.Drawing.Size(55, 13);
            this.MiscBlackBitrateLabel.TabIndex = 40;
            this.MiscBlackBitrateLabel.Text = "目标码率";
            // 
            // MiscBlackBitrateNumericUpDown
            // 
            this.MiscBlackBitrateNumericUpDown.Location = new System.Drawing.Point(106, 138);
            this.MiscBlackBitrateNumericUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.MiscBlackBitrateNumericUpDown.Name = "MiscBlackBitrateNumericUpDown";
            this.MiscBlackBitrateNumericUpDown.Size = new System.Drawing.Size(96, 20);
            this.MiscBlackBitrateNumericUpDown.TabIndex = 39;
            this.MiscBlackBitrateNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MiscBlackBitrateNumericUpDown.Value = new decimal(new int[] {
            900,
            0,
            0,
            0});
            // 
            // MiscBlackDurationSecondsLabel
            // 
            this.MiscBlackDurationSecondsLabel.AutoSize = true;
            this.MiscBlackDurationSecondsLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscBlackDurationSecondsLabel.Location = new System.Drawing.Point(211, 109);
            this.MiscBlackDurationSecondsLabel.Name = "MiscBlackDurationSecondsLabel";
            this.MiscBlackDurationSecondsLabel.Size = new System.Drawing.Size(19, 13);
            this.MiscBlackDurationSecondsLabel.TabIndex = 38;
            this.MiscBlackDurationSecondsLabel.Text = "秒";
            // 
            // MiscBlackDurationSecondsComboBox
            // 
            this.MiscBlackDurationSecondsComboBox.FormattingEnabled = true;
            this.MiscBlackDurationSecondsComboBox.Items.AddRange(new object[] {
            "auto",
            "60",
            "300",
            "900",
            "3600"});
            this.MiscBlackDurationSecondsComboBox.Location = new System.Drawing.Point(107, 108);
            this.MiscBlackDurationSecondsComboBox.Name = "MiscBlackDurationSecondsComboBox";
            this.MiscBlackDurationSecondsComboBox.Size = new System.Drawing.Size(96, 21);
            this.MiscBlackDurationSecondsComboBox.TabIndex = 37;
            this.MiscBlackDurationSecondsComboBox.Text = "auto";
            this.MiscBlackDurationSecondsComboBox.SelectedIndexChanged += new System.EventHandler(this.MiscBlackDurationSecondsComboBox_SelectedIndexChanged);
            // 
            // MiscBlackDurationLabel
            // 
            this.MiscBlackDurationLabel.AutoSize = true;
            this.MiscBlackDurationLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscBlackDurationLabel.Location = new System.Drawing.Point(12, 109);
            this.MiscBlackDurationLabel.Name = "MiscBlackDurationLabel";
            this.MiscBlackDurationLabel.Size = new System.Drawing.Size(55, 13);
            this.MiscBlackDurationLabel.TabIndex = 36;
            this.MiscBlackDurationLabel.Text = "后黑时长";
            // 
            // MiscBlackCrfNumericUpDown
            // 
            this.MiscBlackCrfNumericUpDown.DecimalPlaces = 1;
            this.MiscBlackCrfNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.MiscBlackCrfNumericUpDown.Location = new System.Drawing.Point(390, 107);
            this.MiscBlackCrfNumericUpDown.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.MiscBlackCrfNumericUpDown.Minimum = new decimal(new int[] {
            12,
            0,
            0,
            -2147483648});
            this.MiscBlackCrfNumericUpDown.Name = "MiscBlackCrfNumericUpDown";
            this.MiscBlackCrfNumericUpDown.Size = new System.Drawing.Size(88, 20);
            this.MiscBlackCrfNumericUpDown.TabIndex = 35;
            this.MiscBlackCrfNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MiscBlackCrfNumericUpDown.Value = new decimal(new int[] {
            51,
            0,
            0,
            0});
            // 
            // MiscBlackCrfLabel
            // 
            this.MiscBlackCrfLabel.AutoSize = true;
            this.MiscBlackCrfLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscBlackCrfLabel.Location = new System.Drawing.Point(361, 109);
            this.MiscBlackCrfLabel.Name = "MiscBlackCrfLabel";
            this.MiscBlackCrfLabel.Size = new System.Drawing.Size(28, 13);
            this.MiscBlackCrfLabel.TabIndex = 33;
            this.MiscBlackCrfLabel.Text = "CRF";
            // 
            // MiscBlackNoPicCheckBox
            // 
            this.MiscBlackNoPicCheckBox.AutoSize = true;
            this.MiscBlackNoPicCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.MiscBlackNoPicCheckBox.Checked = true;
            this.MiscBlackNoPicCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MiscBlackNoPicCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MiscBlackNoPicCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscBlackNoPicCheckBox.Location = new System.Drawing.Point(390, 136);
            this.MiscBlackNoPicCheckBox.Name = "MiscBlackNoPicCheckBox";
            this.MiscBlackNoPicCheckBox.Size = new System.Drawing.Size(74, 19);
            this.MiscBlackNoPicCheckBox.TabIndex = 31;
            this.MiscBlackNoPicCheckBox.Text = "使用黑屏";
            this.MiscBlackNoPicCheckBox.UseVisualStyleBackColor = false;
            this.MiscBlackNoPicCheckBox.CheckedChanged += new System.EventHandler(this.MiscBlackNoPicCheckBox_CheckedChanged);
            // 
            // MiscBlackFpsLabel
            // 
            this.MiscBlackFpsLabel.AutoSize = true;
            this.MiscBlackFpsLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscBlackFpsLabel.Location = new System.Drawing.Point(259, 109);
            this.MiscBlackFpsLabel.Name = "MiscBlackFpsLabel";
            this.MiscBlackFpsLabel.Size = new System.Drawing.Size(27, 13);
            this.MiscBlackFpsLabel.TabIndex = 30;
            this.MiscBlackFpsLabel.Text = "FPS";
            // 
            // MiscBlackFpsNumericUpDown
            // 
            this.MiscBlackFpsNumericUpDown.Location = new System.Drawing.Point(288, 107);
            this.MiscBlackFpsNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.MiscBlackFpsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MiscBlackFpsNumericUpDown.Name = "MiscBlackFpsNumericUpDown";
            this.MiscBlackFpsNumericUpDown.Size = new System.Drawing.Size(48, 20);
            this.MiscBlackFpsNumericUpDown.TabIndex = 29;
            this.MiscBlackFpsNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MiscBlackFpsNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MiscBlackPicInputButton
            // 
            this.MiscBlackPicInputButton.Enabled = false;
            this.MiscBlackPicInputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MiscBlackPicInputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscBlackPicInputButton.Location = new System.Drawing.Point(484, 78);
            this.MiscBlackPicInputButton.Name = "MiscBlackPicInputButton";
            this.MiscBlackPicInputButton.Size = new System.Drawing.Size(75, 23);
            this.MiscBlackPicInputButton.TabIndex = 27;
            this.MiscBlackPicInputButton.Text = "图片";
            this.MiscBlackPicInputButton.UseVisualStyleBackColor = true;
            this.MiscBlackPicInputButton.Click += new System.EventHandler(this.MiscBlackPicInputButton_Click);
            // 
            // MiscBlackPicInputTextBox
            // 
            this.MiscBlackPicInputTextBox.AllowDrop = true;
            this.MiscBlackPicInputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MiscBlackPicInputTextBox.EmptyTextTip = null;
            this.MiscBlackPicInputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.MiscBlackPicInputTextBox.Enabled = false;
            this.MiscBlackPicInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MiscBlackPicInputTextBox.Location = new System.Drawing.Point(9, 78);
            this.MiscBlackPicInputTextBox.Name = "MiscBlackPicInputTextBox";
            this.MiscBlackPicInputTextBox.Size = new System.Drawing.Size(469, 21);
            this.MiscBlackPicInputTextBox.TabIndex = 26;
            // 
            // MiscBlackStartButton
            // 
            this.MiscBlackStartButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MiscBlackStartButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscBlackStartButton.Location = new System.Drawing.Point(484, 107);
            this.MiscBlackStartButton.Name = "MiscBlackStartButton";
            this.MiscBlackStartButton.Size = new System.Drawing.Size(75, 23);
            this.MiscBlackStartButton.TabIndex = 25;
            this.MiscBlackStartButton.Text = "后黑";
            this.MiscBlackStartButton.UseVisualStyleBackColor = true;
            this.MiscBlackStartButton.Click += new System.EventHandler(this.MiscBlackStartButton_Click);
            // 
            // MiscBlackOutputButton
            // 
            this.MiscBlackOutputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MiscBlackOutputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscBlackOutputButton.Location = new System.Drawing.Point(484, 49);
            this.MiscBlackOutputButton.Name = "MiscBlackOutputButton";
            this.MiscBlackOutputButton.Size = new System.Drawing.Size(75, 23);
            this.MiscBlackOutputButton.TabIndex = 25;
            this.MiscBlackOutputButton.Text = "输出";
            this.MiscBlackOutputButton.UseVisualStyleBackColor = true;
            this.MiscBlackOutputButton.Click += new System.EventHandler(this.MiscBlackOutputButton_Click);
            // 
            // MiscBlackVideoInputButton
            // 
            this.MiscBlackVideoInputButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MiscBlackVideoInputButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MiscBlackVideoInputButton.Location = new System.Drawing.Point(484, 20);
            this.MiscBlackVideoInputButton.Name = "MiscBlackVideoInputButton";
            this.MiscBlackVideoInputButton.Size = new System.Drawing.Size(75, 23);
            this.MiscBlackVideoInputButton.TabIndex = 25;
            this.MiscBlackVideoInputButton.Text = "视频";
            this.MiscBlackVideoInputButton.UseVisualStyleBackColor = true;
            this.MiscBlackVideoInputButton.Click += new System.EventHandler(this.MiscBlackVideoInputButton_Click);
            // 
            // MiscBlackOutputTextBox
            // 
            this.MiscBlackOutputTextBox.AllowDrop = true;
            this.MiscBlackOutputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MiscBlackOutputTextBox.EmptyTextTip = null;
            this.MiscBlackOutputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.MiscBlackOutputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MiscBlackOutputTextBox.Location = new System.Drawing.Point(9, 49);
            this.MiscBlackOutputTextBox.Name = "MiscBlackOutputTextBox";
            this.MiscBlackOutputTextBox.Size = new System.Drawing.Size(469, 21);
            this.MiscBlackOutputTextBox.TabIndex = 24;
            // 
            // MiscBlackVideoInputTextBox
            // 
            this.MiscBlackVideoInputTextBox.AllowDrop = true;
            this.MiscBlackVideoInputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MiscBlackVideoInputTextBox.EmptyTextTip = null;
            this.MiscBlackVideoInputTextBox.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.MiscBlackVideoInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MiscBlackVideoInputTextBox.Location = new System.Drawing.Point(9, 20);
            this.MiscBlackVideoInputTextBox.Name = "MiscBlackVideoInputTextBox";
            this.MiscBlackVideoInputTextBox.ReadOnly = true;
            this.MiscBlackVideoInputTextBox.Size = new System.Drawing.Size(469, 21);
            this.MiscBlackVideoInputTextBox.TabIndex = 23;
            this.MiscBlackVideoInputTextBox.TextChanged += new System.EventHandler(this.MiscBlackVideoInputTextBox_TextChanged);
            // 
            // ConfigTabPage
            // 
            this.ConfigTabPage.Controls.Add(this.configUserControl);
            this.ConfigTabPage.Location = new System.Drawing.Point(4, 22);
            this.ConfigTabPage.Name = "ConfigTabPage";
            this.ConfigTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ConfigTabPage.Size = new System.Drawing.Size(572, 587);
            this.ConfigTabPage.TabIndex = 11;
            this.ConfigTabPage.Text = "设置";
            this.ConfigTabPage.UseVisualStyleBackColor = true;
            // 
            // configUserControl
            // 
            this.configUserControl.CheckUpdates = true;
            this.configUserControl.CleanupTempFiles = true;
            this.configUserControl.EnableX265 = true;
            this.configUserControl.Location = new System.Drawing.Point(3, 6);
            this.configUserControl.Name = "configUserControl";
            this.configUserControl.Size = new System.Drawing.Size(559, 420);
            this.configUserControl.TabIndex = 0;
            this.configUserControl.UiLanguage = new System.Globalization.CultureInfo("zh-CN");
            this.configUserControl.UiShowSplashScreen = true;
            this.configUserControl.UiTrayIconMode = false;
            this.configUserControl.VideoPlayer = "";
            this.configUserControl.X264ExtraParam = "";
            this.configUserControl.X264Priority = System.Diagnostics.ProcessPriorityClass.Idle;
            this.configUserControl.X264Threads = 0;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(574, 609);
            this.Controls.Add(this.MainTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "小丸工具箱";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.MiscMiscGroupBox.ResumeLayout(false);
            this.MiscMiscGroupBox.PerformLayout();
            this.MediaInfoTab.ResumeLayout(false);
            this.AvsTab.ResumeLayout(false);
            this.AvsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AvsTrimEndNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvsTrimStartNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvsLevelsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvsAddBordersBottomNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvsAddBordersRightNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvsAddBordersTopNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvsSharpenNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvsAddBordersLeftNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvsLanczosResizeHeightNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvsLanczosResizeWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvsTweakContrastNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvsTweakBrightnessNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvsTweakSaturationNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvsTweakChromaNumericUpDown)).EndInit();
            this.ExtractTab.ResumeLayout(false);
            this.ExtractMkvGroupBox.ResumeLayout(false);
            this.ExtractMkvGroupBox.PerformLayout();
            this.ExtractFlvGroupBox.ResumeLayout(false);
            this.ExtractFlvGroupBox.PerformLayout();
            this.ExtractMp4GroupBox.ResumeLayout(false);
            this.ExtractMp4GroupBox.PerformLayout();
            this.MuxTab.ResumeLayout(false);
            this.MuxConvertGroupBox.ResumeLayout(false);
            this.MuxConvertGroupBox.PerformLayout();
            this.MuxMp4GroupBox.ResumeLayout(false);
            this.MuxMp4GroupBox.PerformLayout();
            this.MuxMkvGroupBox.ResumeLayout(false);
            this.MuxMkvGroupBox.PerformLayout();
            this.AudioTab.ResumeLayout(false);
            this.AudioGroupBox.ResumeLayout(false);
            this.AudioGroupBox.PerformLayout();
            this.AudioAudioModePanel.ResumeLayout(false);
            this.AudioBatchGroupBox.ResumeLayout(false);
            this.AudioBatchGroupBox.PerformLayout();
            this.MiscOnePicGroupBox.ResumeLayout(false);
            this.MiscOnePicGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MiscOnePicCrfNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MiscOnePicFpsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MiscOnePicBitrateNumericUpDown)).EndInit();
            this.VideoTab.ResumeLayout(false);
            this.VideoTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VideoFramesNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VideoSeekNumericUpDown)).EndInit();
            this.VideoBatchGroupBox.ResumeLayout(false);
            this.VideoBatchGroupBox.PerformLayout();
            this.VideoX264ModePanel.ResumeLayout(false);
            this.VideoX264ModePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VideoHeightNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VideoWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VideoCrfNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VideoBitrateNumericUpDown)).EndInit();
            this.HelpTab.ResumeLayout(false);
            this.MainTabControl.ResumeLayout(false);
            this.MiscTab.ResumeLayout(false);
            this.MiscBlackGroupBox.ResumeLayout(false);
            this.MiscBlackGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MiscBlackBitrateNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MiscBlackCrfNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MiscBlackFpsNumericUpDown)).EndInit();
            this.ConfigTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private ControlExs.QQButton MiscMiscStartClipButton;
        private System.Windows.Forms.MaskedTextBox MiscMiscEndTimeMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox MiscMiscBeginTimeMaskedTextBox;
        private System.Windows.Forms.Label MiscMiscEndTimeLabel;
        private System.Windows.Forms.Label MiscMiscBeginTimeLabel;
        private ControlExs.QQTextBox MiscMiscVideoOutputTextBox;
        private ControlExs.QQTextBox MiscMiscVideoInputTextBox;
        private ControlExs.QQButton MiscMiscVideoOutputButton;
        private ControlExs.QQButton MiscMiscVideoInputButton;
        private System.Windows.Forms.TabPage MediaInfoTab;
        private System.Windows.Forms.TabPage AvsTab;
        private ControlExs.QQButton AvsClearButton;
        private ControlExs.QQButton AvsGenerateButton;
        private ControlExs.QQButton AvsPreviewButton;
        private ControlExs.QQButton AvsStartButton;
        private ControlExs.QQTextBox AvsScriptTextBox;
        private ControlExs.QQTextBox AvsVideoInputTextBox;
        private ControlExs.QQTextBox AvsOutputTextBox;
        private ControlExs.QQTextBox AvsSubtitleInputTextBox;
        private ControlExs.QQButton AvsVideoInputButton;
        private ControlExs.QQButton AvsOutputButton;
        private ControlExs.QQButton AvsSubtitleInputButton;
        private System.Windows.Forms.TabPage ExtractTab;
        private System.Windows.Forms.GroupBox ExtractMkvGroupBox;
        private ControlExs.QQButton ExtractMkvExtractTrack0Button;
        private ControlExs.QQButton ExtractMkvInputButton;
        private ControlExs.QQTextBox ExtractMkvInputTextBox;
        private System.Windows.Forms.GroupBox ExtractFlvGroupBox;
        private ControlExs.QQButton ExtractFlvExtractVideoButton;
        private ControlExs.QQButton ExtractFlvInputButton;
        private ControlExs.QQTextBox ExtractFlvInputTextBox;
        private ControlExs.QQButton ExtractFlvExtractAudioButton;
        private System.Windows.Forms.GroupBox ExtractMp4GroupBox;
        private ControlExs.QQTextBox ExtractMp4InputTextBox;
        private ControlExs.QQButton ExtractMp4ExtractAudio3Button;
        private ControlExs.QQButton ExtractMp4InputButton;
        private ControlExs.QQButton ExtractMp4ExtractVideoButton;
        private ControlExs.QQButton ExtractMp4ExtractAudio1Button;
        private ControlExs.QQButton ExtractMp4ExtractAudio2Button;
        private System.Windows.Forms.TabPage MuxTab;
        private System.Windows.Forms.GroupBox MuxMkvGroupBox;
        private ControlExs.QQTextBox MuxMkvVideoInputTextBox;
        private ControlExs.QQButton MuxMkvOutputButton;
        private ControlExs.QQTextBox MuxMkvSubtitleTextBox;
        private ControlExs.QQButton MuxMkvAudioInputButton;
        private ControlExs.QQTextBox MuxMkvAudioInputTextBox;
        private ControlExs.QQButton MuxMkvSubtitleButton;
        private ControlExs.QQTextBox MuxMkvOutputTextBox;
        private ControlExs.QQButton MuxMkvVideoInputButton;
        private ControlExs.QQButton MuxMkvStartButton;
        private System.Windows.Forms.GroupBox MuxConvertGroupBox;
        private System.Windows.Forms.ListBox MuxConvertItemListBox;
        private ControlExs.QQButton MuxConvertAddButton;
        private ControlExs.QQButton MuxConvertClearButton;
        private System.Windows.Forms.Label MuxConvertOutputNotificationLabel;
        private ControlExs.QQButton MuxConvertDeleteButton;
        private ControlExs.QQButton MuxConvertStartButton;
        private System.Windows.Forms.GroupBox MuxMp4GroupBox;
        private ControlExs.QQTextBox MuxMp4VideoInputTextBox;
        private ControlExs.QQButton MuxMp4VideoInputButton;
        private ControlExs.QQButton MuxMp4StartButton;
        private System.Windows.Forms.ComboBox MuxMp4FpsComboBox;
        private ControlExs.QQButton MuxMp4AudioInputButton;
        private ControlExs.QQButton MuxMp4OutputButton;
        private ControlExs.QQTextBox MuxMp4AudioInputTextBox;
        private System.Windows.Forms.Label MuxMp4FpsLabel;
        private ControlExs.QQTextBox MuxMp4OutputTextBox;
        private System.Windows.Forms.TabPage AudioTab;
        private System.Windows.Forms.Panel AudioAudioModePanel;
        private System.Windows.Forms.Label AudioKbpsLabel;
        private System.Windows.Forms.Label AudioBitrateLabel;
        private ControlExs.QQButton AudioStartButton;
        private ControlExs.QQButton AudioOutputBotton;
        private ControlExs.QQButton AudioInputButton;
        private System.Windows.Forms.GroupBox AudioBatchGroupBox;
        private ControlExs.QQTextBox AudioOutputTextBox;
        private ControlExs.QQTextBox AudioInputTextBox;
        private ControlExs.QQTextBox AudioCustomParameterTextBox;
        private System.Windows.Forms.TabPage VideoTab;
        private System.Windows.Forms.GroupBox VideoBatchGroupBox;
        private System.Windows.Forms.ListBox VideoBatchItemListbox;
        private ControlExs.QQButton VideoBatchClearButton;
        private ControlExs.QQCheckBox VideoBatchSubtitleCheckBox;
        private ControlExs.QQButton VideoBatchDeleteButton;
        private ControlExs.QQButton VideoBatchStartButton;
        private ControlExs.QQButton VideoBatchAddButton;
        private ControlExs.QQCheckBox VideoAutoShutdownCheckBox;
        private ControlExs.QQTextBox VideoAudioParameterTextBox;
        private ControlExs.QQTextBox VideoSubtitleTextBox;
        private ControlExs.QQTextBox VideoOutputTextBox;
        private ControlExs.QQTextBox VideoInputTextBox;
        private ControlExs.QQTextBox VideoCustomParameterTextBox;
        private ControlExs.QQButton VideoAddPresetButton;
        private ControlExs.QQButton VideoDeletePresetButton;
        private ControlExs.QQButton VideoStartButton;
        private ControlExs.QQButton VideoSubtitleButton;
        private ControlExs.QQButton VideoOutputButton;
        private ControlExs.QQButton VideoInputButton;
        private System.Windows.Forms.Label VideoEncoderLabel;
        private System.Windows.Forms.Label VideoPresetLabel;
        private System.Windows.Forms.ComboBox VideoEncoderComboBox;
        private System.Windows.Forms.ComboBox VideoFpsComboBox;
        private System.Windows.Forms.Label VideoFpsLabel;
        private System.Windows.Forms.ComboBox VideoAudioModeComboBox;
        private System.Windows.Forms.ComboBox VideoPresetComboBox;
        private System.Windows.Forms.Label VideoAudioModeLabel;
        private System.Windows.Forms.Label VideoGoToAudioLabel;
        private System.Windows.Forms.Label VideoBitrateKbpsLabel;
        private System.Windows.Forms.Panel VideoX264ModePanel;
        private ControlExs.QQRadioButton VideoModeCrfRadioButton;
        private ControlExs.QQRadioButton VideoModeCustomRadioButton;
        private ControlExs.QQRadioButton VideoMode2PassRadioButton;
        private System.Windows.Forms.Label VideoDemuxerLabel;
        private System.Windows.Forms.Label VideoCrfLabel;
        private System.Windows.Forms.Label VideoHeightLabel;
        private System.Windows.Forms.Label VideoWidthLabel;
        private System.Windows.Forms.NumericUpDown VideoHeightNumericUpDown;
        private System.Windows.Forms.NumericUpDown VideoWidthNumericUpDown;
        private System.Windows.Forms.NumericUpDown VideoBitrateNumericUpDown;
        private System.Windows.Forms.NumericUpDown VideoCrfNumericUpDown;
        private System.Windows.Forms.Label VideoBitrateLabel;
        private System.Windows.Forms.TabPage HelpTab;
        private System.Windows.Forms.TabControl MainTabControl;
        private ControlExs.QQRadioButton AudioAudioModeBitrateRadioButton;
        private ControlExs.QQRadioButton AudioAudioModeCustomRadioButton;
        private System.Windows.Forms.GroupBox MiscMiscGroupBox;
        private System.Windows.Forms.ListBox AudioBatchItemListBox;
        private ControlExs.QQButton AudioBatchAddButton;
        private ControlExs.QQButton AudioBatchClearButton;
        private ControlExs.QQButton AudioBatchDeleteButton;
        private ControlExs.QQButton AudioBatchStartButton;
        private System.Windows.Forms.Label AudioBatchOutputNotificationLabel;
        private System.Windows.Forms.NumericUpDown AvsLanczosResizeHeightNumericUpDown;
        private System.Windows.Forms.NumericUpDown AvsLanczosResizeWidthNumericUpDown;
        private System.Windows.Forms.Label AvsTweakContrastLabel;
        private System.Windows.Forms.Label AvsTweakBrightnessLabel;
        private System.Windows.Forms.Label AvsTweakSaturationLabel;
        private System.Windows.Forms.Label AvsTweakChromaLabel;
        private System.Windows.Forms.NumericUpDown AvsTweakContrastNumericUpDown;
        private System.Windows.Forms.NumericUpDown AvsTweakBrightnessNumericUpDown;
        private System.Windows.Forms.NumericUpDown AvsTweakSaturationNumericUpDown;
        private System.Windows.Forms.NumericUpDown AvsTweakChromaNumericUpDown;
        private ControlExs.QQCheckBox AvsTrimCheckBox;
        private ControlExs.QQCheckBox AvsSharpenCheckBox;
        private ControlExs.QQCheckBox AvsAddBordersCheckBox;
        private ControlExs.QQCheckBox AvsLanczosResizeCheckBox;
        private ControlExs.QQCheckBox AvsTweakCheckBox;
        private ControlExs.QQCheckBox AvsUndotCheckBox;
        private System.Windows.Forms.NumericUpDown AvsLevelsNumericUpDown;
        private System.Windows.Forms.Label AvsAddBordersTopLabel;
        private System.Windows.Forms.Label AvsAddBordersRightLabel;
        private System.Windows.Forms.Label AvsAddBordersBottomLabel;
        private System.Windows.Forms.Label AvsAddBordersLeftLabel;
        private System.Windows.Forms.NumericUpDown AvsAddBordersBottomNumericUpDown;
        private System.Windows.Forms.NumericUpDown AvsAddBordersRightNumericUpDown;
        private System.Windows.Forms.NumericUpDown AvsAddBordersTopNumericUpDown;
        private System.Windows.Forms.NumericUpDown AvsSharpenNumericUpDown;
        private ControlExs.QQCheckBox AvsLevelsCheckBox;
        private ControlExs.QQCheckBox AvsCropCheckBox;
        private System.Windows.Forms.NumericUpDown AvsAddBordersLeftNumericUpDown;
        private System.Windows.Forms.Label AvsLanczosResizeHeightLabel;
        private System.Windows.Forms.Label AvsLanczosResizeWidthLabel;
        private System.Windows.Forms.Label AvsCropIntroductionLabel;
        private ControlExs.QQTextBox AvsCropTextBox;
        private System.Windows.Forms.Label AvsTrimEndLabel;
        private System.Windows.Forms.Label AvsTrimStartLabel;
        private System.Windows.Forms.NumericUpDown AvsTrimEndNumericUpDown;
        private System.Windows.Forms.NumericUpDown AvsTrimStartNumericUpDown;
        private System.Windows.Forms.ComboBox VideoDemuxerComboBox;
        private ControlExs.QQButton VideoBatchOutputFolderButton;
        private ControlExs.QQTextBox VideoBatchOutputFolderTextBox;
        private System.Windows.Forms.GroupBox AudioGroupBox;
        private System.Windows.Forms.Label AudioEncoderLabel;
        private System.Windows.Forms.ComboBox AudioEncoderComboBox;
        private System.Windows.Forms.TabPage ConfigTabPage;
        private ControlExs.QQButton AvsSaveButton;
        private System.Windows.Forms.Label VideoFramesLabel;
        private System.Windows.Forms.Label VideoSeekLabel;
        private System.Windows.Forms.NumericUpDown VideoFramesNumericUpDown;
        private System.Windows.Forms.NumericUpDown VideoSeekNumericUpDown;
        private ControlExs.QQCheckBox VideoMaintainResolutionCheckBox;
        private ControlExs.QQButton ExtractMkvExtractTrack4Button;
        private ControlExs.QQButton ExtractMkvExtractTrack3Button;
        private ControlExs.QQButton ExtractMkvExtractTrack2Button;
        private ControlExs.QQButton ExtractMkvExtractTrack1Button;
        private System.Windows.Forms.GroupBox MiscOnePicGroupBox;
        private ControlExs.QQButton MiscOnePicStartButton;
        private ControlExs.QQButton MiscOnePicAudioInputButton;
        private ControlExs.QQButton MiscOnePicInputButton;
        private ControlExs.QQTextBox MiscOnePicAudioInputTextBox;
        private ControlExs.QQTextBox MiscOnePicInputTextBox;
        private ControlExs.QQButton MiscOnePicOutputButton;
        private ControlExs.QQTextBox MiscOnePicOutputTextBox;
        private System.Windows.Forms.Label MiscOnePicKbpsLabel;
        private System.Windows.Forms.Label MiscOnePicBitrateLabel;
        private System.Windows.Forms.NumericUpDown MiscOnePicBitrateNumericUpDown;
        private System.Windows.Forms.Label MiscOnePicFpsLabel;
        private System.Windows.Forms.NumericUpDown MiscOnePicFpsNumericUpDown;
        private ControlExs.QQCheckBox MiscOnePicCopyAudioCheckBox;
        private System.Windows.Forms.TabPage MiscTab;
        private System.Windows.Forms.GroupBox MiscBlackGroupBox;
        private ControlExs.QQButton MiscBlackStartButton;
        private ControlExs.QQButton MiscBlackOutputButton;
        private ControlExs.QQButton MiscBlackVideoInputButton;
        private ControlExs.QQTextBox MiscBlackOutputTextBox;
        private ControlExs.QQTextBox MiscBlackVideoInputTextBox;
        private ControlExs.QQButton MiscBlackPicInputButton;
        private ControlExs.QQTextBox MiscBlackPicInputTextBox;
        private System.Windows.Forms.NumericUpDown MiscOnePicCrfNumericUpDown;
        private System.Windows.Forms.Label MiscOnePicCrfLabel;
        private System.Windows.Forms.NumericUpDown MiscBlackCrfNumericUpDown;
        private System.Windows.Forms.Label MiscBlackCrfLabel;
        private ControlExs.QQCheckBox MiscBlackNoPicCheckBox;
        private System.Windows.Forms.Label MiscBlackFpsLabel;
        private System.Windows.Forms.NumericUpDown MiscBlackFpsNumericUpDown;
        private System.Windows.Forms.ComboBox MiscBlackDurationSecondsComboBox;
        private System.Windows.Forms.Label MiscBlackDurationLabel;
        private System.Windows.Forms.Label MiscBlackDurationSecondsLabel;
        private System.Windows.Forms.Label MiscBlackKbpsLabel;
        private System.Windows.Forms.Label MiscBlackBitrateLabel;
        private System.Windows.Forms.NumericUpDown MiscBlackBitrateNumericUpDown;
        private System.Windows.Forms.ComboBox AudioBitrateComboBox;
        private ControlExs.QQCheckBox AvsIncludeAudioCheckBox;
        private System.Windows.Forms.ComboBox AvsFilterComboBox;
        private ControlExs.QQButton AvsAddFilterButton;
        private System.Windows.Forms.Label AvsFilterLabel;
        private System.Windows.Forms.ComboBox VideoBatchSubtitleLanguage;
        private System.Windows.Forms.Label MuxConvertFormatLabel;
        private System.Windows.Forms.ComboBox MuxConvertFormatComboBox;
        private ControlExs.QQButton AudioBatchConcatButton;
        private System.Windows.Forms.ComboBox MuxMp4ParComboBox;
        private System.Windows.Forms.Label MuxMp4ParLabel;
        private ControlExs.QQButton ExtractMkvExtractByExternalButton;
        private ControlExs.QQButton MuxMp4ReplaceAudioButton;
        private System.Windows.Forms.ComboBox MiscMiscTransposeComboBox;
        private ControlExs.QQButton MiscMiscStartRotateButton;
        private System.Windows.Forms.Label MiscMiscTransposeLabel;
        private System.Windows.Forms.Label VideoBatchFormatLabel;
        private System.Windows.Forms.ComboBox VideoBatchFormatComboBox;
        private System.Windows.Forms.ComboBox AudioPresetComboBox;
        private System.Windows.Forms.Label AudioPresetLabel;
        private System.Windows.Forms.Label MuxConvertAacEncoderLabel;
        private System.Windows.Forms.ComboBox MuxConvertAacEncoderComboBox;
        private ControlExs.QQButton AudioPresetDeleteButton;
        private ControlExs.QQButton AudioPresetAddButton;
        private System.Windows.Forms.Label MiscOnePicDurationSecondsLabel;
        private System.Windows.Forms.TextBox MiscOnePicDurationSecondsTextBox;
        private System.Windows.Forms.Label MiscOnePicDurationLabel;
        private UserCtrl.HelpUserControl helpUserControl;
        private UserCtrl.ConfigUserControl configUserControl;
        private UserCtrl.MediaInfoUserControl mediaInfoUserControl1;
    }
}

