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
    public class FileStorage : CVHandle
    {
        MemStorage owner;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileStorage"/> class and prepares the
        /// file storage for reading or writing data.
        /// </summary>
        /// <param name="fileName">Name of the file associated with the storage.</param>
        /// <param name="storage">
        /// Memory storage used for temporary data and for storing dynamic structures, such as
        /// <see cref="Seq"/> or <see cref="Graph"/>. If it is <b>null</b>, a temporary memory
        /// storage is created and used.
        /// </param>
        /// <param name="flags">Specifies operation flags associated with the new file storage.</param>
        /// <param name="encoding">
        /// Encoding of the file. Note that UTF-16 XML encoding is not supported currently and you
        /// should use 8-bit encoding instead.
        /// </param>
        public FileStorage(string fileName, MemStorage storage, StorageFlags flags, string encoding = null)
            : base(true)
        {
            var pStorage = NativeMethods.cvOpenFileStorage(fileName, storage ?? MemStorage.Null, flags, encoding);
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
        public void StartWriteStruct(string name, StructStorageFlags structFlags, string typeName = null, AttrList attributes = default(AttrList))
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
        public void Write(string name, CVHandle handle, AttrList attributes = default(AttrList))
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
        /// Returns a unique reference for a given name.
        /// </summary>
        /// <param name="name">Literal node name.</param>
        /// <param name="createMissing">
        /// A value indicating whether an absent key should be added into the hash table.
        /// </param>
        /// <returns>
        /// A unique reference for each particular file node name. This reference can later be passed to the
        /// <see cref="GetFileNode(FileNode,StringHashNode,bool)"/> method.
        /// </returns>
        public StringHashNode GetHashedKey(string name, bool createMissing = false)
        {
            var key = NativeMethods.cvGetHashedKey(this, name, name.Length, createMissing ? 1 : 0);
            return key.IsInvalid ? null : key;
        }

        /// <summary>
        /// Retrieves one of the top-level nodes of the file storage.
        /// </summary>
        /// <param name="streamIndex">
        /// Zero-based index of the stream. In most cases, there is only one stream in the file.
        /// </param>
        /// <returns>
        /// One of the top-level file nodes. The top-level nodes do not have a name, they correspond to the
        /// streams that are stored one after another in the file storage. If the index is out of range, the
        /// function returns <b>null</b>.
        /// </returns>
        public FileNode GetRootFileNode(int streamIndex = 0)
        {
            var node = NativeMethods.cvGetRootFileNode(this, streamIndex);
            return node.IsInvalid ? null : node;
        }

        /// <summary>
        /// Finds a node in a map or file storage.
        /// </summary>
        /// <param name="map">The parent map. If it is <b>null</b>, the function searches a top-level node.</param>
        /// <param name="key">Unique pointer to the node name, retrieved with <see cref="GetHashedKey"/>.</param>
        /// <param name="createMissing">A value indicating whether an absent node should be added to the map.</param>
        /// <returns>The found or newly created node; <b>null</b> in case of failure.</returns>
        public FileNode GetFileNode(FileNode map, StringHashNode key, bool createMissing = false)
        {
            var node = NativeMethods.cvGetFileNode(this, map ?? FileNode.Null, key ?? StringHashNode.Null, createMissing ? 1 : 0);
            return node.IsInvalid ? null : node;
        }

        /// <summary>
        /// Finds a node in a map or file storage.
        /// </summary>
        /// <param name="map">The parent map. If it is <b>null</b>, the function searches a top-level node.</param>
        /// <param name="name">The file node name.</param>
        /// <returns>The found node or <b>null</b> in case of failure.</returns>
        public FileNode GetFileNode(FileNode map, string name)
        {
            var node = NativeMethods.cvGetFileNodeByName(this, map, name);
            return node.IsInvalid ? null : node;
        }

        /// <summary>
        /// Retrieves an integer value from a file node.
        /// </summary>
        /// <param name="node">The file node.</param>
        /// <param name="defaultValue">The value that is returned if <paramref name="node"/> is <b>null</b>.</param>
        /// <returns>An integer that is represented by the file node.</returns>
        public int ReadInt(FileNode node, int defaultValue = 0)
        {
            if (node == null) return defaultValue;
            return node.ReadInt();
        }

        /// <summary>
        /// Finds a file node and returns its integer value.
        /// </summary>
        /// <param name="map">The parent map. If it is <b>null</b>, the function searches a top-level node.</param>
        /// <param name="name">The node name.</param>
        /// <param name="defaultValue">The value that is returned if the file node is not found.</param>
        /// <returns>An integer that is represented by the file node.</returns>
        public int ReadInt(FileNode map, string name, int defaultValue = 0)
        {
            return ReadInt(GetFileNode(map, name), defaultValue);
        }

        /// <summary>
        /// Retrieves a floating-point value from a file node.
        /// </summary>
        /// <param name="node">The file node.</param>
        /// <param name="defaultValue">The value that is returned if <paramref name="node"/> is <b>null</b>.</param>
        /// <returns>A floating-point value that is represented by the file node.</returns>
        public double ReadReal(FileNode node, double defaultValue = 0)
        {
            if (node == null) return defaultValue;
            return node.ReadReal();
        }

        /// <summary>
        /// Finds a file node and returns its floating-point value.
        /// </summary>
        /// <param name="map">The parent map. If it is <b>null</b>, the function searches a top-level node.</param>
        /// <param name="name">The node name.</param>
        /// <param name="defaultValue">The value that is returned if the file node is not found.</param>
        /// <returns>A floating-point value that is represented by the file node.</returns>
        public double ReadReal(FileNode map, string name, double defaultValue = 0)
        {
            return ReadReal(GetFileNode(map, name), defaultValue);
        }

        /// <summary>
        /// Retrieves a text string from a file node.
        /// </summary>
        /// <param name="node">The file node.</param>
        /// <param name="defaultValue">The value that is returned if <paramref name="node"/> is <b>null</b>.</param>
        /// <returns>A text string that is represented by the file node.</returns>
        public string ReadString(FileNode node, string defaultValue = null)
        {
            if (node == null) return defaultValue;
            return node.ReadString();
        }

        /// <summary>
        /// Finds a file node and returns its text string value.
        /// </summary>
        /// <param name="map">The parent map. If it is <b>null</b>, the function searches a top-level node.</param>
        /// <param name="name">The node name.</param>
        /// <param name="defaultValue">The value that is returned if the file node is not found.</param>
        /// <returns>A text string that is represented by the file node.</returns>
        public string ReadString(FileNode map, string name, string defaultValue = null)
        {
            return ReadString(GetFileNode(map, name), defaultValue);
        }

        /// <summary>
        /// Decodes an object and returns a reference to it.
        /// </summary>
        /// <typeparam name="TElement">The type of the object.</typeparam>
        /// <param name="node">The root object node.</param>
        /// <returns>The reference to the decoded object.</returns>
        public TElement Read<TElement>(FileNode node) where TElement : CVHandle
        {
            if (node.IsInvalid) return default(TElement);
            var handle = NativeMethods.cvRead(this, node, IntPtr.Zero);
            var result = (TElement)Activator.CreateInstance(
                typeof(TElement),
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null,
                new object[] { handle },
                null);
            return result;
        }

        /// <summary>
        /// Finds an object by name and decodes it.
        /// </summary>
        /// <typeparam name="TElement">The type of the object.</typeparam>
        /// <param name="map">The parent map. If it is <b>null</b>, the function searches a top-level node.</param>
        /// <param name="name">The node name.</param>
        /// <returns>The reference to the decoded object.</returns>
        public TElement Read<TElement>(FileNode map, string name) where TElement : CVHandle
        {
            return Read<TElement>(GetFileNode(map, name));
        }

        /// <summary>
        /// Reads multiple numbers.
        /// </summary>
        /// <typeparam name="TElement">The type of the numbers to read.</typeparam>
        /// <param name="src">The file node (a sequence) to read numbers from.</param>
        /// <param name="dst">The destination array.</param>
        /// <param name="format">Specification of each array element.</param>
        public void ReadRawData<TElement>(FileNode src, TElement[] dst, string format) where TElement : struct
        {
            var handle = GCHandle.Alloc(dst, GCHandleType.Pinned);
            try
            {
                NativeMethods.cvReadRawData(this, src, handle.AddrOfPinnedObject(), format);
            }
            finally { handle.Free(); }
        }

        /// <summary>
        /// Writes a file node from another file storage.
        /// </summary>
        /// <param name="newNodeName">
        /// New name of the file node in the destination file storage. To keep the existing name, use the
        /// <see cref="FileNode.Name"/> property.
        /// </param>
        /// <param name="node">The written node.</param>
        /// <param name="embed">
        /// If the written node is a collection and this parameter is <b>true</b>, no extra level of hierarchy
        /// is created. Instead, all the elements of node are written into the currently written structure.
        /// Of course, map elements can only be embedded into another map, and sequence elements can only be
        /// embedded into another sequence.
        /// </param>
        public void WriteFileNode(string newNodeName, FileNode node, bool embed)
        {
            NativeMethods.cvWriteFileNode(this, newNodeName, node, embed ? 1 : 0);
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
        /// Executes the code required to free the native <see cref="FileStorage"/> handle.
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
