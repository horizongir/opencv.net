using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public abstract class TestCvArr
    {
        protected const int Dim0 = 240;
        protected const int Dim1 = 320;
        protected const CvMatDepth Depth = CvMatDepth.F32;
        static readonly CvScalar TestElement = new CvScalar(4);

        CvArr arr;

        protected abstract CvArr CreateCvArr(int channels = 1, CvMatDepth depth = Depth, int dim0 = Dim0, int dim1 = Dim1);

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
        public void TestGetElementType()
        {
            Assert.AreEqual(5, arr.ElementType);
        }

        [TestMethod]
        public void TestGetSize()
        {
            Assert.AreEqual(Dim0, arr.Size.Height);
            Assert.AreEqual(Dim1, arr.Size.Width);
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
        public void TestReshape()
        {
            var mat = arr.Reshape(2);
            Assert.AreEqual(Dim1 / 2, mat.Cols);
        }

        [TestMethod]
        public void TestGetRawData()
        {
            IntPtr data;
            int step;
            CvSize roiSize;
            arr.GetRawData(out data, out step, out roiSize);
            Assert.AreNotEqual(IntPtr.Zero, data);
            Assert.AreEqual(Dim0, roiSize.Height);
        }

        [TestMethod]
        public void TestSet()
        {
            arr.Set(TestElement);
            var real = arr.GetReal(new[] { 0, 0 });
            Assert.AreEqual(TestElement.Val0, real);
        }

        [TestMethod]
        public void TestRepeat()
        {
            arr.SetZero();
            arr[0, 0] = CvScalar.All(1);
            using (var arr2 = CreateCvArr(1, Depth, Dim0 * 2, Dim1 * 2))
            {
                cv.Repeat(arr, arr2);
                Assert.AreEqual(1, arr2[0, 0].Val0);
                Assert.AreEqual(0, arr2[1, 0].Val0);
                Assert.AreEqual(1, arr2[Dim0, 0].Val0);
            }
        }

        [TestMethod]
        public void TestCopy()
        {
            const int Number = 5;
            using (var arr2 = CreateCvArr())
            {
                arr2.SetZero();
                Assert.AreNotEqual(Number, arr2[Number, Number].Val0);
                arr[Number, Number] = CvScalar.Real(Number);
                cv.Copy(arr, arr2);
                Assert.AreEqual(Number, arr2[Number, Number].Val0);
            }
        }

        [TestMethod]
        public void TestSplit()
        {
            arr.SetZero();
            using (var arr2 = CreateCvArr(3))
            {
                arr2[0, 0] = new CvScalar(1, 2, 3, 4);
                cv.Split(arr2, null, arr, null, null);
                Assert.AreEqual(2, arr[0, 0].Val0);
            }
        }

        [TestMethod]
        public void TestMerge()
        {
            arr[0, 0] = CvScalar.Real(2);
            using (var arr2 = CreateCvArr(3))
            {
                cv.Merge(null, arr, null, null, arr2);
                Assert.AreEqual(2, arr2[0, 0].Val1);
            }
        }

        [TestMethod]
        public void TestMixChannels()
        {
            arr.SetZero();
            using (var arrRgba = CreateCvArr(4))
            using (var arrBgr = CreateCvArr(3))
            {
                arrRgba.Set(new CvScalar(1, 2, 3, 4));
                var dst = new[] { arrBgr, arr };
                var src = new[] { arrRgba };
                // RGBA to BGR + Alpha
                var fromTo = new[]
                {
                    0, 2,
                    1, 1,
                    2, 0,
                    3, 3
                };

                cv.MixChannels(src, dst, fromTo);
                Assert.AreEqual(4, arr[0,0].Val0);
            }
        }

        [TestMethod]
        public void TestConvertScale()
        {
            arr.Set(CvScalar.All(1));
            using (var arr2 = CreateCvArr(1))
            {
                cv.ConvertScale(arr, arr2, 5, 1);
                Assert.AreEqual(6, arr2[0, 0].Val0);
            }
        }

        [TestMethod]
        public void TestConvertScaleAbs()
        {
            arr.Set(CvScalar.All(1));
            using (var arr2 = CreateCvArr(1, CvMatDepth.U8))
            {
                cv.ConvertScaleAbs(arr, arr2, 5, 1);
                Assert.AreEqual(6, arr2[0, 0].Val0);
            }
        }
    }
}
