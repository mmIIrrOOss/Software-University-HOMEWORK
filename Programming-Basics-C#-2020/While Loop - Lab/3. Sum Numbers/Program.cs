using System;

namespace ConsoleApp3
{
	class Program
	{
		static void Main(string[] args)
		{
			double num = double.Parse(Console.ReadLine());
			double sum = 0;
			while (sum < num)
			{
				double number = double.Parse(Console.ReadLine());
				sum += number;
			}
			Console.WriteLine(sum);


		}
	}
}
