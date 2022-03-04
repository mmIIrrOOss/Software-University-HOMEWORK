using System;

namespace _01._Data_Types
{
	class Program
	{
		static void Main(string[] args)
		{
			string random = Console.ReadLine();
			string values = Console.ReadLine();
			GetAndCheckValues(random, values);
		}

		private static void GetAndCheckValues(string random, string values)
		{
			if (random == "string")
			{
				Console.WriteLine($"${values}$");
			}
			else if (random == "int")
			{
				int number = int.Parse(values);
				Console.WriteLine(number * 2);
			}
			else if (random == "real")
			{
				double number = double.Parse(values);
				Console.WriteLine($"{(number * 1.5):f2}"); ;
			}
		}
	}
}
