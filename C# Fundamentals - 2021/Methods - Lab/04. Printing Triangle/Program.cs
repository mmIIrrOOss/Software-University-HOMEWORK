using System;
using System.Linq;

public class Example
{
	public static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		for (int row = 1; row <= n; row++)
		{
			PrintLine(row);
		}
		for (int row = n - 1; row >= 1; row--)
		{
			PrintLine(row);
		}
	}
	static void PrintLine(int row)
	{
		for (int colon = 1; colon <= row; colon++)
		{
			Console.Write(colon + " ");
		}
		Console.WriteLine();
	}

}

