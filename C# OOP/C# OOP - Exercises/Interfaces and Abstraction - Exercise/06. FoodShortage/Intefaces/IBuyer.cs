

namespace FoodShortage
{
	using System;
	public interface IBuyer
	{
		string Name { get; }
		public int Food { get; }
		public void BuyFood();
	}
}
