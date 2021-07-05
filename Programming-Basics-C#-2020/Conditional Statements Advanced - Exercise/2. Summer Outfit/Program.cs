using System;

namespace SummerOutfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int degrees = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();
            string outfit = "";
            string shoes = "";

            if (degrees >= 10 && degrees <= 18)
            {
                switch (timeOfDay)
                {
                    case "Morning":
                        outfit = "Sweatshirt";
                        shoes = "Sneakers";
                        Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
                        break;
                    case "Afternoon":
                        outfit = "Shirt";
                        shoes = "Moccasins";
                        Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
                        break;
                    case "Evening":
                        outfit = "Shirt";
                        shoes = "Moccasins";
                        Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
                        break;

                    default:
                        break;
                }
            }
            else if (degrees > 18 && degrees <= 24)
            {
                switch (timeOfDay)
                {
                    case "Morning":
                        outfit = "Shirt";
                        shoes = "Moccasins";
                        Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
                        break;
                    case "Afternoon":
                        outfit = "T-Shirt";
                        shoes = "Sandals";
                        Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
                        break;
                    case "Evening":
                        outfit = "Shirt";
                        shoes = "Moccasins";
                        Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
                        break;

                    default:
                        break;
                }
            }
            else if (degrees >= 25)
            {
                switch (timeOfDay)
                {
                    case "Morning":
                        outfit = "T-Shirt";
                        shoes = "Sandals";
                        Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
                        break;
                    case "Afternoon":
                        outfit = "Swim Suit";
                        shoes = "Barefoot";
                        Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
                        break;
                    case "Evening":
                        outfit = "Shirt";
                        shoes = "Moccasins";
                        Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
                        break;

                    default:
                        break;
                }

            }
        }
    }
}
