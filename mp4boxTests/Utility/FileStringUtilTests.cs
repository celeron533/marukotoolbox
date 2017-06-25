using Microsoft.VisualStudio.TestTools.UnitTesting;
using mp4box.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mp4box.Utility.Tests
{
    [TestClass()]
    public class FileStringUtilTests
    {
        [TestMethod()]
        public void SpeculateSubtitlePathTest()
        {
            // subtitle file does not exist
            string videoFileName = "dummyVideo.mp5";
            var result = FileStringUtil.SpeculateSubtitlePath(videoFileName);
            Assert.AreEqual(result, string.Empty);
        }

        [TestMethod()]
        public void SpeculateSubtitlePathTest2()
        {
            // subtitle file exists without language
            string videoFileName = "dummyVideo.mp5";
            string subtitleFileName = "dummyVideo.srt";
            System.IO.File.Create(subtitleFileName).Dispose();

            var result = FileStringUtil.SpeculateSubtitlePath(videoFileName);
            Assert.AreEqual(result, subtitleFileName);

            System.IO.File.Delete(subtitleFileName);
        }

        [TestMethod()]
        public void SpeculateSubtitlePathTest3()
        {
            // subtitle file exists with language
            string videoFileName = "dummyVideo.mp5";
            string subtitleFileName = "dummyVideo.eng.srt";
            System.IO.File.Create(subtitleFileName).Dispose();

            var result = FileStringUtil.SpeculateSubtitlePath(videoFileName,"eng");
            Assert.AreEqual(result, subtitleFileName);

            System.IO.File.Delete(subtitleFileName);
        }
    }
}