using System;
using System.Runtime.InteropServices;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a possibly rotated rectangle.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RotatedRect : IEquatable<RotatedRect>
    {
        /// <summary>
        /// The mass center of the rectangle.
        /// </summary>
        public Point2f Center;

        /// <summary>
        /// The size of the rectangle.
        /// </summary>
        public Size2f Size;

        /// <summary>
        /// The rotation angle of the rectangle in degrees.
        /// </summary>
        public float Angle;

        /// <summary>
        /// Initializes a new instance of the <see cref="RotatedRect"/> structure with the
        /// specified center, size and rotation angle.
        /// </summary>
        /// <param name="center">The coordinates of the mass center of the rectangle.</param>
        /// <param name="size">The size of the rectangle.</param>
        /// <param name="angle">The rotation angle of the rectangle in degrees.</param>
        public RotatedRect(Point2f center, Size2f size, float angle)
        {
            Center = center;
            Size = size;
            Angle = angle;
        }

        /// <summary>
        /// Returns a hash code for this <see cref="RotatedRect"/> structure.
        /// </summary>
        /// <returns>An integer value that specifies a hash value for this <see cref="RotatedRect"/> structure.</returns>
        public override int GetHashCode()
        {
            return Center.GetHashCode() ^ Size.GetHashCode() ^ Angle.GetHashCode();
        }

        /// <summary>
        /// Tests to see whether the specified object is a <see cref="RotatedRect"/> structure
        /// with the same center, size and rotation angle as this <see cref="RotatedRect"/> structure.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to test.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="obj"/> is a <see cref="RotatedRect"/> and has the same
        /// center, size and rotation angle as this <see cref="RotatedRect"/>; otherwise, <b>false</b>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is RotatedRect)
            {
                return Equals((RotatedRect)obj);
            }

            return false;
        }

        /// <summary>
        /// Returns a value indicating whether this instance has the same center, size and rotation angle
        /// as a specified <see cref="RotatedRect"/> structure.
        /// </summary>
        /// <param name="other">The <see cref="RotatedRect"/> structure to compare to this instance.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="other"/> has the same center, size and rotation angle as
        /// this instance; otherwise, <b>false</b>.
        /// </returns>
        public bool Equals(RotatedRect other)
        {
            return Center == other.Center && Size == other.Size && Angle == other.Angle;
        }

        /// <summary>
        /// Creates a <see cref="String"/> representation of this <see cref="RotatedRect"/>
        /// structure.
        /// </summary>
        /// <returns>
        /// A <see cref="String"/> containing the center, size and rotation angle of this
        /// <see cref="RotatedRect"/> structure.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{{Center={0}, Size={1}, Angle={2}}}", Center, Size, Angle);
        }

        /// <summary>
        /// Tests whether two <see cref="RotatedRect"/> structures are equal.
        /// </summary>
        /// <param name="left">The <see cref="RotatedRect"/> structure on the left of the equality operator.</param>
        /// <param name="right">The <see cref="RotatedRect"/> structure on the right of the equality operator.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> have equal center, size and
        /// rotation angle; otherwise, <b>false</b>.
        /// </returns>
        public static bool operator ==(RotatedRect left, RotatedRect right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Tests whether two <see cref="RotatedRect"/> structures are different.
        /// </summary>
        /// <param name="left">The <see cref="RotatedRect"/> structure on the left of the inequality operator.</param>
        /// <param name="right">The <see cref="RotatedRect"/> structure on the right of the inequality operator.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> differ in center, size or
        /// rotation angle; <b>false</b> if <paramref name="left"/> and <paramref name="right"/> are equal.
        /// </returns>
        public static bool operator !=(RotatedRect left, RotatedRect right)
        {
            return !left.Equals(right);
        }
    }
}
