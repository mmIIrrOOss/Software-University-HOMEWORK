using System;
using System.Collections.Generic;
using System.Linq;
namespace _08._Custom_Comparator
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] numsArr = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();
			List<int> evenNum = new List<int>();
			List<int> oddNum = new List<int>();
			CheckEvenOddNum(numsArr, evenNum, oddNum);
			Console.Write(string.Join(" ", evenNum.OrderBy(x=>x)));
			Console.Write(" ");
			Console.Write(string.Join(" ", oddNum.OrderByDescending(x=>x).Reverse()));
		}
		static void CheckEvenOddNum(int[] arr,List<int> evenNum,List<int> oddNum)
		{
			foreach (var item in arr)
			{
				if (item % 2 == 0)
				{
					evenNum.Add(item);
				}
				else
				{
					oddNum.Add(item);
				}
			}
		}
	}
}
