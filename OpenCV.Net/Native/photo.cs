using System.Runtime.InteropServices;

namespace OpenCV.Net.Native
{
    static partial class NativeMethods
    {
        const string photoLib = "opencv_photo" + libSuffix;

        [DllImport(photoLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvInpaint(Arr src, Arr inpaint_mask, Arr dst, double inpaintRange, InpaintMethod flags);
    }
}
