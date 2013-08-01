using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Specifies available operation flags for <see cref="CvHaarClassifierCascade.DetectObjects"/>.
    /// </summary>
    [Flags]
    public enum HaarDetectObjectFlags : int
    {
        /// <summary>
        /// Specifies that no operation flags are active.
        /// </summary>
        None = 0,

        /// <summary>
        /// Specifies that flat regions of the image (with no lines) should be skipped by the classifier.
        /// </summary>
        DoCannyPruning = 1,

        /// <summary>
        /// Specifies that the image should be scaled rather than the detector.
        /// </summary>
        ScaleImage = 2,

        /// <summary>
        /// Specifies that only the largest object found should be returned.
        /// </summary>
        FindBiggestObject = 4,

        /// <summary>
        /// Specifies that the search should terminate at whatever scale the first candidate is found.
        /// Used only in combination with <see cref="FindBiggestObject"/>.
        /// </summary>
        DoRoughSearch = 8
    }
}
