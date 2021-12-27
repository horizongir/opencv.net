using OpenCV.Net.Native;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a collection of nodes.
    /// </summary>
    public class Set : Seq
    {
        internal Set()
        {
        }

        private Set(int elementType, SequenceKind kind, SequenceFlags flags, MemStorage storage)
            : base(storage)
        {
            var pSet = NativeMethods.cvCreateSet(elementType | (int)kind | (int)flags, SeqHelper.SetHeaderSize, MatHelper.GetElemSize(elementType), storage);
            SetHandle(pSet);
        }

        /// <summary>
        /// Gets the size of the <see cref="Set"/> header, in bytes.
        /// </summary>
        public static new int HeaderSize
        {
            get { return SeqHelper.SetHeaderSize; }
        }

        /// <summary>
        /// Removes all elements from the set.
        /// </summary>
        public override void Clear()
        {
            NativeMethods.cvClearSet(this);
        }
    }
}
