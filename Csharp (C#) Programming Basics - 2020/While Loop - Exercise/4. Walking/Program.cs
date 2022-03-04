using System;

namespace ConsoleApp3
{
	class Program
	{
		static void Main(string[] args)
		{
			int purpose = 10000;
			int steps = 0;
			int sumSteps = 0;
			string commmand = Console.ReadLine();
			while (true)
			{
				if (commmand == "Going home")
				{
					int step = int.Parse(Console.ReadLine());
					step += sumSteps;
					if (step < purpose)
					{
						Console.WriteLine($"{Math.Abs(step - purpose)} more steps to reach goal.");
						return;
					}
					else
					{
						Console.WriteLine($"Goal reached! Good job!");
						Console.WriteLine($"{Math.Abs(step - purpose)} steps over the goal!");
						return;
					}

				}
				steps = int.Parse(commmand);
				sumSteps += steps;
				if (sumSteps >= purpose)
				{
					Console.WriteLine($"Goal reached! Good job!");
					Console.WriteLine($"{sumSteps - purpose} steps over the goal!");
					return;
				}
				commmand = Console.ReadLine();


			}

		}
	}
}
