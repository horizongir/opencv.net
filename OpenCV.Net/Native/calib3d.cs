using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net.Native
{
    static partial class NativeMethods
    {
        const string calib3dLib = "opencv_calib3d246";

        #region Camera Calibration, Pose Estimation and Stereo

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCreatePOSITObject(CvPoint3D32f[] points, int point_count);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvPOSIT(
            CvPOSITObject posit_object,
            CvPoint2D32f[] image_points,
            double focal_length,
            CvTermCriteria criteria,
            [Out]float[] rotation_matrix,
            [Out]float[] translation_vector);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvReleasePOSITObject(ref IntPtr posit_object);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvRANSACUpdateNumIters(double p, double err_prob, int model_points, int max_iters);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvConvertPointsHomogeneous(CvMat src, CvMat dst);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvFindFundamentalMat(
            CvMat points1,
            CvMat points2,
            CvMat fundamental_matrix,
            FundamentalMatrixMethod method,
            double param1,
            double param2,
            CvMat status);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvComputeCorrespondEpilines(
            CvMat points,
            int which_image,
            CvMat fundamental_matrix,
            CvMat correspondent_lines);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvTriangulatePoints(
            CvMat projMatr1,
            CvMat projMatr2,
            CvMat projPoints1,
            CvMat projPoints2,
            CvMat points4D);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCorrectMatches(
            CvMat F,
            CvMat points1,
            CvMat points2,
            CvMat new_points1,
            CvMat new_points2);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvGetOptimalNewCameraMatrix(
            CvMat camera_matrix,
            CvMat dist_coeffs,
            CvSize image_size,
            double alpha,
            CvMat new_camera_matrix,
            CvSize new_imag_size,
            out CvRect valid_pixel_ROI,
            int center_principal_point);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvRodrigues2(CvMat src, CvMat dst, CvMat jacobian);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvFindHomography(
            CvMat src_points,
            CvMat dst_points,
            CvMat homography,
            FindHomographyMethod method,
            double ransacReprojThreshold,
            CvMat mask);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvRQDecomp3x3(
            CvMat matrixM,
            CvMat matrixR,
            CvMat matrixQ,
            CvMat matrixQx,
            CvMat matrixQy,
            CvMat matrixQz,
            [Out]CvPoint3D64f[] eulerAngles);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvDecomposeProjectionMatrix(
            CvMat projMatr,
            CvMat calibMatr,
            CvMat rotMatr,
            CvMat posVect,
            CvMat rotMatrX,
            CvMat rotMatrY,
            CvMat rotMatrZ,
            [Out]CvPoint3D64f[] eulerAngles);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCalcMatMulDeriv(CvMat A, CvMat B, CvMat dABdA, CvMat dABdB);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvComposeRT(
            CvMat _rvec1,
            CvMat _tvec1,
            CvMat _rvec2,
            CvMat _tvec2,
            CvMat _rvec3,
            CvMat _tvec3,
            CvMat dr3dr1,
            CvMat dr3dt1,
            CvMat dr3dr2,
            CvMat dr3dt2,
            CvMat dt3dr1,
            CvMat dt3dt1,
            CvMat dt3dr2,
            CvMat dt3dt2);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvProjectPoints2(
            CvMat object_points,
            CvMat rotation_vector,
            CvMat translation_vector,
            CvMat camera_matrix,
            CvMat distortion_coeffs,
            CvMat image_points,
            CvMat dpdrot,
            CvMat dpdt,
            CvMat dpdf,
            CvMat dpdc,
            CvMat dpddist,
            double aspect_ratio);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvFindExtrinsicCameraParams2(
            CvMat object_points,
            CvMat image_points,
            CvMat camera_matrix,
            CvMat distortion_coeffs,
            CvMat rotation_vector,
            CvMat translation_vector,
            int use_extrinsic_guess);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvInitIntrinsicParams2D(
            CvMat object_points,
            CvMat image_points,
            CvMat npoints,
            CvSize image_size,
            CvMat camera_matrix,
            double aspect_ratio);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvCheckChessboard(IplImage src, CvSize size);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvFindChessboardCorners(
            CvArr image,
            CvSize pattern_size,
            [Out]CvPoint2D32f[] corners,
            out int corner_count,
            ChessboardCalibrationFlags flags);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvDrawChessboardCorners(
            CvArr image,
            CvSize pattern_size,
            CvPoint2D32f[] corners,
            int count,
            int pattern_was_found);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvCalibrateCamera2(
            CvMat object_points,
            CvMat image_points,
            CvMat point_counts,
            CvSize image_size,
            CvMat camera_matrix,
            CvMat distortion_coeffs,
            CvMat rotation_vectors,
            CvMat translation_vectors,
            CameraCalibrationFlags flags,
            CvTermCriteria term_crit);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCalibrationMatrixValues(
            CvMat camera_matrix,
            CvSize image_size,
            double aperture_width,
            double aperture_height,
            out double fovx,
            out double fovy,
            out double focal_length,
            out CvPoint2D64f principal_point,
            out double pixel_aspect_ratio);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvStereoCalibrate(
            CvMat object_points,
            CvMat image_points1,
            CvMat image_points2,
            CvMat npoints,
            CvMat camera_matrix1,
            CvMat dist_coeffs1,
            CvMat camera_matrix2,
            CvMat dist_coeffs2,
            CvSize image_size,
            CvMat R,
            CvMat T,
            CvMat E,
            CvMat F,
            CvTermCriteria term_crit,
            StereoCalibrationFlags flags);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvStereoRectify(
            CvMat camera_matrix1,
            CvMat camera_matrix2,
            CvMat dist_coeffs1,
            CvMat dist_coeffs2,
            CvSize image_size,
            CvMat R,
            CvMat T,
            CvMat R1,
            CvMat R2,
            CvMat P1,
            CvMat P2,
            CvMat Q,
            StereoRectificationFlags flags,
            double alpha,
            CvSize new_image_size,
            out CvRect valid_pix_ROI1,
            out CvRect valid_pix_ROI2);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvStereoRectifyUncalibrated(
            CvMat points1,
            CvMat points2,
            CvMat F,
            CvSize img_size,
            CvMat H1,
            CvMat H2,
            double threshold);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCreateStereoBMState(StereoBMPreset preset, int numberOfDisparities);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvReleaseStereoBMState(ref IntPtr state);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvFindStereoCorrespondenceBM(CvArr left, CvArr right, CvArr disparity, CvStereoBMState state);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CvRect cvGetValidDisparityROI(
            CvRect roi1,
            CvRect roi2,
            int minDisparity,
            int numberOfDisparities,
            int SADWindowSize);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvValidateDisparity(
            CvArr disparity,
            CvArr cost,
            int minDisparity,
            int numberOfDisparities,
            int disp12MaxDiff);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvReprojectImageTo3D(
            CvArr disparityImage,
            CvArr _3dImage,
            CvMat Q,
            int handleMissingValues);

        #endregion
    }
}
