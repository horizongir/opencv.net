using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net.Native
{
    static partial class NativeMethods
    {
        const string videoLib = "opencv_video" + libSuffix;

        #region Motion Analysis

        [DllImport(videoLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCalcOpticalFlowPyrLK(
            Arr prev,
            Arr curr,
            Arr prev_pyr,
            Arr curr_pyr,
            Point2f[] prev_features,
            [In, Out]Point2f[] curr_features,
            int count,
            Size win_size,
            int level,
            [Out]byte[] status,
            [Out]float[] track_error,
            TermCriteria criteria,
            LKFlowFlags flags);

        [DllImport(videoLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCalcAffineFlowPyrLK(
            Arr prev,
            Arr curr,
            Arr prev_pyr,
            Arr curr_pyr,
            Point2f[] prev_features,
            [In, Out]Point2f[] curr_features,
            float[] matrices,
            int count,
            Size win_size,
            int level,
            [Out]byte[] status,
            [Out]float[] track_error,
            TermCriteria criteria,
            LKFlowFlags flags);

        [DllImport(videoLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvEstimateRigidTransform(Arr A, Arr B, Mat M, int full_affine);

        [DllImport(videoLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCalcOpticalFlowFarneback(
            Arr prev,
            Arr next,
            Arr flow,
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
        internal static extern void cvUpdateMotionHistory(Arr silhouette, Arr mhi, double timestamp, double duration);

        [DllImport(videoLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCalcMotionGradient(
            Arr mhi,
            Arr mask,
            Arr orientation,
            double delta1,
            double delta2,
            int aperture_size);

        [DllImport(videoLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvCalcGlobalOrientation(
            Arr orientation,
            Arr mask,
            Arr mhi,
            double timestamp,
            double duration);

        [DllImport(videoLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Seq cvSegmentMotion(
            Arr mhi,
            Arr seg_mask,
            MemStorage storage,
            double timestamp,
            double seg_thresh);

        #endregion

        #region Tracking

        [DllImport(videoLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvCamShift(
            Arr prob_image,
            Rect window,
            TermCriteria criteria,
            out ConnectedComp comp,
            out RotatedRect box);

        [DllImport(videoLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvMeanShift(Arr prob_image, Rect window, TermCriteria criteria, out ConnectedComp comp);

        [DllImport(videoLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCreateKalman(int dynam_params, int measure_params, int control_params);

        [DllImport(videoLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvReleaseKalman(ref IntPtr kalman);

        [DllImport(videoLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvKalmanPredict(KalmanFilter kalman, Mat control);

        [DllImport(videoLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvKalmanCorrect(KalmanFilter kalman, Mat measurement);

        #endregion
    }
}
