using OpenCV.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a video capture stream.
    /// </summary>
    public sealed class Capture : CVHandle
    {
        internal Capture()
            : base(true)
        {
        }

        /// <summary>
        /// Gets the capture back end used for image acquisition.
        /// </summary>
        public CaptureDomain CaptureDomain
        {
            get { return NativeMethods.cvGetCaptureDomain(this); }
        }

        /// <summary>
        /// Initializes capturing a video from a camera.
        /// </summary>
        /// <param name="index">
        /// Index of the camera to be used. If there is only one camera or it does not
        /// matter what camera is used -1 may be passed.
        /// </param>
        /// <returns>
        /// A newly created <see cref="Capture"/> instance representing image
        /// acquisition from a camera.
        /// </returns>
        public static Capture CreateCameraCapture(int index)
        {
            return NativeMethods.cvCreateCameraCapture(index);
        }

        /// <summary>
        /// Initializes capturing a video from a camera using the specified <paramref name="domain"/>.
        /// </summary>
        /// <param name="index">
        /// Index of the camera to be used. If there is only one camera or it does not
        /// matter what camera is used -1 may be passed.
        /// </param>
        /// <param name="domain">
        /// The capture domain used to indicate what kind of camera source should be acquired.
        /// </param>
        /// <returns>
        /// A newly created <see cref="Capture"/> instance representing image
        /// acquisition from a camera.
        /// </returns>
        public static Capture CreateCameraCapture(int index, CaptureDomain domain)
        {
            return CreateCameraCapture(index + (int)domain);
        }

        /// <summary>
        /// Initializes capturing a video from the specified file. Which codecs and file formats are
        /// supported depends on the back end library.
        /// </summary>
        /// <param name="fileName">
        /// The path to the video file.
        /// </param>
        /// <returns>
        /// A newly created <see cref="Capture"/> instance representing image
        /// acquisition from a video file.
        /// </returns>
        public static Capture CreateFileCapture(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }

            var capture = NativeMethods.cvCreateFileCapture(fileName);
            return capture.IsInvalid ? null : capture;
        }

        /// <summary>
        /// Grabs a frame from a camera or file. The grabbed frame is stored internally and
        /// can be retrieved by calling <see cref="RetrieveFrame"/>.
        /// </summary>
        /// <returns>A value indicating whether a new frame was grabbed.</returns>
        public bool GrabFrame()
        {
            return NativeMethods.cvGrabFrame(this) > 0;
        }

        /// <summary>
        /// Gets the image grabbed with <see cref="GrabFrame"/>.
        /// </summary>
        /// <param name="streamIdx">The index of the stream from which to retrieve the frame.</param>
        /// <returns>
        /// The reference to the newly captured frame. The returned image should not be released
        /// or modified by the user. In the event of an error, the return value may be <b>null</b>.
        /// </returns>
        public IplImage RetrieveFrame(int streamIdx = 0)
        {
            var pFrame = NativeMethods.cvRetrieveFrame(this, streamIdx);
            return pFrame != IntPtr.Zero ? new IplImage(pFrame, false) : null;
        }

        /// <summary>
        /// Grabs and returns a frame from a camera or file.
        /// </summary>
        /// <returns>
        /// The reference to the newly captured frame. The returned image should not be released
        /// or modified by the user. In the event of an error, the return value may be <b>null</b>.
        /// </returns>
        public IplImage QueryFrame()
        {
            var pFrame = NativeMethods.cvQueryFrame(this);
            return pFrame != IntPtr.Zero ? new IplImage(pFrame, false) : null;
        }

        /// <summary>
        /// Gets video capture properties.
        /// </summary>
        /// <param name="propertyId">The property identifier as specified by <see cref="CaptureProperty"/>.</param>
        /// <returns>
        /// The value of the specified property.
        /// </returns>
        public double GetProperty(CaptureProperty propertyId)
        {
            return NativeMethods.cvGetCaptureProperty(this, propertyId);
        }

        /// <summary>
        /// Sets video capture properties.
        /// </summary>
        /// <param name="propertyId">The property identifier as specified by <see cref="CaptureProperty"/>.</param>
        /// <param name="value">The new value of the specified property.</param>
        public void SetProperty(CaptureProperty propertyId, double value)
        {
            NativeMethods.cvSetCaptureProperty(this, propertyId, value);
        }

        /// <summary>
        /// Executes the code required to free the native <see cref="Capture"/> handle.
        /// </summary>
        /// <returns>
        /// <b>true</b> if the handle is released successfully; otherwise, in the event of a
        /// catastrophic failure, <b>false</b>.
        /// </returns>
        protected override bool ReleaseHandle()
        {
            NativeMethods.cvReleaseCapture(ref handle);
            return true;
        }
    }
}
