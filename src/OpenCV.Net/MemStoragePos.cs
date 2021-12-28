using System;
using System.Runtime.InteropServices;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a memory storage position.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MemStoragePos
    {
        IntPtr top;
        int free_space;

        /// <summary>
        /// Gets the memory block at the top of the position.
        /// </summary>
        public MemBlock Top
        {
            get
            {
                unsafe
                {
                    return *((MemBlock*)top.ToPointer());
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
