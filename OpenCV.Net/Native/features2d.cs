using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net.Native
{
    static partial class NativeMethods
    {
        const string features2dLib = "opencv_features2d" + libSuffix;

        #region KeyPoint class

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

        #endregion

        #region BRISK class

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cv_features2d_BRISK_new(int thresh, int octaves, float patternScale);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cv_features2d_BRISK_detect(Brisk detector, Arr image, KeyPointCollection keypoints, Arr mask);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cv_features2d_BRISK_compute(Brisk extractor, Arr image, KeyPointCollection keypoints, Arr descriptors);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cv_features2d_BRISK_descriptorSize(Brisk extractor);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cv_features2d_BRISK_descriptorType(Brisk extractor);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cv_features2d_BRISK_delete(IntPtr feature);

        #endregion

        #region ORB class

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cv_features2d_ORB_new(
            int nfeatures,
            float scaleFactor,
            int nlevels,
            int edgeThreshold,
            int firstLevel,
            int WTA_K,
            OrbScoreType scoreType,
            int patchSize);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cv_features2d_ORB_detect(Orb detector, Arr image, KeyPointCollection keypoints, Arr mask);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cv_features2d_ORB_compute(Orb extractor, Arr image, KeyPointCollection keypoints, Arr descriptors);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cv_features2d_ORB_descriptorSize(Orb extractor);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cv_features2d_ORB_descriptorType(Orb extractor);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cv_features2d_ORB_delete(IntPtr feature);

        #endregion

        #region BFMatcher class

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cv_features2d_BFMatcher_new(NormTypes normType, [MarshalAs(UnmanagedType.I1)]bool crossCheck);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cv_features2d_BFMatcher_match(BFMatcher matcher, Arr queryDescriptors, Arr trainDescriptors, DMatchCollection matches, Arr mask);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cv_features2d_BFMatcher_delete(IntPtr matcher);

        #endregion

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cv_features2d_FAST(Arr image, KeyPointCollection keypoints, int threshold, bool nonmaxSupression);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cv_features2d_FASTX(Arr image, KeyPointCollection keypoints, int threshold, bool nonmaxSupression, FastDetectorType type);

        #region DescriptorMatcher class

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cv_features2d_DescriptorMatcher_match(
            DescriptorMatcher matcher,
            Arr queryDescriptors,
            Arr trainDescriptors,
            DMatchCollection matches,
            Arr mask);

        #endregion

        #region Drawing functions

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cv_features2d_drawKeypoints(Arr image, KeyPointCollection keypoints, Arr output, Scalar color, DrawMatchesFlags flags);

        [DllImport(externLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cv_features2d_drawMatches(
            Arr img1, KeyPointCollection keypoints1,
            Arr img2, KeyPointCollection keypoints2,
            DMatchCollection matches1to2, Arr outImg,
            Scalar matchColor,
            Scalar singlePointColor,
            ByteCollection matchesMask,
            DrawMatchesFlags flags);

        #endregion
    }
}
