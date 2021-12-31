namespace _04.Wild_Farm.Models.Food
{
    public class Vegetable : Food
    {
        public Vegetable(int quantity)
            :base(quantity)
        {
            this.Quantity = quantity;
        }
    }
}
