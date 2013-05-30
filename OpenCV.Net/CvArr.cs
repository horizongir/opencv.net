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

        /// <summary>
        /// Returns the size of a particular array dimension.
        /// </summary>
        /// <param name="index">
        /// The zero-based dimension index. For matrices, zero means number of rows and
        /// one means number of columns; for images zero means height and one means width.
        /// </param>
        /// <returns>The number of elements in a particular array dimension.</returns>
        public int GetDimSize(int index)
        {
            return NativeMethods.cvGetDimSize(this, index);
        }
    }
}
