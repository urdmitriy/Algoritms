using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_1
{


    public class Program
    {
        static void Main(string[] args)
        {
            LinkedList myList = new LinkedList();
            myList.AddNode(1);
            myList.AddNode(2);
            //пропуск 3
            myList.AddNode(4);
            myList.AddNode(5);
            myList.AddNode(6);
            myList.AddNode(7);
            myList.AddNode(8);
            myList.AddNode(9);
            myList.AddNode(10);
            PrintList(myList); 

            myList.AddNodeAfter(myList.FindNode(2), 3); //добавляем 3 после 2
            PrintList(myList);

            myList.RemoveNode(3); //удаляем 4 объект п.п.
            PrintList(myList);

            Console.ReadLine();
        }

        static void PrintList(LinkedList list)
        {
            Node node = list.startNode;
            while (node != null)
            {
                Console.Write(node.Value + " ");
                node = node.NextNode;
            }
            Console.WriteLine($"- Всего в списке {list.GetCount()} элементов");
        }
    }
}
