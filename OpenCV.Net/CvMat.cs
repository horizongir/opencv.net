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

        public CvMatDepth Depth
        {
            get
            {
                unsafe
                {
                    return (CvMatDepth)(((_CvMat*)handle.ToPointer())->type & DepthMask);
                }
            }
        }

        public int NumChannels
        {
            get
            {
                unsafe
                {
                    return ((((_CvMat*)handle.ToPointer())->type >> ChannelShift) & (MaxChannels - 1)) + 1;
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
            _CvMat subRect;
            core.cvGetSubRect(this, out subRect, rect);
            return new CvMatSubMat(this, subRect);
        }

        public CvMat GetRow(int row)
        {
            return GetRows(row, row + 1, 1);
        }

        public CvMat GetRows(int startRow, int endRow)
        {
            return GetRows(startRow, endRow, 1);
        }

        public CvMat GetRows(int startRow, int endRow, int deltaRow)
        {
            _CvMat subMat;
            core.cvGetRows(this, out subMat, startRow, endRow, deltaRow);
            return new CvMatSubMat(this, subMat);
        }

        public CvMat GetCol(int col)
        {
            return GetCols(col, col + 1);
        }

        public CvMat GetCols(int startCol, int endCol)
        {
            _CvMat subMat;
            core.cvGetCols(this, out subMat, startCol, endCol);
            return new CvMatSubMat(this, subMat);
        }

        public CvMat GetDiag()
        {
            return GetDiag(0);
        }

        public CvMat GetDiag(int diag)
        {
            _CvMat subMat;
            core.cvGetDiag(this, out subMat, diag);
            return new CvMatSubMat(this, subMat);
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

        class CvMatSubMat : CvMat
        {
            CvMat owner;

            public CvMatSubMat(CvMat source, _CvMat subMat)
                : base(true)
            {
                var pMat = core.cvCreateMatHeader(subMat.rows, subMat.cols, subMat.type);
                SetHandle(pMat);
                SetData(subMat.data, subMat.step);
                owner = source;
            }

            protected override bool ReleaseHandle()
            {
                base.ReleaseHandle();
                owner = null;
                return true;
            }
        }

        class CvMatDataHandle : CvMat
        {
            GCHandle dataHandle;

            public CvMatDataHandle(int rows, int cols, CvMatDepth depth, int channels, object data)
                : this(rows, cols, depth, channels, GCHandle.Alloc(data, GCHandleType.Pinned))
            {
            }

            private CvMatDataHandle(int rows, int cols, CvMatDepth depth, int channels, GCHandle dataHandle)
                : base(rows, cols, depth, channels, dataHandle.AddrOfPinnedObject())
            {
                this.dataHandle = dataHandle;
            }

            protected override bool ReleaseHandle()
            {
                base.ReleaseHandle();
                dataHandle.Free();
                return true;
            }
        }

        public static CvMat CreateMatHeader(byte[] data)
        {
            return new CvMatDataHandle(1, data.Length, CvMatDepth.CV_8U, 1, data);
        }

        public static CvMat CreateMatHeader(byte[,] data)
        {
            return new CvMatDataHandle(data.GetLength(0), data.GetLength(1), CvMatDepth.CV_8U, 1, data);
        }

        public static CvMat CreateMatHeader(short[] data)
        {
            return new CvMatDataHandle(1, data.Length, CvMatDepth.CV_16S, 1, data);
        }

        public static CvMat CreateMatHeader(short[,] data)
        {
            return new CvMatDataHandle(data.GetLength(0), data.GetLength(1), CvMatDepth.CV_16S, 1, data);
        }

        public static CvMat CreateMatHeader(ushort[] data)
        {
            return new CvMatDataHandle(1, data.Length, CvMatDepth.CV_16U, 1, data);
        }

        public static CvMat CreateMatHeader(ushort[,] data)
        {
            return new CvMatDataHandle(data.GetLength(0), data.GetLength(1), CvMatDepth.CV_16U, 1, data);
        }

        public static CvMat CreateMatHeader(int[] data)
        {
            return new CvMatDataHandle(1, data.Length, CvMatDepth.CV_32S, 1, data);
        }

        public static CvMat CreateMatHeader(int[,] data)
        {
            return new CvMatDataHandle(data.GetLength(0), data.GetLength(1), CvMatDepth.CV_32S, 1, data);
        }

        public static CvMat CreateMatHeader(float[] data)
        {
            return new CvMatDataHandle(1, data.Length, CvMatDepth.CV_32F, 1, data);
        }

        public static CvMat CreateMatHeader(float[,] data)
        {
            return new CvMatDataHandle(data.GetLength(0), data.GetLength(1), CvMatDepth.CV_32F, 1, data);
        }

        public static CvMat CreateMatHeader(double[] data)
        {
            return new CvMatDataHandle(1, data.Length, CvMatDepth.CV_64F, 1, data);
        }

        public static CvMat CreateMatHeader(double[,] data)
        {
            return new CvMatDataHandle(data.GetLength(0), data.GetLength(1), CvMatDepth.CV_64F, 1, data);
        }

        public static CvMat FromArray(byte[] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        public static CvMat FromArray(byte[,] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        public static CvMat FromArray(short[] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        public static CvMat FromArray(short[,] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        public static CvMat FromArray(ushort[] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        public static CvMat FromArray(ushort[,] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        public static CvMat FromArray(int[] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        public static CvMat FromArray(int[,] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        public static CvMat FromArray(float[] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        public static CvMat FromArray(float[,] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        public static CvMat FromArray(double[] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        public static CvMat FromArray(double[,] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }
    }
}
