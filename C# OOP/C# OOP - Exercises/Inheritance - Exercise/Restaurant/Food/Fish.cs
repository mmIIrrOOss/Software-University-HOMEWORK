

namespace Restaurant
{
	using System;
	public class Fish : MainDish
	{
		private const double Grams = 22;
		public Fish(string name, decimal price) 
			: base(name, price, Grams)
		{

		}

	}
}
