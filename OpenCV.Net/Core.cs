using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCV.Net.Native;
using System.Runtime.InteropServices;

namespace OpenCV.Net
{
    /// <summary>
    /// This class provides wrapper methods for the OpenCV C interface native functions.
    /// </summary>
    public static partial class cv
    {
        #region Array allocation, deallocation, initialization and access to elements

        /// <summary>
        /// Allocates a block of <paramref name="size"/> bytes in memory,
        /// returning a pointer to the beginning of the block.
        /// </summary>
        /// <param name="size">Size of the memory block, in bytes.</param>
        /// <returns>
        /// On success, a pointer to the memory block allocated by the function.
        /// If there is not enough memory, the function raises an error.
        /// </returns>
        public static IntPtr Alloc(UIntPtr size)
        {
            return NativeMethods.cvAlloc(size);
        }

        /// <summary>
        /// Deallocates a block of memory previously allocated by a call to
        /// <see cref="Alloc"/>.
        /// </summary>
        /// <param name="ptr">Pointer to a memory block previously allocated with <see cref="Alloc"/>.</param>
        public static void Free(ref IntPtr ptr)
        {
            NativeMethods.cvFree_(ptr);
            ptr = IntPtr.Zero;
        }

        /// <summary>
        /// Repeats the 2D source array in both horizontal and vertical directions
        /// to fill the destination array.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <param name="dst">The destination array.</param>
        public static void Repeat(CvArr src, CvArr dst)
        {
            NativeMethods.cvRepeat(src, dst);
        }

        /// <summary>
        /// Copies elements of one array to another.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <param name="dst">The destination array.</param>
        /// <param name="mask">
        /// Optional operation mask, 8-bit single-channel array specifying the
        /// elements that should be changed on <paramref name="dst"/>.
        /// </param>
        public static void Copy(CvArr src, CvArr dst, CvArr mask = null)
        {
            NativeMethods.cvCopy(src, dst, mask ?? CvArr.Null);
        }

        /// <summary>
        /// Divides a multi-channel array into several single-channel arrays or extracts
        /// a single channel from the array.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <param name="dst0">The first destination channel array.</param>
        /// <param name="dst1">The second destination channel array.</param>
        /// <param name="dst2">The third destination channel array.</param>
        /// <param name="dst3">The fourth destination channel array.</param>
        /// <remarks>
        /// The function divides a multi-channel array into separate single-channel arrays.
        /// Two modes are available for the operation. If the source array has N channels
        /// and the first N destination channels are not <b>null</b>, they all are
        /// extracted from the source array; if only a single destination channel of
        /// the first N is not <b>null</b>, this particular channel is extracted;
        /// otherwise an exception is raised. The rest of the destination channels
        /// (beyond the first N) must always be <b>null</b>. For an <see cref="IplImage"/>
        /// instance, <see cref="Copy"/> with COI set can also be used to extract a
        /// single channel from the image.
        /// </remarks>
        public static void Split(CvArr src, CvArr dst0, CvArr dst1, CvArr dst2, CvArr dst3)
        {
            NativeMethods.cvSplit(src, dst0 ?? CvArr.Null, dst1 ?? CvArr.Null, dst2 ?? CvArr.Null, dst3 ?? CvArr.Null);
        }

        /// <summary>
        /// Composes a multi-channel array from several single-channel arrays or
        /// inserts a single channel into the array.
        /// </summary>
        /// <param name="src0">The first input channel array.</param>
        /// <param name="src1">The second input channel array.</param>
        /// <param name="src2">The third input channel array.</param>
        /// <param name="src3">The fourth input channel array.</param>
        /// <param name="dst">The destination array.</param>
        /// <remarks>
        /// The function is the opposite to <see cref="Split"/>. If the destination
        /// array has N channels then if the first N input channels are not <b>null</b>,
        /// they all are copied to the destination array; if only a single source
        /// channel of the first N is not <b>null</b>, this particular channel is
        /// copied into the destination array; otherwise an exception is raised.
        /// The rest of the source channels (beyond the first N) must always be <b>null</b>.
        /// For an <see cref="IplImage"/> instance, <see cref="Copy"/> with COI set
        /// can also be used to insert a single channel into the image.
        /// </remarks>
        public static void Merge(CvArr src0, CvArr src1, CvArr src2, CvArr src3, CvArr dst)
        {
            NativeMethods.cvMerge(src0 ?? CvArr.Null, src1 ?? CvArr.Null, src2 ?? CvArr.Null, src3 ?? CvArr.Null, dst);
        }

