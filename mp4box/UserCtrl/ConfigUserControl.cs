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
using System.Diagnostics;
using mp4box.Extension;
using static mp4box.DialogUtil;
using System.Globalization;

namespace mp4box.UserCtrl
{
    public partial class ConfigUserControl : UserControl
    {
        MainForm mainForm;

        public ConfigUserControl()
        {
            InitializeComponent();
            //todo: remove this dependency
            mainForm = (MainForm)ParentForm;
        }

        public CultureInfo GetCultureFromComboBox()
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

        private void ConfigUiTrayModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Global.Running.trayMode = ConfigUiTrayModeCheckBox.Checked;
        }
        private void ConfigX264PriorityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mainForm.ChangeEncoderProcessPriority();
        }
        private void ConfigFunctionViewLogButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(mainForm.logFileName))
            {
                Process.Start(mainForm.logFileName);
            }
            else MessageBoxExt.ShowInfoMessage("没有找到日志文件。");
        }
        private void ConfigFunctionAllLogButton_Click(object sender, EventArgs e)
        {
            string logPath = Path.GetDirectoryName(mainForm.logFileName);
            if (Directory.Exists(logPath))
            {
                Process.Start(logPath);
            }
            else MessageBoxExt.ShowInfoMessage("没有找到日志文件夹。");
        }
        private void ConfigFunctionRestoreDefaultButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBoxExt.ShowQuestion("是否将所有界面参数恢复到默认设置？", "提示");
            if (result == DialogResult.Yes)
            {
                mainForm.ResetUIFieldParameters();
                MessageBoxExt.ShowInfoMessage("已恢复默认设置！");
            }
        }
        private void ConfigFunctionVideoPlayerButton_Click(object sender, EventArgs e)
        {
            new OpenFileDialog()    //"程序(*.exe)|*.exe|所有文件(*.*)|*.*";
                .Prepare(DialogFilter.PROGRAM, ConfigFunctionVideoPlayerTextBox.Text)
                .ShowDialogExt(ConfigFunctionVideoPlayerTextBox);
        }
        private void ConfigFunctionEnableX265CheckBox_Click(object sender, EventArgs e)
        {
            if (MessageBoxExt.ShowQuestion("你必须重新启动小丸工具箱才能使设置的生效 是否现在重新启动？", "需要重新启动") == DialogResult.Yes)
                Application.Restart();
        }

        private void ConfigUiLanguageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //todo
            //SwitchUILanguage(Thread.CurrentThread);
        }
    }
}
