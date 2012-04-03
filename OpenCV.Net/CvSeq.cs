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
        CvMemStorage owner;

        internal CvSeq()
            : base(true)
        {
        }

        public CvSeq(CvMemStorage storage)
            : base(true)
        {
            owner = storage;
        }

        private CvSeq(bool ownsHandle)
            : base(ownsHandle)
        {
        }

        public CvMemStorage Storage
        {
            get { return owner; }
        }

        internal void SetOwnerStorage(CvMemStorage storage)
        {
            owner = storage;
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

                    var seq = new CvSeq(owner);
                    seq.SetHandle(pSeq);
                    return seq;
                }
            }
            set
            {
                unsafe
                {
                    var pSeq = value != null ? value.handle : IntPtr.Zero;
                    ((_CvSeq*)handle.ToPointer())->h_prev = pSeq;
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

                    var seq = new CvSeq(owner);
                    seq.SetHandle(pSeq);
                    return seq;
                }
            }
            set
            {
                unsafe
                {
                    var pSeq = value != null ? value.handle : IntPtr.Zero;
                    ((_CvSeq*)handle.ToPointer())->h_next = pSeq;
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

                    var seq = new CvSeq(owner);
                    seq.SetHandle(pSeq);
                    return seq;
                }
            }
            set
            {
                unsafe
                {
                    var pSeq = value != null ? value.handle : IntPtr.Zero;
                    ((_CvSeq*)handle.ToPointer())->v_prev = pSeq;
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

                    var seq = new CvSeq(owner);
                    seq.SetHandle(pSeq);
                    return seq;
                }
            }
            set
            {
                unsafe
                {
                    var pSeq = value != null ? value.handle : IntPtr.Zero;
                    ((_CvSeq*)handle.ToPointer())->v_next = pSeq;
                }
            }
        }

        protected override bool ReleaseHandle()
        {
            SetHandleAsInvalid();
            owner = null;
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
