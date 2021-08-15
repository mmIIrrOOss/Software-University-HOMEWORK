using System;
using System.Collections.Generic;
using System.Linq;
namespace _05._Applied_Arithmetics
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> number = Console.ReadLine()
				.Split(" ")
				.Select(int.Parse)
				.ToList();
			Action<List<int>> printNum = x => Console.WriteLine(string.Join(" ",x));
			string command = Console.ReadLine();
			while (command != "end")
			{
				if (command == "add")
				{
					number = number.Select(x => x + 1).ToList();
				}
				else if (command == "multiply")
				{
					number = number.Select(x => x * 2).ToList();
				}
				else if (command == "subtract")
				{
					number = number.Select(x => x - 1).ToList();
				}
				else if (command=="print")
				{
					printNum(number);
				}

				command = Console.ReadLine();
			}
		}
	}
}
