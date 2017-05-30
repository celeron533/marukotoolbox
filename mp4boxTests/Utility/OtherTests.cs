using Microsoft.VisualStudio.TestTools.UnitTesting;
using mp4box.Utility;
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
    }
}