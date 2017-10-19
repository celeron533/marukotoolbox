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

using mp4box.Extension;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mp4box
{
    public class SplashAppContext : ApplicationContext
    {
        Form primaryForm = null;

        // Show the splash form and then auto close it
        public SplashAppContext(Form primaryForm, Form splashForm) : base(splashForm)
        {
            this.primaryForm = primaryForm;
            new Task(() =>
            {
                Thread.Sleep(2000);
                splashForm.InvokeIfRequired(() =>
                {
                    splashForm.Dispose();
                });
            }).Start();
        }

        protected override void OnMainFormClosed(object sender, EventArgs e)
        {
            // Hand-over MainForm to the real MainForm
            if (sender is SplashForm)
            {
                base.MainForm = this.primaryForm;
                base.MainForm.Show();
            }
            // Exit App
            else if (sender is MainForm)
            {
                base.OnMainFormClosed(sender, e);
            }
        }
    }
}
