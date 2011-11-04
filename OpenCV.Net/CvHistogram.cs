using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using OpenCV.Net.Native;

namespace OpenCV.Net
{
    public sealed class CvHistogram : SafeHandleZeroOrMinusOneIsInvalid
    {
        internal CvHistogram()
            : base(true)
        {
        }

        public CvHistogram(int dims, int[] sizes, HistogramType type)
            : this(dims, sizes, type, null, true)
        {
        }

        public CvHistogram(int dims, int[] sizes, HistogramType type, float[][] ranges)
            : this(dims, sizes, type, ranges, true)
        {
        }

        public CvHistogram(int dims, int[] sizes, HistogramType type, float[][] ranges, bool uniform)
            : base(true)
        {
            GCHandle[] handles = ranges != null ? new GCHandle[ranges.Length] : null;
            IntPtr[] pRanges = ranges != null ? new IntPtr[ranges.Length] : null;
            if (pRanges != null)
            {
                for (int i = 0; i < ranges.Length; i++)
                {
                    handles[i] = GCHandle.Alloc(ranges[i], GCHandleType.Pinned);
                    pRanges[i] = handles[i].AddrOfPinnedObject();
                }
            }

            try
            {
                var pHist = imgproc.cvCreateHist(dims, sizes, type, pRanges, uniform ? 1 : 0);
                SetHandle(pHist);
            }
            finally { if (handles != null) Array.ForEach(handles, h => h.Free()); }
        }

        public void GetMinMaxHistValue(out float min_value, out float max_value, int[] min_idx, int[] max_idx)
        {
            imgproc.cvGetMinMaxHistValue(this, out min_value, out max_value, min_idx, max_idx);
        }

        public void NormalizeHist(double factor)
        {
            imgproc.cvNormalizeHist(this, factor);
        }

        public double QueryHistValue(int idx0)
        {
            unsafe
            {
                return core.cvGetReal1D(((_CvHistogram*)handle.ToPointer())->bins, idx0);
            }
        }

        public double QueryHistValue(int idx0, int idx1)
        {
            unsafe
            {
                return core.cvGetReal2D(((_CvHistogram*)handle.ToPointer())->bins, idx0, idx1);
            }
        }

        public double QueryHistValue(int idx0, int idx1, int idx2)
        {
            unsafe
            {
                return core.cvGetReal3D(((_CvHistogram*)handle.ToPointer())->bins, idx0, idx1, idx2);
            }
        }

        protected override bool ReleaseHandle()
        {
            var pHandle = GCHandle.Alloc(handle, GCHandleType.Pinned);
            try
            {
                imgproc.cvReleaseHist(pHandle.AddrOfPinnedObject());
                return true;
            }
            finally { pHandle.Free(); }
        }
    }
}
