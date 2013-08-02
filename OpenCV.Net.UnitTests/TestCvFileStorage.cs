using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public class TestCvFileStorage
    {
        [TestMethod]
        public void TestReadWrite()
        {
            using (var storage = new CvMemStorage())
            using (var fileStorage = new CvFileStorage("storage.txt", storage, StorageFlags.Write))
            {
                fileStorage.WriteInt("testnum", 5);
                fileStorage.WriteString("teststring", "hello");

                var mat = new CvMat(3, 3, CvDepth.F32, 1);
                mat.SetZero();
                mat[1, 1] = CvScalar.All(1);
                fileStorage.Write("testmat", mat);

                fileStorage.StartWriteStruct("testseq", StructStorageFlags.Seq);
                fileStorage.WriteRawData(new[] { 1, 2, 3, 4, 5 }, "i");
                fileStorage.EndWriteStruct();
            }

            using (var storage = new CvMemStorage())
            using (var fileStorage = new CvFileStorage("storage.txt", storage, StorageFlags.Read))
            {
                var node = fileStorage.GetRootFileNode();
                var num = fileStorage.ReadInt(node, "testnum");

                var hash = fileStorage.GetHashedKey("teststring");
                node = fileStorage.GetFileNode(node, hash);
                var str = fileStorage.ReadString(node);
                Console.WriteLine(num + str);

                node = fileStorage.GetRootFileNode();
                var mat = fileStorage.Read<CvMat>(node, "testmat");
                Console.WriteLine(cv.Sum(mat).Val0);

                var elems = new int[5];
                node = fileStorage.GetFileNode(node, "testseq");
                fileStorage.ReadRawData(node, elems, "i");
                Console.WriteLine(elems[2]);
            }
        }
    }
}
