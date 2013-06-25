using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public class TestIplImage : TestCvArr
    {
        IplImage image;

        protected override CvArr CreateCvArr(int channels, CvMatDepth depth, int dim0, int dim1)
        {
            var iplDepth = IplDepth.F32;
            switch (depth)
            {
                case CvMatDepth.U8:
                    iplDepth = IplDepth.U8;
                    break;
                case CvMatDepth.S8:
                    iplDepth = IplDepth.S8;
                    break;
                case CvMatDepth.U16:
                    iplDepth = IplDepth.U16;
                    break;
                case CvMatDepth.S16:
                    iplDepth = IplDepth.S16;
                    break;
                case CvMatDepth.S32:
                    iplDepth = IplDepth.S32;
                    break;
                case CvMatDepth.F32:
                    iplDepth = IplDepth.F32;
                    break;
                case CvMatDepth.F64:
                    iplDepth = IplDepth.F64;
                    break;
                default:
                    break;
            }

            return image = new IplImage(new CvSize(dim1, dim0), iplDepth, channels);
        }
    }
}
