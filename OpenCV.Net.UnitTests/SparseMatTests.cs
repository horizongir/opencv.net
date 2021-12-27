using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public class SparseMatTests : ArrTests
    {
        SparseMat mat;

        protected override Arr CreateArr(int channels, Depth depth, int dim0, int dim1)
        {
            return mat = new SparseMat(new[] { dim0, dim1 }, depth, channels);
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
        public override void GetMat_ReturnsMatWrapperTo2DDenseArr()
        {
            base.GetMat_ReturnsMatWrapperTo2DDenseArr();
        }

        [TestMethod]
        [ExpectedException(typeof(CVException))]
        public override void GetImage_ReturnsIplImageWrapperTo2DDenseArr()
        {
            base.GetImage_ReturnsIplImageWrapperTo2DDenseArr();
        }

        [TestMethod]
        [ExpectedException(typeof(CVException))]
        public override void Reshape_ReturnsReshapedMatFor2DDenseArr()
        {
            base.Reshape_ReturnsReshapedMatFor2DDenseArr();
        }

        [TestMethod]
        [ExpectedException(typeof(CVException))]
        public override void GetRawData_ReturnsNonZeroPointer()
        {
            base.GetRawData_ReturnsNonZeroPointer();
        }

        [TestMethod]
        [ExpectedException(typeof(CVException))]
        public override void Set_ArrElementsHaveTargetValue()
        {
            base.Set_ArrElementsHaveTargetValue();
        }

        [TestMethod]
        [ExpectedException(typeof(CVException))]
        public override void CheckRange_ValidRangeElements_ReturnsTrue()
        {
            base.CheckRange_ValidRangeElements_ReturnsTrue();
        }

        [TestMethod]
        [ExpectedException(typeof(CVException))]
        public override void Repeat_DestinationArrIsTiledWithSourceArr()
        {
            base.Repeat_DestinationArrIsTiledWithSourceArr();
        }

        [TestMethod]
        [ExpectedException(typeof(CVException))]
        public override void Split_DestinationArrPlaneHasCorrectChannelValues()
        {
            base.Split_DestinationArrPlaneHasCorrectChannelValues();
        }

        [TestMethod]
        [ExpectedException(typeof(CVException))]
        public override void Merge_DestinationArrHasCorrectChannelValues()
        {
            base.Merge_DestinationArrHasCorrectChannelValues();
        }

        [TestMethod]
        [ExpectedException(typeof(CVException))]
        public override void MixChannels_TargetArrHasRemappedChannelValues()
        {
            base.MixChannels_TargetArrHasRemappedChannelValues();
        }

        [TestMethod]
        [ExpectedException(typeof(CVException))]
        public override void ConvertScale_DestinationArrHasCorrectlyScaledElements()
        {
            base.ConvertScale_DestinationArrHasCorrectlyScaledElements();
        }

        [TestMethod]
        [ExpectedException(typeof(CVException))]
        public override void ConvertScaleAbs_DestinationArrHasCorrectlyScaledElements()
        {
            base.ConvertScaleAbs_DestinationArrHasCorrectlyScaledElements();
        }

        [TestMethod]
        [ExpectedException(typeof(CVException))]
        public override void SampleLine_ReturnsBufferWithLineElementCountLength()
        {
            base.SampleLine_ReturnsBufferWithLineElementCountLength();
        }

        [TestMethod]
        [ExpectedException(typeof(CVException))]
        public override void Sort_DestinationArrHasSortedElements()
        {
            base.Sort_DestinationArrHasSortedElements();
        }

        [TestMethod]
        public void SparseMatIterator_CorrectlyEnumeratesSparseElementNodes()
        {
            using (var mat = new SparseMat(new[] { 3, 3 }, Depth.F32, 2))
            {
                var testValue = new Scalar(3, 5);
                mat[1, 1] = testValue;
                foreach (var node in mat.GetSparseNodes())
                {
                    Assert.AreEqual(testValue, node.Value);
                }
            }
        }
    }
}
