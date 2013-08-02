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

        /// <summary>
        /// Initializes a new instance of the <see cref="CvSparseMat"/> class with the
        /// specified dimension sizes, element bit <paramref name="depth"/> and
        /// <paramref name="channels"/> per element.
        /// </summary>
        /// <param name="dimSizes">The size of each of the multi-dimensional array dimensions.</param>
        /// <param name="depth">The bit depth of matrix elements.</param>
        /// <param name="channels">The number of channels per element.</param>
        public CvSparseMat(int[] dimSizes, CvDepth depth, int channels)
            : this(NativeMethods.cvCreateSparseMat(dimSizes.Length, dimSizes, MatHelper.GetMatType(depth, channels)), true)
        {
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
                    return MatHelper.GetMatDepth(((_CvSparseMat*)handle.ToPointer())->type);
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
                    return MatHelper.GetMatChannels(((_CvSparseMat*)handle.ToPointer())->type);
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

        IntPtr GetNextSparseNode(ref _CvSparseMatIterator mat_iterator)
        {
            unsafe
            {
                if (mat_iterator.node->next != null)
                    return (IntPtr)(mat_iterator.node = mat_iterator.node->next);
                else
                {
                    int idx;
                    for (idx = ++mat_iterator.curidx; idx < mat_iterator.mat->hashsize; idx++)
                    {
                        var node = (_CvSparseNode*)mat_iterator.mat->hashtable[idx];
                        if (node != null)
                        {
                            mat_iterator.curidx = idx;
                            return (IntPtr)(mat_iterator.node = node);
                        }
                    }
                    return IntPtr.Zero;
                }
            }
        }

        /// <summary>
        /// Returns an <see cref="System.Collections.IEnumerable"/> that supports iteration over the element nodes
        /// of the sparse array.
        /// </summary>
        /// <returns>
        /// An <see cref="System.Collections.IEnumerable"/> that supports iteration over the element nodes
        /// of the sparse array.
        /// </returns>
        public IEnumerable<CvSparseNode> GetSparseNodes()
        {
            _CvSparseMatIterator iterator;
            for (var node = NativeMethods.cvInitSparseMatIterator(this, out iterator);
                 node != IntPtr.Zero;
                 node = GetNextSparseNode(ref iterator))
            {
                yield return new CvSparseNode(node, this);
            }
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
            NativeMethods.cvReleaseSparseMat(ref handle);
            return true;
        }
    }
}
