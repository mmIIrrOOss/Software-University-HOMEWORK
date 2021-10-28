
namespace _01_Recursive_Array_Sum
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] array = Console.ReadLine().Split()
                .Select(int.Parse)
                .ToArray();
            Console.WriteLine(ArraySum(array, 0));
        }


        private static int ArraySum(int[] array, int index)
        {
            if (index == array.Length)
            {
                return 0;
            }
            int currentSum = array[index] + ArraySum(array, index + 1);
            return currentSum;
        }
    }
}
