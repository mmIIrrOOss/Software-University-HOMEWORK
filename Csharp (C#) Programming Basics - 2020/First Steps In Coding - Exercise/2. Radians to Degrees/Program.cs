using System;
using System.Net.Http.Headers;

namespace usd_to_gbn
{
    class Program
    {
        static void Main(string[] args)
        {
            double radians = double.Parse(Console.ReadLine());
            double degrees = radians * 180 / Math.PI;
            Console.WriteLine(Math.Round(degrees));

        }
    }
}