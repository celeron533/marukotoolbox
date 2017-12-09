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
        public CultureInfo UiLanguage
        {
            get
            {
                return (CultureInfo)ConfigUiLanguageComboBox.SelectedValue;
            }
            set
            {
                ConfigUiLanguageComboBox.SelectedItem = UiLanguageBindingList.Single(item => item.Value.LCID == value.LCID);
            }
        }

        public bool UiShowSplashScreen
        {
            get
            {
                return ConfigUiSplashScreenCheckBox.Checked;
            }
            set
            {
                ConfigUiSplashScreenCheckBox.Checked = value;
            }
        }

        public bool UiTrayIconMode
        {
            get
            {
                return ConfigUiTrayModeCheckBox.Checked;
            }
            set
            {
                ConfigUiTrayModeCheckBox.Checked = value;
            }
        }

        public ProcessPriorityClass X264Priority
        {
            get
            {
                return (ProcessPriorityClass)ConfigX264PriorityComboBox.SelectedValue;
            }
            set
            {
                ConfigX264PriorityComboBox.SelectedItem = X264PriorityBindingList.Single(item => item.Value == value);
            }
        }

        public int X264Threads
        {
            get
            {
                return (int)ConfigX264ThreadsComboBox.SelectedValue;
            }
            set
            {
                ConfigX264ThreadsComboBox.SelectedValue = value;
            }
        }

        public string X264ExtraParam
        {
            get
            {
                return ConfigX264ExtraParameterTextBox.Text;
            }
            set
            {
                ConfigX264ExtraParameterTextBox.Text = value;
            }
        }

        public string VideoPlayer
        {
            get
            {
                return ConfigFunctionVideoPlayerTextBox.Text;
            }
            set
            {
                ConfigFunctionVideoPlayerTextBox.Text = value;
            }
        }

        public bool CleanupTempFiles
        {
            get
            {
                return ConfigFunctionDeleteTempFileCheckBox.Checked;
            }
            set
            {
                ConfigFunctionDeleteTempFileCheckBox.Checked = value;
            }
        }

        public bool CheckUpdates
        {
            get
            {
                return ConfigFunctionAutoCheckUpdateCheckBox.Checked;
            }
            set
            {
                ConfigFunctionAutoCheckUpdateCheckBox.Checked = value;
            }
        }

        public bool EnableX265
        {
            get
            {
                return ConfigFunctionEnableX265CheckBox.Checked;
            }
            set
            {
                ConfigFunctionEnableX265CheckBox.Checked = value;
            }
        }


        //Binding Lists
        private BindingList<BindingListItem<CultureInfo>> UiLanguageBindingList;
        private BindingList<BindingListItem<ProcessPriorityClass>> X264PriorityBindingList;
        private BindingList<BindingListItem<int>> X264ThreadsBindingList;


        public ConfigUserControl()
        {
            InitializeComponent();
            InitializeBindingLists();
        }

        private void InitializeBindingLists()
        {
            if (UiLanguageBindingList == null)
            {
                UiLanguageBindingList = new BindingList<BindingListItem<CultureInfo>>
                {
                    new BindingListItem<CultureInfo>("zh-CN", "zh-CN", new CultureInfo("zh-CN")),
                    new BindingListItem<CultureInfo>("zh-TW", "zh-TW", new CultureInfo("zh-TW")),
                    new BindingListItem<CultureInfo>("en-US", "en-US", new CultureInfo("en-US")),
                    new BindingListItem<CultureInfo>("ja-JP", "ja-JP", new CultureInfo("ja-JP"))
                };
                ConfigUiLanguageComboBox.DisplayMember = "DisplayName";
                ConfigUiLanguageComboBox.ValueMember = "Value";
                ConfigUiLanguageComboBox.DataSource = UiLanguageBindingList;
            }

            if (X264PriorityBindingList == null)
            {
                X264PriorityBindingList = new BindingList<BindingListItem<ProcessPriorityClass>>
                {
                    new BindingListItem<ProcessPriorityClass>("Idle", "Idle", ProcessPriorityClass.Idle),
                    new BindingListItem<ProcessPriorityClass>("BelowNormal", "BelowNormal", ProcessPriorityClass.BelowNormal),
                    new BindingListItem<ProcessPriorityClass>("Normal", "Normal", ProcessPriorityClass.Normal),
                    new BindingListItem<ProcessPriorityClass>("AboveNormal", "AboveNormal", ProcessPriorityClass.AboveNormal),
                    new BindingListItem<ProcessPriorityClass>("High", "High", ProcessPriorityClass.High),
                    new BindingListItem<ProcessPriorityClass>("RealTime", "RealTime", ProcessPriorityClass.RealTime)
                };
                ConfigX264PriorityComboBox.DisplayMember = "DisplayName";
                ConfigX264PriorityComboBox.ValueMember = "Value";
                ConfigX264PriorityComboBox.DataSource = X264PriorityBindingList;
            }

            if (X264ThreadsBindingList == null)
            {
                X264ThreadsBindingList = new BindingList<BindingListItem<int>>
                {
                    new BindingListItem<int>("Auto","Auto",0)
                };
                for (int i = 1; i <= Environment.ProcessorCount; i++)
                {
                    X264ThreadsBindingList.Add(new BindingListItem<int>(i.ToString(), i.ToString(), i));
                }
                ConfigX264ThreadsComboBox.DisplayMember = "DisplayName";
                ConfigX264ThreadsComboBox.ValueMember = "Value";
                ConfigX264ThreadsComboBox.DataSource = X264ThreadsBindingList;
            }
        }


        private void ConfigUiTrayModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Global.Running.trayMode = ConfigUiTrayModeCheckBox.Checked;
        }

        private void ConfigX264PriorityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((MainForm)ParentForm)?.ChangeEncoderProcessPriority();
        }

        private void ConfigFunctionViewLogButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(Global.Running.logFileName))
            {
                Process.Start(Global.Running.logFileName);
            }
            else MessageBoxExt.ShowInfoMessage("没有找到日志文件。");
        }

        private void ConfigFunctionAllLogButton_Click(object sender, EventArgs e)
        {
            string logPath = Path.GetDirectoryName(Global.Running.logFileName);
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
                ((MainForm)ParentForm).ResetUIFieldParameters();
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
