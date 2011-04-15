﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCV.Net.Native;
using System.Runtime.InteropServices;

namespace OpenCV.Net
{
    public class IplImage : CvArr
    {
        public IplImage(CvSize size, int depth, int channels)
        {
            var pImage = core.cvCreateImage(size, depth, channels);
            SetHandle(pImage);
        }

        public IplImage(CvSize size, int depth, int channels, IntPtr data)
        {
            var pImage = core.cvCreateImageHeader(size, depth, channels);
            SetHandle(pImage);

            SetData(data, WidthStep);
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

        protected override bool ReleaseHandle()
        {
            var pHandle = GCHandle.Alloc(handle, GCHandleType.Pinned);
            try
            {
                core.cvReleaseImage(pHandle.AddrOfPinnedObject());
                return true;
            }
            finally { pHandle.Free(); }
        }
    }
}
