using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a memory storage block.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MemBlock
    {
        IntPtr prev;
        IntPtr next;

        /// <summary>
        /// Gets the previous memory storage block.
        /// </summary>
        public MemBlock Prev
        {
            get
            {
                unsafe
                {
                    return *((MemBlock*)prev.ToPointer());
                }
            }
        }

        /// <summary>
        /// Gets the next memory storage block.
        /// </summary>
        public MemBlock Next
        {
            get
            {
                unsafe
                {
                    return *((MemBlock*)prev.ToPointer());
                }
            }
        }
    }
}
