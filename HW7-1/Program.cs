using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7_1
{
    class Program
    {
        static int[,] buffer = new int[20, 20];

        static void Print2(int n,int m, int[,] a)
        {
            int i, j;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                    Console.Write($"{a[i, j]} ");
                Console.Write("\r\n");
            }
            Console.WriteLine();
        }

        static void CountRoute(int str, int row)
        {

            int[,] A = new int[str, row];
            int i, j;

            for (j = 0; j < row; j++)
            {
                A[0, j] = 1;
            }

            for (i = 1; i < str; i++)
            {
                A[i, 0] = 1;
                for (j = 1; j < row; j++)
                {
                    if (buffer[i, j] > 0)
                        A[i, j] = buffer[i, j];
                    else
                    {
                        A[i, j] = A[i, j - 1] + A[i - 1, j];
                        buffer[i, j] = A[i, j];
                    }
                }
            }

            Print2(str, row, A);
        }
        static void Main(string[] args)
        {

            CountRoute(3, 3);
            CountRoute(3, 4);
            CountRoute(4, 4);

            Console.ReadLine();
        }


    }
}
