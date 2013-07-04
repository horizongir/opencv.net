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
        internal static extern int cvGetElemType(CvArr arr);

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
        internal static extern IntPtr cvGetMat(CvArr arr, out _CvMat header, out int coi, int allowND);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvReshape(
            CvArr arr,
            out _CvMat header,
            int new_cn,
            int new_rows);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvRepeat(CvArr src, CvArr dst);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSetData(CvArr arr, IntPtr data, int step);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvGetRawData(
            CvArr arr,
            out IntPtr data,
            out int step,
            out CvSize roi_size);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CvSize cvGetSize(CvArr arr);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCopy(CvArr src, CvArr dst, CvArr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSet(CvArr arr, CvScalar value, CvArr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSetZero(CvArr arr);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSplit(CvArr src, CvArr dst0, CvArr dst1, CvArr dst2, CvArr dst3);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvMerge(CvArr src0, CvArr src1, CvArr src2, CvArr src3, CvArr dst);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvMixChannels(
            IntPtr[] src, int src_count,
            IntPtr[] dst, int dst_count,
            int[] from_to, int pair_count);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvConvertScale(
            CvArr src,
            CvArr dst,
            double scale,
            double shift);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvConvertScaleAbs(
            CvArr src,
            CvArr dst,
            double scale,
            double shift);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CvTermCriteria cvCheckTermCriteria(
            CvTermCriteria criteria,
            double default_eps,
            int default_max_iters);

        #endregion

        #region Arithmetic, logic and comparison operations

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvAdd(CvArr src1, CvArr src2, CvArr dst, CvArr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvAddS(CvArr src, CvScalar value, CvArr dst, CvArr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSub(CvArr src1, CvArr src2, CvArr dst, CvArr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSubRS(CvArr src, CvScalar value, CvArr dst, CvArr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvMul(CvArr src1, CvArr src2, CvArr dst, double scale);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvDiv(CvArr src1, CvArr src2, CvArr dst, double scale);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvScaleAdd(CvArr src1, CvScalar scale, CvArr src2, CvArr dst);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvAddWeighted(CvArr src1, double alpha, CvArr src2, double beta, double gamma, CvArr dst);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvDotProduct(CvArr src1, CvArr src2);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvAnd(CvArr src1, CvArr src2, CvArr dst, CvArr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvAndS(CvArr src, CvScalar value, CvArr dst, CvArr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvOr(CvArr src1, CvArr src2, CvArr dst, CvArr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvOrS(CvArr src, CvScalar value, CvArr dst, CvArr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvXor(CvArr src1, CvArr src2, CvArr dst, CvArr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvXorS(CvArr src, CvScalar value, CvArr dst, CvArr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvNot(CvArr src, CvArr dst);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvInRange(CvArr src, CvArr lower, CvArr upper, CvArr dst);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvInRangeS(CvArr src, CvScalar lower, CvScalar upper, CvArr dst);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCmp(CvArr src1, CvArr src2, CvArr dst, ComparisonOperation cmp_op);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCmpS(CvArr src, double value, CvArr dst, ComparisonOperation cmp_op);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvMin(CvArr src1, CvArr src2, CvArr dst);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvMax(CvArr src1, CvArr src2, CvArr dst);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvMinS(CvArr src, double value, CvArr dst);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvMaxS(CvArr src, double value, CvArr dst);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvAbsDiff(CvArr src1, CvArr src2, CvArr dst);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvAbsDiffS(CvArr src, CvArr dst, CvScalar value);

        #endregion

        #region Math operations

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCartToPolar(CvArr x, CvArr y, CvArr magnitude, CvArr angle, int angle_in_degrees);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvPolarToCart(CvArr magnitude, CvArr angle, CvArr x, CvArr y, int angle_in_degrees);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvPow(CvArr src, CvArr dst, double power);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvExp(CvArr src, CvArr dst);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvLog(CvArr src, CvArr dst);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern float cvFastArctan(float y, float x);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern float cvCbrt(float value);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvCheckArr(CvArr arr, CheckArrayFlags flags, double min_val, double max_val);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvRandArr(ref ulong rng, CvArr arr, CvRandDistribution dist_type, CvScalar param1, CvScalar param2);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvRandShuffle(CvArr mat, ref ulong rng, double iter_factor);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSort(CvArr src, CvArr dst, CvArr idxmat, SortFlags flags);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvSolveCubic(CvMat coeffs, CvMat roots);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSolvePoly(CvMat coeffs, CvMat roots2, int maxiter, int fig);

        #endregion

        #region Matrix operations

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCrossProduct(CvArr src1, CvArr src2, CvArr dst);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvGEMM(CvArr src1, CvArr src2, double alpha, CvArr src3, double beta, CvArr dst, GemmFlags tABC);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvTransform(CvArr src, CvArr dst, CvMat transmat, CvMat shiftvec);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvPerspectiveTransform(CvArr src, CvArr dst, CvMat mat);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvMulTransposed(CvArr src, CvArr dst, int order, CvArr delta, double scale);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvTranspose(CvArr src, CvArr dst);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCompleteSymm(CvMat matrix, int LtoR);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvFlip(CvArr src, CvArr dst, FlipMode flipMode);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSVD(CvArr A, CvArr W, CvArr U, CvArr V, SvdFlags flags);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSVBkSb(CvArr W, CvArr U, CvArr V, CvArr B, CvArr X, SvdFlags flags);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvInvert(CvArr src, CvArr dst, InversionMethod method);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvSolve(CvArr src1, CvArr src2, CvArr dst, InversionMethod method);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvDet(CvArr mat);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CvScalar cvTrace(CvArr mat);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvEigenVV(CvArr mat, CvArr evects, CvArr evals, double eps, int lowindex, int highindex);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSetIdentity(CvArr mat, CvScalar value);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvRange(CvArr mat, double start, double end);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCalcCovarMatrix(IntPtr[] vects, int count, CvArr covMat, CvArr avg, CovarianceFlags flags);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCalcPCA(CvArr data, CvArr mean, CvArr eigenvals, CvArr eigenvects, PcaFlags flags);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvProjectPCA(CvArr data, CvArr mean, CvArr eigenvects, CvArr result);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvBackProjectPCA(CvArr proj, CvArr mean, CvArr eigenvects, CvArr result);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvMahalanobis(CvArr vec1, CvArr vec2, CvArr mat);

        #endregion

        #region Array Statistics

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CvScalar cvSum(CvArr arr);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvCountNonZero(CvArr arr);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CvScalar cvAvg(CvArr arr, CvArr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvAvgSdv(CvArr arr, out CvScalar mean, out CvScalar std_dev, CvArr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvMinMaxLoc(
            CvArr arr,
            out double min_val,
            out double max_val,
            out CvPoint min_loc,
            out CvPoint max_loc,
            CvArr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvNorm(CvArr arr1, CvArr arr2, NormTypes norm_type, CvArr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvNormalize(CvArr src, CvArr dst, double a, double b, NormTypes norm_type, CvArr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvReduce(CvArr src, CvArr dst, int dim, ReduceOperation op);

        #endregion

        #region Discrete Linear Transforms and Related Functions

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvDFT(CvArr src, CvArr dst, DiscreteTransformFlags flags, int nonzero_rows);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvMulSpectrums(CvArr src1, CvArr src2, CvArr dst, DiscreteTransformFlags flags);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvGetOptimalDFTSize(int size0);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvDCT(CvArr src, CvArr dst, DiscreteTransformFlags flags);

        #endregion

        #region Dynamic data structures

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvSliceLength(CvSlice slice, CvSeq seq);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCreateMemStorage(int block_size);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCreateChildMemStorage(CvMemStorage parent);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvReleaseMemStorage(ref IntPtr storage);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvClearMemStorage(CvMemStorage storage);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSaveMemStoragePos(CvMemStorage storage, out CvMemStoragePos pos);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvRestoreMemStoragePos(CvMemStorage storage, ref CvMemStoragePos pos);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvMemStorageAlloc(CvMemStorage storage, UIntPtr size);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern _CvString cvMemStorageAllocString(CvMemStorage storage, string ptr, int len);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCreateSeq(int seq_flags, UIntPtr header_size, UIntPtr elem_size, CvMemStorage storage);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSetSeqBlockSize(CvSeq seq, int delta_elems);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvSeqPush(CvSeq seq, IntPtr element);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvSeqPushFront(CvSeq seq, IntPtr element);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSeqPop(CvSeq seq, IntPtr element);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSeqPopFront(CvSeq seq, IntPtr element);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSeqPushMulti(CvSeq seq, IntPtr elements, int count, int in_front);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSeqPopMulti(CvSeq seq, IntPtr elements, int count, int in_front);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvSeqInsert(CvSeq seq, int before_index, IntPtr element);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSeqRemove(CvSeq seq, int index);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvClearSeq(CvSeq seq);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvGetSeqElem(CvSeq seq, int index);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvSeqElemIdx(CvSeq seq, IntPtr element, IntPtr block);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCvtSeqToArray(CvSeq seq, IntPtr elements, CvSlice slice);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CvSeq cvSeqSlice(CvSeq seq, CvSlice slice, CvMemStorage storage, int copy_data);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSeqRemoveSlice(CvSeq seq, CvSlice slice);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSeqInsertSlice(CvSeq seq, int before_index, SafeHandle from_arr);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSeqSort(CvSeq seq, CvCmpFunc func, IntPtr userdata);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvSeqSearch(CvSeq seq, IntPtr elem, CvCmpFunc func, int is_sorted, out int elem_idx, IntPtr userdata);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSeqInvert(CvSeq seq);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvSeqPartition(CvSeq seq, CvMemStorage storage, out CvSeq labels, CvCmpFunc is_equal, IntPtr userdata);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCreateSet(int set_flags, int header_size, int elem_size, CvMemStorage storage);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvClearSet(CvSet set_header);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvGraphRemoveVtx(CvGraph graph, int index);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvGraphRemoveEdge(CvGraph graph, int start_idx, int end_idx);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvClearGraph(CvGraph graph);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvGraphVtxDegree(CvGraph graph, int vtx_idx);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CvGraph cvCloneGraph(CvGraph graph, CvMemStorage storage);

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
