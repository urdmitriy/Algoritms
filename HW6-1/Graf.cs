using System;
using System.Collections.Generic;
using System.Text;

namespace HW6_1
{
    class Graf
    {
        public List<GraphVertex> Vertices { get; }
        public Graf()
        {
            Vertices = new List<GraphVertex>();
        }
        public void AddVertex(int vertexData)
        {
            Vertices.Add(new GraphVertex(vertexData));
        }
        public GraphVertex FindVertex(int vertexData)
        {
            foreach (var v in Vertices)
            {
                if (v.Data==vertexData)
                {
                    return v;
                }
            }

            return null;
        }
        public void AddEdge(int firstData, int secondData, int weight)
        {
            var v1 = FindVertex(firstData);
            var v2 = FindVertex(secondData);
            if (v2 != null && v1 != null)
            {
                v1.AddEdge(v2, weight);
                v2.AddEdge(v1, weight);
            }
        }

        public void printGrafBFS()
        {
            List<GraphVertex> GrayVertex = new List<GraphVertex>();

            Queue<GraphVertex> ChildrenVertexes = new Queue<GraphVertex>();
            ChildrenVertexes.Enqueue(Vertices[0]);
            GrayVertex.Add(Vertices[0]);
            Console.Write("BFS: ");
            while (ChildrenVertexes.Count > 0)
            {
                GraphVertex vertex = new GraphVertex();
                vertex = ChildrenVertexes.Dequeue();
                
                Console.Write(vertex.Data + " ");
                

                if (vertex.Edges.Count > 0)
                {
                    foreach (var item in vertex.Edges)
                    {
                        bool result = false;
                        foreach (var gray in GrayVertex)
                        {
                            if (gray == item.ConnectedVertex)
                                result = true;       
                        }
                        if (!result)
                        {
                            ChildrenVertexes.Enqueue(item.ConnectedVertex);
                            GrayVertex.Add(item.ConnectedVertex);
                        }
                            
                    }
                }
            }
            Console.WriteLine();
        }
        public void printGrafDFS()
        {
            List<GraphVertex> GrayVertex = new List<GraphVertex>();

            Stack<GraphVertex> ChildrenVertexes = new Stack<GraphVertex>();

            ChildrenVertexes.Push(Vertices[0]);
            GrayVertex.Add(Vertices[0]);
            Console.Write("DFS: ");
            while (ChildrenVertexes.Count > 0)
            {
                GraphVertex vertex = new GraphVertex();
                vertex = ChildrenVertexes.Pop();

                foreach (var item in vertex.Edges)
                {
                    bool result = false;
                    foreach (var gray in GrayVertex)
                    {
                        if (gray == item.ConnectedVertex)
                            result = true;
                    }
                    if (!result)
                    {
                        ChildrenVertexes.Push(item.ConnectedVertex);
                        GrayVertex.Add(item.ConnectedVertex);
                    }
                }
                Console.Write(vertex.Data + " ");
            }
            Console.WriteLine();
        }
    }
}
