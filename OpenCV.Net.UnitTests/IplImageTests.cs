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
    }
}
