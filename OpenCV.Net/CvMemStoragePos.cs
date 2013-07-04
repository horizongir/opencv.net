using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a memory storage position.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CvMemStoragePos
    {
        IntPtr top;
        int free_space;

        /// <summary>
        /// Gets the memory block at the top of the position.
        /// </summary>
        public CvMemBlock Top
        {
            get
            {
                unsafe
                {
                    return *((CvMemBlock*)top.ToPointer());
                }
            }
        }

        /// <summary>
        /// Gets the number of free bytes at the position.
        /// </summary>
        public int FreeSpace
        {
            get { return free_space; }
        }
    }
}
