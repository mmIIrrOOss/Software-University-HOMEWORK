using System;

namespace app1
{
    class Program
    {
        static void Main(string[] args)
        {
            double metersInGreen = double.Parse(Console.ReadLine());
            double priceInGreen = metersInGreen * 7.61;
            double discount = priceInGreen - (priceInGreen * 0.18);
            Console.WriteLine($"The final price is: {discount} lv.");
            Console.WriteLine($"The discount is: {priceInGreen * 0.18} lv.");


        }
    }
}