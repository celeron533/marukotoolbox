using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace mp4box.Utility
{
    public static class Other
    {
        /// <summary>
        /// 获取图片编码类型信息
        /// </summary>
        /// <param name="imageCoderType">编码类型</param>
        /// <returns>ImageCodecInfo</returns>
        public static ImageCodecInfo GetImageCoderInfo(string imageCoderType)
        {
            return ImageCodecInfo.GetImageEncoders()?.FirstOrDefault(e => e.MimeType.Equals(imageCoderType));
        }


        /// <summary>
        /// Convert HHMMSS to seconds
        /// </summary>
        /// <param name="hhmmss">"99:59:59"</param>
        /// <returns>Converted seconds </returns>
        public static int SecondsFromHHMMSS(string hhmmss)
        {
            int hh = int.Parse(hhmmss.Substring(0, 2));
            int mm = int.Parse(hhmmss.Substring(3, 2));
            int ss = int.Parse(hhmmss.Substring(6, 2));
            return hh * 3600 + mm * 60 + ss;
        }
    }
}
