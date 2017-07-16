using mp4box.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace mp4box
{
    public static class Global
    {
        public static class Running
        {
            public static readonly string startPath = AppDomain.CurrentDomain.BaseDirectory;
            public static bool shutdownState = false;
            public static bool trayMode = false;

            // Note: you can redirect the tempPath to different folder even for different MarukoToolbox instances
            public static string tempPath = Path.Combine(startPath, "temp");
            public static string tempAvsPath = Path.Combine(tempPath + "tempAvs.avs");
            public static string tempImgPath = Path.Combine(tempPath + "tempImg.jpg");
        }


    }
}
