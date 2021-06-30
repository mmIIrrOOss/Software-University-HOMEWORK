using System;

namespace usd_to_gbn
{
    class Program
    {
        static void Main(string[] args)
        {
            double usdtobgn = double.Parse(Console.ReadLine());
            double convertor = usdtobgn * 1.79549;
            Console.WriteLine($"{ convertor:F2}");


        }
    }
}