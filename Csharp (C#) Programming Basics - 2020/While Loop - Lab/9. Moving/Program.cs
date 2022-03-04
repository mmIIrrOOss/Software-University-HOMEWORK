using System;

namespace ConsoleApp3
{
	class Program
	{
		static void Main(string[] args)
		{
			int width = int.Parse(Console.ReadLine());
			int lenght = int.Parse(Console.ReadLine());
			int height = int.Parse(Console.ReadLine());
			int volume = width * lenght * height;
			int sumBoxes = 0;
			string command = Console.ReadLine();
			while (command != "Done")
			{
				int boxes = int.Parse(command);
				sumBoxes += boxes;
				int ocupiedSpace = volume - sumBoxes;
				if (volume < sumBoxes)
				{
					Console.WriteLine($"No more free space! You need {Math.Abs(ocupiedSpace)} Cubic meters more.");
					return;
				}
				command = Console.ReadLine();
			}
			Console.WriteLine($"{volume - sumBoxes} Cubic meters left.");
		}
	}
}
