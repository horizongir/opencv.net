using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public class TestCore
    {
        [TestMethod]
        public void TestAlloc()
        {
            var size = new UIntPtr(1024);
            var ptr = cv.Alloc(size);
            Assert.AreNotEqual(ptr, IntPtr.Zero);
        }

        [TestMethod]
        public void TestFree()
        {
            var size = new UIntPtr(1024);
            var ptr = cv.Alloc(size);
            Assert.AreNotEqual(ptr, IntPtr.Zero);
            cv.Free(ref ptr);
            Assert.AreEqual(ptr, IntPtr.Zero);
        }
    }
}
