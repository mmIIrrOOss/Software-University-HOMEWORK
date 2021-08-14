using System;
using System.Linq;

namespace _04._Add_VAT
{
	class Program
	{
		static void Main()
		{
			double[] numbers = Console.ReadLine()
				.Split(", ", StringSplitOptions.RemoveEmptyEntries)
				.Select(double.Parse)
				.Select(x => x += x * 0.20)
				.ToArray();
			foreach (var item in numbers)
			{
				Console.WriteLine($"{item:f2}");
			}
		}
	}
}
