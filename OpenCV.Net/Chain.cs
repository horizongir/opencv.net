using OpenCV.Net.Native;
using System.Collections.Generic;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a Freeman chain where a polygon is specified as a sequence of steps in
    /// one of eight directions from a point origin.
    /// </summary>
    public class Chain : Seq
    {
        /// <summary>
        /// Gets the size of the <see cref="Chain"/> header, in bytes.
        /// </summary>
        public static new int HeaderSize
        {
            get { return SeqHelper.ChainHeaderSize; }
        }

        /// <summary>
        /// Gets the origin of the Freeman chain.
        /// </summary>
        public Point Origin
        {
            get
            {
                unsafe
                {
                    return ((_CvChain*)handle.ToPointer())->origin;
                }
            }
        }

        /// <summary>
        /// Initializes a new <see cref="Chain"/> instance from a compatible
        /// <see cref="Seq"/>.
        /// </summary>
        /// <param name="seq">A <see cref="Seq"/> instance representing a Freeman chain.</param>
        /// <returns>A new <see cref="Chain"/> header for the specified <paramref name="seq"/>.</returns>
        public static Chain FromSeq(Seq seq)
        {
            if (seq == null) return null;

            var chain = new Chain();
            chain.SetOwnerStorage(seq.Storage);
            chain.SetHandle(seq.DangerousGetHandle());
            return chain;
        }

        /// <summary>
        /// Translates in sequence all of the points in the Freeman chain code.
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerable{Point}"/> whose elements are the result of translating
        /// the Freeman chain code into points.
        /// </returns>
        public IEnumerable<Point> ReadChainPoints()
        {
            _CvChainPtReader reader;
            NativeMethods.cvStartReadChainPoints(this, out reader);

            for (int i = 0; i < Count; i++)
            {
                yield return NativeMethods.cvReadChainPoint(ref reader);
            }
        }
    }
}
