// ------------------------------------------------------------------
// Copyright (C) 2011-2017 Maruko Toolbox Project
// 
//  Authors: komaruchan <sandy_0308@hotmail.com>
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

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace mp4box
{
    //启动画面会停留一段时间，该时间是设定的时间和主窗体构造所需时间两个的最大值 
    public class SplashScreen : ApplicationContext
    {
        private Form splashScreenForm;
        private Form primaryForm;
        private System.Timers.Timer splashScreenTimer;
        private int splashScreenTimerInterval; 
        private bool isSplashScreenClosed = false;
        private delegate void DisposeDelegate();//关闭委托，下面需要使用控件的Invoke方法，该方法需要这个委托 

        public SplashScreen(Form splashScreenForm, Form primaryForm, int delay = 5000)
        {
            this.splashScreenForm = splashScreenForm;
            this.primaryForm = primaryForm;
            splashScreenTimerInterval = (delay > 0 ? delay : 5000); // give default value

            //TODO: use Task to refactor
            ShowSplashScreen();
            LoadMainForm();
        }

        private void ShowSplashScreen()
        {
            splashScreenTimer = new System.Timers.Timer(splashScreenTimerInterval)
            {
                AutoReset = false
            };

            splashScreenTimer.Elapsed += SplashScreenTimer_Elapsed;

            Thread DisplaySpashScreenThread = new Thread(new ThreadStart(DisplaySplashScreen));
            DisplaySpashScreenThread.Start();
        }

        private void SplashScreenTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            splashScreenTimer.Dispose();
            splashScreenTimer = null;
            isSplashScreenClosed = true;
        }

        private void DisplaySplashScreen()
        {
            splashScreenTimer.Enabled = true;
            Application.Run(this.splashScreenForm);
        }



        private void LoadMainForm()
        {
            while (!isSplashScreenClosed)
            {
                Application.DoEvents();
            }
            DisposeDelegate SplashScreenFormDisposeDelegate = new DisposeDelegate(splashScreenForm.Dispose);
            splashScreenForm.Invoke(SplashScreenFormDisposeDelegate);
            splashScreenForm = null;
            //必须先显示，再激活，否则主窗体不能在启动窗体消失后出现 
            primaryForm.Show();
            primaryForm.Activate();
            this.primaryForm.Closed += PrimaryForm_Closed;
        }

        private void PrimaryForm_Closed(object sender, EventArgs e)
        {
            base.ExitThread();
        }
    }
}
