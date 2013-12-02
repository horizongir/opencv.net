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
    public class Mat : Arr
    {
        bool ownsData;
        internal new static readonly Mat Null = new MatNull();

        /// <summary>
        /// A constant passed to the <see cref="Mat"/> constructor which specifies that no
        /// padding exists between subsequent rows of the matrix.
        /// </summary>
        public const int AutoStep = 0x7fffffff;

        internal Mat()
            : base(false)
        {
        }

        internal Mat(bool ownsHandle)
            : base(ownsHandle)
        {
        }

        internal Mat(IntPtr handle)
            : this(handle, true)
        {
        }

        internal Mat(IntPtr handle, bool ownsHandle)
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
        /// Initializes a new instance of the <see cref="Mat"/> class with the specified
        /// number of <paramref name="rows"/> and <paramref name="cols"/>, element bit
        /// <paramref name="depth"/> and <paramref name="channels"/> per element.
        /// </summary>
        /// <param name="rows">The number of rows in the matrix.</param>
        /// <param name="cols">The number of columns in the matrix.</param>
        /// <param name="depth">The bit depth of matrix elements.</param>
        /// <param name="channels">The number of channels per element.</param>
        public Mat(int rows, int cols, Depth depth, int channels)
            : this(NativeMethods.cvCreateMat(rows, cols, MatHelper.GetMatType(depth, channels)), true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mat"/> class with the specified
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
        public Mat(int rows, int cols, Depth depth, int channels, IntPtr data, int step = AutoStep)
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
        public Depth Depth
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
        /// Creates a new <see cref="Mat"/> that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new <see cref="Mat"/> that is a copy of this instance.
        /// <see cref="Step"/> may differ.
        /// </returns>
        public Mat Clone()
        {
            return new Mat(NativeMethods.cvCloneMat(this), true);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mat"/> class that is a wrapper header for
        /// the specified <paramref name="data"/>. The reference to <paramref name="data"/> will be
        /// pinned in the garbage collector until the matrix header is released.
        /// </summary>
        /// <param name="data">The array to be wrapped.</param>
        /// <returns>
        /// A new <see cref="Mat"/> instance that is a wrapper header around <paramref name="data"/>.
        /// </returns>
        public static Mat CreateMatHeader(byte[] data)
        {
            return new MatDataHandle(1, data.Length, Depth.U8, 1, data);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mat"/> class that is a wrapper header for
        /// the specified <paramref name="data"/>. The reference to <paramref name="data"/> will be
        /// pinned in the garbage collector until the matrix header is released.
        /// </summary>
        /// <param name="data">The array to be wrapped.</param>
        /// <returns>
        /// A new <see cref="Mat"/> instance that is a wrapper header around <paramref name="data"/>.
        /// </returns>
        public static Mat CreateMatHeader(byte[,] data)
        {
            return new MatDataHandle(data.GetLength(0), data.GetLength(1), Depth.U8, 1, data);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mat"/> class that is a wrapper header for
        /// the specified <paramref name="data"/>. The reference to <paramref name="data"/> will be
        /// pinned in the garbage collector until the matrix header is released.
        /// </summary>
        /// <param name="data">The array to be wrapped.</param>
        /// <returns>
        /// A new <see cref="Mat"/> instance that is a wrapper header around <paramref name="data"/>.
        /// </returns>
        public static Mat CreateMatHeader(short[] data)
        {
            return new MatDataHandle(1, data.Length, Depth.S16, 1, data);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mat"/> class that is a wrapper header for
        /// the specified <paramref name="data"/>. The reference to <paramref name="data"/> will be
        /// pinned in the garbage collector until the matrix header is released.
        /// </summary>
        /// <param name="data">The array to be wrapped.</param>
        /// <returns>
        /// A new <see cref="Mat"/> instance that is a wrapper header around <paramref name="data"/>.
        /// </returns>
        public static Mat CreateMatHeader(short[,] data)
        {
            return new MatDataHandle(data.GetLength(0), data.GetLength(1), Depth.S16, 1, data);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mat"/> class that is a wrapper header for
        /// the specified <paramref name="data"/>. The reference to <paramref name="data"/> will be
        /// pinned in the garbage collector until the matrix header is released.
        /// </summary>
        /// <param name="data">The array to be wrapped.</param>
        /// <returns>
        /// A new <see cref="Mat"/> instance that is a wrapper header around <paramref name="data"/>.
        /// </returns>
        public static Mat CreateMatHeader(ushort[] data)
        {
            return new MatDataHandle(1, data.Length, Depth.U16, 1, data);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mat"/> class that is a wrapper header for
        /// the specified <paramref name="data"/>. The reference to <paramref name="data"/> will be
        /// pinned in the garbage collector until the matrix header is released.
        /// </summary>
        /// <param name="data">The array to be wrapped.</param>
        /// <returns>
        /// A new <see cref="Mat"/> instance that is a wrapper header around <paramref name="data"/>.
        /// </returns>
        public static Mat CreateMatHeader(ushort[,] data)
        {
            return new MatDataHandle(data.GetLength(0), data.GetLength(1), Depth.U16, 1, data);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mat"/> class that is a wrapper header for
        /// the specified <paramref name="data"/>. The reference to <paramref name="data"/> will be
        /// pinned in the garbage collector until the matrix header is released.
        /// </summary>
        /// <param name="data">The array to be wrapped.</param>
        /// <returns>
        /// A new <see cref="Mat"/> instance that is a wrapper header around <paramref name="data"/>.
        /// </returns>
        public static Mat CreateMatHeader(int[] data)
        {
            return new MatDataHandle(1, data.Length, Depth.S32, 1, data);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mat"/> class that is a wrapper header for
        /// the specified <paramref name="data"/>. The reference to <paramref name="data"/> will be
        /// pinned in the garbage collector until the matrix header is released.
        /// </summary>
        /// <param name="data">The array to be wrapped.</param>
        /// <returns>
        /// A new <see cref="Mat"/> instance that is a wrapper header around <paramref name="data"/>.
        /// </returns>
        public static Mat CreateMatHeader(int[,] data)
        {
            return new MatDataHandle(data.GetLength(0), data.GetLength(1), Depth.S32, 1, data);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mat"/> class that is a wrapper header for
        /// the specified <paramref name="data"/>. The reference to <paramref name="data"/> will be
        /// pinned in the garbage collector until the matrix header is released.
        /// </summary>
        /// <param name="data">The array to be wrapped.</param>
        /// <returns>
        /// A new <see cref="Mat"/> instance that is a wrapper header around <paramref name="data"/>.
        /// </returns>
        public static Mat CreateMatHeader(float[] data)
        {
            return new MatDataHandle(1, data.Length, Depth.F32, 1, data);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mat"/> class that is a wrapper header for
        /// the specified <paramref name="data"/>. The reference to <paramref name="data"/> will be
        /// pinned in the garbage collector until the matrix header is released.
        /// </summary>
        /// <param name="data">The array to be wrapped.</param>
        /// <returns>
        /// A new <see cref="Mat"/> instance that is a wrapper header around <paramref name="data"/>.
        /// </returns>
        public static Mat CreateMatHeader(float[,] data)
        {
            return new MatDataHandle(data.GetLength(0), data.GetLength(1), Depth.F32, 1, data);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mat"/> class that is a wrapper header for
        /// the specified <paramref name="data"/>. The reference to <paramref name="data"/> will be
        /// pinned in the garbage collector until the matrix header is released.
        /// </summary>
        /// <param name="data">The array to be wrapped.</param>
        /// <returns>
        /// A new <see cref="Mat"/> instance that is a wrapper header around <paramref name="data"/>.
        /// </returns>
        public static Mat CreateMatHeader(double[] data)
        {
            return new MatDataHandle(1, data.Length, Depth.F64, 1, data);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mat"/> class that is a wrapper header for
        /// the specified <paramref name="data"/>. The reference to <paramref name="data"/> will be
        /// pinned in the garbage collector until the matrix header is released.
        /// </summary>
        /// <param name="data">The array to be wrapped.</param>
        /// <returns>
        /// A new <see cref="Mat"/> instance that is a wrapper header around <paramref name="data"/>.
        /// </returns>
        public static Mat CreateMatHeader(double[,] data)
        {
            return new MatDataHandle(data.GetLength(0), data.GetLength(1), Depth.F64, 1, data);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mat"/> class that is a copy of
        /// the specified managed array <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The array that is to be converted to a <see cref="Mat"/>.</param>
        /// <returns>
        /// A new <see cref="Mat"/> instance that is a copy of the <paramref name="data"/> array.
        /// </returns>
        public static Mat FromArray(byte[] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mat"/> class that is a copy of
        /// the specified managed array <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The array that is to be converted to a <see cref="Mat"/>.</param>
        /// <returns>
        /// A new <see cref="Mat"/> instance that is a copy of the <paramref name="data"/> array.
        /// </returns>
        public static Mat FromArray(byte[,] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mat"/> class that is a copy of
        /// the specified managed array <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The array that is to be converted to a <see cref="Mat"/>.</param>
        /// <returns>
        /// A new <see cref="Mat"/> instance that is a copy of the <paramref name="data"/> array.
        /// </returns>
        public static Mat FromArray(short[] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mat"/> class that is a copy of
        /// the specified managed array <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The array that is to be converted to a <see cref="Mat"/>.</param>
        /// <returns>
        /// A new <see cref="Mat"/> instance that is a copy of the <paramref name="data"/> array.
        /// </returns>
        public static Mat FromArray(short[,] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mat"/> class that is a copy of
        /// the specified managed array <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The array that is to be converted to a <see cref="Mat"/>.</param>
        /// <returns>
        /// A new <see cref="Mat"/> instance that is a copy of the <paramref name="data"/> array.
        /// </returns>
        public static Mat FromArray(ushort[] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mat"/> class that is a copy of
        /// the specified managed array <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The array that is to be converted to a <see cref="Mat"/>.</param>
        /// <returns>
        /// A new <see cref="Mat"/> instance that is a copy of the <paramref name="data"/> array.
        /// </returns>
        public static Mat FromArray(ushort[,] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mat"/> class that is a copy of
        /// the specified managed array <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The array that is to be converted to a <see cref="Mat"/>.</param>
        /// <returns>
        /// A new <see cref="Mat"/> instance that is a copy of the <paramref name="data"/> array.
        /// </returns>
        public static Mat FromArray(int[] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mat"/> class that is a copy of
        /// the specified managed array <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The array that is to be converted to a <see cref="Mat"/>.</param>
        /// <returns>
        /// A new <see cref="Mat"/> instance that is a copy of the <paramref name="data"/> array.
        /// </returns>
        public static Mat FromArray(int[,] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mat"/> class that is a copy of
        /// the specified managed array <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The array that is to be converted to a <see cref="Mat"/>.</param>
        /// <returns>
        /// A new <see cref="Mat"/> instance that is a copy of the <paramref name="data"/> array.
        /// </returns>
        public static Mat FromArray(float[] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mat"/> class that is a copy of
        /// the specified managed array <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The array that is to be converted to a <see cref="Mat"/>.</param>
        /// <returns>
        /// A new <see cref="Mat"/> instance that is a copy of the <paramref name="data"/> array.
        /// </returns>
        public static Mat FromArray(float[,] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mat"/> class that is a copy of
        /// the specified managed array <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The array that is to be converted to a <see cref="Mat"/>.</param>
        /// <returns>
        /// A new <see cref="Mat"/> instance that is a copy of the <paramref name="data"/> array.
        /// </returns>
        public static Mat FromArray(double[] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mat"/> class that is a copy of
        /// the specified managed array <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The array that is to be converted to a <see cref="Mat"/>.</param>
        /// <returns>
        /// A new <see cref="Mat"/> instance that is a copy of the <paramref name="data"/> array.
        /// </returns>
        public static Mat FromArray(double[,] data)
        {
            using (var dataHeader = CreateMatHeader(data))
            {
                return dataHeader.Clone();
            }
        }

        /// <summary>
        /// Executes the code required to free the native <see cref="Mat"/> handle.
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

        class MatDataHandle : Mat
        {
            GCHandle dataHandle;

            public MatDataHandle(int rows, int cols, Depth depth, int channels, object data)
                : this(rows, cols, depth, channels, GCHandle.Alloc(data, GCHandleType.Pinned))
            {
            }

            private MatDataHandle(int rows, int cols, Depth depth, int channels, GCHandle dataHandle)
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

        class MatNull : Mat
        {
            public MatNull() : base(IntPtr.Zero, false) { }

            protected override bool ReleaseHandle()
            {
                return false;
            }
        }

        #region Operator Overloads

        /// <summary>
        /// Returns the <see cref="Mat"/> value (the sign is unchanged).
        /// </summary>
        /// <param name="mat">The matrix to return.</param>
        /// <returns>The matrix <paramref name="mat"/>.</returns>
        public static Mat operator +(Mat mat)
        {
            return mat;
        }

        /// <summary>
        /// Negates the specified <see cref="Mat"/> value.
        /// </summary>
        /// <param name="mat">The matrix to negate.</param>
        /// <returns>
        /// The result of <paramref name="mat"/> multiplied by negative one (-1).
        /// </returns>
        public static Mat operator -(Mat mat)
        {
            var result = new Mat(mat.Rows, mat.Cols, mat.Depth, mat.Channels);
            CV.ConvertScale(mat, result, -1, 0);
            return result;
        }

        /// <summary>
        /// Performs per-element bit-wise inversion of the specified <see cref="Mat"/> value.
        /// </summary>
        /// <param name="mat">The matrix to invert.</param>
        /// <returns>The result of bitwise inverting <paramref name="mat"/>.</returns>
        public static Mat operator ~(Mat mat)
        {
            var result = new Mat(mat.Rows, mat.Cols, mat.Depth, mat.Channels);
            CV.Not(mat, result);
            return result;
        }

        /// <summary>
        /// Calculates the per-element sum of two <see cref="Mat"/> values.
        /// </summary>
        /// <param name="left">The first value to add.</param>
        /// <param name="right">The second value to add.</param>
        /// <returns>
        /// The result of adding <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        public static Mat operator +(Mat left, Mat right)
        {
            var result = new Mat(left.Rows, left.Cols, left.Depth, left.Channels);
            CV.Add(left, right, result);
            return result;
        }

        /// <summary>
        /// Calculates the per-element sum of a <see cref="Mat"/> and a <see cref="Scalar"/>.
        /// </summary>
        /// <param name="left">The matrix to add.</param>
        /// <param name="right">The scalar to add.</param>
        /// <returns>
        /// The result of adding <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        public static Mat operator +(Mat left, Scalar right)
        {
            var result = new Mat(left.Rows, left.Cols, left.Depth, left.Channels);
            CV.AddS(left, right, result);
            return result;
        }

        /// <summary>
        /// Calculates the per-element sum of a <see cref="Scalar"/> and a <see cref="Mat"/>.
        /// </summary>
        /// <param name="left">The scalar to add.</param>
        /// <param name="right">The matrix to add.</param>
        /// <returns>
        /// The result of adding <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        public static Mat operator +(Scalar left, Mat right)
        {
            var result = new Mat(right.Rows, right.Cols, right.Depth, right.Channels);
            CV.AddS(right, left, result);
            return result;
        }

        /// <summary>
        /// Calculates the per-element sum of a <see cref="Mat"/> and a
        /// <see cref="double"/> value.
        /// </summary>
        /// <param name="left">The matrix to add.</param>
        /// <param name="right">The scalar value to add.</param>
        /// <returns>
        /// The result of adding <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        public static Mat operator +(Mat left, double right)
        {
            var result = new Mat(left.Rows, left.Cols, left.Depth, left.Channels);
            CV.ConvertScale(left, result, 1, right);
            return result;
        }

        /// <summary>
        /// Calculates the per-element sum of a <see cref="double"/> value and a
        /// <see cref="Mat"/>.
        /// </summary>
        /// <param name="left">The scalar value to add.</param>
        /// <param name="right">The matrix to add.</param>
        /// <returns>
        /// The result of adding <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        public static Mat operator +(double left, Mat right)
        {
            var result = new Mat(right.Rows, right.Cols, right.Depth, right.Channels);
            CV.ConvertScale(right, result, 1, left);
            return result;
        }

        /// <summary>
        /// Calculates the per-element difference between two <see cref="Mat"/> values.
        /// </summary>
        /// <param name="left">The minuend.</param>
        /// <param name="right">The subtrahend.</param>
        /// <returns>
        /// The result of subtracting <paramref name="right"/> from <paramref name="left"/>.
        /// </returns>
        public static Mat operator -(Mat left, Mat right)
        {
            var result = new Mat(left.Rows, left.Cols, left.Depth, left.Channels);
            CV.Sub(left, right, result);
            return result;
        }

        /// <summary>
        /// Calculates the per-element difference between a <see cref="Mat"/> and a
        /// <see cref="Scalar"/>.
        /// </summary>
        /// <param name="left">The matrix minuend.</param>
        /// <param name="right">The scalar subtrahend.</param>
        /// <returns>
        /// The result of subtracting <paramref name="right"/> from <paramref name="left"/>.
        /// </returns>
        public static Mat operator -(Mat left, Scalar right)
        {
            var result = new Mat(left.Rows, left.Cols, left.Depth, left.Channels);
            CV.SubS(left, right, result);
            return result;
        }

        /// <summary>
        /// Subtracts every element of the specified <see cref="Mat"/> value from a
        /// <see cref="Scalar"/>.
        /// </summary>
        /// <param name="left">The scalar minuend.</param>
        /// <param name="right">The matrix subtrahend.</param>
        /// <returns>
        /// The result of subtracting <paramref name="right"/> from <paramref name="left"/>.
        /// </returns>
        public static Mat operator -(Scalar left, Mat right)
        {
            var result = new Mat(right.Rows, right.Cols, right.Depth, right.Channels);
            CV.SubRS(right, left, result);
            return result;
        }

        /// <summary>
        /// Calculates the per-element difference between a <see cref="Mat"/> and a
        /// <see cref="double"/> value.
        /// </summary>
        /// <param name="left">The matrix minuend.</param>
        /// <param name="right">The scalar subtrahend.</param>
        /// <returns>
        /// The result of subtracting <paramref name="right"/> from <paramref name="left"/>.
        /// </returns>
        public static Mat operator -(Mat left, double right)
        {
            var result = new Mat(left.Rows, left.Cols, left.Depth, left.Channels);
            CV.SubS(left, Scalar.All(right), result);
            return result;
        }

        /// <summary>
        /// Subtracts every element of the specified <see cref="Mat"/> value from a
        /// <see cref="double"/> value.
        /// </summary>
        /// <param name="left">The scalar minuend.</param>
        /// <param name="right">The matrix subtrahend.</param>
        /// <returns>
        /// The result of subtracting <paramref name="right"/> from <paramref name="left"/>.
        /// </returns>
        public static Mat operator -(double left, Mat right)
        {
            var result = new Mat(right.Rows, right.Cols, right.Depth, right.Channels);
            CV.SubRS(right, Scalar.All(left), result);
            return result;
        }

        /// <summary>
        /// Calculates the per-element product of two <see cref="Mat"/> values.
        /// </summary>
        /// <param name="left">The first value to multiply.</param>
        /// <param name="right">The second value to multiply.</param>
        /// <returns>
        /// The result of multiplying <paramref name="left"/> by <paramref name="right"/>.
        /// </returns>
        public static Mat operator *(Mat left, Mat right)
        {
            var result = new Mat(left.Rows, left.Cols, left.Depth, left.Channels);
            CV.Mul(left, right, result);
            return result;
        }

        /// <summary>
        /// Calculates the per-element product of a <see cref="Mat"/> by a
        /// <see cref="double"/> scalar value.
        /// </summary>
        /// <param name="left">The matrix to multiply.</param>
        /// <param name="right">The scalar value to multiply.</param>
        /// <returns>
        /// The result of multiplying <paramref name="left"/> by <paramref name="right"/>.
        /// </returns>
        public static Mat operator *(Mat left, double right)
        {
            var result = new Mat(left.Rows, left.Cols, left.Depth, left.Channels);
            CV.ConvertScale(left, result, right);
            return result;
        }

        /// <summary>
        /// Calculates the per-element product of a <see cref="double"/> scalar value
        /// by a <see cref="Mat"/>.
        /// </summary>
        /// <param name="left">The scalar value to multiply.</param>
        /// <param name="right">The matrix to multiply.</param>
        /// <returns>
        /// The result of multiplying <paramref name="left"/> by <paramref name="right"/>.
        /// </returns>
        public static Mat operator *(double left, Mat right)
        {
            var result = new Mat(right.Rows, right.Cols, right.Depth, right.Channels);
            CV.ConvertScale(right, result, left);
            return result;
        }

        /// <summary>
        /// Calculates the per-element division of two <see cref="Mat"/> values.
        /// </summary>
        /// <param name="left">The dividend.</param>
        /// <param name="right">The divisor.</param>
        /// <returns>
        /// The result of dividing <paramref name="left"/> by <paramref name="right"/>.
        /// </returns>
        public static Mat operator /(Mat left, Mat right)
        {
            var result = new Mat(left.Rows, left.Cols, left.Depth, left.Channels);
            CV.Div(left, right, result);
            return result;
        }

        /// <summary>
        /// Calculates the per-element division of a <see cref="Mat"/> by a
        /// <see cref="double"/> scalar value.
        /// </summary>
        /// <param name="left">The matrix dividend.</param>
        /// <param name="right">The scalar divisor.</param>
        /// <returns>
        /// The result of dividing <paramref name="left"/> by <paramref name="right"/>.
        /// </returns>
        public static Mat operator /(Mat left, double right)
        {
            var result = new Mat(left.Rows, left.Cols, left.Depth, left.Channels);
            CV.ConvertScale(left, result, 1.0 / right);
            return result;
        }

        /// <summary>
        /// Calculates the per-element division of a <see cref="double"/> scalar value
        /// by a <see cref="Mat"/>.
        /// </summary>
        /// <param name="left">The scalar dividend.</param>
        /// <param name="right">The matrix divisor.</param>
        /// <returns>
        /// The result of dividing <paramref name="left"/> by <paramref name="right"/>.
        /// </returns>
        public static Mat operator /(double left, Mat right)
        {
            var result = new Mat(right.Rows, right.Cols, right.Depth, right.Channels);
            CV.Div(null, right, result, left);
            return result;
        }

        /// <summary>
        /// Performs per-element bit-wise conjunction of two <see cref="Mat"/> values.
        /// </summary>
        /// <param name="left">The first matrix value.</param>
        /// <param name="right">The second matrix value.</param>
        /// <returns>
        /// The result of performing the bit-wise conjunction of <paramref name="left"/>
        /// and <paramref name="right"/>.
        /// </returns>
        public static Mat operator &(Mat left, Mat right)
        {
            var result = new Mat(left.Rows, left.Cols, left.Depth, left.Channels);
            CV.And(left, right, result);
            return result;
        }

        /// <summary>
        /// Performs per-element bit-wise conjunction of a <see cref="Mat"/> and a
        /// <see cref="Scalar"/>.
        /// </summary>
        /// <param name="left">The matrix value.</param>
        /// <param name="right">The scalar value.</param>
        /// <returns>
        /// The result of performing the bit-wise conjunction of <paramref name="left"/>
        /// and <paramref name="right"/>.
        /// </returns>
        public static Mat operator &(Mat left, Scalar right)
        {
            var result = new Mat(left.Rows, left.Cols, left.Depth, left.Channels);
            CV.AndS(left, right, result);
            return result;
        }

        /// <summary>
        /// Performs per-element bit-wise conjunction of a <see cref="Scalar"/> and a
        /// <see cref="Mat"/>.
        /// </summary>
        /// <param name="left">The scalar value.</param>
        /// <param name="right">The matrix value.</param>
        /// <returns>
        /// The result of performing the bit-wise conjunction of <paramref name="left"/>
        /// and <paramref name="right"/>.
        /// </returns>
        public static Mat operator &(Scalar left, Mat right)
        {
            var result = new Mat(right.Rows, right.Cols, right.Depth, right.Channels);
            CV.AndS(right, left, result);
            return result;
        }

        /// <summary>
        /// Performs per-element bit-wise conjunction of a <see cref="Mat"/> and a
        /// <see cref="double"/> value.
        /// </summary>
        /// <param name="left">The matrix value.</param>
        /// <param name="right">The scalar value.</param>
        /// <returns>
        /// The result of performing the bit-wise conjunction of <paramref name="left"/>
        /// and <paramref name="right"/>.
        /// </returns>
        public static Mat operator &(Mat left, double right)
        {
            var result = new Mat(left.Rows, left.Cols, left.Depth, left.Channels);
            CV.AndS(left, Scalar.All(right), result);
            return result;
        }

        /// <summary>
        /// Performs per-element bit-wise conjunction of a <see cref="double"/> value and a
        /// <see cref="Mat"/>.
        /// </summary>
        /// <param name="left">The scalar value.</param>
        /// <param name="right">The matrix value.</param>
        /// <returns>
        /// The result of performing the bit-wise conjunction of <paramref name="left"/>
        /// and <paramref name="right"/>.
        /// </returns>
        public static Mat operator &(double left, Mat right)
        {
            var result = new Mat(right.Rows, right.Cols, right.Depth, right.Channels);
            CV.AndS(right, Scalar.All(left), result);
            return result;
        }

        /// <summary>
        /// Performs per-element bit-wise disjunction of two <see cref="Mat"/> values.
        /// </summary>
        /// <param name="left">The first matrix value.</param>
        /// <param name="right">The second matrix value.</param>
        /// <returns>
        /// The result of performing the bit-wise disjunction of <paramref name="left"/>
        /// and <paramref name="right"/>.
        /// </returns>
        public static Mat operator |(Mat left, Mat right)
        {
            var result = new Mat(left.Rows, left.Cols, left.Depth, left.Channels);
            CV.Or(left, right, result);
            return result;
        }

        /// <summary>
        /// Performs per-element bit-wise disjunction of a <see cref="Mat"/> and a
        /// <see cref="Scalar"/>.
        /// </summary>
        /// <param name="left">The matrix value.</param>
        /// <param name="right">The scalar value.</param>
        /// <returns>
        /// The result of performing the bit-wise disjunction of <paramref name="left"/>
        /// and <paramref name="right"/>.
        /// </returns>
        public static Mat operator |(Mat left, Scalar right)
        {
            var result = new Mat(left.Rows, left.Cols, left.Depth, left.Channels);
            CV.OrS(left, right, result);
            return result;
        }

        /// <summary>
        /// Performs per-element bit-wise disjunction of a <see cref="Scalar"/> and a
        /// <see cref="Mat"/>.
        /// </summary>
        /// <param name="left">The scalar value.</param>
        /// <param name="right">The matrix value.</param>
        /// <returns>
        /// The result of performing the bit-wise disjunction of <paramref name="left"/>
        /// and <paramref name="right"/>.
        /// </returns>
        public static Mat operator |(Scalar left, Mat right)
        {
            var result = new Mat(right.Rows, right.Cols, right.Depth, right.Channels);
            CV.OrS(right, left, result);
            return result;
        }

        /// <summary>
        /// Performs per-element bit-wise disjunction of a <see cref="Mat"/> and a
        /// <see cref="double"/> value.
        /// </summary>
        /// <param name="left">The matrix value.</param>
        /// <param name="right">The scalar value.</param>
        /// <returns>
        /// The result of performing the bit-wise disjunction of <paramref name="left"/>
        /// and <paramref name="right"/>.
        /// </returns>
        public static Mat operator |(Mat left, double right)
        {
            var result = new Mat(left.Rows, left.Cols, left.Depth, left.Channels);
            CV.OrS(left, Scalar.All(right), result);
            return result;
        }

        /// <summary>
        /// Performs per-element bit-wise disjunction of a <see cref="double"/> value and a
        /// <see cref="Mat"/>.
        /// </summary>
        /// <param name="left">The scalar value.</param>
        /// <param name="right">The matrix value.</param>
        /// <returns>
        /// The result of performing the bit-wise disjunction of <paramref name="left"/>
        /// and <paramref name="right"/>.
        /// </returns>
        public static Mat operator |(double left, Mat right)
        {
            var result = new Mat(right.Rows, right.Cols, right.Depth, right.Channels);
            CV.OrS(right, Scalar.All(left), result);
            return result;
        }

        #endregion
    }
}
