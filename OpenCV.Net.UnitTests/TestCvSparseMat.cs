using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public class TestCvSparseMat : TestCvArr
    {
        CvSparseMat mat;

        protected override CvArr CreateCvArr()
        {
            return mat = new CvSparseMat(new[] { Dim0, Dim1 }, Depth, Channels);
        }

        [TestMethod]
        public void TestCvSparseMatIterator()
        {
            foreach (var node in mat.GetSparseNodes())
            {
                Assert.AreNotEqual(node, IntPtr.Zero);
            }
        }
    }
}
