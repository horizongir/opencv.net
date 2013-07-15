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
            var image = new IplImage(new CvSize(320, 240), IplDepth.U8, 3);
            image.SetZero();
            cv.Circle(image, new CvPoint(100, 100), 50, CvScalar.Rgb(255, 0, 0));
            var result = cv.EncodeImage(".jpg", image);
            Assert.AreEqual(1, result.Channels);
        }
    }
}
