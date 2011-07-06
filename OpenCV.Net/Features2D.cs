using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OpenCV.Net
{
    public static class Features2D
    {
        const string libName = "opencv_features2d230";

        [DllImport(libName)]
        public static extern CvSeq cvGetStarKeypoints(CvArr img, CvMemStorage storage, CvStarDetectorParams detectorParams);
    }
}
