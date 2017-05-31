using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mp4box.Utility.Tests
{
    [TestClass()]
    public class OtherTests
    {
        [TestMethod()]
        public void GetImageCoderInfoTest()
        {
            var result = Other.GetImageCoderInfo("image/jpeg");
            Assert.AreEqual("image/jpeg", result.MimeType);
        }

        [TestMethod()]
        public void GetImageCoderInfoTest2()
        {
            var result = Other.GetImageCoderInfo("image/doesNotExist");
            Assert.IsNull(result);
        }

        //////////

        [TestMethod()]
        public void TimeSubtractTest()
        {
            // normal
            string expResult = timeminus_old(0, 2, 30, 1, 1, 1);

            int[] begin = new int[] { 0, 2, 30 };
            int[] end = new int[] { 1, 1, 1 };
            string result = Other.TimeSubtract(begin, end);

            Assert.AreEqual(expResult, result);
        }

        [TestMethod()]
        public void TimeSubtractTest2()
        {
            // parse more than 24 hours
            string expResult = timeminus_old(0, 2, 30, 25, 1, 1);

            int[] begin = new int[] { 0, 2, 30 };
            int[] end = new int[] { 25, 1, 1 };
            string result = Other.TimeSubtract(begin, end);

            Assert.AreEqual(expResult, result);
        }

        [TestMethod()]
        public void TimeSubtractTest3()
        {
            // parse more than 24 hours
            // result more than 24 hours
            string expResult = timeminus_old(0, 2, 30, 50, 1, 1);

            int[] begin = new int[] { 0, 2, 30 };
            int[] end = new int[] { 50, 1, 1 };
            string result = Other.TimeSubtract(begin, end);

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