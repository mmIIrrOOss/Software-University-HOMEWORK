using System;
using System.Linq;
namespace Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] initArr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int leftFoldIndex = initArr.Length / 4 - 1;
            int rightFoldIndex = 3 * initArr.Length / 4;

            int[] topArr = new int[initArr.Length / 2];

            int howManyNumbersSoFar = 0;
            for (int i = leftFoldIndex; i >= 0; i--)
            {
                howManyNumbersSoFar++;
                topArr[leftFoldIndex - i] = initArr[i];
            }
            for (int i = initArr.Length - 1; i >= rightFoldIndex; i--)
            {
                topArr[initArr.Length - 1 - i + howManyNumbersSoFar] = initArr[i];
            }


            int[] bottomArr = new int[initArr.Length / 2];

            for (int i = leftFoldIndex + 1; i < rightFoldIndex; i++)
            {
                bottomArr[i - howManyNumbersSoFar] = initArr[i];
            }


            for (int i = 0; i < topArr.Length; i++)
            {
                Console.Write(topArr[i] + bottomArr[i] + " ");
            }
        }
    }
}