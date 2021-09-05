
namespace WildFarm
{
	using System;
	using System.Collections.Generic;
	public abstract class Animal
	: IAnimal, IFeedable, IProducingSoundForFood
	{
		private const string INV_FOOD_TYPE = "{0} does not eat {1}!";
		protected Animal(string name, double weight)
		{
			Name = name;
			Weight = weight;
		}

		public string Name { get; }
		public double Weight { get; private set; }

		public int FoodEaten { get; private set; }

		public abstract double WeightMultiplier { get; }

		public abstract ICollection<Type> PreferredFoods { get; }

		public void Feed(IFood food)
		{
			if (PreferredFoods.Contains(food.GetType()) == false)
			{
				throw new InvalidOperationException(string
					.Format(INV_FOOD_TYPE, GetType().Name, food.GetType().Name));
			}

			FoodEaten += food.Quantity;
			Weight += food.Quantity * WeightMultiplier;
		}

		public abstract string ProduceSoundSForFood();

		public override string ToString()
		{
			return $"{GetType().Name} [{Name}, ";
		}
	}
}

