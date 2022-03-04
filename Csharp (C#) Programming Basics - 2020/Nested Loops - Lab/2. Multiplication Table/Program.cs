using System;

namespace ConsoleApp3
{
	class Program
	{
		static void Main(string[] args)
		{
			for (int hours = 1; hours <= 10; hours++)
			{
				for (int minutes = 1; minutes <= 10; minutes++)
				{
					Console.WriteLine($"{hours} * {minutes} = {hours * minutes}");
				}
			}

		}
	}
}
