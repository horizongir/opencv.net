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
        const string libName = "opencv_imgproc230";

        [DllImport(libName)]
        public static extern CvMat cvGetPerspectiveTransform(CvPoint2D32f[] src, CvPoint2D32f[] dst, CvMat map_matrix);

        [DllImport(libName)]
        public static extern void cvWarpPerspective(CvArr src, CvArr dst, CvMat map_matrix, WarpFlags flags, CvScalar fillval);

        [DllImport(libName)]
        public static extern void cvAcc(CvArr image, CvArr sum, CvArr mask);

        [DllImport(libName)]
        public static extern void cvRunningAvg(CvArr image, CvArr acc, double alpha, CvArr mask);

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

        [DllImport(libName)]
        public static extern void cvDilate(CvArr src, CvArr dst, IplConvKernel element, int iterations);

        [DllImport(libName)]
        public static extern void cvErode(CvArr src, CvArr dst, IplConvKernel element, int iterations);

        [DllImport(libName)]
        public static extern void cvAdaptiveThreshold(CvArr src, CvArr dst, double maxValue,
                          AdaptiveThresholdMethod adaptiveMethod, ThresholdType thresholdType,
                          int blockSize, double param1 );

        [DllImport(libName)]
        public static extern double cvThreshold(CvArr src, CvArr dst, double threshold, double maxValue, ThresholdType thresholdType);

        [DllImport(libName)]
        public static extern void cvCvtColor(CvArr src, CvArr dst, ColorConversion code);

        [DllImport(libName)]
        public static extern void cvCanny(CvArr image, CvArr edges, double threshold1, double threshold2, int aperture_size);

        [DllImport(libName)]
        public static extern void cvFindCornerSubPix(CvArr image, CvPoint2D32f[] corners, int count, CvSize win, CvSize zero_zone, CvTermCriteria criteria);

        [DllImport(libName)]
        public static extern void cvMoments(CvArr arr, out CvMoments moments, int binary);

        [DllImport(libName)]
        public static extern void cvFloodFill(
            CvArr image,
            CvPoint seed_point,
            CvScalar new_val,
            CvScalar lo_diff, //=cvScalarAll(0)
            CvScalar up_diff, //=cvScalarAll(0)
            ref CvConnectedComp comp, //=NULL
            int flags, // = 4
            CvArr mask); // = null

        [DllImport(libName)]
        public static extern void cvUpdateMotionHistory(CvArr silhouette, CvArr mhi, double timestamp, double duration);

        [DllImport(libName)]
        public static extern CvSeq cvApproxPoly(
            CvSeq src_seq,
            int header_size,
            CvMemStorage storage,
            PolygonApproximation method,
            double parameter,
            int parameter2);

        [DllImport(libName)]
        public static extern int cvFindContours(
            CvArr image,
            CvMemStorage storage,
            out CvSeq first_contour,
            int header_size, //=sizeof(CvContour),
            ContourRetrieval mode, //=CV_RETR_LIST,
            ContourApproximation method, //=CV_CHAIN_APPROX_SIMPLE,
            CvPoint offset); //=cvPoint(0, 0)
    }
}
