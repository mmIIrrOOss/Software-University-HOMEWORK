using System;
using System.Diagnostics.CodeAnalysis;

namespace colculate_to_deposit
{
    class Program
    {
        static void Main(string[] args)
        {
            double deposit = double.Parse(Console.ReadLine());
            int depositINMounts = int.Parse(Console.ReadLine());
            double interest = double.Parse(Console.ReadLine());
            double lihva = deposit * (interest / 100);
            double interestOfMounth = lihva / 12;
            double result = deposit + (depositINMounts * interestOfMounth);

            Console.WriteLine(result);


        }
    }
}