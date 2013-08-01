using Microsoft.Win32.SafeHandles;
using OpenCV.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a storage associated with a file on disk.
    /// </summary>
    public class CvFileStorage : SafeHandleZeroOrMinusOneIsInvalid
    {
        CvMemStorage owner;

        /// <summary>
        /// Initializes a new instance of the <see cref="CvFileStorage"/> class and prepares the
        /// file storage for reading or writing data.
        /// </summary>
        /// <param name="fileName">Name of the file associated with the storage.</param>
        /// <param name="storage">
        /// Memory storage used for temporary data and for storing dynamic structures, such as
        /// <see cref="CvSeq"/> or <see cref="CvGraph"/>. If it is <b>null</b>, a temporary memory
        /// storage is created and used.
        /// </param>
        /// <param name="flags">Specifies operation flags associated with the new file storage.</param>
        /// <param name="encoding">
        /// Encoding of the file. Note that UTF-16 XML encoding is not supported currently and you
        /// should use 8-bit encoding instead.
        /// </param>
        public CvFileStorage(string fileName, CvMemStorage storage, StorageFlags flags, string encoding = null)
            : base(true)
        {
            var pStorage = NativeMethods.cvOpenFileStorage(fileName, storage ?? CvMemStorage.Null, flags, encoding);
            SetHandle(pStorage);
            owner = storage;
        }

        /// <summary>
        /// Starts writing a new structure.
        /// </summary>
        /// <param name="name">
        /// Name of the written structure. The structure can be accessed by this name when the storage is read.
        /// </param>
        /// <param name="structFlags">Operation flags associated with the written structure.</param>
        /// <param name="typeName">
        /// Optional parameter, the object type name. In case of XML it is written as a type_id attribute of the
        /// structure opening tag. In the case of YAML it is written after a colon following the structure name.
        /// </param>
        /// <param name="attributes">Not used in the current implementation.</param>
        public void StartWriteStruct(string name, StructStorageFlags structFlags, string typeName = null, CvAttrList attributes = default(CvAttrList))
        {
            NativeMethods.cvStartWriteStruct(this, name, structFlags, typeName, attributes);
        }

        /// <summary>
        /// Ends the writing of a structure.
        /// </summary>
        public void EndWriteStruct()
        {
            NativeMethods.cvEndWriteStruct(this);
        }

        /// <summary>
        /// Writes an integer value.
        /// </summary>
        /// <param name="name">
        /// Name of the written value. Should be <b>null</b> if and only if the parent structure is a sequence.
        /// </param>
        /// <param name="value">The written value.</param>
        public void WriteInt(string name, int value)
        {
            NativeMethods.cvWriteInt(this, name, value);
        }

        /// <summary>
        /// Writes a floating-point value.
        /// </summary>
        /// <param name="name">
        /// Name of the written value. Should be <b>null</b> if and only if the parent structure is a sequence.
        /// </param>
        /// <param name="value">The written value.</param>
        public void WriteReal(string name, double value)
        {
            NativeMethods.cvWriteReal(this, name, value);
        }

        /// <summary>
        /// Writes a text string.
        /// </summary>
        /// <param name="name">
        /// Name of the written string. Should be <b>null</b> if and only if the parent structure is a sequence.
        /// </param>
        /// <param name="value">The written string.</param>
        /// <param name="quote">
        /// If <b>true</b>, the written string is put in quotes, regardless of whether they are required.
        /// Otherwise, if the flag is zero, quotes are used only when they are required (e.g. when the string
        /// starts with a digit or contains spaces).
        /// </param>
        public void WriteString(string name, string value, bool quote = false)
        {
            NativeMethods.cvWriteString(this, name, value, quote ? 1 : 0);
        }

        /// <summary>
        /// Writes a comment.
        /// </summary>
        /// <param name="comment">The written comment, single-line or multi-line.</param>
        /// <param name="eolComment">
        /// If <b>true</b>, the method tries to put the comment at the end of current line; otherwise, if the
        /// comment is multi-line, or if it does not fit at the end of the current line, the comment starts a new line.
        /// </param>
        public void WriteComment(string comment, bool eolComment)
        {
            NativeMethods.cvWriteComment(this, comment, eolComment ? 1 : 0);
        }

        /// <summary>
        /// Writes an object to file storage.
        /// </summary>
        /// <param name="name">
        /// Name of the written object. Should be <b>null</b> if and only if the parent structure is a sequence.
        /// </param>
        /// <param name="handle">Handle to the written object.</param>
        /// <param name="attributes">The attributes of the object. They are specific for each particular type.</param>
        public void Write(string name, CvHandle handle, CvAttrList attributes = default(CvAttrList))
        {
            NativeMethods.cvWrite(this, name, handle, attributes);
        }

        /// <summary>
        /// Writes multiple numbers.
        /// </summary>
        /// <typeparam name="TElement">The type of the numbers to write.</typeparam>
        /// <param name="source">The source array.</param>
        /// <param name="format">Specification of each array element.</param>
        public void WriteRawData<TElement>(TElement[] source, string format) where TElement : struct
        {
            var handle = GCHandle.Alloc(source, GCHandleType.Pinned);
            try
            {
                NativeMethods.cvWriteRawData(this, handle.AddrOfPinnedObject(), source.Length, format);
            }
            finally { handle.Free(); }
        }

        /// <summary>
        /// Starts the next stream in file storage. Both YAML and XML support multiple streams.
        /// This is useful for concatenating files or for resuming the writing process.
        /// </summary>
        public void StartNextStream()
        {
            NativeMethods.cvStartNextStream(this);
        }

        /// <summary>
        /// Executes the code required to free the native <see cref="CvFileStorage"/> handle.
        /// </summary>
        /// <returns>
        /// <b>true</b> if the handle is released successfully; otherwise, in the event of a
        /// catastrophic failure, <b>false</b>.
        /// </returns>
        protected override bool ReleaseHandle()
        {
            NativeMethods.cvReleaseFileStorage(ref handle);
            owner = null;
            return true;
        }
    }
}
