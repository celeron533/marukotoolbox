using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mp4box.Utility
{
    public static class UIUtil
    {
        //Ctrl+A 可以全选文本
        public static void TextBoxSelectAll(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
                ((TextBoxBase)sender).SelectAll();  // using TextBoxBase to include TextBox, RichTextBox and MaskedTextBox
        }
    }
}
