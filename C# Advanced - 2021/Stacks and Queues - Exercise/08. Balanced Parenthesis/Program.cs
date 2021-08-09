using System;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
	class Program
	{
		static void Main(string[] args)
		{
			char[] symbol = Console.ReadLine().ToCharArray();
			Stack<char> stack = new Stack<char>();
			Queue<char> queue = new Queue<char>();
			for (int i = 0; i < symbol.Length; i++)
			{
				if (i < symbol.Length / 2)
				{
					stack.Push(symbol[i]);
				}
				else
				{
					queue.Enqueue(symbol[i]);
				}
			}
			while (stack.Count > 0 && queue.Count > 0)
			{
				char first = stack.Pop();
				char second = queue.Dequeue();
				if (!((first == '(' && second == ')')
					|| (first == '{' && second == '}')
					|| (first == '[' && second == ']')))
				{
					Console.WriteLine("NO");
					return;
				}
			}
			Console.WriteLine("YES");

		}
	}
}
