using System;
using System.Collections;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] children = Console.ReadLine().Split();
			int count = int.Parse(Console.ReadLine());
			Queue<string> qy = new Queue<string>(children);
			while (qy.Count > 1)
			{
				for (int i = 1; i < count; i++)
				{
					qy.Enqueue(qy.Dequeue());
				}
				Console.WriteLine($"Removed {qy.Dequeue()}");
			}
			Console.WriteLine($"Last is {qy.Dequeue()}");
		}

	}
}
