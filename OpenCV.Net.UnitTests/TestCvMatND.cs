using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public class TestCvMatND : TestCvArr
    {
        CvMatND mat;

        protected override CvArr CreateCvArr(int channels, CvMatDepth depth, int dim0, int dim1)
        {
            return mat = new CvMatND(new[] { dim0, dim1 }, depth, channels);
        }
    }
}
