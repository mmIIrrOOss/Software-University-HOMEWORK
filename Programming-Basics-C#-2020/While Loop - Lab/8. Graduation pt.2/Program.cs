using System;

namespace ConsoleApp3
{
	class Program
	{
		static void Main(string[] args)
		{
			string name = Console.ReadLine();
			int classs = 1;
			int excluded = 0;
			double gradeSum = 0;
			while (classs <= 12)
			{

				double score = double.Parse(Console.ReadLine());
				if (score < 4)
				{
					excluded++;
					if (excluded < 2)
					{
						continue;

					}
					Console.WriteLine($"{name} has been excluded at {classs} grade");
					return;
				}
				gradeSum += score;
				classs++;
			}
			double averageScore = gradeSum / (classs - 1);
			Console.WriteLine($"{name} graduated. Average grade: {averageScore:f2}");
		}
	}
}
