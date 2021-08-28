

namespace ShoppingSpree
{
	using System;
	using System.Collections.Generic;
	public class Person
	{

		public Person(string name, decimal money)
		{
			this.Name = name;
			this.Money = money;
			this.Products = new List<string>();
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
		public decimal Money
		{
			get => money;
			set
			{
				if (value < 0)
				{
					throw new ArgumentException("Money cannot be negative ");
				}
				this.money = value;
			}
		}
		public List<string> Products
		{
			get
			{
				return this.products;
			}
			set
			{
				this.products = value;
			}
		}
		private string name;
		private decimal money;
		private List<string> products;
	}
}
