using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using OpenCV.Net.Native;

namespace OpenCV.Net
{
    public class CvFont : SafeHandleZeroOrMinusOneIsInvalid
    {
        public CvFont(double scale)
            : this(FontFace.HersheyPlain, scale, scale, 0, 1, 16)
        {
        }

        public CvFont(double scale, int thickness)
            : this(FontFace.HersheyPlain, scale, scale, 0, thickness, 16)
        {
        }

        public CvFont(FontFace fontFace, double hscale, double vscale)
            : this(fontFace, hscale, vscale, 0, 1, 8)
        {
        }

        public CvFont(FontFace fontFace, double hscale, double vscale, double shear, int thickness, int lineType)
            : base(true)
        {
            var pFont = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(_CvFont)));
            core.cvInitFont(pFont, fontFace, hscale, vscale, shear, thickness, lineType);
            SetHandle(pFont);
        }

        protected override bool ReleaseHandle()
        {
            Marshal.FreeHGlobal(handle);
            return true;
        }
    }
}
