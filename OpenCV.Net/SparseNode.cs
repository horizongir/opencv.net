using OpenCV.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents an element node in a sparse array.
    /// </summary>
    public class SparseNode : CVHandle
    {
        SparseMat owner;

        internal SparseNode(IntPtr handle, SparseMat mat)
            : base(false)
        {
            SetHandle(handle);
            owner = mat;
        }

        /// <summary>
        /// Gets the multi-dimensional index of the node in the sparse array.
        /// </summary>
        public int[] Index
        {
            get
            {
                unsafe
                {
                    var index = new int[owner.GetDims()];
                    var indexPtr = (IntPtr)((byte*)handle.ToPointer() + ((_CvSparseMat*)owner.DangerousGetHandle().ToPointer())->idxoffset);
                    Marshal.Copy(indexPtr, index, 0, index.Length);
                    return index;
                }
            }
        }

        /// <summary>
        /// Gets the value of the node.
        /// </summary>
        public Scalar Value
        {
            get
            {
                unsafe
                {
                    Scalar value;
                    var valuePtr = (IntPtr)((byte*)handle.ToPointer() + ((_CvSparseMat*)owner.DangerousGetHandle().ToPointer())->valoffset);
                    NativeMethods.cvRawDataToScalar(valuePtr, owner.ElementType, out value);
                    return value;
                }
            }
        }

        /// <summary>
        /// Executes the code required to free the native <see cref="SparseNode"/> handle.
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
