using System;
using System.Collections.Generic;
using System.Linq;
namespace _02._Average_Student_Grades
{
	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, List<double>> studentInfo = new Dictionary<string, List<double>>();
			int lines = int.Parse(Console.ReadLine());
			for (int i = 0; i < lines; i++)
			{
				string[] student = Console.ReadLine().Split();
				string name = student[0];
				double grade = double.Parse(student[1]);
				if (!studentInfo.ContainsKey(name))
				{
					studentInfo.Add(name, new List<double>());
					studentInfo[name].Add(grade);
					continue;
				}
				studentInfo[name].Add(grade);
			}
			foreach (var student in studentInfo)
			{
				Console.WriteLine($"{student.Key} -> {string.Join(" ",student.Value)} (avg: {student.Value.Average()})");
			}
		}
	}
}
