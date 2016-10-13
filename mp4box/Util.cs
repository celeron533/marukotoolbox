// ------------------------------------------------------------------
// Copyright (C) 2011-2016 Maruko Toolbox Project
// 
//  Authors: LYF <lyfjxymf@sina.com>
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
// express or implied.
// See the License for the specific language governing permissions
// and limitations under the License.
// -------------------------------------------------------------------
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Reflection;

namespace mp4box
{
    class Util
    {
        /// <summary>
        /// 自动加引号
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string FormatPath(string path)
        {
            if (string.IsNullOrEmpty(path)) { return null; }
            string ret = null;
            ret = path.Replace("\"", "");
            if (ret.Contains(" ")) { ret = "\"" + ret + "\""; }
            return ret;
        }

        /// <summary>
        /// concat:D:\一二三123.png 可以防止FFMpeg不认中文名输入文件的Bug
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ConcatProtocol(string path)
        {
            return FormatPath("concat:" + path);
        }

        /// <summary>
        /// 防止文件或目录重名
        /// </summary>
        /// <param name="oriPath_">原路径</param>
        /// <returns>不会重名的路径</returns>
        public static string GetSuitablePath(string oriPath_)
        {
            if (string.IsNullOrEmpty(oriPath_)) { return null; }
            string oriPath = oriPath_.Replace("\"", string.Empty);//去掉引号

            if ((!File.Exists(oriPath)) && (!Directory.Exists(oriPath)))
            {
                return oriPath;
            }
            int i = 0;
            string ext = Path.GetExtension(oriPath);
            string str = oriPath.Remove(oriPath.Length - ext.Length) + "_" + i;
            while (File.Exists(str + ext) || Directory.Exists(str + ext))
            {
                i++;
                str = oriPath + "_" + i;
            }

            return str + ext;
        }

        /// <summary>
        /// <para></para>输入：目标文件的 路径或所在目录；
        /// <para></para>输入：原始文件的路径；
        /// <para></para>输出：输出文件的路径。
        /// <para></para>用目标目录或文件路径（取自tbOutput），和输入的文件，返回一个供输出的文件路径。
        /// </summary>
        /// <param name="DestDirOrFile_">目标目录或文件路径</param>
        /// <param name="SrcFile_">输入的文件（若DestDirOrFile是文件，则忽略此项）</param>
        /// <param name="dotExtension">换扩展名</param>
        /// <returns></returns>
        public static string GetSimilarFilePath(string DestDirOrFile_, string SrcFile_, string dotExtension)
        {
            if (string.IsNullOrEmpty(DestDirOrFile_)) { return null; }
            if (string.IsNullOrEmpty(SrcFile_)) { return null; }
            string DestDirOrFile = DestDirOrFile_.Replace("\"", string.Empty);
            string SrcFile = SrcFile_.Replace("\"", string.Empty);//去掉引号

            if (DestDirOrFile.EndsWith("\\"))//目录
            {
                if (string.IsNullOrEmpty(dotExtension))//没有指定扩展名
                {
                    return DestDirOrFile + Path.GetFileName(SrcFile);
                }
                else//指定了扩展名
                {
                    return DestDirOrFile + Path.GetFileNameWithoutExtension(SrcFile) + dotExtension;
                }
            }
            else
            {
                //单文件，已经设置好了输出
                //DestDirOrFile是文件路径

                if (string.IsNullOrEmpty(dotExtension))//没有指定扩展名
                {
                    return DestDirOrFile;
                }
                else//指定了扩展名
                {
                    return ChangeExt(DestDirOrFile, dotExtension);//换扩展名
                }
            }
        }

        /// <summary>
        /// 用目标目录或文件路径（取自tbOutput），和输入的文件，返回一个供输出的文件路径。
        /// </summary>
        /// <param name="DestDirOrFile">目标目录或文件路径</param>
        /// <param name="SrcFile">输入的文件</param>
        /// <returns></returns>
        public static string GetSimilarFilePath(string DestDirOrFile, string SrcFile)
        {
            return GetSimilarFilePath(DestDirOrFile, SrcFile, null);
        }