        /// <summary>
        /// Copies specified channels from the input arrays to the specified channels
        /// of the output arrays. All matrices must have the same size and depth.
        /// </summary>
        /// <param name="src">The input arrays.</param>
        /// <param name="dst">The output arrays.</param>
        /// <param name="fromTo">
        /// The array of index pairs, specifying which channels are copied and where.
        /// <paramref name="fromTo"/>[k*2] is the 0-based index of the input channel
        /// in <paramref name="src"/> and <paramref name="fromTo"/>[k*2+1] is the
        /// index of the output channel in <paramref name="dst"/>. Continuous channel
        /// numbering is used, i.e. the first input channels in <paramref name="src"/>
        /// are indexed from <code>0</code> to <code>src[0].Channels-1</code>, and the
        /// second input channels are indexed from <code>src[0].Channels</code> to
        /// <code>src[0].Channels + src[1].Channels-1</code>. The same scheme is used
        /// for the output image channels. As a special case, negative output channel
        /// indices mean that the corresponding output channel is filled with zeros.
        /// </param>
        /// <remarks>
        /// This function is a generalized form of <see cref="Split"/> and
        /// <see cref="Merge"/>. It can be used to change the order of the planes,
        /// add/remove alpha channel, extract or insert a single plane or multiple
        /// planes, etc.
        /// </remarks>
        public static void MixChannels(CvArr[] src, CvArr[] dst, int[] fromTo)
        {
            var srcHandles = Array.ConvertAll(src, arr => arr.DangerousGetHandle());
            var dstHandles = Array.ConvertAll(dst, arr => arr.DangerousGetHandle());
            NativeMethods.cvMixChannels(srcHandles, srcHandles.Length, dstHandles, dstHandles.Length, fromTo, fromTo.Length / 2);
            GC.KeepAlive(src);
            GC.KeepAlive(dst);
        }

        /// <summary>
        /// Converts one array to another with optional linear transformation.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <param name="dst">The destination array.</param>
        /// <param name="scale">
        /// The optional scale factor applied independently to all element channels.
        /// </param>
        /// <param name="shift">The optional value added to scaled array elements.</param>
        public static void ConvertScale(CvArr src, CvArr dst, double scale = 1, double shift = 0)
        {
            NativeMethods.cvConvertScale(src, dst, scale, shift);
        }

        /// <summary>
        /// Converts input array elements to an 8-bit unsigned integer array
        /// with optional linear transformation.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <param name="dst">The destination array (must have U8 depth).</param>
        /// <param name="scale">
        /// The optional scale factor applied independently to all element channels.
        /// </param>
        /// <param name="shift">The optional value added to scaled array elements.</param>
        /// <remarks>
        /// This function is similar to <see cref="ConvertScale"/>, but stores absolute
        /// values after the conversion results.
        /// </remarks>
        public static void ConvertScaleAbs(CvArr src, CvArr dst, double scale = 1, double shift = 0)
        {
            NativeMethods.cvConvertScaleAbs(src, dst, scale, shift);
        }

        #endregion

        #region Arithmetic, logic and comparison operations

        /// <summary>
        /// Calculates the per-element sum of two arrays.
        /// </summary>
        /// <param name="src1">The first input array.</param>
        /// <param name="src2">The second input array.</param>
        /// <param name="dst">The destination array.</param>
        /// <param name="mask">
        /// Optional operation mask, 8-bit single-channel array specifying the
        /// elements that should be changed on <paramref name="dst"/>.
        /// </param>
        public static void Add(CvArr src1, CvArr src2, CvArr dst, CvArr mask = null)
        {
            NativeMethods.cvAdd(src1, src2, dst, mask ?? CvArr.Null);
        }

