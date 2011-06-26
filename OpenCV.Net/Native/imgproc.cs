using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OpenCV.Net.Native
{
    static class imgproc
    {
        const string libName = "opencv_imgproc220";

        [DllImport(libName)]
        public static extern IntPtr cvCreateHist(int dims, int[] sizes, HistogramType type, IntPtr[] ranges, int uniform);

        [DllImport(libName)]
        public static extern void cvCalcArrHist(IntPtr[] images, CvHistogram hist, int accumulate, CvArr mask);

        [DllImport(libName)]
        public static extern void cvGetMinMaxHistValue(CvHistogram hist, out float min_value, out float max_value, int[] min_idx, int[] max_idx);

        [DllImport(libName)]
        public static extern void cvNormalizeHist(CvHistogram hist, double factor);

        [DllImport(libName)]
        public static extern void cvReleaseHist(IntPtr capture);

        [DllImport(libName)]
        public static extern IntPtr cvCreateStructuringElementEx(
            int cols, int rows, int anchor_x, int anchor_y,
            StructuringElementShape shape, int[] values);

        [DllImport(libName)]
        public static extern void cvReleaseStructuringElement(IntPtr element);
    }
}
