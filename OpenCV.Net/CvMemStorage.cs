﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using OpenCV.Net.Native;

namespace OpenCV.Net
{
    public class CvMemStorage : SafeHandleZeroOrMinusOneIsInvalid
    {
        public static readonly CvMemStorage Null = new CvMemStorageNull();

        internal CvMemStorage(IntPtr handle)
            : base(true)
        {
            SetHandle(handle);
        }

        public CvMemStorage()
            : this(0)
        {
        }

        public CvMemStorage(int blockSize)
            : base(true)
        {
            var pMemStorage = core.cvCreateMemStorage(blockSize);
            SetHandle(pMemStorage);
        }

        public void Clear()
        {
            core.cvClearMemStorage(this);
        }

        protected override bool ReleaseHandle()
        {
            var pHandle = GCHandle.Alloc(handle, GCHandleType.Pinned);
            try
            {
                core.cvReleaseMemStorage(pHandle.AddrOfPinnedObject());
                return true;
            }
            finally { pHandle.Free(); }
        }

        class CvMemStorageNull : CvMemStorage
        {
            public CvMemStorageNull() : base(IntPtr.Zero) { }

            protected override bool ReleaseHandle()
            {
                return false;
            }
        }
    }
}
