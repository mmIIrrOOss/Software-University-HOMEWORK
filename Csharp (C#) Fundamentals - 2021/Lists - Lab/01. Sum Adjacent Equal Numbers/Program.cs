using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Sum_Adjacent_Equal_Numbers
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> number = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToList();
			int origNumber = number.Count;
			for (int i = 0; i < number.Count/2; i++)
			{
				number[i] += number[number.Count - 1];
				number.RemoveAt(number.Count - 1);
			}
			Console.WriteLine(string.Join(" ",number));
			
		}
	}
}
