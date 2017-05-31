﻿// ------------------------------------------------------------------
// Copyright (C) 2016 Maruko Toolbox Project
// 
//
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
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mp4box
{
    public partial class InputBox : Form
    {
        private InputBox()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public static string Show(string message, string title, string text)
        {
            using (InputBox inbox = new InputBox())
            {
                inbox.MessageLabel.Text = message;
                inbox.InputTextBox.Text = text;
                inbox.Text = title;
                return inbox.ShowDialog() == DialogResult.OK ? inbox.InputTextBox.Text : null;
            }
        }

        private void InputTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OKButton_Click(null, null);
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                CancelButton_Click(null, null);
            }
        }
    }
}
