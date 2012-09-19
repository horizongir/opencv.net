using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using OpenCV.Net.Native;

namespace OpenCV.Net
{
    [StructLayout(LayoutKind.Sequential)]
    public struct KeyPoint
    {
        public CvPoint2D32f Point;
        public float Size;
        public float Angle;
        public float Response;
        public int Octave;
        public int ClassId;

        public KeyPoint(CvPoint2D32f point, float size = 0, float angle = -1, float response = 0, int octave = 0, int classId = -1)
        {
            Point = point;
            Size = size;
            Angle = angle;
            Response = response;
            Octave = octave;
            ClassId = classId;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CvSURFPoint
    {
        public CvPoint2D32f Point;
        public int Laplacian;
        public int Size;
        public float Direction;
        public float Hessian;

        public CvSURFPoint(CvPoint2D32f point, int laplacian, int size)
            : this(point, laplacian, size, 0, 0)
        {
        }

        public CvSURFPoint(CvPoint2D32f point, int laplacian, int size, float direction)
            : this(point, laplacian, size, direction, 0)
        {
        }

        public CvSURFPoint(CvPoint2D32f point, int laplacian, int size, float direction, float hessian)
        {
            Point = point;
            Laplacian = laplacian;
            Size = size;
            Direction = direction;
            Hessian = hessian;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CvSURFParams
    {
        public int Extended;
        public int Upright;
        public double HessianThreshold;

        public int NumOctaves;
        public int NumOctaveLayers;

        public CvSURFParams(double hessianThreshold)
            : this(hessianThreshold, 0)
        {
        }

        public CvSURFParams(double hessianThreshold, int extended)
        {
            var surfParams = features2d.cvSURFParams(hessianThreshold, extended);
            Extended = surfParams.Extended;
            Upright = surfParams.Upright;
            HessianThreshold = surfParams.HessianThreshold;
            NumOctaves = surfParams.NumOctaves;
            NumOctaveLayers = surfParams.NumOctaveLayers;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CvStarKeypoint
    {
        public CvPoint Point;
        public int Size;
        public float Response;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CvStarDetectorParams
    {
        public int MaxSize;
        public int ResponseThreshold;
        public int LineThresholdProjected;
        public int LineThresholdBinarized;
        public int SuppressNonmaxSize;

        public CvStarDetectorParams(int maxSize)
        {
            MaxSize = maxSize;
            ResponseThreshold = 30;
            LineThresholdProjected = 10;
            LineThresholdBinarized = 8;
            SuppressNonmaxSize = 5;
        }
    }
}
