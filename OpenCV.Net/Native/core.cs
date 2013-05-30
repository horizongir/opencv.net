using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OpenCV.Net.Native
{
    static partial class NativeMethods
    {
        const string coreLib = "opencv_core245";

        #region Array allocation, deallocation, initialization and access to elements

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvAlloc(UIntPtr size);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvFree_(IntPtr ptr);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCreateImageHeader(CvSize size, IplDepth depth, int channels);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvInitImageHeader(
            IplImage image,
            CvSize size,
            IplDepth depth,
            int channels,
            IplOrigin origin = IplOrigin.TopLeft,
            int align = 4);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCreateImage(CvSize size, IplDepth depth, int channels);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvReleaseImageHeader(ref IntPtr image);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvReleaseImage(ref IntPtr image);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCloneImage(IplImage image);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSetImageCOI(IplImage image, int coi);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvGetImageCOI(IplImage image);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSetImageROI(IplImage image, CvRect rect);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvResetImageROI(IplImage image);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CvRect cvGetImageROI(IplImage image);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCreateMatHeader(int rows, int cols, int type);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvInitMatHeader(
            IntPtr mat,
            int rows,
            int cols,
            int type,
            IntPtr data,
            int step = CvMat.AutoStep);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCreateMat(int rows, int cols, int type);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvReleaseMat(ref IntPtr mat);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCloneMat(CvMat mat);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvGetSubRect(CvArr arr, out _CvMat submat, CvRect rect);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvGetRows(CvArr arr, out _CvMat submat, int start_row, int end_row, int delta_row);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvGetCols(CvArr arr, out _CvMat submat, int start_col, int end_col);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvGetDiag(CvArr arr, out _CvMat submat, int diag);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCreateMatNDHeader(int dims, int[] sizes, int type);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCreateMatND(int dims, int[] sizes, int type);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvInitMatNDHeader(IntPtr mat, int dims, int[] sizes, int type, IntPtr data);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCloneMatND(CvMatND mat);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCreateSparseMat(int dims, int[] sizes, int type);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvReleaseSparseMat(ref IntPtr mat);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCloneSparseMat(CvSparseMat mat);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvInitSparseMatIterator(CvSparseMat mat, out _CvSparseMatIterator mat_iterator);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvGetDimSize(CvArr arr, int index);

        #endregion
    }
}
