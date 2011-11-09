﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OpenCV.Net.Native
{
    static class legacy
    {
        const string libName = "opencv_legacy231";

        [DllImport(libName)]
        public static extern IntPtr cvCreateConDensation(int dynam_params, int measure_params, int sample_count);

        [DllImport(libName)]
        public static extern void cvReleaseConDensation(IntPtr condens);

        [DllImport(libName)]
        public static extern void cvConDensUpdateByTime(CvConDensation condens);

        [DllImport(libName)]
        public static extern void cvConDensInitSampleSet(CvConDensation condens, CvMat lower_bound, CvMat upper_bound);
    }
}