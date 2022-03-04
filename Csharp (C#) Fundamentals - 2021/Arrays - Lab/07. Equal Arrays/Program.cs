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
		int[] secondNumber = Console.ReadLine()
			.Split()
			.Select(int.Parse)
			.ToArray();
		int sumTwoArrays = 0;
		int count = 0;
		bool isValid = true;
		for (int i = 0; i < number.Length; i++)
		{
			if (number[i] == secondNumber[i])
			{
				sumTwoArrays += secondNumber[i];
			}
			else
			{
				count += i;
				isValid = false;
				break;
			}
		}
		if (isValid)
		{
			Console.WriteLine($"Arrays are identical. Sum: {sumTwoArrays}");
		}
		else
		{
			Console.WriteLine($"Arrays are not identical. Found difference at {count} index");
		}



	}
}

