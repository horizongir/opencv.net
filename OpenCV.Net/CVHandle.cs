using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a native handle to OpenCV structures and classes.
    /// </summary>
    public abstract class CVHandle : SafeHandle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CVHandle"/> class, specifying
        /// whether the handle is to be reliably released.
        /// </summary>
        /// <param name="ownsHandle">
        /// <b>true</b> to reliably release the handle during the finalization phase;
        /// <b>false</b> to prevent reliable release (not recommended).
        /// </param>
        protected CVHandle(bool ownsHandle)
            : base(IntPtr.Zero, ownsHandle)
        {
        }

        /// <summary>
        /// Gets a value indicating whether the handle is invalid.
        /// </summary>
        public override bool IsInvalid
        {
            get { return handle == IntPtr.Zero; }
        }
    }
}
