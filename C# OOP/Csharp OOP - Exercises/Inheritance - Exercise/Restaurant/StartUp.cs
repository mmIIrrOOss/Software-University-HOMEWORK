namespace Restaurant
{
    using Models.Products.Beverages.HotBeverage;
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var coffe = new Coffee("Esspresso", 2.5);
            Console.WriteLine($"{coffe.Name} {coffe.Caffeine}");
        }
    }
}