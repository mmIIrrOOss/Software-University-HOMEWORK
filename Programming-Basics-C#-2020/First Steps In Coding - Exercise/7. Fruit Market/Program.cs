using System;

namespace pazar_za_plodove
{
    class Program
    {
        static void Main(string[] args)
        {
            double strawberryPrice = double.Parse(Console.ReadLine());
            double bananasKg = double.Parse(Console.ReadLine());
            double orangesKg = double.Parse(Console.ReadLine());
            double raaspberryesKg = double.Parse(Console.ReadLine());
            double strawberryesKg = double.Parse(Console.ReadLine());

            double raspberryPrice = strawberryPrice / 2;
            double orangesPrice = raspberryPrice * 0.60;
            double bananaPrice = raspberryPrice * 0.20;

            double sum = (strawberryPrice * strawberryesKg) + (raspberryPrice * raaspberryesKg) + (orangesPrice * orangesKg) + (bananaPrice * bananasKg);
            Console.WriteLine($"{sum:f2}");
        }
    }
}