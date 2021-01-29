using System;
using System.Collections;

namespace HW4_2
{
    /*
     *Реализуйте класс двоичного дерева поиска с операциями вставки, удаления, поиска. 
     *Дерево должно быть сбалансированным. 
     *Также напишите метод вывода в консоль дерева, чтобы увидеть, насколько корректно работает ваша реализация.  
    */

    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree MyTree = new BinaryTree();


            MyTree.Insert(55);
            MyTree.Insert(19);
            MyTree.Insert(36);
            MyTree.Insert(48);
            MyTree.Insert(51);
            MyTree.Insert(15);
            MyTree.Insert(98);
            MyTree.Insert(42);
            MyTree.Insert(16);
            MyTree.Insert(44);
            MyTree.Insert(30);
            MyTree.Insert(9);





            MyTree.Print(MyTree);


            Console.WriteLine("============ Удаляем 48 ==========");
            MyTree.Delete(48);
            MyTree.Print(MyTree);

            //Console.WriteLine("============ Вращаем влево 19 ноду ==========");
            //MyTree.rotateRight(19);
            //MyTree.Print(MyTree);
        }
    }
}
