using MediaInfoLib;
using mp4box.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace mp4box.Procedure
{
    public class Shared
    {
        /// <summary>
        /// Generate the command to mux two input media file into one by using FFMpeg
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <param name="output"></param>
        /// <returns>FFMpeg command</returns>
        public static string FFMpegMuxCommand(string input1, string input2, string output)
        {
            return $"{ToolsUtil.FFMPEG.quotedPath} -i {input1.Quote()} -i {input2.Quote()} -sn -c copy -y {output.Quote()}";
        }

        /// <summary>
        /// Generate the command to mux two input media file into one by using MP4Box
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <param name="output"></param>
        /// <returns>MP4Box command</returns>
        public static string MP4MuxCommand(string input1, string input2, string output)
        {
            return $"{ToolsUtil.MP4BOX.quotedPath} -add \"{input1}#trackID=1:name=\" -add \"{input2}#trackID=1:name=\" -new {output.Quote()}";
        }

        public static string AudioBat(string input, string output, AudioMode audioMode, AudioEncoderType audioEncoder, string audioBitrate, string audioCustomParam)
        {
            string ffmpeg = ToolsUtil.FFMPEG.quotedPath + " -i " + input.Quote() + " -vn -sn -v 0 -c:a pcm_s16le -f wav pipe:|";
            switch (audioEncoder)
            {
                case AudioEncoderType.NeroAAC:
                    switch (audioMode)
                    {
                        case AudioMode.Bitrate:
                            string bitrate = (1000 * Convert.ToInt32(audioBitrate)).ToString();
                            ffmpeg += ToolsUtil.NEROAACENC.quotedPath + " -ignorelength -lc -br " + bitrate + " -if - -of " + output.Quote();
                            break;
                        case AudioMode.Custom:
                            ffmpeg += ToolsUtil.NEROAACENC.quotedPath + " -ignorelength " + audioCustomParam + " -if - -of " + output.Quote();
                            break;
                    }
                    break;

                case AudioEncoderType.QAAC:
                    switch (audioMode)
                    {
                        case AudioMode.Bitrate:
                            ffmpeg += ToolsUtil.QAAC.quotedPath + " -q 2 --ignorelength -c " + audioBitrate + " - -o " + output.Quote();
                            break;
                        case AudioMode.Custom:
                            ffmpeg += ToolsUtil.QAAC.quotedPath + " --ignorelength " + audioCustomParam + " - -o " + output.Quote();
                            break;
                    }
                    break;

                case AudioEncoderType.WAV:
                    if (Path.GetExtension(output) == ".aac")
                        output = Path.ChangeExtension(output, ".wav");
                    // overwrite the ffmpeg
                    ffmpeg = ToolsUtil.FFMPEG.quotedPath + " -y -i " + input.Quote() + " -f wav " + output.Quote();
                    break;

                case AudioEncoderType.ALAC:
                    ffmpeg += ToolsUtil.REFALAC.quotedPath + " --ignorelength - -o " + output.Quote();
                    break;

                case AudioEncoderType.FLAC:
                    ffmpeg += ToolsUtil.FLAC.quotedPath + " -f --ignore-chunk-sizes -5 - -o " + output.Quote();
                    break;

                case AudioEncoderType.FDKAAC:
                    switch (audioMode)
                    {
                        case AudioMode.Bitrate:
                            ffmpeg += ToolsUtil.FDKAAC.quotedPath + " --ignorelength -b " + audioBitrate + " - -o " + output.Quote();
                            break;
                        case AudioMode.Custom:
                            ffmpeg += ToolsUtil.FDKAAC.quotedPath + " --ignorelength " + audioCustomParam + " - -o " + output.Quote();
                            break;
                    }
                    break;

                case AudioEncoderType.AC3:
                    ffmpeg = ToolsUtil.FFMPEG.quotedPath + " -i " + input.Quote() + " -c:a ac3 -b:a " + audioBitrate + "k " + output.Quote();
                    break;

                case AudioEncoderType.MP3:
                    switch (audioMode)
                    {
                        case AudioMode.Bitrate:
                            ffmpeg += ToolsUtil.LAME.quotedPath + " -q 3 -b " + audioBitrate + " - " + output.Quote();
                            break;
                        case AudioMode.Custom:
                            ffmpeg += ToolsUtil.LAME.quotedPath + " " + audioCustomParam + " - " + output.Quote();
                            break;
                    }
                    break;

                default:
                    break;
            }
            return ffmpeg + "\r\n";
        }


        public static string ExtractAV(out string ext, string input, MediaType mediaType, int streamIndex = 0)
        {
            ext = Path.GetExtension(input);
            //aextract = "\"" + workPath + "\\mp4box.exe\" -raw 2 \"" + namevideo + "\"";
            string aextract = FileStringUtil.FormatPath(ToolsUtil.FFMPEG.fullPath);
            aextract += " -i " + FileStringUtil.FormatPath(input);

            switch (mediaType)
            {
                case MediaType.Audio:
                    aextract += " -vn -sn -c:a copy -y -map 0:a:" + streamIndex + " ";

                    MediaInfoWrapper MIW = new MediaInfoWrapper(input);
                    string audioFormat = MIW.a_format;
                    string audioProfile = MIW.a_formatProfile;
                    if (!string.IsNullOrEmpty(audioFormat))
                    {
                        if (audioFormat.Contains("MPEG") && audioProfile == "Layer 3")
                            ext = ".mp3";
                        else if (audioFormat.Contains("MPEG") && audioProfile == "Layer 2")
                            ext = ".mp2";
                        else if (audioFormat.Contains("PCM")) //flv support(PCM_U8 * PCM_S16BE * PCM_MULAW * PCM_ALAW * ADPCM_SWF)
                            ext = ".wav";
                        else if (audioFormat == "AAC")
                            ext = ".aac";
                        else if (audioFormat == "AC-3")
                            ext = ".ac3";
                        else if (audioFormat == "ALAC")
                            ext = ".m4a";
                        else
                            ext = ".mka";
                    }
                    else
                    {
                        //MessageBoxExt.ShowInfoMessage("该轨道无音频");
                        throw new Exception("该轨道无音频");
                    }
                    break;

                case MediaType.Video:
                    aextract += " -an -sn -c:v copy -y -map 0:v:" + streamIndex + " ";
                    break;

                default:
                    throw new InvalidEnumArgumentException();
            }

            return aextract;
        }

    }
}
