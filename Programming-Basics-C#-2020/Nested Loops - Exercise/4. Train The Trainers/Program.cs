using System;


namespace NestedLoopsLab
{
	class Program
	{
		static void Main(string[] args)
		{

			double numPeople = double.Parse(Console.ReadLine());
			double scoreSum = 0;
			double averageGradesOldSum = 0;
			string namePresentacion = Console.ReadLine();
			double countNumGrades = 0;
			while (namePresentacion != "Finish")
			{
				for (int j = 1; j <= numPeople; j++)
				{
					double grade = double.Parse(Console.ReadLine());
					scoreSum += grade;
					countNumGrades++;

				}
				averageGradesOldSum += scoreSum;
				scoreSum /= numPeople;
				Console.WriteLine($"{namePresentacion} - {scoreSum:f2}.");
				scoreSum = 0;
				namePresentacion = Console.ReadLine();

			}
			Console.WriteLine($"Student's final assessment is {averageGradesOldSum / countNumGrades:f2}.");

		}
	}
}
