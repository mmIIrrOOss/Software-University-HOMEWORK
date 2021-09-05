
namespace WildFarm
{
	using System;
	using System.Collections.Generic;
	public class Cat : Feline
	{
		public Cat(string name, double weight, string livingRegion, string breed)
			: base(name, weight, livingRegion, breed)
		{
		}
		public override double WeightMultiplier => 0.3;


		public override ICollection<Type> PreferredFoods => new List<Type>() { typeof(Vegetable), typeof(Meat) };

		public override string ProduceSoundSForFood()
		{
			return "Meow";
		}
	}
}
