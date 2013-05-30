using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public abstract class TestCvArr
    {
        protected const int Dim0 = 240;
        protected const int Dim1 = 320;
        protected const int Channels = 1;
        protected const CvMatDepth Depth = CvMatDepth.F32;

        CvArr arr;

        protected abstract CvArr CreateCvArr();

        [TestInitialize]
        public void InitializeCvArr()
        {
            arr = CreateCvArr();
            Assert.AreEqual(arr.IsInvalid, false);
        }

        [TestCleanup]
        public void CleanupCvArr()
        {
            arr.Close();
            Assert.AreEqual(arr.IsClosed, true);
        }

        [TestMethod]
        public void TestGetDimSize()
        {
            var dim0 = arr.GetDimSize(0);
            var dim1 = arr.GetDimSize(1);
            Assert.AreEqual(Dim0, dim0);
            Assert.AreEqual(Dim1, dim1);
        }
    }
}
