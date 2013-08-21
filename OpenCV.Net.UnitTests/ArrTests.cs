using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public abstract class ArrTests
    {
        protected const int Dim0 = 240;
        protected const int Dim1 = 320;
        protected const Depth TestDepth = Depth.F32;
        static readonly Scalar TestElement = new Scalar(4);

        Arr arr;

        protected abstract Arr CreateArr(int channels = 1, Depth depth = TestDepth, int dim0 = Dim0, int dim1 = Dim1);

        [TestInitialize]
        public void InitializeArr()
        {
            arr = CreateArr();
            Assert.AreEqual(false, arr.IsInvalid);
        }

        [TestCleanup]
        public void CleanupArr()
        {
            arr.Close();
            Assert.AreEqual(true, arr.IsClosed);
        }

        [TestMethod]
        public void GetElementType_ReturnsArrElementCode()
        {
            Assert.AreEqual(5, arr.ElementType);
        }

        [TestMethod]
        public void GetSize_ReturnsArrWidthAndHeight()
        {
            Assert.AreEqual(Dim0, arr.Size.Height);
            Assert.AreEqual(Dim1, arr.Size.Width);
        }

        [TestMethod]
        public void GetSubRect_ReturnsMatWithSubRectDimensions()
        {
            var rect = new Rect(0, 0, arr.Size.Width / 2, arr.Size.Height / 2);
            using (var subRect = arr.GetSubRect(rect))
            {
                Assert.AreEqual(rect.Height, subRect.Rows);
                Assert.AreEqual(rect.Width, subRect.Cols);
            }
        }

        [TestMethod]
        public void GetRow_ReturnsMatVectorWithArrWidthLength()
        {
            using (var row = arr.GetRow(0))
            {
                Assert.AreEqual(arr.Size.Width, row.Cols);
                Assert.AreEqual(1, row.Rows);
            }
        }

        [TestMethod]
        public void GetRows_ReturnsMatWithHeightEqualToSelectedRowCount()
        {
            using (var rows = arr.GetRows(0, arr.Size.Height, 2))
            {
                Assert.AreEqual(arr.Size.Height / 2, rows.Rows);
                Assert.AreEqual(arr.Size.Width, rows.Cols);
            }
        }

        [TestMethod]
        public void GetCol_ReturnsMatVectorWithArrHeightLength()
        {
            using (var col = arr.GetCol(0))
            {
                Assert.AreEqual(1, col.Cols);
                Assert.AreEqual(arr.Size.Height, col.Rows);
            }
        }

        [TestMethod]
        public void GetCols_ReturnsMatWithWidthEqualToSelectedRowCount()
        {
            using (var cols = arr.GetCols(0, arr.Size.Width / 2))
            {
                Assert.AreEqual(arr.Size.Height, cols.Rows);
                Assert.AreEqual(arr.Size.Width / 2, cols.Cols);
            }
        }

        [TestMethod]
        public void GetDiag_ReturnsMatWithArrHeight()
        {
            using (var diag = arr.GetCol(0))
            {
                Assert.AreEqual(1, diag.Cols);
                Assert.AreEqual(arr.Size.Height, diag.Rows);
            }
        }

        [TestMethod]
        public void GetDims_ReturnsCorrectNumberAndSizeOfArrDimensions()
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
        public void GetDimSize_ReturnsCorrectArrDimensionSizes()
        {
            var dim0 = arr.GetDimSize(0);
            var dim1 = arr.GetDimSize(1);
            Assert.AreEqual(Dim0, dim0);
            Assert.AreEqual(Dim1, dim1);
        }

        [TestMethod]
        public void Ptr1D_ReturnsNonZeroPointer()
        {
            var ptr = arr.Ptr(0);
            Assert.AreNotEqual(IntPtr.Zero, ptr);
        }

        [TestMethod]
        public void Ptr2D_ReturnsNonZeroPointer()
        {
            var ptr = arr.Ptr(0, 0);
            Assert.AreNotEqual(IntPtr.Zero, ptr);
        }

        [TestMethod]
        [ExpectedException(typeof(CVException))]
        public void Ptr3D_ReturnsNonZeroPointer()
        {
            var ptr = arr.Ptr(0, 0, 0);
            Assert.AreNotEqual(IntPtr.Zero, ptr);
        }

        [TestMethod]
        public void PtrND_ReturnsNonZeroPointer()
        {
            var ptr = arr.Ptr(new[] { 0, 0 });
            Assert.AreNotEqual(IntPtr.Zero, ptr);
        }

        [TestMethod]
        public void Get1D_ReturnsCorrectElementValue()
        {
            arr[0] = TestElement;
            var scalar = arr[0];
            Assert.AreEqual(TestElement, scalar);
        }

        [TestMethod]
        public void Get2D_ReturnsCorrectElementValue()
        {
            arr[1, 1] = TestElement;
            var scalar = arr[1, 1];
            Assert.AreEqual(TestElement, scalar);
        }

        [TestMethod]
        [ExpectedException(typeof(CVException))]
        public void Get3D_ReturnsCorrectElementValue()
        {
            arr[2, 2, 2] = TestElement;
            var scalar = arr[2, 2, 2];
            Assert.AreEqual(TestElement, scalar);
        }

        [TestMethod]
        public void GetND_ReturnsCorrectElementValue()
        {
            arr[new[] { 3, 3 }] = TestElement;
            var scalar = arr[new[] { 3, 3 }];
            Assert.AreEqual(TestElement, scalar);
        }

        [TestMethod]
        public void GetReal1D_ReturnsCorrectElementValue()
        {
            arr.SetZero();
            var real = arr.GetReal(0);
            Assert.AreEqual(0, real);
        }

        [TestMethod]
        public void GetReal2D_ReturnsCorrectElementValue()
        {
            arr.SetZero();
            var real = arr.GetReal(0, 0);
            Assert.AreEqual(0, real);
        }

        [TestMethod]
        [ExpectedException(typeof(CVException))]
        public void GetReal3D_ReturnsCorrectElementValue()
        {
            arr.SetZero();
            var real = arr.GetReal(0, 0, 0);
            Assert.AreEqual(0, real);
        }

        [TestMethod]
        public void GetRealND_ReturnsCorrectElementValue()
        {
            arr.SetZero();
            var real = arr.GetReal(new[] { 0, 0 });
            Assert.AreEqual(0, real);
        }

        [TestMethod]
        public void ClearND_ReturnsCorrectElementValue()
        {
            arr[0] = TestElement;
            arr.ClearND(new[] { 0, 0 });
            var real = arr.GetReal(new[] { 0, 0 });
            Assert.AreEqual(0, real);
        }

        [TestMethod]
        public void GetMat_ReturnsMatWrapperTo2DDenseArr()
        {
            var mat = arr.GetMat(true);
            Assert.AreEqual(Dim0, mat.Rows);
        }

        [TestMethod]
        public void GetImage_ReturnsIplImageWrapperTo2DDenseArr()
        {
            var image = arr.GetImage();
            Assert.AreEqual(Dim0, image.Height);
        }

        [TestMethod]
        public void Reshape_ReturnsReshapedMatFor2DDenseArr()
        {
            var mat = arr.Reshape(2);
            Assert.AreEqual(Dim1 / 2, mat.Cols);
        }

        [TestMethod]
        public void GetRawData_ReturnsNonZeroPointer()
        {
            IntPtr data;
            int step;
            Size roiSize;
            arr.GetRawData(out data, out step, out roiSize);
            Assert.AreNotEqual(IntPtr.Zero, data);
            Assert.AreEqual(Dim0, roiSize.Height);
        }

        [TestMethod]
        public void Set_ArrElementsHaveTargetValue()
        {
            arr.Set(TestElement);
            var real = arr.GetReal(new[] { 0, 0 });
            Assert.AreEqual(TestElement.Val0, real);
        }

        [TestMethod]
        public void CheckRange_ValidRangeElements_ReturnsTrue()
        {
            arr.Set(TestElement);
            Assert.AreEqual(true, arr.CheckRange(CheckArrayFlags.CheckRange, TestElement.Val0, TestElement.Val0 + 1));
        }

        [TestMethod]
        public void Repeat_DestinationArrIsTiledWithSourceArr()
        {
            arr.SetZero();
            arr[0, 0] = Scalar.All(1);
            using (var arr2 = CreateArr(1, TestDepth, Dim0 * 2, Dim1 * 2))
            {
                cv.Repeat(arr, arr2);
                Assert.AreEqual(1, arr2[0, 0].Val0);
                Assert.AreEqual(0, arr2[1, 0].Val0);
                Assert.AreEqual(1, arr2[Dim0, 0].Val0);
            }
        }

        [TestMethod]
        public void Copy_DestinationArrElementsEqualSourceArrElements()
        {
            const int Number = 5;
            using (var arr2 = CreateArr())
            {
                arr2.SetZero();
                Assert.AreNotEqual(Number, arr2[Number, Number].Val0);
                arr[Number, Number] = Scalar.Real(Number);
                cv.Copy(arr, arr2);
                Assert.AreEqual(Number, arr2[Number, Number].Val0);
            }
        }

        [TestMethod]
        public void Split_DestinationArrPlaneHasCorrectChannelValues()
        {
            arr.SetZero();
            using (var arr2 = CreateArr(3))
            {
                arr2[0, 0] = new Scalar(1, 2, 3, 4);
                cv.Split(arr2, null, arr, null, null);
                Assert.AreEqual(2, arr[0, 0].Val0);
            }
        }

        [TestMethod]
        public void Merge_DestinationArrHasCorrectChannelValues()
        {
            arr[0, 0] = Scalar.Real(2);
            using (var arr2 = CreateArr(3))
            {
                cv.Merge(null, arr, null, null, arr2);
                Assert.AreEqual(2, arr2[0, 0].Val1);
            }
        }

        [TestMethod]
        public void MixChannels_TargetArrHasRemappedChannelValues()
        {
            arr.SetZero();
            using (var arrRgba = CreateArr(4))
            using (var arrBgr = CreateArr(3))
            {
                arrRgba.Set(new Scalar(1, 2, 3, 4));
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
        public void ConvertScale_DestinationArrHasCorrectlyScaledElements()
        {
            arr.Set(Scalar.All(1));
            using (var arr2 = CreateArr(1))
            {
                cv.ConvertScale(arr, arr2, 5, 1);
                Assert.AreEqual(6, arr2[0, 0].Val0);
            }
        }

        [TestMethod]
        public void ConvertScaleAbs_DestinationArrHasCorrectlyScaledElements()
        {
            arr.Set(Scalar.All(1));
            using (var arr2 = CreateArr(1, Depth.U8))
            {
                cv.ConvertScaleAbs(arr, arr2, 5, 1);
                Assert.AreEqual(6, arr2[0, 0].Val0);
            }
        }

        [TestMethod]
        public void SampleLine_ReturnsBufferWithLineElementCountLength()
        {
            var buf = cv.SampleLine<float>(arr, new Point(0, 0), new Point(Dim1 + 100, 1));
            Assert.AreEqual(Dim1, buf.Length);
        }
    }
}
