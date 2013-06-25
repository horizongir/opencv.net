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

    /// <summary>
    /// Specifies operation flags for <see cref="cv.GEMM"/>.
    /// </summary>
    [Flags]
    public enum GemmFlags : int
    {
        /// <summary>
        /// Specifies that no operation flags are active.
        /// </summary>
        None = 0,

        /// <summary>
        /// Specifies that matrix A should be transposed.
        /// </summary>
        TransposeA = 1,

        /// <summary>
        /// Specifies that matrix B should be transposed.
        /// </summary>
        TransposeB = 2,

        /// <summary>
        /// Specifies that matrix C should be transposed.
        /// </summary>
        TransposeC = 4
    }

    /// <summary>
    /// Specifies the mirror mode used in <see cref="cv.Flip"/>.
    /// </summary>
    public enum FlipMode : int
    {
        /// <summary>
        /// Specifies that the array should be flipped vertically.
        /// </summary>
        Vertical = 0,

        /// <summary>
        /// Specifies that the array should be flipped horizontally.
        /// </summary>
        Horizontal = 1,

        /// <summary>
        /// Specifies that the array should be flipped both vertically and horizontally.
        /// </summary>
        Both = -1
    }

    /// <summary>
    /// Specifies operation flags for <see cref="cv.SVD"/>.
    /// </summary>
    [Flags]
    public enum SvdFlags : int
    {
        /// <summary>
        /// Specifies that no operation flags are active.
        /// </summary>
        None = 0,

        /// <summary>
        /// Specifies that matrix A can be modified in order to speed up the processing.
        /// </summary>
        ModifyA = 1,

        /// <summary>
        /// Specifies that the output matrix U is transposed to speed up the processing.
        /// </summary>
        TransposeU = 2,

        /// <summary>
        /// Specifies that the output matrix V is transposed to speed up the processing.
        /// </summary>
        TransposeV = 4
    }

    /// <summary>
    /// Specifies the inversion method for solving linear systems.
    /// </summary>
    public enum InversionMethod : int
    {
        /// <summary>
        /// Gaussian elimination with optimal pivot element chosen.
        /// </summary>
        LU = 0,

        /// <summary>
        /// Singular value decomposition (SVD) method.
        /// </summary>
        Svd = 1,

        /// <summary>
        /// SVD method for a symmetric positively-defined matrix.
        /// </summary>
        SvdSym = 2,

        /// <summary>
        /// Cholesky decomposition. The matrix must be symmetrical
        /// and positively defined.
        /// </summary>
        Cholesky = 3,

        /// <summary>
        /// QR decomposition. The system can be over-defined and/or the
        /// input matrix can be singular.
        /// </summary>
        QR = 4,

        /// <summary>
        /// A non-exclusive flag meaning that the normal equations are
        /// solved instead of the original system.
        /// </summary>
        Normal = 16
    }

    /// <summary>
    /// Specifies operation flags for <see cref="cv.CalcCovarMatrix"/>.
    /// </summary>
    [Flags]
    public enum CovarianceFlags : int
    {
        /// <summary>
        /// Specifies that the scrambled covariance matrix for fast PCA
        /// of a set of very large vectors should be computed.
        /// </summary>
        Scrambled = 0,

        /// <summary>
        /// Specifies that a normal covariance matrix with the same linear
        /// size as the total number of elements in each input vector should
        /// be computed.
        /// </summary>
        Normal = 1,

        /// <summary>
        /// Specifies that the method should use the provided average of
        /// the input vectors.
        /// </summary>
        UseAvg = 2,

        /// <summary>
        /// Specifies that the covariance matrix will be scaled. Scaling will
        /// depend on whether <see cref="Scrambled"/> or <see cref="Normal"/>
        /// flags are set.
        /// </summary>
        Scale = 4,

        /// <summary>
        /// Specifies that all the input vectors are stored as rows of a single matrix.
        /// </summary>
        Rows = 8,

        /// <summary>
        /// Specifies that all the input vectors are stored as columns of a single matrix.
        /// </summary>
        Cols = 16
    }

    /// <summary>
    /// Specifies operation flags for <see cref="cv.CalcPCA"/>
    /// </summary>
    [Flags]
    public enum PcaFlags : int
    {
        /// <summary>
        /// Specifies whether input vectors are stored as rows of the input matrix.
        /// </summary>
        DataAsRow = 0,

        /// <summary>
        /// Specifies whether input vectors are stored as columns of the input matrix.
        /// </summary>
        DataAsCol = 1,

        /// <summary>
        /// Specifies whether the precomputed average is passed as a parameter.
        /// </summary>
        UseAvg = 2
    }
}
