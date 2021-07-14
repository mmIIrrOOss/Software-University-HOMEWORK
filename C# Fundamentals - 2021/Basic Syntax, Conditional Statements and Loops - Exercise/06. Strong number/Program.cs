using System;
using System.Linq;
class Vacation
{
	static void Main()
	{
		int number = int.Parse(Console.ReadLine());
		int orginNum = number;
		int sum = 0;
		while (number > 0)
		{
			int lastDigit = number % 10;
			int factoriel = 1;
			for (int i = 1; i <= lastDigit; i++)
			{
				factoriel *= i;
			}
			sum += factoriel;
			number /= 10;

		}
		if (orginNum == sum)
		{
			Console.WriteLine("yes");
		}
		else
		{
			Console.WriteLine("no");
		}
	}
}