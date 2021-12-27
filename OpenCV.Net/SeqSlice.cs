using OpenCV.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a sequence slice.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SeqSlice
    {
        /// <summary>
        /// An index value that represents the end of the whole sequence.
        /// </summary>
        public const int WholeSeqEndIndex = 0x3fffffff;

        /// <summary>
        /// Returns a <see cref="SeqSlice"/> that is set to encompass the whole sequence.
        /// </summary>
        public static SeqSlice WholeSeq
        {
            get { return new SeqSlice(0, WholeSeqEndIndex); }
        }

        /// <summary>
        /// The inclusive start index of the slice.
        /// </summary>
        public int StartIndex;

        /// <summary>
        /// The exclusive end index boundary of the slice.
        /// </summary>
        public int EndIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="SeqSlice"/> structure from
        /// the specified start and end indices.
        /// </summary>
        /// <param name="start">The inclusive start index of the slice.</param>
        /// <param name="end">The exclusive end index boundary of the slice.</param>
        public SeqSlice(int start, int end)
        {
            StartIndex = start;
            EndIndex = end;
        }

        /// <summary>
        /// Calculates the number of elements in the slice for a specified sequence.
        /// </summary>
        /// <param name="seq">The sequence on which to compute the slice length.</param>
        /// <returns>The number of elements in the slice for the specified sequence.</returns>
        public int SliceLength(Seq seq)
        {
            return NativeMethods.cvSliceLength(this, seq);
        }
    }
}
