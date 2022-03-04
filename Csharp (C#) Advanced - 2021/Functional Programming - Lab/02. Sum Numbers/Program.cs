using System;
using System.Linq;

namespace _02._Sum_Numbers
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] nums = Console.ReadLine()
				.Split(", ")
				.Select(int.Parse)
				.ToArray();
			int sumOfAllNums = nums.Sum();
			int countNums = nums.Length;
			Console.WriteLine(countNums);
			Console.WriteLine(sumOfAllNums);
		}
	}
}
