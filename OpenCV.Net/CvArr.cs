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
        protected CvArr()
            : base(true)
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
    }
}
