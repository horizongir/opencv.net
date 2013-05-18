using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using OpenCV.Net.Native;

namespace OpenCV.Net
{
    public class CvChain : CvSeq
    {
        public CvPoint Origin
        {
            get
            {
                unsafe
                {
                    return ((_CvChain*)handle.ToPointer())->origin;
                }
            }
        }

        public static int HeaderSize
        {
            get { return Marshal.SizeOf(typeof(_CvChain)); }
        }

        public static CvChain FromCvSeq(CvSeq seq)
        {
            if (seq == null) return null;

            var chain = new CvChain();
            chain.SetOwnerStorage(seq.Storage);
            chain.SetHandle(seq.DangerousGetHandle());
            return chain;
        }
    }
}
