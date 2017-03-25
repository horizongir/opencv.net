using OpenCV.Net.Native;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCV.Net
{
    public static partial class CV
    {
        public static void FAST(IplImage image, KeyPointCollection keyPoints, int threshold, bool nonMaxSuppression)
        {
            NativeMethods.cv_features2d_FAST(image, keyPoints, threshold, nonMaxSuppression);
        }

        public static void FAST(IplImage image, KeyPointCollection keyPoints, int threshold, bool nonMaxSuppression, int type)
        {
            NativeMethods.cv_features2d_FASTX(image, keyPoints, threshold, nonMaxSuppression, type);
        }
    }
}
