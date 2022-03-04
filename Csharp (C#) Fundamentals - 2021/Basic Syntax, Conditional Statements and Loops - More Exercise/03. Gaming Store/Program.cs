using System;
using System.Linq;
class Vacation
{
	static void Main()
	{

		double budjet = double.Parse(Console.ReadLine());
		double money = budjet;
		double price = 0;
		double outFall4 = 39.99;
		double csGo = 15.99;
		double zplinterZell = 19.99;
		double honored2 = 59.99;
		double roverWatch = 29.99;
		double roveWatchEdition = 39.99;
		double spent = 0;
		string nameGame = Console.ReadLine();
		while (nameGame != "Game Time")
		{

			if (nameGame == "OutFall 4")
			{
				if (outFall4 <= budjet)
				{
					budjet -= outFall4;
					spent += outFall4;
					Console.WriteLine($"Bought {nameGame}");
				}
				else
				{
					Console.WriteLine($"Too Expensive");
				}
				if (budjet <= 0)
				{
					Console.WriteLine("Out of money!");
					return;
				}
			}
			else if (nameGame == "CS: OG")
			{
				if (csGo <= budjet)
				{
					budjet -= csGo;
					spent += csGo;
					Console.WriteLine($"Bought {nameGame}");
				}
				else
				{
					Console.WriteLine($"Too Expensive");
				}
				if (budjet <= 0)
				{
					Console.WriteLine("Out of money!");
					return;
				}
			}
			else if (nameGame == "Zplinter Zell")
			{
				if (zplinterZell <= budjet)
				{
					budjet -= zplinterZell;
					spent += zplinterZell;
					Console.WriteLine($"Bought {nameGame}");
				}
				else
				{
					Console.WriteLine($"Too Expensive");
				}
				if (budjet <= 0)
				{
					Console.WriteLine("Out of money!");
					return;
				}
			}
			else if (nameGame == "Honored 2")
			{
				if (honored2 <= budjet)
				{
					budjet -= honored2;
					spent += honored2;
					Console.WriteLine($"Bought {nameGame}");
				}
				else
				{
					Console.WriteLine($"Too Expensive");
				}
				if (budjet <= 0)
				{
					Console.WriteLine("Out of money!");
					return;
				}

			}
			else if (nameGame == "RoverWatch")
			{
				if (roverWatch <= budjet)
				{
					budjet -= roverWatch;
					spent += roverWatch;
					Console.WriteLine($"Bought {nameGame}");
				}
				else
				{
					Console.WriteLine($"Too Expensive");
				}
				if (budjet <= 0)
				{
					Console.WriteLine("Out of money!");
					return;
				}
			}
			else if (nameGame == "RoverWatch Origins Edition")
			{
				if (roveWatchEdition <= budjet)
				{
					budjet -= roveWatchEdition;
					spent += spent;
					Console.WriteLine($"Bought {nameGame}");
				}
				else
				{
					Console.WriteLine($"Too Expensive");
				}
				if (budjet <= 0)
				{
					Console.WriteLine("Out of money!");
					return;
				}
			}
			else
			{
				Console.WriteLine("Not Found");
			}
			nameGame = Console.ReadLine();
		}
		double resto = Math.Abs(spent - money);
		Console.WriteLine($"Total spent: ${spent:f2}. Remaining: ${resto:f2}");
	}
}