        /// <summary>
        /// 更换扩展名（保留绝对路径）
        /// </summary>
        /// <param name="srcFile"></param>
        /// <param name="ext"></param>
        /// <returns></returns>
        public static string ChangeExt(string srcFile, string ext)
        {
            return GetDir(srcFile) + Path.GetFileNameWithoutExtension(srcFile) + ext;
        }

        /// <summary>
        /// 获取文件目录，带“\”
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static string GetDir(string path)
        {
            string fileDir = Path.GetDirectoryName(path);
            if (fileDir.EndsWith("\\"))
            {
                return fileDir;
            }
            else
            {
                return fileDir + "\\";
            }
        }

        public static void DeleteDirectoryIfExists(string path, bool recursive)
        {
            if (Directory.Exists(path))
                Directory.Delete(path, recursive);
        }

        public static DirectoryInfo ensureDirectoryExists(string path)
        {
            if (Directory.Exists(path))
                return new DirectoryInfo(path);
            if (string.IsNullOrEmpty(path))
                throw new IOException("无法创建目录");
            ensureDirectoryExists(GetDirectoryName(path));
            System.Threading.Thread.Sleep(100);
            return Directory.CreateDirectory(path);
        }

        public static string GetDirectoryName(string file)
        {
            string path = string.Empty;
            try
            {
                path = Path.GetDirectoryName(file);
            }
            catch { }
            return path;
        }

        /// <summary>
        /// Gets the file version/date
        /// </summary>
        /// <param name="fileName">the file to check</param>
        /// <param name="fileVersion">the file version</param>
        /// <param name="fileDate">the file date</param>
        /// <param name="fileProductName">the file product name</param>
        /// <returns>true if file can be found, false if file cannot be found</returns>
        public static bool GetFileInformation(string fileName, out string fileVersion, out string fileDate, out string fileProductName)
        {
            fileVersion = fileDate = fileProductName = string.Empty;
            if (!File.Exists(fileName))
                return false;

            FileVersionInfo FileProperties = FileVersionInfo.GetVersionInfo(fileName);
            fileVersion = FileProperties.FileVersion;
            if (!String.IsNullOrEmpty(fileVersion))
                fileVersion = fileVersion.Replace(", ", ".");
            fileDate = File.GetLastWriteTimeUtc(fileName).ToString("dd-MM-yyyy");
            fileProductName = FileProperties.ProductName;
            return true;
        }


        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(int Description, int ReservedValue);
        /// <summary>
        /// 用于检查网络是否可以连接互联网,true表示连接成功,false表示连接失败 
        /// </summary>
        /// <returns></returns>
        public static bool IsConnectInternet()
        {
            int Description = 0;
            return InternetGetConnectedState(Description, 0);
        }

        /// <summary>
        /// 检查目录是否可写入
        /// </summary>
        /// <param name"strPath">需要检查的路径</param>
        public static bool IsDirWriteable(string strPath)
        {
            try
            {
                bool bDirectoryCreated = false;

                if (!Directory.Exists(strPath))
                {
                    Directory.CreateDirectory(strPath);
                    bDirectoryCreated = true;
                }

                string newFilePath = string.Empty;
                do
                    newFilePath = Path.Combine(strPath, Path.GetRandomFileName());
                while (File.Exists(newFilePath));

                FileStream fs = File.Create(newFilePath);
                fs.Close();
                File.Delete(newFilePath);

                if (bDirectoryCreated)
                    Directory.Delete(strPath);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Detects the AviSynth version/date
        /// </summary>
        /// <returns></returns>
        public static string CheckAviSynth()
        {
            bool bFoundInstalledAviSynth = false;
            string fileVersion = string.Empty, fileDate = string.Empty, fileProductName = string.Empty;
            string syswow64path = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86);

            if (!Directory.Exists(syswow64path)
                           && GetFileInformation(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "avisynth.dll"), out fileVersion, out fileDate, out fileProductName))
                bFoundInstalledAviSynth = true;
            else if (GetFileInformation(Path.Combine(syswow64path, "avisynth.dll"), out fileVersion, out fileDate, out fileProductName))
                bFoundInstalledAviSynth = true;

            if (bFoundInstalledAviSynth)
                return "AviSynth" + (fileProductName.Contains("+") ? "+" : string.Empty) + "版本: " + fileVersion + " (" + fileDate + ")";
            else return string.Empty;
        }

