using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a connected component.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ConnectedComp
    {
        /// <summary>
        /// The area of the segmented component.
        /// </summary>
        public double Area;

        /// <summary>
        /// The average color of the connected component.
        /// </summary>
        public Scalar Value;

        /// <summary>
        /// The ROI of the segmented component.
        /// </summary>
        public Rect Rect;

        /// <summary>
        /// The optional component boundary.
        /// </summary>
        public IntPtr Contour;
    }
}
