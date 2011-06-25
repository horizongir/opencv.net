﻿using System;
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

        public Trackbar CreateTrackbar(string name, int value, int count)
        {
            return new Trackbar(name, this, value, count);
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
