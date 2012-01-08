using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OpenCV.Net.Native
{
    static class core
    {
        const string libName = "opencv_core231";

        public static readonly CvErrorCallback DefaultCvErrorCallback = SetDefaultErrorCallback();

        private static CvErrorCallback SetDefaultErrorCallback()
        {
            IntPtr userData;
            CvErrorCallback callback = CvErrorExceptionCallback;
            Core.cvRedirectError(callback, IntPtr.Zero, out userData);
            return callback;
        }

        private static int CvErrorExceptionCallback(int status, string func_name, string err_msg, string file_name, int line)
        {
            throw new CvException(status, func_name, err_msg, file_name, line);
        }

        [DllImport(libName)]
        public static extern IntPtr cvCreateMat(int rows, int cols, int type);

        [DllImport(libName)]
        public static extern void cvReleaseMat(IntPtr mat);

        [DllImport(libName)]
        public static extern void cvCalcCovarMatrix(IntPtr[] vects, int count, CvArr covMat, CvArr avg, CovarianceFlags flags);

        [DllImport(libName)]
        public static extern IplImage cvCloneImage(IplImage image);

        [DllImport(libName)]
        public static extern CvRect cvGetImageROI(IplImage image);

        [DllImport(libName)]
        public static extern double cvGetReal1D(IntPtr arr, int idx0);

        [DllImport(libName)]
        public static extern double cvGetReal2D(IntPtr arr, int idx0, int idx1);

        [DllImport(libName)]
        public static extern double cvGetReal3D(IntPtr arr, int idx0, int idx1, int idx2);

        [DllImport(libName)]
        public static extern IntPtr cvGetSeqElem(CvSeq seq, int index);

        [DllImport(libName)]
        public static extern IntPtr cvCreateImage(CvSize size, int depth, int channels);

        [DllImport(libName)]
        public static extern IntPtr cvCreateImageHeader(CvSize size, int depth, int channels);

        [DllImport(libName)]
        public static extern void cvReleaseImage(IntPtr image);

        [DllImport(libName)]
        public static extern void cvReleaseImageHeader(IntPtr image);

        [DllImport(libName)]
        public static extern void cvResetImageROI(IplImage image);

        [DllImport(libName)]
        public static extern void cvSetZero(CvArr arr);

        [DllImport(libName)]
        public static extern void cvSetData(CvArr arr, IntPtr data, int step);

        [DllImport(libName)]
        public static extern void cvGetRawData(CvArr arr, out IntPtr data, out int step, out CvSize roiSize);

        [DllImport(libName)]
        public static extern void cvSetImageROI(IplImage image, CvRect rect);

        [DllImport(libName)]
        public static extern IntPtr cvCreateMemStorage(int blockSize);

        [DllImport(libName)]
        public static extern void cvReleaseMemStorage(IntPtr storage);

        [DllImport(libName)]
        public static extern void cvClearMemStorage(CvMemStorage storage);

        [DllImport(libName, CharSet = CharSet.Ansi)]
        public static extern IntPtr cvLoad(string filename, CvMemStorage storage, string name, out string realName);

        [DllImport(libName)]
        public static extern void cvInitFont(IntPtr font, FontFace fontFace, double hscale, double vscale, double shear, int thickness, int lineType);
    }
}
