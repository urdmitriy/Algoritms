using System;
using System.Collections.Generic;
using System.Text;

namespace HW4_2
{
    public class BinaryTree
    {
        public int Data { get; set; }
        public BinaryTree Left { get; set; }
        public BinaryTree Right { get; set; }
        public BinaryTree Parent { get; set; }

        public int height { get; set; }

        
        public BinaryTree()
        {

        }

        public BinaryTree(int value)
        {
            Data = value;
        }

        public int bfactor(BinaryTree node)
        {
            return node.Right.height - node.Left.height;
        }
        
        public void fixHeight(BinaryTree node)
        {
            int hl = node.Left.height;
            int hr = node.Right.height;
            if (hl > hr)
                node.height = hl + 1;
            else
                node.height = hr + 1;
        }
        
        public void rotateRight(int nodeValue)
        {
            BinaryTree node = new BinaryTree();
            node = Find(nodeValue);

            BinaryTree newNode = new BinaryTree();
            newNode.Data = node.Data;
            newNode.Left = node.Right;
            newNode.Right = node.Parent;
            newNode.Parent = null;

            node = newNode;
        }
        public void Insert(int data)
        {
            if (Data == 0 || Data == data)
            {
                Data = data;
                return;
            }

            if (data < Data)
            {
                if (Left == null)
                {
                    Left = new BinaryTree(data);
                    Left.Parent = this;
                }
                else
                    Left.Insert(data);
            }
            if (data > Data)
            {
                if (Right == null)
                {
                    Right = new BinaryTree(data);
                    Right.Parent = this;
                }
                    
                else
                    Right.Insert(data);
            }
        }
        public void Delete(int value)
    {
        BinaryTree DelTree = new BinaryTree();

        DelTree = Find(value);

        //Если у узла нет дочерних элементов
        if (DelTree.Left == null && DelTree.Right == null)
        {
            if (DelTree.Parent.Left.Data == value)
                DelTree.Parent.Left = null;
            if (DelTree.Parent.Right.Data == value)
                DelTree.Parent.Right = null;
            return;
        }

        //Если нет левого дочернего
        if (DelTree.Left == null)
        {
            DelTree.Right.Parent = DelTree.Parent;
            if (DelTree.Parent.Left.Data == value)
                DelTree.Parent.Left = DelTree.Right;
            if (DelTree.Parent.Right.Data == value)
                DelTree.Parent.Right = DelTree.Right;
            return;
        }            
            
        //Если нет правого дочернего
        if (DelTree.Right == null)
        {
            DelTree.Left.Parent = DelTree.Parent;
            if (DelTree.Parent.Left.Data == value)
                DelTree.Parent.Left = DelTree.Left;
            if (DelTree.Parent.Right.Data == value)
                DelTree.Parent.Right = DelTree.Left;
            return;
        }

        //Если присутствуют оба дочерних узла
        //то правый ставим на место удаляемого
        //а левый вставляем в правый

        if (DelTree.Parent.Left.Data == value)
            DelTree.Parent.Left = DelTree.Left;
        if (DelTree.Parent.Right.Data == value)
            DelTree.Parent.Right = DelTree.Left;
        DelTree.Left.Parent = DelTree.Parent;

        BinaryTree LastRightNode = new BinaryTree();
        LastRightNode = DelTree.Left;
        while (LastRightNode.Right != null)
        {
            LastRightNode = LastRightNode.Right;
        }
        DelTree.Right.Parent = LastRightNode;
        LastRightNode.Right = DelTree.Right;
    }

        public BinaryTree Find(int value)
        {
            if (Data == value)
                return this;
            if (Data > value)
                return Find(value, Left);
            return Find(value, Right);
        }

        public BinaryTree Find(int value, BinaryTree node)
        {
            if (node == null)
                return null;
            if (node.Data == value)
                return node;
            if (node.Data > value)
                return Find(value, node.Left);
            return Find(value, node.Right);
        }


        public void Print(BinaryTree node)
        {
            if (node != null)
            {
                if (node.Parent == null)
                {
                    Console.WriteLine("ROOT:{0}", node.Data);
                }
                else
                {
                    if (node.Parent.Left == node)
                    {
                        Console.WriteLine("Left for {1}  --> {0}", node.Data, node.Parent.Data);
                    }

                    if (node.Parent.Right == node)
                    {
                        Console.WriteLine("Right for {1} --> {0}", node.Data, node.Parent.Data);
                    }
                }
                if (node.Left != null)
                {
                    Print(node.Left);
                }
                if (node.Right != null)
                {
                    Print(node.Right);
                }
            }
        }
    }

}
