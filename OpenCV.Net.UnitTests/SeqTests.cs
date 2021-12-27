using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.InteropServices;
using OpenCV.Net.Native;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public class SeqTests
    {
        [TestMethod]
        public void CreateSeq_ReturnsValidSeqInstance()
        {
            using (var storage = new MemStorage())
            {
                var seq = new Seq(Depth.F32, 1, SequenceKind.Curve, storage);
                Assert.AreEqual(false, seq.IsInvalid);
                Assert.AreEqual(SequenceKind.Curve, seq.Kind);
                Assert.AreEqual(sizeof(float), seq.ElementSize);
            }
        }

        [TestMethod]
        public void PushSortPartitionSearch_Success()
        {
            using (var storage = new MemStorage())
            using (var seq = new Seq(Depth.S32, 1, storage))
            {
                Comparison<int> cmp = (x, y) => x - y;
                seq.Push(1, 2, 3, 6, 3, 67, 37);
                seq.Sort(cmp);
                var idx = seq.Search(6, cmp, true);
                Console.WriteLine(idx);

                seq.Remove(2);

                Seq labels;
                var classes = seq.Partition<int>(null, out labels, (x, y) => (x - y) * (x - y) < 2);
                var arr = labels.ToArray<int>();
                Console.WriteLine(classes);
                Console.WriteLine(arr);
            }
        }
    }
}
