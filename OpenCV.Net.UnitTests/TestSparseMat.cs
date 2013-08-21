using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public class TestSparseMat : TestArr
    {
        SparseMat mat;

        protected override Arr CreateArr(int channels, Depth depth, int dim0, int dim1)
        {
            return mat = new SparseMat(new[] { dim0, dim1 }, depth, channels);
        }

        [TestMethod]
        public void SparseMatIterator_CorrectlyEnumeratesSparseElementNodes()
        {
            using (var mat = new SparseMat(new[] { 3, 3 }, Depth.F32, 2))
            {
                var testValue = new Scalar(3, 5);
                mat[1, 1] = testValue;
                foreach (var node in mat.GetSparseNodes())
                {
                    Assert.AreEqual(testValue, node.Value);
                }
            }
        }
    }
}
