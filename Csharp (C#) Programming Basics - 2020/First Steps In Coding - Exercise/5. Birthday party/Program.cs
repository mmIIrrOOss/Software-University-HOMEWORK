using System;

namespace zaduljitelna_literatura
{
    class Program
    {
        static void Main(string[] args)
        {
            double rent = double.Parse(Console.ReadLine());
            double cakePrice = rent * 0.20;
            double drinks = cakePrice * 0.55;
            double Animation = rent / 3;
            double result = rent + cakePrice + drinks + Animation;
            Console.WriteLine(result);
        }
    }
}