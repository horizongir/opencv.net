using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net.Native
{
    static partial class NativeMethods
    {
        const string objdetectLib = "opencv_objdetect246";

        #region Haar-like Object Detection functions

        [DllImport(objdetectLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvReleaseHaarClassifierCascade(ref IntPtr cascade);

        [DllImport(objdetectLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CvSeq cvHaarDetectObjects(
            CvArr image,
            CvHaarClassifierCascade cascade,
            CvMemStorage storage,
            double scale_factor,
            int min_neighbors,
            HaarDetectObjectFlags flags,
            CvSize min_size,
            CvSize max_size);

        #endregion
    }
}
