using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mp4box.Extension
{
    /// <summary>
    /// A wrapper to make Invoke more easy by using Method Extension.
    /// </summary>
    public static class Invoker
    {
        public static void InvokeIfRequired(this ISynchronizeInvoke control, MethodInvoker action)
        {
            if (control.InvokeRequired)
                control.Invoke(action, null);
            else
                action();
        }
    }
}
