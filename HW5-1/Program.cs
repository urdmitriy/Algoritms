using System;
using System.Collections.Generic;

namespace HW5_1
{
    /*
     * Реализуйте DFS и BFS для дерева с выводом каждого шага в консоль. 
     */
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode myTree = new TreeNode();

            myTree.add(55);
            myTree.add(19);
            myTree.add(36);
            myTree.add(48);
            myTree.add(51);
            myTree.add(15);
            myTree.add(98);
            myTree.add(42);
            myTree.add(16);
            myTree.add(44);
            myTree.add(30);
            myTree.add(9);

            myTree.printTreeBFS();
            Console.WriteLine();

            myTree.printTreeDFS();
            Console.WriteLine();
        }
    }
}
