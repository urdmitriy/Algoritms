using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HW5_1
{
    public class TreeNode
    {
        public Node root { get; set; }
        public int count { get; set; }
        public void add(int data)
        {
            if (root == null)
            {
                root = new Node(data);
                return;
            }
            root.add(data);
            count++;
        }

        public void printTreeBFS()
        {
            Queue<Node> children = new Queue<Node>();
            children.Enqueue(root);
            Console.Write("BFS: ");
            while (children.Count>0)
            {
                Node node = new Node();
                node = children.Dequeue();
                Console.Write(node.Data + " ");
                if (node.Left != null)
                    children.Enqueue(node.Left);
                if (node.Right != null)
                    children.Enqueue(node.Right);
            }
        }
        public void printTreeDFS()
        {
            Stack<Node> children = new Stack<Node>();

            children.Push(root);
            Console.Write("DFS: ");
            while (children.Count > 0)
            {
                Node newNode = new Node();
                newNode = children.Pop();

                Console.Write(newNode.Data + " ");
                if (newNode.Right != null)
                    children.Push(newNode.Right);
                if (newNode.Left != null)
                    children.Push(newNode.Left);
            }
            Console.WriteLine();
        }
    }
}
