using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OpenCV.Net.Native
{
    static partial class NativeMethods
    {
        const string coreLib = "opencv_core247";

        #region Array allocation, deallocation, initialization and access to elements

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvAlloc(UIntPtr size);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvFree_(IntPtr ptr);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCreateImageHeader(Size size, IplDepth depth, int channels);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvInitImageHeader(
            IplImage image,
            Size size,
            IplDepth depth,
            int channels,
            IplOrigin origin = IplOrigin.TopLeft,
            int align = 4);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCreateImage(Size size, IplDepth depth, int channels);

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
        internal static extern void cvSetImageROI(IplImage image, Rect rect);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvResetImageROI(IplImage image);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Rect cvGetImageROI(IplImage image);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCreateMatHeader(int rows, int cols, int type);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvInitMatHeader(
            IntPtr mat,
            int rows,
            int cols,
            int type,
            IntPtr data,
            int step = Mat.AutoStep);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCreateMat(int rows, int cols, int type);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvReleaseMat(ref IntPtr mat);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCloneMat(Mat mat);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvGetSubRect(Arr arr, out _CvMat submat, Rect rect);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvGetRows(Arr arr, out _CvMat submat, int start_row, int end_row, int delta_row);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvGetCols(Arr arr, out _CvMat submat, int start_col, int end_col);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvGetDiag(Arr arr, out _CvMat submat, int diag);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvScalarToRawData(ref Scalar scalar, IntPtr data, int type, int extend_to_12);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvRawDataToScalar(IntPtr data, int type, out Scalar scalar);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCreateMatNDHeader(int dims, int[] sizes, int type);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCreateMatND(int dims, int[] sizes, int type);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvInitMatNDHeader(IntPtr mat, int dims, int[] sizes, int type, IntPtr data);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCloneMatND(MatND mat);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCreateSparseMat(int dims, int[] sizes, int type);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvReleaseSparseMat(ref IntPtr mat);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCloneSparseMat(SparseMat mat);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvInitSparseMatIterator(SparseMat mat, out _CvSparseMatIterator mat_iterator);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvGetElemType(Arr arr);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvGetDims(Arr arr, int[] sizes = null);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvGetDimSize(Arr arr, int index);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvPtr1D(Arr arr, int idx0, out int type);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvPtr2D(Arr arr, int idx0, int idx1, out int type);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvPtr3D(Arr arr, int idx0, int idx1, int idx2, out int type);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvPtrND(
            Arr arr,
            int[] idx,
            out int type,
            int create_node,
            IntPtr precalc_hashval);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Scalar cvGet1D(Arr arr, int idx0);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Scalar cvGet2D(Arr arr, int idx0, int idx1);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Scalar cvGet3D(Arr arr, int idx0, int idx1, int idx2);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Scalar cvGetND(Arr arr, int[] idx);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvGetReal1D(Arr arr, int idx0);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvGetReal2D(Arr arr, int idx0, int idx1);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvGetReal3D(Arr arr, int idx0, int idx1, int idx2);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvGetRealND(Arr arr, int[] idx);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSet1D(Arr arr, int idx0, Scalar value);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSet2D(Arr arr, int idx0, int idx1, Scalar value);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSet3D(Arr arr, int idx0, int idx1, int idx2, Scalar value);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSetND(Arr arr, int[] idx, Scalar value);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSetReal1D(Arr arr, int idx0, double value);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSetReal2D(Arr arr, int idx0, int idx1, double value);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSetReal3D(Arr arr, int idx0, int idx1, int idx2, double value);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSetRealND(Arr arr, int[] idx, double value);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvClearND(Arr arr, int[] idx);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvGetMat(Arr arr, out _CvMat header, out int coi, int allowND);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvGetImage(Arr arr, out _IplImage image_header);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvReshapeMatND(
            Arr arr,
            int sizeof_header,
            Arr header,
            int new_cn,
            int new_dims,
            int[] new_sizes);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvReshape(
            Arr arr,
            out _CvMat header,
            int new_cn,
            int new_rows);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvRepeat(Arr src, Arr dst);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSetData(Arr arr, IntPtr data, int step);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvGetRawData(
            Arr arr,
            out IntPtr data,
            out int step,
            out Size roi_size);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Size cvGetSize(Arr arr);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCopy(Arr src, Arr dst, Arr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSet(Arr arr, Scalar value, Arr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSetZero(Arr arr);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSplit(Arr src, Arr dst0, Arr dst1, Arr dst2, Arr dst3);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvMerge(Arr src0, Arr src1, Arr src2, Arr src3, Arr dst);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvMixChannels(
            IntPtr[] src, int src_count,
            IntPtr[] dst, int dst_count,
            int[] from_to, int pair_count);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvConvertScale(
            Arr src,
            Arr dst,
            double scale,
            double shift);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvConvertScaleAbs(
            Arr src,
            Arr dst,
            double scale,
            double shift);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern TermCriteria cvCheckTermCriteria(
            TermCriteria criteria,
            double default_eps,
            int default_max_iters);

        #endregion

        #region Arithmetic, logic and comparison operations

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvAdd(Arr src1, Arr src2, Arr dst, Arr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvAddS(Arr src, Scalar value, Arr dst, Arr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSub(Arr src1, Arr src2, Arr dst, Arr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSubRS(Arr src, Scalar value, Arr dst, Arr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvMul(Arr src1, Arr src2, Arr dst, double scale);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvDiv(Arr src1, Arr src2, Arr dst, double scale);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvScaleAdd(Arr src1, Scalar scale, Arr src2, Arr dst);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvAddWeighted(Arr src1, double alpha, Arr src2, double beta, double gamma, Arr dst);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvDotProduct(Arr src1, Arr src2);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvAnd(Arr src1, Arr src2, Arr dst, Arr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvAndS(Arr src, Scalar value, Arr dst, Arr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvOr(Arr src1, Arr src2, Arr dst, Arr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvOrS(Arr src, Scalar value, Arr dst, Arr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvXor(Arr src1, Arr src2, Arr dst, Arr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvXorS(Arr src, Scalar value, Arr dst, Arr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvNot(Arr src, Arr dst);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvInRange(Arr src, Arr lower, Arr upper, Arr dst);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvInRangeS(Arr src, Scalar lower, Scalar upper, Arr dst);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCmp(Arr src1, Arr src2, Arr dst, ComparisonOperation cmp_op);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCmpS(Arr src, double value, Arr dst, ComparisonOperation cmp_op);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvMin(Arr src1, Arr src2, Arr dst);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvMax(Arr src1, Arr src2, Arr dst);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvMinS(Arr src, double value, Arr dst);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvMaxS(Arr src, double value, Arr dst);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvAbsDiff(Arr src1, Arr src2, Arr dst);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvAbsDiffS(Arr src, Arr dst, Scalar value);

        #endregion

        #region Math operations

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCartToPolar(Arr x, Arr y, Arr magnitude, Arr angle, int angle_in_degrees);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvPolarToCart(Arr magnitude, Arr angle, Arr x, Arr y, int angle_in_degrees);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvPow(Arr src, Arr dst, double power);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvExp(Arr src, Arr dst);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvLog(Arr src, Arr dst);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern float cvFastArctan(float y, float x);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern float cvCbrt(float value);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvCheckArr(Arr arr, CheckArrayFlags flags, double min_val, double max_val);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvRandArr(ref ulong rng, Arr arr, RandDistribution dist_type, Scalar param1, Scalar param2);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvRandShuffle(Arr mat, ref ulong rng, double iter_factor);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSort(Arr src, Arr dst, Arr idxmat, SortFlags flags);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvSolveCubic(Mat coeffs, Mat roots);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSolvePoly(Mat coeffs, Mat roots2, int maxiter, int fig);

        #endregion

        #region Matrix operations

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCrossProduct(Arr src1, Arr src2, Arr dst);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvGEMM(Arr src1, Arr src2, double alpha, Arr src3, double beta, Arr dst, GemmFlags tABC);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvTransform(Arr src, Arr dst, Mat transmat, Mat shiftvec);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvPerspectiveTransform(Arr src, Arr dst, Mat mat);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvMulTransposed(Arr src, Arr dst, int order, Arr delta, double scale);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvTranspose(Arr src, Arr dst);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCompleteSymm(Mat matrix, int LtoR);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvFlip(Arr src, Arr dst, FlipMode flipMode);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSVD(Arr A, Arr W, Arr U, Arr V, SvdFlags flags);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSVBkSb(Arr W, Arr U, Arr V, Arr B, Arr X, SvdFlags flags);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvInvert(Arr src, Arr dst, InversionMethod method);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvSolve(Arr src1, Arr src2, Arr dst, InversionMethod method);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvDet(Arr mat);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Scalar cvTrace(Arr mat);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvEigenVV(Arr mat, Arr evects, Arr evals, double eps, int lowindex, int highindex);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSetIdentity(Arr mat, Scalar value);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvRange(Arr mat, double start, double end);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCalcCovarMatrix(IntPtr[] vects, int count, Arr covMat, Arr avg, CovarianceFlags flags);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCalcPCA(Arr data, Arr mean, Arr eigenvals, Arr eigenvects, PcaFlags flags);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvProjectPCA(Arr data, Arr mean, Arr eigenvects, Arr result);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvBackProjectPCA(Arr proj, Arr mean, Arr eigenvects, Arr result);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvMahalanobis(Arr vec1, Arr vec2, Arr mat);

        #endregion

        #region Array Statistics

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Scalar cvSum(Arr arr);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvCountNonZero(Arr arr);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Scalar cvAvg(Arr arr, Arr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvAvgSdv(Arr arr, out Scalar mean, out Scalar std_dev, Arr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvMinMaxLoc(
            Arr arr,
            out double min_val,
            out double max_val,
            out Point min_loc,
            out Point max_loc,
            Arr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvNorm(Arr arr1, Arr arr2, NormTypes norm_type, Arr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvNormalize(Arr src, Arr dst, double a, double b, NormTypes norm_type, Arr mask);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvReduce(Arr src, Arr dst, int dim, ReduceOperation op);

        #endregion

        #region Discrete Linear Transforms and Related Functions

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvDFT(Arr src, Arr dst, DiscreteTransformFlags flags, int nonzero_rows);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvMulSpectrums(Arr src1, Arr src2, Arr dst, DiscreteTransformFlags flags);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvGetOptimalDFTSize(int size0);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvDCT(Arr src, Arr dst, DiscreteTransformFlags flags);

        #endregion

        #region Dynamic data structures

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvSliceLength(SeqSlice slice, Seq seq);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCreateMemStorage(int block_size);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCreateChildMemStorage(MemStorage parent);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvReleaseMemStorage(ref IntPtr storage);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvClearMemStorage(MemStorage storage);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSaveMemStoragePos(MemStorage storage, out MemStoragePos pos);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvRestoreMemStoragePos(MemStorage storage, ref MemStoragePos pos);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvMemStorageAlloc(MemStorage storage, UIntPtr size);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern _CvString cvMemStorageAllocString(MemStorage storage, string ptr, int len);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCreateSeq(int seq_flags, UIntPtr header_size, UIntPtr elem_size, MemStorage storage);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSetSeqBlockSize(Seq seq, int delta_elems);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvSeqPush(Seq seq, IntPtr element);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvSeqPushFront(Seq seq, IntPtr element);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSeqPop(Seq seq, IntPtr element);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSeqPopFront(Seq seq, IntPtr element);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSeqPushMulti(Seq seq, IntPtr elements, int count, int in_front);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSeqPopMulti(Seq seq, IntPtr elements, int count, int in_front);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvSeqInsert(Seq seq, int before_index, IntPtr element);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSeqRemove(Seq seq, int index);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvClearSeq(Seq seq);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvGetSeqElem(Seq seq, int index);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvSeqElemIdx(Seq seq, IntPtr element, IntPtr block);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCvtSeqToArray(Seq seq, IntPtr elements, SeqSlice slice);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Seq cvSeqSlice(Seq seq, SeqSlice slice, MemStorage storage, int copy_data);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSeqRemoveSlice(Seq seq, SeqSlice slice);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSeqInsertSlice(Seq seq, int before_index, CVHandle from_arr);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSeqSort(Seq seq, CvCmpFunc func, IntPtr userdata);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvSeqSearch(Seq seq, IntPtr elem, CvCmpFunc func, int is_sorted, out int elem_idx, IntPtr userdata);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvSeqInvert(Seq seq);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvSeqPartition(Seq seq, MemStorage storage, out Seq labels, CvCmpFunc is_equal, IntPtr userdata);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvCreateSet(int set_flags, int header_size, int elem_size, MemStorage storage);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvClearSet(Set set_header);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvGraphRemoveVtx(Graph graph, int index);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvGraphRemoveEdge(Graph graph, int start_idx, int end_idx);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvClearGraph(Graph graph);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvGraphVtxDegree(Graph graph, int vtx_idx);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Graph cvCloneGraph(Graph graph, MemStorage storage);

        #endregion

        #region Drawing

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvLine(
            Arr img,
            Point pt1,
            Point pt2,
            Scalar color,
            int thickness,
            LineFlags line_type,
            int shift);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvRectangle(
            Arr img,
            Point pt1,
            Point pt2,
            Scalar color,
            int thickness,
            LineFlags line_type,
            int shift);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvRectangleR(
            Arr img,
            Rect r,
            Scalar color,
            int thickness,
            LineFlags line_type,
            int shift);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvCircle(
            Arr img,
            Point center,
            int radius,
            Scalar color,
            int thickness,
            LineFlags line_type,
            int shift);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvEllipse(
            Arr img,
            Point center,
            Size axes,
            double angle,
            double start_angle,
            double end_angle,
            Scalar color,
            int thickness,
            LineFlags line_type,
            int shift);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvFillConvexPoly(
            Arr img,
            Point[] pts,
            int npts,
            Scalar color,
            LineFlags line_type,
            int shift);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvFillPoly(
            Arr img,
            IntPtr[] pts,
            int[] npts,
            int contours,
            Scalar color,
            LineFlags line_type,
            int shift);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvPolyLine(
            Arr img,
            IntPtr[] pts,
            int[] npts,
            int contours,
            int is_closed,
            Scalar color,
            int thickness,
            LineFlags line_type,
            int shift);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvClipLine(Size img_size, ref Point pt1, ref Point pt2);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvInitLineIterator(
            Arr image,
            Point pt1,
            Point pt2,
            out _CvLineIterator line_iterator,
            LineType connectivity,
            int left_to_right);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvInitFont(
            IntPtr font,
            FontFace font_face,
            double hscale,
            double vscale,
            double shear,
            int thickness,
            LineFlags line_type);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void cvPutText(Arr img, string text, Point org, Font font, Scalar color);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void cvGetTextSize(string text_string, Font font, out Size text_size, out int baseline);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Scalar cvColorToScalar(double packed_color, int arrtype);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvEllipse2Poly(
            Point center,
            Size axes,
            int angle,
            int arc_start,
            int arc_end,
            Point[] pts,
            int delta);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvDrawContours(
            Arr img,
            Seq contour,
            Scalar external_color,
            Scalar hole_color,
            int max_level,
            int thickness,
            LineFlags line_type,
            Point offset);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvLUT(Arr src, Arr dst, Arr lut);

        #endregion

        #region Data Persistence

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern IntPtr cvOpenFileStorage(string filename, MemStorage memstorage, StorageFlags flags, string encoding);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvReleaseFileStorage(ref IntPtr fs);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern string cvAttrValue(ref AttrList attr, string attr_name);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void cvStartWriteStruct(
            FileStorage fs,
            string name,
            StructStorageFlags struct_flags,
            string type_name,
            AttrList attributes);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvEndWriteStruct(FileStorage fs);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void cvWriteInt(FileStorage fs, string name, int value);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void cvWriteReal(FileStorage fs, string name, double value);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void cvWriteString(FileStorage fs, string name, string str, int quote);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void cvWriteComment(FileStorage fs, string comment, int eol_comment);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void cvWrite(FileStorage fs, string name, CVHandle ptr, AttrList attributes);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvStartNextStream(FileStorage fs);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void cvWriteRawData(FileStorage fs, IntPtr src, int len, string dt);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern StringHashNode cvGetHashedKey(
            FileStorage fs,
            string name,
            int len,
            int create_missing);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern FileNode cvGetRootFileNode(FileStorage fs, int stream_index);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern FileNode cvGetFileNode(
            FileStorage fs,
            FileNode map,
            StringHashNode key,
            int create_missing);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern FileNode cvGetFileNodeByName(FileStorage fs, FileNode map, string name);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvRead(FileStorage fs, FileNode node, IntPtr attributes);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void cvReadRawData(FileStorage fs, FileNode src, IntPtr dst, string dt);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void cvWriteFileNode(FileStorage fs, string new_node_name, FileNode node, int embed);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern IntPtr cvGetFileNodeName(FileNode node);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void cvSave(
            string filename,
            CVHandle struct_ptr,
            string name,
            string comment,
            AttrList attributes);

        [DllImport(coreLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern IntPtr cvLoad(
            string filename,
            MemStorage memstorage,
            string name,
            out IntPtr real_name);

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
        internal static extern IntPtr cvRedirectError(CvErrorCallback error_handler, IntPtr userdata, out IntPtr prevUserdata);

        internal static CvErrorCallback ErrorCallback;

        static NativeMethods()
        {
            IntPtr userData;
            ErrorCallback = ErrorExceptionCallback;
            cvRedirectError(ErrorCallback, IntPtr.Zero, out userData);
        }

        static int ErrorExceptionCallback(int status, string func_name, string err_msg, string file_name, int line, IntPtr userData)
        {
            throw new CVException(status, func_name, err_msg, file_name, line);
        }

        #endregion
    }
}
