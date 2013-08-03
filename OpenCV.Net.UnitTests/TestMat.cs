using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public class TestMat : TestArr
    {
        Mat mat;

        protected override Arr CreateArr(int channels, Depth depth, int dim0, int dim1)
        {
            return mat = new Mat(dim0, dim1, depth, channels);
        }

        [TestMethod]
        public void TestMatRows()
        {
            Assert.AreEqual(mat.Rows, Dim0);
        }

        [TestMethod]
        public void TestMatCols()
        {
            Assert.AreEqual(mat.Cols, Dim1);
        }

        [TestMethod]
        public void TestMatDepth()
        {
            Assert.AreEqual(mat.Depth, TestDepth);
        }

        [TestMethod]
        public void TestMatChannels()
        {
            Assert.AreEqual(mat.Channels, 1);
        }

        [TestMethod]
        public void TestMatStep()
        {
            Assert.AreEqual(mat.Step, mat.Cols * mat.ElementSize * mat.Channels);
        }
    }
}
