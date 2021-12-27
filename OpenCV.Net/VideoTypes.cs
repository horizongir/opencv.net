using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Specifies available operation flags for <see cref="CV.CalcOpticalFlowPyrLK"/> and
    /// <see cref="CV.CalcAffineFlowPyrLK"/>.
    /// </summary>
    [Flags]
    public enum LKFlowFlags : int
    {
        /// <summary>
        /// Specifies that no operation flags are active.
        /// </summary>
        None = 0,

        /// <summary>
        /// Specifies that the pyramid for the first frame was precalculated before the call.
        /// </summary>
        PyrAReady = 1,

        /// <summary>
        /// Specifies that the pyramid for the second frame was precalculated before the call.
        /// </summary>
        PyrBReady = 2,

        /// <summary>
        /// Specifies that output array contains initial coordinate estimates of the features.
        /// </summary>
        InitialGuesses = 4,

        /// <summary>
        /// Specifies that output error array will contain the minimum eigenvalues of detected features.
        /// </summary>
        GetMinEigenVals = 8
    }

    /// <summary>
    /// Specifies available operation flags for <see cref="CV.CalcOpticalFlowFarneback"/>.
    /// </summary>
    [Flags]
    public enum FarnebackFlowFlags : int
    {
        /// <summary>
        /// Specifies that no operation flags are active.
        /// </summary>
        None = 0,

        /// <summary>
        /// Specifies that output array contains the initial flow approximation.
        /// </summary>
        InitialFlow = 4,

        /// <summary>
        /// Specifies that a Gaussian filter should be used instead of a box filter for optical flow estimation.
        /// Usually, this option gives more accurate flow than a box filter, at the cost of lower speed.
        /// The size of the Gaussian window should be set to a larger value to achieve the same level of robustness.
        /// </summary>
        Gaussian = 256
    }
}
