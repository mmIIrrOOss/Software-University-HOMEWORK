using System;
using System.Collections.Generic;
using System.Linq;
namespace _03._Custom_Min_Function
{
	class Program
	{
		static void Main(string[] args)
		{
			int arr = Console.ReadLine()
				.Split(" ")
				.Select(int.Parse)
				.ToArray()
				.Min();
			Console.WriteLine(arr);
		}

	}
}
