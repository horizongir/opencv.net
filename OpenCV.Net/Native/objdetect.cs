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
        internal static extern Seq cvHaarDetectObjects(
            Arr image,
            HaarClassifierCascade cascade,
            MemStorage storage,
            double scale_factor,
            int min_neighbors,
            HaarDetectObjectFlags flags,
            Size min_size,
            Size max_size);

        #endregion

        #region Object Detection using Latent SVM

        [DllImport(objdetectLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern LatentSvmDetector cvLoadLatentSvmDetector(string filename);

        [DllImport(objdetectLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvReleaseLatentSvmDetector(ref IntPtr detector);

        [DllImport(objdetectLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Seq cvLatentSvmDetectObjects(
            IplImage image,
            LatentSvmDetector detector,
            MemStorage storage,
            float overlap_threshold,
            int numThreads);

        #endregion
    }
}
