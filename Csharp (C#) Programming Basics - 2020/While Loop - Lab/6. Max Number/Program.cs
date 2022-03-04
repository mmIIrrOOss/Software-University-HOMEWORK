using System;

namespace ConsoleApp3
{
	class Program
	{
		static void Main(string[] args)
		{
			string command = Console.ReadLine();
			int maxValue = int.MinValue;
			while (command != "Stop")
			{
				int number = int.Parse(command);
				if (number > maxValue)
				{
					maxValue = number;
				}
				command = Console.ReadLine();

			}
			Console.WriteLine(maxValue);

		}
	}
}
