using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public class MatNDTests : ArrTests
    {
        MatND mat;

        protected override Arr CreateArr(int channels, Depth depth, int dim0, int dim1)
        {
            return mat = new MatND(new[] { dim0, dim1 }, depth, channels);
        }

        [TestMethod]
        [ExpectedException(typeof(CVException))]
        public override void Ptr3D_ReturnsNonZeroPointer()
        {
            base.Ptr3D_ReturnsNonZeroPointer();
        }

        [TestMethod]
        [ExpectedException(typeof(CVException))]
        public override void Get3D_ReturnsCorrectElementValue()
        {
            base.Get3D_ReturnsCorrectElementValue();
        }

        [TestMethod]
        [ExpectedException(typeof(CVException))]
        public override void GetReal3D_ReturnsCorrectElementValue()
        {
            base.GetReal3D_ReturnsCorrectElementValue();
        }

        [TestMethod]
        [ExpectedException(typeof(CVException))]
        public override void GetSize_ReturnsArrWidthAndHeight()
        {
            base.GetSize_ReturnsArrWidthAndHeight();
        }

        [TestMethod]
        [ExpectedException(typeof(CVException))]
        public override void GetSubRect_ReturnsMatWithSubRectDimensions()
        {
            base.GetSubRect_ReturnsMatWithSubRectDimensions();
        }

        [TestMethod]
        [ExpectedException(typeof(CVException))]
        public override void GetRow_ReturnsMatVectorWithArrWidthLength()
        {
            base.GetRow_ReturnsMatVectorWithArrWidthLength();
        }

        [TestMethod]
        [ExpectedException(typeof(CVException))]
        public override void GetRows_ReturnsMatWithHeightEqualToSelectedRowCount()
        {
            base.GetRows_ReturnsMatWithHeightEqualToSelectedRowCount();
        }

        [TestMethod]
        [ExpectedException(typeof(CVException))]
        public override void GetCol_ReturnsMatVectorWithArrHeightLength()
        {
            base.GetCol_ReturnsMatVectorWithArrHeightLength();
        }

        [TestMethod]
        [ExpectedException(typeof(CVException))]
        public override void GetCols_ReturnsMatWithWidthEqualToSelectedRowCount()
        {
            base.GetCols_ReturnsMatWithWidthEqualToSelectedRowCount();
        }

        [TestMethod]
        [ExpectedException(typeof(CVException))]
        public override void GetDiag_ReturnsMatWithArrHeight()
        {
            base.GetDiag_ReturnsMatWithArrHeight();
        }

        [TestMethod]
        [ExpectedException(typeof(CVException))]
        public override void GetImage_ReturnsIplImageWrapperTo2DDenseArr()
        {
            base.GetImage_ReturnsIplImageWrapperTo2DDenseArr();
        }

        [TestMethod]
        [ExpectedException(typeof(CVException))]
        public override void SampleLine_ReturnsBufferWithLineElementCountLength()
        {
            base.SampleLine_ReturnsBufferWithLineElementCountLength();
        }
    }
}
