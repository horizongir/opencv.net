using OpenCV.Net.Native;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCV.Net
{
    public static partial class CV
    {
        /// <summary>
        /// Detects corners using the FAST algorithm.
        /// </summary>
        /// <param name="image">The image on which to detect keypoints.</param>
        /// <param name="keyPoints">The collection that will contain the set of detected keypoints.</param>
        /// <param name="threshold">
        /// The threshold applied to the difference between the intensity of each central pixel
        /// and the pixels lying in a circle around this pixel.
        /// </param>
        /// <param name="nonMaxSuppression">Specifies whether to apply non-maximum suppression on detected corners.</param>
        public static void FAST(Arr image, KeyPointCollection keyPoints, int threshold, bool nonMaxSuppression = true)
        {
            NativeMethods.cv_features2d_FAST(image, keyPoints, threshold, nonMaxSuppression);
        }

        /// <summary>
        /// Detects corners using the FAST algorithm.
        /// </summary>
        /// <param name="image">The image on which to detect keypoints.</param>
        /// <param name="keyPoints">The collection that will contain the set of detected keypoints.</param>
        /// <param name="threshold">
        /// The threshold applied to the difference between the intensity of each central pixel
        /// and the pixels lying in a circle around this pixel.
        /// </param>
        /// <param name="nonMaxSuppression">Specifies whether to apply non-maximum suppression on detected corners.</param>
        /// <param name="type">The type of pixel neighborhood.</param>
        public static void FAST(Arr image, KeyPointCollection keyPoints, int threshold, bool nonMaxSuppression, FastDetectorType type)
        {
            NativeMethods.cv_features2d_FASTX(image, keyPoints, threshold, nonMaxSuppression, type);
        }

        /// <summary>
        /// Draws a visual representation of detected keypoints in an image.
        /// </summary>
        /// <param name="image">The image on which the keypoints were detected.</param>
        /// <param name="keyPoints">The collection of keypoints to draw.</param>
        /// <param name="output">The image where the keypoints are to be drawn.</param>
        public static void DrawKeypoints(Arr image, KeyPointCollection keyPoints, Arr output)
        {
            DrawKeypoints(image, keyPoints, output, Scalar.All(-1));
        }

        /// <summary>
        /// Draws a visual representation of detected keypoints in an image.
        /// </summary>
        /// <param name="image">The image on which the keypoints were detected.</param>
        /// <param name="keyPoints">The collection of keypoints to draw.</param>
        /// <param name="output">The image where the keypoints are to be drawn.</param>
        /// <param name="color">The color of the keypoints.</param>
        /// <param name="flags">Optional operation flags specifying how the keypoints are to be drawn.</param>
        public static void DrawKeypoints(Arr image, KeyPointCollection keyPoints, Arr output, Scalar color, DrawMatchesFlags flags = DrawMatchesFlags.None)
        {
            NativeMethods.cv_features2d_drawKeypoints(image, keyPoints, output, color, flags);
        }

        /// <summary>
        /// Draw keypoint matches from two images on the output image.
        /// </summary>
        /// <param name="image1">The first image.</param>
        /// <param name="keyPoints1">The collection of keypoints from the first image.</param>
        /// <param name="image2">The second image.</param>
        /// <param name="keyPoints2">The collection of keypoints from the second image.</param>
        /// <param name="matches">The matches from the first image to the second image.</param>
        /// <param name="outImage">The image where the keypoint matches are to be drawn.</param>
        public static void DrawMatches(
            Arr image1, KeyPointCollection keyPoints1,
            Arr image2, KeyPointCollection keyPoints2,
            DMatchCollection matches, Arr outImage)
        {
            DrawMatches(image1, keyPoints1, image2, keyPoints2, matches, outImage, Scalar.All(-1));
        }

        /// <summary>
        /// Draw keypoint matches from two images on the output image.
        /// </summary>
        /// <param name="image1">The first image.</param>
        /// <param name="keyPoints1">The collection of keypoints from the first image.</param>
        /// <param name="image2">The second image.</param>
        /// <param name="keyPoints2">The collection of keypoints from the second image.</param>
        /// <param name="matches">The matches from the first image to the second image.</param>
        /// <param name="outImage">The image where the keypoint matches are to be drawn.</param>
        /// <param name="matchColor">The color used for drawing successful matches.</param>
        public static void DrawMatches(
            Arr image1, KeyPointCollection keyPoints1,
            Arr image2, KeyPointCollection keyPoints2,
            DMatchCollection matches, Arr outImage,
            Scalar matchColor)
        {
            DrawMatches(image1, keyPoints1, image2, keyPoints2, matches, outImage, matchColor, Scalar.All(-1));
        }

        /// <summary>
        /// Draw keypoint matches from two images on the output image.
        /// </summary>
        /// <param name="image1">The first image.</param>
        /// <param name="keyPoints1">The collection of keypoints from the first image.</param>
        /// <param name="image2">The second image.</param>
        /// <param name="keyPoints2">The collection of keypoints from the second image.</param>
        /// <param name="matches">The matches from the first image to the second image.</param>
        /// <param name="outImage">The image where the keypoint matches are to be drawn.</param>
        /// <param name="matchColor">The color used for drawing successful matches.</param>
        /// <param name="singlePointColor">The color used for drawing unmatched keypoints.</param>
        /// <param name="matchesMask">The optional mask specifying which matches are drawn.</param>
        /// <param name="flags">Optional operation flags specifying how the matches are to be drawn.</param>
        public static void DrawMatches(
            Arr image1, KeyPointCollection keyPoints1,
            Arr image2, KeyPointCollection keyPoints2,
            DMatchCollection matches, Arr outImage,
            Scalar matchColor,
            Scalar singlePointColor,
            ByteCollection matchesMask = null,
            DrawMatchesFlags flags = DrawMatchesFlags.None)
        {
            NativeMethods.cv_features2d_drawMatches(
                image1, keyPoints1,
                image2, keyPoints2,
                matches, outImage,
                matchColor, singlePointColor,
                matchesMask ?? ByteCollection.Null, flags);
        }
    }
}