        /// <summary>
        /// Calculates the per-element sum of an array and a scalar.
        /// </summary>
        /// <param name="src">The input array.</param>
        /// <param name="value">The scalar input value.</param>
        /// <param name="dst">The destination array.</param>
        /// <param name="mask">
        /// Optional operation mask, 8-bit single-channel array specifying the
        /// elements that should be changed on <paramref name="dst"/>.
        /// </param>
        public static void AddS(CvArr src, CvScalar value, CvArr dst, CvArr mask = null)
        {
            NativeMethods.cvAddS(src, value, dst, mask ?? CvArr.Null);
        }

        /// <summary>
        /// Calculates the per-element difference between two arrays.
        /// </summary>
        /// <param name="src1">The first input array.</param>
        /// <param name="src2">The second input array.</param>
        /// <param name="dst">The destination array.</param>
        /// <param name="mask">
        /// Optional operation mask, 8-bit single-channel array specifying the
        /// elements that should be changed on <paramref name="dst"/>.
        /// </param>
        public static void Sub(CvArr src1, CvArr src2, CvArr dst, CvArr mask = null)
        {
            NativeMethods.cvSub(src1, src2, dst, mask ?? CvArr.Null);
        }

        /// <summary>
        /// Calculates the per-element difference between an array and a scalar.
        /// </summary>
        /// <param name="src">The input array.</param>
        /// <param name="value">The scalar input value.</param>
        /// <param name="dst">The destination array.</param>
        /// <param name="mask">
        /// Optional operation mask, 8-bit single-channel array specifying the
        /// elements that should be changed on <paramref name="dst"/>.
        /// </param>
        public static void SubS(CvArr src, CvScalar value, CvArr dst, CvArr mask = null)
        {
            AddS(src, new CvScalar(-value.Val0, -value.Val1, -value.Val2, -value.Val3), dst, mask);
        }

        /// <summary>
        /// Calculates the per-element difference between a scalar and an array.
        /// </summary>
        /// <param name="src">The input array.</param>
        /// <param name="value">The scalar input value.</param>
        /// <param name="dst">The destination array.</param>
        /// <param name="mask">
        /// Optional operation mask, 8-bit single-channel array specifying the
        /// elements that should be changed on <paramref name="dst"/>.
        /// </param>
        public static void SubRS(CvArr src, CvScalar value, CvArr dst, CvArr mask = null)
        {
            NativeMethods.cvSubRS(src, value, dst, mask ?? CvArr.Null);
        }

        /// <summary>
        /// Calculates the per-element product of two arrays.
        /// </summary>
        /// <param name="src1">The first input array.</param>
        /// <param name="src2">The second input array.</param>
        /// <param name="dst">The destination array.</param>
        /// <param name="scale">An optional scale factor.</param>
        public static void Mul(CvArr src1, CvArr src2, CvArr dst, double scale = 1)
        {
            NativeMethods.cvMul(src1, src2, dst, scale);
        }

        /// <summary>
        /// Calculates the per-element division of two arrays.
        /// </summary>
        /// <param name="src1">The first input array. If the reference is <b>null</b>, the array is assumed to be all ones.</param>
        /// <param name="src2">The second input array.</param>
        /// <param name="dst">The destination array.</param>
        /// <param name="scale">An optional scale factor.</param>
        public static void Div(CvArr src1, CvArr src2, CvArr dst, double scale = 1)
        {
            NativeMethods.cvDiv(src1 ?? CvArr.Null, src2, dst, scale);
        }

        /// <summary>
        /// Calculates the sum of a scaled array and another array.
        /// </summary>
        /// <param name="src1">The first input array.</param>
        /// <param name="scale">The scale factor for the first array.</param>
        /// <param name="src2">The second input array.</param>
        /// <param name="dst">The destination array.</param>
        public static void ScaleAdd(CvArr src1, CvScalar scale, CvArr src2, CvArr dst)
        {
            NativeMethods.cvScaleAdd(src1, scale, src2, dst);
        }

