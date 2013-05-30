using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public class TestIplImage : TestCvArr
    {
        IplImage image;

        protected override CvArr CreateCvArr()
        {
            return image = new IplImage(new CvSize(Dim1, Dim0), IplDepth.F32, Channels);
        }
    }
}
