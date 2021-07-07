using System;

namespace ConsoleApp3
{
	class Program
	{
		static void Main(string[] args)
		{
			double num = double.Parse(Console.ReadLine());//6
			double oddSum = 0;
			double oddMax = int.MinValue;
			double oddMin = int.MaxValue;
			double evenSum = 0;
			double evenMax = double.MinValue;
			double evenMin = double.MaxValue;
			for (int i = 1; i <= num; i++)
			{
				double number = double.Parse(Console.ReadLine());//2
				if (i % 2 == 0)
				{
					evenSum += number;
					if (number > evenMax)
					{
						evenMax = number;
					}
					if (evenMin > number)
					{
						evenMin = number;
					}
				}
				else
				{
					oddSum += number;
					if (oddMax < number)
					{
						oddMax = number;
					}
					if (oddMin > number)
					{
						oddMin = number;
					}
				}
			}
			Console.WriteLine($"OddSum={oddSum:f2},");
			if (oddSum == 0)
			{
				Console.WriteLine($"OddMin=No,");
				Console.WriteLine($"OddMax=No,");
			}
			else
			{
				Console.WriteLine($"OddMin={oddMin:f2},");
				Console.WriteLine($"OddMax={oddMax:f2},");
			}
			Console.WriteLine($"EvenSum={evenSum:f2},");
			if (evenSum == 0)
			{
				Console.WriteLine($"EvenMin=No,");
				Console.WriteLine($"EvenMax=No");
			}
			else
			{
				Console.WriteLine($"EvenMin={evenMin:f2},");
				Console.WriteLine($"EvenMax={evenMax:f2}");
			}


		}
	}
}
