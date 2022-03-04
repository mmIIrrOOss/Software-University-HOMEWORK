using System;

namespace app1
{
	class Program
	{
		static void Main(string[] args)
		{
			int countOfNumber = int.Parse(Console.ReadLine());
			int evenSum = 0;
			int oddSum = 0;
			for (int i = 0; i < countOfNumber; i++)
			{
				int currentNumber = int.Parse(Console.ReadLine());
				if (i % 2 == 0)
				{
					evenSum += currentNumber;
				}
				else
				{
					oddSum += currentNumber;
				}
			}
			if (oddSum == evenSum)
			{
				Console.WriteLine($"Yes");
				Console.WriteLine($"Sum = {evenSum}");
			}
			else
			{
				Console.WriteLine($"No");
				Console.WriteLine($"Diff = {Math.Abs(oddSum - evenSum)}");
			}
		}
	}
}