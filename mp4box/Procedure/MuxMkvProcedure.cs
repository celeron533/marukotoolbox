﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace mp4box.Procedure
{
    public class MuxMkvProcedure : ProcedureBase<MuxMkvProcedure>
    {
        public string output { get; set; }
        public string videoInput { get; set; }
        public string audioInput { get; set; }
        public string subtitleInput { get; set; }

        string workPath, batpath = "";
        [Obsolete("It should be no parameter. Currently is just used for refactor compatibility")]
        public MuxMkvProcedure(string workPath):base()
        {
            this.workPath = workPath;
        }

        public override void GetDataFromUI(Action<MuxMkvProcedure> p)
        {
            p.Invoke(this);
        }

        public override void SetDataToUI(Action<MuxMkvProcedure> p)
        {
            p.Invoke(this);
        }

        public override void Execute()
        {
            StringBuilder mkvCommand = new StringBuilder();
            mkvCommand.Append("\"" + workPath + "\\mkvmerge.exe\" -o \"" + output + "\"")
                .AppendParameters($"\"{videoInput}\"");

            if (!string.IsNullOrEmpty(audioInput))
                mkvCommand.AppendParameters($"\"{audioInput}\"");
            if (!string.IsNullOrEmpty(audioInput))
                mkvCommand.AppendParameters($"\"{subtitleInput}\"");

            mkvCommand.AppendLine("cmd");
            batpath = workPath + "\\mkvmerge.bat";
            File.WriteAllText(batpath, mkvCommand.ToString(), Encoding.Default);
            // TODO: Log function
            //LogRecord(mkvCommand.ToString());
            Process.Start(batpath);
        }
    }
}