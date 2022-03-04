namespace OnlineShop.Models.Products.Peripherals
{
    public class Headset : Peripheral
    {
        public Headset(int id, string manufacturer, string model, decimal price, double overallPerformance, 
            string connectType) 
            : base(id, manufacturer, model, price, overallPerformance, connectType)
        {
        }
    }
}
