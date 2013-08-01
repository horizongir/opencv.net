using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCV.Net.Native;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents an IPL image header.
    /// </summary>
    public class IplImage : CvArr
    {
        bool ownsData;

        internal IplImage(bool ownsHandle)
            : base(ownsHandle)
        {
        }

        internal IplImage(IntPtr handle)
            : this(handle, true)
        {
        }

        internal IplImage(IntPtr handle, bool ownsHandle)
            : base(ownsHandle)
        {
            SetHandle(handle);

            if (ownsHandle)
            {
                GC.AddMemoryPressure(WidthStep * Height);
                ownsData = true;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IplImage"/> class with the
        /// specified <paramref name="size"/>, pixel bit <paramref name="depth"/> and
        /// <paramref name="channels"/> per element.
        /// </summary>
        /// <param name="size">The pixel-accurate size of the <see cref="IplImage"/>.</param>
        /// <param name="depth">The bit depth of image pixels.</param>
        /// <param name="channels">The number of channels per pixel.</param>
        public IplImage(CvSize size, IplDepth depth, int channels)
            : this(NativeMethods.cvCreateImage(size, depth, channels), true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IplImage"/> class with the
        /// specified <paramref name="size"/>, pixel bit <paramref name="depth"/> and
        /// <paramref name="channels"/> per element. A pointer to the image raw
        /// <paramref name="data"/> is provided.
        /// </summary>
        /// <param name="size">The pixel-accurate size of the <see cref="IplImage"/>.</param>
        /// <param name="depth">The bit depth of image pixels.</param>
        /// <param name="channels">The number of channels per pixel.</param>
        /// <param name="data">A pointer to the image raw pixel data.</param>
        public IplImage(CvSize size, IplDepth depth, int channels, IntPtr data)
            : base(true)
        {
            var pImage = NativeMethods.cvCreateImageHeader(size, depth, channels);
            SetHandle(pImage);
            SetData(data, WidthStep);
        }

        /// <summary>
        /// Gets the bit depth of image pixels.
        /// </summary>
        public IplDepth Depth
        {
            get
            {
                unsafe
                {
                    return ((_IplImage*)handle.ToPointer())->depth;
                }
            }
        }

        /// <summary>
        /// Gets the number of channels per image pixel.
        /// </summary>
        public int Channels
        {
            get
            {
                unsafe
                {
                    return ((_IplImage*)handle.ToPointer())->nChannels;
                }
            }
        }

        /// <summary>
        /// Gets the width of the image in pixels.
        /// </summary>
        public int Width
        {
            get
            {
                unsafe
                {
                    return ((_IplImage*)handle.ToPointer())->width;
                }
            }
        }

        /// <summary>
        /// Gets the height of the image in pixels.
        /// </summary>
        public int Height
        {
            get
            {
                unsafe
                {
                    return ((_IplImage*)handle.ToPointer())->height;
                }
            }
        }

        /// <summary>
        /// Gets the size of the aligned image row in bytes.
        /// </summary>
        public int WidthStep
        {
            get
            {
                unsafe
                {
                    return ((_IplImage*)handle.ToPointer())->widthStep;
                }
            }
        }

        /// <summary>
        /// Gets a pointer to the aligned image data.
        /// </summary>
        public IntPtr ImageData
        {
            get
            {
                unsafe
                {
                    return ((_IplImage*)handle.ToPointer())->imageData;
                }
            }
        }

        /// <summary>
        /// Gets or sets the image channel of interest.
        /// Only a few functions support COI.
        /// </summary>
        public int ChannelOfInterest
        {
            get { return NativeMethods.cvGetImageCOI(this); }
            set { NativeMethods.cvSetImageCOI(this, value); }
        }

        /// <summary>
        /// Gets or sets the image region of interest.
        /// </summary>
        public CvRect RegionOfInterest
        {
            get { return NativeMethods.cvGetImageROI(this); }
            set { NativeMethods.cvSetImageROI(this, value); }
        }

        /// <summary>
        /// Resets the image region and channel of interest.
        /// </summary>
        public void ResetRegionOfInterest()
        {
            NativeMethods.cvResetImageROI(this);
        }

        /// <summary>
        /// Creates a new <see cref="IplImage"/> that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new <see cref="IplImage"/> that is a copy of this instance.
        /// <see cref="WidthStep"/> may differ.
        /// </returns>
        public IplImage Clone()
        {
            return new IplImage(NativeMethods.cvCloneImage(this), true);
        }

        /// <summary>
        /// Creates a new <see cref="IplImage"/> from a subrectangle of the current instance.
        /// No data is copied.
        /// </summary>
        /// <param name="rect">Zero-based coordinates of the rectangle of interest.</param>
        /// <returns>
        /// A new <see cref="IplImage"/> that corresponds to the specified rectangle of
        /// the current image.
        /// </returns>
        public new IplImage GetSubRect(CvRect rect)
        {
            _CvMat subRect;
            NativeMethods.cvGetSubRect(this, out subRect, rect);
            return new IplImageSubRect(this, subRect);
        }

        /// <summary>
        /// Executes the code required to free the native <see cref="IplImage"/> handle.
        /// </summary>
        /// <returns>
        /// <b>true</b> if the handle is released successfully; otherwise, in the event of a
        /// catastrophic failure, <b>false</b>.
        /// </returns>
        protected override bool ReleaseHandle()
        {
            if (ownsData)
            {
                GC.RemoveMemoryPressure(WidthStep * Height);
                NativeMethods.cvReleaseImage(ref handle);
            }
            else NativeMethods.cvReleaseImageHeader(ref handle);
            return true;
        }

        class IplImageSubRect : IplImage
        {
            IplImage owner;

            public IplImageSubRect(IplImage source, _CvMat subRect)
                : base(true)
            {
                var pImage = NativeMethods.cvCreateImageHeader(new CvSize(subRect.cols, subRect.rows), source.Depth, source.Channels);
                SetHandle(pImage);
                SetData(subRect.data, subRect.step);
                owner = source;
            }

            protected override bool ReleaseHandle()
            {
                base.ReleaseHandle();
                owner = null;
                return true;
            }
        }
    }
}
