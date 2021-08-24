using System;
using System.Collections.Generic;

namespace Animals
{
	public class StartUp
	{
		public static void Main()
		{
			List<Animals> animal = new List<Animals>();
			string command;
			while ((command =Console.ReadLine())!="Beast!")
			{
				var tokens = Console.ReadLine().Split();
				var name = tokens[0];
				var age = int.Parse(tokens[1]);
				var gender = tokens[2];
				try
				{
					switch (command)
					{

						case "Cat":
							animal.Add(new Cat(name, gender, age));
							break;
						case "Dog":
							animal.Add(new Dog(name, age, gender));
							break;
						case "Frog":
							animal.Add(new Frog(name, age, gender));
							break;
						case "Kitten":
							animal.Add(new Kitten(name, age));
							break;
						case "TomCat":
							animal.Add(new Tomcat(name, age));
							break;
						default:
							throw new ArgumentException("Invalid input!");
					}
				}
				catch (ArgumentException ax)
				{
					Console.WriteLine(ax.Message);
				}
			}
			animal.ForEach(Console.WriteLine);

		}
	}
}
