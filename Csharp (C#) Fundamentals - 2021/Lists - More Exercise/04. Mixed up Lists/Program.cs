using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Mixed_up_Lists
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> firstNumbers = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToList();
			List<int> secondNumbers = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToList();
			List<int> maxList = new List<int>();
			List<int> mixedList = new List<int>();
			if (firstNumbers.Count > secondNumbers.Count)
			{
				maxList = firstNumbers;
			}
			else
			{
				maxList = secondNumbers;
				maxList.Reverse();
			}
			List<int> rule = maxList.TakeLast(2).ToList();
			rule.Sort();
			if (firstNumbers.Count > secondNumbers.Count)
			{
				firstNumbers.RemoveRange(firstNumbers.Count - 2, 2);
			}
			else
			{
				secondNumbers.RemoveRange(secondNumbers.Count - 2, 2);
			}
			for (int i = 0; i < firstNumbers.Count; i++)
			{
				mixedList.Add(firstNumbers[i]);
				mixedList.Add(secondNumbers[i]);
			}
			List<int> result = mixedList.FindAll(x => x > rule[0] && x < rule[1]);
			result.Sort();
			Console.WriteLine(string.Join(" ",result));
		}
	}
}
