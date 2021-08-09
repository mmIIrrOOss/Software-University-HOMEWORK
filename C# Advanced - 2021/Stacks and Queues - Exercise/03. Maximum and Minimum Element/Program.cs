using System;
using System.Collections.Generic;
using System.Linq;
namespace _03._Maximum_and_Minimum_Element
{
	class Program
	{
		static void Main(string[] args)
		{
			int numQuery = int.Parse(Console.ReadLine());
			Stack<int> stack = new Stack<int>();
			for (int i = 0; i < numQuery; i++)
			{
				int[] operators = Console.ReadLine().Split().Select(int.Parse).ToArray();
				if (operators[0] == 1)
				{
					int add = operators[1];
					stack.Push(add);
				}
				else if (operators[0] == 2)
				{
					if (stack.Count>0)
					{
						stack.Pop();
					}
				}
				else if (operators[0] == 3)
				{
					if (stack.Count > 0)
					{
						Console.WriteLine(stack.Max());
					}
				}
				else if (operators[0] == 4)
				{
					if (stack.Count > 0)
					{
						Console.WriteLine(stack.Min());
					}
				}
			}
			Console.WriteLine(string.Join(", ", stack));
		}
	}
}
