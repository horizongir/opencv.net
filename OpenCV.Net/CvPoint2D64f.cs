using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a 2D point with double-precision floating-point coordinates.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    [TypeConverter(typeof(NumericAggregateConverter))]
    public struct CvPoint2D64f : IEquatable<CvPoint2D64f>
    {
        /// <summary>
        /// Returns a <see cref="CvPoint2D64f"/> that has <see cref="X"/> and
        /// <see cref="Y"/> values set to zero.
        /// </summary>
        public static CvPoint2D64f Zero
        {
            get { return new CvPoint2D64f(); }
        }

        /// <summary>
        /// The x-coordinate of the point.
        /// </summary>
        public double X;

        /// <summary>
        /// The y-coordinate of the point.
        /// </summary>
        public double Y;

        /// <summary>
        /// Initializes a new instance of the <see cref="CvPoint2D64f"/> structure from the specified coordinates.
        /// </summary>
        /// <param name="x">The x-coordinate of the point.</param>
        /// <param name="y">The y-coordinate of the point.</param>
        public CvPoint2D64f(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvPoint2D64f"/> structure from the specified
        /// <see cref="CvPoint"/> structure.
        /// </summary>
        /// <param name="point">The <see cref="CvPoint"/> used to initialize this instance.</param>
        public CvPoint2D64f(CvPoint point)
        {
            X = point.X;
            Y = point.Y;
        }

        /// <summary>
        /// Returns a hash code for this <see cref="CvPoint2D64f"/> structure.
        /// </summary>
        /// <returns>An integer value that specifies a hash value for this <see cref="CvPoint2D64f"/> structure.</returns>
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        /// <summary>
        /// Tests to see whether the specified object is a <see cref="CvPoint2D64f"/> structure
        /// with the same coordinates as this <see cref="CvPoint2D64f"/> structure.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to test.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="obj"/> is a <see cref="CvPoint2D64f"/> and has the
        /// same X and Y coordinates as this <see cref="CvPoint2D64f"/>; otherwise, <b>false</b>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is CvPoint2D64f)
            {
                return Equals((CvPoint2D64f)obj);
            }

            return false;
        }

        /// <summary>
        /// Returns a value indicating whether this instance has the same coordinates
        /// as a specified <see cref="CvPoint2D64f"/> structure.
        /// </summary>
        /// <param name="other">The <see cref="CvPoint2D64f"/> structure to compare to this instance.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="other"/> has the same X and Y coordinates as
        /// this instance; otherwise, <b>false</b>.
        /// </returns>
        public bool Equals(CvPoint2D64f other)
        {
            return X == other.X && Y == other.Y;
        }

        /// <summary>
        /// Tests whether two <see cref="CvPoint2D64f"/> structures are equal.
        /// </summary>
        /// <param name="left">The <see cref="CvPoint2D64f"/> structure on the left of the equality operator.</param>
        /// <param name="right">The <see cref="CvPoint2D64f"/> structure on the right of the equality operator.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> have equal X and Y coordinates;
        /// otherwise, <b>false</b>.
        /// </returns>
        public static bool operator ==(CvPoint2D64f left, CvPoint2D64f right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Tests whether two <see cref="CvPoint2D64f"/> structures are different.
        /// </summary>
        /// <param name="left">The <see cref="CvPoint2D64f"/> structure on the left of the inequality operator.</param>
        /// <param name="right">The <see cref="CvPoint2D64f"/> structure on the right of the inequality operator.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> differ either in X or Y coordinates;
        /// <b>false</b> if <paramref name="left"/> and <paramref name="right"/> are equal.
        /// </returns>
        public static bool operator !=(CvPoint2D64f left, CvPoint2D64f right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Adds two <see cref="CvPoint2D64f"/> structures.
        /// </summary>
        /// <param name="left">The <see cref="CvPoint2D64f"/> structure on the left of the addition operator.</param>
        /// <param name="right">The <see cref="CvPoint2D64f"/> structure on the right of the addition operator.</param>
        /// <returns>
        /// The <see cref="CvPoint2D64f"/> that is the result of adding the <paramref name="left"/>
        /// and <paramref name="right"/> points.
        /// </returns>
        public static CvPoint2D64f operator +(CvPoint2D64f left, CvPoint2D64f right)
        {
            return new CvPoint2D64f(left.X + right.X, left.Y + right.Y);
        }

        /// <summary>
        /// Subtracts two <see cref="CvPoint2D64f"/> structures.
        /// </summary>
        /// <param name="left">The <see cref="CvPoint2D64f"/> structure on the left of the subtraction operator.</param>
        /// <param name="right">The <see cref="CvPoint2D64f"/> structure on the right of the subtraction operator.</param>
        /// <returns>
        /// The <see cref="CvPoint2D64f"/> that is the result of subtracting the <paramref name="left"/>
        /// and <paramref name="right"/> points.
        /// </returns>
        public static CvPoint2D64f operator -(CvPoint2D64f left, CvPoint2D64f right)
        {
            return new CvPoint2D64f(left.X - right.X, left.Y - right.Y);
        }

        /// <summary>
        /// Returns the inversion with respect to the origin of the specified <see cref="CvPoint2D64f"/> structure.
        /// </summary>
        /// <param name="point">The <see cref="CvPoint2D64f"/> structure for which to compute the inversion.</param>
        /// <returns>
        /// The <see cref="CvPoint2D64f"/> that is the result of inverting <paramref name="point"/> with
        /// respect to the origin.
        /// </returns>
        public static CvPoint2D64f operator -(CvPoint2D64f point)
        {
            return new CvPoint2D64f(-point.X, -point.Y);
        }

        /// <summary>
        /// Multiplies a <see cref="CvPoint2D64f"/> structure by an integer scalar.
        /// </summary>
        /// <param name="point">The <see cref="CvPoint2D64f"/> structure to multiply by the <paramref name="scalar"/>.</param>
        /// <param name="scalar">The scalar by which to multiply the <paramref name="point"/>.</param>
        /// <returns>
        /// The <see cref="CvPoint2D64f"/> that is the result of multiplying <paramref name="point"/> by
        /// <paramref name="scalar"/>.
        /// </returns>
        public static CvPoint2D64f operator *(CvPoint2D64f point, float scalar)
        {
            return new CvPoint2D64f(scalar * point.X, scalar * point.Y);
        }

        /// <summary>
        /// Multiplies a <see cref="CvPoint2D64f"/> structure by an integer scalar.
        /// </summary>
        /// <param name="scalar">The scalar by which to multiply the <paramref name="point"/>.</param>
        /// <param name="point">The <see cref="CvPoint2D64f"/> structure to multiply by the <paramref name="scalar"/>.</param>
        /// <returns>
        /// The <see cref="CvPoint2D64f"/> that is the result of multiplying <paramref name="point"/> by
        /// <paramref name="scalar"/>.
        /// </returns>
        public static CvPoint2D64f operator *(float scalar, CvPoint2D64f point)
        {
            return new CvPoint2D64f(scalar * point.X, scalar * point.Y);
        }
    }
}
