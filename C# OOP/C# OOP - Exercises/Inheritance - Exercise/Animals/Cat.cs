
namespace Animals
{
	using System;
	public class Cat : Animals
	{
		public Cat(string name, string gender, int age) 
			: base(name, age,gender)
		{

		}

		public override string ProduceSound()
		{
			return "Meow meow";
		}
	}
}
