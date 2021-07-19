using System;
using System.Linq;

public class Example
{
	public static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		string input = Console.ReadLine();

		int bestLenght = 1;
		int bestStartIndex = 0;
		int bestSquenceSum = 0;
		int bestSquenceIndex = 0;
		int[] bestSquence = new int[n];
		int squenceCounter = 0;
		while (input != "Clone them!")
		{
			int[] currentSequence = input.Split('!'
				, StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();
			squenceCounter++;

			int lenght = 1;
			int bestCurrentLenght = 1;
			int startIndex = 0;
			int curentSquenceSum = 0;
			for (int i = 0; i < currentSequence.Length - 1; i++)
			{
				if (currentSequence[i] == currentSequence[i + 1])
				{
					lenght++;
				}
				else
				{
					lenght = 1;
				}
				if (lenght > bestCurrentLenght)
				{
					bestCurrentLenght = lenght;
					startIndex = i;
				}
				curentSquenceSum += currentSequence[i];

			}
			curentSquenceSum += currentSequence[n - 1];
			if (bestCurrentLenght > bestLenght)
			{
				bestLenght = bestCurrentLenght;
				bestStartIndex = startIndex;
				bestSquenceSum = curentSquenceSum;
				bestSquenceIndex = squenceCounter;
				bestSquence = currentSequence.ToArray();
			}
			else if (bestCurrentLenght == bestLenght)
			{
				if (startIndex < bestStartIndex)
				{
					bestLenght = bestCurrentLenght;
					bestStartIndex = startIndex;
					bestSquenceSum = curentSquenceSum;
					bestSquenceIndex = squenceCounter;
					bestSquence = currentSequence.ToArray();

				}
				else if (startIndex == bestStartIndex)
				{
					if (curentSquenceSum > bestSquenceSum)
					{
						bestLenght = bestCurrentLenght;
						bestStartIndex = startIndex;
						bestSquenceSum = curentSquenceSum;
						bestSquenceIndex = squenceCounter;
						bestSquence = currentSequence.ToArray();

					}
				}
			}

			input = Console.ReadLine();
		}

		Console.WriteLine($"Best DNA sample {bestSquenceIndex} with sum: {bestSquenceSum}.");
		Console.WriteLine($"{string.Join(" ", bestSquence)}");

	}
}

