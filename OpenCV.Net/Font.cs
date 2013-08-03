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
    public class Font : SafeHandleZeroOrMinusOneIsInvalid
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Font"/> class with the specified
        /// <paramref name="scale"/> and <paramref name="thickness"/>.
        /// </summary>
        /// <param name="scale">The scale factor for the font.</param>
        /// <param name="thickness">The thickness of the text strokes.</param>
        public Font(double scale, int thickness = 1)
            : this(FontFace.HersheyPlain, scale, scale, 0, thickness, LineFlags.AntiAliased)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Font"/> class with the specified
        /// parameters.
        /// </summary>
        /// <param name="fontFace">The font name identifier.</param>
        /// <param name="hscale">The width scale factor for the font.</param>
        /// <param name="vscale">The height scale factor for the font.</param>
        /// <param name="shear">
        /// Approximate tangent of the character slope relative to the vertical line. A value
        /// of 0 means a non-italic font, 1.0 means around 45 degrees of slope, and so on.
        /// </param>
        /// <param name="thickness">The thickness of the text strokes.</param>
        /// <param name="lineType">The algorithm used to draw the text strokes.</param>
        public Font(FontFace fontFace, double hscale, double vscale, double shear = 0, int thickness = 1, LineFlags lineType = LineFlags.Connected8)
            : base(true)
        {
            var pFont = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(_CvFont)));
            NativeMethods.cvInitFont(pFont, fontFace, hscale, vscale, shear, thickness, lineType);
            SetHandle(pFont);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Font"/> class using Qt based glyphs.
        /// </summary>
        /// <param name="nameFont">
        /// Name of the font. The name should match the name of a system font (such as Times).
        /// If the font is not found, a default one is used.
        /// </param>
        /// <param name="pointSize">
        /// Size of the font. If not specified, equal zero or negative, the point size of the
        /// font is set to a system-dependent default value. Generally, this is 12 points.
        /// </param>
        public Font(string nameFont, int pointSize = -1)
            : this(nameFont, pointSize, Scalar.All(0))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Font"/> class using Qt based glyphs.
        /// </summary>
        /// <param name="nameFont">
        /// Name of the font. The name should match the name of a system font (such as Times).
        /// If the font is not found, a default one is used.
        /// </param>
        /// <param name="pointSize">
        /// Size of the font. If not specified, equal zero or negative, the point size of the
        /// font is set to a system-dependent default value. Generally, this is 12 points.
        /// </param>
        /// <param name="color">Color of the font.</param>
        /// <param name="weight">Font weight.</param>
        /// <param name="style">Font style.</param>
        /// <param name="spacing">Spacing between characters. It can be negative or positive.</param>
        public Font(string nameFont, int pointSize, Scalar color, FontWeight weight = FontWeight.Normal, FontStyle style = FontStyle.Normal, int spacing = 0)
            : base(true)
        {
            var font = NativeMethods.cvFontQt(nameFont, pointSize, color, weight, style, spacing);
            var pFont = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(_CvFont)));
            Marshal.StructureToPtr(font, pFont, false);
            SetHandle(pFont);
        }

        /// <summary>
        /// Executes the code required to free the native <see cref="Font"/> handle.
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
