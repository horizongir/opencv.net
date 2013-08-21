using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenCV.Net.UnitTests
{
    [TestClass]
    public class MatNDTests : ArrTests
    {
        MatND mat;

        protected override Arr CreateArr(int channels, Depth depth, int dim0, int dim1)
        {
            return mat = new MatND(new[] { dim0, dim1 }, depth, channels);
        }
    }
}
