using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            MainForm mf = new MainForm();
            string input1 = "input1";
            string input2 = "input2";
            string output = "output";
            string resultBeforeRefactor = "\"" + ToolsUtil.FFMPEG.fullPath + "\" -i \"" + input1 + "\" -i \"" + input2 + "\" -sn -c copy -y \"" + output + "\"";
            string result = mf.FFMpegMuxCommand(input1, input2, output);
            Assert.AreEqual(resultBeforeRefactor, result);
        }

        [TestMethod()]
        public void boxmuxbatTest()
        {
            MainForm mf = new MainForm();

            string input1 = "input1";
            string input2 = "input2";
            string output = "output";
            string resultBeforeRefactor = "\"" + ToolsUtil.MP4BOX.fullPath + "\" -add \"" + input1 + "#trackID=1:name=\" -add \"" + input2 + "#trackID=1:name=\" -new \"" + output + "\"";
            string result = mf.MP4MuxCommand(input1, input2, output);
            Assert.AreEqual(resultBeforeRefactor, result);
        }

        [TestMethod()]
        public void processorCountTest()
        {
            Console.WriteLine($"You have {Environment.ProcessorCount} core(s).");
        }

    }
}