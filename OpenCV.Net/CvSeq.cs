using Microsoft.Win32.SafeHandles;
using OpenCV.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a growable sequence of elements.
    /// </summary>
    public class CvSeq : SafeHandleZeroOrMinusOneIsInvalid
    {
        static readonly CvSeq Null = new CvSeqNull();
        CvMemStorage owner;

        internal CvSeq()
            : base(true)
        {
        }

        internal CvSeq(CvMemStorage storage)
            : base(true)
        {
            owner = storage;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvSeq"/> class with the specified
        /// element bit <paramref name="depth"/> and <paramref name="channels"/> per element.
        /// Memory for the sequence will be allocated from the provided <paramref name="storage"/>.
        /// </summary>
        /// <param name="depth">The bit depth of sequence elements.</param>
        /// <param name="channels">The number of channels per sequence element.</param>
        /// <param name="storage">The memory storage used to grow the sequence.</param>
        public CvSeq(CvDepth depth, int channels, CvMemStorage storage)
            : this(MatHelper.GetMatType(depth, channels), SequenceKind.Generic, SequenceFlags.Simple, storage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvSeq"/> class with the specified
        /// element bit <paramref name="depth"/>, <paramref name="channels"/> per element and
        /// sequence <paramref name="kind"/>.
        /// Memory for the sequence will be allocated from the provided <paramref name="storage"/>.
        /// </summary>
        /// <param name="depth">The bit depth of sequence elements.</param>
        /// <param name="channels">The number of channels per sequence element.</param>
        /// <param name="kind">The kind of sequence to create.</param>
        /// <param name="storage">The memory storage used to grow the sequence.</param>
        public CvSeq(CvDepth depth, int channels, SequenceKind kind, CvMemStorage storage)
            : this(MatHelper.GetMatType(depth, channels), kind, SequenceFlags.Simple, storage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvSeq"/> class with the specified
        /// element bit <paramref name="depth"/>, <paramref name="channels"/> per element,
        /// sequence <paramref name="kind"/> and operational <paramref name="flags"/>.
        /// Memory for the sequence will be allocated from the provided <paramref name="storage"/>.
        /// </summary>
        /// <param name="depth">The bit depth of sequence elements.</param>
        /// <param name="channels">The number of channels per sequence element.</param>
        /// <param name="kind">The kind of sequence to create.</param>
        /// <param name="flags">The operational flags for the sequence.</param>
        /// <param name="storage">The memory storage used to grow the sequence.</param>
        public CvSeq(CvDepth depth, int channels, SequenceKind kind, SequenceFlags flags, CvMemStorage storage)
            : this(MatHelper.GetMatType(depth, channels), kind, flags, storage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvSeq"/> class from a specified
        /// common element type. Memory for the sequence will be allocated from the
        /// provided <paramref name="storage"/>.
        /// </summary>
        /// <param name="elementType">The type of elements in the sequence.</param>
        /// <param name="storage">The memory storage used to grow the sequence.</param>
        public CvSeq(SequenceElementType elementType, CvMemStorage storage)
            : this((int)elementType, SequenceKind.Generic, SequenceFlags.Simple, storage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvSeq"/> class with the specified
        /// common element type and sequence <paramref name="kind"/>.
        /// Memory for the sequence will be allocated from the provided <paramref name="storage"/>.
        /// </summary>
        /// <param name="elementType">The type of elements in the sequence.</param>
        /// <param name="kind">The kind of sequence to create.</param>
        /// <param name="storage">The memory storage used to grow the sequence.</param>
        public CvSeq(SequenceElementType elementType, SequenceKind kind, CvMemStorage storage)
            : this((int)elementType, kind, SequenceFlags.Simple, storage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvSeq"/> class with the specified
        /// common element type, sequence <paramref name="kind"/> and operational <paramref name="flags"/>.
        /// Memory for the sequence will be allocated from the provided <paramref name="storage"/>.
        /// </summary>
        /// <param name="elementType">The type of elements in the sequence.</param>
        /// <param name="kind">The kind of sequence to create.</param>
        /// <param name="flags">The operational flags for the sequence.</param>
        /// <param name="storage">The memory storage used to grow the sequence.</param>
        public CvSeq(SequenceElementType elementType, SequenceKind kind, SequenceFlags flags, CvMemStorage storage)
            : this((int)elementType, kind, flags, storage)
        {
        }

        private CvSeq(int elementType, SequenceKind kind, SequenceFlags flags, CvMemStorage storage)
            : base(true)
        {
            owner = storage;
            var pSeq = NativeMethods.cvCreateSeq(elementType | (int)kind | (int)flags, SeqHelper.SeqHeaderSize, (UIntPtr)MatHelper.GetElemSize((int)elementType), storage);
            SetHandle(pSeq);
        }

        internal CvSeq(bool ownsHandle)
            : base(ownsHandle)
        {
        }

        /// <summary>
        /// Gets the <see cref="CvMemStorage"/> where the sequence is stored.
        /// </summary>
        public CvMemStorage Storage
        {
            get { return owner; }
        }

        /// <summary>
        /// Gets a <see cref="SequenceKind"/> value indicating the kind of the sequence.
        /// </summary>
        public SequenceKind Kind
        {
            get
            {
                unsafe
                {
                    return (SequenceKind)(((_CvSeq*)handle.ToPointer())->flags & SeqHelper.KindMask);
                }
            }
        }

        /// <summary>
        /// Gets the size of a sequence element in bytes.
        /// </summary>
        public int ElementSize
        {
            get
            {
                unsafe
                {
                    return ((_CvSeq*)handle.ToPointer())->elem_size;
                }
            }
        }

        /// <summary>
        /// Gets the total number of elements in the sequence.
        /// </summary>
        public int Count
        {
            get
            {
                unsafe
                {
                    return ((_CvSeq*)handle.ToPointer())->total;
                }
            }
        }

        /// <summary>
        /// Gets the previous sequence on the same hierarchical level.
        /// </summary>
        public CvSeq HorizontalPrevious
        {
            get
            {
                unsafe
                {
                    var pSeq = ((_CvSeq*)handle.ToPointer())->h_prev;
                    if (pSeq == IntPtr.Zero) return null;

                    var seq = new CvSeq(owner);
                    seq.SetHandle(pSeq);
                    return seq;
                }
            }
            set
            {
                unsafe
                {
                    var pSeq = value != null ? value.handle : IntPtr.Zero;
                    ((_CvSeq*)handle.ToPointer())->h_prev = pSeq;
                }
            }
        }

        /// <summary>
        /// Gets the next sequence on the same hierarchical level.
        /// </summary>
        public CvSeq HorizontalNext
        {
            get
            {
                unsafe
                {
                    var pSeq = ((_CvSeq*)handle.ToPointer())->h_next;
                    if (pSeq == IntPtr.Zero) return null;

                    var seq = new CvSeq(owner);
                    seq.SetHandle(pSeq);
                    return seq;
                }
            }
            set
            {
                unsafe
                {
                    var pSeq = value != null ? value.handle : IntPtr.Zero;
                    ((_CvSeq*)handle.ToPointer())->h_next = pSeq;
                }
            }
        }

        /// <summary>
        /// Gets the parent of the sequence in the hierarchy.
        /// </summary>
        public CvSeq VerticalPrevious
        {
            get
            {
                unsafe
                {
                    var pSeq = ((_CvSeq*)handle.ToPointer())->v_prev;
                    if (pSeq == IntPtr.Zero) return null;

                    var seq = new CvSeq(owner);
                    seq.SetHandle(pSeq);
                    return seq;
                }
            }
            set
            {
                unsafe
                {
                    var pSeq = value != null ? value.handle : IntPtr.Zero;
                    ((_CvSeq*)handle.ToPointer())->v_prev = pSeq;
                }
            }
        }

        /// <summary>
        /// Gets the first child of the sequence in the hierarchy.
        /// </summary>
        public CvSeq VerticalNext
        {
            get
            {
                unsafe
                {
                    var pSeq = ((_CvSeq*)handle.ToPointer())->v_next;
                    if (pSeq == IntPtr.Zero) return null;

                    var seq = new CvSeq(owner);
                    seq.SetHandle(pSeq);
                    return seq;
                }
            }
            set
            {
                unsafe
                {
                    var pSeq = value != null ? value.handle : IntPtr.Zero;
                    ((_CvSeq*)handle.ToPointer())->v_next = pSeq;
                }
            }
        }

        internal void SetOwnerStorage(CvMemStorage storage)
        {
            owner = storage;
        }

        /// <summary>
        /// Sets the sequence block size.
        /// </summary>
        /// <param name="blockSize">The memory block size by which to grow the sequence when free space has run out.</param>
        public void SetBlockSize(int blockSize)
        {
            NativeMethods.cvSetSeqBlockSize(this, blockSize);
        }

        private void PushMultiple<TElement>(TElement[] elements, bool inFront) where TElement : struct
        {
            var elementHandle = GCHandle.Alloc(elements, GCHandleType.Pinned);
            try
            {
                NativeMethods.cvSeqPushMulti(this, elementHandle.AddrOfPinnedObject(), elements.Length, inFront ? 1 : 0);
            }
            finally { elementHandle.Free(); }
        }

        /// <summary>
        /// Allocates space for one more element at the end of the sequence.
        /// </summary>
        public void Push()
        {
            NativeMethods.cvSeqPush(this, IntPtr.Zero);
        }

        /// <summary>
        /// Adds one or more elements to the end of the sequence.
        /// </summary>
        /// <typeparam name="TElement">The type of the elements in the sequence.</typeparam>
        /// <param name="elements">The array of elements to add to the end of the sequence.</param>
        public void Push<TElement>(params TElement[] elements) where TElement : struct
        {
            PushMultiple(elements, false);
        }

        /// <summary>
        /// Allocates space for one more element at the beginning of the sequence.
        /// </summary>
        public void PushFront()
        {
            NativeMethods.cvSeqPushFront(this, IntPtr.Zero);
        }

        /// <summary>
        /// Adds one or more elements to the beginning of the sequence.
        /// </summary>
        /// <typeparam name="TElement">The type of the elements in the sequence.</typeparam>
        /// <param name="elements">The array of elements to add to the beginning of the sequence.</param>
        public void PushFront<TElement>(params TElement[] elements) where TElement : struct
        {
            PushMultiple(elements, true);
        }

        private void PopMultiple<TElement>(TElement[] elements, bool inFront) where TElement : struct
        {
            var elementHandle = GCHandle.Alloc(elements, GCHandleType.Pinned);
            try
            {
                NativeMethods.cvSeqPopMulti(this, elementHandle.AddrOfPinnedObject(), elements.Length, inFront ? 1 : 0);
            }
            finally { elementHandle.Free(); }
        }

        /// <summary>
        /// Removes an element from the end of the sequence.
        /// </summary>
        public void Pop()
        {
            NativeMethods.cvSeqPop(this, IntPtr.Zero);
        }

        /// <summary>
        /// Removes an element from the end of the sequence.
        /// </summary>
        /// <typeparam name="TElement">The type of the elements in the sequence.</typeparam>
        /// <param name="element">
        /// When the method returns, contains the element that was removed from the end of the sequence.
        /// </param>
        public void Pop<TElement>(out TElement element) where TElement : struct
        {
            var result = new TElement[1];
            PopMultiple(result, false);
            element = result[0];
        }

        /// <summary>
        /// Removes several elements from the end of the sequence.
        /// </summary>
        /// <typeparam name="TElement">The type of the elements in the sequence.</typeparam>
        /// <param name="elements">The array that will contain the removed elements.</param>
        public void Pop<TElement>(TElement[] elements) where TElement : struct
        {
            PopMultiple(elements, false);
        }

        /// <summary>
        /// Removes an element from the beginning of the sequence.
        /// </summary>
        public void PopFront()
        {
            NativeMethods.cvSeqPopFront(this, IntPtr.Zero);
        }

        /// <summary>
        /// Removes an element from the beginning of the sequence.
        /// </summary>
        /// <typeparam name="TElement">The type of the elements in the sequence.</typeparam>
        /// <param name="element">
        /// When the method returns, contains the element that was removed from the beginning of the sequence.
        /// </param>
        public void PopFront<TElement>(out TElement element) where TElement : struct
        {
            var result = new TElement[1];
            PopMultiple(result, true);
            element = result[0];
        }

        /// <summary>
        /// Removes several elements from the beginning of the sequence.
        /// </summary>
        /// <typeparam name="TElement">The type of the elements in the sequence.</typeparam>
        /// <param name="elements">The array that will contain the removed elements.</param>
        public void PopFront<TElement>(TElement[] elements) where TElement : struct
        {
            PopMultiple(elements, true);
        }

        /// <summary>
        /// Inserts an element in the middle of the sequence.
        /// </summary>
        /// <typeparam name="TElement">The type of the elements in the sequence.</typeparam>
        /// <param name="index">The index before which the element is inserted.</param>
        /// <param name="element">The inserted element.</param>
        public void Insert<TElement>(int index, TElement element) where TElement : struct
        {
            var elementHandle = GCHandle.Alloc(element, GCHandleType.Pinned);
            try
            {
                NativeMethods.cvSeqInsert(this, index, elementHandle.AddrOfPinnedObject());
            }
            finally { elementHandle.Free(); }
        }

        /// <summary>
        /// Inserts a sequence in the middle of this sequence.
        /// </summary>
        /// <param name="index">The index at which to insert the sequence.</param>
        /// <param name="sequence">The inserted sequence.</param>
        public void Insert(int index, CvSeq sequence)
        {
            NativeMethods.cvSeqInsertSlice(this, index, sequence);
        }

        /// <summary>
        /// Inserts an array in the middle of the sequence.
        /// </summary>
        /// <param name="index">The index at which to insert the array.</param>
        /// <param name="array">The inserted array.</param>
        public void Insert(int index, CvArr array)
        {
            NativeMethods.cvSeqInsertSlice(this, index, array);
        }

        /// <summary>
        /// Removes an element from the middle of the sequence.
        /// </summary>
        /// <param name="index">The index of the removed element.</param>
        public void Remove(int index)
        {
            NativeMethods.cvSeqRemove(this, index);
        }

        /// <summary>
        /// Removes a sequence slice.
        /// </summary>
        /// <param name="slice">The part of the sequence to remove.</param>
        public void Remove(CvSlice slice)
        {
            NativeMethods.cvSeqRemoveSlice(this, slice);
        }

        /// <summary>
        /// Removes all elements from the sequence.
        /// </summary>
        public virtual void Clear()
        {
            NativeMethods.cvClearSeq(this);
        }

        /// <summary>
        /// Gets the pointer to the element at the specified index.
        /// </summary>
        /// <param name="index">The index of the element to retrieve.</param>
        /// <returns>A pointer to the element at the specified <paramref name="index"/>.</returns>
        public IntPtr GetElement(int index)
        {
            return NativeMethods.cvGetSeqElem(this, index);
        }

        /// <summary>
        /// Gets the index of the specified element.
        /// </summary>
        /// <param name="element">A pointer to the sequence element.</param>
        /// <returns>The index of the specified <paramref name="element"/>, or -1 if it is not found.</returns>
        public int GetElementIndex(IntPtr element)
        {
            return NativeMethods.cvSeqElemIdx(this, element, IntPtr.Zero);
        }

        /// <summary>
        /// Copies all the elements of the sequence to a compatible one-dimensional array.
        /// </summary>
        /// <typeparam name="TElement">The type of the elements in the sequence.</typeparam>
        /// <param name="array">The array on which to store sequence elements.</param>
        public void CopyTo<TElement>(TElement[] array) where TElement : struct
        {
            CopyTo(array, CvSlice.WholeSeq);
        }

        /// <summary>
        /// Copies part of the sequence elements to a compatible one-dimensional array.
        /// </summary>
        /// <typeparam name="TElement">The type of the elements in the sequence.</typeparam>
        /// <param name="array">The array on which to store sequence elements.</param>
        /// <param name="slice">The portion of the sequence to copy to the array.</param>
        public void CopyTo<TElement>(TElement[] array, CvSlice slice) where TElement : struct
        {
            var arrayHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
            try
            {
                NativeMethods.cvCvtSeqToArray(this, arrayHandle.AddrOfPinnedObject(), slice);
            }
            finally { arrayHandle.Free(); }
        }

        /// <summary>
        /// Copies the elements of the sequence to a new array.
        /// </summary>
        /// <typeparam name="TElement">The type of the elements in the sequence.</typeparam>
        /// <returns>A new array instance containing all the elements in the sequence.</returns>
        public TElement[] ToArray<TElement>() where TElement : struct
        {
            var array = new TElement[Count];
            CopyTo(array);
            return array;
        }

        /// <summary>
        /// Makes a separate header for a sequence slice.
        /// </summary>
        /// <param name="slice">The part of the sequence to be extracted.</param>
        /// <param name="storage">The storage block that will store the new sequence.</param>
        /// <param name="copyData">
        /// A value indicating whether to copy the elements of the extracted slice.
        /// </param>
        /// <returns>
        /// A new <see cref="CvSeq"/> instance containing the elements in the
        /// specified <paramref name="slice"/>.
        /// </returns>
        public CvSeq Slice(CvSlice slice, CvMemStorage storage = null, bool copyData = false)
        {
            storage = storage ?? owner;
            var seq = NativeMethods.cvSeqSlice(this, slice, storage, copyData ? 1 : 0);
            seq.SetOwnerStorage(storage);
            return seq;
        }

        /// <summary>
        /// Creates a copy of the sequence.
        /// </summary>
        /// <param name="storage">
        /// The destination <see cref="CvMemStorage"/> instance on which to store the new sequence.
        /// If <paramref name="storage"/> is <b>null</b>, the same memory storage of this sequence is used.
        /// </param>
        /// <returns>A new <see cref="CvSeq"/> instance that is a copy of this sequence.</returns>
        public CvSeq Clone(CvMemStorage storage = null)
        {
            return Slice(CvSlice.WholeSeq, storage, true);
        }

        /// <summary>
        /// Sorts sequence elements using the specified <paramref name="comparison"/> function.
        /// </summary>
        /// <typeparam name="TElement">The type of the elements in the sequence.</typeparam>
        /// <param name="comparison">
        /// The comparison function that returns negative, zero or positive value depending
        /// on the relationships among the elements.
        /// </param>
        public void Sort<TElement>(Comparison<TElement> comparison) where TElement : struct
        {
            NativeMethods.cvSeqSort(
                this,
                (a, b, userData) => comparison(
                    (TElement)Marshal.PtrToStructure(a, typeof(TElement)),
                    (TElement)Marshal.PtrToStructure(b, typeof(TElement))),
                IntPtr.Zero);
        }

        /// <summary>
        /// Searches for an element in a sequence.
        /// </summary>
        /// <typeparam name="TElement">The type of the elements in the sequence.</typeparam>
        /// <param name="element">The element to look for.</param>
        /// <param name="comparison">
        /// The comparison function that returns negative, zero or positive value depending
        /// on the relationships among the elements.
        /// </param>
        /// <param name="isSorted">A value indicating whether the sequence is sorted or not.</param>
        /// <returns>The index of the element in the sequence, or -1 if it is not found.</returns>
        public int Search<TElement>(TElement element, Comparison<TElement> comparison, bool isSorted) where TElement : struct
        {
            int index;
            var elementHandle = GCHandle.Alloc(element, GCHandleType.Pinned);
            try
            {
                var result = NativeMethods.cvSeqSearch(
                    this,
                    elementHandle.AddrOfPinnedObject(),
                    (a, b, userData) => comparison(
                        (TElement)Marshal.PtrToStructure(a, typeof(TElement)),
                        (TElement)Marshal.PtrToStructure(b, typeof(TElement))),
                    isSorted ? 1 : 0,
                    out index,
                    IntPtr.Zero);
                return result != IntPtr.Zero ? index : -1;
            }
            finally { elementHandle.Free(); }
        }

        /// <summary>
        /// Reverses the order of sequence elements.
        /// </summary>
        public void Invert()
        {
            NativeMethods.cvSeqInvert(this);
        }

        /// <summary>
        /// Splits a sequence into equivalence classes.
        /// </summary>
        /// <typeparam name="TElement">The type of the elements in the sequence.</typeparam>
        /// <param name="storage">The storage block to store the sequence of equivalence classes.</param>
        /// <param name="labels">
        /// When the method returns, contains the sequence of zero-based labels of sequence elements.
        /// </param>
        /// <param name="equalityComparison">
        /// The relation function that should return <b>true</b> if the two particular sequence
        /// elements are from the same class, and <b>false</b> otherwise. The partitioning algorithm
        /// uses the transitive closure of the relation function as an equivalence critria
        /// </param>
        /// <returns>The number of equivalence classes.</returns>
        public int Partition<TElement>(CvMemStorage storage, out CvSeq labels, Func<TElement, TElement, bool> equalityComparison)
        {
            storage = storage ?? owner;

            var classes = NativeMethods.cvSeqPartition(
                this,
                storage,
                out labels,
                (a, b, userData) => equalityComparison(
                        (TElement)Marshal.PtrToStructure(a, typeof(TElement)),
                        (TElement)Marshal.PtrToStructure(b, typeof(TElement))) ? 1 : 0,
                IntPtr.Zero);
            labels.SetOwnerStorage(storage);
            return classes;
        }

        /// <summary>
        /// Executes the code required to free the native <see cref="CvSeq"/> handle.
        /// </summary>
        /// <returns>
        /// <b>true</b> if the handle is released successfully; otherwise, in the event of a
        /// catastrophic failure, <b>false</b>.
        /// </returns>
        protected override bool ReleaseHandle()
        {
            SetHandleAsInvalid();
            owner = null;
            return true;
        }

        class CvSeqNull : CvSeq
        {
            public CvSeqNull() : base(false) { }

            protected override bool ReleaseHandle()
            {
                return false;
            }
        }
    }
}
