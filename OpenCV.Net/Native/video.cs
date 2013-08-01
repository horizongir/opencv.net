using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net.Native
{
    static partial class NativeMethods
    {
        const string videoLib = "opencv_video246";

        #region Motion Analysis

        [DllImport(videoLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCalcOpticalFlowPyrLK(
            CvArr prev,
            CvArr curr,
            CvArr prev_pyr,
            CvArr curr_pyr,
            CvPoint2D32f[] prev_features,
            [Out]CvPoint2D32f[] curr_features,
            int count,
            CvSize win_size,
            int level,
            [Out]byte[] status,
            [Out]float[] track_error,
            CvTermCriteria criteria,
            LKFlowFlags flags);

        [DllImport(videoLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCalcAffineFlowPyrLK(
            CvArr prev,
            CvArr curr,
            CvArr prev_pyr,
            CvArr curr_pyr,
            CvPoint2D32f[] prev_features,
            [Out]CvPoint2D32f[] curr_features,
            float[] matrices,
            int count,
            CvSize win_size,
            int level,
            [Out]byte[] status,
            [Out]float[] track_error,
            CvTermCriteria criteria,
            LKFlowFlags flags);

        [DllImport(videoLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvEstimateRigidTransform(CvArr A, CvArr B, CvMat M, int full_affine);

        [DllImport(videoLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCalcOpticalFlowFarneback(
            CvArr prev,
            CvArr next,
            CvArr flow,
            double pyr_scale,
            int levels,
            int winsize,
            int iterations,
            int poly_n,
            double poly_sigma,
            FarnebackFlowFlags flags);

        #endregion

        #region Motion templates

        [DllImport(videoLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvUpdateMotionHistory(CvArr silhouette, CvArr mhi, double timestamp, double duration);

        [DllImport(videoLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCalcMotionGradient(
            CvArr mhi,
            CvArr mask,
            CvArr orientation,
            double delta1,
            double delta2,
            int aperture_size);

        [DllImport(videoLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvCalcGlobalOrientation(
            CvArr orientation,
            CvArr mask,
            CvArr mhi,
            double timestamp,
            double duration);

        [DllImport(videoLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CvSeq cvSegmentMotion(
            CvArr mhi,
            CvArr seg_mask,
            CvMemStorage storage,
            double timestamp,
            double seg_thresh);

        #endregion

        #region Tracking

        [DllImport(videoLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvCamShift(
            CvArr prob_image,
            CvRect window,
            CvTermCriteria criteria,
            out CvConnectedComp comp,
            out CvBox2D box);

        [DllImport(videoLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvMeanShift(CvArr prob_image, CvRect window, CvTermCriteria criteria, out CvConnectedComp comp);

        [DllImport(videoLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCreateKalman(int dynam_params, int measure_params, int control_params);

        [DllImport(videoLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvReleaseKalman(ref IntPtr kalman);

        [DllImport(videoLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvKalmanPredict(CvKalman kalman, CvMat control);

        [DllImport(videoLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvKalmanCorrect(CvKalman kalman, CvMat measurement);

        #endregion
    }
}
