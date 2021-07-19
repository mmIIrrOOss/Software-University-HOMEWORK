using System;
using System.Linq;

public class Example
{
	public static void Main()
	{
		string[] firstElement = Console.ReadLine().Split();
		string[] secondElement = Console.ReadLine().Split();
		for (int i = 0; i < secondElement.Length; i++)
		{
			for (int j = 0; j < firstElement.Length; j++)
			{
				if (secondElement[i] == firstElement[j])
				{
					Console.Write(secondElement[i] + " ");
				}
			}
		}


	}
}

