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
    public class Contour : Seq
    {
        /// <summary>
        /// Gets the size of the <see cref="Contour"/> header, in bytes.
        /// </summary>
        public static new int HeaderSize
        {
            get { return SeqHelper.ContourHeaderSize; }
        }

        /// <summary>
        /// Gets the bounding rectangle of the contour.
        /// </summary>
        public Rect Rect
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
        /// Initializes a new <see cref="Contour"/> instance from a compatible
        /// <see cref="Seq"/>.
        /// </summary>
        /// <param name="seq">A <see cref="Seq"/> instance representing a polygonal contour.</param>
        /// <returns>A new <see cref="Contour"/> header for the specified <paramref name="seq"/>.</returns>
        public static Contour FromSeq(Seq seq)
        {
            if (seq == null) return null;

            var contour = new Contour();
            contour.SetOwnerStorage(seq.Storage);
            contour.SetHandle(seq.DangerousGetHandle());
            return contour;
        }
    }
}
