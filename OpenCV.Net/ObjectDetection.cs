using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a structure that contains the bounding box and confidence level for a detected object.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ObjectDetection
    {
        /// <summary>
        /// The bounding box for the detected object.
        /// </summary>
        public Rect Rect;

        /// <summary>
        /// The detection confidence level.
        /// </summary>
        public float Score;
    }
}
