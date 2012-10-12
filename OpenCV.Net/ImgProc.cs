using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using OpenCV.Net.Native;

namespace OpenCV.Net
{
    public static class ImgProc
    {
        const string libName = "opencv_imgproc242";

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvGetRectSubPix(CvArr src, CvArr dst, CvPoint2D32f center);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvGetQuadrangleSubPix(CvArr src, CvArr dst, CvMat map_matrix);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvMat cvGetPerspectiveTransform(CvPoint2D32f[] src, CvPoint2D32f[] dst, CvMat map_matrix);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvWarpPerspective(CvArr src, CvArr dst, CvMat map_matrix, WarpFlags flags, CvScalar fillval);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvUndistort2(CvArr src, CvArr dst, CvMat camera_matrix, CvMat distortion_coeffs, CvMat new_camera_matrix);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvAcc(CvArr image, CvArr sum, CvArr mask);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvRunningAvg(CvArr image, CvArr acc, double alpha, CvArr mask);

        public static void cvCalcBackProject(IplImage[] images, CvArr back_project, CvHistogram hist)
        {
            var pImages = new IntPtr[images.Length];
            for (int i = 0; i < images.Length; i++)
            {
                pImages[i] = images[i].DangerousGetHandle();
            }

            imgproc.cvCalcArrBackProject(pImages, back_project, hist);
        }

        public static void cvCalcHist(IplImage[] images, CvHistogram hist)
        {
            cvCalcHist(images, hist, 0, CvArr.Null);
        }

        public static void cvCalcHist(IplImage[] images, CvHistogram hist, int accumulate, CvArr mask)
        {
            var pImages = new IntPtr[images.Length];
            for (int i = 0; i < images.Length; i++)
            {
                pImages[i] = images[i].DangerousGetHandle();
            }

            imgproc.cvCalcArrHist(pImages, hist, accumulate, mask);
        }

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvDilate(CvArr src, CvArr dst, IplConvKernel element, int iterations);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvErode(CvArr src, CvArr dst, IplConvKernel element, int iterations);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvEqualizeHist(CvArr src, CvArr dst);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvAdaptiveThreshold(CvArr src, CvArr dst, double maxValue,
                          AdaptiveThresholdMethod adaptiveMethod, ThresholdType thresholdType,
                          int blockSize, double param1 );

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvThreshold(CvArr src, CvArr dst, double threshold, double maxValue, ThresholdType thresholdType);

        /* Copies source 2D array inside of the larger destination array and
         * makes a border of the specified type (IPL_BORDER_*) around the copied area. */
        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCopyMakeBorder(CvArr src, CvArr dst, CvPoint offset, BorderType bordertype, CvScalar value);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSmooth(
            CvArr src,
            CvArr dst,
            SmoothMethod smoothtype, // CV_DEFAULT(CV_GAUSSIAN),
            int size1, // CV_DEFAULT(3),
            int size2, // CV_DEFAULT(0),
            double sigma1, // CV_DEFAULT(0),
            double sigma2); // CV_DEFAULT(0);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCvtColor(CvArr src, CvArr dst, ColorConversion code);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSobel(CvArr src, CvArr dst, int xorder, int yorder, int aperture_size);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvResize(CvArr src, CvArr dst, SubPixelInterpolation interpolation);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCanny(CvArr image, CvArr edges, double threshold1, double threshold2, int aperture_size);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvFindCornerSubPix(CvArr image, CvPoint2D32f[] corners, int count, CvSize win, CvSize zero_zone, CvTermCriteria criteria);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvGoodFeaturesToTrack(
            CvArr image,
            CvArr eig_image,
            CvArr temp_image,
            [Out]CvPoint2D32f[] corners,
            ref int corner_count,
            double quality_level,
            double min_distance,
            CvArr mask, // CV_DEFAULT(NULL),
            int block_size, // CV_DEFAULT(3),
            int use_harris, // CV_DEFAULT(0),
            double k); // CV_DEFAULT(0.04);

        public static CvSeq cvHoughCircles(
            CvArr image,
            CvMemStorage circle_storage,
            HoughTransformMethod method,
            double dp,
            double min_dist,
            double param1,// CV_DEFAULT(100),
            double param2, // CV_DEFAULT(100),
            int min_radius, // CV_DEFAULT(0),
            int max_radius) // CV_DEFAULT(0));
        {
            var result = imgproc.cvHoughCircles(image, circle_storage, method, dp, min_dist, param1, param2, min_radius, max_radius);
            result.SetOwnerStorage(circle_storage);
            return result;
        }

        public static void cvHoughCircles(
            CvArr image,
            CvArr circle_storage,
            HoughTransformMethod method,
            double dp,
            double min_dist,
            double param1,// CV_DEFAULT(100),
            double param2, // CV_DEFAULT(100),
            int min_radius, // CV_DEFAULT(0),
            int max_radius) // CV_DEFAULT(0));
        {
            imgproc.cvHoughCircles(image, circle_storage, method, dp, min_dist, param1, param2, min_radius, max_radius);
        }

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvMoments(SafeHandle arr, out CvMoments moments, int binary);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvFloodFill(
            CvArr image,
            CvPoint seed_point,
            CvScalar new_val,
            CvScalar lo_diff, //=cvScalarAll(0)
            CvScalar up_diff, //=cvScalarAll(0)
            ref CvConnectedComp comp, //=NULL
            int flags, // = 4
            CvArr mask); // = null

        public static CvSeq cvApproxPoly(
            CvSeq src_seq,
            int header_size,
            CvMemStorage storage,
            PolygonApproximation method,
            double eps,
            int recursive)
        {
            var poly = imgproc.cvApproxPoly(src_seq, header_size, storage, method, eps, recursive);
            poly.SetOwnerStorage(storage);
            return poly;
        }

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvRect cvBoundingRect(SafeHandle points, int update);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvMinEnclosingCircle(SafeHandle points, out CvPoint2D32f center, out float radius);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvBox2D cvFitEllipse2(SafeHandle points);

        public static int cvFindContours(
            CvArr image,
            CvMemStorage storage,
            out CvSeq first_contour,
            int header_size, //=sizeof(CvContour),
            ContourRetrieval mode, //=CV_RETR_LIST,
            ContourApproximation method, //=CV_CHAIN_APPROX_SIMPLE,
            CvPoint offset) //=cvPoint(0, 0)
        {
            var result = imgproc.cvFindContours(image, storage, out first_contour, header_size, mode, method, offset);
            first_contour.SetOwnerStorage(storage);
            return result;
        }

        public static CvContourScanner cvStartFindContours(
            CvArr image,
            CvMemStorage storage,
            int header_size, //=sizeof(CvContour),
            ContourRetrieval mode, //=CV_RETR_LIST,
            ContourApproximation method, //=CV_CHAIN_APPROX_SIMPLE,
            CvPoint offset) //=cvPoint(0, 0)
        {
            var scanner = imgproc.cvStartFindContours(image, storage, header_size, mode, method, offset);
            scanner.SetOwnerStorage(storage);
            return scanner;
        }

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvContourArea(CvSeq contour, CvSlice slice, int oriented);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvPointPolygonTest(SafeHandle contour, CvPoint2D32f pt, int measure_dist);
    }
}
