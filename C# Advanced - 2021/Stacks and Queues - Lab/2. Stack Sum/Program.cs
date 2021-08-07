using System;
using System.Collections.Generic;
using System.Linq;
namespace _2._Stack_Sum
{
	class Program
	{
		static void Main(string[] args)
		{
			var input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
			Stack<int> stack = new Stack<int>();
			for (int i = 0; i < input.Length; i++)
			{
				stack.Push(input[i]);
			}
			while (true)
			{
				string command = Console.ReadLine().ToLower();
				if (command == "end")
				{
					break;
				}
				string[] split = command.Split();
				if (split[0] == "add")
				{
					int first = int.Parse(split[1]);
					int second = int.Parse(split[2]);
					stack.Push(first);
					stack.Push(second);
				}
				else if (split[0] == "remove")
				{
					int countNumber = int.Parse(split[1]);
					if (stack.Count >= countNumber)
					{
						for (int i = 0; i < countNumber; i++)
						{
							stack.Pop();
						}
					}
				}
			}
			int sum = 0;
			while (stack.Count>0)
			{
				sum += stack.Pop();
			}
			Console.WriteLine($"Sum: {sum}");
		}
	}
}
