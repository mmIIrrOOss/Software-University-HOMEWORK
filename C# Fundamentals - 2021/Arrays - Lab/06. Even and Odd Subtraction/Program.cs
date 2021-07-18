using System;
using System.Linq;

public class Example
{
	public static void Main()
	{
		int[] number = Console.ReadLine()
			.Split()
			.Select(int.Parse)
			.ToArray();
		int evenSum = 0;
		int oddSum = 0;
		for (int i = 0; i < number.Length; i++)
		{
			int currentNum = number[i];
			if (currentNum % 2 == 0)
			{
				evenSum += currentNum;
			}
			else
			{
				oddSum += currentNum;
			}
		}
		int diff = evenSum - oddSum;
		Console.WriteLine($"{diff}");


	}
}

