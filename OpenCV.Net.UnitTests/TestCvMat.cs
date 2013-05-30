using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public class TestCvMat
    {
        const int Cols = 320;
        const int Rows = 240;
        const int Channels = 1;
        const CvMatDepth Depth = CvMatDepth.F32;

        CvMat mat;

        [TestInitialize]
        public void InitializeCvMat()
        {
            mat = new CvMat(Rows, Cols, Depth, Channels);
            Assert.AreEqual(mat.IsInvalid, false);
        }

        [TestCleanup]
        public void CleanupCvMat()
        {
            mat.Close();
            Assert.AreEqual(mat.IsClosed, true);
        }

        [TestMethod]
        public void TestCvMatRows()
        {
            Assert.AreEqual(mat.Rows, Rows);
        }

        [TestMethod]
        public void TestCvMatCols()
        {
            Assert.AreEqual(mat.Cols, Cols);
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
            Assert.AreEqual(mat.Step, mat.Cols * mat.ElementSize);
        }
    }
}
