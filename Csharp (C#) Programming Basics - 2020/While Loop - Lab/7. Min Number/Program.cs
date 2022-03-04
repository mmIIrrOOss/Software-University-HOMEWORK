using System;

namespace ConsoleApp3
{
	class Program
	{
		static void Main(string[] args)
		{
			string command = Console.ReadLine();
			int minValue = int.MaxValue;
			while (command != "Stop")
			{
				int number = int.Parse(command);
				if (number < minValue)
				{
					minValue = number;
				}
				command = Console.ReadLine();

			}
			Console.WriteLine(minValue);

		}
	}
}
