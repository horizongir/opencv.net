using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCV.Net.Native;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a multi-channel matrix.
    /// </summary>
    public class CvMat : CvArr
    {
        bool ownsData;
        internal new static readonly CvMat Null = new CvMatNull();

        /// <summary>
        /// A constant passed to the <see cref="CvMat"/> constructor which specifies that no
        /// padding exists between subsequent rows of the matrix.
        /// </summary>
        public const int AutoStep = 0x7fffffff;

        internal CvMat()
            : base(false)
        {
        }

        internal CvMat(bool ownsHandle)
            : base(ownsHandle)
        {
        }

        internal CvMat(IntPtr handle, bool ownsHandle)
            : base(ownsHandle)
        {
            SetHandle(handle);

            if (ownsHandle)
            {
                GC.AddMemoryPressure(Step * Rows);
                ownsData = true;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvMat"/> class with the specified
        /// number of <paramref name="rows"/> and <paramref name="cols"/>, element bit
        /// <paramref name="depth"/> and <paramref name="channels"/> per element.
        /// </summary>
        /// <param name="rows">The number of rows in the matrix.</param>
        /// <param name="cols">The number of columns in the matrix.</param>
        /// <param name="depth">The bit depth of matrix elements.</param>
        /// <param name="channels">The number of channels per element.</param>
        public CvMat(int rows, int cols, CvDepth depth, int channels)
            : this(NativeMethods.cvCreateMat(rows, cols, MatHelper.GetMatType(depth, channels)), true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvMat"/> class with the specified
        /// number of <paramref name="rows"/> and <paramref name="cols"/>, element bit
        /// <paramref name="depth"/> and <paramref name="channels"/> per element.
        /// A pointer to the matrix raw <paramref name="data"/> is provided as well
        /// as the optional full row length <paramref name="step"/> size in bytes.
        /// </summary>
        /// <param name="rows">The number of rows in the matrix.</param>
        /// <param name="cols">The number of columns in the matrix.</param>
        /// <param name="depth">The bit depth of matrix elements.</param>
        /// <param name="channels">The number of channels per matrix element.</param>
        /// <param name="data">A pointer to the matrix raw element data.</param>
        /// <param name="step">The full row length in bytes.</param>
        public CvMat(int rows, int cols, CvDepth depth, int channels, IntPtr data, int step = AutoStep)
            : base(true)
        {
            var type = MatHelper.GetMatType(depth, channels);
            var pMat = NativeMethods.cvCreateMatHeader(rows, cols, type);
            NativeMethods.cvInitMatHeader(pMat, rows, cols, type, data, step); 
            SetHandle(pMat);
        }

        /// <summary>
        /// Gets the number of rows in the matrix.
        /// </summary>
        public int Rows
        {
            get
            {
                unsafe
                {
                    return ((_CvMat*)handle.ToPointer())->rows;
                }
            }
        }

        /// <summary>
        /// Gets the number of columns in the matrix.
        /// </summary>
        public int Cols
        {
            get
            {
                unsafe
                {
                    return ((_CvMat*)handle.ToPointer())->cols;
                }
            }
        }

        /// <summary>
        /// Gets the full row length in bytes.
        /// </summary>
        public int Step
        {
            get
            {
                unsafe
                {
                    return ((_CvMat*)handle.ToPointer())->step;
                }
            }
        }

        /// <summary>
        /// Gets the bit depth of matrix elements.
        /// </summary>
        public CvDepth Depth
        {
            get
            {
                unsafe
                {
                    return MatHelper.GetMatDepth(((_CvMat*)handle.ToPointer())->type);
                }
            }
        }

        /// <summary>
        /// Gets the number of channels per matrix element.
        /// </summary>
        public int Channels
        {
            get
            {
                unsafe
                {
                    return MatHelper.GetMatChannels(((_CvMat*)handle.ToPointer())->type);
                }
            }
        }

        /// <summary>
        /// Gets the size of each matrix element in bytes.
        /// </summary>
        public int ElementSize
        {
            get
            {
                unsafe
                {
                    return MatHelper.GetElemSize(((_CvMat*)handle.ToPointer())->type);
                }
            }
        }

        /// <summary>
        /// Creates a new <see cref="CvMat"/> that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new <see cref="CvMat"/> that is a copy of this instance.
        /// <see cref="Step"/> may differ.
        /// </returns>
        public CvMat Clone()
        {
            return new CvMat(NativeMethods.cvCloneMat(this), true);
        }

        /// <summary>
        /// Executes the code required to free the native <see cref="CvMat"/> handle.
        /// </summary>
        /// <returns>
        /// <b>true</b> if the handle is released successfully; otherwise, in the event of a
        /// catastrophic failure, <b>false</b>.
        /// </returns>
        protected override bool ReleaseHandle()
        {
            if (ownsData)
            {
                GC.RemoveMemoryPressure(Step * Rows);
            }

            NativeMethods.cvReleaseMat(ref handle);
            return true;
        }

        class CvMatNull : CvMat
        {
            public CvMatNull() : base(IntPtr.Zero, false) { }

            protected override bool ReleaseHandle()
            {
                return false;
            }
        }
    }
}
