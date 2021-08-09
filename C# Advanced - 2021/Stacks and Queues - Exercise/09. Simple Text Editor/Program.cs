using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09._Simple_Text_Editor
{
	class Program
	{
		static void Main(string[] args)
		{
			int line = int.Parse(Console.ReadLine());
			StringBuilder str = new StringBuilder();
			Stack<string> stack = new Stack<string>();
			stack.Push(str.ToString());
			for (int i = 0; i < line; i++)
			{
				string[] arr = Console.ReadLine().Split();
				if (arr[0] == "1")
				{
					str.Append(arr[1]);
					stack.Push(str.ToString());
				}
				else if (arr[0] == "2")
				{
					int count = int.Parse(arr[1]);
					str.Remove(str.Length - count, count);
					stack.Push(str.ToString());
				}
				else if (arr[0] == "3")
				{
					int index = int.Parse(arr[1]);
					Console.WriteLine(str[index - 1]);
				}
				else if (arr[0] == "4")
				{
					stack.Pop();
					str = new StringBuilder();
					str.Append(stack.Peek());
				}

			}
		}
	}
}
