using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OpenCV.Net.Native
{
    public static class features2d
    {
        const string libName = "opencv_features2d243";

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSeq cvGetStarKeypoints(CvArr img, CvMemStorage storage, CvStarDetectorParams detectorParams);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSURFParams cvSURFParams(double hessianThreshold, int extended);
    }
}
