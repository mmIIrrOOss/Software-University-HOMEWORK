using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            if (grade >= 3)
            {
                Console.WriteLine($"Passed!");
            }

        }

    }
}