namespace _04.Hotel_Reservation.Models
{
    using System;
    using Enums;
    using IO;
    public class PriceCalculator
    {
        private double pricePerDay;
        private int numberOfDay;
        private Season season;
        private DiscountType discountType;

        public PriceCalculator(double pricePerDay,int numberOfDay,Season season,DiscountType  discountType)
        {
            this.pricePerDay = pricePerDay;
            this.numberOfDay = numberOfDay;
            this.season = season;
            this.discountType = discountType;
        }
        public PriceCalculator(double pricePerDay,int numberOfDay,Season season)
        {
            this.pricePerDay = pricePerDay;
            this.numberOfDay = numberOfDay;
            this.season = season;
        }

        public void ClculateTotalPrice()
        {
            ConsoleWriter writer = new ConsoleWriter();
            double totalPrice = this.pricePerDay * this.numberOfDay * (int)this.season;
            double discount = totalPrice * (int)this.discountType/100.0;
            double price = totalPrice - discount;
            writer.WriteLine($"{price:f2}");
        }

    }
}
