using System;
namespace Sort_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());
            int lastNumber = number % 10;
            string PrintLastNum = "";
            if (lastNumber == 1)
            {
                PrintLastNum = "one";
            }
            else if (lastNumber == 2)
            {
                PrintLastNum = "two";
            }
            else if (lastNumber == 3)
            {
                PrintLastNum = "three";
            }
            else if (lastNumber == 4)
            {
                PrintLastNum = "four";
            }
            else if (lastNumber == 5)
            {
                PrintLastNum = "five";
            }
            else if (lastNumber == 6)
            {
                PrintLastNum = "six";
            }
            else if (lastNumber == 7)
            {
                PrintLastNum = "seven";
            }
            else if (lastNumber == 8)
            {
                PrintLastNum = "eight";
            }
            else if (lastNumber == 9)
            {
                PrintLastNum = "nine";
            }
            else if (lastNumber == 0)
            {
                PrintLastNum = "zero";
            }
            Console.WriteLine(PrintLastNum);

        }
    }
}