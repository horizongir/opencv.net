using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OpenCV.Net.Native
{
    static class core
    {
        const string libName = "opencv_core220";

        [DllImport(libName)]
        public static extern IntPtr cvCreateImage(CvSize size, int depth, int channels);

        [DllImport(libName)]
        public static extern IntPtr cvCreateImageHeader(CvSize size, int depth, int channels);

        [DllImport(libName)]
        public static extern void cvReleaseImage(IntPtr image);

        [DllImport(libName)]
        public static extern void cvSetZero(CvArr arr);

        [DllImport(libName)]
        public static extern void cvSetData(CvArr arr, IntPtr data, int step);

        [DllImport(libName)]
        public static extern IntPtr cvCreateMemStorage(int blockSize);

        [DllImport(libName)]
        public static extern void cvReleaseMemStorage(IntPtr storage);

        [DllImport(libName)]
        public static extern void cvClearMemStorage(CvMemStorage storage);

        [DllImport(libName)]
        public static extern void cvReleaseStructuringElement(IntPtr element);
    }
}
