using System;
using System.Collections.Generic;
namespace _4._Matching_Brackets
{
	class Program
	{
		static void Main(string[] args)
		{
			string expressions = Console.ReadLine();
			Stack<int> stack = new Stack<int>();
			for (int i = 1; i < expressions.Length; i++)
			{
				if (expressions[i]=='(')
				{
					stack.Push(i);
				}
				else if (expressions[i]==')')
				{
					int start = stack.Pop();
					Console.WriteLine(expressions.Substring(start, i - start+1));
				}
			}
		}
	}
}
