using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Provides a set of static methods for 2D image feature detectors, extractors and matchers.
    /// </summary>
    public static class FeatureExtensions
    {
        /// <summary>
        /// Detects keypoints in the specified input image.
        /// </summary>
        /// <param name="detector">The feature detector used to find image keypoints.</param>
        /// <param name="image">The image on which to detect keypoints.</param>
        /// <param name="mask">The optional operation mask used to specify where to look for keypoints.</param>
        /// <returns>The collection of detected keypoints.</returns>
        public static KeyPointCollection Detect(this IFeatureDetector detector, Arr image, Arr mask = null)
        {
            if (detector == null)
            {
                throw new ArgumentNullException("detector");
            }

            var keyPoints = new KeyPointCollection();
            detector.Detect(image, keyPoints, mask);
            return keyPoints;
        }

        /// <summary>
        /// Computes the descriptors for a set of keypoints in an image.
        /// </summary>
        /// <param name="extractor">The descriptor extractor used to compute keypoint descriptors.</param>
        /// <param name="image">The image from which to extract keypoint descriptors.</param>
        /// <param name="keyPoints">
        /// The keypoints for which to extract descriptors. Keypoints for which a
        /// descriptor cannot be computed are removed.
        /// </param>
        /// <returns>The array of descriptors computed for the specified set of keypoints.</returns>
        public static Mat Compute(this IDescriptorExtractor extractor, Arr image, KeyPointCollection keyPoints)
        {
            if (extractor == null)
            {
                throw new ArgumentNullException("extractor");
            }

            if (keyPoints == null)
            {
                throw new ArgumentNullException("keyPoints");
            }

            var descriptors = new Mat(keyPoints.Count, extractor.DescriptorSize, extractor.DescriptorType);
            extractor.Compute(image, keyPoints, descriptors);
            if (descriptors.Rows != keyPoints.Count)
            {
                descriptors = descriptors.GetSubRect(new Rect(0, 0, descriptors.Cols, keyPoints.Count));
            }

            return descriptors;
        }

        /// <summary>
        /// Finds the best match for each descriptor in <paramref name="queryDescriptors"/>.
        /// </summary>
        /// <param name="matcher">The descriptor matcher used to find correspondences between descriptor sets.</param>
        /// <param name="queryDescriptors">The set of descriptors for which to find the best match.</param>
        /// <param name="trainDescriptors">The training set of descriptors.</param>
        /// <param name="mask">
        /// The optional operation mask specifying permissible matches between input query descriptors
        /// and stored training descriptors.
        /// </param>
        /// <returns>
        /// The collection of best matches found for each permissible descriptor in
        /// <paramref name="queryDescriptors"/>.
        /// </returns>
        public static DMatchCollection Match(this IDescriptorMatcher matcher, Arr queryDescriptors, Arr trainDescriptors, Arr mask = null)
        {
            if (matcher == null)
            {
                throw new ArgumentNullException("matcher");
            }

            var matches = new DMatchCollection();
            matcher.Match(queryDescriptors, trainDescriptors, matches, mask);
            return matches;
        }
    }
}
