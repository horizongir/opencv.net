using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public class TestMemStorage
    {
        [TestMethod]
        public void TestAllocString()
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
