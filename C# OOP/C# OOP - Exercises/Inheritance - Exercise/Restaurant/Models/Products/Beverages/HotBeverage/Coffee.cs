namespace Restaurant.Models.Products.Beverages.HotBeverage
{
    public class Coffee : HotBeverage
    {
        private const double coffe_milliliters = 50;
        private const decimal coffe_price = 3.50m;
        public Coffee(string name, double caffeine)
            : base(name, coffe_price, coffe_milliliters)
        {
            Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
