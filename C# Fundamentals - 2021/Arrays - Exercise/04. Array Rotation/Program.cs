using System;
using System.Linq;

public class Example
{
	public static void Main()
	{
		int[] arrNum = Console.ReadLine()
			.Split()
			.Select(int.Parse)
			.ToArray();
		int n = int.Parse(Console.ReadLine());
		for (int i = 0; i < n; i++)
		{
			int firstElement = arrNum[0];
			int[] temp = new int[arrNum.Length];
			for (int j = 1; j < arrNum.Length; j++)
			{
				temp[j - 1] = arrNum[j];
			}
			temp[temp.Length - 1] = firstElement;
			arrNum = temp;
		}
		Console.WriteLine(string.Join(" ", arrNum));



	}
}

