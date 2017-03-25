using OpenCV.Net.Native;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a collection of image point features found by one of the available keypoint detectors.
    /// </summary>
    public class KeyPointCollection : CVHandle, IEnumerable<KeyPoint>
    {
        internal static readonly KeyPointCollection Null = new NullCollection();

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyPointCollection"/> class.
        /// </summary>
        public KeyPointCollection()
            : this(true)
        {
            SetHandle(NativeMethods.cv_vector_KeyPoint_new());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyPointCollection"/> class
        /// with the specified set of keypoints.
        /// </summary>
        /// <param name="values">The set of keypoints with which to initialize the collection.</param>
        public KeyPointCollection(params KeyPoint[] values)
            : this(true)
        {
            SetHandle(NativeMethods.cv_vector_KeyPoint_new_array(values, (IntPtr)values.Length));
        }

        private KeyPointCollection(bool ownsHandle)
            : base(ownsHandle)
        {
        }

        /// <summary>
        /// Gets the number of elements in the <see cref="KeyPointCollection"/>.
        /// </summary>
        public int Count
        {
            get { return NativeMethods.cv_vector_KeyPoint_size(this).ToInt32(); }
        }

        /// <summary>
        /// Copies all elements of the collection to an <see cref="Array"/>.
        /// </summary>
        /// <param name="array">
        /// The one-dimensional <see cref="Array"/> that is the destination of the
        /// elements copied from the collection.
        /// </param>
        public void CopyTo(KeyPoint[] array)
        {
            NativeMethods.cv_vector_KeyPoint_copy(this, array);
        }

        /// <summary>
        /// Creates an array from the <see cref="KeyPointCollection"/>.
        /// </summary>
        /// <returns>An array that contains the elements from the collection.</returns>
        public KeyPoint[] ToArray()
        {
            var array = new KeyPoint[Count];
            CopyTo(array);
            return array;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<KeyPoint> GetEnumerator()
        {
            var iterator = NativeMethods.cv_vector_KeyPoint_iterator_new(this);
            try
            {
                while (NativeMethods.cv_vector_KeyPoint_iterator_hasNext(iterator))
                {
                    yield return NativeMethods.cv_vector_KeyPoint_iterator_next(iterator);
                }
            }
            finally { NativeMethods.cv_vector_KeyPoint_iterator_delete(iterator); }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Executes the code required to free the native <see cref="KeyPointCollection"/> handle.
        /// </summary>
        /// <returns>
        /// <b>true</b> if the handle is released successfully; otherwise, in the event of a
        /// catastrophic failure, <b>false</b>.
        /// </returns>
        protected override bool ReleaseHandle()
        {
            NativeMethods.cv_vector_KeyPoint_delete(handle);
            return true;
        }

        class NullCollection : KeyPointCollection
        {
            internal NullCollection() : base(false) { }

            protected override bool ReleaseHandle()
            {
                return false;
            }
        }
    }
}
