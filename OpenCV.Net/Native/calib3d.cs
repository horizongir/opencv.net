using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net.Native
{
    static partial class NativeMethods
    {
        const string calib3dLib = "opencv_calib3d247";

        #region Camera Calibration, Pose Estimation and Stereo

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCreatePOSITObject(Point3f[] points, int point_count);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvPOSIT(
            PositObject posit_object,
            Point2f[] image_points,
            double focal_length,
            TermCriteria criteria,
            [Out]float[] rotation_matrix,
            [Out]float[] translation_vector);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvReleasePOSITObject(ref IntPtr posit_object);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvRANSACUpdateNumIters(double p, double err_prob, int model_points, int max_iters);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvConvertPointsHomogeneous(Mat src, Mat dst);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvFindFundamentalMat(
            Mat points1,
            Mat points2,
            Mat fundamental_matrix,
            FundamentalMatrixMethod method,
            double param1,
            double param2,
            Mat status);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvComputeCorrespondEpilines(
            Mat points,
            int which_image,
            Mat fundamental_matrix,
            Mat correspondent_lines);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvTriangulatePoints(
            Mat projMatr1,
            Mat projMatr2,
            Mat projPoints1,
            Mat projPoints2,
            Mat points4D);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCorrectMatches(
            Mat F,
            Mat points1,
            Mat points2,
            Mat new_points1,
            Mat new_points2);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvGetOptimalNewCameraMatrix(
            Mat camera_matrix,
            Mat dist_coeffs,
            Size image_size,
            double alpha,
            Mat new_camera_matrix,
            Size new_imag_size,
            out Rect valid_pixel_ROI,
            int center_principal_point);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvRodrigues2(Mat src, Mat dst, Mat jacobian);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvFindHomography(
            Mat src_points,
            Mat dst_points,
            Mat homography,
            FindHomographyMethod method,
            double ransacReprojThreshold,
            Mat mask);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvRQDecomp3x3(
            Mat matrixM,
            Mat matrixR,
            Mat matrixQ,
            Mat matrixQx,
            Mat matrixQy,
            Mat matrixQz,
            [Out]Point3d[] eulerAngles);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvDecomposeProjectionMatrix(
            Mat projMatr,
            Mat calibMatr,
            Mat rotMatr,
            Mat posVect,
            Mat rotMatrX,
            Mat rotMatrY,
            Mat rotMatrZ,
            [Out]Point3d[] eulerAngles);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCalcMatMulDeriv(Mat A, Mat B, Mat dABdA, Mat dABdB);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvComposeRT(
            Mat _rvec1,
            Mat _tvec1,
            Mat _rvec2,
            Mat _tvec2,
            Mat _rvec3,
            Mat _tvec3,
            Mat dr3dr1,
            Mat dr3dt1,
            Mat dr3dr2,
            Mat dr3dt2,
            Mat dt3dr1,
            Mat dt3dt1,
            Mat dt3dr2,
            Mat dt3dt2);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvProjectPoints2(
            Mat object_points,
            Mat rotation_vector,
            Mat translation_vector,
            Mat camera_matrix,
            Mat distortion_coeffs,
            Mat image_points,
            Mat dpdrot,
            Mat dpdt,
            Mat dpdf,
            Mat dpdc,
            Mat dpddist,
            double aspect_ratio);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvFindExtrinsicCameraParams2(
            Mat object_points,
            Mat image_points,
            Mat camera_matrix,
            Mat distortion_coeffs,
            Mat rotation_vector,
            Mat translation_vector,
            int use_extrinsic_guess);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvInitIntrinsicParams2D(
            Mat object_points,
            Mat image_points,
            Mat npoints,
            Size image_size,
            Mat camera_matrix,
            double aspect_ratio);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvCheckChessboard(IplImage src, Size size);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvFindChessboardCorners(
            Arr image,
            Size pattern_size,
            [Out]Point2f[] corners,
            out int corner_count,
            ChessboardCalibrationFlags flags);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvDrawChessboardCorners(
            Arr image,
            Size pattern_size,
            Point2f[] corners,
            int count,
            int pattern_was_found);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvCalibrateCamera2(
            Mat object_points,
            Mat image_points,
            Mat point_counts,
            Size image_size,
            Mat camera_matrix,
            Mat distortion_coeffs,
            Mat rotation_vectors,
            Mat translation_vectors,
            CameraCalibrationFlags flags,
            TermCriteria term_crit);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCalibrationMatrixValues(
            Mat camera_matrix,
            Size image_size,
            double aperture_width,
            double aperture_height,
            out double fovx,
            out double fovy,
            out double focal_length,
            out Point2d principal_point,
            out double pixel_aspect_ratio);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvStereoCalibrate(
            Mat object_points,
            Mat image_points1,
            Mat image_points2,
            Mat npoints,
            Mat camera_matrix1,
            Mat dist_coeffs1,
            Mat camera_matrix2,
            Mat dist_coeffs2,
            Size image_size,
            Mat R,
            Mat T,
            Mat E,
            Mat F,
            TermCriteria term_crit,
            StereoCalibrationFlags flags);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvStereoRectify(
            Mat camera_matrix1,
            Mat camera_matrix2,
            Mat dist_coeffs1,
            Mat dist_coeffs2,
            Size image_size,
            Mat R,
            Mat T,
            Mat R1,
            Mat R2,
            Mat P1,
            Mat P2,
            Mat Q,
            StereoRectificationFlags flags,
            double alpha,
            Size new_image_size,
            out Rect valid_pix_ROI1,
            out Rect valid_pix_ROI2);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvStereoRectifyUncalibrated(
            Mat points1,
            Mat points2,
            Mat F,
            Size img_size,
            Mat H1,
            Mat H2,
            double threshold);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCreateStereoBMState(StereoBMPreset preset, int numberOfDisparities);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvReleaseStereoBMState(ref IntPtr state);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvFindStereoCorrespondenceBM(Arr left, Arr right, Arr disparity, StereoBM state);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Rect cvGetValidDisparityROI(
            Rect roi1,
            Rect roi2,
            int minDisparity,
            int numberOfDisparities,
            int SADWindowSize);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvValidateDisparity(
            Arr disparity,
            Arr cost,
            int minDisparity,
            int numberOfDisparities,
            int disp12MaxDiff);

        [DllImport(calib3dLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvReprojectImageTo3D(
            Arr disparityImage,
            Arr _3dImage,
            Mat Q,
            int handleMissingValues);

        #endregion
    }
}
