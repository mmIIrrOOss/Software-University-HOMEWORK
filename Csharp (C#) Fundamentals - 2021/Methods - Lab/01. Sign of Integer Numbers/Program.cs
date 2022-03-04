using System;
using System.Linq;

public class Example
{
	
	public static void Main()
	{
		Sign(int.Parse(Console.ReadLine()));
	}
	static void Sign(int number)
	{
		if (number > 0)
		{
			Console.WriteLine($"The number {number} is positive.");
		}
		else if (number < 0)
		{
			Console.WriteLine($"The number {number} is negative.");
		}
		else
		{
			Console.WriteLine($"The number {number} is zero.");
		}
	}
}

