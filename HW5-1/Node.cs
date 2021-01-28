using System;
using System.Collections.Generic;
using System.Text;

namespace HW5_1
{
    public class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Data { get; set; }
        public Node(int data)
        {
            Data = data;
        }
        public Node()
        {
        }
        public void add(int data)
        {
            Node newNode = new Node(data);

            if(newNode.Data<Data)
            {
                if (Left == null)
                {
                    Left = newNode;
                }
                else
                {
                    Left.add(data);
                }
            }
            else
            {
                if (Right==null)
                {
                    Right = newNode;
                }
                else
                {
                    Right.add(data);
                }
            }
        }
    }
}
