using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mp4box.Extension
{
    public static class StringBuilderExt
    {
        /// <summary>
        /// Append parameters, separated with space
        /// </summary>
        /// <param name="sb">StringBuilder</param>
        /// <param name="parameters">Array of parameters</param>
        /// <returns>StringBuilder</returns>
        public static StringBuilder AppendParameters(this StringBuilder sb, params object[] parameters)
        {
            // Insert a leading space when necessary
            if (sb.Length > 0 && sb[sb.Length - 1] != ' ')
            {
                sb.Append(' ');
            }
            // Join the parameters, separated with space
            return sb.Append(String.Join(" ", parameters));
        }
    }
}