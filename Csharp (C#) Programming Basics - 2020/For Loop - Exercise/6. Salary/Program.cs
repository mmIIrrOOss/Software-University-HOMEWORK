using System;

namespace app1
{
	class Program
	{
		static void Main(string[] args)

		{
			int webTabs = int.Parse(Console.ReadLine());
			int salary = int.Parse(Console.ReadLine());
			bool isSalary = salary <= 0;
			for (int i = 0; i < webTabs; i++)
			{
				string sitess = Console.ReadLine();
				if (sitess == "Facebook")
				{
					salary -= 150;
				}
				if (sitess == "Instagram")
				{
					salary -= 100;
				}
				if (sitess == "Reddit")
				{
					salary -= 50;
				}
				if (salary <= 0)
				{
					break;
				}
			}
			if (salary > 0)
			{
				Console.WriteLine($"{salary}");
			}
			else
			{
				Console.WriteLine($"You have lost your salary.");
			}


		}
	}
}