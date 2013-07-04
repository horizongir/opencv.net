using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.InteropServices;
using OpenCV.Net.Native;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public class TestCvSeq
    {
        [TestMethod]
        public void TestCreateSeq()
        {
            using (var storage = new CvMemStorage())
            {
                var seq = new CvSeq(CvDepth.F32, 1, SequenceKind.Curve, storage);
                Assert.AreEqual(false, seq.IsInvalid);
                Assert.AreEqual(SequenceKind.Curve, seq.Kind);
                Assert.AreEqual(sizeof(float), seq.ElementSize);
            }
        }

        [TestMethod]
        public void TestSort()
        {
            using (var storage = new CvMemStorage())
            using (var seq = new CvSeq(CvDepth.S32, 1, storage))
            {
                Comparison<int> cmp = (x, y) => x - y;
                seq.Push(1, 2, 3, 6, 3, 67, 37);
                seq.Sort(cmp);
                var idx = seq.Search(6, cmp, true);
                Console.WriteLine(idx);

                seq.Remove(2);

                CvSeq labels;
                var classes = seq.Partition<int>(null, out labels, (x, y) => (x - y) * (x - y) < 2);
                var arr = labels.ToArray<int>();
                Console.WriteLine(classes);
                Console.WriteLine(arr);
            }
        }
    }
}
