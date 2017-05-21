using Microsoft.VisualStudio.TestTools.UnitTesting;
using mp4box;
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
            string workPath = @"C:\";
            mf.workPath = workPath;
            string input1 = "input1";
            string input2 = "input2";
            string output = "output";
            string resultBeforeRefactor = "\"" + workPath + "\\ffmpeg.exe\" -i \"" + input1 + "\" -i \"" + input2 + "\" -sn -c copy -y \"" + output + "\"\r\n";
            string result = mf.ffmuxbat(input1, input2, output);
            Assert.AreEqual(resultBeforeRefactor, result);
        }

        [TestMethod()]
        public void boxmuxbatTest()
        {
            MainForm mf = new MainForm();
            string workPath = @"C:\";
            mf.workPath = workPath;
            string input1 = "input1";
            string input2 = "input2";
            string output = "output";
            string resultBeforeRefactor = "\"" + workPath + "\\mp4box.exe\" -add \"" + input1 + "#trackID=1:name=\" -add \"" + input2 + "#trackID=1:name=\" -new \"" + output + "\"\r\n";
            string result = mf.boxmuxbat(input1, input2, output);
            Assert.AreEqual(resultBeforeRefactor, result);
        }

        [TestMethod()]
        public void processorCountTest()
        {
            Console.WriteLine($"You have {Environment.ProcessorCount} core(s).");
        }

        [TestMethod()]
        public void timeminusTest()
        {
            // normal
            MainForm m = new MainForm();
            string expResult = timeminus_old(0, 2, 30, 1, 1, 1);

            int[] begin = new int[] { 0, 2, 30 };
            int[] end = new int[] { 1, 1, 1 };
            string result = m.timeSubtract(begin, end);

            Assert.AreEqual(expResult, result);
        }

        [TestMethod()]
        public void timeminusTest2()
        {
            // parse more than 24 hours
            MainForm m = new MainForm();
            string expResult = timeminus_old(0, 2, 30, 25, 1, 1);

            int[] begin = new int[] { 0, 2, 30 };
            int[] end = new int[] { 25, 1, 1 };
            string result = m.timeSubtract(begin, end);

            Assert.AreEqual(expResult, result);
        }

        [TestMethod()]
        public void timeminusTest3()
        {
            // parse more than 24 hours
            // result more than 24 hours
            MainForm m = new MainForm();
            string expResult = timeminus_old(0, 2, 30, 50, 1, 1);

            int[] begin = new int[] { 0, 2, 30 };
            int[] end = new int[] { 50, 1, 1 };
            string result = m.timeSubtract(begin, end);

            Assert.AreEqual(expResult, result);
        }

        // old logic of timemunis
        private string timeminus_old(int h1, int m1, int s1, int h2, int m2, int s2)
        {
            int h = 0;
            int m = 0;
            int s = 0;
            s = s2 - s1;
            if (s < 0)
            {
                m = -1;
                s = s + 60;
            }
            m = m + m2 - m1;
            if (m < 0)
            {
                h = -1;
                m = m + 60;
            }
            h = h + h2 - h1;
            return h.ToString() + ":" + m.ToString() + ":" + s.ToString();
        }


    }
}