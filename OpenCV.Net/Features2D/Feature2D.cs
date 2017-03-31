using OpenCV.Net.Native;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents an abstract base class for simultaneous 2D feature detection
    /// and descriptor extraction.
    /// </summary>
    public abstract class Feature2D : CVHandle, IFeatureDetector, IDescriptorExtractor
    {
        internal Feature2D()
            : base(true)
        {
        }

        /// <summary>
        /// Gets the number of dimensions used to represent each keypoint descriptor,
        /// i.e. the columns of the descriptor array.
        /// </summary>
        public abstract int DescriptorSize { get; }

        /// <summary>
        /// Gets the type of the elements in the keypoint descriptor array.
        /// </summary>
        public abstract int DescriptorType { get; }

        /// <summary>
        /// Detects keypoints in the specified input image.
        /// </summary>
        /// <param name="image">The image on which to detect keypoints.</param>
        /// <param name="keyPoints">The collection that will contain the set of detected keypoints.</param>
        /// <param name="mask">The optional operation mask used to specify where to look for keypoints.</param>
        public abstract void Detect(Arr image, KeyPointCollection keyPoints, Arr mask = null);

        /// <summary>
        /// Computes the descriptors for a set of keypoints in an image.
        /// </summary>
        /// <param name="image">The image from which to extract keypoint descriptors.</param>
        /// <param name="keyPoints">
        /// The keypoints for which to extract descriptors. Keypoints for which a
        /// descriptor cannot be computed are removed.
        /// </param>
        /// <param name="descriptors">
        /// The array of descriptors computed for the specified set of keypoints.
        /// </param>
        public abstract void Compute(Arr image, KeyPointCollection keyPoints, Arr descriptors);
    }
}
