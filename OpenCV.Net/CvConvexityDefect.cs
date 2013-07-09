using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a contour convexity defect.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CvConvexityDefect
    {
        IntPtr start;
        IntPtr end;
        IntPtr depth_point;
        float depth;

        /// <summary>
        /// Gets the point of the contour where the defect begins.
        /// </summary>
        public CvPoint Start
        {
            get
            {
                unsafe
                {
                    return *((CvPoint*)start.ToPointer());
                }
            }
        }

        /// <summary>
        /// Gets the point of the contour where the defect ends.
        /// </summary>
        public CvPoint End
        {
            get
            {
                unsafe
                {
                    return *((CvPoint*)end.ToPointer());
                }
            }
        }

        /// <summary>
        /// Gets the farthest point from the convex hull within the defect.
        /// </summary>
        public CvPoint DepthPoint
        {
            get
            {
                unsafe
                {
                    return *((CvPoint*)depth_point.ToPointer());
                }
            }
        }

        /// <summary>
        /// Gets the distance between the farthest point and the convex hull.
        /// </summary>
        public float Depth
        {
            get { return depth; }
        }
    }
}
