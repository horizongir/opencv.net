using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Specifies the available pixel bit depth formats for <see cref="IplImage"/> instances.
    /// </summary>
    public enum IplDepth : int
    {
        /// <summary>
        /// Specifies an unsigned 8-bit pixel depth.
        /// </summary>
        U8 = 8,

        /// <summary>
        /// Specifies an unsigned 16-bit pixel depth.
        /// </summary>
        U16 = 16,

        /// <summary>
        /// Specifies a floating point 32-bit pixel depth.
        /// </summary>
        F32 = 32,

        /// <summary>
        /// Specifies a floating point 64-bit pixel depth.
        /// </summary>
        F64 = 64,

        /// <summary>
        /// Specifies a signed 8-bit pixel depth.
        /// </summary>
        S8 = unchecked((int)(0x80000000 | 8)),

        /// <summary>
        /// Specifies a signed 16-bit pixel depth.
        /// </summary>
        S16 = unchecked((int)(0x80000000 | 16)),

        /// <summary>
        /// Specifies a signed 32-bit pixel depth.
        /// </summary>
        S32 = unchecked((int)(0x80000000 | 32))
    }

    public enum IplOrigin : int
    {
        TopLeft = 0,
        BottomLeft = 1
    }

    /// <summary>
    /// Specifies the available element bit depth formats for <see cref="CvMat"/> instances.
    /// </summary>
    public enum CvMatDepth : int
    {
        /// <summary>
        /// Specifies an unsigned 8-bit element depth.
        /// </summary>
        U8 = 0,

        /// <summary>
        /// Specifies a signed 8-bit element depth.
        /// </summary>
        S8 = 1,

        /// <summary>
        /// Specifies an unsigned 16-bit element depth.
        /// </summary>
        U16 = 2,

        /// <summary>
        /// Specifies a signed 16-bit element depth.
        /// </summary>
        S16 = 3,

        /// <summary>
        /// Specifies a signed 32-bit element depth.
        /// </summary>
        S32 = 4,

        /// <summary>
        /// Specifies a floating point 32-bit element depth.
        /// </summary>
        F32 = 5,

        /// <summary>
        /// Specifies a floating point 64-bit element depth.
        /// </summary>
        F64 = 6
    }
}