        /// <summary>
        /// Calculates the sum of a multiple of an array with another array.
        /// </summary>
        /// <param name="A">The first input array.</param>
        /// <param name="real_scalar">The scale factor for the first array.</param>
        /// <param name="B">The second input array.</param>
        /// <param name="C">The destination array.</param>
        public static void AXPY(CvArr A, double real_scalar, CvArr B, CvArr C)
        {
            ScaleAdd(A, CvScalar.Real(real_scalar), B, C);
        }

        /// <summary>
        /// Computes the weighted sum of two arrays.
        /// </summary>
        /// <param name="src1">The first input array.</param>
        /// <param name="alpha">The weight for the first array elements.</param>
        /// <param name="src2">The second input array.</param>
        /// <param name="beta">The weight for the second array elements.</param>
        /// <param name="gamma">A scalar that is added to each sum.</param>
        /// <param name="dst">The destination array.</param>
        public static void AddWeighted(CvArr src1, double alpha, CvArr src2, double beta, double gamma, CvArr dst)
        {
            NativeMethods.cvAddWeighted(src1, alpha, src2, beta, gamma, dst);
        }

        /// <summary>
        /// Calculates the dot product of two arrays in Euclidian metrics.
        /// </summary>
        /// <param name="src1">The first input array.</param>
        /// <param name="src2">The second input array.</param>
        /// <returns>
        /// The Euclidean dot product of the two arrays. In the case of multiple
        /// channel arrays, the results for all channels are accumulated.
        /// </returns>
        public static double DotProduct(CvArr src1, CvArr src2)
        {
            return NativeMethods.cvDotProduct(src1, src2);
        }

        /// <summary>
        /// Performs per-element bit-wise conjunction of two arrays.
        /// </summary>
        /// <param name="src1">The first input array.</param>
        /// <param name="src2">The second input array.</param>
        /// <param name="dst">The destination array.</param>
        /// <param name="mask">
        /// Optional operation mask, 8-bit single-channel array specifying the
        /// elements that should be changed on <paramref name="dst"/>.
        /// </param>
        public static void And(CvArr src1, CvArr src2, CvArr dst, CvArr mask = null)
        {
            NativeMethods.cvAnd(src1, src2, dst, mask ?? CvArr.Null);
        }

        /// <summary>
        /// Performs per-element bit-wise conjunction of an array and a scalar.
        /// </summary>
        /// <param name="src">The input array.</param>
        /// <param name="value">The scalar input value.</param>
        /// <param name="dst">The destination array.</param>
        /// <param name="mask">
        /// Optional operation mask, 8-bit single-channel array specifying the
        /// elements that should be changed on <paramref name="dst"/>.
        /// </param>
        public static void AndS(CvArr src, CvScalar value, CvArr dst, CvArr mask = null)
        {
            NativeMethods.cvAndS(src, value, dst, mask ?? CvArr.Null);
        }

        /// <summary>
        /// Performs per-element bit-wise disjunction of two arrays.
        /// </summary>
        /// <param name="src1">The first input array.</param>
        /// <param name="src2">The second input array.</param>
        /// <param name="dst">The destination array.</param>
        /// <param name="mask">
        /// Optional operation mask, 8-bit single-channel array specifying the
        /// elements that should be changed on <paramref name="dst"/>.
        /// </param>
        public static void Or(CvArr src1, CvArr src2, CvArr dst, CvArr mask = null)
        {
            NativeMethods.cvOr(src1, src2, dst, mask ?? CvArr.Null);
        }

        /// <summary>
        /// Performs per-element bit-wise disjunction of an array and a scalar.
        /// </summary>
        /// <param name="src">The input array.</param>
        /// <param name="value">The scalar input value.</param>
        /// <param name="dst">The destination array.</param>
        /// <param name="mask">
        /// Optional operation mask, 8-bit single-channel array specifying the
        /// elements that should be changed on <paramref name="dst"/>.
        /// </param>
        public static void OrS(CvArr src, CvScalar value, CvArr dst, CvArr mask = null)
        {
            NativeMethods.cvOrS(src, value, dst, mask ?? CvArr.Null);
        }

