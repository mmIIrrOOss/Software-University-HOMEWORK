using System;
using System.Collections.Generic;
using System.Linq;
namespace _2._Stack_Sum
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] input = Console.ReadLine().Split().Reverse().ToArray();
			Stack<string> stack = new Stack<string>(input);
			while(stack.Count>1)
			{
				//PrintStack(stack);
				int first = int.Parse(stack.Pop());
				string sign = stack.Pop();
				int second = int.Parse(stack.Pop());
				GetOperator(stack, first, sign, second);
			}
			Console.WriteLine(stack.Pop());
		}

		//private static void PrintStack(Stack<string> stack)
		//{
		//	foreach (var item in stack)
		//	{
		//		Console.Write(item);
		//	}
		//	Console.WriteLine();
		//}

		private static void GetOperator(Stack<string> stack, int first, string sign, int second)
		{
			switch (sign)
			{
				case "+":
					stack.Push((first + second).ToString());
					break;
				case "-":
					stack.Push((first - second).ToString());
					break;
				default:
					break;
			}
		}
	}
}
