using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCV.Net.Native;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a multi-dimensional dense multi-channel array.
    /// </summary>
    public class CvMatND : CvArr
    {
        bool ownsData;

        internal CvMatND(IntPtr handle, bool ownsHandle)
            : base(ownsHandle)
        {
            SetHandle(handle);

            if (ownsHandle)
            {
                //GC.AddMemoryPressure(Step * Rows);
                //ownsData = true;
            }
        }

        public CvMatND(int[] dimSizes, CvMatDepth depth, int channels)
            : this(NativeMethods.cvCreateMatND(dimSizes.Length, dimSizes, MatHelper.GetMatType(depth, channels)), true)
        {
        }

        public CvMatND(int[] dimSizes, CvMatDepth depth, int channels, IntPtr data)
            : base(true)
        {
            var type = MatHelper.GetMatType(depth, channels);
            var pMat = NativeMethods.cvCreateMatNDHeader(dimSizes.Length, dimSizes, type);
            NativeMethods.cvInitMatNDHeader(pMat, dimSizes.Length, dimSizes, type, data);
            SetHandle(pMat);
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
                    return MatHelper.GetMatDepth(((_CvMatND*)handle.ToPointer())->type);
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
                    return MatHelper.GetMatNumChannels(((_CvMatND*)handle.ToPointer())->type);
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
                    return MatHelper.GetElemSize(((_CvMatND*)handle.ToPointer())->type);
                }
            }
        }

        /// <summary>
        /// Creates a new <see cref="CvMatND"/> that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new <see cref="CvMatND"/> that is a copy of this instance.
        /// </returns>
        public CvMatND Clone()
        {
            return new CvMatND(NativeMethods.cvCloneMatND(this), true);
        }

        /// <summary>
        /// Executes the code required to free the native <see cref="CvMatND"/> handle.
        /// </summary>
        /// <returns>
        /// <b>true</b> if the handle is released successfully; otherwise, in the event of a
        /// catastrophic failure, <b>false</b>.
        /// </returns>
        protected override bool ReleaseHandle()
        {
            var pMat = handle;
            if (ownsData)
            {
                //GC.RemoveMemoryPressure(Step * Rows);
            }

            NativeMethods.cvReleaseMat(ref pMat);
            return true;
        }
    }
}