        /// <summary>
        /// Performs per-element bit-wise "exclusive or" operation on two arrays.
        /// </summary>
        /// <param name="src1">The first input array.</param>
        /// <param name="src2">The second input array.</param>
        /// <param name="dst">The destination array.</param>
        /// <param name="mask">
        /// Optional operation mask, 8-bit single-channel array specifying the
        /// elements that should be changed on <paramref name="dst"/>.
        /// </param>
        public static void Xor(CvArr src1, CvArr src2, CvArr dst, CvArr mask = null)
        {
            NativeMethods.cvXor(src1, src2, dst, mask ?? CvArr.Null);
        }

        /// <summary>
        /// Performs per-element bit-wise “exclusive or” operation on an array and a scalar.
        /// </summary>
        /// <param name="src">The input array.</param>
        /// <param name="value">The scalar input value.</param>
        /// <param name="dst">The destination array.</param>
        /// <param name="mask">
        /// Optional operation mask, 8-bit single-channel array specifying the
        /// elements that should be changed on <paramref name="dst"/>.
        /// </param>
        public static void XorS(CvArr src, CvScalar value, CvArr dst, CvArr mask = null)
        {
            NativeMethods.cvXorS(src, value, dst, mask ?? CvArr.Null);
        }

        /// <summary>
        /// Performs per-element bit-wise inversion of array elements.
        /// </summary>
        /// <param name="src">The input array.</param>
        /// <param name="dst">The destination array.</param>
        public static void Not(CvArr src, CvArr dst)
        {
            NativeMethods.cvNot(src, dst);
        }

        /// <summary>
        /// Checks that array elements lie between the elements of two other arrays.
        /// </summary>
        /// <param name="src">The input array.</param>
        /// <param name="lower">The inclusive lower boundary array.</param>
        /// <param name="upper">The exclusive upper boundary array.</param>
        /// <param name="dst">The destination array. It must have U8 or S8 type.</param>
        public static void InRange(CvArr src, CvArr lower, CvArr upper, CvArr dst)
        {
            NativeMethods.cvInRange(src, lower, upper, dst);
        }

        /// <summary>
        /// Checks that array elements lie between two scalars.
        /// </summary>
        /// <param name="src">The input array.</param>
        /// <param name="lower">The inclusive lower boundary.</param>
        /// <param name="upper">The exclusive upper boundary.</param>
        /// <param name="dst">The destination array. It must have U8 or S8 type.</param>
        public static void InRangeS(CvArr src, CvScalar lower, CvScalar upper, CvArr dst)
        {
            NativeMethods.cvInRangeS(src, lower, upper, dst);
        }

        /// <summary>
        /// Performs per-element comparison of two arrays.
        /// </summary>
        /// <param name="src1">The first input array.</param>
        /// <param name="src2">The second input array. Both input arrays must have a single channel.</param>
        /// <param name="dst">The destination array. It must have U8 or S8 type.</param>
        /// <param name="cmp_op">
        /// The comparison operation used to test the relation between the elements to be checked.
        /// </param>
        public static void Cmp(CvArr src1, CvArr src2, CvArr dst, ComparisonOperation cmp_op)
        {
            NativeMethods.cvCmp(src2, src2, dst, cmp_op);
        }

        /// <summary>
        /// Performs per-element comparison of an array and a scalar.
        /// </summary>
        /// <param name="src">The input array, must have a single channel.</param>
        /// <param name="value">The scalar value with which to compare each array element.</param>
        /// <param name="dst">The destination array. It must have U8 or S8 type.</param>
        /// <param name="cmpOp">
        /// The comparison operation used to test the relation between the elements to be checked.
        /// </param>
        public static void CmpS(CvArr src, double value, CvArr dst, ComparisonOperation cmpOp)
        {
            NativeMethods.cvCmpS(src, value, dst, cmpOp);
        }

