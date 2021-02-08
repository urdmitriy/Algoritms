using System;

namespace HW6_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Graf myGraf = new Graf();
            myGraf.AddVertex(15);
            myGraf.AddVertex(25);
            myGraf.AddVertex(35);
            myGraf.AddVertex(45);
            myGraf.AddVertex(55);

            myGraf.AddEdge(15, 25, 10);
            myGraf.AddEdge(15, 35, 8);

            myGraf.AddEdge(45, 25, 7);
            myGraf.AddEdge(55, 35, 6);
            myGraf.AddEdge(45, 55, 5);

            myGraf.printGrafBFS();
            myGraf.printGrafDFS();

            Console.ReadLine();
        }
    }
}
