namespace _04.Wild_Farm.Models.Food
{
    public abstract class Food
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public virtual int Quantity { get;  set; }
    }
}
