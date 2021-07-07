using System;

namespace ConsoleApp3
{
	class Program
	{
		static void Main(string[] args)
		{
			decimal num = decimal.Parse(Console.ReadLine());
			decimal p1count = 0;
			decimal p2Count = 0;
			decimal p3Count = 0;
			for (int i = 1; i <= num; i++)
			{

				double number = double.Parse(Console.ReadLine());
				if (number % 2 == 0)
				{
					p1count++;
				}
				if (number % 3 == 0)
				{
					p2Count++;
				}
				if (number % 4 == 0)
				{
					p3Count++;
				}

			}
			p1count = p1count / num;
			p1count *= 100;
			p2Count = p2Count / num;
			p2Count *= 100;
			p3Count = p3Count / num;
			p3Count *= 100;
			Console.WriteLine($"{p1count:f2}%");
			Console.WriteLine($"{p2Count:f2}%");
			Console.WriteLine($"{p3Count:f2}%");
		}
	}
}
