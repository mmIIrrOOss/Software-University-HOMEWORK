namespace _02.Composite_Pattern
{
    using System.Collections.Generic;

    public class CompositeGift : GiftBase, IGiftOperation
    {
        private List<GiftBase> gifts;

        public CompositeGift(string name, int price) 
            : base(name, price)
        {
            this.gifts = new List<GiftBase>();
        }

        public void Add(GiftBase gift)
        {
            this.gifts.Add(gift);
        }

        public override int ClculateTotalPrice()
        {
            int totalPrice = 0;
            System.Console.WriteLine($"{this.name} contains the following products with prices:");
            foreach (var gift in this.gifts)
            {
                totalPrice += gift.ClculateTotalPrice();
            }
            return totalPrice;
        }

        public void Remove(GiftBase gift)
        {
            this.gifts.Remove(gift); 
        }
    }
}
