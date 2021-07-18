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
		while (number.Length != 1)
		{
			int[] newArr = new int[number.Length - 1];
			for (int i = 0; i < newArr.Length; i++)
			{
				newArr[i] = number[i] + number[i + 1];

			}

			number = newArr;
		}
		Console.WriteLine(string.Join(" ", number));


	}
}

