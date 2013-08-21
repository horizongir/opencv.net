using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void AllocFree_NonZeroPointerIsSuccessfullyReleased()
        {
            var size = new UIntPtr(1024);
            var ptr = cv.Alloc(size);
            Assert.AreNotEqual(ptr, IntPtr.Zero);
            cv.Free(ref ptr);
            Assert.AreEqual(ptr, IntPtr.Zero);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PutText_NullText_ThrowsArgumentNullException()
        {
            var image = new IplImage(new Size(10, 10), IplDepth.U8, 1);
            cv.PutText(image, null, Point.Zero, new Font(1), Scalar.All(0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetTextSize_NullText_ThrowsArgumentNullException()
        {
            Size size;
            int baseline;
            cv.GetTextSize(null, new Font(1), out size, out baseline);
        }
    }
}
