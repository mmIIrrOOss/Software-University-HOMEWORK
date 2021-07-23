/*In the "Tribonacci" sequence, every number is formed
 by the sum of the previous 3 numbers. 
 Write a program that prints num numbers from the Tribonacci
 sequence, each on a new line, starting from 1. 
 The input comes as a parameter named num. 
 The value num will always be positive integer.
____________________
Input         Output
4             1 1 2 4
____________________
8             1 1 2 4 7 13 24 44
___________________
*/
using System;

namespace _0_4TribonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            PrintTrib(num);
        }

        private static int GetTribonacci(int num)
        {
            if (num <= 2)
            {
                return 1;
            }

            if (num == 3)
            {
                return 2;
            }
            else
            {
                return GetTribonacci(num - 3) +
                GetTribonacci(num - 2) +
                    GetTribonacci(num - 1);
            }
        }

        private static void PrintTrib(int num)
        {
            for (int i = 1; i <= num; i++)
            {
                Console.Write("{0} ", GetTribonacci(i));
            }
        }
    }
}