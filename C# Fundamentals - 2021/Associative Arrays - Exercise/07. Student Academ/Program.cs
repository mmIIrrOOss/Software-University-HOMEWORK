using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Student_Academy
{
	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, List<double>> saveStudentsGrades = new Dictionary<string, List<double>>();
			Dictionary<string, List<double>> sorted = new Dictionary<string, List<double>>();
			int n = int.Parse(Console.ReadLine());
			for (int i = 0; i < n; i++)
			{
				string studentName = Console.ReadLine();
				double grades = double.Parse(Console.ReadLine());
				if (!saveStudentsGrades.ContainsKey(studentName))
				{
					saveStudentsGrades.Add(studentName, new List<double>());
					saveStudentsGrades[studentName].Add(grades);
					continue;
				}
				saveStudentsGrades[studentName].Add(grades);
			}

			foreach (var item in saveStudentsGrades)
			{


				if (item.Value.Average() >= 4.50)
				{
					continue;
				}
				saveStudentsGrades.Remove(item.Key);
			}

			double endGrades = 0;
			foreach (var item in saveStudentsGrades.OrderByDescending(x=>x.Value.Average()))
			{
				endGrades = item.Value.Average();
				Console.WriteLine($"{item.Key} -> {endGrades:f2}");
			}
		}
	}
}
