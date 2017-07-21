using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mp4box.Extension
{
    public static class StringBuilderExt
    {
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