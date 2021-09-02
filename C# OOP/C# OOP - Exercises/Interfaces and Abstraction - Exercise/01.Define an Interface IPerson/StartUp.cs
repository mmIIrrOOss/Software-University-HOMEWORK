
namespace PersonInfo
{
	using System;
	public class StartUp
	{
		public static void Main()
		{
			string name = Console.ReadLine();
			int age = int.Parse(Console.ReadLine());
			IPerson person = new Citizen(name, age);
			Console.WriteLine(person.Age);
			Console.WriteLine(person.Name);
		}
	}
}
