using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OpenCV.Net.Native
{
    static class imgproc
    {
        const string libName = "opencv_imgproc244";

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreatePyramid(
            CvArr img,
            int extra_layers,
            double rate,
            CvSize[] layer_sizes,
            CvArr bufarr,
            int calc,
            PyramidDecompositionFilter filter);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvSampleLine(CvArr image, CvPoint pt1, CvPoint pt2, IntPtr buffer, int connectivity);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateHist(int dims, int[] sizes, HistogramType type, IntPtr[] ranges, int uniform);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCalcArrBackProject(IntPtr[] images, CvArr back_project, CvHistogram hist);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCalcArrHist(IntPtr[] images, CvHistogram hist, int accumulate, CvArr mask);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvGetMinMaxHistValue(CvHistogram hist, out float min_value, out float max_value, int[] min_idx, int[] max_idx);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvNormalizeHist(CvHistogram hist, double factor);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReleaseHist(IntPtr capture);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreateStructuringElementEx(
            int cols, int rows, int anchor_x, int anchor_y,
            StructuringElementShape shape, int[] values);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReleaseStructuringElement(IntPtr element);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSeq cvApproxPoly(
            CvSeq src_seq,
            int header_size,
            CvMemStorage storage,
            PolygonApproximation method,
            double parameter,
            int parameter2);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSeq cvHoughCircles(
            CvArr image,
            SafeHandle circle_storage,
            HoughTransformMethod method,
            double dp,
            double min_dist,
            double param1,// CV_DEFAULT(100),
            double param2, // CV_DEFAULT(100),
            int min_radius, // CV_DEFAULT(0),
            int max_radius); // CV_DEFAULT(0));

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvFindContours(
            CvArr image,
            CvMemStorage storage,
            out CvSeq first_contour,
            int header_size, //=sizeof(CvContour),
            ContourRetrieval mode, //=CV_RETR_LIST,
            ContourApproximation method, //=CV_CHAIN_APPROX_SIMPLE,
            CvPoint offset); //=cvPoint(0, 0)

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvContourScanner cvStartFindContours(
            CvArr image,
            CvMemStorage storage,
            int header_size, //=sizeof(CvContour),
            ContourRetrieval mode, //=CV_RETR_LIST,
            ContourApproximation method, //=CV_CHAIN_APPROX_SIMPLE,
            CvPoint offset); //=cvPoint(0, 0)

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSeq cvFindNextContour(CvContourScanner scanner);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSubstituteContour(CvContourScanner scanner, CvSeq new_contour);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvSeq cvEndFindContours(IntPtr scanner);
    }
}
