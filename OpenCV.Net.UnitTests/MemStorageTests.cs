using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public class MemStorageTests
    {
        [TestMethod]
        public void AllocString_ReturnsNonZeroPointer()
        {
            using (var storage = new MemStorage())
            {
                var testStr = "Test string";
                var ptr = storage.AllocString(testStr);
                Assert.AreNotEqual(IntPtr.Zero, ptr);
            }
        }
    }
}
