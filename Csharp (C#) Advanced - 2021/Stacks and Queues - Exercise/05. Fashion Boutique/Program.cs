using System;
using System.Collections.Generic;
using System.Linq;
namespace _05._Fashion_Boutique
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int capacity = int.Parse(Console.ReadLine());
			Stack<int> stack = new Stack<int>(clothes);
			int sum = 0;
			int count = 1;
			while (stack.Count > 0)
			{
				sum += stack.Peek();
				if (sum<=capacity)
				{
					stack.Pop();
				}
				else
				{
					count++;
					sum = 0;
				}
			}
			Console.WriteLine(count); 
		}
	}
}
