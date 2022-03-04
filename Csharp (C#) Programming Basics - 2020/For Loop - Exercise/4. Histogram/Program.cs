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
			decimal p4Count = 0;
			decimal p5Count = 0;
			for (int i = 1; i <= num; i++)
			{

				double number = double.Parse(Console.ReadLine());
				if (number < 200)
				{
					p1count++;
				}
				else if (number >= 200 && number < 400)
				{
					p2Count++;
				}
				else if (number >= 400 && number < 600)
				{
					p3Count++;
				}
				else if (number >= 600 && number < 800)
				{
					p4Count++;
				}
				else if (number >= 800)
				{
					p5Count++;
				}

			}
			p1count = p1count / num;
			p1count *= 100;
			p2Count = p2Count / num;
			p2Count *= 100;
			p3Count = p3Count / num;
			p3Count *= 100;
			p4Count = p4Count / num;
			p4Count *= 100;
			p5Count = p5Count / num;
			p5Count *= 100;
			Console.WriteLine($"{p1count:f2}%");
			Console.WriteLine($"{p2Count:f2}%");
			Console.WriteLine($"{p3Count:f2}%");
			Console.WriteLine($"{p4Count:f2}%");
			Console.WriteLine($"{p5Count:f2}%");


		}
	}
}
