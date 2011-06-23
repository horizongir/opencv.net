using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OpenCV.Net.Native
{
    static class video
    {
        const string libName = "opencv_video220";

        [DllImport(libName)]
        public static extern IntPtr cvCreateKalman(int dynam_params, int measure_params, int control_params);

        [DllImport(libName)]
        public static extern IntPtr cvKalmanPredict(IntPtr kalman, CvMat control);

        [DllImport(libName)]
        public static extern IntPtr cvKalmanCorrect(IntPtr kalman, CvMat measurement);

        [DllImport(libName)]
        public static extern void cvReleaseKalman(IntPtr kalman);
    }
}
