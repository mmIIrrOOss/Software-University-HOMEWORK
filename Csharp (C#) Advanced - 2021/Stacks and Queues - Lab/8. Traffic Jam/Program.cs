using System;
using System.Collections.Generic;
namespace _8._Traffic_Jam
{
	class Program
	{
		static void Main(string[] args)
		{
			int greenCount = int.Parse(Console.ReadLine());
			Queue<string> cars = new Queue<string>();
			int count = 0;
			while (true)
			{
				string command = Console.ReadLine();
				if (command.Contains("end"))
				{
					break;
				}
				else if (command.Contains("green"))
				{
					for (int i = 0; i < greenCount; i++)
					{
						if (cars.Count==0)
						{
							break;
						}
						count++;
						Console.WriteLine($"{cars.Dequeue()} passed!");
					}
				}
				else
				{
					cars.Enqueue(command);
				}
			}
			Console.WriteLine($"{count} cars passed the crossroads.");
		}
	}
}
