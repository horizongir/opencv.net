using OpenCV.Net.Native;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a collection of 8-bit unsigned integers.
    /// </summary>
    public class ByteCollection : CVHandle, IEnumerable<byte>
    {
        internal static readonly ByteCollection Null = new NullCollection();

        /// <summary>
        /// Initializes a new instance of the <see cref="ByteCollection"/> class.
        /// </summary>
        public ByteCollection()
            : this(true)
        {
            SetHandle(NativeMethods.cv_vector_char_new());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ByteCollection"/> class with
        /// the specified values.
        /// </summary>
        /// <param name="values">The values with which to initialize the collection.</param>
        public ByteCollection(params byte[] values)
            : this(true)
        {
            SetHandle(NativeMethods.cv_vector_char_new_array(values, (IntPtr)values.Length));
        }

        private ByteCollection(bool ownsHandle)
            : base(ownsHandle)
        {
        }

        /// <summary>
        /// Gets the number of elements in the <see cref="ByteCollection"/>.
        /// </summary>
        public int Count
        {
            get { return NativeMethods.cv_vector_char_size(this).ToInt32(); }
        }

        /// <summary>
        /// Copies all elements of the collection to an <see cref="Array"/>.
        /// </summary>
        /// <param name="array">
        /// The one-dimensional <see cref="Array"/> that is the destination of the
        /// elements copied from the collection.
        /// </param>
        public void CopyTo(byte[] array)
        {
            NativeMethods.cv_vector_char_copy(this, array);
        }

        /// <summary>
        /// Creates an array from the <see cref="ByteCollection"/>.
        /// </summary>
        /// <returns>An array that contains the elements from the collection.</returns>
        public byte[] ToArray()
        {
            var array = new byte[Count];
            CopyTo(array);
            return array;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<byte> GetEnumerator()
        {
            var iterator = NativeMethods.cv_vector_char_iterator_new(this);
            try
            {
                while (NativeMethods.cv_vector_char_iterator_hasNext(iterator))
                {
                    yield return NativeMethods.cv_vector_char_iterator_next(iterator);
                }
            }
            finally { NativeMethods.cv_vector_char_iterator_delete(iterator); }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Executes the code required to free the native <see cref="ByteCollection"/> handle.
        /// </summary>
        /// <returns>
        /// <b>true</b> if the handle is released successfully; otherwise, in the event of a
        /// catastrophic failure, <b>false</b>.
        /// </returns>
        protected override bool ReleaseHandle()
        {
            NativeMethods.cv_vector_char_delete(handle);
            return true;
        }

        class NullCollection : ByteCollection
        {
            internal NullCollection() : base(false) { }

            protected override bool ReleaseHandle()
            {
                return false;
            }
        }
    }
}
