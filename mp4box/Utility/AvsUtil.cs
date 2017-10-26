using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace mp4box
{
    /// <summary>
    /// Operations relate to AVS
    /// </summary>
    public static class AvsUtil
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        const string AVISYNTH = "AviSynth.dll";

        public static bool IsEmbeddedAvsInstalled()
        {
            return IsAvsInstalled(AvsLocationType.Embedded);
        }

        public static bool IsSystemAvsInstalled()
        {
            return IsAvsInstalled(AvsLocationType.System32) || IsAvsInstalled(AvsLocationType.SysWOW64);
        }

        public static bool IsAvsInstalled(AvsLocationType avsLocationType)
        {
            return GetAvsLocations().Exists(l => l.avsLocationType == avsLocationType);
        }

        /// <summary>
        /// Get file locations of system AVS and embedded AVS file.
        /// </summary>
        /// <returns>List of AvsLocation</returns>
        public static List<AvsLocation> GetAvsLocations()
        {
            List<AvsLocation> locations = new List<AvsLocation>();
            // 32-bit %windir%\SysWOW64 on 64-bit OS
            string syswow64path = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86);
            // %windir%\System32 on 32-bit OS
            string system32path = Environment.GetFolderPath(Environment.SpecialFolder.System);

            // Maruko folder
            string embeddedAvsPath = Path.Combine(ToolsUtil.ToolsFolder, AVISYNTH);
            if (File.Exists(embeddedAvsPath))
            {
                locations.Add(new AvsLocation(embeddedAvsPath, AvsLocationType.Embedded));
            }

            // System folder - system32
            string system32AvsPath = Path.Combine(system32path, AVISYNTH);
            if (File.Exists(system32AvsPath))
            {
                locations.Add(new AvsLocation(system32AvsPath, AvsLocationType.System32));
            }

            // System folder - syswow64
            string sysWOW64AvsPath = Path.Combine(syswow64path, AVISYNTH);
            if (File.Exists(sysWOW64AvsPath))
            {
                locations.Add(new AvsLocation(sysWOW64AvsPath, AvsLocationType.SysWOW64));
            }

            return locations;
        }

        /// <summary>
        /// Initialize embedded Avs files.
        /// Copy Avs files from tools\avs folder to tools folder when necessary.
        /// </summary>
        public static void ManipulateAVSFiles()
        {
            // 系统avisynth未安装，使用小丸内置的avs
            if (!IsSystemAvsInstalled())
            {
                string sourceAviSynthdll = Path.Combine(ToolsUtil.AvsFolder, "AviSynth.dll");
                string sourceDevILdll = Path.Combine(ToolsUtil.AvsFolder, "DevIL.dll");
                if (File.Exists(sourceAviSynthdll) && File.Exists(sourceDevILdll))
                {
                    try
                    {
                        File.Copy(sourceAviSynthdll, Path.Combine(ToolsUtil.ToolsFolder, "AviSynth.dll"), true);
                        File.Copy(sourceDevILdll, Path.Combine(ToolsUtil.ToolsFolder, "DevIL.dll"), true);
                        logger.Info("系统未安装avisynth,使用小丸内置avs.");
                    }
                    catch (IOException) { }
                }
            }
        }

        public class AvsLocation
        {
            public AvsLocation(string avsFile, AvsLocationType type)
            {
                this.avsLocationType = type;
                this.fileInfo = new FileInfo(avsFile);
                this.fileVersionInfo = FileVersionInfo.GetVersionInfo(avsFile);
            }

            public AvsLocationType avsLocationType;
            public FileInfo fileInfo;
            public FileVersionInfo fileVersionInfo;
            public override string ToString()
            {
                string fileVersion = fileVersionInfo.FileVersion.Replace(", ", ".");
                string fileDate = fileInfo.LastWriteTimeUtc.ToString("dd-MM-yyyy");
                string fileProductName = fileVersionInfo.ProductName;
                // Note: remain original output format before refactor
                return avsLocationType + ": AviSynth" + (fileProductName.Contains("+") ? "+" : string.Empty) + "版本: " + fileVersion + " (" + fileDate + ")";
            }
        }
    }
}
