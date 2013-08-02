using OpenCV.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents an oriented or unoriented weighted graph.
    /// </summary>
    public class CvGraph : CvSet
    {
        internal CvGraph()
        {
        }

        /// <summary>
        /// Gets the size of the <see cref="CvGraph"/> header, in bytes.
        /// </summary>
        public static new int HeaderSize
        {
            get { return SeqHelper.GraphHeaderSize; }
        }

        /// <summary>
        /// Gets the total number of vertices in the graph.
        /// </summary>
        public int VertexCount
        {
            get
            {
                unsafe
                {
                    return ((_CvGraph*)handle.ToPointer())->active_count;
                }
            }
        }

        /// <summary>
        /// Gets the total number of edges in the graph.
        /// </summary>
        public int EdgeCount
        {
            get
            {
                unsafe
                {
                    return ((_CvSet*)((_CvGraph*)handle.ToPointer())->edges)->active_count;
                }
            }
        }

        /// <summary>
        /// Removes a vertex from the graph.
        /// </summary>
        /// <param name="index">The index of the removed vertex.</param>
        /// <returns>The number of edges deleted.</returns>
        public int RemoveVertex(int index)
        {
            return NativeMethods.cvGraphRemoveVtx(this, index);
        }

        /// <summary>
        /// Removes an edge from the graph.
        /// </summary>
        /// <param name="startIndex">The index of the starting vertex of the edge.</param>
        /// <param name="endIndex">The index of the ending vertex of the edge.</param>
        public void RemoveEdge(int startIndex, int endIndex)
        {
            NativeMethods.cvGraphRemoveEdge(this, startIndex, endIndex);
        }

        /// <summary>
        /// Removes all vertices and edges from the graph.
        /// </summary>
        public override void Clear()
        {
            NativeMethods.cvClearGraph(this);
        }

        /// <summary>
        /// Counts the number of edges incident to the vertex.
        /// </summary>
        /// <param name="index">The index of the graph vertex.</param>
        /// <returns>The number of edges incident to the vertex.</returns>
        public int GetVertexDegree(int index)
        {
            return NativeMethods.cvGraphVtxDegree(this, index);
        }

        /// <summary>
        /// Creates a full copy of the graph.
        /// </summary>
        /// <param name="storage">
        /// The destination <see cref="CvMemStorage"/> instance on which to store the new graph.
        /// If <paramref name="storage"/> is <b>null</b>, the same memory storage of this graph is used.
        /// </param>
        /// <returns>A new <see cref="CvGraph"/> instance that is a copy of this graph.</returns>
        public new CvGraph Clone(CvMemStorage storage = null)
        {
            storage = storage ?? Storage;
            var graph = NativeMethods.cvCloneGraph(this, storage);
            graph.SetOwnerStorage(storage);
            return graph;
        }
    }
}
