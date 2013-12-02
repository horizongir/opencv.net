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

        #region Operator Tests

        const double EyeValue = 1.0;
        const double ScalarValue = 5.0;

        Mat CreateEye(int size = 3, double value = EyeValue, Depth depth = Depth.F64)
        {
            var eye = new Mat(size, size, depth, 1);
            CV.SetIdentity(eye, Scalar.All(value));
            return eye;
        }

        [TestMethod]
        public void op_Explicit_IplImage_ReturnsEquivalentMatInstance()
        {
            var mat = CreateEye();
            var image = (IplImage)mat;
            Assert.AreEqual(mat.Cols, image.Width);
            Assert.AreEqual(mat.Rows, image.Height);
            Assert.AreEqual(CV.Sum(mat), CV.Sum(image));
        }

        [TestMethod]
        public void op_UnaryPlus_Mat_ReturnsSameMat()
        {
            var mat = CreateEye();
            Assert.AreSame(mat, +mat);
        }

        [TestMethod]
        public void op_UnaryNegation_Mat_ReturnsNegatedMat()
        {
            var mat = -CreateEye();
            Assert.AreEqual(-EyeValue, mat.GetReal(0, 0));
        }

        [TestMethod]
        public void op_OnesComplement_Mat_ReturnsInvertedMat()
        {
            var mat = ~CreateEye(depth: Depth.S32);
            Assert.AreEqual(~(int)EyeValue, mat.GetReal(0, 0));
        }

        [TestMethod]
        public void op_Addition_MatMat_ReturnsAdditionOfTwoMats()
        {
            var left = CreateEye();
            var right = CreateEye();
            Assert.AreEqual(EyeValue + EyeValue, (left + right).GetReal(0, 0));
        }

        [TestMethod]
        public void op_Addition_MatScalar_ReturnsAdditionOfMatAndScalar()
        {
            var mat = CreateEye();
            var scalar = Scalar.All(ScalarValue);
            Assert.AreEqual(EyeValue + ScalarValue, (mat + scalar).GetReal(0, 0));
        }

        [TestMethod]
        public void op_Addition_ScalarMat_ReturnsAdditionOfMatAndScalar()
        {
            var scalar = Scalar.All(ScalarValue);
            var mat = CreateEye();
            Assert.AreEqual(EyeValue + ScalarValue, (scalar + mat).GetReal(0, 0));
        }

        [TestMethod]
        public void op_Addition_MatDouble_ReturnsAdditionOfMatAndScalar()
        {
            var mat = CreateEye();
            var scalar = ScalarValue;
            Assert.AreEqual(EyeValue + ScalarValue, (mat + scalar).GetReal(0, 0));
        }

        [TestMethod]
        public void op_Addition_DoubleMat_ReturnsAdditionOfMatAndScalar()
        {
            var scalar = ScalarValue;
            var mat = CreateEye();
            Assert.AreEqual(EyeValue + ScalarValue, (scalar + mat).GetReal(0, 0));
        }

        [TestMethod]
        public void op_Subtraction_MatMat_ReturnsSubtractionOfTwoMats()
        {
            var left = CreateEye();
            var right = CreateEye();
            Assert.AreEqual(0, (left - right).GetReal(0, 0));
        }

        [TestMethod]
        public void op_Subtraction_MatScalar_ReturnsSubtractionOfMatAndScalar()
        {
            var mat = CreateEye();
            var scalar = Scalar.All(ScalarValue);
            Assert.AreEqual(EyeValue - ScalarValue, (mat - scalar).GetReal(0, 0));
        }

        [TestMethod]
        public void op_Subtraction_ScalarMat_ReturnsSubtractionOfMatAndScalar()
        {
            var scalar = Scalar.All(ScalarValue);
            var mat = CreateEye();
            Assert.AreEqual(ScalarValue - EyeValue, (scalar - mat).GetReal(0, 0));
        }

        [TestMethod]
        public void op_Subtraction_MatDouble_ReturnsSubtractionOfMatAndScalar()
        {
            var mat = CreateEye();
            var scalar = ScalarValue;
            Assert.AreEqual(EyeValue - ScalarValue, (mat - scalar).GetReal(0, 0));
        }

        [TestMethod]
        public void op_Subtraction_DoubleMat_ReturnsSubtractionOfMatAndScalar()
        {
            var scalar = ScalarValue;
            var mat = CreateEye();
            Assert.AreEqual(ScalarValue - EyeValue, (scalar - mat).GetReal(0, 0));
        }

        [TestMethod]
        public void op_Multiply_MatMat_ReturnsMultiplicationOfTwoMats()
        {
            var left = CreateEye(value: 2);
            var right = CreateEye(value: 2);
            Assert.AreEqual(4, (left * right).GetReal(0, 0));
        }

        [TestMethod]
        public void op_Multiply_MatDouble_ReturnsMultiplicationOfMatAndScalar()
        {
            var mat = CreateEye();
            var scalar = ScalarValue;
            Assert.AreEqual(1 * ScalarValue, (mat * scalar).GetReal(0, 0));
        }

        [TestMethod]
        public void op_Multiply_DoubleMat_ReturnsMultiplicationOfMatAndScalar()
        {
            var scalar = ScalarValue;
            var mat = CreateEye();
            Assert.AreEqual(ScalarValue * 1, (scalar * mat).GetReal(0, 0));
        }

        [TestMethod]
        public void op_Division_MatMat_ReturnsDivisionOfTwoMats()
        {
            var left = CreateEye(value: 1);
            var right = CreateEye(value: 2);
            Assert.AreEqual(0.5, (left / right).GetReal(0, 0));
        }

        [TestMethod]
        public void op_Division_MatDouble_ReturnsDivisionOfMatAndScalar()
        {
            var mat = CreateEye();
            var scalar = ScalarValue;
            Assert.AreEqual(1 / ScalarValue, (mat / scalar).GetReal(0, 0));
        }

        [TestMethod]
        public void op_Division_DoubleMat_ReturnsDivisionOfMatAndScalar()
        {
            var scalar = ScalarValue;
            var mat = CreateEye();
            Assert.AreEqual(ScalarValue / 1, (scalar / mat).GetReal(0, 0));
        }

        [TestMethod]
        public void op_BitwiseAnd_MatMat_ReturnsBitwiseConjunctionOfTwoMats()
        {
            var left = CreateEye();
            var right = CreateEye();
            Assert.AreEqual(1, (left & right).GetReal(0, 0));
        }

        [TestMethod]
        public void op_BitwiseAnd_MatScalar_ReturnsBitwiseConjunctionOfMatAndScalar()
        {
            var mat = CreateEye(depth: Depth.S32);
            var scalar = Scalar.All(ScalarValue);
            Assert.AreEqual(EyeValue, (mat & scalar).GetReal(0, 0));
        }

        [TestMethod]
        public void op_BitwiseAnd_ScalarMat_ReturnsBitwiseConjunctionOfMatAndScalar()
        {
            var scalar = Scalar.All(ScalarValue);
            var mat = CreateEye(depth: Depth.S32);
            Assert.AreEqual(EyeValue, (scalar & mat).GetReal(0, 0));
        }

        [TestMethod]
        public void op_BitwiseAnd_MatDouble_ReturnsBitwiseConjunctionOfMatAndScalar()
        {
            var mat = CreateEye(depth: Depth.S32);
            var scalar = ScalarValue;
            Assert.AreEqual(EyeValue, (mat & scalar).GetReal(0, 0));
        }

        [TestMethod]
        public void op_BitwiseAnd_DoubleMat_ReturnsBitwiseConjunctionOfMatAndScalar()
        {
            var scalar = ScalarValue;
            var mat = CreateEye(depth: Depth.S32);
            Assert.AreEqual(EyeValue, (scalar & mat).GetReal(0, 0));
        }

        [TestMethod]
        public void op_BitwiseOr_MatMat_ReturnsBitwiseDisjunctionOfTwoMats()
        {
            var left = CreateEye();
            var right = CreateEye();
            Assert.AreEqual(1, (left | right).GetReal(0, 0));
        }

        [TestMethod]
        public void op_BitwiseOr_MatScalar_ReturnsBitwiseDisjunctionOfMatAndScalar()
        {
            var mat = CreateEye(depth: Depth.S32);
            var scalar = Scalar.All(ScalarValue);
            Assert.AreEqual(ScalarValue, (mat | scalar).GetReal(0, 0));
        }

        [TestMethod]
        public void op_BitwiseOr_ScalarMat_ReturnsBitwiseDisjunctionOfMatAndScalar()
        {
            var scalar = Scalar.All(ScalarValue);
            var mat = CreateEye(depth: Depth.S32);
            Assert.AreEqual(ScalarValue, (scalar | mat).GetReal(0, 0));
        }

        [TestMethod]
        public void op_BitwiseOr_MatDouble_ReturnsBitwiseDisjunctionOfMatAndScalar()
        {
            var mat = CreateEye(depth: Depth.S32);
            var scalar = ScalarValue;
            Assert.AreEqual(ScalarValue, (mat | scalar).GetReal(0, 0));
        }

        [TestMethod]
        public void op_BitwiseOr_DoubleMat_ReturnsBitwiseDisjunctionOfMatAndScalar()
        {
            var scalar = ScalarValue;
            var mat = CreateEye(depth: Depth.S32);
            Assert.AreEqual(ScalarValue, (scalar | mat).GetReal(0, 0));
        }

        #endregion
    }
}
