using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public class TestCvSparseMat : TestCvArr
    {
        CvSparseMat mat;

        protected override CvArr CreateCvArr(int channels, CvDepth depth, int dim0, int dim1)
        {
            return mat = new CvSparseMat(new[] { dim0, dim1 }, depth, channels);
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
