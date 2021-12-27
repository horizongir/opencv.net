using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net.Native
{
    [StructLayout(LayoutKind.Sequential)]
    struct _CvStereoBMState
    {
        public StereoBMPreFilterType preFilterType;
        public int preFilterSize;
        public int preFilterCap;

        public int SADWindowSize;
        public int minDisparity;
        public int numberOfDisparities;

        public int textureThreshold;
        public int uniquenessRatio;
        public int speckleWindowSize;
        public int speckleRange;
        public int trySmallerWindows;
        public Rect roi1, roi2;
        public int disp12MaxDiff;

        public IntPtr preFilteredImg0;
        public IntPtr preFilteredImg1;
        public IntPtr slidingSumBuf;
        public IntPtr cost;
        public IntPtr disp;
    }
}
