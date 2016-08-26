using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public class ImgProcTests
    {
        [TestMethod]
        public void BoxPoints_Test()
        {
            var rotatedRect = new RotatedRect(new Point2f(50,50), new Size2f(30,30), 45);
            Point2f[] points = new Point2f[4];
            CV.BoxPoints(rotatedRect, points);
            Assert.IsTrue(points[0].X != 0 && points[0].Y != 0);
            Assert.IsTrue(points[1].X != 0 && points[1].Y != 0);
            Assert.IsTrue(points[2].X != 0 && points[2].Y != 0);
            Assert.IsTrue(points[3].X != 0 && points[3].Y != 0);
        }
    }
}
