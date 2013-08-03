using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a structure that contains the bounding box and number of neighbors of objects
    /// detected by <see cref="HaarClassifierCascade.DetectObjects"/>.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AvgComp
    {
        /// <summary>
        /// The bounding rectangle for the object (average rectangle of a group).
        /// </summary>
        public Rect Rect;

        /// <summary>
        /// The number of neighbor rectangles in the group.
        /// </summary>
        public int Neighbors;
    }
}
