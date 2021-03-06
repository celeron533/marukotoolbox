﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace mp4box.Procedure
{
    public class MiscProcedure : ProcedureBase<MiscProcedure>
    {
        public string inputVideoFilePath { get; set; }
        public string outputVideoFilePath { get; set; }
        public string beginTimeStr { get; set; }
        public string endTimeStr { get; set; }
        public int transposeIndex { get; set; }

        string batpath = "";

        public MiscProcedure() : base()
        {
        }

        public override void GetDataFromUI(Action<MiscProcedure> p)
        {
            p.Invoke(this);
        }

        public override void SetDataToUI(Action<MiscProcedure> p)
        {
            p.Invoke(this);
        }

        /// <summary>
        /// ExecuteClip
        /// </summary>
        public override void Execute()
        {
            int[] begin = new int[]
            {
                int.Parse(beginTimeStr.Substring(0, 2)),
                int.Parse(beginTimeStr.Substring(3, 2)),
                int.Parse(beginTimeStr.Substring(6, 2))
            };

            int[] end = new int[]
            {
                int.Parse(endTimeStr.Substring(0, 2)),
                int.Parse(endTimeStr.Substring(3, 2)),
                int.Parse(endTimeStr.Substring(6, 2))
            };

            string clip = string.Format(@"""{0}"" -ss {1} -t {2} -y -i ""{3}"" -c copy ""{4}""",
                    ToolsUtil.FFMPEG.fullPath, beginTimeStr, OtherUtil.TimeSubtract(begin, end), inputVideoFilePath, outputVideoFilePath) + Environment.NewLine + "cmd";
            //clip = string.Format(@"""{0}\ffmpeg.exe"" -i ""{3}"" -ss {1} -to {2} -y  -c copy ""{4}""", workPath, maskb.Text, maske.Text, namevideo4, nameout5) + Environment.NewLine + "cmd";
            batpath = ToolsUtil.ToolsFolder + "\\clip.bat";
            // TODO: Log function
            //LogRecord(clip);
            File.WriteAllText(batpath, clip, Encoding.Default);
            Process.Start(batpath);
        }

        /// <summary>
        /// ExecuteRotate
        /// </summary>
        public void ExecuteRotate()
        {
            string clip = string.Format(@"""{0}"" -i ""{1}"" -vf ""transpose={2}"" -y ""{3}""",
                    ToolsUtil.FFMPEG.fullPath, inputVideoFilePath, transposeIndex, outputVideoFilePath) + Environment.NewLine + "cmd";
            batpath = ToolsUtil.ToolsFolder + "\\clip.bat";
            logger.Info(clip);
            File.WriteAllText(batpath, clip, Encoding.Default);
            Process.Start(batpath);
        }
    }
}
