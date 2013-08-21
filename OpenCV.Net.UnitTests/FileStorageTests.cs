using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public class FileStorageTests
    {
        [TestMethod]
        public void ReadAfterWrite_SerializationAndDeserializationSuccessful()
        {
            using (var storage = new MemStorage())
            using (var fileStorage = new FileStorage("storage.txt", storage, StorageFlags.Write))
            {
                fileStorage.WriteInt("testnum", 5);
                fileStorage.WriteString("teststring", "hello");

                var mat = new Mat(3, 3, Depth.F32, 1);
                mat.SetZero();
                mat[1, 1] = Scalar.All(1);
                fileStorage.Write("testmat", mat);

                fileStorage.StartWriteStruct("testseq", StructStorageFlags.Seq);
                fileStorage.WriteRawData(new[] { 1, 2, 3, 4, 5 }, "i");
                fileStorage.EndWriteStruct();
            }

            using (var storage = new MemStorage())
            using (var fileStorage = new FileStorage("storage.txt", storage, StorageFlags.Read))
            {
                var node = fileStorage.GetRootFileNode();
                var num = fileStorage.ReadInt(node, "testnum");

                var hash = fileStorage.GetHashedKey("teststring");
                node = fileStorage.GetFileNode(node, hash);
                var str = fileStorage.ReadString(node);
                Console.WriteLine(num + str);

                node = fileStorage.GetRootFileNode();
                var mat = fileStorage.Read<Mat>(node, "testmat");
                Console.WriteLine(cv.Sum(mat).Val0);

                var elems = new int[5];
                node = fileStorage.GetFileNode(node, "testseq");
                fileStorage.ReadRawData(node, elems, "i");
                Console.WriteLine(elems[2]);
            }
        }
    }
}
