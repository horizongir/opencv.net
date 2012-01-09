using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OpenCV.Net.Native
{
    static class video
    {
        const string libName = "opencv_video231";

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateKalman(int dynam_params, int measure_params, int control_params);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvKalmanPredict(IntPtr kalman, CvMat control);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvKalmanCorrect(IntPtr kalman, CvMat measurement);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReleaseKalman(IntPtr kalman);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReleaseBGStatModel(IntPtr bg_model);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvUpdateBGStatModel(IplImage current_frame, CvBGStatModel bg_model, double learningRate);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvRefineForegroundMaskBySegm(CvSeq segments, CvBGStatModel bg_model);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateFGDStatModel(IplImage first_frame, IntPtr parameters);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateGaussianBGModel(IplImage first_frame, IntPtr parameters);
    }
}
