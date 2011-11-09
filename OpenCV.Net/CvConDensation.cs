using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using OpenCV.Net.Native;

namespace OpenCV.Net
{
    public class CvConDensation : SafeHandleZeroOrMinusOneIsInvalid
    {
        IntPtr dynamMatr;
        IntPtr state;
        IntPtr flSamples;
        IntPtr flNewSamples;
        IntPtr flConfidence;
        IntPtr flCumulative;

        public CvConDensation(int dynam_params, int measure_params, int sample_count)
            : base(true)
        {
            var pCondens = legacy.cvCreateConDensation(dynam_params, measure_params, sample_count);
            SetHandle(pCondens);

            unsafe
            {
                dynamMatr = (IntPtr)((_CvConDensation*)handle.ToPointer())->DynamMatr;
                state = (IntPtr)((_CvConDensation*)handle.ToPointer())->State;
                flSamples = (IntPtr)((_CvConDensation*)handle.ToPointer())->flSamples;
                flNewSamples = (IntPtr)((_CvConDensation*)handle.ToPointer())->flNewSamples;
                flConfidence = (IntPtr)((_CvConDensation*)handle.ToPointer())->flConfidence;
                flCumulative = (IntPtr)((_CvConDensation*)handle.ToPointer())->flCumulative;
            }
        }

        public IntPtr DynamMatr
        {
            get { return dynamMatr; }
        }

        public IntPtr State
        {
            get { return state; }
        }

        public IntPtr Samples
        {
            get { return flSamples; }
        }

        public IntPtr NewSamples
        {
            get { return flNewSamples; }
        }

        public IntPtr Confidence
        {
            get { return flConfidence; }
        }

        public IntPtr Cumulative
        {
            get { return flCumulative; }
        }

        public void UpdateByTime()
        {
            legacy.cvConDensUpdateByTime(this);
        }

        public void InitSampleSet(CvMat lower_bound, CvMat upper_bound)
        {
            legacy.cvConDensInitSampleSet(this, lower_bound, upper_bound);
        }

        protected override bool ReleaseHandle()
        {
            var pHandle = GCHandle.Alloc(handle, GCHandleType.Pinned);
            try
            {
                legacy.cvReleaseConDensation(pHandle.AddrOfPinnedObject());
                return true;
            }
            finally { pHandle.Free(); }
        }
    }
}
