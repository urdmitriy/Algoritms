using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 3, 5, 7, 9, 11, 13 };
            
            int result = BinSearch(array, 9);

            if (result!=-1) Console.WriteLine($"Искомый элемент под индексом {result}");
            else Console.WriteLine("Элемент не найден");

            Console.ReadLine();
        }

        public static int BinSearch(int[] inputArray, int searchValue)
        {
            int min = 0;                            //O(1)
            int max = inputArray.Length - 1;        //O(1)
            while (min <= max)                      //O(N)
            {
                int mid = (min + max) / 2;              //O(1)

                if (searchValue == inputArray[mid])
                {
                    return mid;                         //O(1)
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;                      //O(1)
                }
                else
                {
                    min = mid + 1;                      //O(1)
                }
            }
            return -1;                              //O(1)
        }
    }                       //O(1+1+N*(1+1)) = O(N)
}
