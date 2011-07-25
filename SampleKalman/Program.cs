using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCV.Net;
using System.Runtime.InteropServices;

namespace SampleKalman
{
    class Program
    {
        static void draw_cross(IplImage img, CvPoint center, CvScalar color, float d)
        {
            Core.cvLine(img,
                new CvPoint(center.X - d, center.Y - d),
                new CvPoint(center.X + d, center.Y + d),
                color, 1, 8, 0);

            Core.cvLine(img,
                new CvPoint(center.X + d, center.Y - d),
                new CvPoint(center.X - d, center.Y + d),
                color, 1, 8, 0);
        }

        static CvPoint calc_point(IplImage img, double angle)
        {
            return new CvPoint(
                Math.Round(img.Width / 2 + img.Width / 3 * Math.Cos(angle)),
                Math.Round(img.Height / 2 - img.Width / 3 * Math.Sin(angle)));
        }

        unsafe static void Main(string[] args)
        {
            float[] A = new float[] { 1, 1, 0, 1 };

            IplImage img = new IplImage(new CvSize(500, 500), 8, 3);
            CvKalman kalman = new CvKalman(2, 1, 0);

            /* state is (phi, delta_phi) - angle and angle increment */
            CvMat state = new CvMat(2, 1, CvMatDepth.CV_32F, 1);
            CvMat process_noise = new CvMat(2, 1, CvMatDepth.CV_32F, 1);

            /* only phi (angle) is measured */
            CvMat measurement = new CvMat(1, 1, CvMatDepth.CV_32F, 1);
            CvRNG rng = new CvRNG(-1);
            int code = -1;

            measurement.SetZero();
            var kalman_window = new NamedWindow("Kalman", WindowFlags.AUTOSIZE);

            for (; ; )
            {
                Core.cvRandArr(ref rng, state, CvRandDistribution.Normal, CvScalar.Real(0), CvScalar.Real(0.1));

                Marshal.Copy(A, 0, kalman.TransitionMatrix.Data, A.Length);
                Core.cvSetIdentity(kalman.MeasurementMatrix, CvScalar.Real(1));
                Core.cvSetIdentity(kalman.ProcessNoiseCovariance, CvScalar.Real(1e-5));
                Core.cvSetIdentity(kalman.MeasurementNoiseCovariance, CvScalar.Real(1e-1));
                Core.cvSetIdentity(kalman.ErrorCovariancePosterior, CvScalar.Real(1));
                /* choose random initial state */
                Core.cvRandArr(ref rng, kalman.StateCorrected, CvRandDistribution.Normal, CvScalar.Real(0), CvScalar.Real(0.1));

                for (; ; )
                {
                    float state_angle = ((float*)state.Data)[0];
                    CvPoint state_pt = calc_point(img, state_angle);

                    /* predict point position */
                    CvMat prediction = kalman.Predict();
                    float predict_angle = ((float*)prediction.Data)[0];
                    CvPoint predict_pt = calc_point(img, predict_angle);
                    float measurement_angle;
                    CvPoint measurement_pt;

                    Core.cvRandArr(ref rng,
                        measurement, CvRandDistribution.Normal,
                        CvScalar.Real(0),
                        CvScalar.Real(Math.Sqrt(((float*)kalman.MeasurementNoiseCovariance.Data)[0])));

                    /* generate measurement */
                    Core.cvMatMulAdd(kalman.MeasurementMatrix, state, measurement, measurement);

                    measurement_angle = ((float*)measurement.Data)[0];
                    measurement_pt = calc_point(img, measurement_angle);

                    /* plot points */
                    img.SetZero();
                    draw_cross(img, state_pt, CvScalar.Rgb(255, 255, 255), 3);
                    draw_cross(img, measurement_pt, CvScalar.Rgb(255, 0, 0), 3);
                    draw_cross(img, predict_pt, CvScalar.Rgb(0, 255, 0), 3);
                    Core.cvLine(img, state_pt, predict_pt, CvScalar.Rgb(255, 255, 0), 3, 8, 0);

                    /* adjust Kalman filter state */
                    kalman.Correct(measurement);

                    Core.cvRandArr(ref rng,
                        process_noise, CvRandDistribution.Normal,
                        CvScalar.Real(0),
                        CvScalar.Real(Math.Sqrt(((float*)kalman.ProcessNoiseCovariance.Data)[0])));
                    Core.cvMatMulAdd(kalman.TransitionMatrix,
                                 state,
                                 process_noise,
                                 state);

                    kalman_window.ShowImage(img);
                    code = HighGui.cvWaitKey(100);

                    if (code > 0) /* break current simulation by pressing a key */
                        break;
                }

                if (code == 27) /* exit by ESCAPE */
                    break;
            }
        }
    }
}
