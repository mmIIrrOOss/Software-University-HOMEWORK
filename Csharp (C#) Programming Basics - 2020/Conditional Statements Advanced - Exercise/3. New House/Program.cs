using System;

namespace NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeFlower = Console.ReadLine();
            int countFlowers = int.Parse(Console.ReadLine());
            double budjet = double.Parse(Console.ReadLine());
            double price = 0;

            switch (typeFlower)
            {
                case "Roses":
                    price = 5;
                    break;
                case "Dahlias":
                    price = 3.80;
                    break;
                case "Tulips":
                    price = 2.80;
                    break;
                case "Narcissus":
                    price = 3.00;
                    break;
                case "Gladiolus":
                    price = 2.50;
                    break;
                default:
                    break;
            }

            double totalPrice = countFlowers * price;


            if (countFlowers > 80 && typeFlower == "Roses")
            {
                totalPrice = 0.9 * totalPrice;
            }
            else if (countFlowers > 90 && typeFlower == "Dahlias")
            {
                totalPrice = 0.85 * totalPrice;
            }
            else if (countFlowers > 80 && typeFlower == "Tulips")
            {
                totalPrice = 0.85 * totalPrice;
            }
            else if (countFlowers < 120 && typeFlower == "Narcissus")
            {
                totalPrice = 1.15 * totalPrice;
            }
            else if (countFlowers < 80 && typeFlower == "Gladiolus")
            {
                totalPrice = totalPrice + 0.20 * totalPrice;
            }
            if (budjet >= totalPrice)
            {
                double leftSum = budjet - totalPrice;
                Console.WriteLine($"Hey, you have a great garden with {countFlowers} {typeFlower} and {leftSum:f2} leva left.");

            }
            else
            {
                double needSum = budjet - totalPrice;
                Console.WriteLine($"Not enough money, you need {Math.Abs(needSum):f2} leva more.");
            }
        }
    }
}
