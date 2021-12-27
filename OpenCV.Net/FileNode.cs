using OpenCV.Net.Native;
using System;
using System.Runtime.InteropServices;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a file storage node. When XML/YAML file is read, it is first parsed and stored in the
    /// memory as a hierarchical collection of nodes. Each node can be a “leaf”, that is, contain a
    /// single number or a string, or be a collection of other nodes.
    /// </summary>
    public class FileNode : CVHandle
    {
        internal static readonly FileNode Null = new FileNode();
        const int NodeTypeMask = 7;

        internal FileNode()
            : base(false)
        {
        }

        /// <summary>
        /// Gets the name of the node.
        /// </summary>
        public string Name
        {
            get { return Marshal.PtrToStringAnsi(NativeMethods.cvGetFileNodeName(this)); }
        }

        static FileNodeType NodeType(int flags)
        {
            return (FileNodeType)(flags & NodeTypeMask);
        }

        internal int ReadInt()
        {
            unsafe
            {
                var node = (_CvFileNode*)handle;
                return NodeType(node->tag) == FileNodeType.Integer ? *((int*)&node->str)
                    : NodeType(node->tag) == FileNodeType.Real ? (int)Math.Round(*((double*)&node->str))
                    : 0x7fffffff;
            }
        }

        internal double ReadReal()
        {
            unsafe
            {
                var node = (_CvFileNode*)handle;
                return NodeType(node->tag) == FileNodeType.Integer ? *((int*)&node->str)
                    : NodeType(node->tag) == FileNodeType.Real ? *((double*)&node->str)
                    : 1e300;
            }
        }

        internal string ReadString()
        {
            unsafe
            {
                var node = (_CvFileNode*)handle;
                return NodeType(node->tag) == FileNodeType.String
                    ? Marshal.PtrToStringAnsi(node->str.ptr, node->str.len)
                    : null;
            }
        }

        /// <summary>
        /// Executes the code required to free the native <see cref="FileNode"/> handle.
        /// </summary>
        /// <returns>
        /// <b>true</b> if the handle is released successfully; otherwise, in the event of a
        /// catastrophic failure, <b>false</b>.
        /// </returns>
        protected override bool ReleaseHandle()
        {
            return false;
        }
    }
}
