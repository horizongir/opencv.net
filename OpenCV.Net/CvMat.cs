using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCV.Net.Native;
using System.Runtime.InteropServices;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a multi-channel matrix.
    /// </summary>
    public class CvMat : CvArr
    {
        bool ownsData;
        internal new static readonly CvMat Null = new CvMatNull();

        /// <summary>
        /// A constant passed to the <see cref="CvMat"/> constructor which specifies that no
        /// padding exists between subsequent rows of the matrix.
        /// </summary>
        public const int AutoStep = 0x7fffffff;

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

        /// <summary>
        /// Initializes a new instance of the <see cref="CvMat"/> class with the specified
        /// number of <paramref name="rows"/> and <paramref name="cols"/>, element bit
        /// <paramref name="depth"/> and <paramref name="channels"/> per element.
        /// </summary>
        /// <param name="rows">The number of rows in the matrix.</param>
        /// <param name="cols">The number of columns in the matrix.</param>
        /// <param name="depth">The bit depth of matrix elements.</param>
        /// <param name="channels">The number of channels per element.</param>
        public CvMat(int rows, int cols, CvDepth depth, int channels)
            : this(NativeMethods.cvCreateMat(rows, cols, MatHelper.GetMatType(depth, channels)), true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvMat"/> class with the specified
        /// number of <paramref name="rows"/> and <paramref name="cols"/>, element bit
        /// <paramref name="depth"/> and <paramref name="channels"/> per element.
        /// A pointer to the matrix raw <paramref name="data"/> is provided as well
        /// as the optional full row length <paramref name="step"/> size in bytes.
        /// </summary>
        /// <param name="rows">The number of rows in the matrix.</param>
        /// <param name="cols">The number of columns in the matrix.</param>
        /// <param name="depth">The bit depth of matrix elements.</param>
        /// <param name="channels">The number of channels per matrix element.</param>
        /// <param name="data">A pointer to the matrix raw element data.</param>
        /// <param name="step">The full row length in bytes.</param>
        public CvMat(int rows, int cols, CvDepth depth, int channels, IntPtr data, int step = AutoStep)
            : base(true)
        {
            var type = MatHelper.GetMatType(depth, channels);
            var pMat = NativeMethods.cvCreateMatHeader(rows, cols, type);
            NativeMethods.cvInitMatHeader(pMat, rows, cols, type, data, step); 
            SetHandle(pMat);
        }

        /// <summary>
        /// Gets the number of rows in the matrix.
        /// </summary>
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

        /// <summary>
        /// Gets the number of columns in the matrix.
        /// </summary>
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

        /// <summary>
        /// Gets the full row length in bytes.
        /// </summary>
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

        /// <summary>
        /// Gets the bit depth of matrix elements.
        /// </summary>
        public CvDepth Depth
        {
            get
            {
                unsafe
                {
                    return MatHelper.GetMatDepth(((_CvMat*)handle.ToPointer())->type);
                }
            }
        }

        /// <summary>
        /// Gets the number of channels per matrix element.
        /// </summary>
        public int Channels
        {
            get
            {
                unsafe
                {
                    return MatHelper.GetMatChannels(((_CvMat*)handle.ToPointer())->type);
                }
            }
        }

        /// <summary>
        /// Gets the size of each matrix element in bytes.
        /// </summary>
        public int ElementSize
        {
            get
            {
                unsafe
                {
                    return MatHelper.GetElemSize(((_CvMat*)handle.ToPointer())->type);
                }
            }
        }

        /// <summary>
        /// Gets a pointer to the aligned matrix data.
        /// </summary>
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

        /// <summary>
        /// Creates a new <see cref="CvMat"/> that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new <see cref="CvMat"/> that is a copy of this instance.
        /// <see cref="Step"/> may differ.
        /// </returns>
        public CvMat Clone()
        {
            return new CvMat(NativeMethods.cvCloneMat(this), true);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvMat"/> class that is a wrapper header for
        /// the specified <paramref name="data"/>. The reference to <paramref name="data"/> will be
        /// pinned in the garbage collector until the matrix header is released.
        /// </summary>
        /// <param name="data">The array to be wrapped.</param>
        /// <returns>
        /// A new <see cref="CvMat"/> instance that is a wrapper header around <paramref name="data"/>.
        /// </returns>
        public static CvMat CreateMatHeader(byte[] data)
        {
            return new CvMatDataHandle(1, data.Length, CvDepth.U8, 1, data);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvMat"/> class that is a wrapper header for
        /// the specified <paramref name="data"/>. The reference to <paramref name="data"/> will be
        /// pinned in the garbage collector until the matrix header is released.
        /// </summary>
        /// <param name="data">The array to be wrapped.</param>
        /// <returns>
        /// A new <see cref="CvMat"/> instance that is a wrapper header around <paramref name="data"/>.
        /// </returns>
        public static CvMat CreateMatHeader(byte[,] data)
        {
            return new CvMatDataHandle(data.GetLength(0), data.GetLength(1), CvDepth.U8, 1, data);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvMat"/> class that is a wrapper header for
        /// the specified <paramref name="data"/>. The reference to <paramref name="data"/> will be
        /// pinned in the garbage collector until the matrix header is released.
        /// </summary>
        /// <param name="data">The array to be wrapped.</param>
        /// <returns>
        /// A new <see cref="CvMat"/> instance that is a wrapper header around <paramref name="data"/>.
        /// </returns>
        public static CvMat CreateMatHeader(short[] data)
        {
            return new CvMatDataHandle(1, data.Length, CvDepth.S16, 1, data);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvMat"/> class that is a wrapper header for
        /// the specified <paramref name="data"/>. The reference to <paramref name="data"/> will be
        /// pinned in the garbage collector until the matrix header is released.
        /// </summary>
        /// <param name="data">The array to be wrapped.</param>
        /// <returns>
        /// A new <see cref="CvMat"/> instance that is a wrapper header around <paramref name="data"/>.
        /// </returns>
        public static CvMat CreateMatHeader(short[,] data)
        {
            return new CvMatDataHandle(data.GetLength(0), data.GetLength(1), CvDepth.S16, 1, data);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvMat"/> class that is a wrapper header for
        /// the specified <paramref name="data"/>. The reference to <paramref name="data"/> will be
        /// pinned in the garbage collector until the matrix header is released.
        /// </summary>
        /// <param name="data">The array to be wrapped.</param>
        /// <returns>
        /// A new <see cref="CvMat"/> instance that is a wrapper header around <paramref name="data"/>.
        /// </returns>
        public static CvMat CreateMatHeader(ushort[] data)
        {
            return new CvMatDataHandle(1, data.Length, CvDepth.U16, 1, data);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvMat"/> class that is a wrapper header for
        /// the specified <paramref name="data"/>. The reference to <paramref name="data"/> will be
        /// pinned in the garbage collector until the matrix header is released.
        /// </summary>
        /// <param name="data">The array to be wrapped.</param>
        /// <returns>
        /// A new <see cref="CvMat"/> instance that is a wrapper header around <paramref name="data"/>.
        /// </returns>
        public static CvMat CreateMatHeader(ushort[,] data)
        {
            return new CvMatDataHandle(data.GetLength(0), data.GetLength(1), CvDepth.U16, 1, data);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvMat"/> class that is a wrapper header for
        /// the specified <paramref name="data"/>. The reference to <paramref name="data"/> will be
        /// pinned in the garbage collector until the matrix header is released.
        /// </summary>
        /// <param name="data">The array to be wrapped.</param>
        /// <returns>
        /// A new <see cref="CvMat"/> instance that is a wrapper header around <paramref name="data"/>.
        /// </returns>
        public static CvMat CreateMatHeader(int[] data)
        {
            return new CvMatDataHandle(1, data.Length, CvDepth.S32, 1, data);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvMat"/> class that is a wrapper header for
        /// the specified <paramref name="data"/>. The reference to <paramref name="data"/> will be
        /// pinned in the garbage collector until the matrix header is released.
        /// </summary>
        /// <param name="data">The array to be wrapped.</param>
        /// <returns>
        /// A new <see cref="CvMat"/> instance that is a wrapper header around <paramref name="data"/>.
        /// </returns>
        public static CvMat CreateMatHeader(int[,] data)
        {
            return new CvMatDataHandle(data.GetLength(0), data.GetLength(1), CvDepth.S32, 1, data);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvMat"/> class that is a wrapper header for
        /// the specified <paramref name="data"/>. The reference to <paramref name="data"/> will be
        /// pinned in the garbage collector until the matrix header is released.
        /// </summary>
        /// <param name="data">The array to be wrapped.</param>
        /// <returns>
        /// A new <see cref="CvMat"/> instance that is a wrapper header around <paramref name="data"/>.
        /// </returns>
        public static CvMat CreateMatHeader(float[] data)
        {
            return new CvMatDataHandle(1, data.Length, CvDepth.F32, 1, data);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvMat"/> class that is a wrapper header for
        /// the specified <paramref name="data"/>. The reference to <paramref name="data"/> will be
        /// pinned in the garbage collector until the matrix header is released.
        /// </summary>
        /// <param name="data">The array to be wrapped.</param>
        /// <returns>
        /// A new <see cref="CvMat"/> instance that is a wrapper header around <paramref name="data"/>.
        /// </returns>
        public static CvMat CreateMatHeader(float[,] data)
        {
            return new CvMatDataHandle(data.GetLength(0), data.GetLength(1), CvDepth.F32, 1, data);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvMat"/> class that is a wrapper header for
        /// the specified <paramref name="data"/>. The reference to <paramref name="data"/> will be
        /// pinned in the garbage collector until the matrix header is released.
        /// </summary>
        /// <param name="data">The array to be wrapped.</param>
        /// <returns>
        /// A new <see cref="CvMat"/> instance that is a wrapper header around <paramref name="data"/>.
        /// </returns>
        public static CvMat CreateMatHeader(double[] data)
        {
            return new CvMatDataHandle(1, data.Length, CvDepth.F64, 1, data);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvMat"/> class that is a wrapper header for
        /// the specified <paramref name="data"/>. The reference to <paramref name="data"/> will be
        /// pinned in the garbage collector until the matrix header is released.
        /// </summary>
        /// <param name="data">The array to be wrapped.</param>
        /// <returns>
        /// A new <see cref="CvMat"/> instance that is a wrapper header around <paramref name="data"/>.
        /// </returns>
        public static CvMat CreateMatHeader(double[,] data)
        {
            return new CvMatDataHandle(data.GetLength(0), data.GetLength(1), CvDepth.F64, 1, data);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvMat"/> class that is a copy of
        /// the specified managed array <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The array that is to be converted to a <see cref="CvMat"/>.</param>
        /// <returns>
        /// A new <see cref="CvMat"/> instance that is a copy of the <paramref name="data"/> array.
        /// </returns>
        public static CvMat FromArray(byte[] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvMat"/> class that is a copy of
        /// the specified managed array <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The array that is to be converted to a <see cref="CvMat"/>.</param>
        /// <returns>
        /// A new <see cref="CvMat"/> instance that is a copy of the <paramref name="data"/> array.
        /// </returns>
        public static CvMat FromArray(byte[,] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvMat"/> class that is a copy of
        /// the specified managed array <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The array that is to be converted to a <see cref="CvMat"/>.</param>
        /// <returns>
        /// A new <see cref="CvMat"/> instance that is a copy of the <paramref name="data"/> array.
        /// </returns>
        public static CvMat FromArray(short[] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvMat"/> class that is a copy of
        /// the specified managed array <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The array that is to be converted to a <see cref="CvMat"/>.</param>
        /// <returns>
        /// A new <see cref="CvMat"/> instance that is a copy of the <paramref name="data"/> array.
        /// </returns>
        public static CvMat FromArray(short[,] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvMat"/> class that is a copy of
        /// the specified managed array <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The array that is to be converted to a <see cref="CvMat"/>.</param>
        /// <returns>
        /// A new <see cref="CvMat"/> instance that is a copy of the <paramref name="data"/> array.
        /// </returns>
        public static CvMat FromArray(ushort[] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvMat"/> class that is a copy of
        /// the specified managed array <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The array that is to be converted to a <see cref="CvMat"/>.</param>
        /// <returns>
        /// A new <see cref="CvMat"/> instance that is a copy of the <paramref name="data"/> array.
        /// </returns>
        public static CvMat FromArray(ushort[,] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvMat"/> class that is a copy of
        /// the specified managed array <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The array that is to be converted to a <see cref="CvMat"/>.</param>
        /// <returns>
        /// A new <see cref="CvMat"/> instance that is a copy of the <paramref name="data"/> array.
        /// </returns>
        public static CvMat FromArray(int[] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvMat"/> class that is a copy of
        /// the specified managed array <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The array that is to be converted to a <see cref="CvMat"/>.</param>
        /// <returns>
        /// A new <see cref="CvMat"/> instance that is a copy of the <paramref name="data"/> array.
        /// </returns>
        public static CvMat FromArray(int[,] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvMat"/> class that is a copy of
        /// the specified managed array <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The array that is to be converted to a <see cref="CvMat"/>.</param>
        /// <returns>
        /// A new <see cref="CvMat"/> instance that is a copy of the <paramref name="data"/> array.
        /// </returns>
        public static CvMat FromArray(float[] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvMat"/> class that is a copy of
        /// the specified managed array <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The array that is to be converted to a <see cref="CvMat"/>.</param>
        /// <returns>
        /// A new <see cref="CvMat"/> instance that is a copy of the <paramref name="data"/> array.
        /// </returns>
        public static CvMat FromArray(float[,] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvMat"/> class that is a copy of
        /// the specified managed array <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The array that is to be converted to a <see cref="CvMat"/>.</param>
        /// <returns>
        /// A new <see cref="CvMat"/> instance that is a copy of the <paramref name="data"/> array.
        /// </returns>
        public static CvMat FromArray(double[] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvMat"/> class that is a copy of
        /// the specified managed array <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The array that is to be converted to a <see cref="CvMat"/>.</param>
        /// <returns>
        /// A new <see cref="CvMat"/> instance that is a copy of the <paramref name="data"/> array.
        /// </returns>
        public static CvMat FromArray(double[,] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        /// <summary>
        /// Executes the code required to free the native <see cref="CvMat"/> handle.
        /// </summary>
        /// <returns>
        /// <b>true</b> if the handle is released successfully; otherwise, in the event of a
        /// catastrophic failure, <b>false</b>.
        /// </returns>
        protected override bool ReleaseHandle()
        {
            if (ownsData)
            {
                GC.RemoveMemoryPressure(Step * Rows);
            }

            NativeMethods.cvReleaseMat(ref handle);
            return true;
        }

        class CvMatDataHandle : CvMat
        {
            GCHandle dataHandle;

            public CvMatDataHandle(int rows, int cols, CvDepth depth, int channels, object data)
                : this(rows, cols, depth, channels, GCHandle.Alloc(data, GCHandleType.Pinned))
            {
            }

            private CvMatDataHandle(int rows, int cols, CvDepth depth, int channels, GCHandle dataHandle)
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

        class CvMatNull : CvMat
        {
            public CvMatNull() : base(IntPtr.Zero, false) { }

            protected override bool ReleaseHandle()
            {
                return false;
            }
        }
    }
}
