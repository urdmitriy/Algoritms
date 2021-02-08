using System;
using System.Collections.Generic;
using System.Text;

namespace HW6_1
{
    class GraphVertex
    {
        public int Data { get; set; }
        public List<GraphEdge> Edges { get; }
        public GraphVertex(int vertexData)
        {
            Data = vertexData;
            Edges = new List<GraphEdge>();
        }
        public GraphVertex()
        {

        }
        public void AddEdge(GraphEdge newEdge)
        {
            Edges.Add(newEdge);
        }
        public void AddEdge(GraphVertex vertex, int edgeWeight)
        {
            AddEdge(new GraphEdge(vertex, edgeWeight));
        }

    }
}
