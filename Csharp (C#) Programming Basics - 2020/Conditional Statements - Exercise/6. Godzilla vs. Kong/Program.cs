using System;

namespace GodzilavsKingKong
{
	class Program
	{
		static void Main(string[] args)
		{

			double butget = double.Parse(Console.ReadLine());
			int numberOfStatist = int.Parse(Console.ReadLine());
			double priceClothing = double.Parse(Console.ReadLine());
			double totalPriceOfClothing = numberOfStatist * priceClothing;
			butget -= butget * 0.10;

			if (numberOfStatist > 150)
			{
				totalPriceOfClothing -= totalPriceOfClothing * 0.10;
			}
			butget -= totalPriceOfClothing;

			if (butget >= 0)
			{
				Console.WriteLine($"Action!");
				Console.WriteLine($"Wingard starts filming with {butget:f2} leva left.");
			}
			else
			{
				Console.WriteLine($"Not enough money!");
				Console.WriteLine($"Wingard needs {Math.Abs(butget):f2} leva more.");
			}


		}
	}
}
