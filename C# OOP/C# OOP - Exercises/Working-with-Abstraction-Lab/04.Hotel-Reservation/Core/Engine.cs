namespace _04.Hotel_Reservation.Core
{
    using System;
    using Contracts;
    using Models;
    using Models.Enums;
    using IO;

    public class Engine : IEngine
    {
        public void Run()
        {
            ConsoleReader reader = new ConsoleReader();
            ConsoleWriter writer = new ConsoleWriter();

            string[] splitInput = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double pricePerDay = double.Parse(splitInput[0]);
            int numberOfDay = int.Parse(splitInput[1]);
            Season season = Enum.Parse<Season>(splitInput[2]);
            DiscountType discountType = DiscountType.None;
            PriceCalculator priceCalculator = new PriceCalculator(pricePerDay, numberOfDay, season);
            if (splitInput.Length == 4)
            {
                discountType = Enum.Parse<DiscountType>(splitInput[3]);
                priceCalculator = new PriceCalculator(pricePerDay, numberOfDay, season,discountType);
            }
            priceCalculator.ClculateTotalPrice();
        }
    }
}
