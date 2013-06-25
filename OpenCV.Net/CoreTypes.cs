using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Specifies the available pixel bit depth formats for <see cref="IplImage"/> instances.
    /// </summary>
    public enum IplDepth : int
    {
        /// <summary>
        /// Specifies an unsigned 8-bit pixel depth.
        /// </summary>
        U8 = 8,

        /// <summary>
        /// Specifies an unsigned 16-bit pixel depth.
        /// </summary>
        U16 = 16,

        /// <summary>
        /// Specifies a floating point 32-bit pixel depth.
        /// </summary>
        F32 = 32,

        /// <summary>
        /// Specifies a floating point 64-bit pixel depth.
        /// </summary>
        F64 = 64,

        /// <summary>
        /// Specifies a signed 8-bit pixel depth.
        /// </summary>
        S8 = unchecked((int)(0x80000000 | 8)),

        /// <summary>
        /// Specifies a signed 16-bit pixel depth.
        /// </summary>
        S16 = unchecked((int)(0x80000000 | 16)),

        /// <summary>
        /// Specifies a signed 32-bit pixel depth.
        /// </summary>
        S32 = unchecked((int)(0x80000000 | 32))
    }

    /// <summary>
    /// Specifies the available data origin for <see cref="IplImage"/> instances.
    /// </summary>
    public enum IplOrigin : int
    {
        /// <summary>
        /// Specifies a top-left reference coordinate system (Y increases downwards).
        /// </summary>
        TopLeft = 0,

        /// <summary>
        /// Specifies a bottom-right reference coordinate system (Y increases upwards).
        /// </summary>
        BottomLeft = 1
    }

    /// <summary>
    /// Specifies the available element bit depth formats for <see cref="CvMat"/> instances.
    /// </summary>
    public enum CvMatDepth : int
    {
        /// <summary>
        /// Specifies an unsigned 8-bit element depth.
        /// </summary>
        U8 = 0,

        /// <summary>
        /// Specifies a signed 8-bit element depth.
        /// </summary>
        S8 = 1,

        /// <summary>
        /// Specifies an unsigned 16-bit element depth.
        /// </summary>
        U16 = 2,

        /// <summary>
        /// Specifies a signed 16-bit element depth.
        /// </summary>
        S16 = 3,

        /// <summary>
        /// Specifies a signed 32-bit element depth.
        /// </summary>
        S32 = 4,

        /// <summary>
        /// Specifies a floating point 32-bit element depth.
        /// </summary>
        F32 = 5,

        /// <summary>
        /// Specifies a floating point 64-bit element depth.
        /// </summary>
        F64 = 6
    }

    /// <summary>
    /// Specifies the available termination criteria modes for iterative algorithms.
    /// </summary>
    [Flags]
    public enum TermCriteriaType : int
    {
        /// <summary>
        /// Specifies that no termination criteria should be used.
        /// </summary>
        None = 0,

        /// <summary>
        /// Specifies that a maximum number of iterations criteria should be used.
        /// </summary>
        MaxIter = 1,

        /// <summary>
        /// Specifies that a minimum required accuracy criteria should be used.
        /// </summary>
        Epsilon = 2
    }

    /// <summary>
    /// Specifies the comparison operation used to test the relation between individual array elements
    /// in <see cref="cv.Cmp"/> and <see cref="cv.CmpS"/>.
    /// </summary>
    public enum ComparisonOperation : int
    {
        /// <summary>
        /// Specifies that the comparison should check whether the two elements are equal.
        /// </summary>
        Equal = 0,

        /// <summary>
        /// Specifies that the comparison should check whether the first element is
        /// greater than the second element.
        /// </summary>
        GreaterThan = 1,

        /// <summary>
        /// Specifies that the comparison should check whether the first element is
        /// greater than or equal to the second element.
        /// </summary>
        GreaterOrEqual = 2,

        /// <summary>
        /// Specifies that the comparison should check whether the first element is
        /// less than the second element.
        /// </summary>
        LessThan = 3,

        /// <summary>
        /// Specifies that the comparison should check whether the first element is
        /// less than or equal to the second element.
        /// </summary>
        LessOrEqual = 4,

        /// <summary>
        /// Specifies that the comparison should check whether the two elements are not equal.
        /// </summary>
        NotEqual = 5
    }

    /// <summary>
    /// Specifies operation flags for <see cref="cv.CheckArr"/>.
    /// </summary>
    [Flags]
    public enum CheckArrayFlags : int
    {
        /// <summary>
        /// Specifies that the method should check that every element is neither NaN nor Infinity.
        /// </summary>
        CheckNanInfinity = 0,

        /// <summary>
        /// Specifies that the method should check that every element is within a specified range.
        /// </summary>
        CheckRange = 1,

        /// <summary>
        /// Specifies whether the method should raise an error if an element is invalid or out of range.
        /// </summary>
        CheckQuiet = 2
    }

    /// <summary>
    /// Specifies the random distribution to use for <see cref="cv.RandArr"/>.
    /// </summary>
    public enum CvRandDistribution : int
    {
        /// <summary>
        /// Specifies that a uniform distribution should be used.
        /// </summary>
        Uniform = 0,

        /// <summary>
        /// Specifies that a normal (gaussian) distribution should be used.
        /// </summary>
        Normal = 1
    }

    /// <summary>
    /// Specifies operation flags for the <see cref="cv.Sort"/> method.
    /// </summary>
    [Flags]
    public enum SortFlags : int
    {
        /// <summary>
        /// Specifies that the method should sort every row.
        /// </summary>
        EveryRow = 0,

        /// <summary>
        /// Specifies that the method should sort every column.
        /// </summary>
        EveryColumn = 1,

        /// <summary>
        /// Specifies that the method should sort in ascending order.
        /// </summary>
        Ascending = 0,

        /// <summary>
        /// Specifies that the method should sort in descending order.
        /// </summary>
        Descending = 16
    }
}
