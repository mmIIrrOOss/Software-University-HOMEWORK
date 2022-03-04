using System;
using System.Linq;
public class Example
{
	public static void Main()
	{
		decimal price = 0;
		string productName = Console.ReadLine();
		decimal quantity = decimal.Parse(Console.ReadLine());
		 ChekProduct(productName, price, quantity);
	}
	static void ChekProduct(string productName, decimal price, decimal quantity)
	{
		if (productName == "coffee")
		{
			price = 1.50m;
		}
		else if (productName == "water")
		{
			price = 1m;
		}
		else if (productName == "coke")
		{
			price = 1.40m;
		}
		else if (productName == "snacks")
		{
			price = 2m;
		}
		decimal sum = quantity * price;
		Console.WriteLine($"{sum:f2}");
	}


}
