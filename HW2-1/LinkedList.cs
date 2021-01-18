using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_1
{
    public interface ILinkedList
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(int value);  // добавляет новый элемент списка
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(int searchValue); // ищет элемент по его значению
    }

    public class LinkedList : ILinkedList
    {
        public Node startNode;
        public Node endNode;
        int count;

        public void AddNode(int value)
        {
            Node newNode = new Node { Value = value };
            if (startNode == null)
            {
                startNode = newNode;
            }
            else
            {
                endNode.NextNode = newNode;
                newNode.PrevNode = endNode;
            }
            endNode = newNode;
            count++;
        }

        public void AddNodeAfter(Node node, int value)
        {

            Node newNode = new Node { Value = value };
            Node nextItem = node.NextNode;
            node.NextNode = newNode;
            newNode.NextNode = nextItem;
            nextItem.PrevNode = newNode;
            newNode.PrevNode = node;
            count++;
        }

        public Node FindNode(int searchValue)
        {
            Node searchNode = startNode;
            while (searchNode != null)
            {
                if (searchNode.Value == searchValue)
                {
                    return searchNode;
                }
                searchNode = searchNode.NextNode;
            }
            return null;
        }

        public int GetCount()
        {
            return count;
        }

        public void RemoveNode(int index)
        {
            Node current = startNode;

            for (int i=0; i < index; i++)
            {
                current = current.NextNode;
            }

            RemoveNode(current);
        }

        public void RemoveNode(Node node)
        {
            Node current = startNode;
            while (current != null)
            {
                if (current == node)
                {
                    Node prevNode = current.PrevNode;
                    Node nextNode = current.NextNode;

                    prevNode.NextNode = nextNode;
                    nextNode.PrevNode = prevNode;
                }

                current = current.NextNode;
            }
            count--;
        }
    }
}
