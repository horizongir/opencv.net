using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public class MatTests : ArrTests
    {
        Mat mat;

        protected override Arr CreateArr(int channels, Depth depth, int dim0, int dim1)
        {
            return mat = new Mat(dim0, dim1, depth, channels);
        }

        [TestMethod]
        public void MatRows_ReturnsCorrectNumberOfRows()
        {
            Assert.AreEqual(mat.Rows, Dim0);
        }

        [TestMethod]
        public void MatCols_ReturnsCorrectNumberOfColumns()
        {
            Assert.AreEqual(mat.Cols, Dim1);
        }

        [TestMethod]
        public void MatDepth_ReturnsCorrectElementDepth()
        {
            Assert.AreEqual(mat.Depth, TestDepth);
        }

        [TestMethod]
        public void MatChannels_ReturnsCorrectNumberOfChannels()
        {
            Assert.AreEqual(mat.Channels, 1);
        }

        [TestMethod]
        public void MatStep_ReturnsCorrectRowStepInBytes()
        {
            Assert.AreEqual(mat.Step, mat.Cols * mat.ElementSize * mat.Channels);
        }
    }
}
