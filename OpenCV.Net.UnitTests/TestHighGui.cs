using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public class TestHighGui
    {
        [TestMethod]
        public void TestEncodeImage()
        {
            var image = new IplImage(new Size(320, 240), IplDepth.U8, 3);
            image.SetZero();
            cv.Circle(image, new Point(100, 100), 50, Scalar.Rgb(255, 0, 0));
            var result = cv.EncodeImage(".jpg", image);
            Assert.AreEqual(1, result.Channels);
        }
    }
}
