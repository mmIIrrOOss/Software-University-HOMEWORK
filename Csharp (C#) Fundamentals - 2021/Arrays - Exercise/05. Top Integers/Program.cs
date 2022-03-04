using System;
using System.Linq;

public class Example
{
	public static void Main()
	{
		int[] array = Console.ReadLine()
			.Split()
			.Select(int.Parse)
			.ToArray();

		for (int i = 0; i < array.Length; i++)
		{
			bool isTopInteger = true;
			for (int j = i + 1; j < array.Length; j++)
			{

				if (array[i] <= array[j])
				{
					isTopInteger = false;
					break;
				}

			}
			if (isTopInteger)
			{
				Console.Write(array[i] + " ");
			}
		}


	}
}

