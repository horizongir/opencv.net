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
            Assert.AreEqual(false, arr.IsInvalid);
        }

        [TestCleanup]
        public void CleanupCvArr()
        {
            arr.Close();
            Assert.AreEqual(true, arr.IsClosed);
        }

        [TestMethod]
        public void TestGetDims()
        {
            var dims = arr.GetDims();
            Assert.AreEqual(2, dims);
            var sizes = new int[dims];
            dims = arr.GetDims(sizes);
            Assert.AreEqual(2, dims);
            Assert.AreEqual(Dim0, sizes[0]);
            Assert.AreEqual(Dim1, sizes[1]);
        }

        [TestMethod]
        public void TestGetDimSize()
        {
            var dim0 = arr.GetDimSize(0);
            var dim1 = arr.GetDimSize(1);
            Assert.AreEqual(Dim0, dim0);
            Assert.AreEqual(Dim1, dim1);
        }

        [TestMethod]
        public void TestGet1D()
        {
            arr.SetZero();
            var scalar = arr.Get1D(0);
            Assert.AreEqual(0, scalar.Val0);
        }

        [TestMethod]
        public void TestGet2D()
        {
            arr.SetZero();
            var scalar = arr.Get2D(0, 0);
            Assert.AreEqual(0, scalar.Val0);
        }

        [TestMethod]
        [ExpectedException(typeof(CvException))]
        public void TestGet3D()
        {
            arr.SetZero();
            var scalar = arr.Get3D(0, 0, 0);
            Assert.AreEqual(0, scalar.Val0);
        }

        [TestMethod]
        public void TestGetND()
        {
            arr.SetZero();
            var scalar = arr.GetND(0, 0);
            Assert.AreEqual(0, scalar.Val0);
        }
    }
}
