using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public class TestCvMat : TestCvArr
    {
        CvMat mat;

        protected override CvArr CreateCvArr(int channels, CvDepth depth, int dim0, int dim1)
        {
            return mat = new CvMat(dim0, dim1, depth, channels);
        }

        [TestMethod]
        public void TestCvMatRows()
        {
            Assert.AreEqual(mat.Rows, Dim0);
        }

        [TestMethod]
        public void TestCvMatCols()
        {
            Assert.AreEqual(mat.Cols, Dim1);
        }

        [TestMethod]
        public void TestCvMatDepth()
        {
            Assert.AreEqual(mat.Depth, Depth);
        }

        [TestMethod]
        public void TestCvMatChannels()
        {
            Assert.AreEqual(mat.Channels, 1);
        }

        [TestMethod]
        public void TestCvMatStep()
        {
            Assert.AreEqual(mat.Step, mat.Cols * mat.ElementSize * mat.Channels);
        }
    }
}
