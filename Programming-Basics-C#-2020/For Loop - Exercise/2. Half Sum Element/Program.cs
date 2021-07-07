using System;

namespace app1
{
	class Program
	{
		static void Main(string[] args)
		{
			int countOfNumber = int.Parse(Console.ReadLine());
			int sum = 0;
			int max = int.MinValue;
			for (int i = 1; i <= countOfNumber; i++)
			{
				int num = int.Parse(Console.ReadLine());
				sum += num;
				if (num > max)
				{
					max = num;
				}
			}
			int sumWithouthMaxNumebr = sum - max;
			if (max == sumWithouthMaxNumebr)
			{
				Console.WriteLine($"Yes");
				Console.WriteLine($"Sum = {max}");

			}
			else
			{
				int diff = Math.Abs(max - sumWithouthMaxNumebr);
				Console.WriteLine($"No");
				Console.WriteLine($"Diff = {diff}");
			}



		}
	}
}