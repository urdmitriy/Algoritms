using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool result = SimpleNum();
            if (result)
                Console.WriteLine("Это число простое");
            else
                Console.WriteLine("Это число не простое");

            Console.ReadLine();
        }

        static bool SimpleNum()
        {
            Console.WriteLine("Введите число");
            int number;
            bool result=false;
            int.TryParse(Console.ReadLine(), out number);

            int d = 0;
            int i = 2;

            while (i<number)
            {
                if (number % i == 0)
                {
                    d++;
                }

                i++;
            }

            if (d == 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }
    }
}
