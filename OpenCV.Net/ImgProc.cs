using OpenCV.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net
{
    public static partial class cv
    {
        #region Background statistics accumulation

        /// <summary>
        /// Adds a frame to an accumulator.
        /// </summary>
        /// <param name="image">
        /// Input image, 1- or 3-channel, 8-bit or 32-bit floating point. Each channel of
        /// multi-channel image is processed independently.
        /// </param>
        /// <param name="sum">
        /// Accumulator with the same number of channels as input image, 32-bit or
        /// 64-bit floating-point.
        /// </param>
        /// <param name="mask">Optional operation mask.</param>
        public static void Acc(CvArr image, CvArr sum, CvArr mask = null)
        {
            NativeMethods.cvAcc(image, sum, mask ?? CvArr.Null);
        }

        /// <summary>
        /// Adds the square of the source image to the accumulator.
        /// </summary>
        /// <param name="image">
        /// Input image, 1- or 3-channel, 8-bit or 32-bit floating point. Each channel of
        /// multi-channel image is processed independently.
        /// </param>
        /// <param name="sqsum">
        /// Accumulator with the same number of channels as input image, 32-bit or
        /// 64-bit floating-point.
        /// </param>
        /// <param name="mask">Optional operation mask.</param>
        public static void SquareAcc(CvArr image, CvArr sqsum, CvArr mask = null)
        {
            NativeMethods.cvSquareAcc(image, sqsum, mask ?? CvArr.Null);
        }

        /// <summary>
        /// Adds the product of two input images to the accumulator.
        /// </summary>
        /// <param name="image1">
        /// First input image, 1- or 3-channel, 8-bit or 32-bit floating point. Each channel of
        /// multi-channel image is processed independently.
        /// </param>
        /// <param name="image2">Second input image, the same format as the first one.</param>
        /// <param name="acc">
        /// Accumulator with the same number of channels as input images, 32-bit or
        /// 64-bit floating-point.
        /// </param>
        /// <param name="mask">Optional operation mask.</param>
        public static void MultiplyAcc(CvArr image1, CvArr image2, CvArr acc, CvArr mask = null)
        {
            NativeMethods.cvMultiplyAcc(image1, image2, acc, mask ?? CvArr.Null);
        }

        /// <summary>
        /// Calculates the weighted sum of the input image <paramref name="image"/> and the
        /// accumulator <paramref name="acc"/> so that <paramref name="acc"/> becomes a running
        /// average of frame sequence.
        /// </summary>
        /// <param name="image">
        /// Input image, 1- or 3-channel, 8-bit or 32-bit floating point. Each channel of
        /// multi-channel image is processed independently.
        /// </param>
        /// <param name="acc">
        /// Accumulator with the same number of channels as input images, 32-bit or
        /// 64-bit floating-point.
        /// </param>
        /// <param name="alpha">
        /// Weight of the input image. This parameter regulates how fast the accumulator
        /// forgets about previous frames.
        /// </param>
        /// <param name="mask">Optional operation mask.</param>
        public static void RunningAvg(CvArr image, CvArr acc, double alpha, CvArr mask = null)
        {
            NativeMethods.cvRunningAvg(image, acc, alpha, mask ?? CvArr.Null);
        }

        #endregion

        #region Image Processing

        /// <summary>
        /// Copies an image and makes a border around it.
        /// </summary>
        /// <param name="src">The source image.</param>
        /// <param name="dst">The destination image.</param>
        /// <param name="offset">
        /// Coordinates of the top-left corner (or bottom-left in the case of images with bottom-left origin)
        /// of the destination image rectangle where the source image (or its ROI) is copied.
        /// </param>
        /// <param name="borderType">Type of the border to create around the copied source image rectangle.</param>
        public static void CopyMakeBorder(CvArr src, CvArr dst, CvPoint offset, IplBorder borderType)
        {
            CopyMakeBorder(src, dst, offset, borderType, CvScalar.All(0));
        }

        /// <summary>
        /// Copies an image and makes a border around it.
        /// </summary>
        /// <param name="src">The source image.</param>
        /// <param name="dst">The destination image.</param>
        /// <param name="offset">
        /// Coordinates of the top-left corner (or bottom-left in the case of images with bottom-left origin)
        /// of the destination image rectangle where the source image (or its ROI) is copied.
        /// </param>
        /// <param name="borderType">Type of the border to create around the copied source image rectangle.</param>
        /// <param name="value">
        /// Value of the border pixels if <paramref name="borderType"/> is <see cref="IplBorder.Constant"/>.
        /// </param>
        public static void CopyMakeBorder(CvArr src, CvArr dst, CvPoint offset, IplBorder borderType, CvScalar value)
        {
            NativeMethods.cvCopyMakeBorder(src, dst, offset, borderType, value);
        }

        /// <summary>
        /// Smooths the image in one of several ways.
        /// </summary>
        /// <param name="src">The source image.</param>
        /// <param name="dst">The destination image.</param>
        /// <param name="smoothType">Type of the smoothing.</param>
        /// <param name="size1">
        /// The first parameter of the smoothing operation, the aperture width. Must be a positive
        /// odd number (e.g. 1, 3, 5, ...).
        /// </param>
        /// <param name="size2">
        /// The second parameter of the smoothing operation, the aperture height. Ignored by
        /// <see cref="SmoothMethod.Median"/> and <see cref="SmoothMethod.Bilateral"/> methods.
        /// In the case of simple scaled/non-scaled and Gaussian blur, if <paramref name="size2"/>
        /// is zero, it is set to <paramref name="size1"/>. Otherwise it must be a positive odd number.
        /// </param>
        /// <param name="sigma1">
        /// In the case of a <see cref="SmoothMethod.Gaussian"/> smoothing, this parameter may
        /// specify the standard deviation. If it is zero, it is calculated from the kernel size.
        /// If <paramref name="sigma1"/> is not zero but <paramref name="size1"/> and <paramref name="size2"/>
        /// are zeros, the kernel size is calculated from <paramref name="sigma1"/>.
        /// </param>
        /// <param name="sigma2">
        /// Optionally specifies the standard deviation for the second dimension.
        /// </param>
        public static void Smooth(
            CvArr src,
            CvArr dst,
            SmoothMethod smoothType = SmoothMethod.Gaussian,
            int size1 = 3,
            int size2 = 0,
            double sigma1 = 0,
            double sigma2 = 0)
        {
            NativeMethods.cvSmooth(src, dst, smoothType, size1, size2, sigma1, sigma2);
        }

        /// <summary>
        /// Convolves an image with the kernel.
        /// </summary>
        /// <param name="src">The source image.</param>
        /// <param name="dst">
        /// The destination image of the same size and number of channels as <paramref name="src"/>.
        /// </param>
        /// <param name="kernel">
        /// The convolution kernel (or rather a correlation kernel), a single-channel
        /// floating point matrix.
        /// </param>
        public static void Filter2D(CvArr src, CvArr dst, CvMat kernel)
        {
            Filter2D(src, dst, kernel, new CvPoint(-1, -1));
        }

        /// <summary>
        /// Convolves an image with the kernel.
        /// </summary>
        /// <param name="src">The source image.</param>
        /// <param name="dst">
        /// The destination image of the same size and number of channels as <paramref name="src"/>.
        /// </param>
        /// <param name="kernel">
        /// The convolution kernel (or rather a correlation kernel), a single-channel
        /// floating point matrix.
        /// </param>
        /// <param name="anchor">
        /// The anchor of the kernel that indicates the relative position of a filtered point
        /// within the kernel; the anchor should lie within the kernel; default value (-1,-1)
        /// means that the anchor is at the kernel center.
        /// </param>
        public static void Filter2D(CvArr src, CvArr dst, CvMat kernel, CvPoint anchor)
        {
            NativeMethods.cvFilter2D(src, dst, kernel, anchor);
        }

        /// <summary>
        /// Calculates the integral of an image.
        /// </summary>
        /// <param name="image">The source image, W x H, 8-bit or floating-point (32f or 64f).</param>
        /// <param name="sum">The integral image, (W + 1) x (H + 1), 32-bit integer or double precision floating-point (64f).</param>
        /// <param name="sqsum">
        /// The optional integral image for squared pixel values, (W + 1) x (H + 1), double precision
        /// floating-point (64f).
        /// </param>
        /// <param name="tiltedSum">
        /// The integral for the image rotated by 45 degrees, the same data type as <paramref name="sum"/>.
        /// </param>
        public static void Integral(CvArr image, CvArr sum, CvArr sqsum = null, CvArr tiltedSum = null)
        {
            NativeMethods.cvIntegral(image, sum, sqsum ?? CvArr.Null, tiltedSum ?? CvArr.Null);
        }

        /// <summary>
        /// Blurs an image and downsamples it.
        /// </summary>
        /// <param name="src">The source image.</param>
        /// <param name="dst">The destination image, with the same type as <paramref name="src"/>.</param>
        /// <param name="filter">The type of filter used for convolution.</param>
        public static void PyrDown(CvArr src, CvArr dst, PyramidDecompositionFilter filter = PyramidDecompositionFilter.Gaussian5x5)
        {
            NativeMethods.cvPyrDown(src, dst, filter);
        }

        /// <summary>
        /// Upsamples an image and then blurs it.
        /// </summary>
        /// <param name="src">The source image.</param>
        /// <param name="dst">The destination image, with the same type as <paramref name="src"/>.</param>
        /// <param name="filter">The type of filter used for convolution.</param>
        public static void PyrUp(CvArr src, CvArr dst, PyramidDecompositionFilter filter = PyramidDecompositionFilter.Gaussian5x5)
        {
            NativeMethods.cvPyrUp(src, dst, filter);
        }

        /// <summary>
        /// Builds pyramid representation of an image.
        /// </summary>
        /// <param name="img">The source image.</param>
        /// <param name="extraLayers">The number of extra pyramid layers.</param>
        /// <param name="rate">
        /// The size scale factor between each pyramid layer. Used if <paramref name="layerSizes"/>
        /// is <b>null</b>.
        /// </param>
        /// <param name="layerSizes">The size of each pyramid layer.</param>
        /// <param name="buffer">An image buffer on which the pyramids will be stored.</param>
        /// <param name="calc">
        /// A value indicating whether to compute the actual pyramids. If it is <b>false</b>, only the memory
        /// for the pyramids is allocated.
        /// </param>
        /// <param name="filter">The type of filter used for convolution.</param>
        /// <returns>
        /// A set of matrix handles representing the pyramid of <paramref name="img"/>.
        /// </returns>
        public static CvMat[] CreatePyramid(
            CvArr img,
            int extraLayers,
            double rate,
            CvSize[] layerSizes = null,
            CvArr buffer = null,
            bool calc = true,
            PyramidDecompositionFilter filter = PyramidDecompositionFilter.Gaussian5x5)
        {
            var handles = new IntPtr[extraLayers + 1];
            var pyramid = NativeMethods.cvCreatePyramid(img, extraLayers, rate, layerSizes, buffer ?? CvArr.Null, calc ? 1 : 0, filter);
            Marshal.Copy(pyramid, handles, 0, handles.Length);
            return Array.ConvertAll(handles, handle => new CvMat(handle, true));
        }

        /// <summary>
        /// Performs initial step of meanshift segmentation of an image.
        /// </summary>
        /// <param name="src">The source 8-bit, 3-channel image.</param>
        /// <param name="dst">The destination image of the same format and the same size as <paramref name="src"/>.</param>
        /// <param name="sp">The spatial window radius.</param>
        /// <param name="sr">The color window radius.</param>
        /// <param name="maxLevel">Maximum level of the pyramid for the segmentation.</param>
        public static void PyrMeanShiftFiltering(
            CvArr src,
            CvArr dst,
            double sp,
            double sr,
            int maxLevel = 1)
        {
            PyrMeanShiftFiltering(src, dst, sp, sr, maxLevel, new CvTermCriteria(TermCriteriaType.MaxIter | TermCriteriaType.Epsilon, 5, 1));
        }

        /// <summary>
        /// Performs initial step of meanshift segmentation of an image.
        /// </summary>
        /// <param name="src">The source 8-bit, 3-channel image.</param>
        /// <param name="dst">The destination image of the same format and the same size as <paramref name="src"/>.</param>
        /// <param name="sp">The spatial window radius.</param>
        /// <param name="sr">The color window radius.</param>
        /// <param name="maxLevel">Maximum level of the pyramid for the segmentation.</param>
        /// <param name="termcrit">Termination criteria: when to stop meanshift iterations.</param>
        public static void PyrMeanShiftFiltering(
            CvArr src,
            CvArr dst,
            double sp,
            double sr,
            int maxLevel,
            CvTermCriteria termcrit)
        {
            NativeMethods.cvPyrMeanShiftFiltering(src, dst, sp, sr, maxLevel, termcrit);
        }

        /// <summary>
        /// Performs marker-based image segmentation using the watershed algorithm.
        /// </summary>
        /// <param name="image">The input 8-bit 3-channel image.</param>
        /// <param name="markers">
        /// The input/output 32-bit single-channel image (map) of markers. It should have the
        /// same size as <paramref name="image"/>.
        /// </param>
        public static void Watershed(CvArr image, CvArr markers)
        {
            NativeMethods.cvWatershed(image, markers);
        }

        /// <summary>
        /// Calculates the first, second, third or mixed image derivatives using an extended Sobel operator.
        /// </summary>
        /// <param name="src">The source image.</param>
        /// <param name="dst">The destination image.</param>
        /// <param name="xorder">The order of the derivative x.</param>
        /// <param name="yorder">The order of the derivative y.</param>
        /// <param name="apertureSize">Size of the extended Sobel kernel, must be 1, 3, 5 or 7.</param>
        public static void Sobel(CvArr src, CvArr dst, int xorder, int yorder, int apertureSize = 3)
        {
            NativeMethods.cvSobel(src, dst, xorder, yorder, apertureSize);
        }

        /// <summary>
        /// Calculates the Laplacian of an image.
        /// </summary>
        /// <param name="src">The source image.</param>
        /// <param name="dst">The destination image.</param>
        /// <param name="apertureSize">
        /// Size of the extended Sobel kernel used to compute derivatives,
        /// must be 1, 3, 5 or 7.
        /// </param>
        public static void Laplace(CvArr src, CvArr dst, int apertureSize = 3)
        {
            NativeMethods.cvLaplace(src, dst, apertureSize);
        }

        /// <summary>
        /// Converts an image from one color space to another.
        /// </summary>
        /// <param name="src">The input image, 8-bit unsigned, 16-bit unsigned or single-precision floating-point.</param>
        /// <param name="dst">The output image of the same size and depth as <paramref name="src"/>.</param>
        /// <param name="code">The color space conversion to apply.</param>
        public static void CvtColor(CvArr src, CvArr dst, ColorConversion code)
        {
            NativeMethods.cvCvtColor(src, dst, code);
        }

        /// <summary>
        /// Resizes an image.
        /// </summary>
        /// <param name="src">The source image.</param>
        /// <param name="dst">The destination image.</param>
        /// <param name="interpolation">The interpolation method.</param>
        public static void Resize(CvArr src, CvArr dst, SubPixelInterpolation interpolation = SubPixelInterpolation.Linear)
        {
            NativeMethods.cvResize(src, dst, interpolation);
        }

        /// <summary>
        /// Applies an affine transformation to an image.
        /// </summary>
        /// <param name="src">The source image.</param>
        /// <param name="dst">The destination image.</param>
        /// <param name="mapMatrix">The 2 x 3 transformation matrix.</param>
        /// <param name="flags">A combination of interpolation methods and operational flags.</param>
        public static void WarpAffine(CvArr src, CvArr dst, CvMat mapMatrix, WarpFlags flags = WarpFlags.Linear | WarpFlags.FillOutliers)
        {
            WarpAffine(src, dst, mapMatrix, flags, CvScalar.All(0));
        }

        /// <summary>
        /// Applies an affine transformation to an image.
        /// </summary>
        /// <param name="src">The source image.</param>
        /// <param name="dst">The destination image.</param>
        /// <param name="mapMatrix">The 2 x 3 transformation matrix.</param>
        /// <param name="flags">A combination of interpolation methods and operational flags.</param>
        /// <param name="fillval">A value used to fill outliers.</param>
        public static void WarpAffine(CvArr src, CvArr dst, CvMat mapMatrix, WarpFlags flags, CvScalar fillval)
        {
            NativeMethods.cvWarpAffine(src, dst, mapMatrix, flags, fillval);
        }

        /// <summary>
        /// Calculates the affine transform from three corresponding points.
        /// </summary>
        /// <param name="src">Coordinates of three triangle vertices in the source image.</param>
        /// <param name="dst">Coordinates of the three corresponding triangle vertices in the destination image.</param>
        /// <param name="mapMatrix">The destination 2 x 3 transformation matrix.</param>
        /// <returns>The destination 2 x 3 transformation matrix.</returns>
        public static CvMat GetAffineTransform(CvPoint2D32f[] src, CvPoint2D32f[] dst, CvMat mapMatrix)
        {
            NativeMethods.cvGetAffineTransform(src, dst, mapMatrix);
            return mapMatrix;
        }

        /// <summary>
        /// Calculates the affine matrix of 2d rotation.
        /// </summary>
        /// <param name="center">Center of the rotation in the source image.</param>
        /// <param name="angle">
        /// The rotation angle in degrees. Positive values mean counter-clockwise rotation
        /// (the coordinate origin is assumed to be the top-left corner).
        /// </param>
        /// <param name="scale">Isotropic scale factor.</param>
        /// <param name="mapMatrix">The destination 2 x 3 transformation matrix.</param>
        /// <returns>The destination 2 x 3 transformation matrix.</returns>
        public static CvMat GetRotationMatrix2D(CvPoint2D32f center, double angle, double scale, CvMat mapMatrix)
        {
            NativeMethods.cv2DRotationMatrix(center, angle, scale, mapMatrix);
            return mapMatrix;
        }

        /// <summary>
        /// Applies a perspective transformation to an image.
        /// </summary>
        /// <param name="src">The source image.</param>
        /// <param name="dst">The destination image.</param>
        /// <param name="mapMatrix">The 3 x 3 transformation matrix.</param>
        /// <param name="flags">A combination of interpolation methods and operational flags.</param>
        public static void WarpPerspective(CvArr src, CvArr dst, CvMat mapMatrix, WarpFlags flags = WarpFlags.Linear | WarpFlags.FillOutliers)
        {
            WarpPerspective(src, dst, mapMatrix, flags, CvScalar.All(0));
        }

        /// <summary>
        /// Applies a perspective transformation to an image.
        /// </summary>
        /// <param name="src">The source image.</param>
        /// <param name="dst">The destination image.</param>
        /// <param name="mapMatrix">The 3 x 3 transformation matrix.</param>
        /// <param name="flags">A combination of interpolation methods and operational flags.</param>
        /// <param name="fillval">A value used to fill outliers.</param>
        public static void WarpPerspective(CvArr src, CvArr dst, CvMat mapMatrix, WarpFlags flags, CvScalar fillval)
        {
            NativeMethods.cvWarpPerspective(src, dst, mapMatrix, flags, fillval);
        }

        /// <summary>
        /// Calculates the perspective transform from four corresponding points.
        /// </summary>
        /// <param name="src">Coordinates of four quadrangle vertices in the source image.</param>
        /// <param name="dst">Coordinates of the four corresponding quadrangle vertices in the destination image.</param>
        /// <param name="mapMatrix">The destination 3 x 3 transformation matrix.</param>
        /// <returns>The destination 3 x 3 transformation matrix.</returns>
        public static CvMat GetPerspectiveTransform(CvPoint2D32f[] src, CvPoint2D32f[] dst, CvMat mapMatrix)
        {
            NativeMethods.cvGetPerspectiveTransform(src, dst, mapMatrix);
            return mapMatrix;
        }

        /// <summary>
        /// Applies a generic geometrical transformation to the image. The method transforms the source image
        /// using the specified map for each individual pixel coordinates.
        /// </summary>
        /// <param name="src">The source image.</param>
        /// <param name="dst">The destination image.</param>
        /// <param name="mapx">
        /// The map of x-coordinates, 32-bit single-channel floating-point image or
        /// 16-bit 2-channel signed integer image. Fixed-point version is faster.
        /// </param>
        /// <param name="mapy">
        /// The map of y-coordinates, 32-bit single-channel floating-point image or
        /// 16-bit single-channel unsigned integer image. Fixed-point version is faster.
        /// </param>
        /// <param name="flags">A combination of interpolation methods and operational flags.</param>
        public static void Remap(CvArr src, CvArr dst, CvArr mapx, CvArr mapy, WarpFlags flags = WarpFlags.Linear | WarpFlags.FillOutliers)
        {
            Remap(src, dst, mapx, mapy, flags, CvScalar.All(0));
        }

        /// <summary>
        /// Applies a generic geometrical transformation to the image. The method transforms the source image
        /// using the specified map for each individual pixel coordinates.
        /// </summary>
        /// <param name="src">The source image.</param>
        /// <param name="dst">The destination image.</param>
        /// <param name="mapx">
        /// The map of x-coordinates, 32-bit single-channel floating-point image or
        /// 16-bit 2-channel signed integer image.
        /// </param>
        /// <param name="mapy">
        /// The map of y-coordinates, 32-bit single-channel floating-point image or
        /// 16-bit single-channel unsigned integer image.
        /// </param>
        /// <param name="flags">A combination of interpolation methods and operational flags.</param>
        /// <param name="fillval">A value used to fill outliers.</param>
        public static void Remap(CvArr src, CvArr dst, CvArr mapx, CvArr mapy, WarpFlags flags, CvScalar fillval)
        {
            NativeMethods.cvRemap(src, dst, mapx, mapy, flags, fillval);
        }

        /// <summary>
        /// Converts image transformation maps from floating-point to integer fixed-point for
        /// fast remapping operation.
        /// </summary>
        /// <param name="mapx">The map of x-coordinates, 32-bit single-channel floating-point image.</param>
        /// <param name="mapy">The map of y-coordinates, 32-bit single-channel floating-point image.</param>
        /// <param name="mapxy">The output map of xy-coordinates, 16-bit 2-channel signed integer image.</param>
        /// <param name="mapalpha">The output alpha map, 16-bit single-channel unsigned integer image.</param>
        public static void ConvertMaps(CvArr mapx, CvArr mapy, CvArr mapxy, CvArr mapalpha)
        {
            NativeMethods.cvConvertMaps(mapx, mapy, mapxy, mapalpha);
        }

        /// <summary>
        /// Performs forward or inverse log-polar image transform. The function emulates
        /// human "foveal" vision. In-place operation is not supported.
        /// </summary>
        /// <param name="src">The source image.</param>
        /// <param name="dst">The destination image.</param>
        /// <param name="center">The transformation center; where the output precision is maximal.</param>
        /// <param name="M">Magnitude scale parameter for polar transformation.</param>
        /// <param name="flags">A combination of interpolation methods and operational flags.</param>
        public static void LogPolar(CvArr src, CvArr dst, CvPoint2D32f center, double M, WarpFlags flags = WarpFlags.Linear | WarpFlags.FillOutliers)
        {
            NativeMethods.cvLogPolar(src, dst, center, M, flags);
        }

        /// <summary>
        /// Performs forward or inverse linear-polar image transform. The function emulates
        /// human "foveal" vision. In-place operation is not supported.
        /// </summary>
        /// <param name="src">The source image.</param>
        /// <param name="dst">The destination image.</param>
        /// <param name="center">The transformation center; where the output precision is maximal.</param>
        /// <param name="maxRadius">The maximum radius of polar transformation.</param>
        /// <param name="flags">A combination of interpolation methods and operational flags.</param>
        public static void LinearPolar(CvArr src, CvArr dst, CvPoint2D32f center, double maxRadius, WarpFlags flags = WarpFlags.Linear | WarpFlags.FillOutliers)
        {
            NativeMethods.cvLinearPolar(src, dst, center, maxRadius, flags);
        }

        /// <summary>
        /// Transforms an image to compensate for lens distortion.
        /// </summary>
        /// <param name="src">The input (distorted) image.</param>
        /// <param name="dst">The output (corrected) image with same size and type as <paramref name="src"/>.</param>
        /// <param name="cameraMatrix">The input camera matrix.</param>
        /// <param name="distortionCoeffs">The vector of distortion coefficients.</param>
        /// <param name="newCameraMatrix">
        /// Regulates the particular subset of the source image that will be visible in the corrected image.
        /// </param>
        public static void Undistort2(CvArr src, CvArr dst, CvMat cameraMatrix, CvMat distortionCoeffs, CvMat newCameraMatrix = null)
        {
            NativeMethods.cvUndistort2(src, dst, cameraMatrix, distortionCoeffs, newCameraMatrix ?? CvMat.Null);
        }

        /// <summary>
        /// Computes an undistortion map.
        /// </summary>
        /// <param name="cameraMatrix">The input camera matrix.</param>
        /// <param name="distortionCoeffs">The 4 or 5 element vector of distortion coefficients.</param>
        /// <param name="mapx">
        /// The output map of x-coordinates, 32-bit single-channel floating-point image or
        /// 16-bit 2-channel signed integer image. Fixed-point version is faster.
        /// </param>
        /// <param name="mapy">
        /// The output map of y-coordinates, 32-bit single-channel floating-point image or
        /// 16-bit single-channel unsigned integer image. Fixed-point version is faster.
        /// </param>
        public static void InitUndistortMap(CvMat cameraMatrix, CvMat distortionCoeffs, CvArr mapx, CvArr mapy)
        {
            NativeMethods.cvInitUndistortMap(cameraMatrix, distortionCoeffs, mapx, mapy);
        }

        /// <summary>
        /// Computes the undistortion and rectification transformation map.
        /// </summary>
        /// <param name="cameraMatrix">The input camera matrix.</param>
        /// <param name="distortionCoeffs">The 4 or 5 element vector of distortion coefficients.</param>
        /// <param name="R">
        /// The optional rectification transformation in object space (3x3 matrix). If it is <b>null</b>
        /// the identity transform is used.
        /// </param>
        /// <param name="newCameraMatrix">The new camera matrix.</param>
        /// <param name="mapx">
        /// The output map of x-coordinates, 32-bit single-channel floating-point image or
        /// 16-bit 2-channel signed integer image. Fixed-point version is faster.
        /// </param>
        /// <param name="mapy">
        /// The output map of y-coordinates, 32-bit single-channel floating-point image or
        /// 16-bit single-channel unsigned integer image. Fixed-point version is faster.
        /// </param>
        public static void InitUndistortRectifyMap(
            CvMat cameraMatrix,
            CvMat distortionCoeffs,
            CvMat R,
            CvMat newCameraMatrix,
            CvArr mapx,
            CvArr mapy)
        {
            NativeMethods.cvInitUndistortRectifyMap(cameraMatrix, distortionCoeffs, R ?? CvMat.Null, newCameraMatrix, mapx, mapy);
        }

        /// <summary>
        /// Computes the ideal point coordinates from the observed point coordinates.
        /// </summary>
        /// <param name="src">The observed point coordinates, 2xN or Nx2 single-channel or 1xN or Nx1 2-channel.</param>
        /// <param name="dst">
        /// The output ideal point coordinates, after undistortion and reverse perspective transformation,
        /// same format as <paramref name="src"/>.
        /// </param>
        /// <param name="cameraMatrix">The input camera matrix.</param>
        /// <param name="distortionCoeffs">The 4 or 5 element vector of distortion coefficients.</param>
        /// <param name="R">
        /// The optional rectification transformation in object space (3x3 matrix). If it is <b>null</b>
        /// the identity transform is used.
        /// </param>
        /// <param name="P">
        /// The optional new camera matrix (3x3) or the new projection matrix (3x4). If it is <b>null</b>
        /// the identity new camera matrix is used.
        /// </param>
        public static void UndistortPoints(
            CvMat src,
            CvMat dst,
            CvMat cameraMatrix,
            CvMat distortionCoeffs,
            CvMat R = null,
            CvMat P = null)
        {
            NativeMethods.cvUndistortPoints(src, dst, cameraMatrix, distortionCoeffs, R ?? CvMat.Null, P ?? CvMat.Null);
        }

        /// <summary>
        /// Erodes an image by using a specific structuring element.
        /// </summary>
        /// <param name="src">The source image.</param>
        /// <param name="dst">The destination image.</param>
        /// <param name="element">
        /// The structuring element used for erosion. If it is <b>null</b>, a 3x3 rectangular
        /// structuring element is used.
        /// </param>
        /// <param name="iterations">The number of times erosion is applied.</param>
        public static void Erode(CvArr src, CvArr dst, IplConvKernel element = null, int iterations = 1)
        {
            NativeMethods.cvErode(src, dst, element ?? IplConvKernel.Null, iterations);
        }

        /// <summary>
        /// Dilates an image by using a specific structuring element.
        /// </summary>
        /// <param name="src">The source image.</param>
        /// <param name="dst">The destination image.</param>
        /// <param name="element">
        /// The structuring element used for dilation. If it is <b>null</b>, a 3x3 rectangular
        /// structuring element is used.
        /// </param>
        /// <param name="iterations">The number of times dilation is applied.</param>
        public static void Dilate(CvArr src, CvArr dst, IplConvKernel element = null, int iterations = 1)
        {
            NativeMethods.cvDilate(src, dst, element ?? IplConvKernel.Null, iterations);
        }

        /// <summary>
        /// Performs advanced morphological transformations.
        /// </summary>
        /// <param name="src">The source image.</param>
        /// <param name="dst">The destination image.</param>
        /// <param name="temp">
        /// Temporary image, required for <see cref="MorphologicalOperation.Gradient"/> and in-place
        /// operation of <see cref="MorphologicalOperation.TopHat"/> and <see cref="MorphologicalOperation.BlackHat"/>.
        /// </param>
        /// <param name="element">The structuring element used for morphological transformation.</param>
        /// <param name="operation">The type of morphological transformation applied.</param>
        /// <param name="iterations">The number of times erosion and dilation are applied.</param>
        public static void MorphologyEx(
            CvArr src,
            CvArr dst,
            CvArr temp,
            IplConvKernel element,
            MorphologicalOperation operation,
            int iterations = 1)
        {
            NativeMethods.cvMorphologyEx(src, dst, temp, element, operation, iterations);
        }

        #endregion
    }
}
