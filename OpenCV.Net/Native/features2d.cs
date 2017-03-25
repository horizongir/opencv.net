using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net.Native
{
    static partial class NativeMethods
    {
        const string features2dLib = "opencv_features2d" + libSuffix;

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cv_features2d_KeyPoint_convert_vector_KeyPoint(
            KeyPointCollection keypoints,
            Point2fCollection points2f,
            Int32Collection keypointIndexes);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cv_features2d_KeyPoint_convert_vector_Point2f(
            Point2fCollection points2f,
            KeyPointCollection keypoints,
            float size,
            float response,
            int octave,
            int class_id);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern float cv_features2d_KeyPoint_overlap(ref KeyPoint kp1, ref KeyPoint kp2);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cv_features2d_KeyPointsFilter_runByImageBorder(KeyPointCollection keypoints, Size imageSize, int borderSize);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cv_features2d_KeyPointsFilter_runByKeypointSize(KeyPointCollection keypoints, float minSize, float maxSize);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cv_features2d_KeyPointsFilter_runByPixelsMask(KeyPointCollection keypoints, Arr mask);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cv_features2d_KeyPointsFilter_removeDuplicated(KeyPointCollection keypoints);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cv_features2d_KeyPointsFilter_retainBest(KeyPointCollection keypoints, int npoints);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cv_features2d_FAST(IplImage image, KeyPointCollection keypoints, int threshold, bool nonmaxSupression);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cv_features2d_FASTX(IplImage image, KeyPointCollection keypoints, int threshold, bool nonmaxSupression, int type);
    }
}
