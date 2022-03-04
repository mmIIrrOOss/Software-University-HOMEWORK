
namespace _06._Reverse_And_Exclude
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	class Program
	{
		static void Main(string[] args)
		{
			List<int> numbers = Console.ReadLine()
			 .Split()
			 .Select(int.Parse)
			 .Reverse()
			 .ToList();
			int divides = int.Parse(Console.ReadLine());
			Func<int, bool> filter = n => n % divides != 0;
			var remainingNumbers = numbers.Where(filter);
			Console.WriteLine(string.Join(" ", remainingNumbers));
		}
	}
}
