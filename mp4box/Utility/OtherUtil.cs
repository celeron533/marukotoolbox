using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace mp4box
{
    public static class OtherUtil
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

        /// <summary>
        /// Change the process priority by process name
        /// </summary>
        /// <param name="processName"></param>
        /// <param name="priority"></param>
        /// <returns>Count of affected processes.</returns>
        public static int ChangeProcessesPriorityByName(string processName, ProcessPriority priority)
        {

            ProcessPriorityClass newPriority;

            switch (priority)
            {
                case ProcessPriority.Idle: newPriority = ProcessPriorityClass.Idle; break;
                case ProcessPriority.BelowNormal: newPriority = ProcessPriorityClass.BelowNormal; break;
                default:
                case ProcessPriority.Normal: newPriority = ProcessPriorityClass.Normal; break;
                case ProcessPriority.AboveNormal: newPriority = ProcessPriorityClass.AboveNormal; break;
                case ProcessPriority.High: newPriority = ProcessPriorityClass.High; break;
                case ProcessPriority.RealTime: newPriority = ProcessPriorityClass.RealTime; break;
            }

            var processes = Process.GetProcesses().Where(p => p.ProcessName == processName);
            processes.ToList().ForEach(p => p.PriorityClass = newPriority);
            return processes.Count();
        }
    }
}
