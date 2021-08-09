using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] arr = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();
			int countAddNum = arr[0];
			int removeNum = arr[1];
			int findNum = arr[2];
			int[] current = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();
			Stack<int> addNum = new Stack<int>(current);
			for (int i = 0; i < removeNum; i++)
			{
				addNum.Pop();
			}
			addNum.TrimExcess();
			bool isFind = false;
			foreach (var item in addNum)
			{
				if (item == findNum)
				{
					isFind = true;
					break;
				}
			}
			if (isFind)
			{
				Console.WriteLine(true.ToString().ToLower());
			}
			else if (addNum.Count == 0)
			{
				Console.WriteLine(0);
			}
			else
			{
				Console.WriteLine(addNum.Min());
			}

		}
	}
}
