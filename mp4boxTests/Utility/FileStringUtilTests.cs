using Microsoft.VisualStudio.TestTools.UnitTesting;
using mp4box.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace mp4box.Utility.Tests
{
    [TestClass()]
    public class FileStringUtilTests
    {
        string temp = Path.GetTempPath();

        [TestMethod()]
        public void SpeculateSubtitlePathTest()
        {
            // subtitle file does not exist
            string videoFileName = Path.Combine(temp, "dummyVideo.mp5");
            var result = FileStringUtil.SpeculateSubtitlePath(videoFileName);
            Assert.AreEqual(result, string.Empty);
        }

        [TestMethod()]
        public void SpeculateSubtitlePathTest2()
        {
            // subtitle file exists without language
            string videoFileName = Path.Combine("dummyVideo.mp5");
            string subtitleFileName = Path.Combine("dummyVideo.srt");
            File.Create(subtitleFileName).Dispose();

            var result = FileStringUtil.SpeculateSubtitlePath(videoFileName);
            Assert.AreEqual(result, subtitleFileName);

            File.Delete(subtitleFileName);
        }

        [TestMethod()]
        public void SpeculateSubtitlePathTest3()
        {
            // subtitle file exists with language
            string videoFileName = Path.Combine("dummyVideo.mp5");
            string subtitleFileName = Path.Combine("dummyVideo.eng.srt");
            File.Create(subtitleFileName).Dispose();

            var result = FileStringUtil.SpeculateSubtitlePath(videoFileName, "eng");
            Assert.AreEqual(result, subtitleFileName);

            File.Delete(subtitleFileName);
        }
    }
}