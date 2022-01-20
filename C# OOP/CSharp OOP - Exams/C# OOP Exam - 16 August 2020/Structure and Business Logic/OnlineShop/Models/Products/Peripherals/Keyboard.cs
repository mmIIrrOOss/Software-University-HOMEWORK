namespace OnlineShop.Models.Products.Peripherals
{
    public class Keyboard : Peripheral
    {
        public Keyboard(int id, string manufacturer, string model, decimal price, 
            double overallPerformance, string connectType)
            : base(id, manufacturer, model, price, overallPerformance, connectType)
        {
        }
    }
}
