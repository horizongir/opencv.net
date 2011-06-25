using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCV.Net.Native;
using System.Runtime.InteropServices;

namespace OpenCV.Net
{
    public sealed class Trackbar : IDisposable
    {
        IntPtr pPos;
        readonly string name;
        readonly CvTrackbarCallback callback;
        public event CvTrackbarCallback Changed;

        internal Trackbar(string name, NamedWindow window, int value, int count)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            this.name = name;
            callback = OnChanged;
            pPos = Marshal.AllocHGlobal(sizeof(int));
            unsafe { *((int*)pPos.ToPointer()) = value; }
            highgui.cvCreateTrackbar(name, window.Name, pPos, count, callback);
        }

        public string Name
        {
            get { return this.name; }
        }

        public int Position
        {
            get { unsafe { return *((int*)pPos.ToPointer()); } }
            set { unsafe { *((int*)pPos.ToPointer()) = value; } }
        }

        private void OnChanged(int pos)
        {
            var handler = Changed;
            if (handler != null)
            {
                handler(pos);
            }
        }

        ~Trackbar()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (pPos != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(pPos);
                pPos = IntPtr.Zero;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
