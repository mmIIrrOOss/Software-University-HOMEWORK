using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string projectionType = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());
            double income = 0.0;
            if (projectionType == "Premiere")
            {
                income = rows * columns * 12.00;
            }
            else if (projectionType == "Normal")
            {
                income = rows * columns * 7.50;
            }
            else if (projectionType == "Discount")
            {
                income = rows * columns * 5.0;
            }
            Console.WriteLine($"{income:f2} leva");

        }
    }
}
