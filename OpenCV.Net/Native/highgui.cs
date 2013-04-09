using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OpenCV.Net.Native
{
    static class highgui
    {
        const string libName = "opencv_highgui244";

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int cvNamedWindow(string name, WindowFlags flags);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvDestroyAllWindows();

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void cvDestroyWindow(string name);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr cvGetWindowHandle(string name);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void cvShowImage(string name, CvArr image);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void cvMoveWindow(string name, int x, int y);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void cvResizeWindow(string name, int width, int height);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void cvSetMouseCallback(string windowName, [MarshalAs(UnmanagedType.FunctionPtr)]CvMouseCallback onMouse, IntPtr param);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int cvCreateTrackbar(string trackbarName, string windowName, ref int value, int count, [MarshalAs(UnmanagedType.FunctionPtr)]CvTrackbarCallback onChange);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvCapture cvCreateCameraCapture(int index);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern CvCapture cvCreateFileCapture(string filename);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvGetCaptureProperty(CvCapture capture, CaptureProperty property_id);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvSetCaptureProperty(CvCapture capture, CaptureProperty property_id, double value);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvGrabFrame(CvCapture capture);
        
        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvQueryFrame(CvCapture capture);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cvRetrieveFrame(CvCapture capture);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReleaseCapture(IntPtr capture);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr cvCreateVideoWriter(string filename, int fourcc, double fps, CvSize frame_size, int is_color);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvWriteFrame(CvVideoWriter writer, IplImage image);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvReleaseVideoWriter(IntPtr capture);
    }
}
