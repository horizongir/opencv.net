using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OpenCV.Net
{
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
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CvRect
    {
        public int X;
        public int Y;
        public int Width;
        public int Height;
    }
}
