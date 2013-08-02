using OpenCV.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCV.Net
{
    public static partial class cv
    {
        #region Camera Calibration, Pose Estimation and Stereo

        /// <summary>
        /// Convert points to/from homogeneous coordinates.
        /// </summary>
        /// <param name="src">
        /// The input point array, 2xN, Nx2, 3xN, Nx3, 4xN or Nx4 (where N is the number of points).
        /// Multi-channel 1xN or Nx1 array is also acceptable.
        /// </param>
        /// <param name="dst">
        /// The output point array, must contain the same number of points as the input.
        /// The dimensionality must be the same, 1 less or 1 more than the input.
        /// </param>
        public static void ConvertPointsHomogeneous(CvMat src, CvMat dst)
        {
            NativeMethods.cvConvertPointsHomogeneous(src, dst);
        }

        /// <summary>
        /// Calculates the fundamental matrix from the corresponding points in two images.
        /// </summary>
        /// <param name="points1">
        /// Array of N points from the first image. It can be 2xN, Nx2, 3xN or Nx3 1-channel array or
        /// 1xN or Nx1 2- or 3-channel array. The point coordinates should be floating-point
        /// (single or double precision).
        /// </param>
        /// <param name="points2">
        /// Array of the second image points of the same size and format as <paramref name="points1"/>.
        /// </param>
        /// <param name="fundamentalMatrix">
        /// The output fundamental matrix or matrices. The size should be 3x3 or 9x3
        /// (7-point method may return up to 3 matrices).
        /// </param>
        /// <param name="method">Method for computing the fundamental matrix.</param>
        /// <param name="param1">
        /// The parameter is used for RANSAC. It is the maximum distance from the point to the epipolar line
        /// in pixels, beyond which the point is considered an outlier and is not used for computing the
        /// final fundamental matrix. It can be set to something like 1-3, depending on the accuracy of the
        /// point localization, image resolution and image noise.
        /// </param>
        /// <param name="param2">
        /// The parameter is used for RANSAC or LMedS methods only. It specifies the desirable level of
        /// confidence (probability) that the estimated matrix is correct.
        /// </param>
        /// <param name="status">
        /// The optional output array of N elements, every element of which is set to 0 for outliers and to
        /// 1 for the other points. The array is computed only in RANSAC and LMedS methods. For other methods
        /// it is set to all 1's.
        /// </param>
        /// <returns>
        /// The number of fundamental matrices found (1 or 3) or 0, if no matrix is found. Normally just one
        /// matrix is found, but in the case of 7-point algorithm the function may return up to 3 solutions
        /// (9x3 matrix that stores all 3 matrices sequentially).
        /// </returns>
        public static int FindFundamentalMat(
            CvMat points1,
            CvMat points2,
            CvMat fundamentalMatrix,
            FundamentalMatrixMethod method = FundamentalMatrixMethod.Ransac,
            double param1 = 3,
            double param2 = 0.99,
            CvMat status = null)
        {
            return NativeMethods.cvFindFundamentalMat(points1, points2, fundamentalMatrix, method, param1, param2, status ?? CvMat.Null);
        }

        /// <summary>
        /// For points in one image of a stereo pair, computes the corresponding epilines in the other image.
        /// </summary>
        /// <param name="points">
        /// The input points. 2xN, Nx2, 3xN or Nx3 array (where N number of points). Multi-channel 1xN or Nx1
        /// array is also acceptable.
        /// </param>
        /// <param name="whichImage">Index of the image (1 or 2) that contains the points.</param>
        /// <param name="fundamentalMatrix">
        /// The fundamental matrix that can be estimated using <see cref="FindFundamentalMat"/> or
        /// <see cref="StereoRectify(CvMat,CvMat,CvMat,CvMat,CvSize,CvMat,CvMat,CvMat,CvMat,CvMat,CvMat,CvMat,StereoRectificationFlags,double,CvSize)"/>.
        /// </param>
        /// <param name="correspondentLines">
        /// The output epilines, a 3xN or Nx3 array. Each line ax + by + c = 0 is encoded by 3 numbers (a, b, c).
        /// </param>
        public static void ComputeCorrespondEpilines(
            CvMat points,
            int whichImage,
            CvMat fundamentalMatrix,
            CvMat correspondentLines)
        {
            NativeMethods.cvComputeCorrespondEpilines(points, whichImage, fundamentalMatrix, correspondentLines);
        }

        /// <summary>
        /// Reconstructs points by triangulation.
        /// </summary>
        /// <param name="projMatr1">3x4 projection matrix of the first camera.</param>
        /// <param name="projMatr2">3x4 projection matrix of the second camera.</param>
        /// <param name="projPoints1">2xN array of feature points in the first image.</param>
        /// <param name="projPoints2">2xN array of corresponding points in the second image.</param>
        /// <param name="points4D">4xN array of reconstructed points in homogeneous coordinates.</param>
        public static void TriangulatePoints(
            CvMat projMatr1,
            CvMat projMatr2,
            CvMat projPoints1,
            CvMat projPoints2,
            CvMat points4D)
        {
            NativeMethods.cvTriangulatePoints(projMatr1, projMatr2, projPoints1, projPoints2, points4D);
        }

        /// <summary>
        /// Refines coordinates of corresponding points.
        /// </summary>
        /// <param name="F">3x3 fundamental matrix.</param>
        /// <param name="points1">1xN array containing the first set of points.</param>
        /// <param name="points2">1xN array containing the second set of points.</param>
        /// <param name="newPoints1">The optimized <paramref name="points1"/>.</param>
        /// <param name="newPoints2">The optimized <paramref name="points2"/></param>
        public static void CorrectMatches(
            CvMat F,
            CvMat points1,
            CvMat points2,
            CvMat newPoints1,
            CvMat newPoints2)
        {
            NativeMethods.cvCorrectMatches(F, points1, points2, newPoints1, newPoints2);
        }

        /// <summary>
        /// Returns the new camera matrix based on the free scaling parameter.
        /// </summary>
        /// <param name="cameraMatrix">The input camera matrix.</param>
        /// <param name="distCoeffs">
        /// The input 4x1, 1x4, 5x1 or 1x5 vector of distortion coefficients (k1, k2, p1, p2[, k3]).
        /// If the vector is <b>null</b>, the zero distortion coefficients are assumed.
        /// </param>
        /// <param name="imageSize">The original image size.</param>
        /// <param name="alpha">
        /// The free scaling parameter between 0 (when all the pixels in the undistorted image will be valid) and 1
        /// (when all the source image pixels will be retained in the undistorted image); see
        /// <see cref="StereoRectify(CvMat,CvMat,CvMat,CvMat,CvSize,CvMat,CvMat,CvMat,CvMat,CvMat,CvMat,CvMat,StereoRectificationFlags,double,CvSize)"/>.
        /// </param>
        /// <param name="newCameraMatrix">The output new camera matrix.</param>
        public static void GetOptimalNewCameraMatrix(
            CvMat cameraMatrix,
            CvMat distCoeffs,
            CvSize imageSize,
            double alpha,
            CvMat newCameraMatrix)
        {
            GetOptimalNewCameraMatrix(cameraMatrix, distCoeffs, imageSize, alpha, newCameraMatrix, CvSize.Zero);
        }

        /// <summary>
        /// Returns the new camera matrix based on the free scaling parameter.
        /// </summary>
        /// <param name="cameraMatrix">The input camera matrix.</param>
        /// <param name="distCoeffs">
        /// The input 4x1, 1x4, 5x1 or 1x5 vector of distortion coefficients (k1, k2, p1, p2[, k3]).
        /// If the vector is <b>null</b>, the zero distortion coefficients are assumed.
        /// </param>
        /// <param name="imageSize">The original image size.</param>
        /// <param name="alpha">
        /// The free scaling parameter between 0 (when all the pixels in the undistorted image will be valid) and 1
        /// (when all the source image pixels will be retained in the undistorted image); see
        /// <see cref="StereoRectify(CvMat,CvMat,CvMat,CvMat,CvSize,CvMat,CvMat,CvMat,CvMat,CvMat,CvMat,CvMat,StereoRectificationFlags,double,CvSize)"/>.
        /// </param>
        /// <param name="newCameraMatrix">The output new camera matrix.</param>
        /// <param name="newImageSize">
        /// The image size after rectification. By default it will be set to <paramref name="imageSize"/>.
        /// </param>
        public static void GetOptimalNewCameraMatrix(
            CvMat cameraMatrix,
            CvMat distCoeffs,
            CvSize imageSize,
            double alpha,
            CvMat newCameraMatrix,
            CvSize newImageSize)
        {
            CvRect validPixelRoi;
            GetOptimalNewCameraMatrix(cameraMatrix, distCoeffs, imageSize, alpha, newCameraMatrix, newImageSize, out validPixelRoi);
        }

        /// <summary>
        /// Returns the new camera matrix based on the free scaling parameter.
        /// </summary>
        /// <param name="cameraMatrix">The input camera matrix.</param>
        /// <param name="distCoeffs">
        /// The input 4x1, 1x4, 5x1 or 1x5 vector of distortion coefficients (k1, k2, p1, p2[, k3]).
        /// If the vector is <b>null</b>, the zero distortion coefficients are assumed.
        /// </param>
        /// <param name="imageSize">The original image size.</param>
        /// <param name="alpha">
        /// The free scaling parameter between 0 (when all the pixels in the undistorted image will be valid) and 1
        /// (when all the source image pixels will be retained in the undistorted image); see
        /// <see cref="StereoRectify(CvMat,CvMat,CvMat,CvMat,CvSize,CvMat,CvMat,CvMat,CvMat,CvMat,CvMat,CvMat,StereoRectificationFlags,double,CvSize)"/>.
        /// </param>
        /// <param name="newCameraMatrix">The output new camera matrix.</param>
        /// <param name="newImageSize">
        /// The image size after rectification. By default it will be set to <paramref name="imageSize"/>.
        /// </param>
        /// <param name="validPixelROI">
        /// The optional output rectangle that will outline all-good-pixels region in the undistorted image.
        /// </param>
        /// <param name="centerPrincipalPoint">
        /// Optional flag that indicates whether in the new camera matrix the principal point should be at the
        /// image center or not. By default, the principal point is chosen to best fit a subset of the source
        /// image (determined by alpha) to the corrected image.
        /// </param>
        public static void GetOptimalNewCameraMatrix(
            CvMat cameraMatrix,
            CvMat distCoeffs,
            CvSize imageSize,
            double alpha,
            CvMat newCameraMatrix,
            CvSize newImageSize,
            out CvRect validPixelROI,
            bool centerPrincipalPoint = false)
        {
            NativeMethods.cvGetOptimalNewCameraMatrix(cameraMatrix, distCoeffs ?? CvMat.Null, imageSize, alpha, newCameraMatrix, newImageSize, out validPixelROI, centerPrincipalPoint ? 1 : 0);
        }

        /// <summary>
        /// Converts a rotation matrix to a rotation vector or vice versa.
        /// </summary>
        /// <param name="src">The input rotation vector (3x1 or 1x3) or rotation matrix (3x3).</param>
        /// <param name="dst">The output rotation matrix (3x3) or rotation vector (3x1 or 1x3), respectively.</param>
        /// <param name="jacobian">
        /// Optional output Jacobian matrix, 3x9 or 9x3; partial derivatives of the output array components with
        /// respect to the input array components.
        /// </param>
        /// <returns>A value indicating whether the conversion was successful.</returns>
        public static bool Rodrigues2(CvMat src, CvMat dst, CvMat jacobian = null)
        {
            return NativeMethods.cvRodrigues2(src, dst, jacobian ?? CvMat.Null) > 0;
        }

        /// <summary>
        /// Finds the perspective transformation between two planes.
        /// </summary>
        /// <param name="srcPoints">
        /// Coordinates of the points in the original plane, 2xN, Nx2, 3xN or Nx3 1-channel array (the latter two are
        /// for representation in homogeneous coordinates), where N is the number of points. 1xN or Nx1 2- or 3-channel
        /// array can also be passed.
        /// </param>
        /// <param name="dstPoints">
        /// Point coordinates in the destination plane, 2xN, Nx2, 3xN or Nx3 1-channel, or 1xN or Nx1 2- or 3-channel array.
        /// </param>
        /// <param name="homography">The output 3x3 homography matrix.</param>
        /// <param name="method">The method used to compute the homography matrix.</param>
        /// <param name="ransacReprojThreshold">
        /// The maximum allowed reprojection error to treat a point pair as an inlier (used in the RANSAC method only).
        /// </param>
        /// <param name="mask">
        /// The optional output mask set by a robust method (<see cref="FindHomographyMethod.Ransac"/> or
        /// <see cref="FindHomographyMethod.LMedS"/>).
        /// </param>
        /// <returns>A value indicating whether the homography matrix calculation was successful.</returns>
        public static bool FindHomography(
            CvMat srcPoints,
            CvMat dstPoints,
            CvMat homography,
            FindHomographyMethod method = FindHomographyMethod.Regular,
            double ransacReprojThreshold = 3,
            CvMat mask = null)
        {
            return NativeMethods.cvFindHomography(srcPoints, dstPoints, homography, method, ransacReprojThreshold, mask ?? CvMat.Null) > 0;
        }

        /// <summary>
        /// Computes the ‘RQ’ decomposition of 3x3 matrices.
        /// </summary>
        /// <param name="matrixM">The 3x3 input matrix.</param>
        /// <param name="matrixR">The output 3x3 upper-triangular matrix.</param>
        /// <param name="matrixQ">The output 3x3 orthogonal matrix.</param>
        /// <param name="matrixQx">Optional output 3x3 rotation matrix around x-axis.</param>
        /// <param name="matrixQy">Optional output 3x3 rotation matrix around y-axis.</param>
        /// <param name="matrixQz">Optional output 3x3 rotation matrix around z-axis.</param>
        /// <param name="eulerAngles">Optional output array containing the three Euler angles of rotation.</param>
        public static void RQDecomp3x3(
            CvMat matrixM,
            CvMat matrixR,
            CvMat matrixQ,
            CvMat matrixQx = null,
            CvMat matrixQy = null,
            CvMat matrixQz = null,
            CvPoint3D64f[] eulerAngles = null)
        {
            NativeMethods.cvRQDecomp3x3(matrixM, matrixR, matrixQ, matrixQx ?? CvMat.Null, matrixQy ?? CvMat.Null, matrixQz ?? CvMat.Null, eulerAngles);
        }

        /// <summary>
        /// Decomposes the projection matrix into a rotation matrix and a camera matrix.
        /// </summary>
        /// <param name="projMatr">The 3x4 input projection matrix P.</param>
        /// <param name="calibMatr">The output 3x3 camera matrix K.</param>
        /// <param name="rotMatr">The output 3x3 external rotation matrix R.</param>
        /// <param name="posVect">The output 4x1 translation vector T.</param>
        /// <param name="rotMatrX">Optional output 3x3 rotation matrix around x-axis.</param>
        /// <param name="rotMatrY">Optional output 3x3 rotation matrix around y-axis.</param>
        /// <param name="rotMatrZ">Optional output 3x3 rotation matrix around z-axis.</param>
        /// <param name="eulerAngles">Optional output array containing the three Euler angles of rotation.</param>
        public static void DecomposeProjectionMatrix(
            CvMat projMatr,
            CvMat calibMatr,
            CvMat rotMatr,
            CvMat posVect,
            CvMat rotMatrX = null,
            CvMat rotMatrY = null,
            CvMat rotMatrZ = null,
            CvPoint3D64f[] eulerAngles = null)
        {
            NativeMethods.cvDecomposeProjectionMatrix(projMatr, calibMatr, rotMatr, posVect, rotMatrX ?? CvMat.Null, rotMatrY ?? CvMat.Null, rotMatrZ ?? CvMat.Null, eulerAngles);
        }

        /// <summary>
        /// Computes partial derivatives of the matrix product for each multiplied matrix.
        /// </summary>
        /// <param name="A">First multiplied matrix.</param>
        /// <param name="B">Second multiplied matrix.</param>
        /// <param name="dABdA">First output derivative matrix d(A*B)/dA of size (A.Rows*B.Cols)x(A.Rows*A.Cols).</param>
        /// <param name="dABdB">Second output derivative matrix d(A*B)/dB of size (A.Rows*B.Cols)x(B.Rows*B.Cols).</param>
        public static void CalcMatMulDeriv(CvMat A, CvMat B, CvMat dABdA, CvMat dABdB)
        {
            NativeMethods.cvCalcMatMulDeriv(A, B, dABdA, dABdB);
        }

        /// <summary>
        /// Combines two rotation-and-shift transformations.
        /// </summary>
        /// <param name="rvec1">First rotation vector.</param>
        /// <param name="tvec1">First translation vector.</param>
        /// <param name="rvec2">Second rotation vector.</param>
        /// <param name="tvec2">Second translation vector.</param>
        /// <param name="rvec3">Output rotation vector of the superposition.</param>
        /// <param name="tvec3">Output translation vector of the superposition.</param>
        /// <param name="dr3dr1">Optional output derivatives of <paramref name="rvec3"/> with regard to <paramref name="rvec1"/>.</param>
        /// <param name="dr3dt1">Optional output derivatives of <paramref name="rvec3"/> with regard to <paramref name="tvec1"/>.</param>
        /// <param name="dr3dr2">Optional output derivatives of <paramref name="rvec3"/> with regard to <paramref name="rvec2"/>.</param>
        /// <param name="dr3dt2">Optional output derivatives of <paramref name="rvec3"/> with regard to <paramref name="tvec2"/>.</param>
        /// <param name="dt3dr1">Optional output derivatives of <paramref name="tvec3"/> with regard to <paramref name="rvec1"/>.</param>
        /// <param name="dt3dt1">Optional output derivatives of <paramref name="tvec3"/> with regard to <paramref name="tvec1"/>.</param>
        /// <param name="dt3dr2">Optional output derivatives of <paramref name="tvec3"/> with regard to <paramref name="rvec2"/>.</param>
        /// <param name="dt3dt2">Optional output derivatives of <paramref name="tvec3"/> with regard to <paramref name="tvec2"/>.</param>
        public static void ComposeRT(
            CvMat rvec1,
            CvMat tvec1,
            CvMat rvec2,
            CvMat tvec2,
            CvMat rvec3,
            CvMat tvec3,
            CvMat dr3dr1 = null,
            CvMat dr3dt1 = null,
            CvMat dr3dr2 = null,
            CvMat dr3dt2 = null,
            CvMat dt3dr1 = null,
            CvMat dt3dt1 = null,
            CvMat dt3dr2 = null,
            CvMat dt3dt2 = null)
        {
            NativeMethods.cvComposeRT(
                rvec1, tvec1,
                rvec2, tvec2,
                rvec3, tvec3,
                dr3dr1 ?? CvMat.Null, dr3dt1 ?? CvMat.Null,
                dr3dr2 ?? CvMat.Null, dr3dt2 ?? CvMat.Null,
                dt3dr1 ?? CvMat.Null, dt3dt1 ?? CvMat.Null,
                dt3dr2 ?? CvMat.Null, dt3dt2 ?? CvMat.Null);
        }

        /// <summary>
        /// Projects 3D points to an image plane.
        /// </summary>
        /// <param name="objectPoints">
        /// The array of object points, 3xN or Nx3 1-channel or 1xN or Nx1 3-channel, where N is the number of points in the view.
        /// </param>
        /// <param name="rotationVector">The rotation vector of the points; see <see cref="Rodrigues2"/>.</param>
        /// <param name="translationVector">The translation vector of the points; see <see cref="Rodrigues2"/>.</param>
        /// <param name="cameraMatrix">The camera matrix A = [fx 0 cx; 0 fy cy; 0 0 1].</param>
        /// <param name="distortionCoeffs">
        /// The input vector of distortion coefficients of 4,5 or 8 elements. If it is <b>null</b>, the zero distortion
        /// coefficients are assumed.
        /// </param>
        /// <param name="imagePoints">
        /// The output array of image points, 2xN or Nx2 1-channel or 1xN or Nx1 2-channel.
        /// </param>
        /// <param name="dpdrot">
        /// Optional 2Nx3 matrix of derivatives of image points with respect to components of the rotation vector.
        /// </param>
        /// <param name="dpdt">
        /// Optional 2Nx3 matrix of derivatives of image points with respect to components of the translation vector.
        /// </param>
        /// <param name="dpdf">
        /// Optional 2Nx2 matrix of derivatives of image points with respect to fx and fy.
        /// </param>
        /// <param name="dpdc">
        /// Optional 2Nx2 matrix of derivatives of image points with respect to cx and cy.
        /// </param>
        /// <param name="dpddist">
        /// Optional 2Nx4 matrix of derivatives of image points with respect to the distortion coefficients.
        /// </param>
        /// <param name="aspectRatio">
        /// Optional “fixed aspect ratio” parameter. If the parameter is not 0, the function assumes that the aspect ratio (fx/fy)
        /// is fixed and correspondingly adjusts the jacobian matrix.
        /// </param>
        public static void ProjectPoints2(
            CvMat objectPoints,
            CvMat rotationVector,
            CvMat translationVector,
            CvMat cameraMatrix,
            CvMat distortionCoeffs,
            CvMat imagePoints,
            CvMat dpdrot = null,
            CvMat dpdt = null,
            CvMat dpdf = null,
            CvMat dpdc = null,
            CvMat dpddist = null,
            double aspectRatio = 0)
        {
            NativeMethods.cvProjectPoints2(
                objectPoints, rotationVector, translationVector,
                cameraMatrix, distortionCoeffs ?? CvMat.Null, imagePoints,
                dpdrot ?? CvMat.Null, dpdt ?? CvMat.Null, dpdf ?? CvMat.Null,
                dpdc ?? CvMat.Null, dpddist ?? CvMat.Null, aspectRatio);
        }

        /// <summary>
        /// Finds the object pose from the 3D-2D point correspondences.
        /// </summary>
        /// <param name="objectPoints">
        /// The array of object points in the object coordinate space, 3xN or Nx3 1-channel, or 1xN or Nx1 3-channel,
        /// where N is the number of points.
        /// </param>
        /// <param name="imagePoints">
        /// The array of corresponding image points, 2xN or Nx2 1-channel or 1xN or Nx1 2-channel, where N is the
        /// number of points.
        /// </param>
        /// <param name="cameraMatrix">The camera matrix A = [fx 0 cx; 0 fy cy; 0 0 1].</param>
        /// <param name="distortionCoeffs">
        /// The input vector of distortion coefficients of 4,5 or 8 elements. If it is <b>null</b>, the zero distortion
        /// coefficients are assumed.
        /// </param>
        /// <param name="rotationVector">
        /// The output rotation vector (see <see cref="Rodrigues2"/>) that (together with <paramref name="translationVector"/>)
        /// brings points from the model coordinate system to the camera coordinate system.
        /// </param>
        /// <param name="translationVector">The output translation vector.</param>
        /// <param name="useExtrinsicGuess">
        ///  If <b>true</b>, the function will use the provided <paramref name="rotationVector"/> and <paramref name="translationVector"/>
        ///  as the initial approximations of the rotation and translation vectors, respectively, and will further optimize them.
        /// </param>
        public static void FindExtrinsicCameraParams2(
            CvMat objectPoints,
            CvMat imagePoints,
            CvMat cameraMatrix,
            CvMat distortionCoeffs,
            CvMat rotationVector,
            CvMat translationVector,
            bool useExtrinsicGuess = false)
        {
            NativeMethods.cvFindExtrinsicCameraParams2(
                objectPoints, imagePoints, cameraMatrix, distortionCoeffs ?? CvMat.Null,
                rotationVector, translationVector, useExtrinsicGuess ? 1 : 0);
        }

        /// <summary>
        /// Finds the initial camera matrix from the 3D-2D point correspondences.
        /// </summary>
        /// <param name="objectPoints">
        /// The joint array of object points; see <see cref="CalibrateCamera2(CvMat,CvMat,CvMat,CvSize,CvMat,CvMat,CvMat,CvMat,CameraCalibrationFlags)"/>.
        /// </param>
        /// <param name="imagePoints">
        /// The joint array of object point projections; see <see cref="CalibrateCamera2(CvMat,CvMat,CvMat,CvSize,CvMat,CvMat,CvMat,CvMat,CameraCalibrationFlags)"/>.
        /// </param>
        /// <param name="npoints">
        /// The array of point counts; see <see cref="CalibrateCamera2(CvMat,CvMat,CvMat,CvSize,CvMat,CvMat,CvMat,CvMat,CameraCalibrationFlags)"/>.
        /// </param>
        /// <param name="imageSize">The image size in pixels; used to initialize the principal point.</param>
        /// <param name="cameraMatrix">The output camera matrix A = [fx 0 cx; 0 fy cy; 0 0 1].</param>
        /// <param name="aspectRatio">
        /// If it is zero or negative, both fx and fy are estimated independently. Otherwise fx = fy * <paramref name="aspectRatio"/>.
        /// </param>
        public static void InitIntrinsicParams2D(
            CvMat objectPoints,
            CvMat imagePoints,
            CvMat npoints,
            CvSize imageSize,
            CvMat cameraMatrix,
            double aspectRatio = 1)
        {
            NativeMethods.cvInitIntrinsicParams2D(
                objectPoints, imagePoints, npoints,
                imageSize, cameraMatrix, aspectRatio);
        }

        /// <summary>
        /// Does a fast check if a chessboard is in the input image.
        /// </summary>
        /// <param name="src">The input image.</param>
        /// <param name="size">The size of the chessboard.</param>
        /// <returns><b>true</b> if a chessboard may be in the input image; <b>false</b> otherwise.</returns>
        public static bool CheckChessboard(IplImage src, CvSize size)
        {
            return NativeMethods.cvCheckChessboard(src, size) > 0;
        }

        /// <summary>
        /// Finds the positions of the internal corners of the chessboard.
        /// </summary>
        /// <param name="image">Source chessboard view; it must be an 8-bit grayscale or color image.</param>
        /// <param name="patternSize">
        /// The number of inner corners per chessboard row and column (pointsPerRow,pointsPerColumn).
        /// </param>
        /// <param name="corners">The output array of detected corners.</param>
        /// <returns>
        /// <b>true</b> if all of the corners have been found and correctly reordered; <b>false</b> otherwise.
        /// </returns>
        public static bool FindChessboardCorners(
            CvArr image,
            CvSize patternSize,
            CvPoint2D32f[] corners)
        {
            int cornerCount;
            return FindChessboardCorners(image, patternSize, corners, out cornerCount);
        }

        /// <summary>
        /// Finds the positions of the internal corners of the chessboard.
        /// </summary>
        /// <param name="image">Source chessboard view; it must be an 8-bit grayscale or color image.</param>
        /// <param name="patternSize">
        /// The number of inner corners per chessboard row and column (pointsPerRow, pointsPerColumn).
        /// </param>
        /// <param name="corners">The output array of detected corners.</param>
        /// <param name="cornerCount">The output number of corners found.</param>
        /// <param name="flags">Specifies operation flags.</param>
        /// <returns>
        /// <b>true</b> if all of the corners have been found and correctly reordered; <b>false</b> otherwise.
        /// </returns>
        public static bool FindChessboardCorners(
            CvArr image,
            CvSize patternSize,
            CvPoint2D32f[] corners,
            out int cornerCount,
            ChessboardCalibrationFlags flags = ChessboardCalibrationFlags.AdaptiveThreshold | ChessboardCalibrationFlags.NormalizeImage)
        {
            return NativeMethods.cvFindChessboardCorners(image, patternSize, corners, out cornerCount, flags) > 0;
        }

        /// <summary>
        /// Renders the detected chessboard corners.
        /// </summary>
        /// <param name="image">The destination image; it must be an 8-bit color image.</param>
        /// <param name="patternSize">
        /// The number of inner corners per chessboard row and column (pointsPerRow, pointsPerColumn).
        /// </param>
        /// <param name="corners">The array of detected corners.</param>
        /// <param name="patternWasFound">A value indicating whether the complete board was found.</param>
        public static void DrawChessboardCorners(
            CvArr image,
            CvSize patternSize,
            CvPoint2D32f[] corners,
            bool patternWasFound)
        {
            NativeMethods.cvDrawChessboardCorners(image, patternSize, corners, corners.Length, patternWasFound ? 1 : 0);
        }

        /// <summary>
        /// Finds the camera intrinsic and extrinsic parameters from several views of a calibration pattern.
        /// </summary>
        /// <param name="objectPoints">
        /// The joint matrix of object points; calibration pattern features in the model coordinate space.
        /// A floating-point 3xN or Nx3 1-channel, or 1xN or Nx1 3-channel array, where N is the total number
        /// of points in all views.
        /// </param>
        /// <param name="imagePoints">
        /// The joint matrix of object point projections in the camera views. A floating-point 2xN or Nx2 1-channel,
        /// or 1xN or Nx1 2-channel array, where N is the total number of points in all views.
        /// </param>
        /// <param name="pointCounts">
        /// Integer 1xM or Mx1 vector (where M is the number of calibration pattern views) containing the number
        /// of points in each particular view. The sum of vector elements must match the size of <paramref name="objectPoints"/>
        /// and <paramref name="imagePoints"/> (=N).
        /// </param>
        /// <param name="imageSize">Size of the image, used only to initialize the intrinsic camera matrix.</param>
        /// <param name="cameraMatrix">The output 3x3 floating-point camera matrix A = [fx 0 cx; 0 fy cy; 0 0 1].</param>
        /// <param name="distortionCoeffs">
        /// The output 4x1, 1x4, 5x1 or 1x5 vector of distortion coefficients (k1, k2, p1, p2[, k3]).
        /// </param>
        /// <param name="rotationVectors">
        /// The output 3xM or Mx3 1-channel, or 1xM or Mx1 3-channel array of rotation vectors (see <see cref="Rodrigues2"/>),
        /// estimated for each pattern view. That is, each k-th rotation vector together with the corresponding k-th
        /// translation vector (see the next output parameter description) brings the calibration pattern from the model
        /// coordinate space (in which object points are specified) to the world coordinate space, i.e. real position of
        /// the calibration pattern in the k-th pattern view (k=0..M-1)
        /// </param>
        /// <param name="translationVectors">
        /// The output 3xM or Mx3 1-channel, or 1xM or Mx1 3-channel array of translation vectors, estimated for each
        /// pattern view.
        /// </param>
        /// <param name="flags">Specifies various operation flags.</param>
        /// <returns>The final re-projection error.</returns>
        public static double CalibrateCamera2(
            CvMat objectPoints,
            CvMat imagePoints,
            CvMat pointCounts,
            CvSize imageSize,
            CvMat cameraMatrix,
            CvMat distortionCoeffs,
            CvMat rotationVectors = null,
            CvMat translationVectors = null,
            CameraCalibrationFlags flags = CameraCalibrationFlags.None)
        {
            return CalibrateCamera2(
                objectPoints, imagePoints, pointCounts, imageSize,
                cameraMatrix, distortionCoeffs, rotationVectors, translationVectors,
                flags, new CvTermCriteria(TermCriteriaType.MaxIter | TermCriteriaType.Epsilon, 30, double.Epsilon));
        }

        /// <summary>
        /// Finds the camera intrinsic and extrinsic parameters from several views of a calibration pattern.
        /// </summary>
        /// <param name="objectPoints">
        /// The joint matrix of object points; calibration pattern features in the model coordinate space.
        /// A floating-point 3xN or Nx3 1-channel, or 1xN or Nx1 3-channel array, where N is the total number
        /// of points in all views.
        /// </param>
        /// <param name="imagePoints">
        /// The joint matrix of object point projections in the camera views. A floating-point 2xN or Nx2 1-channel,
        /// or 1xN or Nx1 2-channel array, where N is the total number of points in all views.
        /// </param>
        /// <param name="pointCounts">
        /// Integer 1xM or Mx1 vector (where M is the number of calibration pattern views) containing the number
        /// of points in each particular view. The sum of vector elements must match the size of <paramref name="objectPoints"/>
        /// and <paramref name="imagePoints"/> (=N).
        /// </param>
        /// <param name="imageSize">Size of the image, used only to initialize the intrinsic camera matrix.</param>
        /// <param name="cameraMatrix">The output 3x3 floating-point camera matrix A = [fx 0 cx; 0 fy cy; 0 0 1].</param>
        /// <param name="distortionCoeffs">
        /// The output 4x1, 1x4, 5x1 or 1x5 vector of distortion coefficients (k1, k2, p1, p2[, k3]).
        /// </param>
        /// <param name="rotationVectors">
        /// The output 3xM or Mx3 1-channel, or 1xM or Mx1 3-channel array of rotation vectors (see <see cref="Rodrigues2"/>),
        /// estimated for each pattern view. That is, each k-th rotation vector together with the corresponding k-th
        /// translation vector (see the next output parameter description) brings the calibration pattern from the model
        /// coordinate space (in which object points are specified) to the world coordinate space, i.e. real position of
        /// the calibration pattern in the k-th pattern view (k=0..M-1)
        /// </param>
        /// <param name="translationVectors">
        /// The output 3xM or Mx3 1-channel, or 1xM or Mx1 3-channel array of translation vectors, estimated for each
        /// pattern view.
        /// </param>
        /// <param name="flags">Specifies various operation flags.</param>
        /// <param name="criteria">Termination criteria for the iterative optimization algorithm.</param>
        /// <returns>The final re-projection error.</returns>
        public static double CalibrateCamera2(
            CvMat objectPoints,
            CvMat imagePoints,
            CvMat pointCounts,
            CvSize imageSize,
            CvMat cameraMatrix,
            CvMat distortionCoeffs,
            CvMat rotationVectors,
            CvMat translationVectors,
            CameraCalibrationFlags flags,
            CvTermCriteria criteria)
        {
            return NativeMethods.cvCalibrateCamera2(
                objectPoints, imagePoints, pointCounts, imageSize,
                cameraMatrix, distortionCoeffs, rotationVectors ?? CvMat.Null, translationVectors ?? CvMat.Null,
                flags, criteria);
        }

        /// <summary>
        /// Computes useful camera characteristics from the camera matrix.
        /// </summary>
        /// <param name="cameraMatrix">
        /// Input camera matrix that can be estimated by <see cref="CalibrateCamera2(CvMat,CvMat,CvMat,CvSize,CvMat,CvMat,CvMat,CvMat,CameraCalibrationFlags,CvTermCriteria)"/>
        /// or <see cref="StereoCalibrate(CvMat,CvMat,CvMat,CvMat,CvMat,CvMat,CvMat,CvMat,CvSize,CvMat,CvMat,CvMat,CvMat,CvTermCriteria,StereoCalibrationFlags)"/>.
        /// </param>
        /// <param name="imageSize">Input image size in pixels.</param>
        /// <param name="apertureWidth">Physical width of the sensor.</param>
        /// <param name="apertureHeight">Physical height of the sensor.</param>
        public static void CalibrationMatrixValues(
            CvMat cameraMatrix,
            CvSize imageSize,
            double apertureWidth = 0,
            double apertureHeight = 0)
        {
            double fovx;
            CalibrationMatrixValues(cameraMatrix, imageSize, apertureWidth, apertureHeight, out fovx);
        }

        /// <summary>
        /// Computes useful camera characteristics from the camera matrix.
        /// </summary>
        /// <param name="cameraMatrix">
        /// Input camera matrix that can be estimated by <see cref="CalibrateCamera2(CvMat,CvMat,CvMat,CvSize,CvMat,CvMat,CvMat,CvMat,CameraCalibrationFlags,CvTermCriteria)"/>
        /// or <see cref="StereoCalibrate(CvMat,CvMat,CvMat,CvMat,CvMat,CvMat,CvMat,CvMat,CvSize,CvMat,CvMat,CvMat,CvMat,CvTermCriteria,StereoCalibrationFlags)"/>.
        /// </param>
        /// <param name="imageSize">Input image size in pixels.</param>
        /// <param name="apertureWidth">Physical width of the sensor.</param>
        /// <param name="apertureHeight">Physical height of the sensor.</param>
        /// <param name="fovx">Output field of view in degrees along the horizontal sensor axis.</param>
        public static void CalibrationMatrixValues(
            CvMat cameraMatrix,
            CvSize imageSize,
            double apertureWidth,
            double apertureHeight,
            out double fovx)
        {
            double fovy;
            CalibrationMatrixValues(
                cameraMatrix, imageSize, apertureWidth, apertureHeight,
                out fovx, out fovy);
        }

        /// <summary>
        /// Computes useful camera characteristics from the camera matrix.
        /// </summary>
        /// <param name="cameraMatrix">
        /// Input camera matrix that can be estimated by <see cref="CalibrateCamera2(CvMat,CvMat,CvMat,CvSize,CvMat,CvMat,CvMat,CvMat,CameraCalibrationFlags,CvTermCriteria)"/>
        /// or <see cref="StereoCalibrate(CvMat,CvMat,CvMat,CvMat,CvMat,CvMat,CvMat,CvMat,CvSize,CvMat,CvMat,CvMat,CvMat,CvTermCriteria,StereoCalibrationFlags)"/>.
        /// </param>
        /// <param name="imageSize">Input image size in pixels.</param>
        /// <param name="apertureWidth">Physical width of the sensor.</param>
        /// <param name="apertureHeight">Physical height of the sensor.</param>
        /// <param name="fovx">Output field of view in degrees along the horizontal sensor axis.</param>
        /// <param name="fovy">Output field of view in degrees along the vertical sensor axis.</param>
        public static void CalibrationMatrixValues(
            CvMat cameraMatrix,
            CvSize imageSize,
            double apertureWidth,
            double apertureHeight,
            out double fovx,
            out double fovy)
        {
            double focalLength;
            CalibrationMatrixValues(
                cameraMatrix, imageSize, apertureWidth, apertureHeight,
                out fovx, out fovy, out focalLength);
        }

        /// <summary>
        /// Computes useful camera characteristics from the camera matrix.
        /// </summary>
        /// <param name="cameraMatrix">
        /// Input camera matrix that can be estimated by <see cref="CalibrateCamera2(CvMat,CvMat,CvMat,CvSize,CvMat,CvMat,CvMat,CvMat,CameraCalibrationFlags,CvTermCriteria)"/>
        /// or <see cref="StereoCalibrate(CvMat,CvMat,CvMat,CvMat,CvMat,CvMat,CvMat,CvMat,CvSize,CvMat,CvMat,CvMat,CvMat,CvTermCriteria,StereoCalibrationFlags)"/>.
        /// </param>
        /// <param name="imageSize">Input image size in pixels.</param>
        /// <param name="apertureWidth">Physical width of the sensor.</param>
        /// <param name="apertureHeight">Physical height of the sensor.</param>
        /// <param name="fovx">Output field of view in degrees along the horizontal sensor axis.</param>
        /// <param name="fovy">Output field of view in degrees along the vertical sensor axis.</param>
        /// <param name="focalLength">Focal length of the lens in mm.</param>
        public static void CalibrationMatrixValues(
            CvMat cameraMatrix,
            CvSize imageSize,
            double apertureWidth,
            double apertureHeight,
            out double fovx,
            out double fovy,
            out double focalLength)
        {
            CvPoint2D64f principalPoint;
            CalibrationMatrixValues(
                cameraMatrix, imageSize, apertureWidth, apertureHeight,
                out fovx, out fovy, out focalLength, out principalPoint);
        }

        /// <summary>
        /// Computes useful camera characteristics from the camera matrix.
        /// </summary>
        /// <param name="cameraMatrix">
        /// Input camera matrix that can be estimated by <see cref="CalibrateCamera2(CvMat,CvMat,CvMat,CvSize,CvMat,CvMat,CvMat,CvMat,CameraCalibrationFlags,CvTermCriteria)"/>
        /// or <see cref="StereoCalibrate(CvMat,CvMat,CvMat,CvMat,CvMat,CvMat,CvMat,CvMat,CvSize,CvMat,CvMat,CvMat,CvMat,CvTermCriteria,StereoCalibrationFlags)"/>.
        /// </param>
        /// <param name="imageSize">Input image size in pixels.</param>
        /// <param name="apertureWidth">Physical width of the sensor.</param>
        /// <param name="apertureHeight">Physical height of the sensor.</param>
        /// <param name="fovx">Output field of view in degrees along the horizontal sensor axis.</param>
        /// <param name="fovy">Output field of view in degrees along the vertical sensor axis.</param>
        /// <param name="focalLength">Focal length of the lens in mm.</param>
        /// <param name="principalPoint">Principal point in pixels.</param>
        public static void CalibrationMatrixValues(
            CvMat cameraMatrix,
            CvSize imageSize,
            double apertureWidth,
            double apertureHeight,
            out double fovx,
            out double fovy,
            out double focalLength,
            out CvPoint2D64f principalPoint)
        {
            double pixelAspectRatio;
            CalibrationMatrixValues(
                cameraMatrix, imageSize, apertureWidth, apertureHeight,
                out fovx, out fovy, out focalLength, out principalPoint, out pixelAspectRatio);
        }

        /// <summary>
        /// Computes useful camera characteristics from the camera matrix.
        /// </summary>
        /// <param name="cameraMatrix">
        /// Input camera matrix that can be estimated by <see cref="CalibrateCamera2(CvMat,CvMat,CvMat,CvSize,CvMat,CvMat,CvMat,CvMat,CameraCalibrationFlags,CvTermCriteria)"/>
        /// or <see cref="StereoCalibrate(CvMat,CvMat,CvMat,CvMat,CvMat,CvMat,CvMat,CvMat,CvSize,CvMat,CvMat,CvMat,CvMat,CvTermCriteria,StereoCalibrationFlags)"/>.
        /// </param>
        /// <param name="imageSize">Input image size in pixels.</param>
        /// <param name="apertureWidth">Physical width of the sensor.</param>
        /// <param name="apertureHeight">Physical height of the sensor.</param>
        /// <param name="fovx">Output field of view in degrees along the horizontal sensor axis.</param>
        /// <param name="fovy">Output field of view in degrees along the vertical sensor axis.</param>
        /// <param name="focalLength">Focal length of the lens in mm.</param>
        /// <param name="principalPoint">Principal point in pixels.</param>
        /// <param name="pixelAspectRatio">The aspect ratio of a pixel, given by fy / fx.</param>
        public static void CalibrationMatrixValues(
            CvMat cameraMatrix,
            CvSize imageSize,
            double apertureWidth,
            double apertureHeight,
            out double fovx,
            out double fovy,
            out double focalLength,
            out CvPoint2D64f principalPoint,
            out double pixelAspectRatio)
        {
            NativeMethods.cvCalibrationMatrixValues(
                cameraMatrix, imageSize, apertureWidth, apertureHeight,
                out fovx, out fovy, out focalLength, out principalPoint, out pixelAspectRatio);
        }

        /// <summary>
        /// Calibrates stereo camera.
        /// </summary>
        /// <param name="objectPoints">
        /// The joint matrix of object points; calibration pattern features in the model coordinate space.
        /// A floating-point 3xN or Nx3 1-channel, or 1xN or Nx1 3-channel array, where N is the total number
        /// of points in all views.
        /// </param>
        /// <param name="imagePoints1">
        /// The joint matrix of object point projections in the first camera views. A floating-point 2xN or Nx2
        /// 1-channel, or 1xN or Nx1 2-channel array, where N is the total number of points in all views.
        /// </param>
        /// <param name="imagePoints2">
        /// The joint matrix of object point projections in the second camera views. A floating-point 2xN or Nx2 1-channel,
        /// or 1xN or Nx1 2-channel array, where N is the total number of points in all views.
        /// </param>
        /// <param name="npoints">
        /// Integer 1xM or Mx1 vector (where M is the number of calibration pattern views) containing the number
        /// of points in each particular view. The sum of vector elements must match the size of <paramref name="objectPoints"/>,
        /// <paramref name="imagePoints1"/> and <paramref name="imagePoints2"/> (=N).
        /// </param>
        /// <param name="cameraMatrix1">The output 3x3 floating-point first camera matrix A = [fx 0 cx; 0 fy cy; 0 0 1].</param>
        /// <param name="distCoeffs1">
        /// The output 4x1, 1x4, 5x1 or 1x5 vector of distortion coefficients for the first camera (k1, k2, p1, p2[, k3]).
        /// </param>
        /// <param name="cameraMatrix2">The output 3x3 floating-point second camera matrix A = [fx 0 cx; 0 fy cy; 0 0 1].</param>
        /// <param name="distCoeffs2">
        /// The output 4x1, 1x4, 5x1 or 1x5 vector of distortion coefficients for the second camera (k1, k2, p1, p2[, k3]).
        /// </param>
        /// <param name="imageSize">Size of the image, used only to initialize the intrinsic camera matrix.</param>
        /// <param name="R">The output rotation matrix between the 1st and the 2nd cameras’ coordinate systems.</param>
        /// <param name="T">The output translation vector between the cameras’ coordinate systems.</param>
        /// <param name="E">The optional output essential matrix.</param>
        /// <param name="F">The optional output fundamental matrix.</param>
        /// <returns>The final re-projection error.</returns>
        public static double StereoCalibrate(
            CvMat objectPoints,
            CvMat imagePoints1,
            CvMat imagePoints2,
            CvMat npoints,
            CvMat cameraMatrix1,
            CvMat distCoeffs1,
            CvMat cameraMatrix2,
            CvMat distCoeffs2,
            CvSize imageSize,
            CvMat R,
            CvMat T,
            CvMat E = null,
            CvMat F = null)
        {
            return StereoCalibrate(
                objectPoints, imagePoints1, imagePoints2, npoints,
                cameraMatrix1, distCoeffs1, cameraMatrix2, distCoeffs2, imageSize,
                R, T, E, F, new CvTermCriteria(TermCriteriaType.MaxIter | TermCriteriaType.Epsilon, 30, 1e-6));
        }

        /// <summary>
        /// Calibrates stereo camera.
        /// </summary>
        /// <param name="objectPoints">
        /// The joint matrix of object points; calibration pattern features in the model coordinate space.
        /// A floating-point 3xN or Nx3 1-channel, or 1xN or Nx1 3-channel array, where N is the total number
        /// of points in all views.
        /// </param>
        /// <param name="imagePoints1">
        /// The joint matrix of object point projections in the first camera views. A floating-point 2xN or Nx2
        /// 1-channel, or 1xN or Nx1 2-channel array, where N is the total number of points in all views.
        /// </param>
        /// <param name="imagePoints2">
        /// The joint matrix of object point projections in the second camera views. A floating-point 2xN or Nx2 1-channel,
        /// or 1xN or Nx1 2-channel array, where N is the total number of points in all views.
        /// </param>
        /// <param name="npoints">
        /// Integer 1xM or Mx1 vector (where M is the number of calibration pattern views) containing the number
        /// of points in each particular view. The sum of vector elements must match the size of <paramref name="objectPoints"/>,
        /// <paramref name="imagePoints1"/> and <paramref name="imagePoints2"/> (=N).
        /// </param>
        /// <param name="cameraMatrix1">The output 3x3 floating-point first camera matrix A = [fx 0 cx; 0 fy cy; 0 0 1].</param>
        /// <param name="distCoeffs1">
        /// The output 4x1, 1x4, 5x1 or 1x5 vector of distortion coefficients for the first camera (k1, k2, p1, p2[, k3]).
        /// </param>
        /// <param name="cameraMatrix2">The output 3x3 floating-point second camera matrix A = [fx 0 cx; 0 fy cy; 0 0 1].</param>
        /// <param name="distCoeffs2">
        /// The output 4x1, 1x4, 5x1 or 1x5 vector of distortion coefficients for the second camera (k1, k2, p1, p2[, k3]).
        /// </param>
        /// <param name="imageSize">Size of the image, used only to initialize the intrinsic camera matrix.</param>
        /// <param name="R">The output rotation matrix between the 1st and the 2nd cameras’ coordinate systems.</param>
        /// <param name="T">The output translation vector between the cameras’ coordinate systems.</param>
        /// <param name="E">The optional output essential matrix.</param>
        /// <param name="F">The optional output fundamental matrix.</param>
        /// <param name="criteria">The termination criteria for the iterative optimization algorithm.</param>
        /// <param name="flags">Specifies various operation flags.</param>
        /// <returns>The final re-projection error.</returns>
        public static double StereoCalibrate(
            CvMat objectPoints,
            CvMat imagePoints1,
            CvMat imagePoints2,
            CvMat npoints,
            CvMat cameraMatrix1,
            CvMat distCoeffs1,
            CvMat cameraMatrix2,
            CvMat distCoeffs2,
            CvSize imageSize,
            CvMat R,
            CvMat T,
            CvMat E,
            CvMat F,
            CvTermCriteria criteria,
            StereoCalibrationFlags flags = StereoCalibrationFlags.FixIntrinsic)
        {
            return NativeMethods.cvStereoCalibrate(
                objectPoints, imagePoints1, imagePoints2, npoints,
                cameraMatrix1, distCoeffs1, cameraMatrix2, distCoeffs2, imageSize,
                R, T, E ?? CvMat.Null, F ?? CvMat.Null, criteria, flags);
        }

        /// <summary>
        /// Computes rectification transforms for each head of a calibrated stereo camera.
        /// </summary>
        /// <param name="cameraMatrix1">The first camera matrix.</param>
        /// <param name="cameraMatrix2">The second camera matrix.</param>
        /// <param name="distCoeffs1">The input distortion coefficients for the first camera.</param>
        /// <param name="distCoeffs2">The input distortion coefficients for the second camera.</param>
        /// <param name="imageSize">Size of the image used for stereo calibration.</param>
        /// <param name="R">The rotation matrix between the 1st and the 2nd cameras’ coordinate systems.</param>
        /// <param name="T">The translation vector between the cameras’ coordinate systems.</param>
        /// <param name="R1">The output 3x3 rectification transform (rotation matrix) for the first camera.</param>
        /// <param name="R2">The output 3x3 rectification transform (rotation matrix) for the second camera.</param>
        /// <param name="P1">
        /// The output 3x4 projection matrix for the first camera in the new (rectified) coordinate system.
        /// </param>
        /// <param name="P2">
        /// The output 3x4 projection matrix for the second camera in the new (rectified) coordinate system.
        /// </param>
        /// <param name="Q">
        /// The output 4x4 disparity-to-depth mapping matrix, see <see cref="ReprojectImageTo3D"/>.
        /// </param>
        /// <param name="flags">The operation flags.</param>
        /// <param name="alpha">
        /// The free scaling parameter. If it is -1, the function performs some default scaling. Otherwise the parameter
        /// should be between 0 and 1. 0 means that the rectified images will be zoomed and shifted so that only valid
        /// pixels are visible (i.e. there will be no black areas after rectification). 1 means that the rectified image
        /// will be decimated and shifted so that all the pixels from the original images from the cameras are retained
        /// in the rectified images, i.e. no source image pixels are lost.
        /// </param>
        public static void StereoRectify(
            CvMat cameraMatrix1,
            CvMat cameraMatrix2,
            CvMat distCoeffs1,
            CvMat distCoeffs2,
            CvSize imageSize,
            CvMat R,
            CvMat T,
            CvMat R1,
            CvMat R2,
            CvMat P1,
            CvMat P2,
            CvMat Q = null,
            StereoRectificationFlags flags = StereoRectificationFlags.ZeroDisparity,
            double alpha = -1)
        {
            StereoRectify(
                cameraMatrix1, cameraMatrix2, distCoeffs1, distCoeffs2,
                imageSize, R, T, R1, R2, P1, P2, Q, flags, alpha, CvSize.Zero);
        }

        /// <summary>
        /// Computes rectification transforms for each head of a calibrated stereo camera.
        /// </summary>
        /// <param name="cameraMatrix1">The first camera matrix.</param>
        /// <param name="cameraMatrix2">The second camera matrix.</param>
        /// <param name="distCoeffs1">The input distortion coefficients for the first camera.</param>
        /// <param name="distCoeffs2">The input distortion coefficients for the second camera.</param>
        /// <param name="imageSize">Size of the image used for stereo calibration.</param>
        /// <param name="R">The rotation matrix between the 1st and the 2nd cameras’ coordinate systems.</param>
        /// <param name="T">The translation vector between the cameras’ coordinate systems.</param>
        /// <param name="R1">The output 3x3 rectification transform (rotation matrix) for the first camera.</param>
        /// <param name="R2">The output 3x3 rectification transform (rotation matrix) for the second camera.</param>
        /// <param name="P1">
        /// The output 3x4 projection matrix for the first camera in the new (rectified) coordinate system.
        /// </param>
        /// <param name="P2">
        /// The output 3x4 projection matrix for the second camera in the new (rectified) coordinate system.
        /// </param>
        /// <param name="Q">
        /// The output 4x4 disparity-to-depth mapping matrix, see <see cref="ReprojectImageTo3D"/>.
        /// </param>
        /// <param name="flags">The operation flags.</param>
        /// <param name="alpha">
        /// The free scaling parameter. If it is -1, the function performs some default scaling. Otherwise the parameter
        /// should be between 0 and 1. 0 means that the rectified images will be zoomed and shifted so that only valid
        /// pixels are visible (i.e. there will be no black areas after rectification). 1 means that the rectified image
        /// will be decimated and shifted so that all the pixels from the original images from the cameras are retained
        /// in the rectified images, i.e. no source image pixels are lost.
        /// </param>
        /// <param name="newImageSize">
        /// The new image resolution after rectification. By default, i.e. when (0,0) is passed, it is set to the original
        /// <paramref name="imageSize"/>. Setting it to larger value can help you to preserve details in the original image,
        /// especially when there is big radial distortion.
        /// </param>
        public static void StereoRectify(
            CvMat cameraMatrix1,
            CvMat cameraMatrix2,
            CvMat distCoeffs1,
            CvMat distCoeffs2,
            CvSize imageSize,
            CvMat R,
            CvMat T,
            CvMat R1,
            CvMat R2,
            CvMat P1,
            CvMat P2,
            CvMat Q,
            StereoRectificationFlags flags,
            double alpha,
            CvSize newImageSize)
        {
            CvRect validPixROI1;
            StereoRectify(
                cameraMatrix1, cameraMatrix2, distCoeffs1, distCoeffs2,
                imageSize, R, T, R1, R2, P1, P2, Q, flags, alpha,
                newImageSize, out validPixROI1);
        }

        /// <summary>
        /// Computes rectification transforms for each head of a calibrated stereo camera.
        /// </summary>
        /// <param name="cameraMatrix1">The first camera matrix.</param>
        /// <param name="cameraMatrix2">The second camera matrix.</param>
        /// <param name="distCoeffs1">The input distortion coefficients for the first camera.</param>
        /// <param name="distCoeffs2">The input distortion coefficients for the second camera.</param>
        /// <param name="imageSize">Size of the image used for stereo calibration.</param>
        /// <param name="R">The rotation matrix between the 1st and the 2nd cameras’ coordinate systems.</param>
        /// <param name="T">The translation vector between the cameras’ coordinate systems.</param>
        /// <param name="R1">The output 3x3 rectification transform (rotation matrix) for the first camera.</param>
        /// <param name="R2">The output 3x3 rectification transform (rotation matrix) for the second camera.</param>
        /// <param name="P1">
        /// The output 3x4 projection matrix for the first camera in the new (rectified) coordinate system.
        /// </param>
        /// <param name="P2">
        /// The output 3x4 projection matrix for the second camera in the new (rectified) coordinate system.
        /// </param>
        /// <param name="Q">
        /// The output 4x4 disparity-to-depth mapping matrix, see <see cref="ReprojectImageTo3D"/>.
        /// </param>
        /// <param name="flags">The operation flags.</param>
        /// <param name="alpha">
        /// The free scaling parameter. If it is -1, the function performs some default scaling. Otherwise the parameter
        /// should be between 0 and 1. 0 means that the rectified images will be zoomed and shifted so that only valid
        /// pixels are visible (i.e. there will be no black areas after rectification). 1 means that the rectified image
        /// will be decimated and shifted so that all the pixels from the original images from the cameras are retained
        /// in the rectified images, i.e. no source image pixels are lost.
        /// </param>
        /// <param name="newImageSize">
        /// The new image resolution after rectification. By default, i.e. when (0,0) is passed, it is set to the original
        /// <paramref name="imageSize"/>. Setting it to larger value can help you to preserve details in the original image,
        /// especially when there is big radial distortion.
        /// </param>
        /// <param name="validPixelROI1">
        /// The optional output rectangle inside the rectified first camera image where all the pixels are valid.
        /// </param>
        public static void StereoRectify(
            CvMat cameraMatrix1,
            CvMat cameraMatrix2,
            CvMat distCoeffs1,
            CvMat distCoeffs2,
            CvSize imageSize,
            CvMat R,
            CvMat T,
            CvMat R1,
            CvMat R2,
            CvMat P1,
            CvMat P2,
            CvMat Q,
            StereoRectificationFlags flags,
            double alpha,
            CvSize newImageSize,
            out CvRect validPixelROI1)
        {
            CvRect validPixROI2;
            StereoRectify(
                cameraMatrix1, cameraMatrix2, distCoeffs1, distCoeffs2,
                imageSize, R, T, R1, R2, P1, P2, Q, flags, alpha,
                newImageSize, out validPixelROI1, out validPixROI2);
        }

        /// <summary>
        /// Computes rectification transforms for each head of a calibrated stereo camera.
        /// </summary>
        /// <param name="cameraMatrix1">The first camera matrix.</param>
        /// <param name="cameraMatrix2">The second camera matrix.</param>
        /// <param name="distCoeffs1">The input distortion coefficients for the first camera.</param>
        /// <param name="distCoeffs2">The input distortion coefficients for the second camera.</param>
        /// <param name="imageSize">Size of the image used for stereo calibration.</param>
        /// <param name="R">The rotation matrix between the 1st and the 2nd cameras’ coordinate systems.</param>
        /// <param name="T">The translation vector between the cameras’ coordinate systems.</param>
        /// <param name="R1">The output 3x3 rectification transform (rotation matrix) for the first camera.</param>
        /// <param name="R2">The output 3x3 rectification transform (rotation matrix) for the second camera.</param>
        /// <param name="P1">
        /// The output 3x4 projection matrix for the first camera in the new (rectified) coordinate system.
        /// </param>
        /// <param name="P2">
        /// The output 3x4 projection matrix for the second camera in the new (rectified) coordinate system.
        /// </param>
        /// <param name="Q">
        /// The output 4x4 disparity-to-depth mapping matrix, see <see cref="ReprojectImageTo3D"/>.
        /// </param>
        /// <param name="flags">The operation flags.</param>
        /// <param name="alpha">
        /// The free scaling parameter. If it is -1, the function performs some default scaling. Otherwise the parameter
        /// should be between 0 and 1. 0 means that the rectified images will be zoomed and shifted so that only valid
        /// pixels are visible (i.e. there will be no black areas after rectification). 1 means that the rectified image
        /// will be decimated and shifted so that all the pixels from the original images from the cameras are retained
        /// in the rectified images, i.e. no source image pixels are lost.
        /// </param>
        /// <param name="newImageSize">
        /// The new image resolution after rectification. By default, i.e. when (0,0) is passed, it is set to the original
        /// <paramref name="imageSize"/>. Setting it to larger value can help you to preserve details in the original image,
        /// especially when there is big radial distortion.
        /// </param>
        /// <param name="validPixelROI1">
        /// The optional output rectangle inside the rectified first camera image where all the pixels are valid.
        /// </param>
        /// <param name="validPixelROI2">
        /// The optional output rectangle inside the rectified second camera image where all the pixels are valid.
        /// </param>
        public static void StereoRectify(
            CvMat cameraMatrix1,
            CvMat cameraMatrix2,
            CvMat distCoeffs1,
            CvMat distCoeffs2,
            CvSize imageSize,
            CvMat R,
            CvMat T,
            CvMat R1,
            CvMat R2,
            CvMat P1,
            CvMat P2,
            CvMat Q,
            StereoRectificationFlags flags,
            double alpha,
            CvSize newImageSize,
            out CvRect validPixelROI1,
            out CvRect validPixelROI2)
        {
            NativeMethods.cvStereoRectify(
                cameraMatrix1, cameraMatrix2, distCoeffs1, distCoeffs2,
                imageSize, R, T, R1, R2, P1, P2, Q ?? CvMat.Null, flags, alpha,
                newImageSize, out validPixelROI1, out validPixelROI2);
        }

        /// <summary>
        /// Computes rectification transform for uncalibrated stereo camera.
        /// </summary>
        /// <param name="points1">
        /// Array of N points from the first image.It can be 2xN, Nx2, 3xN or Nx3 1-channel array or
        /// 1xN or Nx1 2- or 3-channel array. The point coordinates should be floating-point
        /// (single or double precision).
        /// </param>
        /// <param name="points2">
        /// Array of the second image points of the same size and format as <paramref name="points1"/>.
        /// </param>
        /// <param name="F">
        /// The input fundamental matrix. It can be computed from the same set of point pairs using
        /// <see cref="FindFundamentalMat"/>.
        /// </param>
        /// <param name="imageSize">Size of the image.</param>
        /// <param name="H1">The output rectification homography matrix for the first camera.</param>
        /// <param name="H2">The output rectification homography matrix for the second camera.</param>
        /// <param name="threshold">
        /// The optional threshold used to filter out the outliers. If the parameter is greater than zero,
        /// then all the point pairs that do not comply the epipolar geometry well enough are rejected
        /// prior to computing the homographies. Otherwise, all the points are considered inliers.
        /// </param>
        /// <returns>A value indicating whether the rectification transform was computed successfully.</returns>
        public static bool StereoRectifyUncalibrated(
            CvMat points1,
            CvMat points2,
            CvMat F,
            CvSize imageSize,
            CvMat H1,
            CvMat H2,
            double threshold = 5)
        {
            return NativeMethods.cvStereoRectifyUncalibrated(points1, points2, F, imageSize, H1, H2, threshold) > 0;
        }

        /// <summary>
        /// Reprojects disparity image to 3D space.
        /// </summary>
        /// <param name="disparityImage">
        /// The input single-channel 16-bit signed or 32-bit floating-point disparity image.
        /// </param>    
        /// <param name="image3d">
        /// The output 3-channel floating-point image of the same size as disparity . Each
        /// element of image3d(x,y) will contain the 3D coordinates of the point (x,y),
        /// computed from the disparity map.
        /// </param>
        /// <param name="Q">
        /// The 4x4 perspective transformation matrix that can be obtained with
        /// <see cref="StereoRectify(CvMat,CvMat,CvMat,CvMat,CvSize,CvMat,CvMat,CvMat,CvMat,CvMat,CvMat,CvMat,StereoRectificationFlags,double)"/>.
        /// </param>
        /// <param name="handleMissingValues">
        /// If <b>true</b>, the pixels with the minimal disparity (which correspond to the
        /// outliers; see <see cref="CvStereoBMState.FindStereoCorrespondence"/>) will be
        /// transformed to 3D points with some very large Z value (currently set to 10000).
        /// </param>
        public static void ReprojectImageTo3D(
            CvArr disparityImage,
            CvArr image3d,
            CvMat Q,
            bool handleMissingValues)
        {
            NativeMethods.cvReprojectImageTo3D(disparityImage, image3d, Q, handleMissingValues ? 1 : 0);
        }

        #endregion
    }
}
