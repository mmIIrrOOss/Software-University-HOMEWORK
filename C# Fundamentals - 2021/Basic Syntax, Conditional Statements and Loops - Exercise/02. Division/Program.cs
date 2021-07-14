using System;

class HolidaysBetweenTwoDates
{
	static void Main()
	{
		int num = int.Parse(Console.ReadLine());
		int ten = 10;
		int seven = 7;
		int six = 6;
		int tree = 3;
		int two = 2;
		if (num % ten == 0)
		{
			Console.WriteLine($"The number is divisible by {ten}");

		}
		else if (num % seven == 0)
		{
			Console.WriteLine($"The number is divisible by {seven}");


		}
		else if (num % six == 0)
		{
			Console.WriteLine($"The number is divisible by {six}");


		}
		else if (num % tree == 0)
		{
			Console.WriteLine($"The number is divisible by {tree}");


		}
		else if (num % two == 0)
		{
			Console.WriteLine($"The number is divisible by {two}");


		}
		else
		{
			Console.WriteLine("Not divisible");
		}
	}
}