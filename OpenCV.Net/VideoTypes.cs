using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCV.Net
{
    [Flags]
    public enum LKFlowFlags : int
    {
        None = 0,
        PyrAReady = 1,
        PyrBReady = 2,
        InitialGuesses = 4,
        GetMinEigenVals = 8
    }
}
