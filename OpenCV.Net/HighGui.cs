using OpenCV.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCV.Net
{
    public static partial class CV
    {
        #region Basic GUI functions

        /// <summary>
        /// Draws text on the specified image <paramref name="img"/> using the specific <paramref name="font"/>.
        /// </summary>
        /// <param name="img">Image where the text should be drawn.</param>
        /// <param name="text">Text to write on the image.</param>
        /// <param name="location">The point where the text should start on the image.</param>
        /// <param name="font">Font used to draw the text.</param>
        public static void AddText(Arr img, string text, Point location, Font font)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            NativeMethods.cvAddText(img, text, location, font);
        }

        /// <summary>
        /// Creates and attaches a button to the shared control panel.
        /// </summary>
        /// <param name="buttonName">The name of the button.</param>
        /// <param name="onChange">
        /// The callback method that will be called every time the button changes state.
        /// </param>
        /// <param name="buttonType">The type of button to create.</param>
        /// <param name="initialButtonState">The initial state of the button.</param>
        /// <returns>
        /// <b>true</b> if the button was created successfully; otherwise, <b>false</b>.
        /// </returns>
        public static bool CreateButton(
            string buttonName = null,
            ButtonCallback onChange = null,
            ButtonType buttonType = ButtonType.PushButton,
            bool initialButtonState = false)
        {
            _CvButtonCallback callback = onChange != null ? (state, userdata) => onChange(state > 0 ? true : false) : (_CvButtonCallback)null;
            return NativeMethods.cvCreateButton(buttonName, callback, IntPtr.Zero, buttonType, initialButtonState ? 1 : 0) > 0;
        }

        /// <summary>
        /// Loads an image from a file as an <see cref="IplImage"/>.
        /// </summary>
        /// <param name="fileName">Name of file to be loaded.</param>
        /// <param name="colorType">Specific color type of the loaded image.</param>
        /// <returns>The newly loaded image.</returns>
        public static IplImage LoadImage(string fileName, LoadImageFlags colorType)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }

            var pImage = NativeMethods.cvLoadImage(fileName, colorType);
            return pImage == IntPtr.Zero ? null : new IplImage(pImage, true);
        }

        /// <summary>
        /// Loads an image from a file as a <see cref="Mat"/>.
        /// </summary>
        /// <param name="fileName">Name of file to be loaded.</param>
        /// <param name="colorType">Specific color type of the loaded image.</param>
        /// <returns>The newly loaded image.</returns>
        public static Mat LoadImageM(string fileName, LoadImageFlags colorType)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }

            var pMat = NativeMethods.cvLoadImageM(fileName, colorType);
            return pMat == IntPtr.Zero ? null : new Mat(pMat, true);
        }

        /// <summary>
        /// Saves an image to a specified file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="image">Image to be saved.</param>
        /// <param name="parameters">Optional image compression parameters.</param>
        /// <returns>
        /// <b>true</b> if the image was saved successfully; otherwise, <b>false</b>.
        /// </returns>
        public static bool SaveImage(string fileName, Arr image, params int[] parameters)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }

            return NativeMethods.cvSaveImage(fileName, image, parameters) > 0;
        }

        /// <summary>
        /// Reads an image from a buffer in memory as an <see cref="IplImage"/>.
        /// </summary>
        /// <param name="buf">Input array of bytes.</param>
        /// <param name="colorType">Specific color type of the loaded image.</param>
        /// <returns>The newly loaded image.</returns>
        public static IplImage DecodeImage(Mat buf, LoadImageFlags colorType)
        {
            var pImage = NativeMethods.cvDecodeImage(buf, colorType);
            return pImage == IntPtr.Zero ? null : new IplImage(pImage, true);
        }

        /// <summary>
        /// Reads an image from a buffer in memory as a <see cref="Mat"/>.
        /// </summary>
        /// <param name="buf">Input array of bytes.</param>
        /// <param name="colorType">Specific color type of the loaded image.</param>
        /// <returns>The newly loaded image.</returns>
        public static Mat DecodeImageM(Mat buf, LoadImageFlags colorType)
        {
            var pMat = NativeMethods.cvDecodeImageM(buf, colorType);
            return pMat == IntPtr.Zero ? null : new Mat(pMat, true);
        }

        /// <summary>
        /// Encodes an image into a memory buffer.
        /// </summary>
        /// <param name="ext">File extension that defines the output format.</param>
        /// <param name="image">Image to be written.</param>
        /// <param name="parameters">Optional image compression parameters.</param>
        /// <returns>
        /// A newly created <see cref="Mat"/> containing the encoded image bytes.
        /// </returns>
        public static Mat EncodeImage(string ext, Arr image, params int[] parameters)
        {
            if (ext == null)
            {
                throw new ArgumentNullException("ext");
            }

            var pMat = NativeMethods.cvEncodeImage(ext, image, parameters);
            return pMat == IntPtr.Zero ? null : new Mat(pMat, true);
        }

        /// <summary>
        /// Converts one image to another with an optional vertical flip.
        /// </summary>
        /// <param name="src">Source image.</param>
        /// <param name="dst">Destination image.</param>
        /// <param name="flags">The operation flags.</param>
        public static void ConvertImage(Arr src, Arr dst, ConvertImageFlags flags = ConvertImageFlags.None)
        {
            NativeMethods.cvConvertImage(src, dst, flags);
        }

        /// <summary>
        /// Waits for a pressed key.
        /// </summary>
        /// <param name="delay">
        /// Maximum delay in milliseconds for which to wait for a key press.
        /// </param>
        /// <returns>
        /// The pressed key code or -1 if no key was pressed before the specified
        /// time had elapsed.
        /// </returns>
        public static int WaitKey(int delay = 0)
        {
            return NativeMethods.cvWaitKey(delay);
        }

        #endregion
    }
}
