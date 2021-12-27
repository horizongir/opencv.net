using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a 3D point with double-precision floating-point coordinates.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    [TypeConverter(typeof(NumericAggregateConverter))]
    public struct Point3d : IEquatable<Point3d>
    {
        /// <summary>
        /// Returns a <see cref="Point3d"/> that has <see cref="X"/>,
        /// <see cref="Y"/> and <see cref="Z"/> values set to zero.
        /// </summary>
        public static Point3d Zero
        {
            get { return new Point3d(); }
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
        /// The z-coordinate of the point.
        /// </summary>
        public double Z;

        /// <summary>
        /// Initializes a new instance of the <see cref="Point3d"/> structure from the specified coordinates.
        /// </summary>
        /// <param name="x">The x-coordinate of the point.</param>
        /// <param name="y">The y-coordinate of the point.</param>
        /// <param name="z">The z-coordinate of the point.</param>
        public Point3d(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Returns a hash code for this <see cref="Point3d"/> structure.
        /// </summary>
        /// <returns>An integer value that specifies a hash value for this <see cref="Point3d"/> structure.</returns>
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }

        /// <summary>
        /// Tests to see whether the specified object is a <see cref="Point3d"/> structure
        /// with the same coordinates as this <see cref="Point3d"/> structure.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to test.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="obj"/> is a <see cref="Point3d"/> and has the
        /// same X, Y and Z coordinates as this <see cref="Point3d"/>; otherwise, <b>false</b>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Point3d)
            {
                return Equals((Point3d)obj);
            }

            return false;
        }

        /// <summary>
        /// Returns a value indicating whether this instance has the same coordinates
        /// as a specified <see cref="Point3d"/> structure.
        /// </summary>
        /// <param name="other">The <see cref="Point3d"/> structure to compare to this instance.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="other"/> has the same X, Y and Z coordinates as
        /// this instance; otherwise, <b>false</b>.
        /// </returns>
        public bool Equals(Point3d other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        /// <summary>
        /// Creates a <see cref="String"/> representation of this <see cref="Point3d"/>
        /// structure.
        /// </summary>
        /// <returns>
        /// A <see cref="String"/> containing the <see cref="X"/>, <see cref="Y"/> and
        /// <see cref="Z"/> values of this <see cref="Point3d"/> structure.
        /// </returns>
        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", X, Y, Z);
        }

        /// <summary>
        /// Tests whether two <see cref="Point3d"/> structures are equal.
        /// </summary>
        /// <param name="left">The <see cref="Point3d"/> structure on the left of the equality operator.</param>
        /// <param name="right">The <see cref="Point3d"/> structure on the right of the equality operator.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> have equal X, Y and Z coordinates;
        /// otherwise, <b>false</b>.
        /// </returns>
        public static bool operator ==(Point3d left, Point3d right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Tests whether two <see cref="Point3d"/> structures are different.
        /// </summary>
        /// <param name="left">The <see cref="Point3d"/> structure on the left of the inequality operator.</param>
        /// <param name="right">The <see cref="Point3d"/> structure on the right of the inequality operator.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> differ in X, Y or Z coordinates;
        /// <b>false</b> if <paramref name="left"/> and <paramref name="right"/> are equal.
        /// </returns>
        public static bool operator !=(Point3d left, Point3d right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Adds two <see cref="Point3d"/> structures.
        /// </summary>
        /// <param name="left">The <see cref="Point3d"/> structure on the left of the addition operator.</param>
        /// <param name="right">The <see cref="Point3d"/> structure on the right of the addition operator.</param>
        /// <returns>
        /// The <see cref="Point3d"/> that is the result of adding the <paramref name="left"/>
        /// and <paramref name="right"/> points.
        /// </returns>
        public static Point3d operator +(Point3d left, Point3d right)
        {
            return new Point3d(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }

        /// <summary>
        /// Subtracts two <see cref="Point3d"/> structures.
        /// </summary>
        /// <param name="left">The <see cref="Point3d"/> structure on the left of the subtraction operator.</param>
        /// <param name="right">The <see cref="Point3d"/> structure on the right of the subtraction operator.</param>
        /// <returns>
        /// The <see cref="Point3d"/> that is the result of subtracting the <paramref name="left"/>
        /// and <paramref name="right"/> points.
        /// </returns>
        public static Point3d operator -(Point3d left, Point3d right)
        {
            return new Point3d(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }

        /// <summary>
        /// Returns the inversion with respect to the origin of the specified <see cref="Point3d"/> structure.
        /// </summary>
        /// <param name="point">The <see cref="Point3d"/> structure for which to compute the inversion.</param>
        /// <returns>
        /// The <see cref="Point3d"/> that is the result of inverting <paramref name="point"/> with
        /// respect to the origin.
        /// </returns>
        public static Point3d operator -(Point3d point)
        {
            return new Point3d(-point.X, -point.Y, -point.Z);
        }

        /// <summary>
        /// Multiplies a <see cref="Point3d"/> structure by an integer scalar.
        /// </summary>
        /// <param name="point">The <see cref="Point3d"/> structure to multiply by the <paramref name="scalar"/>.</param>
        /// <param name="scalar">The scalar by which to multiply the <paramref name="point"/>.</param>
        /// <returns>
        /// The <see cref="Point3d"/> that is the result of multiplying <paramref name="point"/> by
        /// <paramref name="scalar"/>.
        /// </returns>
        public static Point3d operator *(Point3d point, float scalar)
        {
            return new Point3d(scalar * point.X, scalar * point.Y, scalar * point.Z);
        }

        /// <summary>
        /// Multiplies a <see cref="Point3d"/> structure by an integer scalar.
        /// </summary>
        /// <param name="scalar">The scalar by which to multiply the <paramref name="point"/>.</param>
        /// <param name="point">The <see cref="Point3d"/> structure to multiply by the <paramref name="scalar"/>.</param>
        /// <returns>
        /// The <see cref="Point3d"/> that is the result of multiplying <paramref name="point"/> by
        /// <paramref name="scalar"/>.
        /// </returns>
        public static Point3d operator *(float scalar, Point3d point)
        {
            return new Point3d(scalar * point.X, scalar * point.Y, scalar * point.Z);
        }
    }
}
