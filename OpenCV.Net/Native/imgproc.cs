using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net.Native
{
    static partial class NativeMethods
    {
        const string imgprocLib = "opencv_imgproc245";

        #region Background statistics accumulation

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvAcc(CvArr image, CvArr sum, CvArr mask);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSquareAcc(CvArr image, CvArr sqsum, CvArr mask);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvMultiplyAcc(CvArr image1, CvArr image2, CvArr acc, CvArr mask);

        [DllImport(imgprocLib, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvRunningAvg(CvArr image, CvArr acc, double alpha, CvArr mask);

        #endregion
    }
}
