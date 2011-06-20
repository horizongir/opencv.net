using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OpenCV.Net
{
    public static class Video
    {
        const string libName = "opencv_video220";

        [DllImport(libName)]
        public static extern void cvCalcOpticalFlowLK(CvArr prev, CvArr curr, CvSize win_size, CvArr velx, CvArr vely);

        [DllImport(libName)]
        public static extern void cvCalcOpticalFlowHS(CvArr prev, CvArr curr, int usePrevious, CvArr velx, CvArr vely, double lambda, CvTermCriteria criteria);
    }
}
