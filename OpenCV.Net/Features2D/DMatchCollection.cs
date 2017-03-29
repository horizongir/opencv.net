using OpenCV.Net.Native;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a collection of image keypoint descriptor matches computed
    /// by one of the available descriptor matchers.
    /// </summary>
    public class DMatchCollection : CVHandle, IEnumerable<DMatch>
    {
        internal static readonly DMatchCollection Null = new NullCollection();

        /// <summary>
        /// Initializes a new instance of the <see cref="DMatchCollection"/> class.
        /// </summary>
        public DMatchCollection()
            : this(true)
        {
            SetHandle(NativeMethods.cv_vector_DMatch_new());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DMatchCollection"/> class
        /// with the specified set of keypoint descriptor matches.
        /// </summary>
        /// <param name="values">
        /// The set of keypoint descriptor matches with which to initialize the collection.
        /// </param>
        public DMatchCollection(params DMatch[] values)
            : this(true)
        {
            SetHandle(NativeMethods.cv_vector_DMatch_new_array(values, (IntPtr)values.Length));
        }

        private DMatchCollection(bool ownsHandle)
            : base(ownsHandle)
        {
        }

        /// <summary>
        /// Gets the number of elements in the <see cref="DMatchCollection"/>.
        /// </summary>
        public int Count
        {
            get { return NativeMethods.cv_vector_DMatch_size(this).ToInt32(); }
        }

        /// <summary>
        /// Copies all elements of the collection to an <see cref="Array"/>.
        /// </summary>
        /// <param name="array">
        /// The one-dimensional <see cref="Array"/> that is the destination of the
        /// elements copied from the collection.
        /// </param>
        public void CopyTo(DMatch[] array)
        {
            NativeMethods.cv_vector_DMatch_copy(this, array);
        }

        /// <summary>
        /// Creates an array from the <see cref="DMatchCollection"/>.
        /// </summary>
        /// <returns>An array that contains the elements from the collection.</returns>
        public DMatch[] ToArray()
        {
            var array = new DMatch[Count];
            CopyTo(array);
            return array;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<DMatch> GetEnumerator()
        {
            var iterator = NativeMethods.cv_vector_DMatch_iterator_new(this);
            try
            {
                while (NativeMethods.cv_vector_DMatch_iterator_hasNext(iterator))
                {
                    yield return NativeMethods.cv_vector_DMatch_iterator_next(iterator);
                }
            }
            finally { NativeMethods.cv_vector_DMatch_iterator_delete(iterator); }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Executes the code required to free the native <see cref="DMatchCollection"/> handle.
        /// </summary>
        /// <returns>
        /// <b>true</b> if the handle is released successfully; otherwise, in the event of a
        /// catastrophic failure, <b>false</b>.
        /// </returns>
        protected override bool ReleaseHandle()
        {
            NativeMethods.cv_vector_DMatch_delete(handle);
            return true;
        }

        class NullCollection : DMatchCollection
        {
            internal NullCollection() : base(false) { }

            protected override bool ReleaseHandle()
            {
                return false;
            }
        }
    }
}
