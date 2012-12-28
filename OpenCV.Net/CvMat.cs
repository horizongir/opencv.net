using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCV.Net.Native;
using System.Runtime.InteropServices;

namespace OpenCV.Net
{
    public class CvMat : CvArr
    {
        bool ownsData;
        public new static readonly CvMat Null = new CvMatNull();

        const int MaxChannels = 512;
        const int ChannelShift = 3;
        const int DepthMax = 1 << ChannelShift;
        const int DepthMask = DepthMax - 1;
        const int AutoStep = 0x7fffffff;

        internal CvMat()
            : base(false)
        {
        }

        internal CvMat(bool ownsHandle)
            : base(ownsHandle)
        {
        }

        internal CvMat(IntPtr handle)
            : this(handle, true)
        {
        }

        internal CvMat(IntPtr handle, bool ownsHandle)
            : base(ownsHandle)
        {
            SetHandle(handle);

            if (ownsHandle)
            {
                GC.AddMemoryPressure(Step * Rows);
                ownsData = true;
            }
        }

        public CvMat(int rows, int cols, CvMatDepth depth, int channels)
            : this(core.cvCreateMat(rows, cols, GetMatType(depth, channels)), true)
        {
        }

        public CvMat(int rows, int cols, CvMatDepth depth, int channels, IntPtr data)
        {
            var type = GetMatType(depth, channels);
            var pMat = core.cvCreateMatHeader(rows, cols, type);
            SetHandle(pMat);
            SetData(data, Step);
        }

        public int Rows
        {
            get
            {
                unsafe
                {
                    return ((_CvMat*)handle.ToPointer())->rows;
                }
            }
        }

        public int Cols
        {
            get
            {
                unsafe
                {
                    return ((_CvMat*)handle.ToPointer())->cols;
                }
            }
        }

        public int Step
        {
            get
            {
                unsafe
                {
                    return ((_CvMat*)handle.ToPointer())->step;
                }
            }
        }

        public IntPtr Data
        {
            get
            {
                unsafe
                {
                    return ((_CvMat*)handle.ToPointer())->data;
                }
            }
        }

        static int GetMatType(CvMatDepth depth, int channels)
        {
            return ((int)depth & DepthMask) + ((channels - 1) << ChannelShift);
        }

        public CvMat Clone()
        {
            return new CvMat(core.cvCloneMat(this), true);
        }

        public CvMat GetSubRect(CvRect rect)
        {
            return new CvMatSubRect(this, rect);
        }

        protected override bool ReleaseHandle()
        {
            var pHandle = GCHandle.Alloc(handle, GCHandleType.Pinned);
            try
            {
                if (ownsData)
                {
                    GC.RemoveMemoryPressure(Step * Rows);
                }

                core.cvReleaseMat(pHandle.AddrOfPinnedObject());
                return true;
            }
            finally { pHandle.Free(); }
        }

        class CvMatNull : CvMat
        {
            public CvMatNull() : base(IntPtr.Zero, false) { }

            protected override bool ReleaseHandle()
            {
                return false;
            }
        }

        class CvMatSubRect : CvMat
        {
            CvMat owner;

            public CvMatSubRect(CvMat source, CvRect rect)
                : base(true)
            {
                _CvMat subRect;
                core.cvGetSubRect(source, out subRect, rect);
                var pMat = core.cvCreateMatHeader(subRect.rows, subRect.cols, subRect.type);
                SetHandle(pMat);
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
