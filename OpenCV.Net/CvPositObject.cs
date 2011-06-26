using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32.SafeHandles;
using OpenCV.Net.Native;
using System.Runtime.InteropServices;

namespace OpenCV.Net
{
    public class CvPositObject : SafeHandleZeroOrMinusOneIsInvalid
    {
        public CvPositObject(CvPoint3D32f[] points)
            : base(true)
        {
            var pPosit = calib3d.cvCreatePOSITObject(points, points.Length);
            SetHandle(pPosit);
        }

        public void Posit(CvPoint2D32f[] image_points, double focal_length, CvTermCriteria criteria, float[] rotation_matrix, float[] translation_vector)
        {
            calib3d.cvPOSIT(handle, image_points, focal_length, criteria, rotation_matrix, translation_vector);
        }

        protected override bool ReleaseHandle()
        {
            var pHandle = GCHandle.Alloc(handle, GCHandleType.Pinned);
            try
            {
                calib3d.cvReleasePOSITObject(pHandle.AddrOfPinnedObject());
                return true;
            }
            finally { pHandle.Free(); }
        }
    }
}
