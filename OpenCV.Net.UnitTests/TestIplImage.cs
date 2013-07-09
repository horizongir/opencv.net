using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public class TestIplImage : TestCvArr
    {
        IplImage image;

        protected override CvArr CreateCvArr(int channels, CvDepth depth, int dim0, int dim1)
        {
            var iplDepth = IplDepth.F32;
            switch (depth)
            {
                case CvDepth.U8:
                    iplDepth = IplDepth.U8;
                    break;
                case CvDepth.S8:
                    iplDepth = IplDepth.S8;
                    break;
                case CvDepth.U16:
                    iplDepth = IplDepth.U16;
                    break;
                case CvDepth.S16:
                    iplDepth = IplDepth.S16;
                    break;
                case CvDepth.S32:
                    iplDepth = IplDepth.S32;
                    break;
                case CvDepth.F32:
                    iplDepth = IplDepth.F32;
                    break;
                case CvDepth.F64:
                    iplDepth = IplDepth.F64;
                    break;
                default:
                    break;
            }

            return image = new IplImage(new CvSize(dim1, dim0), iplDepth, channels);
        }

        [TestMethod]
        public void TestSample()
        {
            var buf = cv.SampleLine<float>(image, new CvPoint(0, 0), new CvPoint(Dim1 + 100, 1));
            Assert.AreEqual(Dim1, buf.Length);
        }
    }
}
