// ------------------------------------------------------------------
// Copyright (C) 2015-2016 Maruko Toolbox Project
// 
//  Authors: LunarShaddow <aflyhorse@hotmail.com>
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mp4box
{
    public partial class UpdateForm : Form
    {
        /// <summary>
        /// Path of new (and temporary) assembly.
        /// </summary>
        private string newPath;

        /// <summary>
        /// Path of current assembly.
        /// </summary>
        private string exePath;

        /// <summary>
        /// Path of designated backup assembly.
        /// </summary>
        private string backupPath;

        /// <summary>
        /// Update Downloader.
        /// </summary>
        private System.Net.WebClient client;

        /// <summary>
        /// Construnctor, initiate an update at targeted directory.
        /// </summary>
        /// <param name="startpath">The directory containing xiaowan.exe.</param>
        /// <param name="newReleaseDate">The new release date.</param>
        public UpdateForm(string startpath, string newReleaseDate)
        {
            InitializeComponent();
            newPath = Path.Combine(startpath, "xiaowan.exe.new");
            exePath = Path.Combine(startpath, "xiaowan.exe");
            backupPath = Path.Combine(startpath, "xiaowan.exe.bak");
            labelDate.Text = newReleaseDate;
        }

        private void FormUpdater_Load(object sender, EventArgs e)
        {
            StartDownload();
        }

        private void StartDownload()
        {
            client = new System.Net.WebClient();
            client.DownloadProgressChanged += client_DownloadProgressChanged;
            client.DownloadFileCompleted += client_DownloadFileCompleted;
            client.DownloadFileAsync(new Uri("http://maruko.appinn.me/config/xiaowan.exe"), newPath);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            client.CancelAsync();
        }

        /// <summary>
        /// Update ProgressBar as requested.
        /// </summary>
        void client_DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            progressBarDownload.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// Clean up. Remove incomplete file or do actually file replacing.
        /// </summary>
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                if (File.Exists(newPath))
                    File.Delete(newPath);
                this.Close();
            }
            else
            {
                if (File.Exists(backupPath))
                    File.Delete(backupPath);
                File.Move(exePath, backupPath);
                File.Move(newPath, exePath);
                Application.Restart();
            }
        }
    }
}
