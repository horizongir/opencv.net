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
        internal static extern int cvGetDims(CvArr arr, int[] sizes = null);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvGetDimSize(CvArr arr, int index);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvPtr1D(CvArr arr, int idx0, out int type);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvPtr2D(CvArr arr, int idx0, int idx1, out int type);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvPtr3D(CvArr arr, int idx0, int idx1, int idx2, out int type);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvPtrND(
            CvArr arr,
            int[] idx,
            out int type,
            int create_node,
            IntPtr precalc_hashval);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CvScalar cvGet1D(CvArr arr, int idx0);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CvScalar cvGet2D(CvArr arr, int idx0, int idx1);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CvScalar cvGet3D(CvArr arr, int idx0, int idx1, int idx2);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CvScalar cvGetND(CvArr arr, int[] idx);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvGetReal1D(CvArr arr, int idx0);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvGetReal2D(CvArr arr, int idx0, int idx1);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvGetReal3D(CvArr arr, int idx0, int idx1, int idx2);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvGetRealND(CvArr arr, int[] idx);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSet1D(CvArr arr, int idx0, CvScalar value);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSet2D(CvArr arr, int idx0, int idx1, CvScalar value);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSet3D(CvArr arr, int idx0, int idx1, int idx2, CvScalar value);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSetND(CvArr arr, int[] idx, CvScalar value);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSetReal1D(CvArr arr, int idx0, double value);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSetReal2D(CvArr arr, int idx0, int idx1, double value);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSetReal3D(CvArr arr, int idx0, int idx1, int idx2, double value);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSetRealND(CvArr arr, int[] idx, double value);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvClearND(CvArr arr, int[] idx);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvGetMat(CvArr arr, out _CvMat header, out int coi, int allowND = 0);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSetData(CvArr arr, IntPtr data, int step);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CvSize cvGetSize(CvArr arr);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSet(CvArr arr, CvScalar value, CvArr mask = null);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSetZero(CvArr arr);

        #endregion

        #region Error handling

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvGetErrStatus();

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSetErrStatus(int status);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvSetErrMode(int mode);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvErrorStr(int status);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvRedirectError([MarshalAs(UnmanagedType.FunctionPtr)]CvErrorCallback error_handler, IntPtr userdata, out IntPtr prevUserdata);

        internal static CvErrorCallback CvErrorCallback;

        static NativeMethods()
        {
            IntPtr userData;
            CvErrorCallback = CvErrorExceptionCallback;
            cvRedirectError(CvErrorCallback, IntPtr.Zero, out userData);
        }

        static int CvErrorExceptionCallback(int status, string func_name, string err_msg, string file_name, int line, IntPtr userData)
        {
            throw new CvException(status, func_name, err_msg, file_name, line);
        }

        #endregion
    }
}
