using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net.Native
{
    static partial class NativeMethods
    {
        const string imgprocLib = "opencv_imgproc246";

        #region Background statistics accumulation

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvAcc(CvArr image, CvArr sum, CvArr mask);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSquareAcc(CvArr image, CvArr sqsum, CvArr mask);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvMultiplyAcc(CvArr image1, CvArr image2, CvArr acc, CvArr mask);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvRunningAvg(CvArr image, CvArr acc, double alpha, CvArr mask);

        #endregion

        #region Image Processing

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCopyMakeBorder(CvArr src, CvArr dst, CvPoint offset, IplBorder bordertype, CvScalar value);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSmooth(
            CvArr src,
            CvArr dst,
            SmoothMethod smoothtype,
            int size1,
            int size2,
            double sigma1,
            double sigma2);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvFilter2D(CvArr src, CvArr dst, CvMat kernel, CvPoint anchor);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvIntegral(CvArr image, CvArr sum, CvArr sqsum, CvArr tilted_sum);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvPyrDown(CvArr src, CvArr dst, PyramidDecompositionFilter filter);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvPyrUp(CvArr src, CvArr dst, PyramidDecompositionFilter filter);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCreatePyramid(
            CvArr img,
            int extra_layers,
            double rate,
            CvSize[] layer_sizes,
            CvArr bufarr,
            int calc,
            PyramidDecompositionFilter filter);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvReleasePyramid(IntPtr pyramid, int extra_layers);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvPyrMeanShiftFiltering(
            CvArr src,
            CvArr dst,
            double sp,
            double sr,
            int max_level,
            CvTermCriteria termcrit);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvWatershed(CvArr image, CvArr markers);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSobel(CvArr src, CvArr dst, int xorder, int yorder, int aperture_size);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvLaplace(CvArr src, CvArr dst, int aperture_size);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCvtColor(CvArr src, CvArr dst, ColorConversion code);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvResize(CvArr src, CvArr dst, SubPixelInterpolation interpolation);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvWarpAffine(CvArr src, CvArr dst, CvMat map_matrix, WarpFlags flags, CvScalar fillval);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CvMat cvGetAffineTransform(CvPoint2D32f[] src, CvPoint2D32f[] dst, CvMat map_matrix);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CvMat cv2DRotationMatrix(CvPoint2D32f center, double angle, double scale, CvMat map_matrix);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvWarpPerspective(CvArr src, CvArr dst, CvMat map_matrix, WarpFlags flags, CvScalar fillval);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CvMat cvGetPerspectiveTransform(CvPoint2D32f[] src, CvPoint2D32f[] dst, CvMat map_matrix);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvRemap(CvArr src, CvArr dst, CvArr mapx, CvArr mapy, WarpFlags flags, CvScalar fillval);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvConvertMaps(CvArr mapx, CvArr mapy, CvArr mapxy, CvArr mapalpha);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvLogPolar(CvArr src, CvArr dst, CvPoint2D32f center, double M, WarpFlags flags);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvLinearPolar(CvArr src, CvArr dst, CvPoint2D32f center, double maxRadius, WarpFlags flags);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvUndistort2(CvArr src, CvArr dst, CvMat camera_matrix, CvMat distortion_coeffs, CvMat new_camera_matrix);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvInitUndistortMap(CvMat camera_matrix, CvMat distortion_coeffs, CvArr mapx, CvArr mapy);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvInitUndistortRectifyMap(
            CvMat camera_matrix,
            CvMat dist_coeffs,
            CvMat R,
            CvMat new_camera_matrix,
            CvArr mapx,
            CvArr mapy);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvUndistortPoints(
            CvMat src,
            CvMat dst,
            CvMat camera_matrix,
            CvMat dist_coeffs,
            CvMat R,
            CvMat P);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCreateStructuringElementEx(
            int cols,
            int rows,
            int anchor_x,
            int anchor_y,
            StructuringElementShape shape,
            int[] values);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvReleaseStructuringElement(ref IntPtr element);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvErode(CvArr src, CvArr dst, IplConvKernel element, int iterations);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvDilate(CvArr src, CvArr dst, IplConvKernel element, int iterations);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvMorphologyEx(
            CvArr src,
            CvArr dst,
            CvArr temp,
            IplConvKernel element,
            MorphologicalOperation operation,
            int iterations);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvMoments(CvHandle arr, out CvMoments moments, int binary);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvGetSpatialMoment(ref CvMoments moments, int x_order, int y_order);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvGetCentralMoment(ref CvMoments moments, int x_order, int y_order);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvGetNormalizedCentralMoment(ref CvMoments moments, int x_order, int y_order);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvGetHuMoments(ref CvMoments moments, out CvHuMoments hu_moments);

        #endregion

        #region Data sampling

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvSampleLine(CvArr image, CvPoint pt1, CvPoint pt2, IntPtr buffer, LineType connectivity);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvGetRectSubPix(CvArr src, CvArr dst, CvPoint2D32f center);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvGetQuadrangleSubPix(CvArr src, CvArr dst, CvMat map_matrix);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvMatchTemplate(CvArr image, CvArr templ, CvArr result, TemplateMatchingMethod method);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern float cvCalcEMD2(
            CvArr signature1,
            CvArr signature2,
            DistanceType distance_type,
            CvDistanceFunction distance_func,
            CvArr cost_matrix,
            CvArr flow,
            ref float lower_bound,
            IntPtr userdata);

        #endregion

        #region Contours retrieving

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvFindContours(
            CvArr image,
            CvMemStorage storage,
            out CvSeq first_contour,
            int header_size,
            ContourRetrieval mode,
            ContourApproximation method,
            CvPoint offset);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CvContourScanner cvStartFindContours(
            CvArr image,
            CvMemStorage storage,
            int header_size,
            ContourRetrieval mode,
            ContourApproximation method,
            CvPoint offset);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CvSeq cvFindNextContour(CvContourScanner scanner);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSubstituteContour(CvContourScanner scanner, CvSeq new_contour);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CvSeq cvEndFindContours(ref IntPtr scanner);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CvSeq cvApproxChains(
            CvSeq src_seq,
            CvMemStorage storage,
            ContourApproximation method,
            double parameter,
            int minimal_perimeter,
            int recursive);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvStartReadChainPoints(CvChain chain, out _CvChainPtReader reader);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CvPoint cvReadChainPoint(ref _CvChainPtReader reader);

        #endregion

        #region Contour Processing and Shape Analysis

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CvSeq cvApproxPoly(
            CvSeq src_seq,
            int header_size,
            CvMemStorage storage,
            PolygonApproximation method,
            double parameter,
            int parameter2);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvArcLength(CvHandle curve, CvSlice slice, int is_closed);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CvRect cvBoundingRect(CvHandle points, int update);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvContourArea(CvHandle contour, CvSlice slice, int oriented);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CvBox2D cvMinAreaRect2(CvHandle points, CvMemStorage storage);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvMinEnclosingCircle(CvHandle points, out CvPoint2D32f center, out float radius);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvMatchShapes(CvHandle object1, CvHandle object2, ShapeMatchingMethod method, double parameter);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CvSeq cvConvexHull2(CvHandle input, CvHandle hull_storage, ShapeOrientation orientation, int return_points);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvCheckContourConvexity(CvHandle contour);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CvSeq cvConvexityDefects(CvHandle contour, CvHandle convexhull, CvMemStorage storage);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CvBox2D cvFitEllipse2(CvHandle points);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CvRect cvMaxRect(ref CvRect rect1, ref CvRect rect2);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvBoxPoints(CvBox2D box, CvPoint2D32f[] pt);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CvSeq cvPointSeqFromMat(int seq_kind, CvArr mat, CvContour contour_header, IntPtr block);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvPointPolygonTest(CvHandle contour, CvPoint2D32f pt, int measure_dist);

        #endregion
    }
}
