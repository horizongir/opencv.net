using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OpenCV.Net
{
    public static class Video
    {
        const string libName = "opencv_video231";

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCalcOpticalFlowLK(CvArr prev, CvArr curr, CvSize win_size, CvArr velx, CvArr vely);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCalcOpticalFlowHS(CvArr prev, CvArr curr, int usePrevious, CvArr velx, CvArr vely, double lambda, CvTermCriteria criteria);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCalcOpticalFlowPyrLK(CvArr prev, CvArr curr, CvArr prevPyr, CvArr currPyr, CvPoint2D32f[] prevFeatures, [Out]CvPoint2D32f[] currFeatures, int count, CvSize winSize, int level, byte[] status, float[] track_error, CvTermCriteria criteria, LKFlowFlags flags);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvUpdateMotionHistory(CvArr silhouette, CvArr mhi, double timestamp, double duration);
    }
}
