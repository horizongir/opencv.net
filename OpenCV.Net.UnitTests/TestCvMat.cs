using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public class TestCvMat : TestCvArr
    {
        CvMat mat;

        protected override CvArr CreateCvArr()
        {
            return mat = new CvMat(Dim0, Dim1, Depth, Channels);
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
            Assert.AreEqual(mat.NumChannels, Channels);
        }

        [TestMethod]
        public void TestCvMatStep()
        {
            Assert.AreEqual(mat.Step, mat.Cols * mat.ElementSize * mat.NumChannels);
        }
    }
}
