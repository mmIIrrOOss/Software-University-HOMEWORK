using System;
using System.Linq;

public class Example
{
	public static void Main()
	{
		int[] evenNumbers = Console.ReadLine()
			.Split()
			.Select(int.Parse)
			.ToArray();
		int sumEvenNums = 0;
		for (int i = 0; i < evenNumbers.Length; i++)
		{
			int currentNum = evenNumbers[i];
			if (currentNum % 2 == 0)
			{
				sumEvenNums += currentNum;
			}
		}
		Console.WriteLine(sumEvenNums);


	}
}

