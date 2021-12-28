using OpenCV.Net.Native;
using System;
using System.Runtime.InteropServices;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a list of attributes.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AttrList
    {
        IntPtr attr;
        IntPtr next;

        /// <summary>
        /// Gets the attribute value with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the attribute.</param>
        /// <returns>The value associated with the specified <paramref name="name"/>.</returns>
        public string this[string name]
        {
            get { return NativeMethods.cvAttrValue(ref this, name); }
        }

        /// <summary>
        /// Gets the next chunk of attributes in the list.
        /// </summary>
        public AttrList? Next
        {
            get
            {
                unsafe
                {
                    return next != IntPtr.Zero ? *((AttrList*)next.ToPointer()) : (AttrList?)null;
                }
            }
        }
    }
}
