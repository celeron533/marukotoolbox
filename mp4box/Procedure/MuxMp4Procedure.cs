using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace mp4box.Procedure
{
    public class MuxMp4Procedure : ProcedureBase<MuxMp4Procedure>
    {
        public string videoInputFile { get; set; }
        public string audioInputFile { get; set; }
        public string outputFile { get; set; }
        public string fpsStr { get; set; }
        public string parStr { get; set; }

        string batpath = "";

        public MuxMp4Procedure():base()
        {
        }

        public override void GetDataFromUI(Action<MuxMp4Procedure> p)
        {
            p.Invoke(this);
        }

        public override void SetDataToUI(Action<MuxMp4Procedure> p)
        {
            p.Invoke(this);
        }

        public override void Execute()
        {
            StringBuilder mp4Command = new StringBuilder();
            mp4Command.Append(FileStringUtil.FormatPath(ToolsUtil.MP4BOX.fullPath) + " -add \"" + videoInputFile + "#trackID=1");
            if (parStr != "")
                mp4Command.Append(":par=" + parStr);
            if (fpsStr != "auto" && fpsStr != "")
                mp4Command.Append(":fps=" + fpsStr);
            mp4Command.Append(":name=\""); //输入raw时删除默认添加的gpac字符串
            if (audioInputFile != "")
                mp4Command.Append(" -add \"" + audioInputFile + ":name=\"");
            mp4Command.Append(" -new \"" + outputFile + "\" \r\n cmd");

            string mux = mp4Command.ToString();
            batpath = ToolsUtil.ToolsFolder + "\\mux.bat";
            File.WriteAllText(batpath, mux, Encoding.Default);
            //TODO: Log function
            //LogRecord(mux);
            Process.Start(batpath);
        }

        public void ExecuteReplaceAudio()
        {
            //mux = "\"" + workPath + "\\ffmpeg.exe\" -y -i \"" + namevideo + "\" -c:v copy -an  \"" + workPath + "\\video_noaudio.mp4\" \r\n";
            //mux += "\"" + workPath + "\\ffmpeg.exe\" -y -i \"" + workPath + "\\video_noaudio.mp4\" -i \"" + nameaudio + "\" -vcodec copy  -acodec copy \"" + nameout + "\" \r\n";
            //mux += "del \"" + workPath + "\\video_noaudio.mp4\" \r\n";
            string mux = "\"" + ToolsUtil.FFMPEG.fullPath + "\" -y -i \"" + videoInputFile + "\" -i \"" + audioInputFile + "\" -map 0:v -c:v copy -map 1:0 -c:a copy  \"" + outputFile + "\" \r\n";
            batpath = ToolsUtil.ToolsFolder + "\\mux.bat";
            File.WriteAllText(batpath, mux, Encoding.Default);
            logger.Info(mux);
            Process.Start(batpath);
        }
    }
}