        /// <summary>
        /// Finds per-element minimum of two arrays.
        /// </summary>
        /// <param name="src1">The first input array.</param>
        /// <param name="src2">The second input array.</param>
        /// <param name="dst">The destination array.</param>
        public static void Min(CvArr src1, CvArr src2, CvArr dst)
        {
            NativeMethods.cvMin(src1, src2, dst);
        }

        /// <summary>
        /// Finds per-element maximum of two arrays.
        /// </summary>
        /// <param name="src1">The first input array.</param>
        /// <param name="src2">The second input array.</param>
        /// <param name="dst">The destination array.</param>
        public static void Max(CvArr src1, CvArr src2, CvArr dst)
        {
            NativeMethods.cvMax(src1, src2, dst);
        }

        /// <summary>
        /// Finds per-element minimum of an array and a scalar.
        /// </summary>
        /// <param name="src">The input array.</param>
        /// <param name="value">The scalar input value.</param>
        /// <param name="dst">The destination array.</param>
        public static void MinS(CvArr src, double value, CvArr dst)
        {
            NativeMethods.cvMinS(src, value, dst);
        }

        /// <summary>
        /// Finds per-element maximum of array and scalar.
        /// </summary>
        /// <param name="src">The input array.</param>
        /// <param name="value">The scalar input value.</param>
        /// <param name="dst">The destination array.</param>
        public static void MaxS(CvArr src, double value, CvArr dst)
        {
            NativeMethods.cvMaxS(src, value, dst);
        }

        /// <summary>
        /// Calculates the absolute difference between two arrays.
        /// </summary>
        /// <param name="src1">The first input array.</param>
        /// <param name="src2">The second input array.</param>
        /// <param name="dst">The destination array.</param>
        public static void AbsDiff(CvArr src1, CvArr src2, CvArr dst)
        {
            NativeMethods.cvAbsDiff(src1, src2, dst);
        }

        /// <summary>
        /// Calculates the absolute difference between an array and a scalar.
        /// </summary>
        /// <param name="src">The input array.</param>
        /// <param name="value">The scalar input value.</param>
        /// <param name="dst">The destination array.</param>
        public static void AbsDiffS(CvArr src, CvArr dst, CvScalar value)
        {
            NativeMethods.cvAbsDiffS(src, dst, value);
        }

        /// <summary>
        /// Calculates the per-element absolute value of an array.
        /// </summary>
        /// <param name="src">The input array.</param>
        /// <param name="dst">The destination array.</param>
        public static void Abs(CvArr src, CvArr dst)
        {
            AbsDiffS(src, dst, CvScalar.All(0));
        }

        #endregion

        #region Math operations

        /// <summary>
        /// Calculates the magnitude and/or angle of 2d vectors.
        /// </summary>
        /// <param name="x">The array of x-coordinates.</param>
        /// <param name="y">The array of y-coordinates.</param>
        /// <param name="magnitude">
        /// The destination array of magnitudes, may be set to <b>null</b> if it is not needed.
        /// </param>
        /// <param name="angle">
        /// The destination array of angles, may be set to <b>null</b> if it is not needed.
        /// The angles are measured in radians (0 to 2pi) or in degrees (0 to 360 degrees).
        /// </param>
        /// <param name="angleInDegrees">
        /// A value indicating whether the angles are measured in radians, which is the
        /// default mode, or in degrees.
        /// </param>
        public static void CartToPolar(CvArr x, CvArr y, CvArr magnitude, CvArr angle = null, bool angleInDegrees = false)
        {
            NativeMethods.cvCartToPolar(x, y, magnitude ?? CvArr.Null, angle ?? CvArr.Null, angleInDegrees ? 1 : 0);
        }

        /// <summary>
        /// Calculates Cartesian coordinates of 2d vectors represented in polar form.
        /// </summary>
        /// <param name="magnitude">
        /// The array of magnitudes. If it is <b>null</b>, the magnitudes are assumed to be all ones.
        /// </param>
        /// <param name="angle">The array of angles, whether in radians or degrees.</param>
        /// <param name="x">The destination array of x-coordinates, may be set to <b>null</b> if it is not needed.</param>
        /// <param name="y">The destination array of y-coordinates, may be set to <b>null</b> if it is not needed.</param>
        /// <param name="angleInDegrees">
        /// A value indicating whether the angles are measured in radians, which is the
        /// default mode, or in degrees.
        /// </param>
        public static void PolarToCart(CvArr magnitude, CvArr angle, CvArr x, CvArr y, bool angleInDegrees = false)
        {
            NativeMethods.cvPolarToCart(magnitude ?? CvArr.Null, angle, x ?? CvArr.Null, y ?? CvArr.Null, angleInDegrees ? 1 : 0);
        }

