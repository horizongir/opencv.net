using OpenCV.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a polygonal contour.
    /// </summary>
    public class CvContour : CvSeq
    {
        /// <summary>
        /// Gets the size of the <see cref="CvContour"/> header, in bytes.
        /// </summary>
        public static new int HeaderSize
        {
            get { return SeqHelper.ContourHeaderSize; }
        }

        /// <summary>
        /// Gets the bounding rectangle of the contour.
        /// </summary>
        public CvRect Rect
        {
            get
            {
                unsafe
                {
                    return ((_CvContour*)handle.ToPointer())->rect;
                }
            }
        }

        /// <summary>
        /// Initializes a new <see cref="CvContour"/> instance from a compatible
        /// <see cref="CvSeq"/>.
        /// </summary>
        /// <param name="seq">A <see cref="CvSeq"/> instance representing a polygonal contour.</param>
        /// <returns>A new <see cref="CvContour"/> header for the specified <paramref name="seq"/>.</returns>
        public static CvContour FromCvSeq(CvSeq seq)
        {
            if (seq == null) return null;

            var contour = new CvContour();
            contour.SetOwnerStorage(seq.Storage);
            contour.SetHandle(seq.DangerousGetHandle());
            return contour;
        }
    }
}
