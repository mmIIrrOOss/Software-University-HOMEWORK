
namespace WildFarm
{
	using System;
	using System.Collections.Generic;


	public class Tiger : Feline
	{
		public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
		{ }

		public override double WeightMultiplier => 1.00;

		public override ICollection<Type> PreferredFoods => new List<Type>() { typeof(Meat) };

		public override string ProduceSoundSForFood()
		{
			return "ROAR!!!";
		}
	}

}
