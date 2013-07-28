using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a 2D point with integer coordinates (usually zero-based).
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    [TypeConverter(typeof(NumericAggregateConverter))]
    public struct CvPoint : IEquatable<CvPoint>
    {
        /// <summary>
        /// Returns a <see cref="CvPoint"/> that has <see cref="X"/> and
        /// <see cref="Y"/> values set to zero.
        /// </summary>
        public static CvPoint Zero
        {
            get { return new CvPoint(); }
        }

        /// <summary>
        /// The x-coordinate of the point.
        /// </summary>
        public int X;

        /// <summary>
        /// The y-coordinate of the point.
        /// </summary>
        public int Y;

        /// <summary>
        /// Initializes a new instance of the <see cref="CvPoint"/> structure from the specified coordinates.
        /// </summary>
        /// <param name="x">The x-coordinate of the point.</param>
        /// <param name="y">The y-coordinate of the point.</param>
        public CvPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvPoint"/> structure from the specified
        /// <see cref="CvPoint2D32f"/> structure.
        /// </summary>
        /// <param name="point">The <see cref="CvPoint2D32f"/> used to initialize this instance by rounding.</param>
        public CvPoint(CvPoint2D32f point)
        {
            X = (int)Math.Round(point.X);
            Y = (int)Math.Round(point.Y);
        }

        /// <summary>
        /// Returns a hash code for this <see cref="CvPoint"/> structure.
        /// </summary>
        /// <returns>An integer value that specifies a hash value for this <see cref="CvPoint"/> structure.</returns>
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        /// <summary>
        /// Tests to see whether the specified object is a <see cref="CvPoint"/> structure
        /// with the same coordinates as this <see cref="CvPoint"/> structure.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to test.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="obj"/> is a <see cref="CvPoint"/> and has the
        /// same X and Y coordinates as this <see cref="CvPoint"/>; otherwise, <b>false</b>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is CvPoint)
            {
                return Equals((CvPoint)obj);
            }

            return false;
        }

        /// <summary>
        /// Returns a value indicating whether this instance has the same coordinates
        /// as a specified <see cref="CvPoint"/> structure.
        /// </summary>
        /// <param name="other">The <see cref="CvPoint"/> structure to compare to this instance.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="other"/> has the same X and Y coordinates as
        /// this instance; otherwise, <b>false</b>.
        /// </returns>
        public bool Equals(CvPoint other)
        {
            return X == other.X && Y == other.Y;
        }

        /// <summary>
        /// Tests whether two <see cref="CvPoint"/> structures are equal.
        /// </summary>
        /// <param name="left">The <see cref="CvPoint"/> structure on the left of the equality operator.</param>
        /// <param name="right">The <see cref="CvPoint"/> structure on the right of the equality operator.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> have equal X and Y coordinates;
        /// otherwise, <b>false</b>.
        /// </returns>
        public static bool operator ==(CvPoint left, CvPoint right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Tests whether two <see cref="CvPoint"/> structures are different.
        /// </summary>
        /// <param name="left">The <see cref="CvPoint"/> structure on the left of the inequality operator.</param>
        /// <param name="right">The <see cref="CvPoint"/> structure on the right of the inequality operator.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> differ either in X or Y coordinates;
        /// <b>false</b> if <paramref name="left"/> and <paramref name="right"/> are equal.
        /// </returns>
        public static bool operator !=(CvPoint left, CvPoint right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Adds two <see cref="CvPoint"/> structures.
        /// </summary>
        /// <param name="left">The <see cref="CvPoint"/> structure on the left of the addition operator.</param>
        /// <param name="right">The <see cref="CvPoint"/> structure on the right of the addition operator.</param>
        /// <returns>
        /// The <see cref="CvPoint"/> that is the result of adding the <paramref name="left"/>
        /// and <paramref name="right"/> points.
        /// </returns>
        public static CvPoint operator +(CvPoint left, CvPoint right)
        {
            return new CvPoint(left.X + right.X, left.Y + right.Y);
        }

        /// <summary>
        /// Subtracts two <see cref="CvPoint"/> structures.
        /// </summary>
        /// <param name="left">The <see cref="CvPoint"/> structure on the left of the subtraction operator.</param>
        /// <param name="right">The <see cref="CvPoint"/> structure on the right of the subtraction operator.</param>
        /// <returns>
        /// The <see cref="CvPoint"/> that is the result of subtracting the <paramref name="left"/>
        /// and <paramref name="right"/> points.
        /// </returns>
        public static CvPoint operator -(CvPoint left, CvPoint right)
        {
            return new CvPoint(left.X - right.X, left.Y - right.Y);
        }

        /// <summary>
        /// Returns the inversion with respect to the origin of the specified <see cref="CvPoint"/> structure.
        /// </summary>
        /// <param name="point">The <see cref="CvPoint"/> structure for which to compute the inversion.</param>
        /// <returns>
        /// The <see cref="CvPoint"/> that is the result of inverting <paramref name="point"/> with
        /// respect to the origin.
        /// </returns>
        public static CvPoint operator -(CvPoint point)
        {
            return new CvPoint(-point.X, -point.Y);
        }

        /// <summary>
        /// Multiplies a <see cref="CvPoint"/> structure by an integer scalar.
        /// </summary>
        /// <param name="point">The <see cref="CvPoint"/> structure to multiply by the <paramref name="scalar"/>.</param>
        /// <param name="scalar">The scalar by which to multiply the <paramref name="point"/>.</param>
        /// <returns>
        /// The <see cref="CvPoint"/> that is the result of multiplying <paramref name="point"/> by
        /// <paramref name="scalar"/>.
        /// </returns>
        public static CvPoint operator *(CvPoint point, int scalar)
        {
            return new CvPoint(point.X * scalar, point.Y * scalar);
        }

        /// <summary>
        /// Multiplies a <see cref="CvPoint"/> structure by an integer scalar.
        /// </summary>
        /// <param name="scalar">The scalar by which to multiply the <paramref name="point"/>.</param>
        /// <param name="point">The <see cref="CvPoint"/> structure to multiply by the <paramref name="scalar"/>.</param>
        /// <returns>
        /// The <see cref="CvPoint"/> that is the result of multiplying <paramref name="point"/> by
        /// <paramref name="scalar"/>.
        /// </returns>
        public static CvPoint operator *(int scalar, CvPoint point)
        {
            return new CvPoint(point.X * scalar, point.Y * scalar);
        }
    }
}
