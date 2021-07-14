using System;
using System.Linq;
class Vacation
{
	static void Main()
	{
		string start = Console.ReadLine();
		double wallet = 0;
		while (start != "Start")
		{
			double inputMoney = double.Parse(start);
			if (inputMoney == 0.10)
			{
				wallet += inputMoney;
			}
			else if (inputMoney == 0.20)
			{
				wallet += inputMoney;
			}
			else if (inputMoney == 0.50)
			{
				wallet += inputMoney;
			}
			else if (inputMoney == 1)
			{
				wallet += inputMoney;
			}
			else if (inputMoney == 2)
			{
				wallet += inputMoney;
			}
			else
			{
				Console.WriteLine($"Cannot accept {inputMoney}");
			}
			start = Console.ReadLine();

		}
		string nameProduxt = Console.ReadLine();
		double price = 0;
		double coke = 1;
		double soda = 0.80;
		double nuts = 2;
		double crisps = 1.50;
		double water = 0.70;
		while (nameProduxt != "End")
		{

			if (nameProduxt == "Nuts")
			{
				if (wallet >= nuts)
				{
					price = 2;
					wallet -= price;
					Console.WriteLine($"Purchased {nameProduxt.ToLower()}");
				}
				else
				{
					Console.WriteLine($"Sorry, not enough money");
				}
			}
			else if (nameProduxt == "Water")
			{
				if (wallet >= water)
				{
					price = 0.70;
					wallet -= price;
					Console.WriteLine($"Purchased {nameProduxt.ToLower()}");
				}
				else
				{
					Console.WriteLine($"Sorry, not enough money");
				}
			}
			else if (nameProduxt == "Crisps")
			{
				if (wallet >= crisps)
				{
					price = 1.50;
					wallet -= price;
					Console.WriteLine($"Purchased {nameProduxt.ToLower()}");
				}
				else
				{
					Console.WriteLine($"Sorry, not enough money");
				}

			}
			else if (nameProduxt == "Soda")
			{
				if (wallet >= soda)
				{
					price = 0.80;
					wallet -= price;
					Console.WriteLine($"Purchased {nameProduxt.ToLower()}");
				}
				else
				{
					Console.WriteLine($"Sorry, not enough money");
				}
			}
			else if (nameProduxt == "Coke")
			{
				if (wallet >= coke)
				{
					price = 1;
					wallet -= price;
					Console.WriteLine($"Purchased {nameProduxt.ToLower()}");
				}
				else
				{
					Console.WriteLine($"Sorry, not enough money");
				}
			}
			else
			{
				Console.WriteLine($"Invalid product");
			}
			nameProduxt = Console.ReadLine();
		}
		Console.WriteLine($"Change: {wallet:f2}");
	}
}