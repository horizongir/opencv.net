using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OpenCV.Net
{
    public static class Calib3D
    {
        const string libName = "opencv_calib3d231";

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvFindChessboardCorners(CvArr image, CvSize patternSize, CvPoint2D32f[] corners, out int cornerCount, ChessboardCalibrationFlags flags);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvFindExtrinsicCameraParams2(
            CvMat object_points,
            CvMat image_points,
            CvMat camera_matrix,
            CvMat distortion_coeffs,
            CvMat rotation_vector,
            CvMat translation_vector,
            int use_extrinsic_guess);

        public static int cvRodrigues2(CvMat src, CvMat dst)
        {
            return cvRodrigues2(src, dst, CvMat.Null);
        }

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvRodrigues2(CvMat src, CvMat dst, CvMat jacobian);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvUndistort2(CvArr src, CvArr dst, CvMat cameraMatrix, CvMat distCoeffs, CvMat newCameraMatrix);
    }
}
