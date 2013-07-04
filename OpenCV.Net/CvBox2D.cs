using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a possibly rotated rectangle.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CvBox2D
    {
        /// <summary>
        /// The mass center of the rectangle.
        /// </summary>
        public CvPoint2D32f Center;

        /// <summary>
        /// The size of the rectangle.
        /// </summary>
        public CvSize2D32f Size;

        /// <summary>
        /// The rotation angle of the rectangle in degrees.
        /// </summary>
        public float Angle;
    }
}
