using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net.Native
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    delegate int pt2Func(int argc, string[] argv);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate void _CvButtonCallback(int state, IntPtr userdata);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate void CvTrackbarCallback2(int pos, IntPtr userdata);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate void _CvMouseCallback(MouseEvent evt, int x, int y, MouseEventFlags flags, IntPtr param);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate void _CvOpenGlDrawCallback(IntPtr userdata);
}
