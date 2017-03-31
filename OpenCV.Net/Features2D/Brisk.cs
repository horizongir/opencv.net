using OpenCV.Net.Native;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents an implementation of the BRISK keypoint detector and descriptor extractor.
    /// </summary>
    public class Brisk : Feature2D
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Brisk"/> class with
        /// the specified parameters.
        /// </summary>
        /// <param name="threshold">The detection threshold score.</param>
        /// <param name="octaves">The number of detection octaves (i.e. pyramid levels) to use.</param>
        /// <param name="patternScale">
        /// The scale applied to the pattern used for sampling the neighbourhood of a keypoint.
        /// </param>
        public Brisk(int threshold = 30, int octaves = 3, float patternScale = 1.0f)
        {
            var handle = NativeMethods.cv_features2d_BRISK_new(threshold, octaves, patternScale);
            SetHandle(handle);
        }

        /// <summary>
        /// Gets the number of dimensions used to represent each keypoint descriptor,
        /// i.e. the columns of the descriptor array.
        /// </summary>
        public override int DescriptorSize
        {
            get { return NativeMethods.cv_features2d_BRISK_descriptorSize(this); }
        }

        /// <summary>
        /// Gets the type of the elements in the keypoint descriptor array.
        /// </summary>
        public override int DescriptorType
        {
            get { return NativeMethods.cv_features2d_BRISK_descriptorType(this); }
        }

        /// <summary>
        /// Detects keypoints in the specified input image.
        /// </summary>
        /// <param name="image">The image on which to detect keypoints.</param>
        /// <param name="keyPoints">The collection that will contain the set of detected keypoints.</param>
        /// <param name="mask">The optional operation mask used to specify where to look for keypoints.</param>
        public override void Detect(Arr image, KeyPointCollection keyPoints, Arr mask = null)
        {
            NativeMethods.cv_features2d_BRISK_detect(this, image, keyPoints, mask ?? Arr.Null);
        }

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
        public override void Compute(Arr image, KeyPointCollection keyPoints, Arr descriptors)
        {
            NativeMethods.cv_features2d_BRISK_compute(this, image, keyPoints, descriptors);
        }

        /// <summary>
        /// Executes the code required to free the native <see cref="Brisk"/> handle.
        /// </summary>
        /// <returns>
        /// <b>true</b> if the handle is released successfully; otherwise, in the event of a
        /// catastrophic failure, <b>false</b>.
        /// </returns>
        protected override bool ReleaseHandle()
        {
            NativeMethods.cv_features2d_BRISK_delete(handle);
            return true;
        }
    }
}
