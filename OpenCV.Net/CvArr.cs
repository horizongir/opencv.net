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
            : this(true)
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
