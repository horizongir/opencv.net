using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public class TestCvMatND : TestCvArr
    {
        CvMatND mat;

        protected override CvArr CreateCvArr()
        {
            return mat = new CvMatND(new[] { Dim0, Dim1 }, Depth, Channels);
        }
    }
}
