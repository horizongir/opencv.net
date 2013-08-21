using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public class TestCapture
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateFileCapture_NullPath_ThrowsArgumentNullException()
        {
            Capture.CreateFileCapture(null);
        }

        [TestMethod]
        public void CreateFileCapture_InvalidPath_ReturnsNull()
        {
            var capture = Capture.CreateFileCapture(string.Empty);
            Assert.AreEqual(null, capture);
        }
    }
}
