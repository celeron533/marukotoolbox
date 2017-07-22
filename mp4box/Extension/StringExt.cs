using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mp4box.Extension
{
    public static class StringExt
    {
        /// <summary>
        /// Add quotation mark around the string
        /// </summary>
        /// <param name="str">The source string</param>
        /// <param name="quote">Quotation mark you want to use. Default is 'Double quotation mark'</param>
        /// <returns></returns>
        public static string Quote(this string str, string quote = "\"")
        {
            return quote + str + quote;
        }
    }
}
