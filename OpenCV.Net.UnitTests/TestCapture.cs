using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public class TestCapture
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestFileCaptureNullPath()
        {
            Capture.CreateFileCapture(null);
        }

        [TestMethod]
        public void TestFileCaptureInvalidPath()
        {
            var capture = Capture.CreateFileCapture(string.Empty);
            Assert.AreEqual(null, capture);
        }
    }
}
