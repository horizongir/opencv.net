using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCV.Net.Native;

namespace OpenCV.Net
{
    /// <summary>
    /// This class provides wrapper methods for the OpenCV C interface native functions.
    /// </summary>
    public static partial class cv
    {
        #region Array allocation, deallocation, initialization and access to elements

        /// <summary>
        /// Allocates a block of <paramref name="size"/> bytes in memory,
        /// returning a pointer to the beginning of the block.
        /// </summary>
        /// <param name="size">Size of the memory block, in bytes.</param>
        /// <returns>
        /// On success, a pointer to the memory block allocated by the function.
        /// If there is not enough memory, the function raises an error.
        /// </returns>
        public static IntPtr Alloc(UIntPtr size)
        {
            return NativeMethods.cvAlloc(size);
        }

        /// <summary>
        /// Deallocates a block of memory previously allocated by a call to
        /// <see cref="Alloc"/>.
        /// </summary>
        /// <param name="ptr">Pointer to a memory block previously allocated with <see cref="Alloc"/>.</param>
        public static void Free(ref IntPtr ptr)
        {
            NativeMethods.cvFree_(ptr);
            ptr = IntPtr.Zero;
        }

        #endregion
    }
}
