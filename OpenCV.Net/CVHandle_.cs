using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a native handle to OpenCV structures and classes.
    /// </summary>
    public abstract class CVHandle : SafeHandleZeroOrMinusOneIsInvalid
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
            : base(ownsHandle)
        {
        }
    }
}
