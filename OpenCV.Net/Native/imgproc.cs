using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net.Native
{
    static partial class NativeMethods
    {
        const string imgprocLib = "opencv_imgproc248";

        #region Background statistics accumulation

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvAcc(Arr image, Arr sum, Arr mask);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSquareAcc(Arr image, Arr sqsum, Arr mask);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvMultiplyAcc(Arr image1, Arr image2, Arr acc, Arr mask);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvRunningAvg(Arr image, Arr acc, double alpha, Arr mask);

        #endregion

        #region Image Processing

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCopyMakeBorder(Arr src, Arr dst, Point offset, IplBorder bordertype, Scalar value);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSmooth(
            Arr src,
            Arr dst,
            SmoothMethod smoothtype,
            int size1,
            int size2,
            double sigma1,
            double sigma2);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvFilter2D(Arr src, Arr dst, Mat kernel, Point anchor);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvIntegral(Arr image, Arr sum, Arr sqsum, Arr tilted_sum);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvPyrDown(Arr src, Arr dst, PyramidDecompositionFilter filter);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvPyrUp(Arr src, Arr dst, PyramidDecompositionFilter filter);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCreatePyramid(
            Arr img,
            int extra_layers,
            double rate,
            Size[] layer_sizes,
            Arr bufarr,
            int calc,
            PyramidDecompositionFilter filter);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvReleasePyramid(IntPtr pyramid, int extra_layers);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvPyrMeanShiftFiltering(
            Arr src,
            Arr dst,
            double sp,
            double sr,
            int max_level,
            TermCriteria termcrit);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvWatershed(Arr image, Arr markers);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSobel(Arr src, Arr dst, int xorder, int yorder, int aperture_size);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvLaplace(Arr src, Arr dst, int aperture_size);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCvtColor(Arr src, Arr dst, ColorConversion code);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvResize(Arr src, Arr dst, SubPixelInterpolation interpolation);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvWarpAffine(Arr src, Arr dst, Mat map_matrix, WarpFlags flags, Scalar fillval);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvGetAffineTransform(Point2f[] src, Point2f[] dst, Mat map_matrix);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cv2DRotationMatrix(Point2f center, double angle, double scale, Mat map_matrix);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvWarpPerspective(Arr src, Arr dst, Mat map_matrix, WarpFlags flags, Scalar fillval);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvGetPerspectiveTransform(Point2f[] src, Point2f[] dst, Mat map_matrix);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvRemap(Arr src, Arr dst, Arr mapx, Arr mapy, WarpFlags flags, Scalar fillval);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvConvertMaps(Arr mapx, Arr mapy, Arr mapxy, Arr mapalpha);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvLogPolar(Arr src, Arr dst, Point2f center, double M, WarpFlags flags);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvLinearPolar(Arr src, Arr dst, Point2f center, double maxRadius, WarpFlags flags);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvUndistort2(Arr src, Arr dst, Mat camera_matrix, Mat distortion_coeffs, Mat new_camera_matrix);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvInitUndistortMap(Mat camera_matrix, Mat distortion_coeffs, Arr mapx, Arr mapy);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvInitUndistortRectifyMap(
            Mat camera_matrix,
            Mat dist_coeffs,
            Mat R,
            Mat new_camera_matrix,
            Arr mapx,
            Arr mapy);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvUndistortPoints(
            Mat src,
            Mat dst,
            Mat camera_matrix,
            Mat dist_coeffs,
            Mat R,
            Mat P);

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
        internal static extern void cvErode(Arr src, Arr dst, IplConvKernel element, int iterations);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvDilate(Arr src, Arr dst, IplConvKernel element, int iterations);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvMorphologyEx(
            Arr src,
            Arr dst,
            Arr temp,
            IplConvKernel element,
            MorphologicalOperation operation,
            int iterations);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvMoments(CVHandle arr, out Moments moments, int binary);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvGetSpatialMoment(ref Moments moments, int x_order, int y_order);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvGetCentralMoment(ref Moments moments, int x_order, int y_order);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvGetNormalizedCentralMoment(ref Moments moments, int x_order, int y_order);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvGetHuMoments(ref Moments moments, out HuMoments hu_moments);

        #endregion

        #region Data sampling

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvSampleLine(Arr image, Point pt1, Point pt2, IntPtr buffer, LineType connectivity);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvGetRectSubPix(Arr src, Arr dst, Point2f center);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvGetQuadrangleSubPix(Arr src, Arr dst, Mat map_matrix);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvMatchTemplate(Arr image, Arr templ, Arr result, TemplateMatchingMethod method);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern float cvCalcEMD2(
            Arr signature1,
            Arr signature2,
            DistanceType distance_type,
            CvDistanceFunction distance_func,
            Arr cost_matrix,
            Arr flow,
            ref float lower_bound,
            IntPtr userdata);

        #endregion

        #region Contours retrieving

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvFindContours(
            Arr image,
            MemStorage storage,
            out Seq first_contour,
            int header_size,
            ContourRetrieval mode,
            ContourApproximation method,
            Point offset);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ContourScanner cvStartFindContours(
            Arr image,
            MemStorage storage,
            int header_size,
            ContourRetrieval mode,
            ContourApproximation method,
            Point offset);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Seq cvFindNextContour(ContourScanner scanner);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSubstituteContour(ContourScanner scanner, Seq new_contour);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Seq cvEndFindContours(ref IntPtr scanner);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Seq cvApproxChains(
            Seq src_seq,
            MemStorage storage,
            ContourApproximation method,
            double parameter,
            int minimal_perimeter,
            int recursive);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvStartReadChainPoints(Chain chain, out _CvChainPtReader reader);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Point cvReadChainPoint(ref _CvChainPtReader reader);

        #endregion

        #region Contour Processing and Shape Analysis

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Seq cvApproxPoly(
            Seq src_seq,
            int header_size,
            MemStorage storage,
            PolygonApproximation method,
            double parameter,
            int parameter2);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvArcLength(CVHandle curve, SeqSlice slice, int is_closed);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Rect cvBoundingRect(CVHandle points, int update);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvContourArea(CVHandle contour, SeqSlice slice, int oriented);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern RotatedRect cvMinAreaRect2(CVHandle points, MemStorage storage);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvMinEnclosingCircle(CVHandle points, out Point2f center, out float radius);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvMatchShapes(CVHandle object1, CVHandle object2, ShapeMatchingMethod method, double parameter);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Seq cvConvexHull2(CVHandle input, CVHandle hull_storage, ShapeOrientation orientation, int return_points);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvCheckContourConvexity(CVHandle contour);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Seq cvConvexityDefects(CVHandle contour, CVHandle convexhull, MemStorage storage);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern RotatedRect cvFitEllipse2(CVHandle points);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Rect cvMaxRect(ref Rect rect1, ref Rect rect2);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvBoxPoints(RotatedRect box, Point2f[] pt);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Seq cvPointSeqFromMat(int seq_kind, Arr mat, Contour contour_header, IntPtr block);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvPointPolygonTest(CVHandle contour, Point2f pt, int measure_dist);

        #endregion

        #region Histogram functions

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCreateHist(int dims, int[] sizes, HistogramType type, IntPtr[] ranges, int uniform);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSetHistBinRanges(Histogram hist, IntPtr[] ranges, int uniform);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvMakeHistHeaderForArray(
            int dims,
            int[] sizes,
            IntPtr hist,
            float[] data,
            IntPtr[] ranges,
            int uniform);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvReleaseHist(ref IntPtr hist);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvClearHist(Histogram hist);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvGetMinMaxHistValue(
            Histogram hist,
            out float min_value,
            out float max_value,
            int[] min_idx,
            int[] max_idx);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvNormalizeHist(Histogram hist, double factor);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvThreshHist(Histogram hist, double threshold);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvCompareHist(Histogram hist1, Histogram hist2, HistogramComparison method);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCopyHist(Histogram src, out Histogram dst);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCalcBayesianProb(IntPtr[] src, int number, IntPtr[] dst);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCalcArrHist(IntPtr[] arr, Histogram hist, int accumulate, Arr mask);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCalcArrBackProject(IntPtr[] image, Arr dst, Histogram hist);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCalcArrBackProjectPatch(
            IntPtr[] image,
            Arr dst,
            Size range,
            Histogram hist,
            HistogramComparison method,
            double factor);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCalcProbDensity(
            Histogram hist1,
            Histogram hist2,
            Histogram dst_hist,
            double scale);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvEqualizeHist(Arr src, Arr dst);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvDistTransform(
            Arr src,
            Arr dst,
            DistanceType distance_type,
            int mask_size,
            float[] mask,
            Arr labels,
            DistanceLabel labelType);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvThreshold(
            Arr src,
            Arr dst,
            double threshold,
            double max_value,
            ThresholdTypes threshold_type);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvAdaptiveThreshold(
            Arr src,
            Arr dst,
            double maxValue,
            AdaptiveThresholdMethod adaptiveMethod,
            ThresholdTypes thresholdType,
            int blockSize,
            double param1);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvFloodFill(
            Arr image,
            Point seed_point,
            Scalar new_val,
            Scalar lo_diff,
            Scalar up_diff,
            out ConnectedComp comp,
            FloodFillFlags flags,
            Arr mask);

        #endregion

        #region Feature detection

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCanny(Arr image, Arr edges, double threshold1, double threshold2, int aperture_size);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvPreCornerDetect(Arr image, Arr corners, int aperture_size);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCornerEigenValsAndVecs(Arr image, Arr eigenvv, int block_size, int aperture_size);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCornerMinEigenVal(Arr image, Arr eigenval, int block_size, int aperture_size);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCornerHarris(
            Arr image,
            Arr harris_responce,
            int block_size,
            int aperture_size,
            double k);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvFindCornerSubPix(
            Arr image,
            [Out]Point2f[] corners,
            int count,
            Size win,
            Size zero_zone,
            TermCriteria criteria);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvGoodFeaturesToTrack(
            Arr image,
            Arr eig_image,
            Arr temp_image,
            [Out]Point2f[] corners,
            ref int corner_count,
            double quality_level,
            double min_distance,
            Arr mask,
            int block_size,
            int use_harris,
            double k);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Seq cvHoughLines2(
            Arr image,
            CVHandle line_storage,
            HoughLinesMethod method,
            double rho,
            double theta,
            int threshold,
            double param1,
            double param2);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Seq cvHoughCircles(
            Arr image,
            CVHandle circle_storage,
            HoughCirclesMethod method,
            double dp,
            double min_dist,
            double param1,
            double param2,
            int min_radius,
            int max_radius);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvFitLine(
            Arr points,
            DistanceType dist_type,
            double param,
            double reps,
            double aeps,
            [Out]float[] line);

        #endregion
    }
}
