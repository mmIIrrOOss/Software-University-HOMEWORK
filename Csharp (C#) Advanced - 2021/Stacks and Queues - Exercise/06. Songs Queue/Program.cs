using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
	class Program
	{
		static void Main(string[] args)
		{
			List<string> songs = Console.ReadLine().Split(", ").ToList();
			Queue<string> queue = new Queue<string>();
			foreach (var song in songs)
			{
				queue.Enqueue(song);
			}
			while (queue.Any())
			{
				string commmand = Console.ReadLine();

				if (commmand == "Play")
				{
					queue.Dequeue();

				}
				else if (commmand.StartsWith("Add"))
				{
					var song = commmand.Substring(4);
					if (queue.Contains(song))
					{
						Console.WriteLine($" {song} is already contained!");
					}
					else
					{
						queue.Enqueue(song);
					}
				}
				else if (commmand == "Show")
				{
					Console.WriteLine("{0}", string.Join(", ", queue));
				}
			}
			Console.WriteLine("No more songs!");
		}
	}
}
