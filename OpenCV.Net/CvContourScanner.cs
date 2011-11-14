using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32.SafeHandles;
using OpenCV.Net.Native;
using System.Runtime.InteropServices;

namespace OpenCV.Net
{
    public sealed class CvContourScanner : SafeHandleZeroOrMinusOneIsInvalid
    {
        public CvContourScanner()
            : base(true)
        {
        }

        public CvSeq FindNextContour()
        {
            return imgproc.cvFindNextContour(this);
        }

        public void SubstituteContour(CvSeq new_contour)
        {
            imgproc.cvSubstituteContour(this, new_contour);
        }

        public CvSeq EndFindContours()
        {
            var pHandle = GCHandle.Alloc(handle, GCHandleType.Pinned);
            try
            {
                var contours = imgproc.cvEndFindContours(pHandle.AddrOfPinnedObject());
                SetHandle(IntPtr.Zero);
                SetHandleAsInvalid();
                return contours;
            }
            finally { pHandle.Free(); }
        }

        protected override bool ReleaseHandle()
        {
            if (!IsClosed) EndFindContours();
            return true;
        }
    }
}
