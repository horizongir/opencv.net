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
        int dp;
        int mp;
        int samplesNum;
        IntPtr dynamMatr;
        IntPtr state;
        IntPtr flNewSamples;
        IntPtr flCumulative;

        public CvConDensation(int dynam_params, int measure_params, int sample_count)
            : base(true)
        {
            var pCondens = legacy.cvCreateConDensation(dynam_params, measure_params, sample_count);
            SetHandle(pCondens);

            unsafe
            {
                dp = ((_CvConDensation*)handle.ToPointer())->DP;
                mp = ((_CvConDensation*)handle.ToPointer())->MP;
                samplesNum = ((_CvConDensation*)handle.ToPointer())->SamplesNum;
                dynamMatr = (IntPtr)((_CvConDensation*)handle.ToPointer())->DynamMatr;
                state = (IntPtr)((_CvConDensation*)handle.ToPointer())->State;
                flNewSamples = (IntPtr)((_CvConDensation*)handle.ToPointer())->flNewSamples;
                flCumulative = (IntPtr)((_CvConDensation*)handle.ToPointer())->flCumulative;
            }
        }

        public int DP
        {
            get { return dp; }
        }

        public int MP
        {
            get { return mp; }
        }

        public int SamplesNum
        {
            get { return samplesNum; }
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
            get
            {
                unsafe { return (IntPtr)((_CvConDensation*)handle.ToPointer())->flSamples; }
            }
        }

        public IntPtr NewSamples
        {
            get { return flNewSamples; }
        }

        public IntPtr Confidence
        {
            get
            {
                unsafe { return (IntPtr)((_CvConDensation*)handle.ToPointer())->flConfidence; }
            }
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
