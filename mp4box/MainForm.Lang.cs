using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace mp4box
{
    public partial class MainForm
    {
        /// <summary>
        /// Get the corresponding resource file of the form and them apply it.
        /// </summary>
        /// <param name="cultureInfo"></param>
        /// <param name="form"></param>
        /// <param name="formType"></param>
        public static void SetLang(CultureInfo cultureInfo, Form form, Type formType)
        {
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            if (form != null)
            {
                ComponentResourceManager resources = new ComponentResourceManager(formType);
                resources.ApplyResources(form, "$this");
                AppLang(form, resources);
            }
        }

        /// <summary>
        /// Apply the language resource to Controls
        /// </summary>
        /// <param name="control"></param>
        /// <param name="resources"></param>
        private static void AppLang(Control control, ComponentResourceManager resources)
        {
            foreach (Control c in control.Controls)
            {
                resources.ApplyResources(c, c.Name);
                AppLang(c, resources);
            }
        }

        private CultureInfo GetCultureFromComboBox()
        {
            CultureInfo cultureInfo;
            switch (ConfigUiLanguageComboBox.SelectedIndex)
            {
                default:
                case 0:
                    cultureInfo = new CultureInfo("zh-CN");
                    break;
                case 1:
                    cultureInfo = new CultureInfo("zh-TW");
                    break;
                case 2:
                    cultureInfo = new CultureInfo("en-US");
                    break;
                case 3:
                    cultureInfo = new CultureInfo("ja-JP");
                    break;
            }
            return cultureInfo;
        }


        private void SwitchUILanguage(Thread UIThread)
        {
            CultureInfo cultureInfo = GetCultureFromComboBox();
            UIThread.CurrentUICulture = cultureInfo;
            SetLang(cultureInfo, this, typeof(MainForm));

            VideoModeCrfRadioButton.Checked = true;
            AudioAudioModeBitrateRadioButton.Checked = true;
            int VideoAudioModeComboBoxIndex = 0;

            switch (cultureInfo.Name)
            {
                default:
                case "zh-CN":
                    //SetLang("zh-CN", this, typeof(MainForm));
                    //this.Text = string.Format("小丸工具箱 {0}", Assembly.GetExecutingAssembly().GetName().Version.Build);
                    this.Text = string.Format("小丸工具箱 {0}", Utility.AssemblyUtil.GetAssemblyFileVersion());
                    ConfigX264PriorityComboBox.Items.Clear();
                    ConfigX264PriorityComboBox.Items.AddRange(new string[] { "低", "低于标准", "普通", "高于标准", "高", "实时" });
                    ConfigX264PriorityComboBox.SelectedIndex = 2;

                    VideoAudioModeComboBoxIndex = VideoAudioModeComboBox.SelectedIndex;
                    VideoAudioModeComboBox.Items.Clear();
                    VideoAudioModeComboBox.Items.Add("压制音频");
                    VideoAudioModeComboBox.Items.Add("无音频流");
                    VideoAudioModeComboBox.Items.Add("复制音频流");
                    VideoAudioModeComboBox.SelectedIndex = VideoAudioModeComboBoxIndex;

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

                case "zh-TW":
                    //SetLang("zh-TW", this, typeof(MainForm));
                    this.Text = string.Format("小丸工具箱 {0}", Utility.AssemblyUtil.GetAssemblyFileVersion());
                    ConfigX264PriorityComboBox.Items.Clear();
                    ConfigX264PriorityComboBox.Items.AddRange(new string[] { "低", "在標準以下", "標準", "在標準以上", "高", "即時" });
                    ConfigX264PriorityComboBox.SelectedIndex = 2;

                    VideoAudioModeComboBoxIndex = VideoAudioModeComboBox.SelectedIndex;
                    VideoAudioModeComboBox.Items.Clear();
                    VideoAudioModeComboBox.Items.Add("壓制音頻");
                    VideoAudioModeComboBox.Items.Add("無音頻流");
                    VideoAudioModeComboBox.Items.Add("拷貝音頻流");
                    VideoAudioModeComboBox.SelectedIndex = VideoAudioModeComboBoxIndex;

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

                case "en-US":
                    //SetLang("en-US", this, typeof(MainForm));
                    this.Text = string.Format("Maruko Toolbox {0}", Utility.AssemblyUtil.GetAssemblyFileVersion());
                    ConfigX264PriorityComboBox.Items.Clear();
                    ConfigX264PriorityComboBox.Items.AddRange(new string[] { "Idle", "BelowNormal", "Normal", "AboveNormal", "High", "RealTime" });
                    ConfigX264PriorityComboBox.SelectedIndex = 2;

                    VideoAudioModeComboBoxIndex = VideoAudioModeComboBox.SelectedIndex;
                    VideoAudioModeComboBox.Items.Clear();
                    VideoAudioModeComboBox.Items.Add("with audio");
                    VideoAudioModeComboBox.Items.Add("no audio");
                    VideoAudioModeComboBox.Items.Add("copy audio");
                    VideoAudioModeComboBox.SelectedIndex = VideoAudioModeComboBoxIndex;

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

                case "ja-JP":
                    //SetLang("ja-JP", this, typeof(MainForm));
                    this.Text = string.Format("小丸道具箱 {0}", Utility.AssemblyUtil.GetAssemblyFileVersion());
                    ConfigX264PriorityComboBox.Items.Clear();
                    ConfigX264PriorityComboBox.Items.AddRange(new string[] { "低", "通常以下", "通常", "通常以上", "高", "リアルタイム" });
                    ConfigX264PriorityComboBox.SelectedIndex = 2;

                    VideoAudioModeComboBoxIndex = VideoAudioModeComboBox.SelectedIndex;
                    VideoAudioModeComboBox.Items.Clear();
                    VideoAudioModeComboBox.Items.Add("オーディオ付き");
                    VideoAudioModeComboBox.Items.Add("オーディオなし");
                    VideoAudioModeComboBox.Items.Add("オーディオ コピー");
                    VideoAudioModeComboBox.SelectedIndex = VideoAudioModeComboBoxIndex;

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
            }
        }

    }
}
