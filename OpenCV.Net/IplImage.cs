using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCV.Net.Native;
using System.Runtime.InteropServices;

namespace OpenCV.Net
{
    public class IplImage : CvArr
    {
        bool ownsData;

        internal IplImage()
        {
            ownsData = true;
        }

        internal IplImage(IntPtr handle, bool ownsHandle)
            : base(ownsHandle)
        {
            SetHandle(handle);

            if (ownsHandle)
            {
                GC.AddMemoryPressure(WidthStep * Height * Depth / 8);
                ownsData = true;
            }
        }

        public IplImage(CvSize size, int depth, int channels)
            : this(core.cvCreateImage(size, depth, channels), true)
        {
        }

        public IplImage(CvSize size, int depth, int channels, IntPtr data)
        {
            var pImage = core.cvCreateImageHeader(size, depth, channels);
            SetHandle(pImage);
            SetData(data, WidthStep);
        }

        public CvRect ImageROI
        {
            get { return core.cvGetImageROI(this); }
            set { core.cvSetImageROI(this, value); }
        }

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

        public CvSize Size
        {
            get
            {
                unsafe
                {
                    return new CvSize(((_IplImage*)handle.ToPointer())->width,
                                      ((_IplImage*)handle.ToPointer())->height);
                }
            }
        }

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

        public int Depth
        {
            get
            {
                unsafe
                {
                    return ((_IplImage*)handle.ToPointer())->depth;
                }
            }
        }

        public int NumChannels
        {
            get
            {
                unsafe
                {
                    return ((_IplImage*)handle.ToPointer())->nChannels;
                }
            }
        }

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

        public IplImage Clone()
        {
            return new IplImage(core.cvCloneImage(this), true);
        }

        public void ResetImageROI()
        {
            core.cvResetImageROI(this);
        }

        protected override bool ReleaseHandle()
        {
            var pHandle = GCHandle.Alloc(handle, GCHandleType.Pinned);
            try
            {
                if (ownsData)
                {
                    GC.RemoveMemoryPressure(WidthStep * Height * Depth / 8);
                    core.cvReleaseImage(pHandle.AddrOfPinnedObject());
                }
                else core.cvReleaseImageHeader(pHandle.AddrOfPinnedObject());
                return true;
            }
            finally { pHandle.Free(); }
        }
    }
}
