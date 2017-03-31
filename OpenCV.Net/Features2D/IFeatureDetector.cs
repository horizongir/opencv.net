using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents an algorithm for detecting 2D image features.
    /// </summary>
    public interface IFeatureDetector
    {
        /// <summary>
        /// Detects keypoints in the specified input image.
        /// </summary>
        /// <param name="image">The image on which to detect keypoints.</param>
        /// <param name="keyPoints">The collection that will contain the set of detected keypoints.</param>
        /// <param name="mask">The optional operation mask used to specify where to look for keypoints.</param>
        void Detect(Arr image, KeyPointCollection keyPoints, Arr mask = null);
    }
}
