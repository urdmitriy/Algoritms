using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace HW3_1netCore
{
    class Program
    {
        static void Main(string[] args)
        {

            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

            Console.ReadLine();
        }
    }
    public class BenchmarkClass
    {
        static int quantity = 100000;

        public int[,] dot1 = new int[quantity, 2];
        public int[,] dot2 = new int[quantity, 2];

        float floatRes;
        double doubleRes;

        public BenchmarkClass()
        {
            Random rnd = new Random();
            for (int i = 0; i < dot1.GetLength(0); i++)
            {
                dot1[i, 0] = rnd.Next(5000);
                dot1[i, 1] = rnd.Next(5000);
                dot2[i, 0] = rnd.Next(5000);
                dot2[i, 1] = rnd.Next(5000);
            }
        }

        public float PointDistanceFloatClass(PointClassFloat pointOne, PointClassFloat pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        public float PointDistanceFloatStruct(PointStructFloat pointOne, PointStructFloat pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        public double PointDistanceDoubleStruct(PointStructDouble pointOne, PointStructDouble pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }
        public float PointDistanceFloatStructWOSQRT(PointStructFloat pointOne, PointStructFloat pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return ((x * x) + (y * y));
        }

        [Benchmark(Description = "Ссылочный тип, координаты float")]
        public void TestDistanceClassFloat()
        {

            for (int i = 0; i < dot1.GetLength(0); i++)
                floatRes = PointDistanceFloatClass(new PointClassFloat { X = dot1[i, 0], Y = dot1[i, 1] }, new PointClassFloat { X = dot2[i, 0], Y = dot2[i, 1] });
        }

        [Benchmark(Description = "Значимый тип, координаты float")]
        public void TestDistanceStructFloat()
        {
            for (int i = 0; i < dot1.GetLength(0); i++)
                floatRes = PointDistanceFloatStruct(new PointStructFloat { X = dot1[i, 0], Y = dot1[i, 1] }, new PointStructFloat { X = dot2[i, 0], Y = dot2[i, 1] });
        }

        [Benchmark(Description = "Значимый тип, координаты double")]
        public void TestDistanceStructDouble()
        {
            for (int i = 0; i < dot1.GetLength(0); i++)
                doubleRes = PointDistanceDoubleStruct(new PointStructDouble { X = dot1[i, 0], Y = dot1[i, 1] }, new PointStructDouble { X = dot2[i, 0], Y = dot2[i, 1] });
        }

        [Benchmark(Description = "Значимый тип, координаты float, к квдрате")]
        public void TestDistanceStructFloatWOSQRT()
        {
            for (int i = 0; i < dot1.GetLength(0); i++)
                floatRes = PointDistanceFloatStructWOSQRT(new PointStructFloat { X = dot1[i, 0], Y = dot1[i, 1] }, new PointStructFloat { X = dot2[i, 0], Y = dot2[i, 1] });
        }
    }

    public class PointClassFloat
    {
        public float X;
        public float Y;
    }

    public struct PointStructFloat
    {
        public float X;
        public float Y;
    }
    public struct PointStructDouble
    {
        public double X;
        public double Y;
    }
}
