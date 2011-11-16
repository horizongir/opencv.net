using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32.SafeHandles;
using OpenCV.Net.Native;
using System.Runtime.InteropServices;

namespace OpenCV.Net
{
    public sealed class CvKalman : SafeHandleZeroOrMinusOneIsInvalid
    {
        CvMat state_pre;
        CvMat state_post;
        CvMat transition_matrix;
        CvMat control_matrix;
        CvMat measurement_matrix;
        CvMat process_noise_cov;
        CvMat measurement_noise_cov;
        CvMat error_cov_pre;
        CvMat gain;
        CvMat error_cov_post;

        public CvKalman(int dynam_params, int measure_params, int control_params)
            : base(true)
        {
            var pKalman = video.cvCreateKalman(dynam_params, measure_params, control_params);
            SetHandle(pKalman);

            unsafe
            {
                state_pre = new CvMat(((_CvKalman*)handle.ToPointer())->state_pre, false);
                state_post = new CvMat(((_CvKalman*)handle.ToPointer())->state_post, false);
                transition_matrix = new CvMat(((_CvKalman*)handle.ToPointer())->transition_matrix, false);
                control_matrix = new CvMat(((_CvKalman*)handle.ToPointer())->control_matrix, false);
                measurement_matrix = new CvMat(((_CvKalman*)handle.ToPointer())->measurement_matrix, false);
                process_noise_cov = new CvMat(((_CvKalman*)handle.ToPointer())->process_noise_cov, false);
                measurement_noise_cov = new CvMat(((_CvKalman*)handle.ToPointer())->measurement_noise_cov, false);
                error_cov_pre = new CvMat(((_CvKalman*)handle.ToPointer())->error_cov_pre, false);
                gain = new CvMat(((_CvKalman*)handle.ToPointer())->gain, false);
                error_cov_post = new CvMat(((_CvKalman*)handle.ToPointer())->error_cov_post, false);
            }
        }

        public CvMat StatePredicted
        {
            get { return state_pre; }
        }

        public CvMat StateCorrected
        {
            get { return state_post; }
        }

        public CvMat TransitionMatrix
        {
            get { return transition_matrix; }
        }

        public CvMat ControlMatrix
        {
            get { return control_matrix; }
        }

        public CvMat MeasurementMatrix
        {
            get { return measurement_matrix; }
        }

        public CvMat ProcessNoiseCovariance
        {
            get { return process_noise_cov; }
        }

        public CvMat MeasurementNoiseCovariance
        {
            get { return measurement_noise_cov; }
        }

        public CvMat ErrorCovariancePrior
        {
            get { return error_cov_pre; }
        }

        public CvMat Gain
        {
            get { return gain; }
        }

        public CvMat ErrorCovariancePosterior
        {
            get { return error_cov_post; }
        }

        public CvMat Predict()
        {
            return Predict(null);
        }

        public CvMat Predict(CvMat control)
        {
            return new CvMat(video.cvKalmanPredict(handle, control ?? CvMat.Null), false);
        }

        public CvMat Correct(CvMat measurement)
        {
            return new CvMat(video.cvKalmanCorrect(handle, measurement), false);
        }

        protected override bool ReleaseHandle()
        {
            var pHandle = GCHandle.Alloc(handle, GCHandleType.Pinned);
            try
            {
                video.cvReleaseKalman(pHandle.AddrOfPinnedObject());
                return true;
            }
            finally { pHandle.Free(); }
        }
    }
}
