using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using OpenCV.Net.Native;

namespace OpenCV.Net
{
    public class CvContour : CvSeq
    {
        public CvRect Rect
        {
            get
            {
                unsafe
                {
                    return ((_CvContour*)handle.ToPointer())->rect;
                }
            }
        }

        public static int HeaderSize
        {
            get { return Marshal.SizeOf(typeof(_CvContour)); }
        }

        public static CvContour FromCvSeq(CvSeq seq)
        {
            if (seq == null) return null;

            var contour = new CvContour();
            contour.SetOwnerStorage(seq.Storage);
            contour.SetHandle(seq.DangerousGetHandle());
            return contour;
        }
    }
}
