using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net.Native
{
    static partial class NativeMethods
    {
        const string highguiLib = "opencv_highgui" + libSuffix;

        #region Basic GUI functions

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern _CvFont cvFontQt(
            string nameFont,
            int pointSize,
            Scalar color,
            FontWeight weight,
            FontStyle style,
            int spacing);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void cvAddText(Arr img, string text, Point org, Font arg2);

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
        internal static extern void cvShowImage(string name, Arr image);

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
            TrackbarCallback on_change);

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
        internal static extern IntPtr cvLoadImage(string filename, LoadImageFlags iscolor);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern IntPtr cvLoadImageM(string filename, LoadImageFlags iscolor);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern int cvSaveImage(string filename, Arr image, int[] parameters);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvDecodeImage(Mat buf, LoadImageFlags iscolor);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvDecodeImageM(Mat buf, LoadImageFlags iscolor);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern IntPtr cvEncodeImage(string ext, Arr image, int[] parameters);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvConvertImage(Arr src, Arr dst, ConvertImageFlags flags);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvWaitKey(int delay);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void cvSetOpenGlDrawCallback(string window_name, _CvOpenGlDrawCallback callback, IntPtr userdata);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void cvSetOpenGlContext(string window_name);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void cvUpdateWindow(string window_name);

        #endregion

        #region Working with Video Files and Cameras

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern Capture cvCreateFileCapture(string filename);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Capture cvCreateCameraCapture(int index);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvGrabFrame(Capture capture);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvRetrieveFrame(Capture capture, int streamIdx);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvQueryFrame(Capture capture);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvReleaseCapture(ref IntPtr capture);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double cvGetCaptureProperty(Capture capture, CaptureProperty property_id);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvSetCaptureProperty(Capture capture, CaptureProperty property_id, double value);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CaptureDomain cvGetCaptureDomain(Capture capture);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern IntPtr cvCreateVideoWriter(string filename, int fourcc, double fps, Size frame_size, int is_color);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cvWriteFrame(VideoWriter writer, IplImage image);

        [DllImport(highguiLib, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvReleaseVideoWriter(ref IntPtr capture);

        #endregion
    }
}
