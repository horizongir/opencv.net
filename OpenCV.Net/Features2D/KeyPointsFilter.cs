using OpenCV.Net.Native;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// This class provides utility methods for filtering a collection of keypoints.
    /// </summary>
    public static class KeyPointsFilter
    {
        /// <summary>
        /// Remove keypoints which lie within <paramref name="borderSize"/> of an image edge.
        /// </summary>
        /// <param name="keyPoints">The collection of keypoints to filter.</param>
        /// <param name="imageSize">The size of the input image.</param>
        /// <param name="borderSize">
        /// The minimum number of pixels by which keypoints should be
        /// away from the image edge.
        /// </param>
        public static void RunByImageBorder(KeyPointCollection keyPoints, Size imageSize, int borderSize)
        {
            NativeMethods.cv_features2d_KeyPointsFilter_runByImageBorder(keyPoints, imageSize, borderSize);
        }

        /// <summary>
        /// Remove keypoints with sizes outside of the specified range.
        /// </summary>
        /// <param name="keyPoints">The collection of keypoints to filter.</param>
        /// <param name="minSize">The minimum size of the keypoints.</param>
        public static void RunByKeypointSize(KeyPointCollection keyPoints, float minSize)
        {
            NativeMethods.cv_features2d_KeyPointsFilter_runByKeypointSize(keyPoints, minSize, float.MaxValue);
        }

        /// <summary>
        /// Remove keypoints with sizes outside of the specified range.
        /// </summary>
        /// <param name="keyPoints">The collection of keypoints to filter.</param>
        /// <param name="minSize">The minimum size of the keypoints.</param>
        /// <param name="maxSize">The maximum size of the keypoints.</param>
        public static void RunByKeypointSize(KeyPointCollection keyPoints, float minSize, float maxSize)
        {
            NativeMethods.cv_features2d_KeyPointsFilter_runByKeypointSize(keyPoints, minSize, maxSize);
        }

        /// <summary>
        /// Remove keypoints by checking whether they lie in the specified pixel operation mask.
        /// </summary>
        /// <param name="keyPoints">The collection of keypoints to filter.</param>
        /// <param name="mask">The operation mask used to filter the keypoints</param>
        public static void RunByPixelsMask(KeyPointCollection keyPoints, Arr mask)
        {
            NativeMethods.cv_features2d_KeyPointsFilter_runByPixelsMask(keyPoints, mask);
        }

        /// <summary>
        /// Remove duplicated keypoints.
        /// </summary>
        /// <param name="keyPoints">The collection of keypoints to filter.</param>
        public static void RemoveDuplicated(KeyPointCollection keyPoints)
        {
            NativeMethods.cv_features2d_KeyPointsFilter_removeDuplicated(keyPoints);
        }

        /// <summary>
        /// Retain the specified number of best keypoints, sorted by their response.
        /// </summary>
        /// <param name="keyPoints">The collection of keypoints to filter.</param>
        /// <param name="numPoints">The number of points to retain.</param>
        public static void RetainBest(KeyPointCollection keyPoints, int numPoints)
        {
            NativeMethods.cv_features2d_KeyPointsFilter_retainBest(keyPoints, numPoints);
        }
    }
}
