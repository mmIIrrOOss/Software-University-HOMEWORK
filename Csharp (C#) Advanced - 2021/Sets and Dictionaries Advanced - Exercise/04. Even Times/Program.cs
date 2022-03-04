using System;
using System.Collections.Generic;

namespace _04._Even_Times
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			int save = 0;
			HashSet<int> nums = new HashSet<int>();
			for (int i = 0; i < n; i++)
			{
				int num = int.Parse(Console.ReadLine());
				if (!nums.Contains(num))
				{
					nums.Add(num);
					continue;
				}
				if (nums.Contains(num))
				{
					save = num;
				}
			}
			Console.WriteLine(save);
		}
	}
}