        /// <summary>
        /// Raises every array element to a power.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <param name="dst">The destination array, should be the same type as the source.</param>
        /// <param name="power">The exponent of power.</param>
        public static void Pow(CvArr src, CvArr dst, double power)
        {
            NativeMethods.cvPow(src, dst, power);
        }

        /// <summary>
        /// Calculates the exponent of every array element.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <param name="dst">
        /// The destination array, it should have double type or the same type
        /// as <paramref name="src"/>.
        /// </param>
        public static void Exp(CvArr src, CvArr dst)
        {
            NativeMethods.cvExp(src, dst);
        }

        /// <summary>
        /// Calculates the natural logarithm of every array element’s absolute value.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <param name="dst">
        /// The destination array, it should have double type or the same type
        /// as <paramref name="src"/>.
        /// </param>
        public static void Log(CvArr src, CvArr dst)
        {
            NativeMethods.cvLog(src, dst);
        }

        /// <summary>
        /// Calculates the angle of a 2D vector.
        /// </summary>
        /// <param name="y">The y-coordinate of the 2D vector.</param>
        /// <param name="x">The x-coordinate of the 2D vector.</param>
        /// <returns>
        /// The full-range angle of an input 2D vector. The angle is measured in
        /// degrees and varies from 0 degrees to 360 degrees.
        /// The accuracy is about 0.1 degrees.
        /// </returns>
        public static float FastArctan(float y, float x)
        {
            return NativeMethods.cvFastArctan(y, x);
        }

        /// <summary>
        /// Calculates the cubic root.
        /// </summary>
        /// <param name="value">The input floating-point value.</param>
        /// <returns>The cubic root of <paramref name="value"/>.</returns>
        public static float Cbrt(float value)
        {
            return NativeMethods.cvCbrt(value);
        }

        /// <summary>
        /// Checks that every array element is neither NaN nor Infinity. It can also check
        /// whether the elements are within a specified range.
        /// </summary>
        /// <param name="arr">The source array to check.</param>
        /// <param name="flags">
        /// The operation flags. A combination of <see cref="CheckArrayFlags.CheckNanInfinity"/>
        /// and <see cref="CheckArrayFlags.CheckRange"/>. If the latter is set, the function
        /// checks whether every value of the array is greater than or equal to <paramref name="min_val"/>
        /// and less than <paramref name="max_val"/>. If <see cref="CheckArrayFlags.CheckQuiet"/> is set,
        /// the function does not raise an error if an element is invalid or out of range.
        /// </param>
        /// <param name="min_val">The inclusive lower boundary of valid values range.</param>
        /// <param name="max_val">The exclusive upper boundary of valid values range.</param>
        /// <returns><b>true</b> if all array elements are valid and within range; <b>false</b> otherwise.</returns>
        public static bool CheckArr(CvArr arr, CheckArrayFlags flags, double min_val, double max_val)
        {
            return NativeMethods.cvCheckArr(arr, flags, min_val, max_val) > 0;
        }

        /// <summary>
        /// Initializes a random number generator state.
        /// </summary>
        /// <param name="seed">A 64-bit value used to initiate a random sequence.</param>
        /// <returns>The initialized random number generator state.</returns>
        public static ulong Rng(long seed)
        {
            unchecked
            {
                return seed > 0 ? (ulong)seed : (ulong)(long)-1;
            }
        }

