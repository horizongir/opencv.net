using System;
using OpenCV.Net.Native;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents an arbitrary array-like data structure.
    /// </summary>
    public abstract class Arr : CVHandle
    {
        internal static readonly Arr Null = new ArrNull();

        internal Arr(bool ownsHandle)
            : base(ownsHandle)
        {
        }

        /// <summary>
        /// Gets the type of array elements.
        /// </summary>
        public int ElementType
        {
            get { return NativeMethods.cvGetElemType(this); }
        }

        /// <summary>
        /// Gets the pixel-accurate size of the array.
        /// </summary>
        public Size Size
        {
            get { return NativeMethods.cvGetSize(this); }
        }

        /// <summary>
        /// Creates a new <see cref="Mat"/> from a subrectangle of the current instance.
        /// No data is copied.
        /// </summary>
        /// <param name="rect">Zero-based coordinates of the rectangle of interest.</param>
        /// <returns>
        /// A new <see cref="Mat"/> that corresponds to the specified rectangle of
        /// the current matrix.
        /// </returns>
        public Mat GetSubRect(Rect rect)
        {
            _CvMat subRect;
            NativeMethods.cvGetSubRect(this, out subRect, rect);
            return new MatHeader(this, subRect);
        }

        /// <summary>
        /// Returns a single row of the current matrix as a new <see cref="Mat"/>.
        /// No data is copied.
        /// </summary>
        /// <param name="row">Zero-based index of the selected row.</param>
        /// <returns>
        /// A new <see cref="Mat"/> that corresponds to the selected row of
        /// the current matrix.
        /// </returns>
        public Mat GetRow(int row)
        {
            return GetRows(row, row + 1);
        }

        /// <summary>
        /// Returns a row span of the current matrix as a new <see cref="Mat"/>.
        /// No data is copied.
        /// </summary>
        /// <param name="startRow">Zero-based index of the starting row (inclusive) of the span.</param>
        /// <param name="endRow">Zero-based index of the ending row (exclusive) of the span</param>
        /// <param name="deltaRow">Index step in the row span.</param>
        /// <returns>The multi-row matrix containing the row span.</returns>
        public Mat GetRows(int startRow, int endRow, int deltaRow = 1)
        {
            _CvMat subMat;
            NativeMethods.cvGetRows(this, out subMat, startRow, endRow, deltaRow);
            return new MatHeader(this, subMat);
        }

        /// <summary>
        /// Returns a single column of the current matrix as a new <see cref="Mat"/>.
        /// No data is copied.
        /// </summary>
        /// <param name="col">Zero-based index of the selected column.</param>
        /// <returns>
        /// A new <see cref="Mat"/> that corresponds to the selected column of
        /// the current matrix.
        /// </returns>
        public Mat GetCol(int col)
        {
            return GetCols(col, col + 1);
        }

        /// <summary>
        /// Returns a column span of the current matrix as a new <see cref="Mat"/>.
        /// No data is copied.
        /// </summary>
        /// <param name="startCol">Zero-based index of the starting column (inclusive) of the span.</param>
        /// <param name="endCol">Zero-based index of the ending column (exclusive) of the span</param>
        /// <returns>The multi-column matrix containing the column span.</returns>
        public Mat GetCols(int startCol, int endCol)
        {
            _CvMat subMat;
            NativeMethods.cvGetCols(this, out subMat, startCol, endCol);
            return new MatHeader(this, subMat);
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
        /// A new <see cref="Mat"/> that corresponds to the specified diagonal
        /// of the current matrix.
        /// </returns>
        public Mat GetDiag(int diag = 0)
        {
            _CvMat subMat;
            NativeMethods.cvGetDiag(this, out subMat, diag);
            return new MatHeader(this, subMat);
        }

        /// <summary>
        /// Returns the number of array dimensions and their sizes.
        /// </summary>
        /// <param name="sizes">
        /// The optional output array of the dimension sizes. For 2D arrays the number
        /// of rows (height) goes first and the number of columns (width) goes next.
        /// </param>
        /// <returns>The number of array dimensions.</returns>
        public int GetDims(int[] sizes = null)
        {
            return NativeMethods.cvGetDims(this, sizes);
        }

        /// <summary>
        /// Returns the size of a particular array dimension.
        /// </summary>
        /// <param name="index">
        /// The zero-based dimension index. For matrices, zero means number of rows and
        /// one means number of columns; for images zero means height and one means width.
        /// </param>
        /// <returns>The number of elements in a particular array dimension.</returns>
        public int GetDimSize(int index)
        {
            return NativeMethods.cvGetDimSize(this, index);
        }

        /// <summary>
        /// Returns a pointer to a specific array element.
        /// </summary>
        /// <param name="index">The zero-based element index.</param>
        /// <returns>The pointer to the array element specified by <paramref name="index"/>.</returns>
        /// <remarks>
        /// This method can be used for sequential access to 1D, 2D or nD dense arrays.
        /// The method can be used for sparse arrays as well; if the requested node
        /// does not exist, it is created and set to zero.
        /// </remarks>
        public IntPtr Ptr(int index)
        {
            int elementType;
            return Ptr(index, out elementType);
        }

        /// <summary>
        /// Returns a pointer to a specific array element.
        /// </summary>
        /// <param name="index">The zero-based element index.</param>
        /// <param name="elementType">
        /// When this method returns, contains the type of matrix elements. This parameter
        /// is passed uninitialized.
        /// </param>
        /// <returns>The pointer to the array element specified by <paramref name="index"/>.</returns>
        /// <remarks>
        /// This method can be used for sequential access to 1D, 2D or nD dense arrays.
        /// The method can be used for sparse arrays as well; if the requested node
        /// does not exist, it is created and set to zero.
        /// </remarks>
        public IntPtr Ptr(int index, out int elementType)
        {
            return NativeMethods.cvPtr1D(this, index, out elementType);
        }

        /// <summary>
        /// Returns a pointer to a specific array element.
        /// </summary>
        /// <param name="index0">The zero-based element index on the first array dimension.</param>
        /// <param name="index1">The zero-based element index on the second array dimension.</param>
        /// <returns>
        /// The pointer to the array element specified by <paramref name="index0"/> and
        /// <paramref name="index1"/>.
        /// </returns>
        /// <remarks>
        /// The array must have two dimensions. The method can be used for sparse arrays as
        /// well; if the requested node does not exist, it is created and set to zero.
        /// </remarks>
        public IntPtr Ptr(int index0, int index1)
        {
            int elementType;
            return Ptr(index0, index1, out elementType);
        }

        /// <summary>
        /// Returns a pointer to a specific array element.
        /// </summary>
        /// <param name="index0">The zero-based element index on the first array dimension.</param>
        /// <param name="index1">The zero-based element index on the second array dimension.</param>
        /// <param name="elementType">
        /// When this method returns, contains the type of matrix elements. This parameter
        /// is passed uninitialized.
        /// </param>
        /// <returns>
        /// The pointer to the array element specified by <paramref name="index0"/> and
        /// <paramref name="index1"/>.
        /// </returns>
        /// <remarks>
        /// The array must have two dimensions. The method can be used for sparse arrays as
        /// well; if the requested node does not exist, it is created and set to zero.
        /// </remarks>
        public IntPtr Ptr(int index0, int index1, out int elementType)
        {
            return NativeMethods.cvPtr2D(this, index0, index1, out elementType);
        }

        /// <summary>
        /// Returns a pointer to a specific array element.
        /// </summary>
        /// <param name="index0">The zero-based element index on the first array dimension.</param>
        /// <param name="index1">The zero-based element index on the second array dimension.</param>
        /// <param name="index2">The zero-based element index on the third array dimension.</param>
        /// <returns>
        /// The pointer to the array element specified by <paramref name="index0"/>,
        /// <paramref name="index1"/> and <paramref name="index2"/>.
        /// </returns>
        /// <remarks>
        /// The array must have three dimensions. The method can be used for sparse arrays as
        /// well; if the requested node does not exist, it is created and set to zero.
        /// </remarks>
        public IntPtr Ptr(int index0, int index1, int index2)
        {
            int elementType;
            return Ptr(index0, index1, index2, out elementType);
        }

        /// <summary>
        /// Returns a pointer to a specific array element.
        /// </summary>
        /// <param name="index0">The zero-based element index on the first array dimension.</param>
        /// <param name="index1">The zero-based element index on the second array dimension.</param>
        /// <param name="index2">The zero-based element index on the third array dimension.</param>
        /// <param name="elementType">
        /// When this method returns, contains the type of matrix elements. This parameter
        /// is passed uninitialized.
        /// </param>
        /// <returns>
        /// The pointer to the array element specified by <paramref name="index0"/>,
        /// <paramref name="index1"/> and <paramref name="index2"/>.
        /// </returns>
        /// <remarks>
        /// The array must have three dimensions. The method can be used for sparse arrays as
        /// well; if the requested node does not exist, it is created and set to zero.
        /// </remarks>
        public IntPtr Ptr(int index0, int index1, int index2, out int elementType)
        {
            return NativeMethods.cvPtr3D(this, index0, index1, index2, out elementType);
        }

        /// <summary>
        /// Returns a pointer to a specific array element.
        /// </summary>
        /// <param name="index">
        /// An array specifying the zero-based multi-dimensional element index.
        /// The length of <paramref name="index"/> must be the same as the number
        /// of dimensions of this instance.
        /// </param>
        /// <returns>
        /// The pointer to the array element specified by the multi-dimensional
        /// <paramref name="index"/>.
        /// </returns>
        /// <remarks>
        /// The method can be used for sparse arrays as
        /// well; if the requested node does not exist, it is created and set to zero.
        /// </remarks>
        public IntPtr Ptr(int[] index)
        {
            int elementType;
            return Ptr(index, out elementType);
        }

        /// <summary>
        /// Returns a pointer to a specific array element.
        /// </summary>
        /// <param name="index">
        /// An array specifying the zero-based multi-dimensional element index.
        /// The length of <paramref name="index"/> must be the same as the number
        /// of dimensions of this instance.
        /// </param>
        /// <param name="elementType">
        /// When this method returns, contains the type of matrix elements. This parameter
        /// is passed uninitialized.
        /// </param>
        /// <param name="createNode">
        /// Optional parameter for sparse arrays only. <b>true</b> means that the requested
        /// element is created if it does not exist already; otherwise, the array will not
        /// be changed.
        /// </param>
        /// <returns>
        /// The pointer to the array element specified by the multi-dimensional
        /// <paramref name="index"/>.
        /// </returns>
        public IntPtr Ptr(int[] index, out int elementType, bool createNode = true)
        {
            return NativeMethods.cvPtrND(this, index, out elementType, createNode ? 1 : 0, IntPtr.Zero);
        }

        /// <summary>
        /// Gets or sets a specific array element.
        /// </summary>
        /// <param name="index">The zero-based element index.</param>
        /// <returns>The array element specified by <paramref name="index"/>.</returns>
        /// <remarks>
        /// This method can be used for sequential access to 1D, 2D or nD dense arrays.
        /// The method can be used for sparse arrays as well; if the requested node
        /// does not exist, it is created and set to zero.
        /// </remarks>
        public Scalar this[int index]
        {
            get { return NativeMethods.cvGet1D(this, index); }
            set { NativeMethods.cvSet1D(this, index, value); }
        }

        /// <summary>
        /// Gets or sets a specific array element.
        /// </summary>
        /// <param name="index0">The zero-based element index on the first array dimension.</param>
        /// <param name="index1">The zero-based element index on the second array dimension.</param>
        /// <returns>
        /// The array element specified by <paramref name="index0"/> and
        /// <paramref name="index1"/>.
        /// </returns>
        /// <remarks>
        /// The array must have two dimensions. The method can be used for sparse arrays as
        /// well; if the requested node does not exist, it is created and set to zero.
        /// </remarks>
        public Scalar this[int index0, int index1]
        {
            get { return NativeMethods.cvGet2D(this, index0, index1); }
            set { NativeMethods.cvSet2D(this, index0, index1, value); }
        }

        /// <summary>
        /// Gets or sets a specific array element.
        /// </summary>
        /// <param name="index0">The zero-based element index on the first array dimension.</param>
        /// <param name="index1">The zero-based element index on the second array dimension.</param>
        /// <param name="index2">The zero-based element index on the third array dimension.</param>
        /// <returns>
        /// The array element specified by <paramref name="index0"/>, <paramref name="index1"/>
        /// and <paramref name="index2"/>.
        /// </returns>
        /// <remarks>
        /// The array must have three dimensions. The method can be used for sparse arrays as
        /// well; if the requested node does not exist, it is created and set to zero.
        /// </remarks>
        public Scalar this[int index0, int index1, int index2]
        {
            get { return NativeMethods.cvGet3D(this, index0, index1, index2); }
            set { NativeMethods.cvSet3D(this, index0, index1, index2, value); }
        }

        /// <summary>
        /// Gets or sets a specific array element.
        /// </summary>
        /// <param name="index">
        /// An array specifying the zero-based multi-dimensional element index.
        /// The length of <paramref name="index"/> must be the same as the number
        /// of dimensions of this instance.
        /// </param>
        /// <returns>
        /// The array element specified by the multi-dimensional <paramref name="index"/>.
        /// </returns>
        /// <remarks>
        /// The method can be used for sparse arrays as
        /// well; if the requested node does not exist, it is created and set to zero.
        /// </remarks>
        public Scalar this[params int[] index]
        {
            get { return NativeMethods.cvGetND(this, index); }
            set { NativeMethods.cvSetND(this, index, value); }
        }

        /// <summary>
        /// Returns a specific element of single-channel array.
        /// </summary>
        /// <param name="index">The zero-based element index.</param>
        /// <returns>The array element specified by <paramref name="index"/>.</returns>
        /// <remarks>
        /// This method can be used for sequential access to 1D, 2D or nD dense arrays.
        /// The method can be used for sparse arrays as well; if the requested node
        /// does not exist, it is created and set to zero.
        /// </remarks>
        public double GetReal(int index)
        {
            return NativeMethods.cvGetReal1D(this, index);
        }

        /// <summary>
        /// Returns a specific element of single-channel array.
        /// </summary>
        /// <param name="index0">The zero-based element index on the first array dimension.</param>
        /// <param name="index1">The zero-based element index on the second array dimension.</param>
        /// <returns>
        /// The array element specified by <paramref name="index0"/> and
        /// <paramref name="index1"/>.
        /// </returns>
        /// <remarks>
        /// The array must have two dimensions. The method can be used for sparse arrays as
        /// well; if the requested node does not exist, it is created and set to zero.
        /// </remarks>
        public double GetReal(int index0, int index1)
        {
            return NativeMethods.cvGetReal2D(this, index0, index1);
        }

        /// <summary>
        /// Returns a specific element of single-channel array.
        /// </summary>
        /// <param name="index0">The zero-based element index on the first array dimension.</param>
        /// <param name="index1">The zero-based element index on the second array dimension.</param>
        /// <param name="index2">The zero-based element index on the third array dimension.</param>
        /// <returns>
        /// The array element specified by <paramref name="index0"/>, <paramref name="index1"/>
        /// and <paramref name="index2"/>.
        /// </returns>
        /// <remarks>
        /// The array must have three dimensions. The method can be used for sparse arrays as
        /// well; if the requested node does not exist, it is created and set to zero.
        /// </remarks>
        public double GetReal(int index0, int index1, int index2)
        {
            return NativeMethods.cvGetReal3D(this, index0, index1, index2);
        }

        /// <summary>
        /// Returns a specific element of single-channel array.
        /// </summary>
        /// <param name="index">
        /// An array specifying the zero-based multi-dimensional element index.
        /// The length of <paramref name="index"/> must be the same as the number
        /// of dimensions of this instance.
        /// </param>
        /// <returns>
        /// The array element specified by the multi-dimensional <paramref name="index"/>.
        /// </returns>
        /// <remarks>
        /// The method can be used for sparse arrays as well; if the requested node
        /// does not exist, it is created and set to zero.
        /// </remarks>
        public double GetReal(params int[] index)
        {
            return NativeMethods.cvGetRealND(this, index);
        }

        /// <summary>
        /// Sets a specific element of single-channel array.
        /// </summary>
        /// <param name="index">The zero-based element index.</param>
        /// <param name="value">The assigned value.</param>
        /// <remarks>
        /// The method can be used for sparse arrays as well; if the node does not
        /// exist, it is created and set to the specified <paramref name="value"/>.
        /// </remarks>
        public void SetReal(int index, double value)
        {
            NativeMethods.cvSetReal1D(this, index, value);
        }

        /// <summary>
        /// Sets a specific element of single-channel array.
        /// </summary>
        /// <param name="index0">The zero-based element index on the first array dimension.</param>
        /// <param name="index1">The zero-based element index on the second array dimension.</param>
        /// <param name="value">The assigned value.</param>
        /// <remarks>
        /// The method can be used for sparse arrays as well; if the node does not
        /// exist, it is created and set to the specified <paramref name="value"/>.
        /// </remarks>
        public void SetReal(int index0, int index1, double value)
        {
            NativeMethods.cvSetReal2D(this, index0, index1, value);
        }

        /// <summary>
        /// Sets a specific element of single-channel array.
        /// </summary>
        /// <param name="index0">The zero-based element index on the first array dimension.</param>
        /// <param name="index1">The zero-based element index on the second array dimension.</param>
        /// <param name="index2">The zero-based element index on the third array dimension.</param>
        /// <param name="value">The assigned value.</param>
        /// <remarks>
        /// The method can be used for sparse arrays as well; if the node does not
        /// exist, it is created and set to the specified <paramref name="value"/>.
        /// </remarks>
        public void SetReal(int index0, int index1, int index2, double value)
        {
            NativeMethods.cvSetReal3D(this, index0, index1, index2, value);
        }

        /// <summary>
        /// Sets a specific element of single-channel array.
        /// </summary>
        /// <param name="index">
        /// An array specifying the zero-based multi-dimensional element index.
        /// The length of <paramref name="index"/> must be the same as the number
        /// of dimensions of this instance.
        /// </param>
        /// <param name="value">The assigned value.</param>
        /// <remarks>
        /// The method can be used for sparse arrays as well; if the node does not
        /// exist, it is created and set to the specified <paramref name="value"/>.
        /// </remarks>
        public void SetReal(int[] index, double value)
        {
            NativeMethods.cvSetRealND(this, index, value);
        }

        /// <summary>
        /// Clears a specific element of a multi-dimensional array. If the array
        /// is dense, the element is set to zero; in case of sparse arrays,
        /// it deletes the specified node.
        /// </summary>
        /// <param name="index">
        /// An array specifying the zero-based multi-dimensional index of the
        /// element to be cleared.
        /// </param>
        public void ClearND(params int[] index)
        {
            NativeMethods.cvClearND(this, index);
        }

        /// <summary>
        /// Returns matrix header for arbitrary array.
        /// </summary>
        /// <param name="allowND">
        /// If <b>true</b>, the function accepts multi-dimensional dense arrays of type
        /// <see cref="MatND"/> and returns a 2D matrix if the <see cref="MatND"/>
        /// has two dimensions or 1D matrix otherwise. The array must be continuous.
        /// </param>
        /// <returns>
        /// A matrix header for the array which can be an image, matrix or
        /// multi-dimensional dense array.
        /// </returns>
        public Mat GetMat(bool allowND = false)
        {
            int coi;
            _CvMat header;
            var pMat = NativeMethods.cvGetMat(this, out header, out coi, allowND ? 1 : 0);
            if (pMat == handle) return (Mat)this;
            else return new MatHeader(this, header);
        }

        /// <summary>
        /// Returns image header for arbitrary array.
        /// </summary>
        /// <returns>
        /// An image header for the array which can be an image or matrix.
        /// </returns>
        public IplImage GetImage()
        {
            _IplImage header;
            var pImage = NativeMethods.cvGetImage(this, out header);
            if (pImage == handle) return (IplImage)this;
            else return new IplImageHeader(this, header);
        }

        /// <summary>
        /// Changes shape of matrix/image without copying data.
        /// </summary>
        /// <param name="channels">
        /// The new number of channels. Zero means that the number of channels
        /// remains unchanged.
        /// </param>
        /// <param name="rows">
        /// The new number of rows. Zero means that the number of rows remains
        /// unchanged unless it needs to be changed according to <paramref name="channels"/>.
        /// </param>
        /// <returns>
        /// A new matrix header for the array with the newly specified shape.
        /// </returns>
        public Mat Reshape(int channels, int rows = 0)
        {
            _CvMat header;
            NativeMethods.cvReshape(this, out header, channels, rows);
            return new MatHeader(this, header);
        }

        /// <summary>
        /// Assigns the specified user data pointer to the array header.
        /// </summary>
        /// <param name="data">The user data pointer to the raw element data.</param>
        /// <param name="step">The full row length in bytes.</param>
        public void SetData(IntPtr data, int step)
        {
            NativeMethods.cvSetData(this, data, step);
        }

        /// <summary>
        /// Retrieves low-level information about the array.
        /// </summary>
        /// <param name="data">
        /// Output pointer to the whole image origin or ROI origin if ROI is set.
        /// </param>
        public void GetRawData(out IntPtr data)
        {
            int step;
            Size roiSize;
            NativeMethods.cvGetRawData(this, out data, out step, out roiSize);
        }

        /// <summary>
        /// Retrieves low-level information about the array.
        /// </summary>
        /// <param name="data">
        /// Output pointer to the whole image origin or ROI origin if ROI is set.
        /// </param>
        /// <param name="step">Output full row length in bytes.</param>
        public void GetRawData(out IntPtr data, out int step)
        {
            Size roiSize;
            NativeMethods.cvGetRawData(this, out data, out step, out roiSize);
        }

        /// <summary>
        /// Retrieves low-level information about the array.
        /// </summary>
        /// <param name="data">
        /// Output pointer to the whole image origin or ROI origin if ROI is set.
        /// </param>
        /// <param name="step">Output full row length in bytes.</param>
        /// <param name="roiSize">Output pixel-accurate ROI size.</param>
        public void GetRawData(out IntPtr data, out int step, out Size roiSize)
        {
            NativeMethods.cvGetRawData(this, out data, out step, out roiSize);
        }

        /// <summary>
        /// Sets every element of the array to a given value.
        /// </summary>
        /// <param name="value">The fill value.</param>
        /// <param name="mask">
        /// Optional operation mask, 8-bit single-channel array specifying the
        /// elements that should be changed.
        /// </param>
        public void Set(Scalar value, Arr mask = null)
        {
            NativeMethods.cvSet(this, value, mask ?? Null);
        }

        /// <summary>
        /// Clears the array. In the case of dense arrays, all elements are
        /// set to zero; for sparse arrays all the elements are removed.
        /// </summary>
        public void SetZero()
        {
            NativeMethods.cvSetZero(this);
        }

        /// <summary>
        /// Checks that every array element is neither NaN nor Infinity. It can also check
        /// whether the elements are within a specified range.
        /// </summary>
        /// <param name="flags">
        /// The operation flags. A combination of <see cref="CheckArrayFlags.CheckNanInfinity"/>
        /// and <see cref="CheckArrayFlags.CheckRange"/>. If the latter is set, the function
        /// checks whether every value of the array is greater than or equal to <paramref name="minVal"/>
        /// and less than <paramref name="maxVal"/>. If <see cref="CheckArrayFlags.CheckQuiet"/> is set,
        /// the function does not raise an error if an element is invalid or out of range.
        /// </param>
        /// <param name="minVal">The inclusive lower boundary of valid values range.</param>
        /// <param name="maxVal">The exclusive upper boundary of valid values range.</param>
        /// <returns><b>true</b> if all array elements are valid and within range; <b>false</b> otherwise.</returns>
        public bool CheckRange(CheckArrayFlags flags, double minVal, double maxVal)
        {
            return NativeMethods.cvCheckArr(this, flags, minVal, maxVal) > 0;
        }

        internal class MatHeader : Mat
        {
            Arr owner;

            public MatHeader(Arr source, _CvMat subMat)
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

        internal class IplImageHeader : IplImage
        {
            Arr owner;

            public IplImageHeader(Arr source, _IplImage header)
                : base(true)
            {
                var pImage = NativeMethods.cvCreateImageHeader(new Size(header.width, header.height), header.depth, header.nChannels);
                SetHandle(pImage);
                SetData(header.imageData, header.widthStep);
                owner = source;
            }

            protected override bool ReleaseHandle()
            {
                base.ReleaseHandle();
                owner = null;
                return true;
            }
        }

        class ArrNull : Arr
        {
            internal ArrNull() : base(false) { }

            protected override bool ReleaseHandle()
            {
                return false;
            }
        }
    }
}
