using Microsoft.Win32.SafeHandles;
using OpenCV.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a font that can be passed to text rendering functions.
    /// </summary>
    public class CvFont : SafeHandleZeroOrMinusOneIsInvalid
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CvFont"/> class with the specified
        /// <paramref name="scale"/> and <paramref name="thickness"/>.
        /// </summary>
        /// <param name="scale">The scale factor for the font.</param>
        /// <param name="thickness">The thickness of the text strokes.</param>
        public CvFont(double scale, int thickness = 1)
            : this(FontFace.HersheyPlain, scale, scale, 0, thickness, LineType.AntiAliased)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvFont"/> class with the specified
        /// parameters.
        /// </summary>
        /// <param name="fontFace"></param>
        /// <param name="hscale">The width scale factor for the font.</param>
        /// <param name="vscale">The height scale factor for the font.</param>
        /// <param name="shear">
        /// Approximate tangent of the character slope relative to the vertical line. A value
        /// of 0 means a non-italic font, 1.0 means around 45 degrees of slope, and so on.
        /// </param>
        /// <param name="thickness">The thickness of the text strokes.</param>
        /// <param name="lineType">The algorithm used to draw the text strokes.</param>
        public CvFont(FontFace fontFace, double hscale, double vscale, double shear = 0, int thickness = 1, LineType lineType = LineType.Connected8)
            : base(true)
        {
            var pFont = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(_CvFont)));
            NativeMethods.cvInitFont(pFont, fontFace, hscale, vscale, shear, thickness, lineType);
            SetHandle(pFont);
        }

        /// <summary>
        /// Executes the code required to free the native <see cref="CvFont"/> handle.
        /// </summary>
        /// <returns>
        /// <b>true</b> if the handle is released successfully; otherwise, in the event of a
        /// catastrophic failure, <b>false</b>.
        /// </returns>
        protected override bool ReleaseHandle()
        {
            Marshal.FreeHGlobal(handle);
            return true;
        }
    }
}
