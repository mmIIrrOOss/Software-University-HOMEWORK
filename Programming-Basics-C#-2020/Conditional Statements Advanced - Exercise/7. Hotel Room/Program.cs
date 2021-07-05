using System;

namespace app1
{
	class Program
	{
		static void Main(string[] args)

		{

			string mounth = Console.ReadLine();

			int numDays = int.Parse(Console.ReadLine());


			double studios = 0;
			double apartment = 0;
			if (mounth == "May" || mounth == "October")
			{
				studios = 50;
				apartment = 65;
				if (numDays > 14)
				{
					studios = studios - (studios * 0.30);
				}
				else if (numDays > 7)
				{
					studios = studios - (studios * 0.05);
				}
				if (numDays > 14)
				{
					apartment = apartment - (apartment * 0.10);
				}
				studios *= numDays;
				apartment *= numDays;
			}
			else if (mounth == "June" || mounth == "September")
			{
				studios = 75.20;
				apartment = 68.70;
				if (numDays > 14)
				{
					studios = studios - (studios * 0.20);
				}
				if (numDays > 14)
				{
					apartment = apartment - (apartment * 0.10);
				}
				studios *= numDays;
				apartment *= numDays;
			}
			else if (mounth == "July" || mounth == "August")
			{
				studios = 76;
				apartment = 77;

				if (numDays > 14)
				{
					apartment = apartment - (apartment * 0.10);
				}
				studios *= numDays;
				apartment *= numDays;

			}
			Console.WriteLine($"Apartment: {apartment:f2} lv.");
			Console.WriteLine($"Studio: {studios:f2} lv.");


		}
	}
}