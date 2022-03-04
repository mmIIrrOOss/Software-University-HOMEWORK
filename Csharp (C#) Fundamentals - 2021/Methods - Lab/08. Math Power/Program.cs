using System;

public class Example
{
	public static void Main()
	{
		decimal n = decimal.Parse(Console.ReadLine());
		decimal power = decimal.Parse(Console.ReadLine());
		Pow(n, power);
	}
	static void Pow(decimal n, decimal power)
	{
		decimal result = 1;
		decimal oldPowers = 0;
		for (int i = 0; i < power; i++)
		{
			result *= n;
			oldPowers = result;
		}
		Console.WriteLine(oldPowers);
	}


}
