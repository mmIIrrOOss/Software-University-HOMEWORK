using System;
using System.Collections.Generic;
using System.Linq;
namespace _01._Count_Same_Values_in_Array
{
	class Program
	{
		static void Main(string[] args)
		{
			double [] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();
			Dictionary<double, int> nums = new Dictionary<double, int>();
			for (int i = 0; i < numbers.Length; i++)
			{
				if (!nums.ContainsKey(numbers[i]))
				{
					nums.Add(numbers[i], 1);
				}
				else
				{
					nums[numbers[i]]++;
				}
			}
			foreach (var item in nums)
			{
				Console.WriteLine($"{item.Key} - {item.Value} times");
			}
			
		}
	}
}
