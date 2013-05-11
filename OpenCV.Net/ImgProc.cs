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
        const string libName = "opencv_imgproc244";

        #region Background statistics accumulation

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvAcc(CvArr image, CvArr sum, CvArr mask);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSquareAcc(CvArr image, CvArr sqsum, CvArr mask);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvMultiplyAcc(CvArr image1, CvArr image2, CvArr acc, CvArr mask);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvRunningAvg(CvArr image, CvArr acc, double alpha, CvArr mask);

        #endregion

        #region Image Processing

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

        public static void cvFilter2D(CvArr src, CvArr dst, CvMat kernel)
        {
            cvFilter2D(src, dst, kernel, new CvPoint(-1, -1));
        }

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvFilter2D(CvArr src, CvArr dst, CvMat kernel, CvPoint anchor);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvIntegral(CvArr image, CvArr sum, CvArr sqsum, CvArr tilted_sum);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvPyrDown(CvArr src, CvArr dst, PyramidDecompositionFilter filter);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvPyrUp(CvArr src, CvArr dst, PyramidDecompositionFilter filter);

        public static CvMat[] cvCreatePyramid(
            CvArr img,
            int extra_layers,
            double rate,
            CvSize[] layer_sizes,
            CvArr bufarr,
            int calc,
            PyramidDecompositionFilter filter)
        {
            var handles = new IntPtr[extra_layers + 1];
            var pyramid = imgproc.cvCreatePyramid(img, extra_layers, rate, layer_sizes, bufarr, calc, filter);
            Marshal.Copy(pyramid, handles, 0, handles.Length);
            return Array.ConvertAll(handles, handle => new CvMat(handle));
        }

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvPyrMeanShiftFiltering(CvArr src, CvArr dst, double sp, double sr, int max_level, CvTermCriteria termcrit);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvWatershed(CvArr image, CvArr markers);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSobel(CvArr src, CvArr dst, int xorder, int yorder, int aperture_size);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvLaplace(CvArr src, CvArr dst, int aperture_size);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCvtColor(CvArr src, CvArr dst, ColorConversion code);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvResize(CvArr src, CvArr dst, SubPixelInterpolation interpolation);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvWarpAffine(CvArr src, CvArr dst, CvMat map_matrix, WarpFlags flags, CvScalar fillval);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvMat cvGetAffineTransform(CvPoint2D32f[] src, CvPoint2D32f[] dst, CvMat map_matrix);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvMat cv2DRotationMatrix(CvPoint2D32f center, double angle, double scale, CvMat map_matrix);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvWarpPerspective(CvArr src, CvArr dst, CvMat map_matrix, WarpFlags flags, CvScalar fillval);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvMat cvGetPerspectiveTransform(CvPoint2D32f[] src, CvPoint2D32f[] dst, CvMat map_matrix);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvRemap(CvArr src, CvArr dst, CvArr mapx, CvArr mapy, WarpFlags flags, CvScalar fillval);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvConvertMaps(CvArr mapx, CvArr mapy, CvArr mapxy, CvArr mapalpha);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvLogPolar(CvArr src, CvArr dst, CvPoint2D32f center, double M, WarpFlags flags);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvLinearPolar(CvArr src, CvArr dst, CvPoint2D32f center, double maxRadius, WarpFlags flags);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvUndistort2(CvArr src, CvArr dst, CvMat camera_matrix, CvMat distortion_coeffs, CvMat new_camera_matrix);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvInitUndistortMap(CvMat camera_matrix, CvMat distortion_coeffs, CvArr mapx, CvArr mapy);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvInitUndistortRectifyMap(
            CvMat camera_matrix,
            CvMat dist_coeffs,
            CvMat R,
            CvMat new_camera_matrix,
            CvArr mapx,
            CvArr mapy);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvUndistortPoints(
            CvMat src,
            CvMat dst,
            CvMat camera_matrix,
            CvMat dist_coeffs,
            CvMat R,
            CvMat P);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvErode(CvArr src, CvArr dst, IplConvKernel element, int iterations);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvDilate(CvArr src, CvArr dst, IplConvKernel element, int iterations);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvMorphologyEx(
            CvArr src,
            CvArr dst,
            CvArr temp,
            IplConvKernel element,
            MorphologicalOperation operation,
            int iterations);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvMoments(SafeHandle arr, out CvMoments moments, int binary);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvGetSpatialMoment(ref CvMoments moments, int x_order, int y_order);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvGetCentralMoment(ref CvMoments moments, int x_order, int y_order);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvGetNormalizedCentralMoment(ref CvMoments moments, int x_order, int y_order);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvGetHuMoments(ref CvMoments moments, out CvHuMoments hu_moments);

        #endregion

        #region Data Sampling

        public static int cvSampleLine<TElement>(CvArr image, CvPoint pt1, CvPoint pt2, TElement[] buffer, int connectivity) where TElement : struct
        {
            var bufferHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            try
            {
                return imgproc.cvSampleLine(image, pt1, pt2, bufferHandle.AddrOfPinnedObject(), connectivity);
            }
            finally { bufferHandle.Free(); }
        }

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvGetRectSubPix(CvArr src, CvArr dst, CvPoint2D32f center);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvGetQuadrangleSubPix(CvArr src, CvArr dst, CvMat map_matrix);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvMatchTemplate(CvArr image, CvArr templ, CvArr result, TemplateMatchingMethod method);

        #endregion

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
        public static extern void cvEqualizeHist(CvArr src, CvArr dst);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvAdaptiveThreshold(CvArr src, CvArr dst, double maxValue,
                          AdaptiveThresholdMethod adaptiveMethod, ThresholdType thresholdType,
                          int blockSize, double param1 );

        /* Applies distance transform to binary image */
        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvDistTransform(
            CvArr src,
            CvArr dst,
            DistanceType distance_type, // CV_DEFAULT(CV_DIST_L2),
            int mask_size, // CV_DEFAULT(3),
            float[] mask, // CV_DEFAULT(NULL),
            CvArr labels, // CV_DEFAULT(NULL),
            DistanceLabel labelType); // CV_DEFAULT(CV_DIST_LABEL_CCOMP));

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvThreshold(CvArr src, CvArr dst, double threshold, double maxValue, ThresholdType thresholdType);

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

        /* Calculates exact convex hull of 2d point set */
        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSeq cvConvexHull2(SafeHandle input, SafeHandle hull_storage, ShapeOrientation orientation, int return_points);

        /* Finds convexity defects for the contour */
        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSeq cvConvexityDefects(SafeHandle contour, SafeHandle convexhull, CvMemStorage storage);

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
