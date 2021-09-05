
namespace WildFarm
{
	using System;
	using System.Collections.Generic;
	public interface IFeedable
	{
		int FoodEaten { get; }

		double WeightMultiplier { get; }

		void Feed(IFood food);

		ICollection<Type> PreferredFoods { get; }
	}
}