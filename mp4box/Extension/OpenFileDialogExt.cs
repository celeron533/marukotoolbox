using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static mp4box.Utility.DialogUtil;

namespace mp4box.Extension
{
    public static class OpenFileDialogExt
    {
        /// <summary>
        /// Prepare a dialog with filter and preset selected file
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="presetFileName"></param>
        /// <returns></returns>
        public static OpenFileDialog Prepare(this OpenFileDialog dialog, string filter = "", string presetFileName = "")
        {
            if (!string.IsNullOrEmpty(presetFileName))
                dialog.FileName = presetFileName;
            if (!string.IsNullOrEmpty(filter))
                dialog.Filter = filter;
            return dialog;
        }

        /// <summary>
        /// Update the reference <c>selectedFileName</c> when user click OK
        /// </summary>
        /// <param name="selectedFileName">reference of the output selected file path</param>
        /// <returns></returns>
        public static DialogResult ShowDialogExt(this OpenFileDialog dialog, ref string selectedFileName)
        {
            DialogResult result;
            if ((result = dialog.ShowDialog()) == DialogResult.OK)
                selectedFileName = dialog.FileName;
            return result;
        }

        /// <summary>
        /// Update the reference <c>selectedFileNameTextBoxBase.Text</c> when user click OK
        /// </summary>
        /// <param name="selectedFileNameTextBoxBase"></param>
        /// <returns></returns>
        public static DialogResult ShowDialogExt(this OpenFileDialog dialog, TextBoxBase selectedFileNameTextBoxBase)
        {
            DialogResult result;
            if ((result = dialog.ShowDialog()) == DialogResult.OK)
                selectedFileNameTextBoxBase.Text = dialog.FileName;
            return result;
        }
    }
}
