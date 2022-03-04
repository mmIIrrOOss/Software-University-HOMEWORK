using System;

namespace ConsoleApp3
{
	class Program
	{
		static void Main(string[] args)
		{
			int height = int.Parse(Console.ReadLine());
			int lenght = int.Parse(Console.ReadLine());
			int size = height * lenght;
			int sumCakes = 0;
			string command = Console.ReadLine();
			while (command != "STOP")
			{
				int cakes = int.Parse(command);
				sumCakes += cakes;
				if (sumCakes >= size)
				{
					Console.WriteLine($"No more cake left! You need {Math.Abs(sumCakes - size)} pieces more.");
					return;
				}
				command = Console.ReadLine();
			}
			Console.WriteLine($"{Math.Abs(sumCakes - size)} pieces are left.");

		}
	}
}
