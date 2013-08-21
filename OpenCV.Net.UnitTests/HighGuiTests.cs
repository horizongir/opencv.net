using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public class HighGuiTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadImage_NullPath_ThrowsArgumentNullException()
        {
            cv.LoadImage(null, LoadImageFlags.Unchanged);
        }

        [TestMethod]
        public void LoadImage_InvalidPath_ReturnsNull()
        {
            var image = cv.LoadImage(string.Empty, LoadImageFlags.Unchanged);
            Assert.AreEqual(null, image);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SaveImage_NullPath_ThrowsArgumentNullException()
        {
            var image = new IplImage(new Size(10, 10), IplDepth.U8, 1);
            cv.SaveImage(null, image);
        }

        [TestMethod]
        [ExpectedException(typeof(CVException))]
        public void SaveImage_InvalidPathWithInvalidExtension_ThrowsCVException()
        {
            var image = new IplImage(new Size(10, 10), IplDepth.U8, 1);
            cv.SaveImage(":://42.sd", image);
        }

        [TestMethod]
        public void SaveImage_InvalidPathWithValidExtension_ReturnsFalse()
        {
            var image = new IplImage(new Size(10, 10), IplDepth.U8, 1);
            var result = cv.SaveImage(":://.png", image);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EncodeImage_NullPath_ThrowsArgumentNullException()
        {
            var image = new IplImage(new Size(10, 10), IplDepth.U8, 1);
            cv.EncodeImage(null, image);
        }

        [TestMethod]
        public void EncodeImage_ReturnsSingleChannelMat()
        {
            var image = new IplImage(new Size(320, 240), IplDepth.U8, 3);
            image.SetZero();
            cv.Circle(image, new Point(100, 100), 50, Scalar.Rgb(255, 0, 0));
            var result = cv.EncodeImage(".jpg", image);
            Assert.AreEqual(1, result.Channels);
        }
    }
}
