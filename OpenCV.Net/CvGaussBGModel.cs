using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using OpenCV.Net.Native;

namespace OpenCV.Net
{
    public sealed class CvGaussBGModel : CvBGStatModel
    {
        public CvGaussBGModel(IplImage first_frame)
        {
            var pModel = video.cvCreateGaussianBGModel(first_frame, IntPtr.Zero);
            SetHandle(pModel);
            SetProperties();
        }

        public CvGaussBGModel(IplImage first_frame, CvGaussBGStatModelParams parameters)
        {
            var pParameters = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                var pModel = video.cvCreateGaussianBGModel(first_frame, pParameters.AddrOfPinnedObject());
                SetHandle(pModel);
                SetProperties();
            }
            finally { pParameters.Free(); }
        }
    }
}
