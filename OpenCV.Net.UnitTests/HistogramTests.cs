using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public class HistogramTests
    {
        Histogram hist;
        float[][] uniformRanges = new[] { new[] { 0f, 100f }, new[] { 20f, 30f } };

        Histogram CreateHistogram()
        {
            return new Histogram(2, new[] { 100, 50 }, HistogramType.Array, uniformRanges);
        }

        [TestInitialize]
        public void InitializeArr()
        {
            hist = CreateHistogram();
            Assert.IsFalse(hist.IsInvalid);
        }

        [TestCleanup]
        public void CleanupArr()
        {
            hist.Close();
            Assert.IsTrue(hist.IsClosed);
        }

        [TestMethod]
        public void GetType_DenseHistogram_ReturnsArrayEnumValue()
        {
            Assert.AreEqual(HistogramType.Array, hist.Type);
        }

        [TestMethod]
        public void GetType_SparseHistogram_ReturnsSparseEnumValue()
        {
            var sparseHist = new Histogram(2, new[] { 2, 3 }, HistogramType.Sparse);
            Assert.AreEqual(HistogramType.Sparse, sparseHist.Type);
        }

        [TestMethod]
        public void Copy_NullOutput_ReturnsValidHistogram()
        {
            Histogram copy;
            hist.Copy(out copy);
            Assert.IsFalse(copy.IsInvalid);
            Assert.AreEqual(hist.Bins.GetDims(), copy.Bins.GetDims());
        }

        [TestMethod]
        public void Copy_NonNullOutput_ReplacesHistogram()
        {
            Histogram copy;
            hist.Copy(out copy);
            Assert.IsFalse(copy.IsInvalid);
            Assert.AreEqual(hist.Bins.GetDims(), copy.Bins.GetDims());

            var previous = copy;
            hist.Copy(out copy);
            Assert.AreNotSame(previous, copy);
            Assert.IsFalse(copy.IsInvalid);
            Assert.AreEqual(hist.Bins.GetDims(), copy.Bins.GetDims());
        }

        [TestMethod]
        public void GetIsUniform_UniformHistogram_ReturnsTrue()
        {
            Assert.IsTrue(hist.IsUniform);
        }

        [TestMethod]
        public void GetBinRanges_UniformHistogram_ReturnsLowerAndUpperBound()
        {
            var bins = hist.Bins;
            var dims = bins.GetDims();
            var ranges = hist.GetBinRanges();
            Assert.IsTrue(hist.IsUniform);
            Assert.AreEqual(dims, ranges.Length);

            for (int i = 0; i < ranges.Length; i++)
            {
                Assert.AreEqual(2, ranges[i].Length);
            }

            for (int i = 0; i < ranges.Length; i++)
            {
                for (int j = 0; j < ranges[i].Length; j++)
                {
                    Assert.AreEqual(uniformRanges[i][j], ranges[i][j]);
                }
            }
        }

        [TestMethod]
        public void GetBinRanges_NonUniformHistogram_ReturnsBinEdges()
        {
            var nonUniformRanges = new[]
            {
                new[] { 0f, 3, 5, 7, 8, 10 },
                new[] { 10f, 50, 80, 90, 100, 110, 200 }
            };

            var hist = new Histogram(2, new[] { 4, 6 }, HistogramType.Array, nonUniformRanges, false);
            Assert.IsFalse(hist.IsInvalid);

            var ranges = hist.GetBinRanges();
            for (int i = 0; i < nonUniformRanges.Length; i++)
            {
                for (int j = 0; j < nonUniformRanges[i].Length; j++)
                {
                    Assert.AreEqual(nonUniformRanges[i][j], ranges[i][j]);
                }
            }
        }
    }
}
