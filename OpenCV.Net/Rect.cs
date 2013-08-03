using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents the offset and size of a rectangle.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    [TypeConverter(typeof(NumericAggregateConverter))]
    public struct Rect : IEquatable<Rect>
    {
        /// <summary>
        /// The x-coordinate of the top-left corner.
        /// </summary>
        public int X;

        /// <summary>
        /// The y-coordinate of the top-left corner (or bottom-left depending on image origin).
        /// </summary>
        public int Y;

        /// <summary>
        /// The width of the rectangle.
        /// </summary>
        public int Width;

        /// <summary>
        /// The height of the rectangle.
        /// </summary>
        public int Height;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rect"/> structure from the
        /// specified offset and dimensions.
        /// </summary>
        /// <param name="x">The x-coordinate of the top-left corner.</param>
        /// <param name="y">The y-coordinate of the top-left corner (or bottom-left depending on image origin).</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        public Rect(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Returns a hash code for this <see cref="Rect"/> structure.
        /// </summary>
        /// <returns>An integer value that specifies a hash value for this <see cref="Rect"/> structure.</returns>
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Width.GetHashCode() ^ Height.GetHashCode();
        }

        /// <summary>
        /// Tests to see whether the specified object is a <see cref="Rect"/> structure
        /// with the same offset and size as this <see cref="Rect"/> structure.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to test.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="obj"/> is a <see cref="Rect"/> and has the
        /// same offset and size as this <see cref="Rect"/>; otherwise, <b>false</b>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Rect)
            {
                return Equals((Rect)obj);
            }

            return false;
        }

        /// <summary>
        /// Returns a value indicating whether this instance has the same offset and size
        /// as a specified <see cref="Rect"/> structure.
        /// </summary>
        /// <param name="other">The <see cref="Rect"/> structure to compare to this instance.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="other"/> has the same offset and size as
        /// this instance; otherwise, <b>false</b>.
        /// </returns>
        public bool Equals(Rect other)
        {
            return X == other.X && Y == other.Y && Width == other.Width && Height == other.Height;
        }

        /// <summary>
        /// Tests whether two <see cref="Rect"/> structures are equal.
        /// </summary>
        /// <param name="left">The <see cref="Rect"/> structure on the left of the equality operator.</param>
        /// <param name="right">The <see cref="Rect"/> structure on the right of the equality operator.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> have equal offset and size;
        /// otherwise, <b>false</b>.
        /// </returns>
        public static bool operator ==(Rect left, Rect right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Tests whether two <see cref="Rect"/> structures are different.
        /// </summary>
        /// <param name="left">The <see cref="Rect"/> structure on the left of the inequality operator.</param>
        /// <param name="right">The <see cref="Rect"/> structure on the right of the inequality operator.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> differ in offset or size;
        /// <b>false</b> if <paramref name="left"/> and <paramref name="right"/> are equal.
        /// </returns>
        public static bool operator !=(Rect left, Rect right)
        {
            return !left.Equals(right);
        }
    }
}
