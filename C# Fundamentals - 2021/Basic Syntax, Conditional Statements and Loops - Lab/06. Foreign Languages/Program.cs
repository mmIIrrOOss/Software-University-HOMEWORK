using System;

namespace Exercise_1
{
	class Program
	{
		static void Main(string[] args)
		{
			string country = Console.ReadLine();
			switch (country)
			{
				case "England":
				case "USA":
					Console.WriteLine("English");
					break;
				case "Spain":
				case "Arjentina":
				case "Mexico":
					Console.WriteLine("Spanish");
					break;
				default:
					Console.WriteLine("unknown");
					break;
			}
		}

	}
}