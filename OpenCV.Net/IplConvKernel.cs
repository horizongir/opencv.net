using Microsoft.Win32.SafeHandles;
using OpenCV.Net.Native;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a rectangular convolution kernel used for morphological operations.
    /// </summary>
    public class IplConvKernel : SafeHandleZeroOrMinusOneIsInvalid
    {
        internal static readonly IplConvKernel Null = new IplConvKernel();

        internal IplConvKernel()
            : base(true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IplConvKernel"/> class with the specified
        /// size, anchor and shape for the structuring element.
        /// </summary>
        /// <param name="cols">The width of the structuring element.</param>
        /// <param name="rows">The height of the structuring element.</param>
        /// <param name="anchorX">The x-coordinate of the anchor.</param>
        /// <param name="anchorY">The y-coordinate of the anchor.</param>
        /// <param name="shape">The shape of the structuring element.</param>
        public IplConvKernel(int cols, int rows, int anchorX, int anchorY, StructuringElementShape shape)
            : this(cols, rows, anchorX, anchorY, shape, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IplConvKernel"/> class with the specified
        /// size, anchor, shape and optionally custom kernel values for the structuring element.
        /// </summary>
        /// <param name="cols">The width of the structuring element.</param>
        /// <param name="rows">The height of the structuring element.</param>
        /// <param name="anchorX">The x-coordinate of the anchor.</param>
        /// <param name="anchorY">The y-coordinate of the anchor.</param>
        /// <param name="shape">The shape of the structuring element.</param>
        /// <param name="values">
        /// The kernel values that specify the custom shape of the structuring element, when
        /// <paramref name="shape"/> is equal to <see cref="StructuringElementShape.Custom"/>.
        /// </param>
        public IplConvKernel(int cols, int rows, int anchorX, int anchorY, StructuringElementShape shape, int[] values)
            : base(true)
        {
            var pKernel = NativeMethods.cvCreateStructuringElementEx(cols, rows, anchorX, anchorY, shape, values);
            SetHandle(pKernel);
        }

        /// <summary>
        /// Executes the code required to free the native <see cref="IplConvKernel"/> handle.
        /// </summary>
        /// <returns>
        /// <b>true</b> if the handle is released successfully; otherwise, in the event of a
        /// catastrophic failure, <b>false</b>.
        /// </returns>
        protected override bool ReleaseHandle()
        {
            NativeMethods.cvReleaseStructuringElement(ref handle);
            return true;
        }

        /// <summary>
        /// Gets the size of the convolution kernel.
        /// </summary>
        public Size Size
        {
            get
            {
                unsafe
                {
                    return new Size(((_IplConvKernel*)handle.ToPointer())->nCols,
                                      ((_IplConvKernel*)handle.ToPointer())->nRows);
                }
            }
        }

        /// <summary>
        /// Gets the anchor position within the element. The default value (-1, -1) means that
        /// the anchor is at the center. Note that only the shape of a cross-shaped element depends
        /// on the anchor position. In other cases the anchor just regulates how much the result
        /// of the morphological operation is shifted.
        /// </summary>
        public Point Anchor
        {
            get
            {
                unsafe
                {
                    return new Point(((_IplConvKernel*)handle.ToPointer())->anchorX,
                                       ((_IplConvKernel*)handle.ToPointer())->anchorY);
                }
            }
        }
    }
}
