
namespace BubbleSort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length - 1; j++)
                {
                    if (numbers[i] > numbers[j])
                    {
                        int tempNumber = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = tempNumber;
                    }
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
