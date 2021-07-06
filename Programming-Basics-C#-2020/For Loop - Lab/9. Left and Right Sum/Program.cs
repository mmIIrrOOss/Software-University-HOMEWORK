using System;

namespace ConsoleApp3
{
	class Program
	{
		static void Main(string[] args)
		{
			int num = int.Parse(Console.ReadLine());
			int leftSum = 0;//90+
			int rightSum = 0;
			for (int i = 0; i < 2 * num; i++)
			{
				int number = int.Parse(Console.ReadLine());//90 10 60
				if (i < num)
				{
					leftSum += number;//90
				}
				else
				{
					rightSum += number;//10+
				}
			}
			if (leftSum == rightSum)
			{
				Console.WriteLine($"Yes, sum = {leftSum}");
			}
			else
			{
				Console.WriteLine($"No, diff = {Math.Abs(leftSum - rightSum)}");
			}
		}
	}
}
