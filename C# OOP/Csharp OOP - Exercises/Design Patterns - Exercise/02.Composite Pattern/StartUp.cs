namespace _02.Composite_Pattern
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            var phone = new SingleGift("Phone", 256);
            phone.ClculateTotalPrice();
            Console.WriteLine();

            var rootBox = new CompositeGift("RootBox", 0);
            var truckToy = new SingleGift("RootBox", 289);
            var plainToy = new CompositeGift("PlainToy", 587);

            rootBox.Add(truckToy);
            rootBox.Add(plainToy);

            var childBox = new CompositeGift("ChildBox", 0);
            var soldierToy = new CompositeGift("ChildBox", 0);
            childBox.Add(soldierToy);
            rootBox.Add(childBox);

            Console.WriteLine($"Total price of this composite present is: {rootBox.ClculateTotalPrice()}");
        }
    }
}
