using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCV.Net.Native;

namespace OpenCV.Net
{
    public sealed class NamedWindow : IDisposable
    {
        bool disposed;
        readonly string name;
        CvMouseCallback mouseCallback;
        List<CvTrackbarCallback> trackbars;

        public NamedWindow(string name)
            : this(name, WindowFlags.AUTOSIZE | WindowFlags.KEEPRATIO | WindowFlags.GUI_EXPANDED)
        {
        }

        public NamedWindow(string name, WindowFlags flags)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            this.name = name;
            highgui.cvNamedWindow(name, flags);
        }

        public string Name
        {
            get { return this.name; }
        }

        public IntPtr WindowHandle
        {
            get { return highgui.cvGetWindowHandle(name); }
        }

        public void ShowImage(CvArr image)
        {
            highgui.cvShowImage(name, image);
        }

        public void MoveWindow(int x, int y)
        {
            highgui.cvMoveWindow(name, x, y);
        }

        public void ResizeWindow(int width, int height)
        {
            highgui.cvResizeWindow(name, width, height);
        }

        public void SetMouseCallback(CvMouseCallback onMouse)
        {
            mouseCallback = onMouse;
            highgui.cvSetMouseCallback(name, onMouse, IntPtr.Zero);
        }

        public void CreateTrackbar(string name, ref int value, int count, CvTrackbarCallback onChanged)
        {
            if (trackbars == null)
            {
                trackbars = new List<CvTrackbarCallback>();
            }

            trackbars.Add(onChanged);
            highgui.cvCreateTrackbar(name, Name, ref value, count, onChanged);
        }

        public static void DestroyAllWindows()
        {
            highgui.cvDestroyAllWindows();
        }

        ~NamedWindow()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    disposed = true;
                }

                highgui.cvDestroyWindow(name);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
