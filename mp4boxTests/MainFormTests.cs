using Microsoft.VisualStudio.TestTools.UnitTesting;
using mp4box.Procedure;
using mp4box.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mp4box.Tests
{
    [TestClass()]
    public class MainFormTests
    {
        [TestMethod()]
        public void ffmuxbatTest()
        {
            string input1 = "input1";
            string input2 = "input2";
            string output = "output";
            string resultBeforeRefactor = "\"" + ToolsUtil.FFMPEG.fullPath + "\" -i \"" + input1 + "\" -i \"" + input2 + "\" -sn -c copy -y \"" + output + "\"";
            string result = Shared.FFMpegMuxCommand(input1, input2, output);
            Assert.AreEqual(resultBeforeRefactor, result);
        }

        [TestMethod()]
        public void boxmuxbatTest()
        {
            string input1 = "input1";
            string input2 = "input2";
            string output = "output";
            string resultBeforeRefactor = "\"" + ToolsUtil.MP4BOX.fullPath + "\" -add \"" + input1 + "#trackID=1:name=\" -add \"" + input2 + "#trackID=1:name=\" -new \"" + output + "\"";
            string result = Shared.MP4MuxCommand(input1, input2, output);
            Assert.AreEqual(resultBeforeRefactor, result);
        }

    }
}