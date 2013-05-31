using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32.SafeHandles;
using OpenCV.Net.Native;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents an arbitrary array-like data structure.
    /// </summary>
    public abstract class CvArr : SafeHandleZeroOrMinusOneIsInvalid
    {
        internal CvArr(bool ownsHandle)
            : base(ownsHandle)
        {
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
        /// Returns a specific array element.
        /// </summary>
        /// <param name="index">The zero-based element index.</param>
        /// <returns>The array element specified by <paramref name="index"/>.</returns>
        /// <remarks>
        /// This method can be used for sequential access to 1D, 2D or nD dense arrays.
        /// The method can be used for sparse arrays as well; if the requested node
        /// does not exist, it is created and set to zero.
        /// </remarks>
        public CvScalar Get1D(int index)
        {
            return NativeMethods.cvGet1D(this, index);
        }

        /// <summary>
        /// Returns a specific array element.
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
        public CvScalar Get2D(int index0, int index1)
        {
            return NativeMethods.cvGet2D(this, index0, index1);
        }

        /// <summary>
        /// Returns a specific array element.
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
        public CvScalar Get3D(int index0, int index1, int index2)
        {
            return NativeMethods.cvGet3D(this, index0, index1, index2);
        }

        /// <summary>
        /// Returns a specific array element.
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
        public CvScalar GetND(params int[] index)
        {
            return NativeMethods.cvGetND(this, index);
        }

        /// <summary>
        /// Clears the array. In the case of dense arrays, all elements are
        /// set to zero; for sparse arrays all the elements are removed.
        /// </summary>
        public void SetZero()
        {
            NativeMethods.cvSetZero(this);
        }
    }
}
