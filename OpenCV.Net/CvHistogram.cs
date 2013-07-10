using Microsoft.Win32.SafeHandles;
using OpenCV.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a multi-dimensional histogram.
    /// </summary>
    public sealed class CvHistogram : SafeHandleZeroOrMinusOneIsInvalid
    {
        readonly CvArr bins;

        internal CvHistogram()
            : base(true)
        {
        }

        internal CvHistogram(IntPtr handle)
            : base(true)
        {
            SetHandle(handle);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvHistogram"/> class with the
        /// specified size.
        /// </summary>
        /// <param name="dims">Number of histogram dimensions.</param>
        /// <param name="sizes">Array of the histogram dimension sizes.</param>
        /// <param name="type">Histogram representation format.</param>
        /// <param name="ranges">Array of ranges for the histogram bins.</param>
        /// <param name="uniform">
        /// If <b>true</b> the histogram has evenly spaced bins and for each dimension, <paramref name="ranges"/>
        /// contains its lower and upper boundaries which are then used to split the dimension into equally sized bins.
        /// Otherwise, <paramref name="ranges"/> specifies for each dimension the edges of each bin.
        /// </param>
        public CvHistogram(int dims, int[] sizes, HistogramType type, float[][] ranges = null, bool uniform = true)
            : base(true)
        {
            ConvertRanges(ranges, pRanges =>
            {
                var pHist = NativeMethods.cvCreateHist(dims, sizes, type, pRanges, uniform ? 1 : 0);
                SetHandle(pHist);
            });

            unsafe
            {
                bins = new CvMat(((_CvHistogram*)handle.ToPointer())->bins, false);
            }
        }

        /// <summary>
        /// Sets the bounds of the histogram bins.
        /// </summary>
        /// <param name="ranges">Array of ranges for the histogram bins.</param>
        /// <param name="uniform">
        /// If <b>true</b> the histogram has evenly spaced bins and for each dimension, <paramref name="ranges"/>
        /// contains its lower and upper boundaries which are then used to split the dimension into equally sized bins.
        /// Otherwise, <paramref name="ranges"/> specifies for each dimension the edges of each bin.
        /// </param>
        public void SetBinRanges(float[][] ranges, bool uniform = true)
        {
            ConvertRanges(ranges, pRanges => NativeMethods.cvSetHistBinRanges(this, pRanges, uniform ? 1 : 0));
        }

        void ConvertRanges(float[][] ranges, Action<IntPtr[]> action)
        {
            var handles = ranges != null ? Array.ConvertAll(ranges, range => GCHandle.Alloc(range, GCHandleType.Pinned)) : null;
            var pRanges = handles != null ? Array.ConvertAll(handles, handle => handle.AddrOfPinnedObject()) : null;
            try { action(pRanges); }
            finally { if (handles != null) Array.ForEach(handles, h => h.Free()); }
        }

        /// <summary>
        /// Clears the histogram.
        /// </summary>
        public void Clear()
        {
            NativeMethods.cvClearHist(this);
        }
        
        /// <summary>
        /// Finds the minimum and maximum histogram bins.
        /// </summary>
        /// <param name="minValue">The output minimum value of the histogram.</param>
        /// <param name="maxValue">The output maximum value of the histogram.</param>
        /// <param name="minIdx">The array of coordinates for the minimum.</param>
        /// <param name="maxIdx">The array of coordinates for the maximum.</param>
        public void GetMinMaxValue(out float minValue, out float maxValue, int[] minIdx = null, int[] maxIdx = null)
        {
            NativeMethods.cvGetMinMaxHistValue(this, out minValue, out maxValue, minIdx, maxIdx);
        }

        /// <summary>
        /// Normalizes the histogram such that the sum of the bins is equal to <paramref name="factor"/>.
        /// </summary>
        /// <param name="factor">Normalization factor.</param>
        public void Normalize(double factor)
        {
            NativeMethods.cvNormalizeHist(this, factor);
        }

        /// <summary>
        /// Thresholds the histogram by clearing histogram bins that are below the
        /// specified <paramref name="threshold"/>.
        /// </summary>
        /// <param name="threshold">Threshold level.</param>
        public void Threshold(double threshold)
        {
            NativeMethods.cvThreshHist(this, threshold);
        }

        /// <summary>
        /// Compares this histogram with another dense histogram.
        /// </summary>
        /// <param name="other">The second dense histogram.</param>
        /// <param name="method">The comparison method to be used.</param>
        /// <returns>The distance between the two histograms.</returns>
        public double Compare(CvHistogram other, HistogramComparison method)
        {
            return NativeMethods.cvCompareHist(this, other, method);
        }

        /// <summary>
        /// Copies the histogram. The method copies this histogram’s bin values to the
        /// destination histogram and sets the same bin value ranges as this instance.
        /// </summary>
        /// <param name="dst">The destination histogram.</param>
        public void Copy(out CvHistogram dst)
        {
            NativeMethods.cvCopyHist(this, out dst);
        }

        /// <summary>
        /// Creates a new <see cref="CvHistogram"/> that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new <see cref="CvHistogram"/> that is a copy of this instance.
        /// </returns>
        public CvHistogram Clone()
        {
            CvHistogram hist;
            Copy(out hist);
            return hist;
        }

        /// <summary>
        /// Calculates the histogram of image(s).
        /// </summary>
        /// <param name="images">Source images.</param>
        /// <param name="accumulate">
        /// If <b>true</b>, the histogram is not cleared in the beginning. This feature
        /// allows the user to compute a single histogram from several images, or to
        /// update the histogram online.
        /// </param>
        /// <param name="mask">
        /// The operation mask, determines what pixels of the source images are counted.
        /// </param>
        public void CalcArrHist(CvArr[] images, bool accumulate = false, CvArr mask = null)
        {
            var pImages = Array.ConvertAll(images, image => image.DangerousGetHandle());
            NativeMethods.cvCalcArrHist(pImages, this, accumulate ? 1 : 0, mask ?? CvArr.Null);
            GC.KeepAlive(images);
        }

        /// <summary>
        /// Calculates the back projection.
        /// </summary>
        /// <param name="images">Source images.</param>
        /// <param name="dst">
        /// Destination back projection image of the same type as the source <paramref name="images"/>.
        /// </param>
        public void CalcArrBackProject(CvArr[] images, CvArr dst)
        {
            var pImages = Array.ConvertAll(images, image => image.DangerousGetHandle());
            NativeMethods.cvCalcArrBackProject(pImages, dst, this);
            GC.KeepAlive(images);
        }

        /// <summary>
        /// Locates a template within an image by using a histogram comparison.
        /// </summary>
        /// <param name="images">Source images.</param>
        /// <param name="dst">Destination image.</param>
        /// <param name="range">Size of the patch slid though the source image.</param>
        /// <param name="method">The histogram comparison method.</param>
        /// <param name="factor">Normalization factor for histograms.</param>
        public void CalcArrBackProjectPatch(
            CvArr[] images,
            CvArr dst,
            CvSize range,
            HistogramComparison method,
            double factor)
        {
            var pImages = Array.ConvertAll(images, image => image.DangerousGetHandle());
            NativeMethods.cvCalcArrBackProjectPatch(pImages, dst, range, this, method, factor);
            GC.KeepAlive(images);
        }

        /// <summary>
        /// Divides one histogram by another and stores the result in this instance.
        /// </summary>
        /// <param name="hist1">First histogram (the divisor).</param>
        /// <param name="hist2">Second histogram.</param>
        /// <param name="scale">Scale factor.</param>
        public void CalcProbDensity(
            CvHistogram hist1,
            CvHistogram hist2,
            double scale = 255)
        {
            NativeMethods.cvCalcProbDensity(hist1, hist2, this, scale);
        }

        /// <summary>
        /// Queries the value of the histogram bin.
        /// </summary>
        /// <param name="idx0">The index of the bin.</param>
        /// <returns>The value of the specified bin.</returns>
        public double QueryValue(int idx0)
        {
            unsafe
            {
                return NativeMethods.cvGetReal1D(bins, idx0);
            }
        }

        /// <summary>
        /// Queries the value of the histogram bin.
        /// </summary>
        /// <param name="idx0">The first index of the bin.</param>
        /// <param name="idx1">The second index of the bin.</param>
        /// <returns>The value of the specified bin.</returns>
        public double QueryValue(int idx0, int idx1)
        {
            unsafe
            {
                return NativeMethods.cvGetReal2D(bins, idx0, idx1);
            }
        }

        /// <summary>
        /// Queries the value of the histogram bin.
        /// </summary>
        /// <param name="idx0">The first index of the bin.</param>
        /// <param name="idx1">The second index of the bin.</param>
        /// <param name="idx2">The third index of the bin.</param>
        /// <returns>The value of the specified bin.</returns>
        public double QueryValue(int idx0, int idx1, int idx2)
        {
            unsafe
            {
                return NativeMethods.cvGetReal3D(bins, idx0, idx1, idx2);
            }
        }

        /// <summary>
        /// Executes the code required to free the native <see cref="CvHistogram"/> handle.
        /// </summary>
        /// <returns>
        /// <b>true</b> if the handle is released successfully; otherwise, in the event of a
        /// catastrophic failure, <b>false</b>.
        /// </returns>
        protected override bool ReleaseHandle()
        {
            NativeMethods.cvReleaseHist(ref handle);
            return true;
        }
    }
}
