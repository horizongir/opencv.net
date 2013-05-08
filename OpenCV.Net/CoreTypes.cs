using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace OpenCV.Net
{
    [Flags]
    public enum NormTypes : int
    {
        CV_C = 1,
        CV_L1 = 2,
        CV_L2 = 4,
        CV_NORM_MASK = 7,
        CV_RELATIVE = 8,
        CV_DIFF = 16,
        CV_MINMAX = 32,

        CV_DIFF_C = (CV_DIFF | CV_C),
        CV_DIFF_L1 = (CV_DIFF | CV_L1),
        CV_DIFF_L2 = (CV_DIFF | CV_L2),
        CV_RELATIVE_C = (CV_RELATIVE | CV_C),
        CV_RELATIVE_L1 = (CV_RELATIVE | CV_L1),
        CV_RELATIVE_L2 = (CV_RELATIVE | CV_L2)
    }

    public enum ReduceOperation : int
    {
        Sum,
        Avg,
        Max,
        Min
    }

    public enum ComparisonOperation : int
    {
        Equal = 0,
        GreaterThan = 1,
        GreaterOrEqual = 2,
        LessThan = 3,
        LessOrEqual = 4,
        NotEqual = 5
    }

    [Flags]
    public enum CheckArrayFlags : int
    {
        None = 0,
        CheckRange = 1,
        CheckQuiet = 2
    }

    public enum BorderType : int
    {
        Constant,
        Replicate,
        Reflect,
        Wrap
    }

    [Flags]
    public enum DiscreteTransformFlags : int
    {
        Forward = 0,
        Inverse = 1,
        Scale = 2, /* divide result by size of array */
        InverseScale = (Inverse + Scale),
        Rows = 4, /* transform each row individually */
        MultiplyConjugate = 8 /* conjugate the second argument of cvMulSpectrums */
    }

    public delegate int CvErrorCallback(int status, string func_name, string err_msg, string file_name, int line, IntPtr userData);

    public delegate IntPtr CvAllocFunc(IntPtr size, IntPtr userdata);

    public delegate int CvFreeFunc(IntPtr pptr, IntPtr userdata);

    public enum ErrorMode : int
    {
        Leaf,
        Parent,
        Silent
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CvRNG
    {
        ulong state;

        public CvRNG(long seed)
        {
            unchecked
            {
                state = seed > 0 ? (ulong)seed : (ulong)(long)-1;
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    [TypeConverter(typeof(NumericAggregateConverter))]
    public struct CvPoint
    {
        public static readonly CvPoint Zero = new CvPoint();

        public int X;
        public int Y;

        public CvPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public CvPoint(float x, float y)
        {
            X = (int)x;
            Y = (int)y;
        }

        public CvPoint(double x, double y)
        {
            X = (int)x;
            Y = (int)y;
        }

        public CvPoint(CvPoint2D32f point)
        {
            X = (int)point.X;
            Y = (int)point.Y;
        }

        public static CvPoint operator +(CvPoint pt1, CvPoint pt2)
        {
            return new CvPoint(pt1.X + pt2.X, pt1.Y + pt2.Y);
        }

        public static CvPoint operator -(CvPoint pt1, CvPoint pt2)
        {
            return new CvPoint(pt1.X - pt2.X, pt1.Y - pt2.Y);
        }

        public static CvPoint operator -(CvPoint pt)
        {
            return new CvPoint(-pt.X, -pt.Y);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    [TypeConverter(typeof(NumericAggregateConverter))]
    public struct CvPoint2D32f
    {
        public static readonly CvPoint2D32f Zero = new CvPoint2D32f();

        public float X;
        public float Y;

        public CvPoint2D32f(CvPoint point)
        {
            X = point.X;
            Y = point.Y;
        }

        public CvPoint2D32f(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static CvPoint2D32f operator *(CvPoint2D32f pt, float scalar)
        {
            return new CvPoint2D32f(scalar * pt.X, scalar * pt.Y);
        }

        public static CvPoint2D32f operator *(float scalar, CvPoint2D32f pt)
        {
            return new CvPoint2D32f(scalar * pt.X, scalar * pt.Y);
        }

        public static CvPoint2D32f operator +(CvPoint2D32f pt1, CvPoint2D32f pt2)
        {
            return new CvPoint2D32f(pt1.X + pt2.X, pt1.Y + pt2.Y);
        }

        public static CvPoint2D32f operator -(CvPoint2D32f pt1, CvPoint2D32f pt2)
        {
            return new CvPoint2D32f(pt1.X - pt2.X, pt1.Y - pt2.Y);
        }

        public static CvPoint2D32f operator -(CvPoint2D32f pt)
        {
            return new CvPoint2D32f(-pt.X, -pt.Y);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    [TypeConverter(typeof(NumericAggregateConverter))]
    public struct CvPoint2D64f
    {
        public static readonly CvPoint2D64f Zero = new CvPoint2D64f();

        public double X;
        public double Y;

        public CvPoint2D64f(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static CvPoint2D64f operator *(CvPoint2D64f pt, double scalar)
        {
            return new CvPoint2D64f(scalar * pt.X, scalar * pt.Y);
        }

        public static CvPoint2D64f operator *(double scalar, CvPoint2D64f pt)
        {
            return new CvPoint2D64f(scalar * pt.X, scalar * pt.Y);
        }

        public static CvPoint2D64f operator +(CvPoint2D64f pt1, CvPoint2D64f pt2)
        {
            return new CvPoint2D64f(pt1.X + pt2.X, pt1.Y + pt2.Y);
        }

        public static CvPoint2D64f operator -(CvPoint2D64f pt1, CvPoint2D64f pt2)
        {
            return new CvPoint2D64f(pt1.X - pt2.X, pt1.Y - pt2.Y);
        }

        public static CvPoint2D64f operator -(CvPoint2D64f pt)
        {
            return new CvPoint2D64f(-pt.X, -pt.Y);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    [TypeConverter(typeof(NumericAggregateConverter))]
    public struct CvPoint3D32f
    {
        public static readonly CvPoint3D32f Zero = new CvPoint3D32f();

        public float X;
        public float Y;
        public float Z;

        public CvPoint3D32f(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static CvPoint3D32f operator *(CvPoint3D32f pt, float scalar)
        {
            return new CvPoint3D32f(scalar * pt.X, scalar * pt.Y, scalar * pt.Z);
        }

        public static CvPoint3D32f operator *(float scalar, CvPoint3D32f pt)
        {
            return new CvPoint3D32f(scalar * pt.X, scalar * pt.Y, scalar * pt.Z);
        }

        public static CvPoint3D32f operator +(CvPoint3D32f pt1, CvPoint3D32f pt2)
        {
            return new CvPoint3D32f(pt1.X + pt2.X, pt1.Y + pt2.Y, pt1.Z + pt2.Z);
        }

        public static CvPoint3D32f operator -(CvPoint3D32f pt1, CvPoint3D32f pt2)
        {
            return new CvPoint3D32f(pt1.X - pt2.X, pt1.Y - pt2.Y, pt1.Z - pt2.Z);
        }

        public static CvPoint3D32f operator -(CvPoint3D32f pt)
        {
            return new CvPoint3D32f(-pt.X, -pt.Y, -pt.Z);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    [TypeConverter(typeof(NumericAggregateConverter))]
    public struct CvSize : IEquatable<CvSize>
    {
        public int Width;
        public int Height;

        public CvSize(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override int GetHashCode()
        {
            return Width.GetHashCode() ^ Height.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is CvSize)
            {
                return Equals((CvSize)obj);
            }

            return false;
        }

        public bool Equals(CvSize other)
        {
            return Width == other.Width && Height == other.Height;
        }

        public static bool operator ==(CvSize left, CvSize right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CvSize left, CvSize right)
        {
            return !left.Equals(right);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    [TypeConverter(typeof(NumericAggregateConverter))]
    public struct CvSize2D32f : IEquatable<CvSize2D32f>
    {
        public float Width;
        public float Height;

        public CvSize2D32f(float width, float height)
        {
            Width = width;
            Height = height;
        }

        public override int GetHashCode()
        {
            return Width.GetHashCode() ^ Height.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is CvSize2D32f)
            {
                return Equals((CvSize2D32f)obj);
            }

            return false;
        }

        public bool Equals(CvSize2D32f other)
        {
            return Width == other.Width && Height == other.Height;
        }

        public static bool operator ==(CvSize2D32f left, CvSize2D32f right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CvSize2D32f left, CvSize2D32f right)
        {
            return !left.Equals(right);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CvBox2D
    {
        public CvPoint2D32f Center;
        public CvSize2D32f Size;
        public float Angle;
    }

    [StructLayout(LayoutKind.Sequential)]
    [TypeConverter(typeof(NumericAggregateConverter))]
    public struct CvScalar
    {
        public double Val0;
        public double Val1;
        public double Val2;
        public double Val3;

        public CvScalar(double val0, double val1, double val2, double val3)
        {
            Val0 = val0;
            Val1 = val1;
            Val2 = val2;
            Val3 = val3;
        }

        public static CvScalar Real(double val0)
        {
            return new CvScalar(val0, 0, 0, 0);
        }

        public static CvScalar All(double val0123)
        {
            return new CvScalar(val0123, val0123, val0123, val0123);
        }

        public static CvScalar Rgb(double r, double g, double b)
        {
            return new CvScalar(b, g, r, 0);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CvTermCriteria
    {
        public TermCriteriaType Type;
        public int MaxIter;
        public double Epsilon;

        public CvTermCriteria(TermCriteriaType type, int maxIter, double epsilon)
        {
            Type = type;
            MaxIter = maxIter;
            Epsilon = epsilon;
        }
    }

    public enum FontFace : int
    {
        HersheySimplex = 0,
        HersheyPlain = 1,
        HersheyDuplex = 2,
        HersheyComplex = 3,
        HersheyTriplex = 4,
        HersheyComplexSmall = 5,
        HersheyScriptSimplex = 6,
        HersheyScriptComplex = 7
    }

    public enum CvRandDistribution : int
    {
        Uniform = 0,
        Normal = 1
    }

    [Flags]
    public enum SortFlags : int
    {
        EveryRow = 0,
        EveryColumn = 1,
        Ascending = 0,
        Descending = 16
    }

    [Flags]
    public enum GemmFlags : int
    {
        None = 0,
        TransposeA = 1,
        TransposeB = 2,
        TransposeC = 4
    }

    [Flags]
    public enum SvdFlags : int
    {
        None = 0,
        ModifyA = 1,
        TransposeU = 2,
        TransposeV = 4
    }

    public enum CvMatDepth : int
    {
        CV_8U = 0,
        CV_8S = 1,
        CV_16U = 2,
        CV_16S = 3,
        CV_32S = 4,
        CV_32F = 5,
        CV_64F = 6
    }

    public enum FlipMode : int
    {
        Vertical = 0,
        Horizontal = 1,
        Both = -1
    }

    public enum TermCriteriaType : int
    {
        None = 0,
        MaxIter = 1,
        Epsilon = 2
    }

    [Flags]
    public enum CovarianceFlags : int
    {
        Scrambled = 0,
        Normal = 1,
        UseAvg = 2,
        Scale = 4,
        Rows = 8,
        Cols = 16
    }

    [Flags]
    public enum PcaFlags : int
    {
        DataAsRow = 0,
        DataAsCol = 1,
        UseAvg = 2
    }

    public enum InversionMethod : int
    {
        LU = 0,
        Svd = 1,
        SvdSym = 2,
        Cholesky = 3,
        QR = 4,
        Normal = 16
    }

    [StructLayout(LayoutKind.Sequential)]
    [TypeConverter(typeof(NumericAggregateConverter))]
    public struct CvRect
    {
        public int X;
        public int Y;
        public int Width;
        public int Height;

        public CvRect(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CvAttrList
    {
        public IntPtr attr;
        public IntPtr next;
    }

    public enum FileStorageFlags : int
    {
        Read = 0,
        Write = 1,
        Append = 2
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CvSlice
    {
        public const int WholeSeqEndIndex = 0x3fffffff;
        public static readonly CvSlice WholeSeq = new CvSlice(0, WholeSeqEndIndex);

        public int start_index;
        public int end_index;

        public CvSlice(int start, int end)
        {
            start_index = start;
            end_index = end;
        }
    }
}
