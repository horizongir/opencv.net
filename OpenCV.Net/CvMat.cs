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

        /// <summary>
        /// A constant passed to the <see cref="CvMat"/> constructor which specifies that no
        /// padding exists between subsequent rows of the matrix.
        /// </summary>
        public const int AutoStep = 0x7fffffff;

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
        public CvMat(int rows, int cols, CvMatDepth depth, int channels)
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
        public CvMat(int rows, int cols, CvMatDepth depth, int channels, IntPtr data, int step = AutoStep)
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
        public CvMatDepth Depth
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
        public int NumChannels
        {
            get
            {
                unsafe
                {
                    return MatHelper.GetMatNumChannels(((_CvMat*)handle.ToPointer())->type);
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
        /// Creates a new <see cref="CvMat"/> from a subrectangle of the current instance.
        /// No data is copied.
        /// </summary>
        /// <param name="rect">Zero-based coordinates of the rectangle of interest.</param>
        /// <returns>
        /// A new <see cref="CvMat"/> that corresponds to the specified rectangle of
        /// the current matrix.
        /// </returns>
        public CvMat GetSubRect(CvRect rect)
        {
            _CvMat subRect;
            NativeMethods.cvGetSubRect(this, out subRect, rect);
            return new CvMatSubMat(this, subRect);
        }

        /// <summary>
        /// Returns a single row of the current matrix as a new <see cref="CvMat"/>.
        /// No data is copied.
        /// </summary>
        /// <param name="row">Zero-based index of the selected row.</param>
        /// <returns>
        /// A new <see cref="CvMat"/> that corresponds to the selected row of
        /// the current matrix.
        /// </returns>
        public CvMat GetRow(int row)
        {
            return GetRows(row, row + 1);
        }

        /// <summary>
        /// Returns a row span of the current matrix as a new <see cref="CvMat"/>.
        /// No data is copied.
        /// </summary>
        /// <param name="startRow">Zero-based index of the starting row (inclusive) of the span.</param>
        /// <param name="endRow">Zero-based index of the ending row (exclusive) of the span</param>
        /// <param name="deltaRow">Index step in the row span.</param>
        /// <returns>The multi-row matrix containing the row span.</returns>
        public CvMat GetRows(int startRow, int endRow, int deltaRow = 1)
        {
            _CvMat subMat;
            NativeMethods.cvGetRows(this, out subMat, startRow, endRow, deltaRow);
            return new CvMatSubMat(this, subMat);
        }

        /// <summary>
        /// Returns a single column of the current matrix as a new <see cref="CvMat"/>.
        /// No data is copied.
        /// </summary>
        /// <param name="col">Zero-based index of the selected column.</param>
        /// <returns>
        /// A new <see cref="CvMat"/> that corresponds to the selected column of
        /// the current matrix.
        /// </returns>
        public CvMat GetCol(int col)
        {
            return GetCols(col, col + 1);
        }

        /// <summary>
        /// Returns a column span of the current matrix as a new <see cref="CvMat"/>.
        /// No data is copied.
        /// </summary>
        /// <param name="startCol">Zero-based index of the starting column (inclusive) of the span.</param>
        /// <param name="endCol">Zero-based index of the ending column (exclusive) of the span</param>
        /// <returns>The multi-column matrix containing the column span.</returns>
        public CvMat GetCols(int startCol, int endCol)
        {
            _CvMat subMat;
            NativeMethods.cvGetCols(this, out subMat, startCol, endCol);
            return new CvMatSubMat(this, subMat);
        }

        /// <summary>
        /// Returns the main diagonal of the current matrix.
        /// </summary>
        /// <returns>
        /// A new <see cref="CvMat"/> that corresponds to the main diagonal
        /// of the current matrix.
        /// </returns>
        public CvMat GetDiag()
        {
            return GetDiag(0);
        }

        /// <summary>
        /// Returns a specified diagonal of the current matrix.
        /// </summary>
        /// <param name="diag">
        /// The selected array diagonal. Zero corresponds to the main diagonal,
        /// negative one corresponds to the diagonal above the main, positive one
        /// corresponds to the diagonal below the main, and so forth.
        /// </param>
        /// <returns>
        /// A new <see cref="CvMat"/> that corresponds to the specified diagonal
        /// of the current matrix.
        /// </returns>
        public CvMat GetDiag(int diag)
        {
            _CvMat subMat;
            NativeMethods.cvGetDiag(this, out subMat, diag);
            return new CvMatSubMat(this, subMat);
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
            var pMat = handle;
            if (ownsData)
            {
                GC.RemoveMemoryPressure(Step * Rows);
            }

            NativeMethods.cvReleaseMat(ref pMat);
            return true;
        }

        class CvMatSubMat : CvMat
        {
            CvMat owner;

            public CvMatSubMat(CvMat source, _CvMat subMat)
                : base(true)
            {
                var pMat = NativeMethods.cvCreateMatHeader(subMat.rows, subMat.cols, subMat.type);
                NativeMethods.cvInitMatHeader(pMat, subMat.rows, subMat.cols, subMat.type, subMat.data, subMat.step);
                SetHandle(pMat);
                owner = source;
            }

            protected override bool ReleaseHandle()
            {
                base.ReleaseHandle();
                owner = null;
                return true;
            }
        }
    }
}
