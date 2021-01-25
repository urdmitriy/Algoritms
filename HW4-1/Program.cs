using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace HW4_1
{
    public class Program
    {
        /*
         *Заполните массив и HashSet случайными строками, не менее 10 000 строк. Строки можно сгенерировать. 
         *Потом выполните замер производительности проверки наличия строки в массиве и HashSet. 
         *Выложите код и результат замеров.  
         */

        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

            BenchmarkClass myBench = new BenchmarkClass();
            Console.WriteLine($"Поиск значения АБВГДЕЁЖЗИ в массиве: {myBench.SearchArray()}");
            Console.Write($"Поиск значения АБВГДЕЁЖЗИ в хэш: ");
            Console.WriteLine(myBench.SearchHash());
        }
  
    }

    public class BenchmarkClass
    {
        public static HashSet<string> hashset = new HashSet<string>();
        public static string[] array = new string[10000];
        public string SearchValue = "АБВГДЕЁЖЗИ";

        public BenchmarkClass()
        {
            for (int i = 0; i < 10000 - 1; i++)
            {
                hashset.Add(RndString(10));
                array[i] = RndString(10);
            }

            hashset.Add("АБВГДЕЁЖЗИ"); //для проверки поиска
            array[9999] = "АБВГДЕЁЖЗИ"; //для проверки поиска
        }

        [Benchmark]
        public bool SearchArray()
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == SearchValue)
                {
                    return true;
                }
            }
            return false;
        }

        [Benchmark]
        public bool SearchHash()
        {
            return hashset.Contains(SearchValue);
        }

        
        static string RndString(int countSymbol)
        {
            char[] letters = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЫЪЭЮЯ".ToCharArray();
            char[] arraySymbol = new char[countSymbol];
            Random rndSimbol = new Random();

            for (int i = 0; i < countSymbol; i++)
                arraySymbol[i] = letters[rndSimbol.Next(letters.Length)];

            return new string(arraySymbol);
        }
    }
}
