

namespace Restaurant
{
	using System;
	public class Cake : Dessert
	{
		private const double CakeGrams = 250;
		private const double Calories = 1000;
		private const decimal CakePrice = 5M;
		public Cake(string name)
			: base(name, CakePrice,CakeGrams,Calories)
		{
			this.Name = name;
		}

		
	}
}
