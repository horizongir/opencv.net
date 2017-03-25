using OpenCV.Net.Native;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a collection of 2D points with single-precision floating point coordinates.
    /// </summary>
    public class Point2fCollection : CVHandle, IEnumerable<Point2f>
    {
        internal static readonly Point2fCollection Null = new NullCollection();

        /// <summary>
        /// Initializes a new instance of the <see cref="Point2fCollection"/> class.
        /// </summary>
        public Point2fCollection()
            : this(true)
        {
            SetHandle(NativeMethods.cv_vector_Point2f_new());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point2fCollection"/> class
        /// with the specified points.
        /// </summary>
        /// <param name="values">The points with which to initialize the collection.</param>
        public Point2fCollection(params Point2f[] values)
            : this(true)
        {
            SetHandle(NativeMethods.cv_vector_Point2f_new_array(values, (IntPtr)values.Length));
        }

        private Point2fCollection(bool ownsHandle)
            : base(ownsHandle)
        {
        }

        /// <summary>
        /// Gets the number of elements in the <see cref="Point2fCollection"/>.
        /// </summary>
        public int Count
        {
            get { return NativeMethods.cv_vector_Point2f_size(this).ToInt32(); }
        }

        /// <summary>
        /// Copies all elements of the collection to an <see cref="Array"/>.
        /// </summary>
        /// <param name="array">
        /// The one-dimensional <see cref="Array"/> that is the destination of the
        /// elements copied from the collection.
        /// </param>
        public void CopyTo(Point2f[] array)
        {
            NativeMethods.cv_vector_Point2f_copy(this, array);
        }

        /// <summary>
        /// Creates an array from the <see cref="Point2fCollection"/>.
        /// </summary>
        /// <returns>An array that contains the elements from the collection.</returns>
        public Point2f[] ToArray()
        {
            var array = new Point2f[Count];
            CopyTo(array);
            return array;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<Point2f> GetEnumerator()
        {
            var iterator = NativeMethods.cv_vector_Point2f_iterator_new(this);
            try
            {
                while (NativeMethods.cv_vector_Point2f_iterator_hasNext(iterator))
                {
                    yield return NativeMethods.cv_vector_Point2f_iterator_next(iterator);
                }
            }
            finally { NativeMethods.cv_vector_Point2f_iterator_delete(iterator); }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Executes the code required to free the native <see cref="Point2fCollection"/> handle.
        /// </summary>
        /// <returns>
        /// <b>true</b> if the handle is released successfully; otherwise, in the event of a
        /// catastrophic failure, <b>false</b>.
        /// </returns>
        protected override bool ReleaseHandle()
        {
            NativeMethods.cv_vector_Point2f_delete(handle);
            return true;
        }

        class NullCollection : Point2fCollection
        {
            internal NullCollection() : base(false) { }

            protected override bool ReleaseHandle()
            {
                return false;
            }
        }
    }
}
