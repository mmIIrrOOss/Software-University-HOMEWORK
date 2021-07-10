using System;

namespace ConsoleApp3
{
	class Program
	{
		static void Main(string[] args)
		{
			int start = int.Parse(Console.ReadLine());
			int end = int.Parse(Console.ReadLine());
			int magicNum = int.Parse(Console.ReadLine());
			int countCombination = 0;
			bool isFound = false;
			int sum = 0;
			for (int i = start; i <= end; i++)
			{
				for (int j = start; j <= end; j++)
				{
					countCombination++;
					sum = i + j;
					if (sum == magicNum)
					{
						isFound = true;
						Console.WriteLine($"Combination N:{countCombination} ({i} + {j} = {magicNum})");
						return;
					}

				}
			}
			if (!isFound)
			{
				Console.WriteLine($"{countCombination} combinations - neither equals {magicNum}");

			}


		}
	}
}
