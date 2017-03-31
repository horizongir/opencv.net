using OpenCV.Net.Native;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents an implementation of the ORB keypoint detector and descriptor extractor.
    /// </summary>
    public class Orb : Feature2D
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Orb"/> class with
        /// the specified parameters.
        /// </summary>
        /// <param name="numFeatures">The maximum number of features to retain.</param>
        /// <param name="scaleFactor">The pyramid decimation ratio, which must be greater than one.</param>
        /// <param name="numLevels">The number of pyramid levels.</param>
        /// <param name="edgeThreshold">The size of the border where features are not detected.</param>
        /// <param name="firstLevel">This parameter should always be zero in the current implementation.</param>
        /// <param name="wtaK">The number of points that produce each element of the oriented BRIEF descriptor.</param>
        /// <param name="scoreType">The type of score used to rank detected features.</param>
        /// <param name="patchSize">The size of the patch used by each oriented BRIEF descriptor.</param>
        public Orb(
            int numFeatures = 500,
            float scaleFactor = 1.2f,
            int numLevels = 8,
            int edgeThreshold = 31,
            int firstLevel = 0,
            int wtaK = 2,
            OrbScoreType scoreType = OrbScoreType.HarrisScore,
            int patchSize = 31)
        {
            var handle = NativeMethods.cv_features2d_ORB_new(
                numFeatures,
                scaleFactor,
                numLevels,
                edgeThreshold,
                firstLevel,
                wtaK,
                scoreType,
                patchSize);
            SetHandle(handle);
        }

        /// <summary>
        /// Gets the number of dimensions used to represent each keypoint descriptor,
        /// i.e. the columns of the descriptor array.
        /// </summary>
        public override int DescriptorSize
        {
            get { return NativeMethods.cv_features2d_ORB_descriptorSize(this); }
        }

        /// <summary>
        /// Gets the type of the elements in the keypoint descriptor array.
        /// </summary>
        public override int DescriptorType
        {
            get { return NativeMethods.cv_features2d_ORB_descriptorType(this); }
        }

        /// <summary>
        /// Detects keypoints in the specified input image.
        /// </summary>
        /// <param name="image">The image on which to detect keypoints.</param>
        /// <param name="keyPoints">The collection that will contain the set of detected keypoints.</param>
        /// <param name="mask">The optional operation mask used to specify where to look for keypoints.</param>
        public override void Detect(Arr image, KeyPointCollection keyPoints, Arr mask = null)
        {
            NativeMethods.cv_features2d_ORB_detect(this, image, keyPoints, mask ?? Arr.Null);
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
            NativeMethods.cv_features2d_ORB_compute(this, image, keyPoints, descriptors);
        }

        /// <summary>
        /// Executes the code required to free the native <see cref="Orb"/> handle.
        /// </summary>
        /// <returns>
        /// <b>true</b> if the handle is released successfully; otherwise, in the event of a
        /// catastrophic failure, <b>false</b>.
        /// </returns>
        protected override bool ReleaseHandle()
        {
            NativeMethods.cv_features2d_ORB_delete(handle);
            return true;
        }
    }
}
