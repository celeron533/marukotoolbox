﻿using System;
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


        /// <summary>
        /// Calculate time: EndTime - BeginTime
        /// </summary>
        /// <param name="beginTimeInt">Array of hh, mm, ss</param>
        /// <param name="endTimeInt">Array of hh, mm, ss</param>
        /// <returns>hh:mm:ss as formatted string</returns>
        public static string TimeSubtract(int[] beginTimeInt, int[] endTimeInt)
        {
            // endTimeInt must later than beginTimeInt
            // TimeSpan not able to direct parse greater than 24 hours without day specified
            TimeSpan beginTime = new TimeSpan(beginTimeInt[0], beginTimeInt[1], beginTimeInt[2]);
            TimeSpan endTime = new TimeSpan(endTimeInt[0], endTimeInt[1], endTimeInt[2]);
            if (endTime > beginTime)
            {
                TimeSpan result = endTime.Subtract(beginTime);
                // Do not use TimeSpan.ToString(), which converts hours to day when it is greater than 24h
                return $"{(int)result.TotalHours}:{result.Minutes}:{result.Seconds}";
            }
            else
            {
                TimeSpan result = beginTime.Subtract(endTime);
                return $"-{(int)result.TotalHours}:{result.Minutes}:{result.Seconds}";
            }
        }

        // <summary>
        /// 是否安装 Apple Application Support
        /// </summary>
        /// <returns>true:安装 false:没有安装</returns>
        public static bool IsAppleAppSupportInstalled()
        {
            Microsoft.Win32.RegistryKey uninstallNode_1 = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"Software\Wow6432Node\Apple Inc.\Apple Application Support"); //x64 OS
            Microsoft.Win32.RegistryKey uninstallNode_2 = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"Software\Apple Inc.\Apple Application Support"); //x86 OS
            if (uninstallNode_1 != null || uninstallNode_2 != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}