        // 检查内置的avs版本
        public static string CheckinternalAviSynth()
        {
            bool bFoundInstalledAviSynth = false;
            string fileVersion = string.Empty, fileDate = string.Empty, fileProductName = string.Empty;

            if (GetFileInformation(Path.Combine(Application.StartupPath, @"tools\AviSynth.dll"), out fileVersion, out fileDate, out fileProductName))
                bFoundInstalledAviSynth = true;

            if (bFoundInstalledAviSynth)
                return "AviSynth" + (fileProductName.Contains("+") ? "+" : string.Empty) + "版本: " + fileVersion + " (" + fileDate + ")";
            else return string.Empty;
        }

        #region DialogFilter
        /// <summary>
        /// Consolidate the Filter settings for OpenFileDialog & SaveFileDialog
        /// </summary>
        /// <param name="type">DialogFilterTypes</param>
        /// <returns>string</returns>
        public static string GetDialogFilter(DialogFilterTypes type)
        {
            string filterString;
            //TODO: multi language support in the future
            string all = "所有文件";
            string avs = "AVS";
            string video = "视频";
            string audio = "音频";
            string image = "图片";
            string subtitle = "字幕";
            string program = "程序";
            string stream = "流";

            switch (type)
            {
                //all
                case DialogFilterTypes.ALL:
                    filterString = String.Format("{0}(*.*)|*.*;", all); break;

                //video
                case DialogFilterTypes.VIDEO_1:
                    filterString = String.Format("{0}(*.*)|*.*;", video); break;
                case DialogFilterTypes.VIDEO_2:
                    filterString = String.Format("{0}(*.mkv)|*.mkv;", video); break;
                case DialogFilterTypes.VIDEO_3:
                    filterString = String.Format("{0}(*.mp4)|*.mp4;", video); break;
                case DialogFilterTypes.VIDEO_4:
                    filterString = String.Format("{0}(*.flv;*.hlv)|*.flv;*.hlv;", video); break;
                case DialogFilterTypes.VIDEO_5:
                    filterString = String.Format("{0}(*.mp4)|*.mp4|{1}(*.*)|*.*;", video, all); break;
                case DialogFilterTypes.VIDEO_6:
                    filterString = String.Format("{0}(*.mp4;*.flv;*.mkv)|*.mp4;*.flv;*.mkv|{1}(*.*)|*.*;", video, all); break;
                case DialogFilterTypes.VIDEO_7:
                    filterString = String.Format("{0}(*.mp4;*.flv;*.mkv;*.wmv)|*.mp4;*.flv;*.mkv;*.wmv|{1}(*.*)|*.*;", video, all); break;
                case DialogFilterTypes.VIDEO_8:
                    filterString = String.Format("{0}(*.mp4;*.flv;*.mkv;*.avi;*.wmv;*.mpg;*.avs)|*.mp4;*.flv;*.mkv;*.avi;*.wmv;*.mpg;*.avs|{1}(*.*)|*.*;", video, all); break;
                case DialogFilterTypes.VIDEO_9:
                    filterString = String.Format("{0}(*.avi;*.mp4;*.m1v;*.m2v;*.m4v;*.264;*.h264;*.hevc)|*.avi;*.mp4;*.m1v;*.m2v;*.m4v;*.264;*.h264;*.hevc|{1}(*.*)|*.*;", video, all); break;

                //video with detailed description
                case DialogFilterTypes.VIDEO_D_1:
                    filterString = String.Format("FLV {0}(*.flv)|*.flv;", video); break;
                case DialogFilterTypes.VIDEO_D_2:
                    filterString = String.Format("MP4 {0}(*.mp4)|*.mp4|FLV {0}(*.flv)|*.flv;", video); break;
                case DialogFilterTypes.VIDEO_D_3:
                    filterString = String.Format("MPEG-4 {0}(*.mp4)|*.mp4|Flash {0}(*.flv)|*.flv|Matroska {0}(*.mkv)|*.mkv|AVI {0}(*.avi)|*.avi|H.264 {1}(*.raw)|*.raw;", video, stream); break;

                //audio
                case DialogFilterTypes.AUDIO_1:
                    filterString = String.Format("{0}(*.mp3)|*.mp3|{0}(*.aac)|*.aac|{1}(*.*)|*.*;", audio, all); break;
                case DialogFilterTypes.AUDIO_2:
                    filterString = String.Format("{0}(*.mp3;*.aac;*.ac3)|*.mp3;*.aac;*.ac3|{1}(*.*)|*.*;", audio, all); break;
                case DialogFilterTypes.AUDIO_3:
                    filterString = String.Format("{0}(*.aac;*.wav;*.m4a;*.flac)|*.aac;*.wav;*.m4a;*.flac;", audio); break;
                case DialogFilterTypes.AUDIO_4:
                    filterString = String.Format("{0}(*.aac;*.mp3;*.mp4;*.wav)|*.aac;*.mp3;*.mp4;*.wav|{1}(*.*)|*.*;", audio, all); break;
                case DialogFilterTypes.AUDIO_5:
                    filterString = String.Format("{0}(*.mp4;*.aac;*.mp2;*.mp3;*.m4a;*.ac3)|*.mp4;*.aac;*.mp2;*.mp3;*.m4a;*.ac3|{1}(*.*)|*.*;", audio, all); break;

                //others
                case DialogFilterTypes.AVS:
                    filterString = String.Format("{0}(*.avs)|*.avs;", avs); break;
                case DialogFilterTypes.PROGRAM:
                    filterString = String.Format("{0}(*.exe)|*.exe|{1}(*.*)|*.*;", program, all); break;
                case DialogFilterTypes.SUBTITLE_1:
                    filterString = String.Format("{0}(*.ass;*.ssa;*.srt)|*.ass;*.ssa;*.srt|{1}(*.*)|*.*;", subtitle, all); break;
                case DialogFilterTypes.SUBTITLE_2:
                    filterString = String.Format("{0}(*.ass;*.ssa;*.srt;*.idx;*.sup)|*.ass;*.ssa;*.srt;*.idx;*.sup|{1}(*.*)|*.*;", subtitle, all); break;
                case DialogFilterTypes.IMAGE:
                    filterString = String.Format("{0}(*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif|{1}(*.*)|*.*;", image, all); break;

                default:
                    filterString = String.Format("{0}(*.*)|*.*;", all); break;
            }
            return filterString;
        }

