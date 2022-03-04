using System;
using System.Linq;

public class Example
{
	public static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		int[] sumN = new int[n];
		for (int i = 0; i < n; i++)
		{
			int numbers = int.Parse(Console.ReadLine());
			sumN[i] = numbers;
		}
		for (int i = sumN.Length - 1; i >= 0; i--)
		{
			Console.Write(sumN[i] + " ");
		}

	}
}

