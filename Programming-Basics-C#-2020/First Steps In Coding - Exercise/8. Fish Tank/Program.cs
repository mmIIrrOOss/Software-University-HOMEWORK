using System;

namespace akvariym
{
    class Program
    {
        static void Main(string[] args)
        {
            double Length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine());

            double volumeLiters = (Length * width * height) * 0.001;
            double areaWidthSand = volumeLiters * (percentage / 100);
            double result = volumeLiters - areaWidthSand;
            Console.WriteLine(result);
        }
    }
}