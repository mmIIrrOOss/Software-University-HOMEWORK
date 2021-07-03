using System;

namespace _8._Scholarship
{
	class Program
	{
		static void Main(string[] args)
		{
			double income = double.Parse(Console.ReadLine());
			double averageGrade = double.Parse(Console.ReadLine());
			double salary = double.Parse(Console.ReadLine());
			double socialStipend = Math.Floor(salary * 0.35);
			double excilentStipend = Math.Floor(averageGrade * 25);
			if (income < salary && averageGrade > 4.50)
			{
				if (averageGrade > 5.50 && income < salary)
				{
					if (excilentStipend > socialStipend)
					{
						Console.WriteLine($"You get a scholarship for excellent results {excilentStipend} BGN");
					}
					else if (socialStipend > excilentStipend)
					{
						Console.WriteLine($"You get a Social scholarship {socialStipend} BGN");
					}
					else
					{
						Console.WriteLine($"You get a scholarship for excellent results {excilentStipend} BGN");

					}
				}
				else
				{

					Console.WriteLine($"You get a Social scholarship {socialStipend} BGN");
				}

			}
			else if (averageGrade >= 5.50)
			{
				Console.WriteLine($"You get a scholarship for excellent results {excilentStipend} BGN");

			}
			else
			{
				Console.WriteLine("You cannot get a scholarship!");
			}

		}
	}
}
