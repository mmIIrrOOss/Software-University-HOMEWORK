
namespace WildFarm
{
	using System;
	using System.Collections.Generic;
	public class Hen : Bird
	{
		public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
		{ }

		public override double WeightMultiplier => 0.35;

		public override ICollection<Type> PreferredFoods => new List<Type>() { typeof(Meat), typeof(Seeds), typeof(Fruit), typeof(Vegetable) };

		public override string ProduceSoundSForFood()
		{
			return "Cluck";
		}
	}
}
