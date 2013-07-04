using OpenCV.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a Freeman chain where a polygon is specified as a sequence of steps in
    /// one of eight directions from a point origin.
    /// </summary>
    public class CvChain : CvSeq
    {
        /// <summary>
        /// Gets the origin of the Freeman chain.
        /// </summary>
        public CvPoint Origin
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
        /// Initializes a new <see cref="CvChain"/> instance from a compatible
        /// <see cref="CvSeq"/>.
        /// </summary>
        /// <param name="seq">A <see cref="CvSeq"/> instance representing a Freeman chain.</param>
        /// <returns>A new <see cref="CvChain"/> header for the specified <paramref name="seq"/>.</returns>
        public static CvChain FromCvSeq(CvSeq seq)
        {
            if (seq == null) return null;

            var chain = new CvChain();
            chain.SetOwnerStorage(seq.Storage);
            chain.SetHandle(seq.DangerousGetHandle());
            return chain;
        }
    }
}
