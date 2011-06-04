using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OpenCV.Net
{
    public static class Core
    {
        const string libName = "opencv_core220";

        [DllImport(libName)]
        public static extern void cvAbsDiff(CvArr src1, CvArr src2, CvArr dst);

        [DllImport(libName)]
        public static extern void cvAnd(CvArr src1, CvArr src2, CvArr dst, CvArr mask);

        [DllImport(libName)]
        public static extern void cvCopy(CvArr src, CvArr dst, CvArr mask);

        [DllImport(libName)]
        public static extern void cvSplit(CvArr src, CvArr dst0, CvArr dst1, CvArr dst2, CvArr dst3);

        [DllImport(libName)]
        public static extern void cvSub(CvArr src1, CvArr src2, CvArr dst, CvArr mask);

        [DllImport(libName)]
        public static extern CvScalar cvSum(CvArr arr);

        [DllImport(libName)]
        public static extern void cvCmpS(CvArr src, double value, CvArr dst, int cmp_op);

        [DllImport(libName)]
        public static extern void cvDrawContours(
            CvArr img,
            CvSeq contour,
            CvScalar external_color,
            CvScalar hole_color,
            int max_level,
            int thickness,// = 1
            int lineType,// = 8
            CvPoint offset);//= CvPoint(0,0)

        [DllImport(libName)]
        public static extern void cvRectangle(
            CvArr img,
            CvPoint pt1,
            CvPoint pt2,
            CvScalar color,
            int thickness,// = 1
            int lineType,// = 8
            int shift);// = 0

        [DllImport(libName)]
        public static extern int cvGetErrStatus();

        [DllImport(libName)]
        public static extern string cvErrorStr(int status);

        [DllImport(libName)]
        [return:MarshalAs(UnmanagedType.FunctionPtr)]
        public static extern CvErrorCallback cvRedirectError([MarshalAs(UnmanagedType.FunctionPtr)]CvErrorCallback error_handler, IntPtr userdata, out IntPtr prevUserdata);
    }
}
