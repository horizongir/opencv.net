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

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Save_NullPath_ThrowsArgumentNullException()
        {
            var mat = new Mat(10, 10, Depth.U8, 1);
            cv.Save(null, mat);
        }

        [TestMethod]
        [ExpectedException(typeof(CVException))]
        public void Save_InvalidPath_ThrowsCVException()
        {
            var mat = new Mat(10, 10, Depth.U8, 1);
            cv.Save(string.Empty, mat);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Load_NullPath_ThrowsArgumentNullException()
        {
            cv.Load<Mat>(null);
        }

        [TestMethod]
        [ExpectedException(typeof(CVException))]
        public void Load_InvalidPath_ThrowsCVException()
        {
            cv.Load<Mat>(string.Empty);
        }

        [TestMethod]
        public void SaveLoad_Mat_MatIsSerializedAndDeserializedSuccessfully()
        {
            var mat = Mat.FromArray(new byte[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } });
            cv.Save("storage.txt", mat);

            var loadmat = cv.Load<Mat>("storage.txt");
            Assert.AreEqual(mat.GetReal(1, 1), loadmat.GetReal(1, 1));
        }
    }
}
