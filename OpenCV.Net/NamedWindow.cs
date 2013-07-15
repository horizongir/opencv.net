using OpenCV.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a window which can be used as placeholder for images and trackbars.
    /// </summary>
    public sealed class NamedWindow : IDisposable
    {
        bool disposed;
        readonly string name;
        _CvMouseCallback mouseCallback;
        _CvOpenGlDrawCallback drawCallback;
        List<CvTrackbarCallback> trackbars;

        /// <summary>
        /// Initializes a new instance of the <see cref="NamedWindow"/> class from the
        /// specified native window handle.
        /// </summary>
        /// <param name="handle">
        /// The platform specific native window handle used to retrieve the window name.
        /// </param>
        public NamedWindow(IntPtr handle)
        {
            name = NativeMethods.cvGetWindowName(handle);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NamedWindow"/> class with the
        /// specified name.
        /// </summary>
        /// <param name="name">The name of the window in the window caption.</param>
        /// <param name="flags">The flags of the window.</param>
        public NamedWindow(string name, WindowFlags flags = WindowFlags.AutoSize)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            this.name = name;
            NativeMethods.cvNamedWindow(name, flags);
        }

        /// <summary>
        /// Gets the name of the window.
        /// </summary>
        public string Name
        {
            get { return this.name; }
        }

        /// <summary>
        /// Gets the platform specific native window handle.
        /// </summary>
        public IntPtr Handle
        {
            get { return NativeMethods.cvGetWindowHandle(name); }
        }

        /// <summary>
        /// Displays text on the window’s image as an overlay for <paramref name="delayMs"/> milliseconds.
        /// This is not editing the image’s data. The text is displayed on the top of the image.
        /// </summary>
        /// <param name="text">Overlay text to write on the window’s image.</param>
        /// <param name="delayMs">
        /// Delay to display the overlay text. If this method is called before the previous overlay text
        /// times out, the timer is restarted and the text updated. If this value is zero, the text never
        /// disappears.
        /// </param>
        public void DisplayOverlay(string text, int delayMs = 0)
        {
            NativeMethods.cvDisplayOverlay(name, text, delayMs);
        }

        /// <summary>
        /// Displays text on the window’s status bar for <paramref name="delayMs"/> milliseconds.
        /// </summary>
        /// <param name="text">Text to write on the window’s status bar.</param>
        /// <param name="delayMs">
        /// Delay to display the text. If this method is called before the previous text times out, the
        /// timer is restarted and the text updated. If this value is zero, the text never disappears.
        /// </param>
        public void DisplayStatusBar(string text, int delayMs = 0)
        {
            NativeMethods.cvDisplayStatusBar(name, text, delayMs);
        }

        /// <summary>
        /// Saves parameters of the window such as size, location, flags, etc.
        /// </summary>
        public void SaveWindowParameters()
        {
            NativeMethods.cvSaveWindowParameters(name);
        }

        /// <summary>
        /// Loads parameters of the window such as size, location, flags, etc.
        /// </summary>
        public void LoadWindowParameters()
        {
            NativeMethods.cvLoadWindowParameters(name);
        }

        /// <summary>
        /// Change the parameters of the window dynamically.
        /// </summary>
        /// <param name="propId">The identifier of the property to edit.</param>
        /// <param name="propValue">The new value of the window property.</param>
        public void SetProperty(WindowProperty propId, WindowFlags propValue)
        {
            NativeMethods.cvSetWindowProperty(name, propId, (double)propValue);
        }

        /// <summary>
        /// Gets the parameters of the window.
        /// </summary>
        /// <param name="propId">The identifier of the property to retrieve.</param>
        /// <returns>The value of the window property.</returns>
        public WindowFlags GetProperty(WindowProperty propId)
        {
            return (WindowFlags)NativeMethods.cvGetWindowProperty(name, propId);
        }

        /// <summary>
        /// Displays the image in the specified window.
        /// </summary>
        /// <param name="image">The image to be shown.</param>
        public void ShowImage(CvArr image)
        {
            NativeMethods.cvShowImage(name, image);
        }

        /// <summary>
        /// Sets the window size.
        /// </summary>
        /// <param name="width">The new width.</param>
        /// <param name="height">The new height.</param>
        public void Resize(int width, int height)
        {
            NativeMethods.cvResizeWindow(name, width, height);
        }

        /// <summary>
        /// Sets the position of the window.
        /// </summary>
        /// <param name="x">The new x-coordinate of the top-left corner.</param>
        /// <param name="y">The new y-coordinate of the top-left corner.</param>
        public void Move(int x, int y)
        {
            NativeMethods.cvMoveWindow(name, x, y);
        }

        /// <summary>
        /// Destroys all of the HighGUI windows.
        /// </summary>
        public static void DestroyAllWindows()
        {
            NativeMethods.cvDestroyAllWindows();
        }

        /// <summary>
        /// Creates a trackbar and attaches it to the window.
        /// </summary>
        /// <param name="trackbarName">Name of the created trackbar.</param>
        /// <param name="value">A reference to an integer value that specifies the position of the slider.</param>
        /// <param name="count">Maximal position of the slider. Minimal position is always 0.</param>
        /// <param name="onChanged">
        /// The callback method that will be called every time the slider changes position.
        /// </param>
        public void CreateTrackbar(string trackbarName, ref int value, int count, CvTrackbarCallback onChanged = null)
        {
            if (trackbars == null)
            {
                trackbars = new List<CvTrackbarCallback>();
            }

            if (onChanged != null)
            {
                trackbars.Add(onChanged);
            }
            NativeMethods.cvCreateTrackbar(trackbarName, name, ref value, count, onChanged);
        }

        /// <summary>
        /// Returns the trackbar position.
        /// </summary>
        /// <param name="trackbarName">The name of the trackbar.</param>
        /// <returns>The current position of the specified trackbar.</returns>
        public int GetTrackbarPos(string trackbarName)
        {
            return NativeMethods.cvGetTrackbarPos(trackbarName, Name);
        }

        /// <summary>
        /// Sets the trackbar position.
        /// </summary>
        /// <param name="trackbarName">The name of the trackbar.</param>
        /// <param name="pos">The new trackbar position.</param>
        public void SetTrackbarPos(string trackbarName, int pos)
        {
            NativeMethods.cvSetTrackbarPos(trackbarName, Name, pos);
        }

        /// <summary>
        /// Assigns a callback for mouse events.
        /// </summary>
        /// <param name="onMouse">
        /// The callback method that will handle mouse events of this named window.
        /// </param>
        public void SetMouseCallback(CvMouseCallback onMouse)
        {
            mouseCallback = (evt, x, y, flags, param) => onMouse(evt, x, y, flags);
            NativeMethods.cvSetMouseCallback(name, mouseCallback, IntPtr.Zero);
        }

        /// <summary>
        /// Assigns a callback to draw OpenGL on top of the image display.
        /// Used only for windows with OpenGL support.
        /// </summary>
        /// <param name="callback">
        /// The callback method that will be called every frame.
        /// </param>
        public void SetOpenGLDrawCallback(CvOpenGlDrawCallback callback)
        {
            drawCallback = userdata => callback();
            NativeMethods.cvSetOpenGlDrawCallback(name, drawCallback, IntPtr.Zero);
        }

        /// <summary>
        /// Makes the GL context current. Used only for windows with OpenGL support.
        /// </summary>
        public void SetOpenGLContext()
        {
            NativeMethods.cvSetOpenGlContext(name);
        }

        /// <summary>
        /// Updates the window. Used only for windows with OpenGL support.
        /// </summary>
        public void Update()
        {
            NativeMethods.cvUpdateWindow(name);
        }

        /// <summary>
        /// Allows an object to try to free resources and perform other cleanup operations
        /// before it is reclaimed by garbage collection.
        /// </summary>
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
                    NativeMethods.cvDestroyWindow(name);
                    mouseCallback = null;
                    drawCallback = null;
                    if (trackbars != null)
                    {
                        trackbars.Clear();
                        trackbars = null;
                    }
                    disposed = true;
                }
            }
        }
        
        /// <summary>
        /// Releases all resources used by the <see cref="NamedWindow"/>.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
