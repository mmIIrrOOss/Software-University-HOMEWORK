using System;
using System.Collections.Generic;
using System.Linq;
namespace _03._Custom_Min_Function
{
	class Program
	{
		static void Main(string[] args)
		{
			Predicate<int> isEven = x => x % 2 == 0;
			Func<int, bool> isEvenFunc = x => x % 2 == 0;
			Action<List<int>> pirntNums = x => Console.WriteLine(string.Join(" ", x));
			int[] arr = Console.ReadLine()
				.Split(" ")
				.Select(int.Parse)
				.Select(x => Math.Abs(x))
				.ToArray();
			List<int> numbers = new List<int>();
			List<int> result = new List<int>();
			int start = arr[0];
			int end = arr[1];
			for (int i = start; i <= end; i++)
			{
				numbers.Add(i);
			}
			string input = Console.ReadLine();
			if (input == "even")
			{
				result = numbers.Where(isEvenFunc).ToList();
			}
			else if (input == "odd")
			{
				result = numbers.Where(x=>!isEvenFunc(x)).ToList();

			}
			pirntNums(result);
		}

	}
}
