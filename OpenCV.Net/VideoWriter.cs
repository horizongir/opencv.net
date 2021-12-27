using Microsoft.Win32.SafeHandles;
using OpenCV.Net.Native;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a frame writer for a video file stream.
    /// </summary>
    public sealed class VideoWriter : SafeHandleZeroOrMinusOneIsInvalid
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VideoWriter"/> class with the specified
        /// <paramref name="fileName"/>, codec and format parameters.
        /// </summary>
        /// <param name="fileName">Name of the output video file.</param>
        /// <param name="fourCC">4-character code of codec used to compress the frames.</param>
        /// <param name="fps">Framerate of the created video stream.</param>
        /// <param name="frameSize">Size of the video frames.</param>
        public VideoWriter(string fileName, int fourCC, double fps, Size frameSize)
            : this(fileName, fourCC, fps, frameSize, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoWriter"/> class with the specified
        /// <paramref name="fileName"/>, codec and format parameters.
        /// </summary>
        /// <param name="fileName">Name of the output video file.</param>
        /// <param name="fourCC">4-character code of codec used to compress the frames.</param>
        /// <param name="fps">Framerate of the created video stream.</param>
        /// <param name="frameSize">Size of the video frames.</param>
        /// <param name="isColor">
        /// If <b>true</b>, the encoder will expect and encode color frames, otherwise it will work
        /// with grayscale frames (the flag is currently supported on Windows only).
        /// </param>
        public VideoWriter(string fileName, int fourCC, double fps, Size frameSize, bool isColor)
            : base(true)
        {
            var pWriter = NativeMethods.cvCreateVideoWriter(fileName, fourCC, fps, frameSize, isColor ? 1 : 0);
            SetHandle(pWriter);
        }

        /// <summary>
        /// Writes a frame to a video file.
        /// </summary>
        /// <param name="image">The written frame.</param>
        /// <returns><b>True</b> if the frame was written successfully; false, otherwise.</returns>
        public bool WriteFrame(IplImage image)
        {
            return NativeMethods.cvWriteFrame(this, image) > 0;
        }

        /// <summary>
        /// Creates the integer representation of a 4-character codec code.
        /// </summary>
        /// <param name="c1">The first character of the codec code.</param>
        /// <param name="c2">The second character of the codec code.</param>
        /// <param name="c3">The third character of the codec code.</param>
        /// <param name="c4">The fourth character of the codec code.</param>
        /// <returns>The integer representation of the codec code.</returns>
        public static int FourCC(char c1, char c2, char c3, char c4)
        {
            return (c1 & 255) + ((c2 & 255) << 8) + ((c3 & 255) << 16) + ((c4 & 255) << 24);
        }

        /// <summary>
        /// Executes the code required to free the native <see cref="VideoWriter"/> handle.
        /// </summary>
        /// <returns>
        /// <b>true</b> if the handle is released successfully; otherwise, in the event of a
        /// catastrophic failure, <b>false</b>.
        /// </returns>
        protected override bool ReleaseHandle()
        {
            NativeMethods.cvReleaseVideoWriter(ref handle);
            return true;
        }
    }
}
