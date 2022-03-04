namespace _03.ShoppingSpree
{
    using System;
    public class Product
    {
		public Product(string name, decimal price)
		{
			this.Name = name;
			this.Cost = price;
		}
		public string Name
		{
			get => name;
			set
			{
				if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
				{
					throw new ArgumentException("Name cannot be empty");

				}
				this.name = value;
			}

		}
		public decimal Cost
		{
			get => cost;
			set
			{
				if (value <= 0)
				{
					throw new ArgumentException("Money cannot be negative");
				}
				this.cost = value;
			}
		}

		private string name;
		private decimal cost;

	}
}