        /// <summary>
        /// Returns a random 32-bit unsigned integer and updates the generator state.
        /// </summary>
        /// <param name="rng">The random number generator state initialized by <see cref="Rng"/>.</param>
        /// <returns>A uniformly-distributed random 32-bit unsigned integer.</returns>
        public static uint RandInt(ref ulong rng)
        {
            const ulong RngCoeff = 4164903690U;
            var temp = rng;
            temp = (ulong)(uint)temp * RngCoeff + (temp >> 32);
            rng = temp;
            return (uint)temp;
        }

        /// <summary>
        /// Returns a floating-point random number and updates the generator state.
        /// </summary>
        /// <param name="rng">The random number generator state initialized by <see cref="Rng"/>.</param>
        /// <returns>
        /// A uniformly-distributed random floating-point number between 0
        /// inclusive and 1 exclusive.
        /// </returns>
        public static double RandReal(ref ulong rng)
        {
            return RandInt(ref rng) * 2.3283064365386962890625e-10 /* 2^-32 */;
        }

        /// <summary>
        /// Fills an array with random numbers and updates the generator state.
        /// </summary>
        /// <param name="rng">The random number generator state initialized by <see cref="Rng"/>.</param>
        /// <param name="arr">The destination array.</param>
        /// <param name="distType">The type of distribution used to generate random numbers.</param>
        /// <param name="param1">
        /// The first parameter of the distribution. In the case of a uniform distribution it is
        /// the inclusive lower boundary of the random numbers range. In the case of a normal
        /// distribution it is the mean value of the random numbers.
        /// </param>
        /// <param name="param2">
        /// The second parameter of the distribution. In the case of a uniform distribution it is
        /// the exclusive upper boundary of the random numbers range. In the case of a normal
        /// distribution it is the standard deviation of the random numbers.
        /// </param>
        public static void RandArr(ref ulong rng, CvArr arr, CvRandDistribution distType, CvScalar param1, CvScalar param2)
        {
            NativeMethods.cvRandArr(ref rng, arr, distType, param1, param2);
        }

        /// <summary>
        /// Shuffles the array elements randomly and updates the generator state.
        /// </summary>
        /// <param name="mat">The source and destination array. The array is shuffled in place.</param>
        /// <param name="rng">The random number generator state initialized by <see cref="Rng"/>.</param>
        /// <param name="iterFactor">The scale factor that determines the number of random swap operations.</param>
        public static void RandShuffle(CvArr mat, ref ulong rng, double iterFactor = 1)
        {
            NativeMethods.cvRandShuffle(mat, ref rng, iterFactor);
        }

        /// <summary>
        /// Sorts each row or each column of a matrix.
        /// </summary>
        /// <param name="src">The source single-channel array.</param>
        /// <param name="dst">The destination array of the same size and the same type as <paramref name="src"/>.</param>
        /// <param name="indices">The array on which to store the sorted indices.</param>
        /// <param name="flags">
        /// The operation flags indicating whether to sort rows or columns and whether to use ascending
        /// or descending order.
        /// </param>
        public static void Sort(CvArr src, CvArr dst, CvArr indices, SortFlags flags)
        {
            NativeMethods.cvSort(src, dst, indices, flags);
        }

        /// <summary>
        /// Finds the real roots of a cubic equation.
        /// </summary>
        /// <param name="coeffs">The equation coefficients, an array of 3 or 4 elements.</param>
        /// <param name="roots">The output array of real roots which should have 3 elements.</param>
        /// <returns>The number of real roots found.</returns>
        public static int SolveCubic(CvMat coeffs, CvMat roots)
        {
            return NativeMethods.cvSolveCubic(coeffs, roots);
        }

        /// <summary>
        /// Finds the real or complex roots of a polynomial equation.
        /// </summary>
        /// <param name="coeffs">The array of polynomial coefficients.</param>
        /// <param name="roots2">The destination (complex) array of roots.</param>
        /// <param name="maxIter">The maximum number of iterations to perform.</param>
        /// <param name="fig">The required figures of precision.</param>
        public static void SolvePoly(CvMat coeffs, CvMat roots2, int maxIter = 20, int fig = 100)
        {
            NativeMethods.cvSolvePoly(coeffs, roots2, maxIter, fig);
        }

        #endregion
    }
}
