using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] expressions = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();
			Queue<int> even = new Queue<int>();
			GetEvenNumbers(expressions, even);
			PrintEveneNumbers(even);
		}

		static Queue<int> GetEvenNumbers(int[] expressionns, Queue<int> evenNumbers)
		{
			foreach (var even in expressionns)
			{
				if (even % 2 == 0)
				{
					evenNumbers.Enqueue(even);
				}
			}
			return evenNumbers;
		}
		private static void PrintEveneNumbers(Queue<int> even)
		{
				Console.Write(string.Join(", ",even));
		}

	}
}
