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
    }
}
