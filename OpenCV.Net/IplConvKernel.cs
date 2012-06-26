using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using OpenCV.Net.Native;

namespace OpenCV.Net
{
    public class IplConvKernel : SafeHandleZeroOrMinusOneIsInvalid
    {
        public static readonly IplConvKernel Null = new IplConvKernel();

        internal IplConvKernel()
            : base(true)
        {
        }

        public IplConvKernel(int cols, int rows, int anchorX, int anchorY, StructuringElementShape shape)
            : this(cols, rows, anchorX, anchorY, shape, null)
        {
        }

        public IplConvKernel(int cols, int rows, int anchorX, int anchorY, StructuringElementShape shape, int[] values)
            : base(true)
        {
            var pKernel = imgproc.cvCreateStructuringElementEx(cols, rows, anchorX, anchorY, shape, values);
            SetHandle(pKernel);
        }

        protected override bool ReleaseHandle()
        {
            var pHandle = GCHandle.Alloc(handle, GCHandleType.Pinned);
            try
            {
                imgproc.cvReleaseStructuringElement(pHandle.AddrOfPinnedObject());
                return true;
            }
            finally { pHandle.Free(); }
        }

        public CvSize Size
        {
            get
            {
                unsafe
                {
                    return new CvSize(((_IplConvKernel*)handle.ToPointer())->nCols,
                                      ((_IplConvKernel*)handle.ToPointer())->nRows);
                }
            }
        }

        public CvPoint Anchor
        {
            get
            {
                unsafe
                {
                    return new CvPoint(((_IplConvKernel*)handle.ToPointer())->anchorX,
                                       ((_IplConvKernel*)handle.ToPointer())->anchorY);
                }
            }
        }
    }
}
