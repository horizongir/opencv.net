using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32.SafeHandles;
using OpenCV.Net.Native;

namespace OpenCV.Net
{
    public abstract class CvArr : SafeHandleZeroOrMinusOneIsInvalid
    {
        public static readonly CvArr Null = new CvArrNull();

        protected CvArr()
            : base(true)
        {
        }

        protected CvArr(bool ownsHandle)
            : base(ownsHandle)
        {
        }

        public void SetZero()
        {
            core.cvSetZero(this);
        }

        public void SetData(IntPtr data, int step)
        {
            core.cvSetData(this, data, step);
        }

        public void GetRawData(out IntPtr data)
        {
            int step;
            CvSize roiSize;
            core.cvGetRawData(this, out data, out step, out roiSize);
        }

        public void GetRawData(out IntPtr data, out int step)
        {
            CvSize roiSize;
            core.cvGetRawData(this, out data, out step, out roiSize);
        }

        public void GetRawData(out IntPtr data, out int step, out CvSize roiSize)
        {
            core.cvGetRawData(this, out data, out step, out roiSize);
        }

        class CvArrNull : CvArr
        {
            public CvArrNull() : base(false) { }

            protected override bool ReleaseHandle()
            {
                return false;
            }
        }
    }
}
