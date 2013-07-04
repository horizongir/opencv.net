using OpenCV.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCV.Net
{
    public static partial class cv
    {
        #region Background statistics accumulation

        /// <summary>
        /// Adds a frame to an accumulator.
        /// </summary>
        /// <param name="image">
        /// Input image, 1- or 3-channel, 8-bit or 32-bit floating point. Each channel of
        /// multi-channel image is processed independently.
        /// </param>
        /// <param name="sum">
        /// Accumulator with the same number of channels as input image, 32-bit or
        /// 64-bit floating-point.
        /// </param>
        /// <param name="mask">Optional operation mask.</param>
        public static void Acc(CvArr image, CvArr sum, CvArr mask = null)
        {
            NativeMethods.cvAcc(image, sum, mask ?? CvArr.Null);
        }

        /// <summary>
        /// Adds the square of the source image to the accumulator.
        /// </summary>
        /// <param name="image">
        /// Input image, 1- or 3-channel, 8-bit or 32-bit floating point. Each channel of
        /// multi-channel image is processed independently.
        /// </param>
        /// <param name="sqsum">
        /// Accumulator with the same number of channels as input image, 32-bit or
        /// 64-bit floating-point.
        /// </param>
        /// <param name="mask">Optional operation mask.</param>
        public static void SquareAcc(CvArr image, CvArr sqsum, CvArr mask = null)
        {
            NativeMethods.cvSquareAcc(image, sqsum, mask ?? CvArr.Null);
        }

        /// <summary>
        /// Adds the product of two input images to the accumulator.
        /// </summary>
        /// <param name="image1">
        /// First input image, 1- or 3-channel, 8-bit or 32-bit floating point. Each channel of
        /// multi-channel image is processed independently.
        /// </param>
        /// <param name="image2">Second input image, the same format as the first one.</param>
        /// <param name="acc">
        /// Accumulator with the same number of channels as input images, 32-bit or
        /// 64-bit floating-point.
        /// </param>
        /// <param name="mask">Optional operation mask.</param>
        public static void MultiplyAcc(CvArr image1, CvArr image2, CvArr acc, CvArr mask = null)
        {
            NativeMethods.cvMultiplyAcc(image1, image2, acc, mask ?? CvArr.Null);
        }

        /// <summary>
        /// Calculates the weighted sum of the input image <paramref name="image"/> and the
        /// accumulator <paramref name="acc"/> so that <paramref name="acc"/> becomes a running
        /// average of frame sequence.
        /// </summary>
        /// <param name="image">
        /// Input image, 1- or 3-channel, 8-bit or 32-bit floating point. Each channel of
        /// multi-channel image is processed independently.
        /// </param>
        /// <param name="acc">
        /// Accumulator with the same number of channels as input images, 32-bit or
        /// 64-bit floating-point.
        /// </param>
        /// <param name="alpha">
        /// Weight of the input image. This parameter regulates how fast the accumulator
        /// forgets about previous frames.
        /// </param>
        /// <param name="mask">Optional operation mask.</param>
        public static void RunningAvg(CvArr image, CvArr acc, double alpha, CvArr mask = null)
        {
            NativeMethods.cvRunningAvg(image, acc, alpha, mask ?? CvArr.Null);
        }

        #endregion
    }
}
