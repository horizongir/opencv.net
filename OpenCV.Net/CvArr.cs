using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32.SafeHandles;
using OpenCV.Net.Native;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents an arbitrary array-like data structure.
    /// </summary>
    public abstract class CvArr : SafeHandleZeroOrMinusOneIsInvalid
    {
        internal CvArr(bool ownsHandle)
            : base(ownsHandle)
        {
        }
    }
}
