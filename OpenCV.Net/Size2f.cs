using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents the sub-pixel accurate size of a rectangle.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    [TypeConverter(typeof(NumericAggregateConverter))]
    public struct Size2f : IEquatable<Size2f>
    {
        /// <summary>
        /// The width of the rectangle.
        /// </summary>
        public float Width;

        /// <summary>
        /// The height of the rectangle.
        /// </summary>
        public float Height;

        /// <summary>
        /// Initializes a new instance of the <see cref="Size2f"/> structure from the specified dimensions.
        /// </summary>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        public Size2f(float width, float height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Returns a hash code for this <see cref="Size2f"/> structure.
        /// </summary>
        /// <returns>An integer value that specifies a hash value for this <see cref="Size2f"/> structure.</returns>
        public override int GetHashCode()
        {
            return Width.GetHashCode() ^ Height.GetHashCode();
        }

        /// <summary>
        /// Tests to see whether the specified object is a <see cref="Size2f"/> structure
        /// with the same dimensions as this <see cref="Size2f"/> structure.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to test.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="obj"/> is a <see cref="Size2f"/> and has the
        /// same width and height as this <see cref="Size2f"/>; otherwise, <b>false</b>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Size2f)
            {
                return Equals((Size2f)obj);
            }

            return false;
        }

        /// <summary>
        /// Returns a value indicating whether this instance has the same dimensions
        /// as a specified <see cref="Size2f"/> structure.
        /// </summary>
        /// <param name="other">The <see cref="Size2f"/> structure to compare to this instance.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="other"/> has the same width and height as
        /// this instance; otherwise, <b>false</b>.
        /// </returns>
        public bool Equals(Size2f other)
        {
            return Width == other.Width && Height == other.Height;
        }

        /// <summary>
        /// Creates a <see cref="String"/> representation of this <see cref="Size2f"/>
        /// structure.
        /// </summary>
        /// <returns>
        /// A <see cref="String"/> containing the <see cref="Width"/> and <see cref="Height"/>
        /// values of this <see cref="Size2f"/> structure.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{{Width={0}, Height={1}}}", Width, Height);
        }

        /// <summary>
        /// Tests whether two <see cref="Size2f"/> structures are equal.
        /// </summary>
        /// <param name="left">The <see cref="Size2f"/> structure on the left of the equality operator.</param>
        /// <param name="right">The <see cref="Size2f"/> structure on the right of the equality operator.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> have equal width and height;
        /// otherwise, <b>false</b>.
        /// </returns>
        public static bool operator ==(Size2f left, Size2f right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Tests whether two <see cref="Size2f"/> structures are different.
        /// </summary>
        /// <param name="left">The <see cref="Size2f"/> structure on the left of the inequality operator.</param>
        /// <param name="right">The <see cref="Size2f"/> structure on the right of the inequality operator.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> differ either in width or height;
        /// <b>false</b> if <paramref name="left"/> and <paramref name="right"/> are equal.
        /// </returns>
        public static bool operator !=(Size2f left, Size2f right)
        {
            return !left.Equals(right);
        }
    }
}
