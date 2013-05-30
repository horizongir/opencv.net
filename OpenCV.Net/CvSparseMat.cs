using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCV.Net.Native;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a multi-dimensional sparse multi-channel array.
    /// </summary>
    public class CvSparseMat : CvArr
    {
        internal CvSparseMat(IntPtr handle, bool ownsHandle)
            : base(ownsHandle)
        {
            SetHandle(handle);
        }

        public CvSparseMat(int[] dimSizes, CvMatDepth depth, int channels)
            : this(NativeMethods.cvCreateSparseMat(dimSizes.Length, dimSizes, MatHelper.GetMatType(depth, channels)), true)
        {
        }

        /// <summary>
        /// Gets the bit depth of matrix elements.
        /// </summary>
        public CvMatDepth Depth
        {
            get
            {
                unsafe
                {
                    return MatHelper.GetMatDepth(((_CvSparseMat*)handle.ToPointer())->type);
                }
            }
        }

        /// <summary>
        /// Gets the number of channels per matrix element.
        /// </summary>
        public int NumChannels
        {
            get
            {
                unsafe
                {
                    return MatHelper.GetMatNumChannels(((_CvSparseMat*)handle.ToPointer())->type);
                }
            }
        }

        /// <summary>
        /// Gets the size of each matrix element channel in bytes.
        /// </summary>
        public int ElementSize
        {
            get
            {
                unsafe
                {
                    return MatHelper.GetElemSize(((_CvSparseMat*)handle.ToPointer())->type);
                }
            }
        }

        /// <summary>
        /// Creates a new <see cref="CvSparseMat"/> that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new <see cref="CvSparseMat"/> that is a copy of this instance.
        /// </returns>
        public CvSparseMat Clone()
        {
            return new CvSparseMat(NativeMethods.cvCloneSparseMat(this), true);
        }

        /// <summary>
        /// Executes the code required to free the native <see cref="CvSparseMat"/> handle.
        /// </summary>
        /// <returns>
        /// <b>true</b> if the handle is released successfully; otherwise, in the event of a
        /// catastrophic failure, <b>false</b>.
        /// </returns>
        protected override bool ReleaseHandle()
        {
            var pMat = handle;
            NativeMethods.cvReleaseSparseMat(ref pMat);
            return true;
        }
    }
}
