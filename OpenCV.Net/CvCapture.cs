using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using OpenCV.Net.Native;

namespace OpenCV.Net
{
    public sealed class CvCapture : SafeHandleZeroOrMinusOneIsInvalid
    {
        internal CvCapture()
            : base(true)
        {
        }

        public int GrabFrame()
        {
            return highgui.cvGrabFrame(this);
        }

        public IplImage QueryFrame()
        {
            var pFrame = highgui.cvQueryFrame(this);
            return pFrame != IntPtr.Zero ? new IplImage(pFrame, false) : null;
        }

        public IplImage RetrieveFrame()
        {
            var pFrame = highgui.cvRetrieveFrame(this);
            return pFrame != IntPtr.Zero ? new IplImage(pFrame, false) : null;
        }

        public double GetProperty(CaptureProperty property_id)
        {
            return highgui.cvGetCaptureProperty(this, property_id);
        }

        public void SetProperty(CaptureProperty property_id, double value)
        {
            highgui.cvSetCaptureProperty(this, property_id, value);
        }

        public static CvCapture CreateCameraCapture(int index)
        {
            return highgui.cvCreateCameraCapture(index);
        }

        public static CvCapture CreateFileCapture(string filename)
        {
            return highgui.cvCreateFileCapture(filename);
        }

        protected override bool ReleaseHandle()
        {
            var pHandle = GCHandle.Alloc(handle, GCHandleType.Pinned);
            try
            {
                highgui.cvReleaseCapture(pHandle.AddrOfPinnedObject());
                return true;
            }
            finally { pHandle.Free(); }
        }
    }
}
