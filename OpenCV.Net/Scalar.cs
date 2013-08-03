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
    [TypeConverter(typeof(NumericAggregateConverter))]
    public struct Scalar
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
    }
}
