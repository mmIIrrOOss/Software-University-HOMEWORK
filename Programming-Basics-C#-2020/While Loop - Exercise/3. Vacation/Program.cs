using System;

namespace ConsoleApp3
{
	class Program
	{
		static void Main(string[] args)
		{

			double target = double.Parse(Console.ReadLine());
			double budhet = double.Parse(Console.ReadLine());
			int days = 0;
			int spendCounter = 0;
			bool isEnough = false;
			while (!isEnough)
			{
				string command = Console.ReadLine();
				double ammount = double.Parse(Console.ReadLine());
				days++;
				if (command == "save")
				{
					budhet += ammount;
					spendCounter = 0;
				}
				else
				{
					budhet -= ammount;
					if (budhet < 0)
					{
						budhet = 0;
					}
					spendCounter++;
					if (spendCounter >= 5)
					{
						break;
					}
				}
				if (budhet >= target)
				{
					isEnough = true;
				}
			}
			if (isEnough)
			{
				Console.WriteLine($"You saved the money for {days} days.");
			}
			else
			{
				Console.WriteLine("You can't save the money.");
				Console.WriteLine(days);
			}

		}
	}
}
