using System;
using System.Collections.Generic;
using System.Linq;
namespace _09._List_Of_Predicates
{
	class Program
	{
		static void Main(string[] args)
		{
			int numEnd = int.Parse(Console.ReadLine());
			List<int> nums = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.Distinct()
				.ToList();
			List<int> result = new List<int>();
			for (int i = 1; i <= numEnd; i++)
			{
				if (DevidersInfo(nums, i))
				{
					result.Add(i);
				}
			}
			Console.WriteLine(string.Join(" ", result));
		}
		static bool DevidersInfo(List<int> deviders, int end)
		{
			bool isTrue = true;
			foreach (var item in deviders)
			{
				if (end % item != 0)
				{
					isTrue = false;
				}
			}
			return isTrue;
		}
	}
}
