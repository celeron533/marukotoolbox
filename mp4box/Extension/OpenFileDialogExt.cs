using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static mp4box.Utility.DialogUtil;

namespace System.Windows.Forms
{
    public static class OpenFileDialogExt
    {
        public static OpenFileDialog Prepare(this OpenFileDialog dialog, string filter = "", string presetFileName = "")
        {
            if (!string.IsNullOrEmpty(presetFileName))
                dialog.FileName = presetFileName;
            if (!string.IsNullOrEmpty(filter))
                dialog.Filter = filter;
            return dialog;
        }

        public static OpenFileDialog Prepare(this OpenFileDialog dialog, DialogFilterTypes filterType, string presetFileName = "")
        {
            return dialog.Prepare(GetDialogFilter(filterType), presetFileName);
        }

        public static DialogResult ShowDialogExt(this OpenFileDialog dialog, out string selectedFileName)
        {
            DialogResult result;
            if ((result = dialog.ShowDialog()) == DialogResult.OK)
                selectedFileName = dialog.FileName;
            else
                selectedFileName = string.Empty;
            return result;
        }

        public static DialogResult ShowDialogExt(this OpenFileDialog dialog, TextBoxBase selectedFileNameTextBoxBase)
        {
            DialogResult result;
            if ((result = dialog.ShowDialog()) == DialogResult.OK)
                selectedFileNameTextBoxBase.Text = dialog.FileName;
            return result;
        }
    }
}
