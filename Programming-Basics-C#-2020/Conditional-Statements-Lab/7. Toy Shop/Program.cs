using System;

namespace ToyShop
{
	class Program
	{
		static void Main(string[] args)
		{

			double priceOfHoliday = double.Parse(Console.ReadLine());
			int numberOfPuzzels = int.Parse(Console.ReadLine());
			int talkingDoll = int.Parse(Console.ReadLine());
			int reddyBears = int.Parse(Console.ReadLine());
			int minions = int.Parse(Console.ReadLine());
			int trucks = int.Parse(Console.ReadLine());

			double totalPrice = numberOfPuzzels * 2.60 + talkingDoll * 3 + reddyBears * 4.10 + minions * 8.20 + trucks * 2;

			int sumToys = numberOfPuzzels + talkingDoll + reddyBears + minions + trucks;


			if (sumToys >= 50)
			{
				totalPrice -= totalPrice * 0.25;

			}
			totalPrice -= totalPrice * 0.10;

			if (totalPrice >= priceOfHoliday)
			{
				Console.WriteLine($"Yes! {totalPrice - priceOfHoliday:f2} lv left.");
			}
			else
			{
				Console.WriteLine($"Not enough money! { priceOfHoliday - totalPrice:f2} lv needed. ");
			}


		}
	}
}
