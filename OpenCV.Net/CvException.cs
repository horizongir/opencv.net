using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;

namespace OpenCV.Net
{
    [Serializable]
    public class CvException : Exception
    {
        public CvException()
        {
        }

        public CvException(string message)
            : base(message)
        {
        }

        public CvException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public CvException(int status, string functionName, string errorMessage, string fileName, int line)
            : base(GetErrorMessage(status, functionName, errorMessage, fileName, line))
        {
            Status = status;
            FunctionName = functionName;
            ErrorMessage = errorMessage;
            FileName = fileName;
            Line = line;
        }

        protected CvException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public int Status { get; private set; }

        public string FunctionName { get; private set; }

        public string ErrorMessage { get; private set; }

        public string FileName { get; private set; }

        public int Line { get; private set; }

        private static string GetErrorMessage(int status, string functionName, string errorMessage, string fileName, int line)
        {
            var errorText = Core.cvErrorStr(status);
            if (string.IsNullOrEmpty(errorText))
            {
                return "Unknown error.";
            }
            else
            {
                if (!string.IsNullOrEmpty(functionName)) errorText += string.Format("in function {0}", functionName);
                if (!string.IsNullOrEmpty(fileName)) errorText += string.Format(", {0}({1})", Path.GetFileName(fileName), line);
                return errorText;
            }
        }
    }
}
