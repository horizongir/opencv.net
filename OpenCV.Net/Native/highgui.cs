using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OpenCV.Net.Native
{
    static class highgui
    {
        const string libName = "opencv_highgui220";

        [DllImport(libName, CharSet = CharSet.Ansi)]
        public static extern int cvNamedWindow(string name, WindowFlags flags);

        [DllImport(libName)]
        public static extern void cvDestroyAllWindows();

        [DllImport(libName, CharSet = CharSet.Ansi)]
        public static extern void cvDestroyWindow(string name);

        [DllImport(libName, CharSet = CharSet.Ansi)]
        public static extern IntPtr cvGetWindowHandle(string name);

        [DllImport(libName, CharSet = CharSet.Ansi)]
        public static extern void cvShowImage(string name, CvArr image);

        [DllImport(libName, CharSet = CharSet.Ansi)]
        public static extern void cvMoveWindow(string name, int x, int y);

        [DllImport(libName, CharSet = CharSet.Ansi)]
        public static extern void cvResizeWindow(string name, int width, int height);

        [DllImport(libName)]
        public static extern CvCapture cvCreateCameraCapture(int index);

        [DllImport(libName, CharSet = CharSet.Ansi)]
        public static extern CvCapture cvCreateFileCapture(string filename);

        [DllImport(libName)]
        public static extern double cvGetCaptureProperty(CvCapture capture, CaptureProperty property_id);

        [DllImport(libName)]
        public static extern int cvSetCaptureProperty(CvCapture capture, CaptureProperty property_id, double value);

        [DllImport(libName)]
        public static extern IntPtr cvQueryFrame(CvCapture capture);

        [DllImport(libName)]
        public static extern void cvReleaseCapture(IntPtr capture);
    }
}
