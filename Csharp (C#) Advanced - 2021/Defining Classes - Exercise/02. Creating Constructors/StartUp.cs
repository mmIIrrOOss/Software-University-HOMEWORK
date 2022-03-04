

namespace DefiningClasses
{
	using System;
	public class StartUp
	{
		static void Main(string[] args)
		{
			Person first = new Person();
			first.Name = "Pesho";
			first.Age = 21;
			Person second = new Person(21);
			Person third = new Person("Gosho", 43);

		}
	}
}
