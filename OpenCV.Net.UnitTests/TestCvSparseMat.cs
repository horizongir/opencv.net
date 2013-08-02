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
            using (var mat = new CvSparseMat(new[] { 3, 3 }, CvDepth.F32, 2))
            {
                var testValue = new CvScalar(3, 5);
                mat[1, 1] = testValue;
                foreach (var node in mat.GetSparseNodes())
                {
                    Assert.AreEqual(testValue, node.Value);
                }
            }
        }
    }
}
