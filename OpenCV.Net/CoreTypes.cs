using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OpenCV.Net
{
    public delegate int CvErrorCallback(int status, string func_name, string err_msg, string file_name, int line);

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
    public struct CvPoint
    {
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
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CvPoint2D32f
    {
        public float X;
        public float Y;

        public CvPoint2D32f(float x, float y)
        {
            X = x;
            Y = y;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CvPoint3D32f
    {
        public float X;
        public float Y;
        public float Z;

        public CvPoint3D32f(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CvSize
    {
        public int Width;
        public int Height;

        public CvSize(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
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

    public enum CvRandDistribution : int
    {
        Uniform = 0,
        Normal = 1
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

    [StructLayout(LayoutKind.Sequential)]
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
