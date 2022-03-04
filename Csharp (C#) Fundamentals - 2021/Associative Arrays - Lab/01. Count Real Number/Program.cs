using System;

namespace _01._Count_Real_Number
{
	using System.Collections.Generic;
	using System.Linq;
	class Program
	{
		static void Main(string[] args)
		{
			List<double> numbers = Console.ReadLine()
				.Split()
				.Select(double.Parse)
				.ToList();
			var counts = new SortedDictionary<double, int>();
			foreach (var item in numbers)
			{
				if (counts.ContainsKey(item))
				{
					counts[item]++;
				}
				else
				{
					counts[item] = 1;
				}
			}
			foreach (var item in counts)
			{
				Console.WriteLine($"{item.Key} -> {item.Value}");
			}
		}
	}
}
