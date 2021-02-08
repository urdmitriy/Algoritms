using System;
using System.Collections.Generic;
using System.Text;

namespace HW6_1
{
    class GraphEdge
    {
        public GraphVertex ConnectedVertex { get; set; }
        public int EdgeWeight { get; }
        public GraphEdge(GraphVertex connectedVertex, int weight)
        {
            ConnectedVertex = connectedVertex;
            EdgeWeight = weight;
        }
    }
}
