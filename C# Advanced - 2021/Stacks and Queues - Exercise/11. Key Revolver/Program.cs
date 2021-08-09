using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
	class Program
	{
		static void Main(string[] args)
		{
			int bulletPrice = int.Parse(Console.ReadLine());
			int size = int.Parse(Console.ReadLine());
			int copy = size;
			int[] symbol = Console.ReadLine().Split().Select(int.Parse).ToArray();
			Stack<int> shoots = new Stack<int>(symbol);
			int[] key = Console.ReadLine().Split().Select(int.Parse).ToArray();
			Stack<int> keys = new Stack<int>(key.Reverse());
			int earned = int.Parse(Console.ReadLine());
			int numShoots = 0;
			while (shoots.Count > 0 && keys.Count > 0)
			{
				if (shoots.Peek() <= keys.Peek()) 
				{
					Console.WriteLine("Bang!");
					shoots.Pop();
					keys.Pop();
					copy--;
					numShoots++;
				}
				else
				{
					Console.WriteLine("Ping!");
					shoots.Pop();
					copy--;
					numShoots++;
				}
				if (copy == 0 && shoots.Count > 0)
				{
					Console.WriteLine("Reloading!");
					copy = size;
				}
			}
			int sum = numShoots * bulletPrice;
			int moeny = earned - sum;
			if (shoots.Count >= 0&& keys.Count == 0)
			{
				Console.WriteLine($"{shoots.Count} bullets left. Earned ${moeny}");
			}
			else 
			{
				Console.WriteLine($"Couldn't get through. Locks left: {keys.Count}");
			}
		}
	}
}
