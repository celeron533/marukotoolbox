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
            this.MediaInfoTab = new System.Windows.Forms.TabPage();
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
            this.MuxTab = new System.Windows.Forms.TabPage();
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
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.MiscTab = new System.Windows.Forms.TabPage();
            this.ConfigTabPage = new System.Windows.Forms.TabPage();
            this.miscUserControl1 = new mp4box.UserCtrl.MiscUserControl();
            this.muxUserControl1 = new mp4box.UserCtrl.MuxUserControl();
            this.mediaInfoUserControl1 = new mp4box.UserCtrl.MediaInfoUserControl();
            this.configUserControl = new mp4box.UserCtrl.ConfigUserControl();
            this.helpUserControl = new mp4box.UserCtrl.HelpUserControl();
            this.extractUserControl1 = new mp4box.UserCtrl.ExtractUserControl();
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
            this.MuxTab.SuspendLayout();
            this.AudioTab.SuspendLayout();
            this.AudioGroupBox.SuspendLayout();
            this.AudioAudioModePanel.SuspendLayout();
            this.AudioBatchGroupBox.SuspendLayout();
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
            this.ConfigTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 9000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            this.AvsTab.Size = new System.Drawing.Size(572, 587);
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
            this.AvsFilterLabel.Size = new System.Drawing.Size(53, 12);
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
            this.AvsFilterComboBox.Size = new System.Drawing.Size(295, 20);
            this.AvsFilterComboBox.TabIndex = 64;
            // 
            // AvsCropIntroductionLabel
            // 
            this.AvsCropIntroductionLabel.AutoSize = true;
            this.AvsCropIntroductionLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsCropIntroductionLabel.Location = new System.Drawing.Point(156, 176);
            this.AvsCropIntroductionLabel.Name = "AvsCropIntroductionLabel";
            this.AvsCropIntroductionLabel.Size = new System.Drawing.Size(185, 12);
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
            this.AvsTrimEndLabel.Size = new System.Drawing.Size(41, 12);
            this.AvsTrimEndLabel.TabIndex = 60;
            this.AvsTrimEndLabel.Text = "结束帧";
            // 
            // AvsTrimStartLabel
            // 
            this.AvsTrimStartLabel.AutoSize = true;
            this.AvsTrimStartLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsTrimStartLabel.Location = new System.Drawing.Point(156, 204);
            this.AvsTrimStartLabel.Name = "AvsTrimStartLabel";
            this.AvsTrimStartLabel.Size = new System.Drawing.Size(41, 12);
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
            this.AvsTrimEndNumericUpDown.Size = new System.Drawing.Size(88, 21);
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
            this.AvsTrimStartNumericUpDown.Size = new System.Drawing.Size(88, 21);
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
            this.AvsLevelsNumericUpDown.Size = new System.Drawing.Size(57, 21);
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
            this.AvsAddBordersTopLabel.Size = new System.Drawing.Size(17, 12);
            this.AvsAddBordersTopLabel.TabIndex = 47;
            this.AvsAddBordersTopLabel.Text = "上";
            // 
            // AvsAddBordersRightLabel
            // 
            this.AvsAddBordersRightLabel.AutoSize = true;
            this.AvsAddBordersRightLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsAddBordersRightLabel.Location = new System.Drawing.Point(337, 150);
            this.AvsAddBordersRightLabel.Name = "AvsAddBordersRightLabel";
            this.AvsAddBordersRightLabel.Size = new System.Drawing.Size(17, 12);
            this.AvsAddBordersRightLabel.TabIndex = 46;
            this.AvsAddBordersRightLabel.Text = "右";
            // 
            // AvsAddBordersBottomLabel
            // 
            this.AvsAddBordersBottomLabel.AutoSize = true;
            this.AvsAddBordersBottomLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsAddBordersBottomLabel.Location = new System.Drawing.Point(421, 150);
            this.AvsAddBordersBottomLabel.Name = "AvsAddBordersBottomLabel";
            this.AvsAddBordersBottomLabel.Size = new System.Drawing.Size(17, 12);
            this.AvsAddBordersBottomLabel.TabIndex = 45;
            this.AvsAddBordersBottomLabel.Text = "下";
            // 
            // AvsAddBordersLeftLabel
            // 
            this.AvsAddBordersLeftLabel.AutoSize = true;
            this.AvsAddBordersLeftLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsAddBordersLeftLabel.Location = new System.Drawing.Point(168, 150);
            this.AvsAddBordersLeftLabel.Name = "AvsAddBordersLeftLabel";
            this.AvsAddBordersLeftLabel.Size = new System.Drawing.Size(17, 12);
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
            this.AvsAddBordersBottomNumericUpDown.Size = new System.Drawing.Size(55, 21);
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
            this.AvsAddBordersRightNumericUpDown.Size = new System.Drawing.Size(55, 21);
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
            this.AvsAddBordersTopNumericUpDown.Size = new System.Drawing.Size(55, 21);
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
            this.AvsSharpenNumericUpDown.Size = new System.Drawing.Size(55, 21);
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
            this.AvsAddBordersLeftNumericUpDown.Size = new System.Drawing.Size(55, 21);
            this.AvsAddBordersLeftNumericUpDown.TabIndex = 36;
            this.AvsAddBordersLeftNumericUpDown.ValueChanged += new System.EventHandler(this.GenerateAVSHandler);
            // 
            // AvsLanczosResizeHeightLabel
            // 
            this.AvsLanczosResizeHeightLabel.AutoSize = true;
            this.AvsLanczosResizeHeightLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsLanczosResizeHeightLabel.Location = new System.Drawing.Point(325, 123);
            this.AvsLanczosResizeHeightLabel.Name = "AvsLanczosResizeHeightLabel";
            this.AvsLanczosResizeHeightLabel.Size = new System.Drawing.Size(29, 12);
            this.AvsLanczosResizeHeightLabel.TabIndex = 35;
            this.AvsLanczosResizeHeightLabel.Text = "高度";
            // 
            // AvsLanczosResizeWidthLabel
            // 
            this.AvsLanczosResizeWidthLabel.AutoSize = true;
            this.AvsLanczosResizeWidthLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsLanczosResizeWidthLabel.Location = new System.Drawing.Point(156, 123);
            this.AvsLanczosResizeWidthLabel.Name = "AvsLanczosResizeWidthLabel";
            this.AvsLanczosResizeWidthLabel.Size = new System.Drawing.Size(29, 12);
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
            this.AvsLanczosResizeHeightNumericUpDown.Size = new System.Drawing.Size(88, 21);
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
            this.AvsLanczosResizeWidthNumericUpDown.Size = new System.Drawing.Size(88, 21);
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
            this.AvsTweakContrastLabel.Size = new System.Drawing.Size(41, 12);
            this.AvsTweakContrastLabel.TabIndex = 31;
            this.AvsTweakContrastLabel.Text = "对比度";
            // 
            // AvsTweakBrightnessLabel
            // 
            this.AvsTweakBrightnessLabel.AutoSize = true;
            this.AvsTweakBrightnessLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsTweakBrightnessLabel.Location = new System.Drawing.Point(360, 96);
            this.AvsTweakBrightnessLabel.Name = "AvsTweakBrightnessLabel";
            this.AvsTweakBrightnessLabel.Size = new System.Drawing.Size(29, 12);
            this.AvsTweakBrightnessLabel.TabIndex = 31;
            this.AvsTweakBrightnessLabel.Text = "亮度";
            // 
            // AvsTweakSaturationLabel
            // 
            this.AvsTweakSaturationLabel.AutoSize = true;
            this.AvsTweakSaturationLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsTweakSaturationLabel.Location = new System.Drawing.Point(252, 96);
            this.AvsTweakSaturationLabel.Name = "AvsTweakSaturationLabel";
            this.AvsTweakSaturationLabel.Size = new System.Drawing.Size(41, 12);
            this.AvsTweakSaturationLabel.TabIndex = 31;
            this.AvsTweakSaturationLabel.Text = "饱和度";
            // 
            // AvsTweakChromaLabel
            // 
            this.AvsTweakChromaLabel.AutoSize = true;
            this.AvsTweakChromaLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AvsTweakChromaLabel.Location = new System.Drawing.Point(156, 96);
            this.AvsTweakChromaLabel.Name = "AvsTweakChromaLabel";
            this.AvsTweakChromaLabel.Size = new System.Drawing.Size(29, 12);
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
            this.AvsTweakContrastNumericUpDown.Size = new System.Drawing.Size(55, 21);
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
            this.AvsTweakBrightnessNumericUpDown.Size = new System.Drawing.Size(55, 21);
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
            this.AvsTweakSaturationNumericUpDown.Size = new System.Drawing.Size(55, 21);
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
            this.AvsTweakChromaNumericUpDown.Size = new System.Drawing.Size(55, 21);
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
            this.ExtractTab.Controls.Add(this.extractUserControl1);
            this.ExtractTab.Location = new System.Drawing.Point(4, 22);
            this.ExtractTab.Name = "ExtractTab";
            this.ExtractTab.Padding = new System.Windows.Forms.Padding(3);
            this.ExtractTab.Size = new System.Drawing.Size(572, 587);
            this.ExtractTab.TabIndex = 0;
            this.ExtractTab.Text = "抽取";
            this.ExtractTab.UseVisualStyleBackColor = true;
            // 
            // MuxTab
            // 
            this.MuxTab.Controls.Add(this.muxUserControl1);
            this.MuxTab.Location = new System.Drawing.Point(4, 22);
            this.MuxTab.Name = "MuxTab";
            this.MuxTab.Padding = new System.Windows.Forms.Padding(3);
            this.MuxTab.Size = new System.Drawing.Size(572, 587);
            this.MuxTab.TabIndex = 7;
            this.MuxTab.Text = "封装";
            this.MuxTab.UseVisualStyleBackColor = true;
            // 
            // AudioTab
            // 
            this.AudioTab.AllowDrop = true;
            this.AudioTab.Controls.Add(this.AudioGroupBox);
            this.AudioTab.Controls.Add(this.AudioBatchGroupBox);
            this.AudioTab.Location = new System.Drawing.Point(4, 22);
            this.AudioTab.Name = "AudioTab";
            this.AudioTab.Padding = new System.Windows.Forms.Padding(3);
            this.AudioTab.Size = new System.Drawing.Size(572, 587);
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
            this.AudioPresetComboBox.Size = new System.Drawing.Size(122, 20);
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
            this.AudioPresetLabel.Size = new System.Drawing.Size(29, 12);
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
            this.AudioBitrateComboBox.Size = new System.Drawing.Size(122, 20);
            this.AudioBitrateComboBox.TabIndex = 20;
            this.AudioBitrateComboBox.Text = "128";
            // 
            // AudioEncoderLabel
            // 
            this.AudioEncoderLabel.AutoSize = true;
            this.AudioEncoderLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AudioEncoderLabel.Location = new System.Drawing.Point(18, 81);
            this.AudioEncoderLabel.Name = "AudioEncoderLabel";
            this.AudioEncoderLabel.Size = new System.Drawing.Size(41, 12);
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
            this.AudioEncoderComboBox.Size = new System.Drawing.Size(122, 20);
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
            this.AudioKbpsLabel.Size = new System.Drawing.Size(29, 12);
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
            this.AudioBitrateLabel.Size = new System.Drawing.Size(29, 12);
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
            this.AudioBatchOutputNotificationLabel.Size = new System.Drawing.Size(137, 12);
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
            this.AudioBatchItemListBox.ItemHeight = 12;
            this.AudioBatchItemListBox.Location = new System.Drawing.Point(9, 20);
            this.AudioBatchItemListBox.Name = "AudioBatchItemListBox";
            this.AudioBatchItemListBox.Size = new System.Drawing.Size(551, 280);
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
            this.VideoFramesLabel.Size = new System.Drawing.Size(53, 12);
            this.VideoFramesLabel.TabIndex = 46;
            this.VideoFramesLabel.Text = "编码帧数";
            // 
            // VideoSeekLabel
            // 
            this.VideoSeekLabel.AutoSize = true;
            this.VideoSeekLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoSeekLabel.Location = new System.Drawing.Point(11, 147);
            this.VideoSeekLabel.Name = "VideoSeekLabel";
            this.VideoSeekLabel.Size = new System.Drawing.Size(41, 12);
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
            this.VideoFramesNumericUpDown.Size = new System.Drawing.Size(100, 21);
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
            this.VideoSeekNumericUpDown.Size = new System.Drawing.Size(110, 21);
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
            this.VideoDemuxerComboBox.Size = new System.Drawing.Size(100, 20);
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
            this.VideoBatchFormatLabel.Size = new System.Drawing.Size(29, 12);
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
            this.VideoBatchFormatComboBox.Size = new System.Drawing.Size(72, 20);
            this.VideoBatchFormatComboBox.TabIndex = 30;
            this.VideoBatchFormatComboBox.Text = "mp4";
            // 
            // VideoBatchSubtitleLanguage
            // 
            this.VideoBatchSubtitleLanguage.FormattingEnabled = true;
            this.VideoBatchSubtitleLanguage.Location = new System.Drawing.Point(483, 158);
            this.VideoBatchSubtitleLanguage.Name = "VideoBatchSubtitleLanguage";
            this.VideoBatchSubtitleLanguage.Size = new System.Drawing.Size(75, 20);
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
            this.VideoDemuxerLabel.Size = new System.Drawing.Size(41, 12);
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
            this.VideoEncoderLabel.Size = new System.Drawing.Size(41, 12);
            this.VideoEncoderLabel.TabIndex = 29;
            this.VideoEncoderLabel.Text = "编码器";
            // 
            // VideoEncoderComboBox
            // 
            this.VideoEncoderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VideoEncoderComboBox.FormattingEnabled = true;
            this.VideoEncoderComboBox.Location = new System.Drawing.Point(66, 120);
            this.VideoEncoderComboBox.Name = "VideoEncoderComboBox";
            this.VideoEncoderComboBox.Size = new System.Drawing.Size(239, 20);
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
            this.VideoFpsComboBox.Size = new System.Drawing.Size(88, 20);
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
            this.VideoFpsLabel.Size = new System.Drawing.Size(23, 12);
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
            this.VideoAudioModeComboBox.Size = new System.Drawing.Size(100, 20);
            this.VideoAudioModeComboBox.TabIndex = 20;
            // 
            // VideoPresetComboBox
            // 
            this.VideoPresetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VideoPresetComboBox.FormattingEnabled = true;
            this.VideoPresetComboBox.Location = new System.Drawing.Point(66, 196);
            this.VideoPresetComboBox.Name = "VideoPresetComboBox";
            this.VideoPresetComboBox.Size = new System.Drawing.Size(123, 20);
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
            this.VideoAudioModeLabel.Size = new System.Drawing.Size(53, 12);
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
            this.VideoGoToAudioLabel.Size = new System.Drawing.Size(101, 12);
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
            this.VideoBitrateKbpsLabel.Size = new System.Drawing.Size(29, 12);
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
            this.VideoCrfLabel.Size = new System.Drawing.Size(23, 12);
            this.VideoCrfLabel.TabIndex = 9;
            this.VideoCrfLabel.Text = "CRF";
            // 
            // VideoHeightLabel
            // 
            this.VideoHeightLabel.AutoSize = true;
            this.VideoHeightLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoHeightLabel.Location = new System.Drawing.Point(233, 250);
            this.VideoHeightLabel.Name = "VideoHeightLabel";
            this.VideoHeightLabel.Size = new System.Drawing.Size(29, 12);
            this.VideoHeightLabel.TabIndex = 8;
            this.VideoHeightLabel.Text = "高度";
            // 
            // VideoWidthLabel
            // 
            this.VideoWidthLabel.AutoSize = true;
            this.VideoWidthLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VideoWidthLabel.Location = new System.Drawing.Point(233, 223);
            this.VideoWidthLabel.Name = "VideoWidthLabel";
            this.VideoWidthLabel.Size = new System.Drawing.Size(29, 12);
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
            this.VideoHeightNumericUpDown.Size = new System.Drawing.Size(88, 21);
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
            this.VideoWidthNumericUpDown.Size = new System.Drawing.Size(88, 21);
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
            this.VideoCrfNumericUpDown.Size = new System.Drawing.Size(88, 21);
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
            this.VideoBitrateLabel.Size = new System.Drawing.Size(29, 12);
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
            this.VideoPresetLabel.Size = new System.Drawing.Size(29, 12);
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
            this.VideoBitrateNumericUpDown.Size = new System.Drawing.Size(88, 21);
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
            this.MiscTab.Controls.Add(this.miscUserControl1);
            this.MiscTab.Location = new System.Drawing.Point(4, 22);
            this.MiscTab.Name = "MiscTab";
            this.MiscTab.Padding = new System.Windows.Forms.Padding(3);
            this.MiscTab.Size = new System.Drawing.Size(572, 587);
            this.MiscTab.TabIndex = 12;
            this.MiscTab.Text = "常用";
            this.MiscTab.UseVisualStyleBackColor = true;
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
            // miscUserControl1
            // 
            this.miscUserControl1.Location = new System.Drawing.Point(0, 0);
            this.miscUserControl1.Name = "miscUserControl1";
            this.miscUserControl1.Size = new System.Drawing.Size(566, 543);
            this.miscUserControl1.TabIndex = 0;
            // 
            // muxUserControl1
            // 
            this.muxUserControl1.Location = new System.Drawing.Point(0, 0);
            this.muxUserControl1.Name = "muxUserControl1";
            this.muxUserControl1.Size = new System.Drawing.Size(566, 585);
            this.muxUserControl1.TabIndex = 0;
            // 
            // mediaInfoUserControl1
            // 
            this.mediaInfoUserControl1.Location = new System.Drawing.Point(3, 3);
            this.mediaInfoUserControl1.Name = "mediaInfoUserControl1";
            this.mediaInfoUserControl1.Size = new System.Drawing.Size(561, 588);
            this.mediaInfoUserControl1.TabIndex = 0;
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
            // helpUserControl
            // 
            this.helpUserControl.Location = new System.Drawing.Point(0, 0);
            this.helpUserControl.Name = "helpUserControl";
            this.helpUserControl.Size = new System.Drawing.Size(556, 582);
            this.helpUserControl.TabIndex = 0;
            // 
            // extractUserControl1
            // 
            this.extractUserControl1.Location = new System.Drawing.Point(0, 0);
            this.extractUserControl1.Name = "extractUserControl1";
            this.extractUserControl1.Size = new System.Drawing.Size(566, 585);
            this.extractUserControl1.TabIndex = 0;
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
            this.MuxTab.ResumeLayout(false);
            this.AudioTab.ResumeLayout(false);
            this.AudioGroupBox.ResumeLayout(false);
            this.AudioGroupBox.PerformLayout();
            this.AudioAudioModePanel.ResumeLayout(false);
            this.AudioBatchGroupBox.ResumeLayout(false);
            this.AudioBatchGroupBox.PerformLayout();
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
            this.ConfigTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
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
        private System.Windows.Forms.TabPage MuxTab;
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
        private System.Windows.Forms.TabPage MiscTab;
        private System.Windows.Forms.ComboBox AudioBitrateComboBox;
        private ControlExs.QQCheckBox AvsIncludeAudioCheckBox;
        private System.Windows.Forms.ComboBox AvsFilterComboBox;
        private ControlExs.QQButton AvsAddFilterButton;
        private System.Windows.Forms.Label AvsFilterLabel;
        private System.Windows.Forms.ComboBox VideoBatchSubtitleLanguage;
        private ControlExs.QQButton AudioBatchConcatButton;
        private System.Windows.Forms.Label VideoBatchFormatLabel;
        private System.Windows.Forms.ComboBox VideoBatchFormatComboBox;
        private System.Windows.Forms.ComboBox AudioPresetComboBox;
        private System.Windows.Forms.Label AudioPresetLabel;
        private ControlExs.QQButton AudioPresetDeleteButton;
        private ControlExs.QQButton AudioPresetAddButton;
        private UserCtrl.HelpUserControl helpUserControl;
        private UserCtrl.ConfigUserControl configUserControl;
        private UserCtrl.MediaInfoUserControl mediaInfoUserControl1;
        private UserCtrl.MiscUserControl miscUserControl1;
        private UserCtrl.MuxUserControl muxUserControl1;
        private UserCtrl.ExtractUserControl extractUserControl1;
    }
}

