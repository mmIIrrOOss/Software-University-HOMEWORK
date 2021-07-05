using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel
{
	class Program
	{
		static void Main(string[] args)
		{

			double budjet = double.Parse(Console.ReadLine());
			string season = Console.ReadLine();
			string country = "";
			double totalPrice = 0;
			string placeToStay = "";
			if (budjet <= 100)
			{
				country = "Bulgaria";
				if (season == "summer")
				{
					placeToStay = "Camp";
					totalPrice = budjet - (budjet * 0.70);
				}
				else if (season == "winter")
				{
					placeToStay = "Hotel";
					totalPrice = budjet - (budjet * 0.30);
				}

			}
			else if (budjet <= 1000)
			{
				country = "Balkans";
				if (season == "summer")
				{
					placeToStay = "Camp";
					totalPrice = budjet - (budjet * 0.60);
				}
				else if (season == "winter")
				{
					placeToStay = "Hotel";
					totalPrice = budjet - (budjet * 0.20);
				}
			}
			else if (budjet >= 1000)
			{
				country = "Europe";
				placeToStay = "Hotel";

				if (season == "summer" || season == "winter")
				{
					totalPrice = budjet - (budjet * 0.10);

				}
			}
			Console.WriteLine($"Somewhere in {country}");
			Console.WriteLine($"{placeToStay} - {totalPrice:f2}");

		}
	}
}