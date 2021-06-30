using System;

namespace zaduljitelna_literatura
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalPages = int.Parse(Console.ReadLine());
            int pagesPerHour = int.Parse(Console.ReadLine());
            int daysCount = int.Parse(Console.ReadLine());

            double result = (totalPages * 1.0 / pagesPerHour * 1.0) / daysCount * 1.0;
            Console.WriteLine(result);
        }
    }
}