using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mp4box2.Utility
{
    public class StringHelper
    {
        public static string Quotation(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;
            return "\"" + input + "\"";
        }


        /// concat:D:\一二三123.png 可以防止FFMpeg不认中文名输入文件的Bug
        public static string ConcatProtocol(string path)
        {
            return Quotation("concat:" + path);
        }
    }
}
