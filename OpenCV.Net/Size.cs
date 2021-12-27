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
    public struct Size : IEquatable<Size>
    {
        /// <summary>
        /// Returns a <see cref="Size"/> that has <see cref="Width"/> and
        /// <see cref="Height"/> values set to zero.
        /// </summary>
        public static Size Zero
        {
            get { return new Size(); }
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
        /// Initializes a new instance of the <see cref="Size"/> structure from the specified dimensions.
        /// </summary>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Returns a hash code for this <see cref="Size"/> structure.
        /// </summary>
        /// <returns>An integer value that specifies a hash value for this <see cref="Size"/> structure.</returns>
        public override int GetHashCode()
        {
            return Width.GetHashCode() ^ Height.GetHashCode();
        }

        /// <summary>
        /// Tests to see whether the specified object is a <see cref="Size"/> structure
        /// with the same dimensions as this <see cref="Size"/> structure.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to test.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="obj"/> is a <see cref="Size"/> and has the
        /// same width and height as this <see cref="Size"/>; otherwise, <b>false</b>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Size)
            {
                return Equals((Size)obj);
            }

            return false;
        }

        /// <summary>
        /// Returns a value indicating whether this instance has the same dimensions
        /// as a specified <see cref="Size"/> structure.
        /// </summary>
        /// <param name="other">The <see cref="Size"/> structure to compare to this instance.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="other"/> has the same width and height as
        /// this instance; otherwise, <b>false</b>.
        /// </returns>
        public bool Equals(Size other)
        {
            return Width == other.Width && Height == other.Height;
        }

        /// <summary>
        /// Creates a <see cref="String"/> representation of this <see cref="Size"/>
        /// structure.
        /// </summary>
        /// <returns>
        /// A <see cref="String"/> containing the <see cref="Width"/> and <see cref="Height"/>
        /// values of this <see cref="Size"/> structure.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{{Width={0}, Height={1}}}", Width, Height);
        }

        /// <summary>
        /// Tests whether two <see cref="Size"/> structures are equal.
        /// </summary>
        /// <param name="left">The <see cref="Size"/> structure on the left of the equality operator.</param>
        /// <param name="right">The <see cref="Size"/> structure on the right of the equality operator.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> have equal width and height;
        /// otherwise, <b>false</b>.
        /// </returns>
        public static bool operator ==(Size left, Size right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Tests whether two <see cref="Size"/> structures are different.
        /// </summary>
        /// <param name="left">The <see cref="Size"/> structure on the left of the inequality operator.</param>
        /// <param name="right">The <see cref="Size"/> structure on the right of the inequality operator.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> differ either in width or height;
        /// <b>false</b> if <paramref name="left"/> and <paramref name="right"/> are equal.
        /// </returns>
        public static bool operator !=(Size left, Size right)
        {
            return !left.Equals(right);
        }

        internal static void Broadcast(ref Size left, ref Size right)
        {
            if (left.Width != right.Width)
            {
                if (left.Width == 1) left.Width = right.Width;
                else if (right.Width == 1) right.Width = left.Width;
                else throw new ArgumentException("Operand width cannot be broadcast together.", "right");
            }

            if (left.Height != right.Height)
            {
                if (left.Height == 1) left.Height = right.Height;
                else if (right.Height == 1) right.Height = left.Height;
                else throw new ArgumentException("Operand height cannot be broadcast together.", "right");
            }
        }
    }
}
