using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents an algorithm for computing descriptors for image keypoints.
    /// </summary>
    /// <remarks>
    /// Keypoint descriptors are represented as dense, fixed-dimensional arrays
    /// of some basic type. Collection of descriptors are represented using the
    /// <see cref="Mat"/> type, where each row is one keypoint descriptor.
    /// </remarks>
    public interface IDescriptorExtractor
    {
        /// <summary>
        /// Gets the number of dimensions used to represent each keypoint descriptor,
        /// i.e. the columns of the descriptor array.
        /// </summary>
        int DescriptorSize { get; }

        /// <summary>
        /// Gets the type of the elements in the keypoint descriptor array.
        /// </summary>
        int DescriptorType { get; }

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
        void Compute(Arr image, KeyPointCollection keyPoints, Arr descriptors);
    }
}
