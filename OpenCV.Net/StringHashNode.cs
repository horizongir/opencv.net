using OpenCV.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a unique reference for a given name.
    /// </summary>
    public class StringHashNode : CVHandle
    {
        internal static readonly StringHashNode Null = new StringHashNode();

        internal StringHashNode()
            : base(false)
        {
        }

        internal StringHashNode(IntPtr handle)
            : base(false)
        {
            SetHandle(handle);
        }

        /// <summary>
        /// Gets the hash code value of the name.
        /// </summary>
        public uint HashVal
        {
            get
            {
                unsafe
                {
                    return ((_CvStringHashNode*)handle.ToPointer())->hashval;
                }
            }
        }

        /// <summary>
        /// Gets the string representation of the name.
        /// </summary>
        public string Str
        {
            get
            {
                unsafe
                {
                    var ptr = (_CvStringHashNode*)handle.ToPointer();
                    return Marshal.PtrToStringAnsi(ptr->str.ptr, ptr->str.len);
                }
            }
        }

        /// <summary>
        /// Executes the code required to free the native <see cref="StringHashNode"/> handle.
        /// </summary>
        /// <returns>
        /// <b>true</b> if the handle is released successfully; otherwise, in the event of a
        /// catastrophic failure, <b>false</b>.
        /// </returns>
        protected override bool ReleaseHandle()
        {
            return false;
        }
    }
}
