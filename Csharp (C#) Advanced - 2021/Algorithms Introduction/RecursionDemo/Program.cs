
namespace RecursionDemo
{
    using System;
    class Program
    {
        static void Main()
        {
            int[] array = new int[] { 1, 2, 3 };
            Traverse(array, 0);
            //int number = int.Parse(Console.ReadLine());
            //int pow = int.Parse(Console.ReadLine());
            //Console.WriteLine(Pow(number, pow));
        }
        private static void Traverse<T>(T[] collection, int index)
        {
            if (index == collection.Length)
            {
                return;
            }
            Console.WriteLine(collection[index]);
            Traverse(collection, index + 1);
        }
        private static void Loop(int index)
        {
            if (index == 0)
            {
                return;
            }
            Console.WriteLine($"Hello {index}");
            Loop(index--);
        }
        private static int Pow(int number, int pow)
        {
            if (pow == 1)
            {
                return number;
            }
            int current = number * Pow(number, pow - 1);
            return current;
        }
    }
}
