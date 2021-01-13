using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Для какого числа нужно рассчитать число Фибонначи?");
            float num;
            float.TryParse(Console.ReadLine(), out num);

            Console.WriteLine($"Рекурсивный метод: {FibRecurse(num)}");
            Console.WriteLine($"Метод без рекурсии: {FibFor(num)}");

            Console.ReadLine();
        }

        static float FibRecurse(float num)
        {
            float result;
            if (num == 0)
            {
                return 0;
            }

            if (num == 1)
            {
                return 1;
            }

            result = FibRecurse(num - 2) + FibRecurse(num - 1);
            return result;
        }

        static float FibFor(float num)
        {
            float result=1;
            float prevNum1=0; //(n-2)
            float prevNum2 = 1; //(n-1)

            if (num == 0) return 0;

            for (float i = 1; i < num; i++)
            {
                result = prevNum1 + prevNum2;
                prevNum1 = prevNum2;
                prevNum2 = result;
            }
            return result;
        }
    }
}
