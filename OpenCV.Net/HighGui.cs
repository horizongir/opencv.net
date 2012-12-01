using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OpenCV.Net
{
    public static class HighGui
    {
        const string libName = "opencv_highgui243";

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvConvertImage(CvArr src, CvArr dst, ConvertImageFlags flags);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvWaitKey(int delay);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IplImage cvLoadImage(string filename, LoadImageMode iscolor);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int cvSaveImage(string filename, CvArr image, params int[] parameters);
    }
}
