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

        #region Data sampling

        /// <summary>
        /// Samples the raster line elements.
        /// </summary>
        /// <typeparam name="TElement">The type of the elements in the image.</typeparam>
        /// <param name="image">The image to sample the line from.</param>
        /// <param name="pt1">Starting line point.</param>
        /// <param name="pt2">Ending line point.</param>
        /// <param name="connectivity">The scanned line connectivity for Bresenham's algorithm, either 4 or 8.</param>
        /// <returns>The buffer containing the sampled line elements.</returns>
        public static TElement[] SampleLine<TElement>(
            CvArr image,
            CvPoint pt1,
            CvPoint pt2,
            LineType connectivity = LineType.Connected8)
            where TElement : struct
        {
            int bufferSize = 0;
            switch (connectivity)
            {
                case LineType.Connected8:
                    bufferSize = Math.Max(Math.Abs(pt2.X - pt1.X) + 1, Math.Abs(pt2.Y - pt1.Y) + 1);
                    break;
                case LineType.Connected4:
                    bufferSize = Math.Abs(pt2.X - pt1.X) + Math.Abs(pt2.Y - pt1.Y) + 1;
                    break;
            }

            var buffer = new TElement[bufferSize];
            var bufferHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            try
            {
                var count = NativeMethods.cvSampleLine(image, pt1, pt2, bufferHandle.AddrOfPinnedObject(), connectivity);
                if (count != buffer.Length)
                {
                    Array.Resize(ref buffer, count);
                }

                return buffer;
            }
            finally { bufferHandle.Free(); }
        }

        /// <summary>
        /// Retrieves the pixel rectangle from an image with sub-pixel accuracy.
        /// </summary>
        /// <param name="src">The source image.</param>
        /// <param name="dst">The destination image containing the extracted rectangle.</param>
        /// <param name="center">
        /// Floating point coordinates of the extracted rectangle center within the source image.
        /// The center must be inside the image.
        /// </param>
        public static void GetRectSubPix(CvArr src, CvArr dst, CvPoint2D32f center)
        {
            NativeMethods.cvGetRectSubPix(src, dst, center);
        }

        /// <summary>
        /// Retrieves the pixel quadrangle from an image with sub-pixel accuracy.
        /// </summary>
        /// <param name="src">The source image.</param>
        /// <param name="dst">The destination image containing the extracted quadrangle.</param>
        /// <param name="mapMatrix">The 2 x 3 transformation matrix.</param>
        public static void GetQuadrangleSubPix(CvArr src, CvArr dst, CvMat mapMatrix)
        {
            NativeMethods.cvGetQuadrangleSubPix(src, dst, mapMatrix);
        }

        /// <summary>
        /// Compares a template against overlapped image regions.
        /// </summary>
        /// <param name="image">The image where the search is running; should be 8-bit or 32-bit floating-point.</param>
        /// <param name="templ">
        /// Searched template; must not be greater than <paramref name="image"/> and have the same data type.
        /// </param>
        /// <param name="result">A map of comparison results; single-channel 32-bit floating-point.</param>
        /// <param name="method">Specifies the way the template must be compared with the image regions.</param>
        public static void MatchTemplate(CvArr image, CvArr templ, CvArr result, TemplateMatchingMethod method)
        {
            NativeMethods.cvMatchTemplate(image, templ, result, method);
        }

        /// <summary>
        /// Computes the earth mover distance between two weighted point sets (signatures).
        /// </summary>
        /// <param name="signature1">
        /// The first signature array. Must be floating-point and consist of rows containing the
        /// histogram bin count followed by its coordinates.
        /// </param>
        /// <param name="signature2">
        /// The second signature array. Must be floating-point and consist of rows containing the
        /// histogram bin count followed by its coordinates.
        /// </param>
        /// <param name="distanceType">The type of metric to use for computing the earth mover distance.</param>
        /// <param name="distanceFunc">The custom distance function used for computing the earth mover distance.</param>
        /// <param name="costMatrix">The user-defined cost matrix.</param>
        /// <param name="flow">The resultant flow matrix.</param>
        /// <returns>The earth mover distance between the two signatures.</returns>
        public static float CalcEMD2(
            CvArr signature1,
            CvArr signature2,
            DistanceType distanceType,
            Func<float, float, float> distanceFunc = null,
            CvArr costMatrix = null,
            CvArr flow = null)
        {
            float lowerBound = 0;
            return CalcEMD2(signature1, signature2, distanceType, distanceFunc, costMatrix, flow, ref lowerBound);
        }

        /// <summary>
        /// Computes the earth mover distance between two weighted point sets (signatures).
        /// </summary>
        /// <param name="signature1">
        /// The first signature array. Must be floating-point and consist of rows containing the
        /// histogram bin count followed by its coordinates.
        /// </param>
        /// <param name="signature2">
        /// The second signature array. Must be floating-point and consist of rows containing the
        /// histogram bin count followed by its coordinates.
        /// </param>
        /// <param name="distanceType">The type of metric to use for computing the earth mover distance.</param>
        /// <param name="distanceFunc">The custom distance function used for computing the earth mover distance.</param>
        /// <param name="costMatrix">The user-defined cost matrix.</param>
        /// <param name="flow">The resultant flow matrix.</param>
        /// <param name="lowerBound">
        /// The optional lower boundary of the distance between the two signatures that is a distance between
        /// mass centers.
        /// </param>
        /// <returns>The earth mover distance between the two signatures.</returns>
        public static float CalcEMD2(
            CvArr signature1,
            CvArr signature2,
            DistanceType distanceType,
            Func<float, float, float> distanceFunc,
            CvArr costMatrix,
            CvArr flow,
            ref float lowerBound)
        {
            unsafe
            {
                return NativeMethods.cvCalcEMD2(
                    signature1,
                    signature2,
                    distanceType,
                    distanceFunc == null ? (CvDistanceFunction)null : (a, b, userData) => distanceFunc(*a, *b),
                    costMatrix ?? CvArr.Null,
                    flow ?? CvArr.Null,
                    ref lowerBound,
                    IntPtr.Zero);
            }
        }

        #endregion

        #region Contours retrieving

        /// <summary>
        /// Finds the contours in a binary image.
        /// </summary>
        /// <param name="image">
        /// The source image, 8-bit single channel. Non-zero pixels are treated as ones,
        /// zero pixels remain zero, i.e. the image is treated as binary.
        /// </param>
        /// <param name="storage">Container of the retrieved contours.</param>
        /// <param name="firstContour">The reference to the first outer contour.</param>
        /// <returns>The number of retrieved contours.</returns>
        public static int FindContours(
            CvArr image,
            CvMemStorage storage,
            out CvSeq firstContour)
        {
            return FindContours(image, storage, out firstContour, SeqHelper.ContourHeaderSize);
        }

        /// <summary>
        /// Finds the contours in a binary image.
        /// </summary>
        /// <param name="image">
        /// The source image, 8-bit single channel. Non-zero pixels are treated as ones,
        /// zero pixels remain zero, i.e. the image is treated as binary.
        /// </param>
        /// <param name="storage">Container of the retrieved contours.</param>
        /// <param name="firstContour">The reference to the first outer contour.</param>
        /// <param name="headerSize">Size of the sequence header.</param>
        /// <param name="mode">Specifies the contour retrieval mode.</param>
        /// <param name="method">Specifies the contour approximation method.</param>
        /// <returns>The number of retrieved contours.</returns>
        public static int FindContours(
            CvArr image,
            CvMemStorage storage,
            out CvSeq firstContour,
            int headerSize,
            ContourRetrieval mode = ContourRetrieval.List,
            ContourApproximation method = ContourApproximation.ChainApproxSimple)
        {
            return FindContours(image, storage, out firstContour, headerSize, mode, method, new CvPoint(0, 0));
        }

        /// <summary>
        /// Finds the contours in a binary image.
        /// </summary>
        /// <param name="image">The 8-bit, single channel, binary source image.</param>
        /// <param name="storage">Container of the retrieved contours.</param>
        /// <param name="firstContour">The reference to the first outer contour.</param>
        /// <param name="headerSize">Size of the sequence header.</param>
        /// <param name="mode">Specifies the contour retrieval mode.</param>
        /// <param name="method">Specifies the contour approximation method.</param>
        /// <param name="offset">
        /// An offset, by which every contour point is shifted. This is useful if the
        /// contours are extracted from an image ROI but should then be analyzed in
        /// the whole image context.
        /// </param>
        /// <returns>The number of retrieved contours.</returns>
        public static int FindContours(
            CvArr image,
            CvMemStorage storage,
            out CvSeq firstContour,
            int headerSize,
            ContourRetrieval mode,
            ContourApproximation method,
            CvPoint offset)
        {
            var result = NativeMethods.cvFindContours(image, storage, out firstContour, headerSize, mode, method, offset);
            if (result > 0)
            {
                firstContour.SetOwnerStorage(storage);
            }
            else firstContour = null;
            return result;
        }

        /// <summary>
        /// Initializes the contour scanning process.
        /// </summary>
        /// <param name="image">The 8-bit, single channel, binary source image.</param>
        /// <param name="storage">Container of the retrieved contours.</param>
        /// <param name="headerSize">Size of the sequence header.</param>
        /// <param name="mode">Specifies the contour retrieval mode.</param>
        /// <param name="method">Specifies the contour approximation method.</param>
        /// <param name="offset">
        /// An offset, by which every contour point is shifted. This is useful if the
        /// contours are extracted from an image ROI but should then be analyzed in
        /// the whole image context.
        /// </param>
        /// <returns>
        /// A reference to the <see cref="CvContourScanner"/> instance that can be
        /// used to iterate over the retrieved contours.
        /// </returns>
        public static CvContourScanner StartFindContours(
            CvArr image,
            CvMemStorage storage,
            int headerSize,
            ContourRetrieval mode,
            ContourApproximation method,
            CvPoint offset)
        {
            var scanner = NativeMethods.cvStartFindContours(image, storage, headerSize, mode, method, offset);
            scanner.SetOwnerStorage(storage);
            return scanner;
        }

        /// <summary>
        /// Approximates Freeman chain(s) with a polygonal curve.
        /// </summary>
        /// <param name="srcSeq">The Freeman chain that can refer to other chains.</param>
        /// <param name="storage">Storage location for the resulting polylines.</param>
        /// <param name="method">Specifies the contour approximation method.</param>
        /// <param name="parameter">Not used.</param>
        /// <param name="minimalPerimeter">
        /// Approximates only those contours whose perimeters are greater or equal than <paramref name="minimalPerimeter"/>.
        /// Other chains are removed from the resulting structure.
        /// </param>
        /// <param name="recursive">
        /// If <b>true</b>, the function approximates all chains that can be accessed from
        /// <paramref name="srcSeq"/> by using either <see cref="CvSeq.HNext"/> or <see cref="CvSeq.VPrev"/>
        /// links; otherwise, the single chain is approximated.
        /// </param>
        /// <returns>The function returns the reference to the first resultant contour.</returns>
        public static CvSeq ApproxChains(
            CvSeq srcSeq,
            CvMemStorage storage,
            ContourApproximation method,
            double parameter,
            int minimalPerimeter,
            bool recursive)
        {
            var chain = NativeMethods.cvApproxChains(srcSeq, storage, method, parameter, minimalPerimeter, recursive ? 1 : 0);
            chain.SetOwnerStorage(storage);
            return chain;
        }

        #endregion

        #region Contour Processing and Shape Analysis

        /// <summary>
        /// Approximates polygonal curve(s) with the specified precision.
        /// </summary>
        /// <param name="srcSeq">The input sequence.</param>
        /// <param name="headerSize">Header size of the approximated curve(s).</param>
        /// <param name="storage">
        /// Container for the approximated contours. If <b>null</b>, the input sequence
        /// storage is used.
        /// </param>
        /// <param name="method">The polygon approximation method.</param>
        /// <param name="parameter">
        /// Method-specific parameter. In case of <see cref="PolygonApproximation.DouglasPeucker"/>
        /// it is a desired approximation accuracy.
        /// </param>
        /// <param name="parameter2">
        /// Indicates whether the single sequence should be approximated, or all the sequences
        /// on the same level and below <paramref name="srcSeq"/>.
        /// </param>
        /// <returns>
        /// A reference to the first approximated curve.
        /// </returns>
        public static CvSeq ApproxPoly(
            CvSeq srcSeq,
            int headerSize,
            CvMemStorage storage,
            PolygonApproximation method,
            double parameter,
            bool parameter2 = false)
        {
            var poly = NativeMethods.cvApproxPoly(srcSeq, headerSize, storage ?? CvMemStorage.Null, method, parameter, parameter2 ? 1 : 0);
            poly.SetOwnerStorage(storage ?? srcSeq.Storage);
            return poly;
        }

        /// <summary>
        /// Calculates the contour perimeter or the curve length.
        /// </summary>
        /// <param name="curve">Sequence or array of the curve points.</param>
        /// <returns>
        /// The length of the curve as the sum of the lengths of segments between subsequent points.
        /// </returns>
        public static double ArcLength(CvHandle curve)
        {
            return ArcLength(curve, CvSlice.WholeSeq);
        }

        /// <summary>
        /// Calculates the contour perimeter or the curve length.
        /// </summary>
        /// <param name="curve">Sequence or array of the curve points.</param>
        /// <param name="slice">
        /// Starting and ending points of the curve. By default, the whole curve length is calculated.
        /// </param>
        /// <param name="isClosed">
        /// Indicates whether or not the curve is closed. If <b>null</b> and the input is a sequence,
        /// the sequence flags are examined to determine whether the curve is closed. Otherwise,
        /// it is assumed unclosed.
        /// </param>
        /// <returns>
        /// The length of the curve as the sum of the lengths of segments between subsequent points.
        /// </returns>
        public static double ArcLength(CvHandle curve, CvSlice slice, bool? isClosed = null)
        {
            return NativeMethods.cvArcLength(curve, slice, isClosed.HasValue ? (isClosed.Value ? 1 : 0) : -1);
        }

        /// <summary>
        /// Calculates the contour perimeter.
        /// </summary>
        /// <param name="contour">Sequence or array of the contour points.</param>
        /// <returns>
        /// The perimeter of the closed contour as the sum of the lengths of segments between
        /// subsequent points.
        /// </returns>
        public static double ContourPerimeter(CvHandle contour)
        {
            return NativeMethods.cvArcLength(contour, CvSlice.WholeSeq, 1);
        }

        /// <summary>
        /// Calculates the up-right bounding rectangle of a point set.
        /// </summary>
        /// <param name="points">Sequence or array of points.</param>
        /// <param name="update">
        /// Indicates whether or not to update the <see cref="CvContour.Rect"/> field.
        /// </param>
        /// <returns>The up-right bounding rectangle for a 2d point set.</returns>
        public static CvRect BoundingRect(CvHandle points, bool update = false)
        {
            return NativeMethods.cvBoundingRect(points, update ? 1 : 0);
        }

        /// <summary>
        /// Calculates the area of a whole contour or contour section.
        /// </summary>
        /// <param name="contour">Sequence or array of vertices.</param>
        /// <returns>The area of the whole contour or contour section.</returns>
        public static double ContourArea(CvHandle contour)
        {
            return ContourArea(contour, CvSlice.WholeSeq);
        }

        /// <summary>
        /// Calculates the area of a whole contour or contour section.
        /// </summary>
        /// <param name="contour">Sequence or array of vertices.</param>
        /// <param name="slice">
        /// Starting and ending points of the contour section of interest. By default, the
        /// area of the whole contour is calculated.
        /// </param>
        /// <param name="oriented">
        /// If <b>false</b>, the absolute area will be returned; otherwise the returned value
        /// might be negative.
        /// </param>
        /// <returns>The area of the whole contour or contour section.</returns>
        public static double ContourArea(CvHandle contour, CvSlice slice, bool oriented = false)
        {
            return NativeMethods.cvContourArea(contour, slice, oriented ? 1 : 0);
        }

        /// <summary>
        /// Finds the circumscribed rectangle of minimal area for a given 2D point set.
        /// </summary>
        /// <param name="points">Sequence or array of points.</param>
        /// <param name="storage">Optional temporary memory storage.</param>
        /// <returns>The oriented rectangle with minimal area for the specified <paramref name="points"/>.</returns>
        public static CvBox2D MinAreaRect2(CvHandle points, CvMemStorage storage = null)
        {
            return NativeMethods.cvMinAreaRect2(points, storage ?? CvMemStorage.Null);
        }

        /// <summary>
        /// Finds the circumscribed circle of minimal area for a given 2D point set.
        /// </summary>
        /// <param name="points">Sequence or array of points.</param>
        /// <param name="center">Output parameter; the center of the enclosing circle.</param>
        /// <param name="radius">Output parameter; the radius of the enclosing circle.</param>
        /// <returns>
        /// <b>true</b> if the resulting circle contains all the input points and <b>false</b>
        /// otherwise.
        /// </returns>
        public static bool MinEnclosingCircle(CvHandle points, out CvPoint2D32f center, out float radius)
        {
            return NativeMethods.cvMinEnclosingCircle(points, out center, out radius) > 0;
        }

        /// <summary>
        /// Compares two shapes using their Hu moments.
        /// </summary>
        /// <param name="object1">First contour or grayscale image.</param>
        /// <param name="object2">Second contour or grayscale image.</param>
        /// <param name="method">The shape comparison method.</param>
        /// <param name="parameter">Method-specific parameter (not used).</param>
        /// <returns>The distance between the two shapes.</returns>
        public static double MatchShapes(CvHandle object1, CvHandle object2, ShapeMatchingMethod method, double parameter = 0)
        {
            return NativeMethods.cvMatchShapes(object1, object2, method, parameter);
        }

        /// <summary>
        /// Finds the convex hull of a point set.
        /// </summary>
        /// <param name="input">Sequence or array of points.</param>
        /// <param name="hullStorage">The array or memory storage that will store the convex hull.</param>
        /// <param name="orientation">Desired orientation of the convex hull.</param>
        /// <param name="returnPoints">
        /// If <b>true</b>, the points themselves will be stored in the hull instead of the indices.
        /// </param>
        /// <returns>A sequence containing the points in the convex hull.</returns>
        public static CvSeq ConvexHull2(
            CvHandle input,
            CvHandle hullStorage = null,
            ShapeOrientation orientation = ShapeOrientation.Clockwise,
            bool returnPoints = false)
        {
            var hull = NativeMethods.cvConvexHull2(input, hullStorage ?? CvMemStorage.Null, orientation, returnPoints ? 1 : 0);
            if (hull.IsInvalid) return null;
            hull.SetOwnerStorage((CvMemStorage)hullStorage);
            return hull;
        }

        /// <summary>
        /// Tests contour convexity. The contour must be simple, without self-intersections.
        /// </summary>
        /// <param name="contour">Sequence or array of points.</param>
        /// <returns>
        /// A value indicating whether or not the <paramref name="contour"/> is convex.
        /// </returns>
        public static bool CheckContourConvexity(CvHandle contour)
        {
            return NativeMethods.cvCheckContourConvexity(contour) > 0;
        }

        /// <summary>
        /// Finds the convexity defects of a contour.
        /// </summary>
        /// <param name="contour">Input contour.</param>
        /// <param name="convexhull">
        /// Convex hull obtained using <see cref="ConvexHull2"/> that should contain pointers or indices
        /// to the contour points, not the hull points themselves (i.e. the returnPoints of <see cref="ConvexHull2"/>
        /// parameter should be <b>false</b>).
        /// </param>
        /// <param name="storage">Container for the output sequence of convexity defects.</param>
        /// <returns>A sequence of <see cref="CvConvexityDefect"/> structures.</returns>
        public static CvSeq ConvexityDefects(CvHandle contour, CvSeq convexhull, CvMemStorage storage = null)
        {
            var defects = NativeMethods.cvConvexityDefects(contour, convexhull, storage ?? CvMemStorage.Null);
            if (storage == null)
            {
                var seq = contour as CvSeq;
                if (seq != null) storage = seq.Storage;
                else storage = convexhull.Storage;
            }

            defects.SetOwnerStorage(storage);
            return defects;
        }

        /// <summary>
        /// Fits an ellipse around a set of 2D points.
        /// </summary>
        /// <param name="points">Sequence or array of points.</param>
        /// <returns>
        /// The rotated rectangle representing the ellipse best fit around the point set.
        /// The size of the box represents the full lengths of the ellipse axes.
        /// </returns>
        public static CvBox2D FitEllipse2(CvHandle points)
        {
            return NativeMethods.cvFitEllipse2(points);
        }

        /// <summary>
        /// Finds minimum rectangle containing two given rectangles.
        /// </summary>
        /// <param name="rect1">The first rectangle.</param>
        /// <param name="rect2">The second rectangle.</param>
        /// <returns>
        /// The minimum rectangle containing <paramref name="rect1"/> and <paramref name="rect2"/>.
        /// </returns>
        public static CvRect MaxRect(CvRect rect1, CvRect rect2)
        {
            return NativeMethods.cvMaxRect(ref rect1, ref rect2);
        }

        /// <summary>
        /// Finds the box vertices.
        /// </summary>
        /// <param name="box">The input rotated rectangle.</param>
        /// <param name="pt">The array of box vertices.</param>
        public static void BoxPoints(CvBox2D box, CvPoint2D32f[] pt)
        {
            NativeMethods.cvBoxPoints(box, pt);
        }

        /// <summary>
        /// Point in contour test.
        /// </summary>
        /// <param name="contour">Input contour.</param>
        /// <param name="pt">The point to be tested against the <paramref name="contour"/>.</param>
        /// <param name="measureDist">
        /// If <b>true</b> the method estimates the distance from the point to the nearest
        /// contour edge. Otherwise, only the test result itself is stored.
        /// </param>
        /// <returns>
        /// If <paramref name="measureDist"/> is <b>true</b>, the return value is a signed distance
        /// between the point and the nearest contour edge. Otherwise, +1, -1 and 0 are returned,
        /// respectively, when the point is inside the contour, outside or lies on an edge.
        /// </returns>
        public static double PointPolygonTest(CvHandle contour, CvPoint2D32f pt, bool measureDist)
        {
            return NativeMethods.cvPointPolygonTest(contour, pt, measureDist ? 1 : 0);
        }

        #endregion

        #region Histogram functions

        /// <summary>
        /// Calculates bayesian probabilistic histograms.
        /// </summary>
        /// <param name="src">The source histograms.</param>
        /// <param name="dst">The destination histograms.</param>
        public static void CalcBayesianProb(CvHistogram[] src, CvHistogram[] dst)
        {
            var pSrc = Array.ConvertAll(src, hist => hist.DangerousGetHandle());
            var pDst = Array.ConvertAll(dst, hist => hist.DangerousGetHandle());
            NativeMethods.cvCalcBayesianProb(pSrc, pSrc.Length, pDst);
            GC.KeepAlive(src);
            GC.KeepAlive(dst);
        }

        /// <summary>
        /// Equalizes the histogram of a grayscale image.
        /// </summary>
        /// <param name="src">Source 8-bit single channel image.</param>
        /// <param name="dst">Destination image of the same size and type as <paramref name="src"/>.</param>
        public static void EqualizeHist(CvArr src, CvArr dst)
        {
            NativeMethods.cvEqualizeHist(src, dst);
        }

        /// <summary>
        /// Calculates the distance to the closest zero pixel for all non-zero pixels of the source image.
        /// </summary>
        /// <param name="src">8-bit, single-channel (binary) source image.</param>
        /// <param name="dst">Output image with calculated distances (32-bit floating-point, single-channel).</param>
        /// <param name="distanceType">The type of distance to use.</param>
        /// <param name="maskSize">Size of the distance transform mask; can be 3 or 5.</param>
        /// <param name="mask">
        /// User-defined mask in the case of a user-defined distance. It consists of 2 numbers
        /// (horizontal/vertical shift cost, diagonal shift cost) in the case of a 3x3 mask and 3 numbers
        /// (horizontal/vertical shift cost, diagonal shift cost, knight’s move cost) in the case of a 5x5 mask.
        /// </param>
        /// <param name="labels">
        /// The optional output 2d array of integer type labels, the same size as <paramref name="src"/>
        /// and <paramref name="dst"/>.
        /// </param>
        /// <param name="labelType">Specifies the content of the output label array.</param>
        public static void DistTransform(
            CvArr src,
            CvArr dst,
            DistanceType distanceType = DistanceType.L2,
            int maskSize = 3,
            float[] mask = null,
            CvArr labels = null,
            DistanceLabel labelType = DistanceLabel.ConnectedComponent)
        {
            NativeMethods.cvDistTransform(src, dst, distanceType, maskSize, mask, labels ?? CvArr.Null, labelType);
        }

        /// <summary>
        /// Applies a fixed-level threshold to array elements.
        /// </summary>
        /// <param name="src">Source array.</param>
        /// <param name="dst">Destination array; must be either the same type as <paramref name="src"/> or 8-bit.</param>
        /// <param name="threshold">Threshold value.</param>
        /// <param name="maxValue">
        /// Maximum value to use with <see cref="ThresholdTypes.Binary"/> and <see cref="ThresholdTypes.BinaryInv"/>.
        /// </param>
        /// <param name="thresholdType">The type of threshold to apply.</param>
        /// <returns>The computed threshold value in case <see cref="ThresholdTypes.Otsu"/> is used.</returns>
        public static double Threshold(
            CvArr src,
            CvArr dst,
            double threshold,
            double maxValue,
            ThresholdTypes thresholdType)
        {
            return NativeMethods.cvThreshold(src, dst, threshold, maxValue, thresholdType);
        }

        /// <summary>
        /// Applies an adaptive threshold to an array.
        /// </summary>
        /// <param name="src">Source 8-bit single-channel image.</param>
        /// <param name="dst">Destination image; will have the same size and the same type as <paramref name="src"/>.</param>
        /// <param name="maxValue">The non-zero value assigned to the pixels for which the condition is satisfied.</param>
        /// <param name="adaptiveMethod">The adaptive thresholding algorithm to use.</param>
        /// <param name="thresholdType">The type of threshold to apply.</param>
        /// <param name="blockSize">
        /// The size of a pixel neighborhood that is used to calculate a threshold value for the pixel, must be
        /// an odd number greater or equal to 3.
        /// </param>
        /// <param name="C">The constant subtracted from the mean or weighted mean.</param>
        public static void AdaptiveThreshold(
            CvArr src,
            CvArr dst,
            double maxValue,
            AdaptiveThresholdMethod adaptiveMethod = AdaptiveThresholdMethod.MeanC,
            ThresholdTypes thresholdType = ThresholdTypes.Binary,
            int blockSize = 3,
            double C = 5)
        {
            NativeMethods.cvAdaptiveThreshold(src, dst, maxValue, adaptiveMethod, thresholdType, blockSize, C);
        }

        /// <summary>
        /// Fills a connected component with the given color.
        /// </summary>
        /// <param name="image">
        /// Input/output 1- or 3-channel, 8-bit or floating-point image. It is modified by the
        /// function unless <see cref="FloodFillFlags.MaskOnly"/> is set.
        /// </param>
        /// <param name="seedPoint">The starting point.</param>
        /// <param name="newVal">New value of the repainted domain pixels.</param>
        public static void FloodFill(
            CvArr image,
            CvPoint seedPoint,
            CvScalar newVal)
        {
            FloodFill(image, seedPoint, newVal, CvScalar.All(0));
        }

        /// <summary>
        /// Fills a connected component with the given color.
        /// </summary>
        /// <param name="image">
        /// Input/output 1- or 3-channel, 8-bit or floating-point image. It is modified by the
        /// function unless <see cref="FloodFillFlags.MaskOnly"/> is set.
        /// </param>
        /// <param name="seedPoint">The starting point.</param>
        /// <param name="newVal">New value of the repainted domain pixels.</param>
        /// <param name="lowerDiff">
        /// Maximal lower brightness/color difference between the currently observed pixel and
        /// one of its neighbors belonging to the component, or a seed pixel being added to the
        /// component.
        /// </param>
        public static void FloodFill(
            CvArr image,
            CvPoint seedPoint,
            CvScalar newVal,
            CvScalar lowerDiff)
        {
            FloodFill(image, seedPoint, newVal, lowerDiff, CvScalar.All(0));
        }

        /// <summary>
        /// Fills a connected component with the given color.
        /// </summary>
        /// <param name="image">
        /// Input/output 1- or 3-channel, 8-bit or floating-point image. It is modified by the
        /// function unless <see cref="FloodFillFlags.MaskOnly"/> is set.
        /// </param>
        /// <param name="seedPoint">The starting point.</param>
        /// <param name="newVal">New value of the repainted domain pixels.</param>
        /// <param name="lowerDiff">
        /// Maximal lower brightness/color difference between the currently observed pixel and
        /// one of its neighbors belonging to the component, or a seed pixel being added to the
        /// component.
        /// </param>
        /// <param name="upperDiff">
        /// Maximal upper brightness/color difference between the currently observed pixel and
        /// one of its neighbors belonging to the component, or a seed pixel being added to the
        /// component.
        /// </param>
        public static void FloodFill(
            CvArr image,
            CvPoint seedPoint,
            CvScalar newVal,
            CvScalar lowerDiff,
            CvScalar upperDiff)
        {
            CvConnectedComp comp;
            FloodFill(image, seedPoint, newVal, lowerDiff, upperDiff, out comp);
        }

        /// <summary>
        /// Fills a connected component with the given color.
        /// </summary>
        /// <param name="image">
        /// Input/output 1- or 3-channel, 8-bit or floating-point image. It is modified by the
        /// function unless <see cref="FloodFillFlags.MaskOnly"/> is set.
        /// </param>
        /// <param name="seedPoint">The starting point.</param>
        /// <param name="newVal">New value of the repainted domain pixels.</param>
        /// <param name="lowerDiff">
        /// Maximal lower brightness/color difference between the currently observed pixel and
        /// one of its neighbors belonging to the component, or a seed pixel being added to the
        /// component.
        /// </param>
        /// <param name="upperDiff">
        /// Maximal upper brightness/color difference between the currently observed pixel and
        /// one of its neighbors belonging to the component, or a seed pixel being added to the
        /// component.
        /// </param>
        /// <param name="comp">
        /// Output parameter that will be initialized with information about the repainted domain.
        /// </param>
        /// <param name="flags">The operation flags.</param>
        /// <param name="mask">
        /// Operation mask, should be a single-channel 8-bit image, 2 pixels wider and 2 pixels taller
        /// than <paramref name="image"/>.
        /// </param>
        public static void FloodFill(
            CvArr image,
            CvPoint seedPoint,
            CvScalar newVal,
            CvScalar lowerDiff,
            CvScalar upperDiff,
            out CvConnectedComp comp,
            FloodFillFlags flags = FloodFillFlags.Connected4,
            CvArr mask = null)
        {
            NativeMethods.cvFloodFill(image, seedPoint, newVal, lowerDiff, upperDiff, out comp, flags, mask ?? CvArr.Null);
        }

        #endregion

        #region Feature detection

        /// <summary>
        /// Implements the Canny algorithm for edge detection.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="edges">Single-channel image to store the edges found by the function.</param>
        /// <param name="threshold1">
        /// The first threshold. The smallest value between <paramref name="threshold1"/> and
        /// <paramref name="threshold2"/> is used for edge linking, the largest value is used
        /// to find the initial segments of strong edges.
        /// </param>
        /// <param name="threshold2">
        /// The second threshold. The smallest value between <paramref name="threshold1"/> and
        /// <paramref name="threshold2"/> is used for edge linking, the largest value is used
        /// to find the initial segments of strong edges.
        /// </param>
        /// <param name="apertureSize">
        /// Aperture parameter for the Sobel operator (see <see cref="Sobel"/>).
        /// </param>
        public static void Canny(CvArr image, CvArr edges, double threshold1, double threshold2, int apertureSize = 3)
        {
            NativeMethods.cvCanny(image, edges, threshold1, threshold2, apertureSize);
        }

        /// <summary>
        /// Calculates the feature map for corner detection.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="corners">Image to store the corner candidates.</param>
        /// <param name="apertureSize">
        /// Aperture parameter for the Sobel operator (see <see cref="Sobel"/>).
        /// </param>
        public static void PreCornerDetect(CvArr image, CvArr corners, int apertureSize=3)
        {
            NativeMethods.cvPreCornerDetect(image, corners, apertureSize);
        }

        /// <summary>
        /// Calculates eigenvalues and eigenvectors of image blocks for corner detection.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="eigenvv">Image to store the results. It must be 6 times wider than the input image.</param>
        /// <param name="blockSize">
        /// The pixel neighborhood size. The method calculates the covariance matrix of derivatives
        /// over the neighborhood and finds its eigenvectors and eigenvalues.
        /// </param>
        /// <param name="apertureSize">
        /// Aperture parameter for the Sobel operator (see <see cref="Sobel"/>).
        /// </param>
        public static void CornerEigenValsAndVecs(CvArr image, CvArr eigenvv, int blockSize, int apertureSize=3)
        {
            NativeMethods.cvCornerEigenValsAndVecs(image, eigenvv, blockSize, apertureSize);
        }

        /// <summary>
        /// Calculates the minimal eigenvalue of gradient matrices for corner detection.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="eigenval">
        /// Image to store the minimal eigenvalues. Should have the same size as <paramref name="image"/>.
        /// </param>
        /// <param name="blockSize">
        /// The pixel neighborhood size (see <see cref="CornerEigenValsAndVecs"/>).
        /// </param>
        /// <param name="apertureSize">
        /// Aperture parameter for the Sobel operator (see <see cref="Sobel"/>).
        /// </param>
        public static void CornerMinEigenVal(CvArr image, CvArr eigenval, int blockSize, int apertureSize=3)
        {
            NativeMethods.cvCornerMinEigenVal(image, eigenval, blockSize, apertureSize);
        }

        /// <summary>
        /// Implements the Harris edge detector.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="harrisResponse">
        /// Image to store the Harris detector responses. Should have the same size as <paramref name="image"/>.
        /// </param>
        /// <param name="blockSize">
        /// The pixel neighborhood size (see <see cref="CornerEigenValsAndVecs"/>).
        /// </param>
        /// <param name="apertureSize">
        /// Aperture parameter for the Sobel operator (see <see cref="Sobel"/>).
        /// </param>
        /// <param name="k">Harris detector free parameter.</param>
        public static void CornerHarris(
            CvArr image,
            CvArr harrisResponse,
            int blockSize,
            int apertureSize = 3,
            double k = 0.04)
        {
            NativeMethods.cvCornerHarris(image, harrisResponse, blockSize, apertureSize, k);
        }

        /// <summary>
        /// Refines the corner locations.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="corners">Initial coordinates of the input corners; refined coordinates on output.</param>
        /// <param name="win">Half of the side length of the search window.</param>
        /// <param name="zeroZone">
        /// Half of the size of the dead region in the middle of the search zone over which the summation
        /// is not done. It is used sometimes to avoid possible singularities of the autocorrelation matrix.
        /// The value of (-1,-1) indicates that there is no such size.
        /// </param>
        /// <param name="criteria">
        /// Criteria for termination of the iterative process of corner refinement.
        /// </param>
        public static void FindCornerSubPix(
            CvArr image,
            CvPoint2D32f[] corners,
            CvSize win,
            CvSize zeroZone,
            CvTermCriteria criteria)
        {
            NativeMethods.cvFindCornerSubPix(image, corners, corners.Length, win, zeroZone, criteria);
        }

        /// <summary>
        /// Determines strong corners on an image.
        /// </summary>
        /// <param name="image">The source 8-bit or floating-point 32-bit, single-channel image.</param>
        /// <param name="eigImage">
        /// Temporary floating-point 32-bit image, the same size as <paramref name="image"/>.
        /// </param>
        /// <param name="tempImage">
        /// Another temporary image, the same size and format as <paramref name="eigImage"/>.
        /// </param>
        /// <param name="corners">Output parameter; detected corners.</param>
        /// <param name="cornerCount">Output parameter; number of detected corners.</param>
        /// <param name="qualityLevel">
        /// Multiplier for the max/min eigenvalue; specifies the minimal accepted quality of image corners.
        /// </param>
        /// <param name="minDistance">
        /// Limit, specifying the minimum possible distance between the returned corners; Euclidian distance
        /// is used.
        /// </param>
        /// <param name="mask">
        /// Region of interest. The function selects points either in the specified region or in the whole
        /// image if the mask is <b>null</b>.
        /// </param>
        /// <param name="blockSize">
        /// Size of the averaging block, passed to the underlying corner detection method.
        /// </param>
        /// <param name="useHarris">
        /// If <b>true</b>, Harris operator (<see cref="CornerHarris"/>) is used instead of default
        /// (<see cref="CornerMinEigenVal"/>).
        /// </param>
        /// <param name="k">
        /// Free parameter of Harris detector; used only if <paramref name="useHarris"/> is <b>true</b>.
        /// </param>
        public static void GoodFeaturesToTrack(
            CvArr image,
            CvArr eigImage,
            CvArr tempImage,
            CvPoint2D32f[] corners,
            out int cornerCount,
            double qualityLevel,
            double minDistance,
            CvArr mask = null,
            int blockSize = 3,
            bool useHarris = false,
            double k = 0.04)
        {
            cornerCount = corners.Length;
            NativeMethods.cvGoodFeaturesToTrack(
                image,
                eigImage,
                tempImage,
                corners,
                ref cornerCount,
                qualityLevel,
                minDistance,
                mask ?? CvArr.Null,
                blockSize,
                useHarris ? 1 : 0,
                k);
        }

        /// <summary>
        /// Finds lines in a binary image using a Hough transform.
        /// </summary>
        /// <param name="image">
        /// The 8-bit, single-channel, binary source image. In the case of a probabilistic method,
        /// the image is modified by the function.
        /// </param>
        /// <param name="lineStorage">
        /// The storage for the lines that are detected. It can be a memory storage (in this case
        /// a sequence of lines is created in the storage and returned by the function) or single
        /// row/single column matrix (<see cref="CvMat"/>) of a particular type.
        /// </param>
        /// <param name="method">The Hough transform variant.</param>
        /// <param name="rho">Distance resolution in pixel-related units.</param>
        /// <param name="theta">Angle resolution measured in radians.</param>
        /// <param name="threshold">
        /// Threshold parameter. A line is returned by the function if the corresponding accumulator
        /// value is greater than <paramref name="threshold"/>.
        /// </param>
        /// <param name="param1">
        /// The first method-dependent parameter. For the classical Hough transform it is not used.
        /// For the probabilistic Hough transform it is the minimum line length. For the multi-scale
        /// Hough transform it is the divisor for the distance resolution <paramref name="rho"/>.
        /// </param>
        /// <param name="param2">
        /// The second method-dependent parameter. For the classical Hough transform it is not used.
        /// For the probabilistic Hough transform it is the maximum gap between line segments lying on
        /// the same line to treat them as a single line segment (i.e. to join them). For the multi-scale
        /// Hough transform it is the divisor for the angle resolution <paramref name="theta"/>.
        /// </param>
        /// <returns>
        /// A sequence of lines in case <paramref name="lineStorage"/> is a memory storage.
        /// </returns>
        public static CvSeq HoughLines2(
            CvArr image,
            CvHandle lineStorage,
            HoughLinesMethod method,
            double rho,
            double theta,
            int threshold,
            double param1,
            double param2)
        {
            var lines = NativeMethods.cvHoughLines2(image, lineStorage, method, rho, theta, threshold, param1, param2);
            if (lines.IsInvalid) return null;
            lines.SetOwnerStorage((CvMemStorage)lineStorage);
            return lines;
        }

        /// <summary>
        /// Finds circles in a grayscale image using a Hough transform.
        /// </summary>
        /// <param name="image">The 8-bit, single-channel, grayscale input image.</param>
        /// <param name="circleStorage">
        /// The storage for the circles that are detected. It can be a memory storage (in this case
        /// a sequence of circles is created in the storage and returned by the function) or single
        /// row/single column matrix (<see cref="CvMat"/>) of a particular type.
        /// </param>
        /// <param name="method">
        /// The Hough transform method. Currently, only <see cref="HoughCirclesMethod.Gradient"/>
        /// is implemented.
        /// </param>
        /// <param name="dp">
        /// The inverse ratio of the accumulator resolution to the image resolution. For example, if
        /// <paramref name="dp"/> = 1, the accumulator will have the same resolution as the input image,
        /// if <paramref name="dp"/> = 2 the accumulator will have half as big width and height, etc.
        /// </param>
        /// <param name="minDist">
        /// Minimum distance between the centers of the detected circles. If the parameter is too small,
        /// multiple neighbor circles may be falsely detected in addition to a true one. If it is too large,
        /// some circles may be missed.
        /// </param>
        /// <param name="param1">
        /// The first method-specific parameter. in the case of <see cref="HoughCirclesMethod.Gradient"/>
        /// it is the higher threshold of the two passed to the canny edge detector (the lower one will be
        /// twice smaller).
        /// </param>
        /// <param name="param2">
        /// The second method-specific parameter. in the case of <see cref="HoughCirclesMethod.Gradient"/>
        /// it is the accumulator threshold at the center detection stage. The smaller it is, the more false
        /// circles may be detected. Circles, corresponding to the larger accumulator values, will be
        /// returned first.
        /// </param>
        /// <param name="minRadius">Minimum circle radius.</param>
        /// <param name="maxRadius">Maximum circle radius.</param>
        /// <returns>
        /// A sequence of lines in case <paramref name="circleStorage"/> is a memory storage.
        /// </returns>
        public static CvSeq HoughCircles(
            CvArr image,
            CvHandle circleStorage,
            HoughCirclesMethod method,
            double dp,
            double minDist,
            double param1,
            double param2,
            int minRadius,
            int maxRadius)
        {
            var circles = NativeMethods.cvHoughCircles(image, circleStorage, method, dp, minDist, param1, param2, minRadius, maxRadius);
            if (circles.IsInvalid) return null;
            circles.SetOwnerStorage((CvMemStorage)circleStorage);
            return circles;
        }

        /// <summary>
        /// Fits line to 2D or 3D point set.
        /// </summary>
        /// <param name="points">
        /// Sequence or array of 2D or 3D points with 32-bit integer or floating-point coordinates.
        /// </param>
        /// <param name="distType">The distance used for fitting.</param>
        /// <param name="param">
        /// Numerical parameter (C) for some types of distances, if 0 then some optimal value is chosen.
        /// </param>
        /// <param name="reps">
        /// Sufficient accuracy for radius (distance between the coordinate origin and the line);
        /// 0.01 would be a good default.
        /// </param>
        /// <param name="aeps">Sufficient accuracy for angle; 0.01 would be a good default.</param>
        /// <param name="line">
        /// The output line parameters. In case of 2D fitting it is an array of 4 floats (vx, vy, x0, y0)
        /// where (vx, vy) is a normalized vector collinear to the line and (x0, y0) is some point on the line.
        /// In case of 3D fitting it is an array of 6 floats (vx, vy, vz, x0, y0, z0) where (vx, vy, vz) is a
        /// normalized vector collinear to the line and (x0, y0, z0) is some point on the line.
        /// </param>
        public static void FitLine(
            CvArr points,
            DistanceType distType,
            double param,
            double reps,
            double aeps,
            float[] line)
        {
            NativeMethods.cvFitLine(points, distType, param, reps, aeps, line);
        }

        #endregion
    }
}
