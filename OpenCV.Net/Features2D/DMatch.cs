using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a pairwise comparison between keypoint descriptors.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DMatch
    {
        /// <summary>
        /// The index of the matched descriptor in the query set.
        /// </summary>
        public int QueryIndex;

        /// <summary>
        /// The index of the matched descriptor in the training set.
        /// </summary>
        public int TrainIndex;

        /// <summary>
        /// The index of the image used to compute the descriptor training set.
        /// </summary>
        public int ImageIndex;

        /// <summary>
        /// The computed distance between the keypoint descriptors.
        /// </summary>
        public float Distance;
    }
}
