using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OpenCV.Net
{
    [Flags]
    public enum ChessboardCalibrationFlags : int
    {
        None = 0,
        AdaptiveThreshold = 1,
        NormalizeImage = 2,
        FilterQuads = 4,
        FastCheck = 8
    }
}
