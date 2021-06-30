using System;

namespace app1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberIsDock = int.Parse(Console.ReadLine());
            int numberIsOtherAnimal = int.Parse(Console.ReadLine());
            double FoodisDock = numberIsDock * 2.50;
            int otherFood = numberIsOtherAnimal * 4;
            double sumOfResult = FoodisDock + otherFood;
            Console.WriteLine($"{sumOfResult} lv.");


        }
    }
}