using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#if !NETSTANDARD1_1
using System.Runtime.Serialization;
#endif
using System.IO;
using System.Runtime.InteropServices;
using OpenCV.Net.Native;

namespace OpenCV.Net
{
    /// <summary>
    /// The exception that is thrown when OpenCV error status is set.
    /// </summary>
#if !NETSTANDARD1_1
    [Serializable]
#endif
    public class CVException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CVException"/> class.
        /// </summary>
        public CVException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CVException"/> class with a
        /// specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public CVException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CVException"/> class with a
        /// specified error message and a reference to the inner exception that is the
        /// cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">
        /// The exception that is the cause of the current exception. If the <paramref name="inner"/>
        /// parameter is not <b>null</b>, the current exception is raised in a <b>catch</b> block
        /// that handles the inner exception.
        /// </param>
        public CVException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CVException"/> class from OpenCV
        /// error information.
        /// </summary>
        /// <param name="status">The error code, usually a negative value.</param>
        /// <param name="functionName">The name of the function where the error status was set.</param>
        /// <param name="errorMessage">The text of the error message.</param>
        /// <param name="fileName">The path to the file where the error status was set.</param>
        /// <param name="line">The line number inside <paramref name="fileName"/> where the error status was set.</param>
        public CVException(int status, string functionName, string errorMessage, string fileName, int line)
            : base(GetErrorMessage(status, functionName, errorMessage, fileName, line))
        {
            Status = status;
            FunctionName = functionName;
            ErrorMessage = errorMessage;
            FileName = fileName;
            Line = line;
        }

#if !NETSTANDARD1_1
        /// <summary>
        /// Initializes a new instance of the <see cref="CVException"/> class from
        /// serialization data.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected CVException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif

        /// <summary>
        /// Gets or sets the error code, usually a negative value.
        /// </summary>
        public int Status { get; private set; }

        /// <summary>
        /// Gets or sets the name of the function where the error status was set.
        /// </summary>
        public string FunctionName { get; private set; }

        /// <summary>
        /// Gets or sets the text of the error message.
        /// </summary>
        public string ErrorMessage { get; private set; }

        /// <summary>
        /// Gets or sets the path to the file where the error status was set.
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        /// Gets or sets the line number inside <see cref="FileName"/> where the error status was set.
        /// </summary>
        public int Line { get; private set; }

        private static string GetErrorMessage(int status, string functionName, string errorMessage, string fileName, int line)
        {
            var errorStr = NativeMethods.cvErrorStr(status);
            if (errorStr == IntPtr.Zero)
            {
                return "Unknown error.";
            }
            else
            {
                var errorText = Marshal.PtrToStringAnsi(errorStr);
                if (!string.IsNullOrEmpty(errorMessage)) errorText += string.Format(": {0}", errorMessage);
                if (!string.IsNullOrEmpty(functionName)) errorText += string.Format("in function {0}", functionName);
                if (!string.IsNullOrEmpty(fileName)) errorText += string.Format(", {0}({1})", Path.GetFileName(fileName), line);
                return errorText;
            }
        }
    }
}
