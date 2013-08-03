using OpenCV.Net.Native;
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
    /// Specifies the type of border to create around a copied image.
    /// </summary>
    public enum IplBorder : int
    {
        /// <summary>
        /// Specifies that the border is filled with a fixed value.
        /// </summary>
        Constant,

        /// <summary>
        /// Specifies that the pixels from the top and bottom rows, the left-most and right-most
        /// columns are replicated to fill the border.
        /// </summary>
        Replicate,

        /// <summary>
        /// This border type is currently unsupported.
        /// </summary>
        Reflect,

        /// <summary>
        /// This border type is currently unsupported.
        /// </summary>
        Wrap
    }

    /// <summary>
    /// Specifies the available element bit depth formats for <see cref="Mat"/> and <see cref="Seq"/> instances.
    /// </summary>
    public enum Depth : int
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
        F64 = 6,

        /// <summary>
        /// Specifies a user defined element pointer type.
        /// </summary>
        UserType = 7
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
    /// Specifies operation flags for <see cref="Arr.CheckRange"/>.
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
    public enum RandDistribution : int
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

    /// <summary>
    /// Specifies flags for <see cref="cv.Norm"/> and <see cref="cv.Normalize"/>.
    /// </summary>
    [Flags]
    public enum NormTypes : int
    {
        /// <summary>
        /// Specifies the elementwise max norm.
        /// </summary>
        C = 1,

        /// <summary>
        /// Specifies the L1 or Manhattan norm.
        /// </summary>
        L1 = 2,

        /// <summary>
        /// Specifies the L2 or Euclidean norm.
        /// </summary>
        L2 = 4,

        /// <summary>
        /// Specifies a squared L2 norm.
        /// </summary>
        L2Sqr = 5,

        /// <summary>
        /// Specifies a Hamming distance norm.
        /// </summary>
        Hamming = 6,

        /// <summary>
        /// Specifies a Hamming2 norm.
        /// </summary>
        Hamming2 = 7,
        
        /// <summary>
        /// The bitmask used to extract the norm type.
        /// </summary>
        NormMask = 7,

        /// <summary>
        /// Specifies that a relative difference norm should be computed.
        /// </summary>
        Relative = 8,

        /// <summary>
        /// Specifies that a difference norm should be computed.
        /// </summary>
        Diff = 16,

        /// <summary>
        /// Specifies that a range normalization should be computed.
        /// </summary>
        MinMax = 32,

        /// <summary>
        /// Specifies a difference elementwise max norm.
        /// </summary>
        DiffC = (Diff | C),

        /// <summary>
        /// Specifies a difference L1 norm.
        /// </summary>
        DiffL1 = (Diff | L1),

        /// <summary>
        /// Specifies a difference L2 norm.
        /// </summary>
        DiffL2 = (Diff | L2),

        /// <summary>
        /// Specifies a relative difference elementwise max norm.
        /// </summary>
        RelativeC = (Relative | C),

        /// <summary>
        /// Specifies a relative difference L1 norm.
        /// </summary>
        RelativeL1 = (Relative | L1),

        /// <summary>
        /// Specifies a relative difference L2 norm.
        /// </summary>
        RelativeL2 = (Relative | L2)
    }

    /// <summary>
    /// Specifies the matrix reduction operation.
    /// </summary>
    public enum ReduceOperation : int
    {
        /// <summary>
        /// Specifies that the output is the sum of all the matrix rows/columns.
        /// </summary>
        Sum,

        /// <summary>
        /// Specifies that the output is the mean vector of all of the matrix rows/columns.
        /// </summary>
        Avg,

        /// <summary>
        /// Specifies that the output is the maximum (column/row-wise) of all of the matrix rows/columns.
        /// </summary>
        Max,

        /// <summary>
        /// Specifies that the output is the minimum (column/row-wise) of all of the matrix rows/columns.
        /// </summary>
        Min
    }

    /// <summary>
    /// Specifies the operation of discrete linear transforms and related functions.
    /// </summary>
    [Flags]
    public enum DiscreteTransformFlags : int
    {
        /// <summary>
        /// Specifies that a forward 1D or 2D transform should be performed.
        /// </summary>
        Forward = 0,

        /// <summary>
        /// Specifies that an inverse 1D or 2D transform should be performed.
        /// </summary>
        Inverse = 1,

        /// <summary>
        /// Specifies that the result should be scaled by dividing it by the number of array elements.
        /// </summary>
        Scale = 2,

        /// <summary>
        /// A combination of <see cref="Inverse"/> and <see cref="Scale"/>.
        /// </summary>
        InverseScale = (Inverse + Scale),

        /// <summary>
        /// Specifies that each row of the array should be processed individually.
        /// </summary>
        Rows = 4,

        /// <summary>
        /// Specifies that the second array should be conjugated before the multiplication.
        /// </summary>
        MultiplyConjugate = 8
    }

    /// <summary>
    /// Specifies the most common sequence element types.
    /// </summary>
    public enum SequenceElementType : int
    {
        /// <summary>
        /// Specifies a point in 2D space.
        /// </summary>
        Point = 12,

        /// <summary>
        /// Specifies a freeman code element.
        /// </summary>
        Code = Depth.U8,

        /// <summary>
        /// Specifies an undefined type of sequence element.
        /// </summary>
        Generic = 0,

        /// <summary>
        /// Specifies a pointer type of sequence element.
        /// </summary>
        Pointer = Depth.UserType,

        /// <summary>
        /// Specifies a pointer to an element of another sequence.
        /// </summary>
        PointPointer = Pointer,

        /// <summary>
        /// Specifies an index of an element of some other sequence.
        /// </summary>
        Index = Depth.S32,

        /// <summary>
        /// Specifies an edge of a graph.
        /// </summary>
        GraphEdge = 0,

        /// <summary>
        /// Specifies a vertex of a graph.
        /// </summary>
        GraphVertex = 0,

        /// <summary>
        /// Specifies a vertex of a binary tree.
        /// </summary>
        TreeVertex = 0,

        /// <summary>
        /// Specifies a connected component.
        /// </summary>
        ConnectedComponent = 0,

        /// <summary>
        /// Specifies a point in 3D space.
        /// </summary>
        Point3D = 13,
    }

    /// <summary>
    /// Specifies the kind of <see cref="Seq"/> instances.
    /// </summary>
    public enum SequenceKind : int
    {
        /// <summary>
        /// Specifies a generic array of elements.
        /// </summary>
        Generic = (0 << SeqHelper.ElementTypeBits),

        /// <summary>
        /// Specifies a sequence of elements that represents a geometrical curve.
        /// </summary>
        Curve = (1 << SeqHelper.ElementTypeBits),

        /// <summary>
        /// Specifies a binary tree of elements.
        /// </summary>
        BinaryTree = (2 << SeqHelper.ElementTypeBits),

        /// <summary>
        /// Specifies a graph of elements.
        /// </summary>
        Graph = (1 << SeqHelper.ElementTypeBits),

        /// <summary>
        /// Specifies a set of planar subdivisions.
        /// </summary>
        Subdiv2D = (2 << SeqHelper.ElementTypeBits)
    }

    /// <summary>
    /// Specifies a set of operational flags for <see cref="Seq"/> instances.
    /// </summary>
    [Flags]
    public enum SequenceFlags : int
    {
        /// <summary>
        /// Specifies that the geometrical curve is closed.
        /// </summary>
        Closed = (1 << SeqHelper.FlagShift),

        /// <summary>
        /// Specifies a simple sequence of elements.
        /// </summary>
        Simple = (0 << SeqHelper.FlagShift),

        /// <summary>
        /// Specifies that the geometrical curve is convex.
        /// </summary>
        Convex = (0 << SeqHelper.FlagShift),

        /// <summary>
        /// Specifies that the geometrical curve represents a hole.
        /// </summary>
        Hole = (2 << SeqHelper.FlagShift),

        /// <summary>
        /// Specifies that a graph type sequence is oriented.
        /// </summary>
        Oriented = (1 << SeqHelper.FlagShift)
    }

    /// <summary>
    /// Specifies the type of connectivity used for line rasterizing.
    /// </summary>
    public enum LineType : int
    {
        /// <summary>
        /// Specifies the 8-connected Bresenham algorithm.
        /// </summary>
        Connected8 = 8,

        /// <summary>
        /// Specifies the 4-connected Bresenham algorithm.
        /// </summary>
        Connected4 = 4,
    }

    /// <summary>
    /// Specifies flags for the line drawing algorithm used for rasterizing.
    /// </summary>
    [Flags]
    public enum LineFlags : int
    {
        /// <summary>
        /// Specifies the 8-connected Bresenham algorithm.
        /// </summary>
        Connected8 = 8,

        /// <summary>
        /// Specifies the 4-connected Bresenham algorithm.
        /// </summary>
        Connected4 = 4,

        /// <summary>
        /// Specifies anti-aliased lines drawn using gaussian filtering.
        /// </summary>
        AntiAliased = 16
    }

    /// <summary>
    /// Specifies font face flags for instances of <see cref="Font"/>.
    /// </summary>
    [Flags]
    public enum FontFace : int
    {
        /// <summary>
        /// Specifies a normal size sans-serif font.
        /// </summary>
        HersheySimplex = 0,

        /// <summary>
        /// Specifies a small size sans-serif font.
        /// </summary>
        HersheyPlain = 1,

        /// <summary>
        /// Specifies a normal size sans-serif font more complex than <see cref="HersheySimplex"/>.
        /// </summary>
        HersheyDuplex = 2,

        /// <summary>
        /// Specifies a normal size serif font.
        /// </summary>
        HersheyComplex = 3,

        /// <summary>
        /// Specifies a normal size serif font more complex than <see cref="HersheyComplex"/>.
        /// </summary>
        HersheyTriplex = 4,

        /// <summary>
        /// Specifies a smaller version of <see cref="HersheyComplex"/>.
        /// </summary>
        HersheyComplexSmall = 5,

        /// <summary>
        /// Specifies a hand-writing style font.
        /// </summary>
        HersheyScriptSimplex = 6,

        /// <summary>
        /// Specifies a more complex variant of <see cref="HersheyScriptSimplex"/>.
        /// </summary>
        HersheyScriptComplex = 7,

        /// <summary>
        /// Specifies that the font should be rendered in italic or oblique font.
        /// </summary>
        Italic = 16
    }

    /// <summary>
    /// Specifies available flags for creating <see cref="FileStorage"/> instances.
    /// </summary>
    [Flags]
    public enum StorageFlags : int
    {
        /// <summary>
        /// Specifies that the file should be open for reading.
        /// </summary>
        Read = 0,

        /// <summary>
        /// Specifies that the file should be open for writing.
        /// </summary>
        Write = 1,

        /// <summary>
        /// Specifies that the file should be open for appending.
        /// </summary>
        Append = 2,

        /// <summary>
        /// Specifies that all data in the file should be read or that write operations should
        /// target internal memory buffers.
        /// </summary>
        Memory = 4,

        /// <summary>
        /// Specifies that the file format should be automatically determined.
        /// </summary>
        FormatAuto = 0,

        /// <summary>
        /// Specifies that the XML file format should be used.
        /// </summary>
        FormatXml = 8,

        /// <summary>
        /// Specifies that the YAML file format should be used.
        /// </summary>
        FormatYaml = 16,
    }

    /// <summary>
    /// Specifies the available types of file storage node values.
    /// </summary>
    public enum FileNodeType : int
    {
        /// <summary>
        /// Specifies an integer type value.
        /// </summary>
        Integer = 1,

        /// <summary>
        /// Specifies a floating-point type value.
        /// </summary>
        Real = 2,

        /// <summary>
        /// Specifies a text string type value.
        /// </summary>
        String = 3,

        /// <summary>
        /// Specifies a reference type value.
        /// </summary>
        Ref = 4,

        /// <summary>
        /// Specifies a sequence node value.
        /// </summary>
        Seq = 5,

        /// <summary>
        /// Specifies a map node value.
        /// </summary>
        Map = 6,
    }

    /// <summary>
    /// Specifies type flags for writing compound structures to a <see cref="FileStorage"/> instance.
    /// </summary>
    [Flags]
    public enum StructStorageFlags : int
    {
        /// <summary>
        /// Specifies that the written structure is a sequence, that is, its elements do not have a name.
        /// </summary>
        Seq = 5,

        /// <summary>
        /// Specifies that the written structure is a map, that is, all its elements have names.
        /// </summary>
        Map = 6,

        /// <summary>
        /// Specifies that the structure is written as a flow (not as a block), which is more compact.
        /// This is an optional flag that is used only for YAML streams.
        /// </summary>
        Flow = 8
    }
}
