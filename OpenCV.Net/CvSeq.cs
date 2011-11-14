using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32.SafeHandles;
using OpenCV.Net.Native;
using System.Runtime.InteropServices;

namespace OpenCV.Net
{
    public class CvSeq : SafeHandleZeroOrMinusOneIsInvalid
    {
        public static readonly CvSeq Null = new CvSeqNull();

        public CvSeq()
            : base(true)
        {
        }

        private CvSeq(bool ownsHandle)
            : base(ownsHandle)
        {
        }

        public IntPtr GetElement(int index)
        {
            return core.cvGetSeqElem(this, index);
        }

        public int Total
        {
            get
            {
                unsafe
                {
                    return ((_CvSeq*)handle.ToPointer())->total;
                }
            }
        }

        public CvSeq HPrev
        {
            get
            {
                unsafe
                {
                    var pSeq = ((_CvSeq*)handle.ToPointer())->h_prev;
                    if (pSeq == IntPtr.Zero) return null;

                    var seq = new CvSeq();
                    seq.SetHandle(pSeq);
                    return seq;
                }
            }
        }

        public CvSeq HNext
        {
            get
            {
                unsafe
                {
                    var pSeq = ((_CvSeq*)handle.ToPointer())->h_next;
                    if (pSeq == IntPtr.Zero) return null;

                    var seq = new CvSeq();
                    seq.SetHandle(pSeq);
                    return seq;
                }
            }
        }

        public CvSeq VPrev
        {
            get
            {
                unsafe
                {
                    var pSeq = ((_CvSeq*)handle.ToPointer())->v_prev;
                    if (pSeq == IntPtr.Zero) return null;

                    var seq = new CvSeq();
                    seq.SetHandle(pSeq);
                    return seq;
                }
            }
        }

        public CvSeq VNext
        {
            get
            {
                unsafe
                {
                    var pSeq = ((_CvSeq*)handle.ToPointer())->v_next;
                    if (pSeq == IntPtr.Zero) return null;

                    var seq = new CvSeq();
                    seq.SetHandle(pSeq);
                    return seq;
                }
            }
        }

        protected override bool ReleaseHandle()
        {
            SetHandleAsInvalid();
            return true;
        }

        class CvSeqNull : CvSeq
        {
            public CvSeqNull() : base(false) { }

            protected override bool ReleaseHandle()
            {
                return false;
            }
        }
    }
}
