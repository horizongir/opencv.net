using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents the pixel-accurate size of a rectangle.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    [TypeConverter(typeof(NumericAggregateConverter))]
    public struct CvSize : IEquatable<CvSize>
    {
        /// <summary>
        /// Returns a <see cref="CvSize"/> that has <see cref="Width"/> and
        /// <see cref="Height"/> values set to zero.
        /// </summary>
        public static CvSize Zero
        {
            get { return new CvSize(); }
        }

        /// <summary>
        /// The width of the rectangle.
        /// </summary>
        public int Width;

        /// <summary>
        /// The height of the rectangle.
        /// </summary>
        public int Height;

        /// <summary>
        /// Initializes a new instance of the <see cref="CvSize"/> structure from the specified dimensions.
        /// </summary>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        public CvSize(int width, int height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Returns a hash code for this <see cref="CvSize"/> structure.
        /// </summary>
        /// <returns>An integer value that specifies a hash value for this <see cref="CvSize"/> structure.</returns>
        public override int GetHashCode()
        {
            return Width.GetHashCode() ^ Height.GetHashCode();
        }

        /// <summary>
        /// Tests to see whether the specified object is a <see cref="CvSize"/> structure
        /// with the same dimensions as this <see cref="CvSize"/> structure.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to test.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="obj"/> is a <see cref="CvSize"/> and has the
        /// same width and height as this <see cref="CvSize"/>; otherwise, <b>false</b>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is CvSize)
            {
                return Equals((CvSize)obj);
            }

            return false;
        }

        /// <summary>
        /// Returns a value indicating whether this instance has the same dimensions
        /// as a specified <see cref="CvSize"/> structure.
        /// </summary>
        /// <param name="other">The <see cref="CvSize"/> structure to compare to this instance.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="other"/> has the same width and height as
        /// this instance; otherwise, <b>false</b>.
        /// </returns>
        public bool Equals(CvSize other)
        {
            return Width == other.Width && Height == other.Height;
        }

        /// <summary>
        /// Tests whether two <see cref="CvSize"/> structures are equal.
        /// </summary>
        /// <param name="left">The <see cref="CvSize"/> structure on the left of the equality operator.</param>
        /// <param name="right">The <see cref="CvSize"/> structure on the right of the equality operator.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> have equal width and height;
        /// otherwise, <b>false</b>.
        /// </returns>
        public static bool operator ==(CvSize left, CvSize right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Tests whether two <see cref="CvSize"/> structures are different.
        /// </summary>
        /// <param name="left">The <see cref="CvSize"/> structure on the left of the inequality operator.</param>
        /// <param name="right">The <see cref="CvSize"/> structure on the right of the inequality operator.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> differ either in width or height;
        /// <b>false</b> if <paramref name="left"/> and <paramref name="right"/> are equal.
        /// </returns>
        public static bool operator !=(CvSize left, CvSize right)
        {
            return !left.Equals(right);
        }
    }
}
