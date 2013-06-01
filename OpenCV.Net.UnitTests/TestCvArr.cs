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
        static readonly CvScalar TestElement = new CvScalar(4);

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
        public void TestPtr1D()
        {
            var ptr = arr.Ptr(0);
            Assert.AreNotEqual(IntPtr.Zero, ptr);
        }

        [TestMethod]
        public void TestPtr2D()
        {
            var ptr = arr.Ptr(0, 0);
            Assert.AreNotEqual(IntPtr.Zero, ptr);
        }

        [TestMethod]
        [ExpectedException(typeof(CvException))]
        public void TestPtr3D()
        {
            var ptr = arr.Ptr(0, 0, 0);
            Assert.AreNotEqual(IntPtr.Zero, ptr);
        }

        [TestMethod]
        public void TestPtrND()
        {
            var ptr = arr.Ptr(new[] { 0, 0 });
            Assert.AreNotEqual(IntPtr.Zero, ptr);
        }

        [TestMethod]
        public void TestGet1D()
        {
            arr[0] = TestElement;
            var scalar = arr[0];
            Assert.AreEqual(TestElement, scalar);
        }

        [TestMethod]
        public void TestGet2D()
        {
            arr[1, 1] = TestElement;
            var scalar = arr[1, 1];
            Assert.AreEqual(TestElement, scalar);
        }

        [TestMethod]
        [ExpectedException(typeof(CvException))]
        public void TestGet3D()
        {
            arr[2, 2, 2] = TestElement;
            var scalar = arr[2, 2, 2];
            Assert.AreEqual(TestElement, scalar);
        }

        [TestMethod]
        public void TestGetND()
        {
            arr[new[] { 3, 3 }] = TestElement;
            var scalar = arr[new[] { 3, 3 }];
            Assert.AreEqual(TestElement, scalar);
        }

        [TestMethod]
        public void TestGetReal1D()
        {
            arr.SetZero();
            var real = arr.GetReal(0);
            Assert.AreEqual(0, real);
        }

        [TestMethod]
        public void TestGetReal2D()
        {
            arr.SetZero();
            var real = arr.GetReal(0, 0);
            Assert.AreEqual(0, real);
        }

        [TestMethod]
        [ExpectedException(typeof(CvException))]
        public void TestGetReal3D()
        {
            arr.SetZero();
            var real = arr.GetReal(0, 0, 0);
            Assert.AreEqual(0, real);
        }

        [TestMethod]
        public void TestGetRealND()
        {
            arr.SetZero();
            var real = arr.GetReal(new[] { 0, 0 });
            Assert.AreEqual(0, real);
        }

        [TestMethod]
        public void TestClearND()
        {
            arr[0] = TestElement;
            arr.ClearND(new[] { 0, 0 });
            var real = arr.GetReal(new[] { 0, 0 });
            Assert.AreEqual(0, real);
        }

        [TestMethod]
        public void TestGetMat()
        {
            var mat = arr.GetMat(true);
            Assert.AreEqual(Dim0, mat.Rows);
        }

        [TestMethod]
        public void TestSet()
        {
            arr.Set(TestElement);
            var real = arr.GetReal(new[] { 0, 0 });
            Assert.AreEqual(TestElement.Val0, real);
        }
    }
}
