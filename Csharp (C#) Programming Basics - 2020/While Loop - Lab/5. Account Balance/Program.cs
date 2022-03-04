using System;

namespace ConsoleApp3
{
	class Program
	{
		static void Main(string[] args)
		{
			string command = Console.ReadLine();
			double sumIncrease = 0;
			while (command != "NoMoreMoney")
			{

				double increase = double.Parse(command);
				if (increase < 0)
				{
					Console.WriteLine("Invalid operation!");
					break;
				}
				sumIncrease += increase;
				Console.WriteLine($"Increase: {increase:f2}");
				command = Console.ReadLine();

			}
			Console.WriteLine($"Total: {sumIncrease:f2}");

		}
	}
}
