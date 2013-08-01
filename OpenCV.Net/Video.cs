using OpenCV.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCV.Net
{
    public static partial class cv
    {
        #region Motion Analysis

        /// <summary>
        /// Calculates the optical flow for a sparse feature set using the iterative Lucas-Kanade method with pyramids.
        /// </summary>
        /// <param name="prev">First frame.</param>
        /// <param name="curr">Second frame.</param>
        /// <param name="prevPyr">
        /// Buffer for the pyramid for the first frame. If it is not <b>null</b>, the buffer must have a sufficient
        /// size to store the pyramid from level 1 to level <paramref name="level"/>; the total size of
        /// (width + 8) * height / 3 bytes is sufficient.
        /// </param>
        /// <param name="currPyr">
        /// The same as <paramref name="prevPyr"/>, for the second frame.
        /// </param>
        /// <param name="prevFeatures">Array of points for which the flow needs to be found.</param>
        /// <param name="currFeatures">
        /// Array of 2D points containing the calculated new positions of the input features in the second image.
        /// </param>
        /// <param name="winSize">Size of the search window of each pyramid level.</param>
        /// <param name="level">
        /// Maximal pyramid level number. If 0 , pyramids are not used (single level), if 1, two levels are used, etc.
        /// </param>
        /// <param name="status">
        /// Every element of the status array is set to either 1, if the flow for the corresponding feature has been
        /// found, or 0 otherwise.
        /// </param>
        /// <param name="trackError">
        /// Array of numbers containing the difference between patches around the original and moved points.
        /// Optional parameter; can be <b>null</b>.
        /// </param>
        /// <param name="criteria">
        /// Specifies when the iteration process of finding the flow for each point on each pyramid level should be stopped.
        /// </param>
        /// <param name="flags">Specifies operation flags.</param>
        public static void CalcOpticalFlowPyrLK(
            CvArr prev,
            CvArr curr,
            CvArr prevPyr,
            CvArr currPyr,
            CvPoint2D32f[] prevFeatures,
            CvPoint2D32f[] currFeatures,
            CvSize winSize,
            int level,
            byte[] status,
            float[] trackError,
            CvTermCriteria criteria,
            LKFlowFlags flags)
        {
            NativeMethods.cvCalcOpticalFlowPyrLK(
                prev,
                curr,
                prevPyr,
                currPyr,
                prevFeatures,
                currFeatures,
                prevFeatures.Length,
                winSize,
                level,
                status,
                trackError,
                criteria,
                flags);
        }

        /// <summary>
        /// Calculates the affine optical flow for a sparse feature set using a modification of the iterative
        /// Lucas-Kanade method with pyramids.
        /// </summary>
        /// <param name="prev">First frame.</param>
        /// <param name="curr">Second frame.</param>
        /// <param name="prevPyr">
        /// Buffer for the pyramid for the first frame. If it is not <b>null</b>, the buffer must have a sufficient
        /// size to store the pyramid from level 1 to level <paramref name="level"/>; the total size of
        /// (width + 8) * height / 3 bytes is sufficient.
        /// </param>
        /// <param name="currPyr">
        /// The same as <paramref name="prevPyr"/>, for the second frame.
        /// </param>
        /// <param name="prevFeatures">Array of points for which the flow needs to be found.</param>
        /// <param name="currFeatures">
        /// Array of 2D points containing the calculated new positions of the input features in the second image.
        /// </param>
        /// <param name="matrices">
        /// The array of affine transformation matrices for each feature point. Matrices are stored sequentially with
        /// the format m(i) = [a00, a01, a10, a11] for each feature index, i.
        /// </param>
        /// <param name="winSize">Size of the search window of each pyramid level.</param>
        /// <param name="level">
        /// Maximal pyramid level number. If 0 , pyramids are not used (single level), if 1, two levels are used, etc.
        /// </param>
        /// <param name="status">
        /// Every element of the status array is set to either 1, if the flow for the corresponding feature has been
        /// found, or 0 otherwise.
        /// </param>
        /// <param name="trackError">
        /// Array of numbers containing the difference between patches around the original and moved points.
        /// Optional parameter; can be <b>null</b>.
        /// </param>
        /// <param name="criteria">
        /// Specifies when the iteration process of finding the flow for each point on each pyramid level should be stopped.
        /// </param>
        /// <param name="flags">Specifies operation flags.</param>
        public static void CalcAffineFlowPyrLK(
            CvArr prev,
            CvArr curr,
            CvArr prevPyr,
            CvArr currPyr,
            CvPoint2D32f[] prevFeatures,
            CvPoint2D32f[] currFeatures,
            float[] matrices,
            CvSize winSize,
            int level,
            byte[] status,
            float[] trackError,
            CvTermCriteria criteria,
            LKFlowFlags flags)
        {
            NativeMethods.cvCalcAffineFlowPyrLK(
                prev,
                curr,
                prevPyr,
                currPyr,
                prevFeatures,
                currFeatures,
                matrices,
                prevFeatures.Length,
                winSize,
                level,
                status,
                trackError,
                criteria,
                flags);
        }

        /// <summary>
        /// Estimates the optimal affine transformation between two images or two point sets.
        /// </summary>
        /// <param name="A">
        /// First input 2D point set stored as a <see cref="CvMat"/>, or an image.
        /// </param>
        /// <param name="B">
        /// Second input 2D point set of the same size and the same type as <paramref name="A"/>, or another image.
        /// </param>
        /// <param name="M">The output optimal 2x3 affine transformation matrix.</param>
        /// <param name="fullAffine">
        /// If <b>true</b>, the function finds an optimal affine transformation with no additional restrictions
        /// (6 degrees of freedom). Otherwise, the class of transformations to choose from is limited to
        /// combinations of translation, rotation, and uniform scaling (5 degrees of freedom).
        /// </param>
        /// <returns>
        /// <b>true</b> if the optimal affine transformation was successfully found; <b>false</b> otherwise.
        /// </returns>
        public static bool EstimateRigidTransform(CvArr A, CvArr B, CvMat M, bool fullAffine)
        {
            return NativeMethods.cvEstimateRigidTransform(A, B, M, fullAffine ? 1 : 0) > 0;
        }

        /// <summary>
        /// Computes dense optical flow using Gunnar Farneback’s algorithm.
        /// </summary>
        /// <param name="prev">The first 8-bit single-channel input image.</param>
        /// <param name="next">The second input image of the same size and the same type as <paramref name="prev"/>.</param>
        /// <param name="flow">
        /// The computed flow image; will have the same size as <paramref name="prev"/> and two 32-bit floating-point channels.
        /// </param>
        /// <param name="pyrScale">
        /// Specifies the image scale (less than 1) to build the pyramids for each image. 0.5 means the classical pyramid,
        /// where each next layer is twice smaller than the previous.
        /// </param>
        /// <param name="levels">
        /// The number of pyramid layers, including the initial image. 1 means that no extra layers are created and only
        /// the original images are used.
        /// </param>
        /// <param name="winSize">
        /// The averaging window size; The larger values increase the algorithm robustness to image noise and give more
        /// chances for fast motion detection, but yield a more blurred motion field.
        /// </param>
        /// <param name="iterations">The number of iterations the algorithm does at each pyramid level.</param>
        /// <param name="polyN">
        /// Size of the pixel neighborhood used to find polynomial expansion in each pixel. The larger values mean that
        /// the image will be approximated with smoother surfaces, yielding a more robust algorithm and a more blurred
        /// motion field. Typically, <paramref name="polyN"/> is set to 5 or 7.
        /// </param>
        /// <param name="polySigma">
        /// Standard deviation of the Gaussian that is used to smooth derivatives that are used as a basis for the
        /// polynomial expansion. For a <paramref name="polyN"/> of 5 you can set <paramref name="polySigma"/> to 1.1,
        /// while for a <paramref name="polyN"/> of 7 a good value would be 1.5.
        /// </param>
        /// <param name="flags">Specifies operation flags.</param>
        public static void CalcOpticalFlowFarneback(
            CvArr prev,
            CvArr next,
            CvArr flow,
            double pyrScale,
            int levels,
            int winSize,
            int iterations,
            int polyN,
            double polySigma,
            FarnebackFlowFlags flags)
        {
            NativeMethods.cvCalcOpticalFlowFarneback(
                prev,
                next,
                flow,
                pyrScale,
                levels,
                winSize,
                iterations,
                polyN,
                polySigma,
                flags);
        }

        #endregion

        #region Motion templates

        /// <summary>
        /// Updates the motion history image by a moving silhouette.
        /// </summary>
        /// <param name="silhouette">Silhouette mask that has non-zero pixels where the motion occurs.</param>
        /// <param name="mhi">
        /// Motion history image, that is updated by the function (single-channel, 32-bit floating-point).
        /// </param>
        /// <param name="timestamp">Current time in milliseconds or other units.</param>
        /// <param name="duration">Maximal duration of the motion track in the same units as <paramref name="timestamp"/>.</param>
        public static void UpdateMotionHistory(CvArr silhouette, CvArr mhi, double timestamp, double duration)
        {
            NativeMethods.cvUpdateMotionHistory(silhouette, mhi, timestamp, duration);
        }

        /// <summary>
        /// Calculates the gradient orientation of a motion history image.
        /// </summary>
        /// <param name="mhi">Motion history image.</param>
        /// <param name="mask">Output mask image with non-zero pixels where the motion gradient data is correct.</param>
        /// <param name="orientation">Motion gradient orientation image; contains angles from 0 to 360 degrees.</param>
        /// <param name="delta1">
        /// The minimal or maximal gradient threshold used to determine whether a given pixel motion gradient data
        /// is correct.
        /// </param>
        /// <param name="delta2">
        /// The minimal or maximal gradient threshold used to determine whether a given pixel motion gradient data
        /// is correct.
        /// </param>
        /// <param name="apertureSize">
        /// Aperture size of derivative operators used by the function. See <see cref="Sobel"/>.
        /// </param>
        public static void CalcMotionGradient(
            CvArr mhi,
            CvArr mask,
            CvArr orientation,
            double delta1,
            double delta2,
            int apertureSize = 3)
        {
            NativeMethods.cvCalcMotionGradient(mhi, mask, orientation, delta1, delta2, apertureSize);
        }

        /// <summary>
        /// Calculates the global motion orientation of some selected region.
        /// </summary>
        /// <param name="orientation">Motion gradient orientation image calculated by <see cref="CalcMotionGradient"/>.</param>
        /// <param name="mask">
        /// Mask image. It may be a conjunction of a valid gradient mask, obtained with <see cref="CalcMotionGradient"/>
        /// and the mask of the region, whose direction needs to be calculated.
        /// </param>
        /// <param name="mhi">Motion history image.</param>
        /// <param name="timestamp">Current time in milliseconds or other units.</param>
        /// <param name="duration">Maximal duration of the motion track in the same units as <paramref name="timestamp"/>.</param>
        /// <returns>
        /// The general motion direction angle in the selected region, between 0 degrees and 360 degrees.
        /// </returns>
        public static double CalcGlobalOrientation(
            CvArr orientation,
            CvArr mask,
            CvArr mhi,
            double timestamp,
            double duration)
        {
            return NativeMethods.cvCalcGlobalOrientation(orientation, mask, mhi, timestamp, duration);
        }

        /// <summary>
        /// Segments a whole motion into separate moving parts.
        /// </summary>
        /// <param name="mhi">Motion history image.</param>
        /// <param name="segMask">
        /// Output image where the segmentation mask should be stored, single-channel, 32-bit floating-point.
        /// Different motion segments are marked with individual values (1,2,...).
        /// </param>
        /// <param name="storage">Memory storage that will contain a sequence of motion connected components.</param>
        /// <param name="timestamp">Current time in milliseconds or other units.</param>
        /// <param name="segThresh">
        /// Segmentation threshold; recommended to be equal to the interval between motion history “steps” or greater.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="CvConnectedComp"/> structures, one for each motion component. The motion direction
        /// for every component can be calculated with <see cref="CalcGlobalOrientation"/> using the extracted mask of
        /// the particular component.
        /// </returns>
        public static CvSeq SegmentMotion(
            CvArr mhi,
            CvArr segMask,
            CvMemStorage storage,
            double timestamp,
            double segThresh)
        {
            var motion = NativeMethods.cvSegmentMotion(mhi, segMask, storage, timestamp, segThresh);
            if (motion.IsInvalid) return null;
            motion.SetOwnerStorage(storage);
            return motion;
        }

        #endregion

        #region Tracking

        /// <summary>
        /// Finds the object center, size, and orientation.
        /// </summary>
        /// <param name="probImage">Back projection of object histogram (see <see cref="CvHistogram.CalcArrBackProject"/>).</param>
        /// <param name="window">Initial search window.</param>
        /// <param name="criteria">Criteria applied to determine when the window search should be finished.</param>
        /// <param name="comp">
        /// Resultant structure that contains the converged search window coordinates (<see cref="CvConnectedComp.Rect"/> field)
        /// and the sum of all of the pixels inside the window (<see cref="CvConnectedComp.Area"/> field).
        /// </param>
        /// <returns><b>true</b> if the search was successful; <b>false</b> otherwise.</returns>
        public static bool CamShift(
            CvArr probImage,
            CvRect window,
            CvTermCriteria criteria,
            out CvConnectedComp comp)
        {
            CvBox2D box;
            return NativeMethods.cvCamShift(probImage, window, criteria, out comp, out box) > 0;
        }

        /// <summary>
        /// Finds the object center, size, and orientation.
        /// </summary>
        /// <param name="probImage">Back projection of object histogram (see <see cref="CvHistogram.CalcArrBackProject"/>).</param>
        /// <param name="window">Initial search window.</param>
        /// <param name="criteria">Criteria applied to determine when the window search should be finished.</param>
        /// <param name="comp">
        /// Resultant structure that contains the converged search window coordinates (<see cref="CvConnectedComp.Rect"/> field)
        /// and the sum of all of the pixels inside the window (<see cref="CvConnectedComp.Area"/> field).
        /// </param>
        /// <param name="box">Circumscribed box for the object.</param>
        /// <returns><b>true</b> if the search was successful; <b>false</b> otherwise.</returns>
        public static bool CamShift(
            CvArr probImage,
            CvRect window,
            CvTermCriteria criteria,
            out CvConnectedComp comp,
            out CvBox2D box)
        {
            return NativeMethods.cvCamShift(probImage, window, criteria, out comp, out box) > 0;
        }

        /// <summary>
        /// Finds the object center on back projection.
        /// </summary>
        /// <param name="probImage">Back projection of object histogram (see <see cref="CvHistogram.CalcArrBackProject"/>).</param>
        /// <param name="window">Initial search window.</param>
        /// <param name="criteria">Criteria applied to determine when the window search should be finished.</param>
        /// <param name="comp">
        /// Resultant structure that contains the converged search window coordinates (<see cref="CvConnectedComp.Rect"/> field)
        /// and the sum of all of the pixels inside the window (<see cref="CvConnectedComp.Area"/> field).
        /// </param>
        /// <returns><b>true</b> if the search was successful; <b>false</b> otherwise.</returns>
        public static bool MeanShift(CvArr probImage, CvRect window, CvTermCriteria criteria, out CvConnectedComp comp)
        {
            return NativeMethods.cvMeanShift(probImage, window, criteria, out comp) > 0;
        }

        #endregion
    }
}
