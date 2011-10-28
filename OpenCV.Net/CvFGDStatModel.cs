using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCV.Net.Native;
using System.Runtime.InteropServices;

namespace OpenCV.Net
{
    public sealed class CvFGDStatModel : CvBGStatModel
    {
        public CvFGDStatModel(IplImage first_frame)
        {
            var pModel = video.cvCreateFGDStatModel(first_frame, IntPtr.Zero);
            SetHandle(pModel);
            SetProperties();
        }

        public CvFGDStatModel(IplImage first_frame, CvFGDStatModelParams parameters)
        {
            var pParameters = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                var pModel = video.cvCreateFGDStatModel(first_frame, pParameters.AddrOfPinnedObject());
                SetHandle(pModel);
                SetProperties();
            }
            finally { pParameters.Free(); }
        }
    }
}
