using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using OpenCV.Net.Native;

namespace OpenCV.Net
{
    public sealed class CvVideoWriter : SafeHandleZeroOrMinusOneIsInvalid
    {
        public CvVideoWriter(string filename, int fourcc, double fps, CvSize frame_size)
            : this(filename, fourcc, fps, frame_size, true)
        {
        }

        public CvVideoWriter(string filename, int fourcc, double fps, CvSize frame_size, bool is_color)
            : base(true)
        {
            var pWriter = highgui.cvCreateVideoWriter(filename, fourcc, fps, frame_size, is_color ? 1 : 0);
            SetHandle(pWriter);
        }

        public int WriteFrame(IplImage image)
        {
            return highgui.cvWriteFrame(this, image);
        }

        public static int FourCC(char c1, char c2, char c3, char c4)
        {
            return (c1 & 255) + ((c2 & 255) << 8) + ((c3 & 255) << 16) + ((c4 & 255) << 24);
        }

        protected override bool ReleaseHandle()
        {
            var pHandle = GCHandle.Alloc(handle, GCHandleType.Pinned);
            try
            {
                highgui.cvReleaseVideoWriter(pHandle.AddrOfPinnedObject());
                return true;
            }
            finally { pHandle.Free(); }
        }
    }
}
