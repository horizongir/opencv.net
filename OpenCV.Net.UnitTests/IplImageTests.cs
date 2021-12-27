using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.InteropServices;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public class IplImageTests : ArrTests
    {
        IplImage image;

        protected override Arr CreateArr(int channels, Depth depth, int dim0, int dim1)
        {
            var iplDepth = IplDepth.F32;
            switch (depth)
            {
                case Depth.U8:
                    iplDepth = IplDepth.U8;
                    break;
                case Depth.S8:
                    iplDepth = IplDepth.S8;
                    break;
                case Depth.U16:
                    iplDepth = IplDepth.U16;
                    break;
                case Depth.S16:
                    iplDepth = IplDepth.S16;
                    break;
                case Depth.S32:
                    iplDepth = IplDepth.S32;
                    break;
                case Depth.F32:
                    iplDepth = IplDepth.F32;
                    break;
                case Depth.F64:
                    iplDepth = IplDepth.F64;
                    break;
                default:
                    break;
            }

            return image = new IplImage(new Size(dim1, dim0), iplDepth, channels);
        }

        [TestMethod]
        public void CreateIplImageHeader_ValidAccessToUnderlyingDataArray()
        {
            var data = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var dataHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
            using (var image = new IplImage(new Size(3, 3), IplDepth.S32, 1, dataHandle.AddrOfPinnedObject()))
            {
                Assert.AreEqual(data[7], image[2, 1].Val0);
            }
            dataHandle.Free();
        }

        [TestMethod]
        public void Clone_ReturnsCopyOfIplImage()
        {
            using (var image = new IplImage(new Size(3, 3), IplDepth.F32, 1))
            {
                image.SetZero();
                image[1, 1] = Scalar.All(3);
                Assert.AreEqual(3, image[1, 1].Val0);
                using (var clone = image.Clone())
                {
                    Assert.AreEqual(image.Size, clone.Size);
                    Assert.AreEqual(image[1, 1], clone[1, 1]);
                }
            }
        }

        [TestMethod]
        public void CopyImageWithChannelOfInterest_ResultMatContainsSelectedChannelValues()
        {
            using (var image = new IplImage(new Size(3, 3), IplDepth.F32, 3))
            {
                image.SetZero();
                image[1, 1] = new Scalar(0, 1, 0, 0);
                using (var mask = new IplImage(image.Size, image.Depth, 1))
                {
                    image.ChannelOfInterest = 2;
                    CV.Copy(image, mask);
                    image.ChannelOfInterest = 0;
                    Assert.AreEqual(image[1, 1].Val1, mask[1, 1].Val0);
                }
            }
        }

        #region Operator Tests

        const double EyeValue = 1.0;
        const double ScalarValue = 5.0;

        IplImage CreateEye(int size = 3, double value = EyeValue, IplDepth depth = IplDepth.F64)
        {
            var eye = new IplImage(new Size(size, size), depth, 1);
            CV.SetIdentity(eye, Scalar.All(value));
            return eye;
        }

        [TestMethod]
        public void op_Explicit_Mat_ReturnsEquivalentMatInstance()
        {
            var image = CreateEye();
            var mat = (Mat)image;
            Assert.AreEqual(image.Width, mat.Cols);
            Assert.AreEqual(image.Height, mat.Rows);
            Assert.AreEqual(CV.Sum(image), CV.Sum(mat));
        }

        [TestMethod]
        public void op_UnaryPlus_IplImage_ReturnsSameIplImage()
        {
            var image = CreateEye();
            Assert.AreSame(image, +image);
        }

        [TestMethod]
        public void op_UnaryNegation_IplImage_ReturnsNegatedIplImage()
        {
            var image = -CreateEye();
            Assert.AreEqual(-EyeValue, image.GetReal(0, 0));
        }

        [TestMethod]
        public void op_OnesComplement_IplImage_ReturnsInvertedIplImage()
        {
            var image = ~CreateEye(depth: IplDepth.S32);
            Assert.AreEqual(~(int)EyeValue, image.GetReal(0, 0));
        }

        [TestMethod]
        public void op_Addition_IplImageIplImage_ReturnsAdditionOfTwoIplImages()
        {
            var left = CreateEye();
            var right = CreateEye();
            Assert.AreEqual(EyeValue + EyeValue, (left + right).GetReal(0, 0));
        }

        [TestMethod]
        public void op_Addition_IplImageScalar_ReturnsAdditionOfIplImageAndScalar()
        {
            var image = CreateEye();
            var scalar = Scalar.All(ScalarValue);
            Assert.AreEqual(EyeValue + ScalarValue, (image + scalar).GetReal(0, 0));
        }

        [TestMethod]
        public void op_Addition_ScalarIplImage_ReturnsAdditionOfIplImageAndScalar()
        {
            var scalar = Scalar.All(ScalarValue);
            var image = CreateEye();
            Assert.AreEqual(EyeValue + ScalarValue, (scalar + image).GetReal(0, 0));
        }

        [TestMethod]
        public void op_Addition_IplImageDouble_ReturnsAdditionOfIplImageAndScalar()
        {
            var image = CreateEye();
            var scalar = ScalarValue;
            Assert.AreEqual(EyeValue + ScalarValue, (image + scalar).GetReal(0, 0));
        }

        [TestMethod]
        public void op_Addition_DoubleIplImage_ReturnsAdditionOfIplImageAndScalar()
        {
            var scalar = ScalarValue;
            var image = CreateEye();
            Assert.AreEqual(EyeValue + ScalarValue, (scalar + image).GetReal(0, 0));
        }

        [TestMethod]
        public void op_Subtraction_IplImageIplImage_ReturnsSubtractionOfTwoIplImages()
        {
            var left = CreateEye();
            var right = CreateEye();
            Assert.AreEqual(0, (left - right).GetReal(0, 0));
        }

        [TestMethod]
        public void op_Subtraction_IplImageScalar_ReturnsSubtractionOfIplImageAndScalar()
        {
            var image = CreateEye();
            var scalar = Scalar.All(ScalarValue);
            Assert.AreEqual(EyeValue - ScalarValue, (image - scalar).GetReal(0, 0));
        }

        [TestMethod]
        public void op_Subtraction_ScalarIplImage_ReturnsSubtractionOfIplImageAndScalar()
        {
            var scalar = Scalar.All(ScalarValue);
            var image = CreateEye();
            Assert.AreEqual(ScalarValue - EyeValue, (scalar - image).GetReal(0, 0));
        }

        [TestMethod]
        public void op_Subtraction_IplImageDouble_ReturnsSubtractionOfIplImageAndScalar()
        {
            var image = CreateEye();
            var scalar = ScalarValue;
            Assert.AreEqual(EyeValue - ScalarValue, (image - scalar).GetReal(0, 0));
        }

        [TestMethod]
        public void op_Subtraction_DoubleIplImage_ReturnsSubtractionOfIplImageAndScalar()
        {
            var scalar = ScalarValue;
            var image = CreateEye();
            Assert.AreEqual(ScalarValue - EyeValue, (scalar - image).GetReal(0, 0));
        }

        [TestMethod]
        public void op_Multiply_IplImageIplImage_ReturnsMultiplicationOfTwoIplImages()
        {
            var left = CreateEye(value: 2);
            var right = CreateEye(value: 2);
            Assert.AreEqual(4, (left * right).GetReal(0, 0));
        }

        [TestMethod]
        public void op_Multiply_IplImageDouble_ReturnsMultiplicationOfIplImageAndScalar()
        {
            var image = CreateEye();
            var scalar = ScalarValue;
            Assert.AreEqual(1 * ScalarValue, (image * scalar).GetReal(0, 0));
        }

        [TestMethod]
        public void op_Multiply_DoubleIplImage_ReturnsMultiplicationOfIplImageAndScalar()
        {
            var scalar = ScalarValue;
            var image = CreateEye();
            Assert.AreEqual(ScalarValue * 1, (scalar * image).GetReal(0, 0));
        }

        [TestMethod]
        public void op_Division_IplImageIplImage_ReturnsDivisionOfTwoIplImages()
        {
            var left = CreateEye(value: 1);
            var right = CreateEye(value: 2);
            Assert.AreEqual(0.5, (left / right).GetReal(0, 0));
        }

        [TestMethod]
        public void op_Division_IplImageDouble_ReturnsDivisionOfIplImageAndScalar()
        {
            var image = CreateEye();
            var scalar = ScalarValue;
            Assert.AreEqual(1 / ScalarValue, (image / scalar).GetReal(0, 0));
        }

        [TestMethod]
        public void op_Division_DoubleIplImage_ReturnsDivisionOfIplImageAndScalar()
        {
            var scalar = ScalarValue;
            var image = CreateEye();
            Assert.AreEqual(ScalarValue / 1, (scalar / image).GetReal(0, 0));
        }

        [TestMethod]
        public void op_ExclusiveOr_IplImageIplImage_ReturnsExclusiveOrOnTwoIplImages()
        {
            var left = CreateEye();
            var right = CreateEye();
            Assert.AreEqual(0, (left ^ right).GetReal(0, 0));
        }

        [TestMethod]
        public void op_ExclusiveOr_IplImageScalar_ReturnsExclusiveOrOnIplImageAndScalar()
        {
            var image = CreateEye(depth: IplDepth.S32);
            var scalar = Scalar.All(ScalarValue);
            Assert.AreEqual((int)EyeValue ^ (int)ScalarValue, (image ^ scalar).GetReal(0, 0));
        }

        [TestMethod]
        public void op_ExclusiveOr_ScalarIplImage_ReturnsExclusiveOrOnIplImageAndScalar()
        {
            var scalar = Scalar.All(ScalarValue);
            var image = CreateEye(depth: IplDepth.S32);
            Assert.AreEqual((int)EyeValue ^ (int)ScalarValue, (scalar ^ image).GetReal(0, 0));
        }

        [TestMethod]
        public void op_ExclusiveOr_IplImageDouble_ReturnsExclusiveOrOnIplImageAndScalar()
        {
            var image = CreateEye(depth: IplDepth.S32);
            var scalar = ScalarValue;
            Assert.AreEqual((int)EyeValue ^ (int)ScalarValue, (image ^ scalar).GetReal(0, 0));
        }

        [TestMethod]
        public void op_ExclusiveOr_DoubleIplImage_ReturnsExclusiveOrOnIplImageAndScalar()
        {
            var scalar = ScalarValue;
            var image = CreateEye(depth: IplDepth.S32);
            Assert.AreEqual((int)EyeValue ^ (int)ScalarValue, (scalar ^ image).GetReal(0, 0));
        }

        [TestMethod]
        public void op_BitwiseAnd_IplImageIplImage_ReturnsBitwiseConjunctionOfTwoIplImages()
        {
            var left = CreateEye();
            var right = CreateEye();
            Assert.AreEqual(1, (left & right).GetReal(0, 0));
        }

        [TestMethod]
        public void op_BitwiseAnd_IplImageScalar_ReturnsBitwiseConjunctionOfIplImageAndScalar()
        {
            var image = CreateEye(depth: IplDepth.S32);
            var scalar = Scalar.All(ScalarValue);
            Assert.AreEqual(EyeValue, (image & scalar).GetReal(0, 0));
        }

        [TestMethod]
        public void op_BitwiseAnd_ScalarIplImage_ReturnsBitwiseConjunctionOfIplImageAndScalar()
        {
            var scalar = Scalar.All(ScalarValue);
            var image = CreateEye(depth: IplDepth.S32);
            Assert.AreEqual(EyeValue, (scalar & image).GetReal(0, 0));
        }

        [TestMethod]
        public void op_BitwiseAnd_IplImageDouble_ReturnsBitwiseConjunctionOfIplImageAndScalar()
        {
            var image = CreateEye(depth: IplDepth.S32);
            var scalar = ScalarValue;
            Assert.AreEqual(EyeValue, (image & scalar).GetReal(0, 0));
        }

        [TestMethod]
        public void op_BitwiseAnd_DoubleIplImage_ReturnsBitwiseConjunctionOfIplImageAndScalar()
        {
            var scalar = ScalarValue;
            var image = CreateEye(depth: IplDepth.S32);
            Assert.AreEqual(EyeValue, (scalar & image).GetReal(0, 0));
        }

        [TestMethod]
        public void op_BitwiseOr_IplImageIplImage_ReturnsBitwiseDisjunctionOfTwoIplImages()
        {
            var left = CreateEye();
            var right = CreateEye();
            Assert.AreEqual(1, (left | right).GetReal(0, 0));
        }

        [TestMethod]
        public void op_BitwiseOr_IplImageScalar_ReturnsBitwiseDisjunctionOfIplImageAndScalar()
        {
            var image = CreateEye(depth: IplDepth.S32);
            var scalar = Scalar.All(ScalarValue);
            Assert.AreEqual(ScalarValue, (image | scalar).GetReal(0, 0));
        }

        [TestMethod]
        public void op_BitwiseOr_ScalarIplImage_ReturnsBitwiseDisjunctionOfIplImageAndScalar()
        {
            var scalar = Scalar.All(ScalarValue);
            var image = CreateEye(depth: IplDepth.S32);
            Assert.AreEqual(ScalarValue, (scalar | image).GetReal(0, 0));
        }

        [TestMethod]
        public void op_BitwiseOr_IplImageDouble_ReturnsBitwiseDisjunctionOfIplImageAndScalar()
        {
            var image = CreateEye(depth: IplDepth.S32);
            var scalar = ScalarValue;
            Assert.AreEqual(ScalarValue, (image | scalar).GetReal(0, 0));
        }

        [TestMethod]
        public void op_BitwiseOr_DoubleIplImage_ReturnsBitwiseDisjunctionOfIplImageAndScalar()
        {
            var scalar = ScalarValue;
            var image = CreateEye(depth: IplDepth.S32);
            Assert.AreEqual(ScalarValue, (scalar | image).GetReal(0, 0));
        }

        #endregion
    }
}
