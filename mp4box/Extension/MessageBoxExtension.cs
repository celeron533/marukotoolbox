using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Windows.Forms
{
    /// Actually it is not a real extension method.
    /// You cannot do this because System.Windows.Forms.MessageBox is NOT an instance of MessageBox.
    /// MessageBox.Show() is a static method.
    /// https://stackoverflow.com/questions/8688479/how-to-add-an-extension-method-to-the-messagebox
    /// And MessageBox class cannot be inherited

    public static class MessageBoxExtension
    {
        public static DialogResult ShowErrorMessage(string argMessage, string argTitle = "错误!")
        {
            return MessageBox.Show(argMessage, argTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowWarningMessage(string argMessage, string argTitle = "警告!")
        {
            return MessageBox.Show(argMessage, argTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DialogResult ShowInfoMessage(string argMessage, string argTitle = "提示!")
        {
            return MessageBox.Show(argMessage, argTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowQuestion(string argQuestion, string argTitle)
        {
            return MessageBox.Show(argQuestion, argTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult ShowQuestionWithCancel(string argQuestion, string argTitle)
        {
            return MessageBox.Show(argQuestion, argTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }
    }
}
