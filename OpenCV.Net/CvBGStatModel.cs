using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using OpenCV.Net.Native;

namespace OpenCV.Net
{
    public abstract class CvBGStatModel : SafeHandleZeroOrMinusOneIsInvalid
    {
        IplImage background;
        IplImage foreground;

        protected CvBGStatModel()
            : base(true)
        {
        }

        public IplImage Background
        {
            get { return background; }
        }

        public IplImage Foreground
        {
            get { return foreground; }
        }

        protected internal void SetProperties()
        {
            unsafe
            {
                background = new IplImage(((_CvBGStatModel*)handle.ToPointer())->background, false);
                foreground = new IplImage(((_CvBGStatModel*)handle.ToPointer())->foreground, false);
            }
        }

        public int UpdateModel(IplImage current_frame)
        {
            return UpdateModel(current_frame, -1);
        }

        public int UpdateModel(IplImage current_frame, double learning_rate)
        {
            return video.cvUpdateBGStatModel(current_frame, this, learning_rate);
        }

        public void RefineForegroundMaskBySegm(CvSeq segments)
        {
            video.cvRefineForegroundMaskBySegm(segments, this);
        }

        protected override bool ReleaseHandle()
        {
            var pHandle = GCHandle.Alloc(handle, GCHandleType.Pinned);
            try
            {
                video.cvReleaseBGStatModel(pHandle.AddrOfPinnedObject());
                return true;
            }
            finally { pHandle.Free(); }
        }
    }
}
