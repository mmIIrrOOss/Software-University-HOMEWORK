

namespace Animals
{
	using System;
	public class Kitten : Cat
	{
		public Kitten(string name, int age, string gender = "Female")
			: base(name, gender, age)
		{

		}
		public override string ProduceSound()
		{
			return $"Meow";
		}
	}
}
