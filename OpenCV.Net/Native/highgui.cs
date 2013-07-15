using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net.Native
{
    static partial class NativeMethods
    {
        const string highguiLib = "opencv_highgui246";

        #region Basic GUI functions

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern _CvFont cvFontQt(
            string nameFont,
            int pointSize,
            CvScalar color,
            FontWeight weight,
            FontStyle style,
            int spacing);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void cvAddText(CvArr img, string text, CvPoint org, CvFont arg2);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void cvDisplayOverlay(string name, string text, int delayms);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void cvDisplayStatusBar(string name, string text, int delayms);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void cvSaveWindowParameters(string name);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void cvLoadWindowParameters(string name);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern int cvStartLoop(pt2Func func, int argc, string[] argv);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvStopLoop();

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern int cvCreateButton(
            string button_name,
            _CvButtonCallback on_change,
            IntPtr userdata,
            ButtonType button_type,
            int initial_button_state);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern int cvInitSystem(int argc, string[] argv);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvStartWindowThread();

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern int cvNamedWindow(string name, WindowFlags flags);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void cvSetWindowProperty(string name, WindowProperty prop_id, double prop_value);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern double cvGetWindowProperty(string name, WindowProperty prop_id);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void cvShowImage(string name, CvArr image);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void cvResizeWindow(string name, int width, int height);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void cvMoveWindow(string name, int x, int y);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void cvDestroyWindow(string name);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvDestroyAllWindows();

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern IntPtr cvGetWindowHandle(string name);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern string cvGetWindowName(IntPtr window_handle);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern int cvCreateTrackbar(
            string trackbar_name,
            string window_name,
            ref int value,
            int count,
            CvTrackbarCallback on_change);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern int cvCreateTrackbar2(
            string trackbar_name,
            string window_name,
            ref int value,
            int count,
            CvTrackbarCallback2 on_change,
            IntPtr userdata);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern int cvGetTrackbarPos(string trackbar_name, string window_name);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void cvSetTrackbarPos(string trackbar_name, string window_name, int pos);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void cvSetMouseCallback(string window_name, _CvMouseCallback on_mouse, IntPtr param);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern IplImage cvLoadImage(string filename, LoadImageFlags iscolor);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern CvMat cvLoadImageM(string filename, LoadImageFlags iscolor);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern int cvSaveImage(string filename, CvArr image, int[] parameters);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IplImage cvDecodeImage(CvMat buf, LoadImageFlags iscolor);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CvMat cvDecodeImageM(CvMat buf, LoadImageFlags iscolor);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern CvMat cvEncodeImage(string ext, CvArr image, int[] parameters);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvConvertImage(CvArr src, CvArr dst, ConvertImageFlags flags);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvWaitKey(int delay);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void cvSetOpenGlDrawCallback(string window_name, _CvOpenGlDrawCallback callback, IntPtr userdata);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void cvSetOpenGlContext(string window_name);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void cvUpdateWindow(string window_name);

        #endregion
    }
}
