using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OpenCV.Net.Native
{
    static class calib3d
    {
        const string libName = "opencv_calib3d231";

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvCreatePOSITObject(CvPoint3D32f[] points, int point_count);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvPOSIT(
            IntPtr posit_object,
            CvPoint2D32f[] image_points,
            double focal_length,
            CvTermCriteria criteria,
            float[] rotation_matrix,
            float[] translation_vector);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReleasePOSITObject(IntPtr posit_object);
    }
}
