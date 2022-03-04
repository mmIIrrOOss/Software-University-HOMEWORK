using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
	class Program
	{
		static void Main(string[] args)
		{
			int quantityFood = int.Parse(Console.ReadLine());
			List<int> orders = Console.ReadLine().Split().Select(int.Parse).ToList();
			Queue<int> queue = new Queue<int>(orders);
			Console.WriteLine(orders.Max());
			while (queue.Count > 0)
			{
				if (quantityFood >= queue.Peek())
				{
					quantityFood -= queue.Dequeue();
				}
				else
				{
					Console.WriteLine($"Orders left: {string.Join(" ", queue.Dequeue())}");
					return;
				}
			}
			Console.WriteLine("Orders complete");
		}
	}
}
