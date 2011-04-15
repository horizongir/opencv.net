using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OpenCV.Net
{
    public static class ImgProc
    {
        const string libName = "opencv_imgproc220";

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
        public static extern int cvFindContours(
            CvArr image,
            CvMemStorage storage,
            out CvContour first_contour,
            int header_size, //=sizeof(CvContour),
            ContourRetrieval mode, //=CV_RETR_LIST,
            ContourApproximation method, //=CV_CHAIN_APPROX_SIMPLE,
            CvPoint offset); //=cvPoint(0, 0)
    }
}
