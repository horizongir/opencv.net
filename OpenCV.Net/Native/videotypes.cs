using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net.Native
{
    [StructLayout(LayoutKind.Sequential)]
    struct _CvKalman
    {
        public int MP;
        public int DP;
        public int CP;

        public IntPtr PosterState;
        public IntPtr PriorState;
        public IntPtr DynamMatr;
        public IntPtr MeasurementMatr;
        public IntPtr MNCovariance;
        public IntPtr PNCovariance;
        public IntPtr KalmGainMatr;
        public IntPtr PriorErrorCovariance;
        public IntPtr PosterErrorCovariance;
        public IntPtr Temp1;
        public IntPtr Temp2;

        public IntPtr state_pre;
        public IntPtr state_post;
        public IntPtr transition_matrix;
        public IntPtr control_matrix;
        public IntPtr measurement_matrix;
        public IntPtr process_noise_cov;
        public IntPtr measurement_noise_cov;
        public IntPtr error_cov_pre;
        public IntPtr gain;
        public IntPtr error_cov_post;
        public IntPtr temp1;
        public IntPtr temp2;
        public IntPtr temp3;
        public IntPtr temp4;
        public IntPtr temp5;
    }
}
