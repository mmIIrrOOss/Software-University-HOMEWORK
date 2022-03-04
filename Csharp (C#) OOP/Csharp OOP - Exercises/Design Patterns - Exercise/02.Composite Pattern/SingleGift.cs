namespace _02.Composite_Pattern
{
    public class SingleGift : GiftBase
    {
        public SingleGift(string name, int price) 
            : base(name, price)
        {
        }

        public override int ClculateTotalPrice()
        {
            System.Console.WriteLine($"{this.name} name with the price {this.price} ");
            return this.price;
        }
    }
}
