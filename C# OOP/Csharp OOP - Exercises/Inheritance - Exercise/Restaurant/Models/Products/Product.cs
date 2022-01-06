namespace Restaurant.Models.Products
{
    public abstract class Product
    {
        private decimal price;
        private string name;

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        public virtual string Name { get => name; set => name = value; }
        public virtual decimal Price { get => price; set => price = value; }

    }
}
