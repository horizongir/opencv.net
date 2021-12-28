using OpenCV.Net.Native;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a Kalman filter state.
    /// </summary>
    public class KalmanFilter : CVHandle    
    {
        Mat statePre;
        Mat statePost;
        Mat transitionMatrix;
        Mat controlMatrix;
        Mat measurementMatrix;
        Mat processNoiseCov;
        Mat measurementNoiseCov;
        Mat errorCovPre;
        Mat gain;
        Mat errorCovPost;

        /// <summary>
        /// Initializes a new instance of the <see cref="KalmanFilter"/> class with the specified dimensionality.
        /// </summary>
        /// <param name="dynamParams">Dimensionality of the state vector.</param>
        /// <param name="measureParams">Dimensionality of the measurement vector.</param>
        /// <param name="controlParams">Dimensionality of the control vector.</param>
        public KalmanFilter(int dynamParams, int measureParams, int controlParams)
            : base(true)
        {
            var pKalman = NativeMethods.cvCreateKalman(dynamParams, measureParams, controlParams);
            SetHandle(pKalman);

            unsafe
            {
                statePre = new Mat(((_CvKalman*)handle.ToPointer())->state_pre, false);
                statePost = new Mat(((_CvKalman*)handle.ToPointer())->state_post, false);
                transitionMatrix = new Mat(((_CvKalman*)handle.ToPointer())->transition_matrix, false);
                controlMatrix = new Mat(((_CvKalman*)handle.ToPointer())->control_matrix, false);
                measurementMatrix = new Mat(((_CvKalman*)handle.ToPointer())->measurement_matrix, false);
                processNoiseCov = new Mat(((_CvKalman*)handle.ToPointer())->process_noise_cov, false);
                measurementNoiseCov = new Mat(((_CvKalman*)handle.ToPointer())->measurement_noise_cov, false);
                errorCovPre = new Mat(((_CvKalman*)handle.ToPointer())->error_cov_pre, false);
                gain = new Mat(((_CvKalman*)handle.ToPointer())->gain, false);
                errorCovPost = new Mat(((_CvKalman*)handle.ToPointer())->error_cov_post, false);
            }
        }

        /// <summary>
        /// Gets the predicted state vector (x'(k)): x'(k) = A * x(k - 1) + B * u(k).
        /// </summary>
        public Mat StatePredicted
        {
            get { return statePre; }
        }

        /// <summary>
        /// Gets the corrected state vector (x(k)): x(k) = x'(k) + K(k) * (z(k) - H * x'(k))
        /// </summary>
        public Mat StateCorrected
        {
            get { return statePost; }
        }

        /// <summary>
        /// Gets the state transition matrix (A).
        /// </summary>
        public Mat TransitionMatrix
        {
            get { return transitionMatrix; }
        }

        /// <summary>
        /// Gets the control matrix (B). Not used if there is no control.
        /// </summary>
        public Mat ControlMatrix
        {
            get { return controlMatrix; }
        }

        /// <summary>
        /// Gets the measurement matrix (H).
        /// </summary>
        public Mat MeasurementMatrix
        {
            get { return measurementMatrix; }
        }

        /// <summary>
        /// Gets the process noise covariance matrix (Q).
        /// </summary>
        public Mat ProcessNoiseCovariance
        {
            get { return processNoiseCov; }
        }

        /// <summary>
        /// Gets the measurement noise covariance matrix (R).
        /// </summary>
        public Mat MeasurementNoiseCovariance
        {
            get { return measurementNoiseCov; }
        }

        /// <summary>
        /// Gets the prior error estimate covariance matrix (P'(k)): P'(k) = A * P(k - 1) * At + Q.
        /// </summary>
        public Mat ErrorCovariancePrior
        {
            get { return errorCovPre; }
        }

        /// <summary>
        /// Gets the Kalman gain matrix (K(k)): K(k) = P'(k) * Ht * inv(H * P'(k) * Ht + R).
        /// </summary>
        public Mat Gain
        {
            get { return gain; }
        }

        /// <summary>
        /// Gets the posterior error estimate covariance matrix (P(k)): P(k) = (I - K(k) * H) * P'(k).
        /// </summary>
        public Mat ErrorCovariancePosterior
        {
            get { return errorCovPost; }
        }

        /// <summary>
        /// Estimates the subsequent model state.
        /// </summary>
        /// <returns>The estimated state vector.</returns>
        public Mat Predict()
        {
            return Predict(null);
        }

        /// <summary>
        /// Estimates the subsequent model state.
        /// </summary>
        /// <param name="control">The control vector u(k) or <b>null</b> if there is no control.</param>
        /// <returns>The estimated state vector.</returns>
        public Mat Predict(Mat control)
        {
            return new Mat(NativeMethods.cvKalmanPredict(this, control ?? Mat.Null), false);
        }

        /// <summary>
        /// Adjusts the model state.
        /// </summary>
        /// <param name="measurement">The measurement vector z(k).</param>
        /// <returns>The adjusted state estimate.</returns>
        public Mat Correct(Mat measurement)
        {
            return new Mat(NativeMethods.cvKalmanCorrect(this, measurement), false);
        }

        /// <summary>
        /// Executes the code required to free the native <see cref="KalmanFilter"/> handle.
        /// </summary>
        /// <returns>
        /// <b>true</b> if the handle is released successfully; otherwise, in the event of a
        /// catastrophic failure, <b>false</b>.
        /// </returns>
        protected override bool ReleaseHandle()
        {
            NativeMethods.cvReleaseKalman(ref handle);
            return true;
        }
    }
}
