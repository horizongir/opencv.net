using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Specifies available methods for computing the fundamental matrix.
    /// </summary>
    public enum FundamentalMatrixMethod : int
    {
        /// <summary>
        /// Specifies a 7-point algorithm (N = 7).
        /// </summary>
        Point7 = 1,

        /// <summary>
        /// Specifies an 8-point algorithm (N >= 8).
        /// </summary>
        Point8 = 2,

        /// <summary>
        /// Specifies the Least-Median robust method (N >= 8).
        /// </summary>
        LMedS = 4,

        /// <summary>
        /// Specifies the RANSAC algorithm (N >= 8).
        /// </summary>
        Ransac = 8
    }

    /// <summary>
    /// Specifies available methods for computing the homography matrix.
    /// </summary>
    public enum FindHomographyMethod : int
    {
        /// <summary>
        /// Specifies a regular method using all the points.
        /// </summary>
        Regular = 0,

        /// <summary>
        /// Specifies a Least-Median robust method.
        /// </summary>
        LMedS = 4,

        /// <summary>
        /// Specifies a RANSAC-based robust method.
        /// </summary>
        Ransac = 8,
    }

    /// <summary>
    /// Specifies available operation flags for finding chessboard corners.
    /// </summary>
    [Flags]
    public enum ChessboardCalibrationFlags : int
    {
        /// <summary>
        /// Specifies that no operation flags are active.
        /// </summary>
        None = 0,

        /// <summary>
        /// Specifies that adaptive thresholding should be used to convert the image to black and white,
        /// rather than a fixed threshold level (computed from the average image brightness).
        /// </summary>
        AdaptiveThreshold = 1,

        /// <summary>
        /// Specifies the image gamma should be normalized with <see cref="CV.EqualizeHist"/> before
        /// applying fixed or adaptive thresholding.
        /// </summary>
        NormalizeImage = 2,

        /// <summary>
        /// Specifies that additional criteria (like contour area, perimeter, square-like shape) should be
        /// used to filter out false quads extracted at the contour retrieval stage.
        /// </summary>
        FilterQuads = 4,

        /// <summary>
        /// Specifies that a fast check should be run on the image that looks for chessboard corners, and
        /// shortcuts the call if none is found. This can drastically speed up the call in the degenerate
        /// condition when no chessboard is observed.
        /// </summary>
        FastCheck = 8
    }

    /// <summary>
    /// Specifies available operation flags for camera calibration.
    /// </summary>
    [Flags]
    public enum CameraCalibrationFlags : int
    {
        /// <summary>
        /// Specifies that no operation flags are active.
        /// </summary>
        None = 0,

        /// <summary>
        /// Specifies that some or all of the intrinsic parameters should be optimized according
        /// to the specified flags. Initial values are provided by the user.
        /// </summary>
        UseIntrinsicGuess = 1,

        /// <summary>
        /// Specifies that the function considers only fy as a free parameter. The ratio fx/fy
        /// stays the same as in the input camera matrix . When <see cref="UseIntrinsicGuess"/>
        /// is not set, the actual input values of fx and fy are ignored; only their ratio is
        /// computed and used further.
        /// </summary>
        FixAspectRatio = 2,

        /// <summary>
        /// Specifies that the principal point is not changed during the global optimization.
        /// It stays at the center or at a different location specified when
        /// <see cref="UseIntrinsicGuess"/> is set too.
        /// </summary>
        FixPrincipalPoint = 4,

        /// <summary>
        /// Specifies that tangential distortion coefficients (p1, p2) are set to zeros and
        /// stay zero.
        /// </summary>
        ZeroTangentialDistortion = 8,

        /// <summary>
        /// Specifies that the focal length (fx, fy) is not changed during the optimization.
        /// </summary>
        FixFocalLength = 16,

        /// <summary>
        /// Specifies that the k1 radial distortion coefficient is not changed during the optimization.
        /// If <see cref="UseIntrinsicGuess"/> is set, the coefficient from the supplied coefficients
        /// matrix is used. Otherwise, it is set to 0.
        /// </summary>
        FixK1 = 32,

        /// <summary>
        /// Specifies that the k2 radial distortion coefficient is not changed during the optimization.
        /// If <see cref="UseIntrinsicGuess"/> is set, the coefficient from the supplied coefficients
        /// matrix is used. Otherwise, it is set to 0.
        /// </summary>
        FixK2 = 64,

        /// <summary>
        /// Specifies that the k3 radial distortion coefficient is not changed during the optimization.
        /// If <see cref="UseIntrinsicGuess"/> is set, the coefficient from the supplied coefficients
        /// matrix is used. Otherwise, it is set to 0.
        /// </summary>
        FixK3 = 128,

        /// <summary>
        /// Specifies that the k4 radial distortion coefficient is not changed during the optimization.
        /// If <see cref="UseIntrinsicGuess"/> is set, the coefficient from the supplied coefficients
        /// matrix is used. Otherwise, it is set to 0.
        /// </summary>
        FixK4 = 2048,

        /// <summary>
        /// Specifies that the k5 radial distortion coefficient is not changed during the optimization.
        /// If <see cref="UseIntrinsicGuess"/> is set, the coefficient from the supplied coefficients
        /// matrix is used. Otherwise, it is set to 0.
        /// </summary>
        FixK5 = 4096,

        /// <summary>
        /// Specifies that the k6 radial distortion coefficient is not changed during the optimization.
        /// If <see cref="UseIntrinsicGuess"/> is set, the coefficient from the supplied coefficients
        /// matrix is used. Otherwise, it is set to 0.
        /// </summary>
        FixK6 = 8192,

        /// <summary>
        /// Coefficients k4, k5, and k6 are enabled. To provide the backward compatibility, this extra
        /// flag should be explicitly specified to make the calibration function use the rational model
        /// and return 8 coefficients. If the flag is not set, the function computes and returns only
        /// 5 distortion coefficients.
        /// </summary>
        RationalModel = 16384
    }

    /// <summary>
    /// Specifies available operation flags for stereo camera calibration.
    /// </summary>
    [Flags]
    public enum StereoCalibrationFlags : int
    {
        /// <summary>
        /// Specifies that no operation flags are active.
        /// </summary>
        None = 0,

        /// <summary>
        /// Specifies that some or all of the intrinsic parameters should be optimized according
        /// to the specified flags. Initial values are provided by the user.
        /// </summary>
        UseIntrinsicGuess = 1,

        /// <summary>
        /// Specifies that the function considers only fy as a free parameter. The ratio fx/fy
        /// stays the same as in the input camera matrix . When <see cref="UseIntrinsicGuess"/>
        /// is not set, the actual input values of fx and fy are ignored; only their ratio is
        /// computed and used further.
        /// </summary>
        FixAspectRatio = 2,

        /// <summary>
        /// Specifies that the principal point is not changed during the global optimization.
        /// It stays at the center or at a different location specified when
        /// <see cref="UseIntrinsicGuess"/> is set too.
        /// </summary>
        FixPrincipalPoint = 4,

        /// <summary>
        /// Specifies that tangential distortion coefficients (p1, p2) are set to zeros and
        /// stay zero.
        /// </summary>
        ZeroTangentialDistortion = 8,

        /// <summary>
        /// Specifies that the focal length (fx, fy) is not changed during the optimization.
        /// </summary>
        FixFocalLength = 16,

        /// <summary>
        /// Specifies that the k1 radial distortion coefficient is not changed during the optimization.
        /// If <see cref="UseIntrinsicGuess"/> is set, the coefficient from the supplied coefficients
        /// matrix is used. Otherwise, it is set to 0.
        /// </summary>
        FixK1 = 32,

        /// <summary>
        /// Specifies that the k2 radial distortion coefficient is not changed during the optimization.
        /// If <see cref="UseIntrinsicGuess"/> is set, the coefficient from the supplied coefficients
        /// matrix is used. Otherwise, it is set to 0.
        /// </summary>
        FixK2 = 64,

        /// <summary>
        /// Specifies that the k3 radial distortion coefficient is not changed during the optimization.
        /// If <see cref="UseIntrinsicGuess"/> is set, the coefficient from the supplied coefficients
        /// matrix is used. Otherwise, it is set to 0.
        /// </summary>
        FixK3 = 128,

        /// <summary>
        /// Specifies that the camera matrix and distortion coefficients should not be changed, so that
        /// only R, T, E and F matrices are estimated.
        /// </summary>
        FixIntrinsic = 256,

        /// <summary>
        /// Specifies the constraint that both cameras should have the same focal length (fx, fy).
        /// </summary>
        SameFocalLength = 512,

        /// <summary>
        /// Specifies that the k4 radial distortion coefficient is not changed during the optimization.
        /// If <see cref="UseIntrinsicGuess"/> is set, the coefficient from the supplied coefficients
        /// matrix is used. Otherwise, it is set to 0.
        /// </summary>
        FixK4 = 2048,

        /// <summary>
        /// Specifies that the k5 radial distortion coefficient is not changed during the optimization.
        /// If <see cref="UseIntrinsicGuess"/> is set, the coefficient from the supplied coefficients
        /// matrix is used. Otherwise, it is set to 0.
        /// </summary>
        FixK5 = 4096,

        /// <summary>
        /// Specifies that the k6 radial distortion coefficient is not changed during the optimization.
        /// If <see cref="UseIntrinsicGuess"/> is set, the coefficient from the supplied coefficients
        /// matrix is used. Otherwise, it is set to 0.
        /// </summary>
        FixK6 = 8192,

        /// <summary>
        /// Coefficients k4, k5, and k6 are enabled. To provide the backward compatibility, this extra
        /// flag should be explicitly specified to make the calibration function use the rational model
        /// and return 8 coefficients. If the flag is not set, the function computes and returns only
        /// 5 distortion coefficients.
        /// </summary>
        RationalModel = 16384
    }

    /// <summary>
    /// Specifies available operation flags for stereo rectification.
    /// </summary>
    [Flags]
    public enum StereoRectificationFlags : int
    {
        /// <summary>
        /// Specifies that no operation flags are active.
        /// </summary>
        None = 0,

        /// <summary>
        /// Specifies that the function makes the principal points of each camera have the same pixel
        /// coordinates in the rectified views.
        /// </summary>
        ZeroDisparity = 1024
    }

    /// <summary>
    /// Specifies available types of stereo block matching pre-filtering.
    /// </summary>
    public enum StereoBMPreFilterType : int
    {
        /// <summary>
        /// Specifies that no pre-filter is used and the output is just the
        /// normalized response.
        /// </summary>
        NormalizedResponse = 0,

        /// <summary>
        /// Specifies the x-sobel pre-filter.
        /// </summary>
        XSobel = 1
    }

    /// <summary>
    /// Specifies available presets of stereo block matching algorithm parameters.
    /// </summary>
    public enum StereoBMPreset : int
    {
        /// <summary>
        /// Specifies parameters suitable for general cameras.
        /// </summary>
        Basic = 0,

        /// <summary>
        /// Specifies parameters suitable for wide-angle cameras.
        /// </summary>
        FishEye = 1,

        /// <summary>
        /// Specifies parameters suitable for narrow-angle cameras.
        /// </summary>
        Narrow = 2
    }
}
