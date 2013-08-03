using Microsoft.Win32.SafeHandles;
using OpenCV.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a growing memory storage.
    /// </summary>
    public class MemStorage : CVHandle
    {
        MemStorage owner;
        internal static readonly MemStorage Null = new MemStorageNull();

        internal MemStorage(IntPtr handle)
            : base(true)
        {
            SetHandle(handle);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MemStorage"/> class.
        /// </summary>
        public MemStorage()
            : this(0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MemStorage"/> class with the
        /// specified <paramref name="blockSize"/>.
        /// </summary>
        /// <param name="blockSize">The size of storage blocks, in bytes.</param>
        public MemStorage(int blockSize)
            : base(true)
        {
            var pMemStorage = NativeMethods.cvCreateMemStorage(blockSize);
            SetHandle(pMemStorage);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MemStorage"/> class that will
        /// borrow its memory blocks from the specified <paramref name="parent"/> storage.
        /// </summary>
        /// <param name="parent">The parent memory storage.</param>
        public MemStorage(MemStorage parent)
            : base(true)
        {
            var pMemStorage = NativeMethods.cvCreateChildMemStorage(parent);
            SetHandle(pMemStorage);
            owner = parent;
        }

        /// <summary>
        /// Clears the memory storage. If the storage has a parent, the method returns
        /// all memory blocks to the parent.
        /// </summary>
        public void Clear()
        {
            NativeMethods.cvClearMemStorage(this);
        }

        /// <summary>
        /// Saves the memory storage position.
        /// </summary>
        /// <returns>The current position of the storage top.</returns>
        public MemStoragePos SavePosition()
        {
            MemStoragePos pos;
            NativeMethods.cvSaveMemStoragePos(this, out pos);
            return pos;
        }

        /// <summary>
        /// Restores the memory storage position.
        /// </summary>
        /// <param name="pos">The new position of the storage top.</param>
        public void RestorePosition(MemStoragePos pos)
        {
            NativeMethods.cvRestoreMemStoragePos(this, ref pos);
        }

        /// <summary>
        /// Allocates a memory buffer in a storage block.
        /// </summary>
        /// <param name="size">The size of the memory block, in bytes.</param>
        /// <returns>A pointer to the newly allocated memory block.</returns>
        public IntPtr Alloc(UIntPtr size)
        {
            return NativeMethods.cvMemStorageAlloc(this, size);
        }

        /// <summary>
        /// Allocates a text string in a storage block.
        /// </summary>
        /// <param name="value">The string to be copied to the storage.</param>
        /// <returns>The pointer to the copy of the string in storage.</returns>
        public IntPtr AllocString(string value)
        {
            return NativeMethods.cvMemStorageAllocString(this, value, -1).ptr;
        }

        /// <summary>
        /// Executes the code required to free the native <see cref="MemStorage"/> handle.
        /// </summary>
        /// <returns>
        /// <b>true</b> if the handle is released successfully; otherwise, in the event of a
        /// catastrophic failure, <b>false</b>.
        /// </returns>
        protected override bool ReleaseHandle()
        {
            owner = null;
            NativeMethods.cvReleaseMemStorage(ref handle);
            return true;
        }

        class MemStorageNull : MemStorage
        {
            public MemStorageNull() : base(IntPtr.Zero) { }

            protected override bool ReleaseHandle()
            {
                return false;
            }
        }
    }
}
