﻿// ------------------------------------------------------------------
// Copyright (C) 2011-2017 Maruko Toolbox Project
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

namespace mp4box.Utility
{
    /// <summary>
    /// File, folder and file name related operations.
    /// </summary>
    public static class FileStringUtil
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

        ///// <summary>
        ///// 防止文件或目录重名
        ///// </summary>
        ///// <param name="oriPath_">原路径</param>
        ///// <returns>不会重名的路径</returns>
        //public static string GetSuitablePath(string oriPath_)
        //{
        //    if (string.IsNullOrEmpty(oriPath_)) { return null; }
        //    string oriPath = oriPath_.Replace("\"", string.Empty);//去掉引号

        //    if ((!File.Exists(oriPath)) && (!Directory.Exists(oriPath)))
        //    {
        //        return oriPath;
        //    }
        //    int i = 0;
        //    string ext = Path.GetExtension(oriPath);
        //    string str = oriPath.Remove(oriPath.Length - ext.Length) + "_" + i;
        //    while (File.Exists(str + ext) || Directory.Exists(str + ext))
        //    {
        //        i++;
        //        str = oriPath + "_" + i;
        //    }

        //    return str + ext;
        //}

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
        public static string GetSimilarFilePath(string DestDirOrFile_, string SrcFile_, string dotExtension = null)
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
                    return Path.ChangeExtension(DestDirOrFile, dotExtension);//换扩展名
                }
            }
        }

        public static void DeleteDirectoryIfExists(string path, bool recursive)
        {
            if (Directory.Exists(path))
                Directory.Delete(path, recursive);
        }

        /// <summary>
        /// 确保目录存在
        /// </summary>
        /// <param name="path">目录路径</param>
        /// <returns></returns>
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

        /// <summary>
        /// 检查目录是否可写入
        /// </summary>
        /// <param name="strPath">需要检查的路径</param>
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


        public static string GetLibassFormatPath(string path)
        {
            return path.Replace("\\", "\\\\\\\\").Replace(":", "\\\\:").Replace("[", "\\[").Replace("]", "\\]");
        }

        public static string SpeculateSubtitlePath(string videoFilePath, string language="")
        {
            string[] subExt = { "ass", "ssa", "srt" };
            string intermediateName = Path.GetFileNameWithoutExtension(videoFilePath);

            if (!string.IsNullOrEmpty(language))
                intermediateName = "." + language;

            foreach (string ext in subExt)
            {
                string speculateSubtitleFile = intermediateName + "." + ext;
                if (File.Exists(speculateSubtitleFile))
                {
                    return speculateSubtitleFile;
                }
            }
            return string.Empty;
        }

    }
}
