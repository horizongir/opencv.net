using OpenCV.Net.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// A container for one-,two-,three- or four-tuples of doubles.
    /// <see cref="Scalar"/> is always represented as a four-tuple.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
#if !NET_CORE
    [TypeConverter(typeof(NumericAggregateConverter))]
#endif
    public struct Scalar : IEquatable<Scalar>
    {
        /// <summary>
        /// The first value of the scalar tuple.
        /// </summary>
        public double Val0;

        /// <summary>
        /// The second value of the scalar tuple.
        /// </summary>
        public double Val1;

        /// <summary>
        /// The third value of the scalar tuple.
        /// </summary>
        public double Val2;

        /// <summary>
        /// The fourth value of the scalar tuple.
        /// </summary>
        public double Val3;

        /// <summary>
        /// Initializes a new instance of the <see cref="Scalar"/> structure from
        /// the specified values.
        /// </summary>
        /// <param name="val0">The first value of the scalar tuple.</param>
        /// <param name="val1">The optional second value of the scalar tuple.</param>
        /// <param name="val2">The optional third value of the scalar tuple.</param>
        /// <param name="val3">The optional fourth value of the scalar tuple.</param>
        public Scalar(double val0, double val1 = 0, double val2 = 0, double val3 = 0)
        {
            Val0 = val0;
            Val1 = val1;
            Val2 = val2;
            Val3 = val3;
        }

        /// <summary>
        /// Initializes a new <see cref="Scalar"/> instance representing a single scalar value.
        /// </summary>
        /// <param name="val0">The scalar value.</param>
        /// <returns>
        /// A new <see cref="Scalar"/> instance representing a single scalar value.
        /// </returns>
        public static Scalar Real(double val0)
        {
            return new Scalar(val0, 0, 0, 0);
        }

        /// <summary>
        /// Initializes a new <see cref="Scalar"/> instance where all the values
        /// of the tuple are initialized to the same scalar value.
        /// </summary>
        /// <param name="val0123">The scalar value from which to initialize all tuple scalars.</param>
        /// <returns>
        /// A new <see cref="Scalar"/> instance where all the values
        /// of the tuple are initialized to the specified scalar value.
        /// </returns>
        public static Scalar All(double val0123)
        {
            return new Scalar(val0123, val0123, val0123, val0123);
        }

        /// <summary>
        /// Initializes a new <see cref="Scalar"/> instance representing a
        /// color pixel value.
        /// </summary>
        /// <param name="r">The red component of the color.</param>
        /// <param name="g">The green component of the color.</param>
        /// <param name="b">The blue component of the color.</param>
        /// <returns>
        /// A new <see cref="Scalar"/> instance where the values of the
        /// tuple are initialized to the specified color components.
        /// </returns>
        public static Scalar Rgb(double r, double g, double b)
        {
            return new Scalar(b, g, r, 0);
        }

        /// <summary>
        /// Initializes a new <see cref="Scalar"/> instance from a packed
        /// color value.
        /// </summary>
        /// <param name="color">The packed color value.</param>
        /// <param name="arrayType">
        /// The type of array elements. If the depth of the elements is not
        /// 8-bit, the first channels of the returned <see cref="Scalar"/>
        /// are set to the same value as <paramref name="color"/>.
        /// </param>
        /// <returns>
        /// A new <see cref="Scalar"/> instance where the values of the
        /// tuple are initialized to represent the unpacked color.
        /// </returns>
        public static Scalar PackedColor(double color, int arrayType)
        {
            return NativeMethods.cvColorToScalar(color, arrayType);
        }

        /// <summary>
        /// Returns a hash code for this <see cref="Scalar"/> structure.
        /// </summary>
        /// <returns>An integer value that specifies a hash value for this <see cref="Scalar"/> structure.</returns>
        public override int GetHashCode()
        {
            return Val0.GetHashCode() ^ Val1.GetHashCode() ^ Val2.GetHashCode() ^ Val3.GetHashCode();
        }

        /// <summary>
        /// Tests to see whether the specified object is a <see cref="Scalar"/> structure
        /// with the same tuple values as this <see cref="Scalar"/> structure.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to test.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="obj"/> is a <see cref="Scalar"/> and has the
        /// same Val0, Val1, Val2 and Val3 values as this <see cref="Scalar"/>; otherwise, <b>false</b>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Scalar)
            {
                return Equals((Scalar)obj);
            }

            return false;
        }

        /// <summary>
        /// Returns a value indicating whether this instance has the same tuple values
        /// as a specified <see cref="Scalar"/> structure.
        /// </summary>
        /// <param name="other">The <see cref="Scalar"/> structure to compare to this instance.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="other"/> has the same Val0, Val1, Val2 and Val3 values as
        /// this instance; otherwise, <b>false</b>.
        /// </returns>
        public bool Equals(Scalar other)
        {
            return Val0 == other.Val0 && Val1 == other.Val1 && Val2 == other.Val2 && Val3 == other.Val3;
        }

        /// <summary>
        /// Creates a <see cref="String"/> representation of this <see cref="Scalar"/>
        /// structure.
        /// </summary>
        /// <returns>
        /// A <see cref="String"/> containing the four tuple values of this
        /// <see cref="Scalar"/> structure.
        /// </returns>
        public override string ToString()
        {
            return string.Format("({0}, {1}, {2}, {3})", Val0, Val1, Val2, Val3);
        }

        /// <summary>
        /// Tests whether two <see cref="Scalar"/> structures are equal.
        /// </summary>
        /// <param name="left">The <see cref="Scalar"/> structure on the left of the equality operator.</param>
        /// <param name="right">The <see cref="Scalar"/> structure on the right of the equality operator.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> have equal Val0, Val1, Val2
        /// and Val3 values; otherwise, <b>false</b>.
        /// </returns>
        public static bool operator ==(Scalar left, Scalar right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Tests whether two <see cref="Scalar"/> structures are different.
        /// </summary>
        /// <param name="left">The <see cref="Scalar"/> structure on the left of the inequality operator.</param>
        /// <param name="right">The <see cref="Scalar"/> structure on the right of the inequality operator.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> differ in Val0, Val1, Val2
        /// or Val3 values; <b>false</b> if <paramref name="left"/> and <paramref name="right"/> are equal.
        /// </returns>
        public static bool operator !=(Scalar left, Scalar right)
        {
            return !left.Equals(right);
        }
    }
}
