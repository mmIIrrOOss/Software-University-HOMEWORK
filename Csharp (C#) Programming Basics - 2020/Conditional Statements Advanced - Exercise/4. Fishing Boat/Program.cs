using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel
{
    class Program
    {
        static void Main(string[] args)
        {

            double budjet = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int numFishing = int.Parse(Console.ReadLine());

            double rentalPrice = 0;

            switch (season)
            {
                case "Spring":
                    rentalPrice = 3000;
                    break;
                case "Summer":
                case "Autumn":
                    rentalPrice = 4200;
                    break;
                case "Winter":
                    rentalPrice = 2600;
                    break;
                default:
                    break;
            }

            if (numFishing <= 6)
            {
                rentalPrice = rentalPrice - 0.10 * rentalPrice;
            }
            else if (numFishing >= 7 && numFishing <= 11)
            {
                rentalPrice = rentalPrice - 0.15 * rentalPrice;
            }
            else if (numFishing > 12)
            {
                rentalPrice = rentalPrice - 0.25 * rentalPrice;

            }


            if (numFishing % 2 == 0 && season != "Autumn")
            {
                rentalPrice = rentalPrice - 0.05 * rentalPrice;
            }
            if (budjet >= rentalPrice)
            {
                double leftMoney = budjet - rentalPrice;
                Console.WriteLine($"Yes! You have {leftMoney:f2} leva left.");
            }
            else
            {
                double needMoney = rentalPrice - budjet;
                Console.WriteLine($"Not enough money! You need {needMoney:f2} leva.");
            }


        }
    }
}