        public enum DialogFilterTypes
        {
            ALL,
            VIDEO_1, VIDEO_2, VIDEO_3, VIDEO_4, VIDEO_5, VIDEO_6, VIDEO_7, VIDEO_8, VIDEO_9,
            VIDEO_D_1, VIDEO_D_2, VIDEO_D_3,
            AUDIO_1, AUDIO_2, AUDIO_3, AUDIO_4, AUDIO_5,
            AVS,
            PROGRAM,
            SUBTITLE_1, SUBTITLE_2,
            IMAGE,
        }

        #endregion

        #region 程序集版本号

        public static DateTime GetAssemblyVersionTime()
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            return new DateTime(2000, 1, 1).AddDays(version.Build).AddSeconds(version.Revision * 2);
        }

        public static string GetAssemblyFileVersion()
        {
            return GetAssembly(typeof(System.Reflection.AssemblyInformationalVersionAttribute));
        }
        
        /// <summary>
        /// 获取程序集项目属性内容
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static string GetAssembly(Type type)
        {
            if (type.ToString() == "System.Reflection.AssemblyVersionAttribute")
            {//程序集版本号，要用这个方法获取，无法用下边的方法获取，原因不知
                return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
            object[] attributes = System.Reflection.Assembly.GetExecutingAssembly().GetCustomAttributes(type, false);
            if (attributes.Length > 0)
            {
                if (type.ToString() == "System.Reflection.AssemblyCompanyAttribute")
                {
                    #region//公司
                    System.Reflection.AssemblyCompanyAttribute company = (System.Reflection.AssemblyCompanyAttribute)attributes[0];
                    if (company.Company != "")
                    {
                        return company.Company;
                    }
                    #endregion
                }
                else if (type.ToString() == "System.Reflection.AssemblyCopyrightAttribute")
                {
                    #region//版权
                    System.Reflection.AssemblyCopyrightAttribute company = (System.Reflection.AssemblyCopyrightAttribute)attributes[0];
                    if (company.Copyright != "")
                    {
                        return company.Copyright;
                    }
                    #endregion
                }
                else if (type.ToString() == "System.Reflection.AssemblyTitleAttribute")
                {
                    #region//标题
                    System.Reflection.AssemblyTitleAttribute company = (System.Reflection.AssemblyTitleAttribute)attributes[0];
                    if (company.Title != "")
                    {
                        return company.Title;
                    }
                    #endregion
                }
                else if (type.ToString() == "System.Reflection.AssemblyDescriptionAttribute")
                {
                    #region//备注
                    System.Reflection.AssemblyDescriptionAttribute company = (System.Reflection.AssemblyDescriptionAttribute)attributes[0];
                    if (company.Description != "")
                    {
                        return company.Description;
                    }
                    #endregion
                }
                else if (type.ToString() == "System.Reflection.AssemblyProductAttribute")
                {
                    #region//产品名称
                    System.Reflection.AssemblyProductAttribute company = (System.Reflection.AssemblyProductAttribute)attributes[0];
                    if (company.Product != "")
                    {
                        return company.Product;
                    }
                    #endregion
                }
                else if (type.ToString() == "System.Reflection.AssemblyTrademarkAttribute")
                {
                    #region//商标
                    System.Reflection.AssemblyTrademarkAttribute company = (System.Reflection.AssemblyTrademarkAttribute)attributes[0];
                    if (company.Trademark != "")
                    {
                        return company.Trademark;
                    }
                    #endregion
                }
                else if (type.ToString() == "System.Reflection.AssemblyConfigurationAttribute")
                {
                    #region//获取程序集配置信息，具体什么内容，不清楚
                    System.Reflection.AssemblyConfigurationAttribute company = (System.Reflection.AssemblyConfigurationAttribute)attributes[0];
                    if (company.Configuration != "")
                    {
                        return company.Configuration;
                    }
                    #endregion
                }
                else if (type.ToString() == "System.Reflection.AssemblyCultureAttribute")
                {
                    #region//获取属性化程序集支持的区域性，具体什么内容，不清楚
                    System.Reflection.AssemblyCultureAttribute company = (System.Reflection.AssemblyCultureAttribute)attributes[0];
                    if (company.Culture != "")
                    {
                        return company.Culture;
                    }
                    #endregion
                }
                else if (type.ToString() == "System.Reflection.AssemblyVersionAttribute")
                {
                    #region//程序集版本号
                    System.Reflection.AssemblyVersionAttribute company = (System.Reflection.AssemblyVersionAttribute)attributes[0];
                    if (company.Version != "")
                    {
                        return company.Version;
                    }
                    #endregion
                }
                else if (type.ToString() == "System.Reflection.AssemblyFileVersionAttribute")
                {
                    #region//文件版本号
                    System.Reflection.AssemblyFileVersionAttribute company = (System.Reflection.AssemblyFileVersionAttribute)attributes[0];
                    if (company.Version != "")
                    {
                        return company.Version;
                    }
                    #endregion
                }
                else if (type.ToString() == "System.Reflection.AssemblyInformationalVersionAttribute")
                {
                    #region//产品版本号
                    System.Reflection.AssemblyInformationalVersionAttribute company = (System.Reflection.AssemblyInformationalVersionAttribute)attributes[0];
                    if (company.InformationalVersion != "")
                    {
                        return company.InformationalVersion;
                    }
                    #endregion
                }
            }
            //如果没有  属性，或者  属性为一个空字符串，则返回 .exe 的名称  
            return System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
        }

        #endregion

    }
}
