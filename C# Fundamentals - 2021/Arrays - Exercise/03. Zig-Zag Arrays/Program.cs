using System;
using System.Linq;

public class Example
{
	public static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		int[] arr1 = new int[n];
		int[] arr2 = new int[n];
		for (int i = 0; i < n; i++)
		{
			int[] currentLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
			if (i % 2 == 0)
			{
				arr1[i] = currentLine[0];
				arr2[i] = currentLine[1];
			}
			else
			{
				arr1[i] = currentLine[1];
				arr2[i] = currentLine[0];
			}

		}
		Console.WriteLine(string.Join(' ', arr1));
		Console.WriteLine(string.Join(' ', arr2));



	}
}

