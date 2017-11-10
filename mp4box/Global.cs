using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace mp4box
{
    public static class Global
    {
        public static readonly DateTime ReleaseDate = AssemblyUtil.GetAssemblyVersionTime();

        public static class Running
        {
            public static readonly string startPath = AppDomain.CurrentDomain.BaseDirectory;
            public static bool shutdownState = false;
            public static bool trayMode = false;

            public static Settings settings = new Settings();

            // Note: you can redirect the tempFolder to different folder even for different MarukoToolbox instances
            public static string tempFolder = Path.Combine(startPath, "temp");
            public static string tempAvsFile = Path.Combine(tempFolder + "tempAvs.avs");
            public static string tempImgFile = Path.Combine(tempFolder + "tempImg.jpg");
        }


    }
}
