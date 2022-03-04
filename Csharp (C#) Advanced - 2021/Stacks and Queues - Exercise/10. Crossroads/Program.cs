using System;
using System.Collections.Generic;

namespace _10._Crossroads
{
	class Program
	{
		static void Main(string[] args)
		{
			int second = int.Parse(Console.ReadLine());
			int freeWindow = int.Parse(Console.ReadLine());

			string command = Console.ReadLine();
			Queue<string> cars = new Queue<string>();
			int succesCount = 0;
			while (command != "END")
			{
				int greenLights = second;
				int passSeconds = freeWindow;
				if (command == "green")
				{

					while (cars.Count != 0 && greenLights > 0)
					{
						string car = cars.Dequeue();
						greenLights -= car.Length;
						if (greenLights >= 0)
						{
							succesCount++;
						}
						else
						{
							passSeconds += greenLights;
							if (passSeconds < 0)
							{
								Console.WriteLine($"A crash happened!");
								Console.WriteLine($"{car} was hit at {car[car.Length + passSeconds]}.");
								return;
							}
							succesCount++;
						}
					}
				}
				else
				{
					cars.Enqueue(command);
				}
				command = Console.ReadLine();

			}
			Console.WriteLine($"Everyone is safe.");
			Console.WriteLine($"{succesCount} total cars passed the crossroads.");
		}
	}
}
