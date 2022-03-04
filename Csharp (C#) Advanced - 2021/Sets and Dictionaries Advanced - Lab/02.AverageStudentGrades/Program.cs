using System;
using System.Collections.Generic;
using System.Linq;
namespace _02._Average_Student_Grades
{
	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, List<decimal>> studentInfo = new Dictionary<string, List<decimal>>();
			int lines = int.Parse(Console.ReadLine());
			for (int i = 0; i < lines; i++)
			{
				string[] student = Console.ReadLine().Split();
				string name = student[0];
				decimal grades =Math.Abs(Math.Round(decimal.Parse(student[1]), 2));
				if (!studentInfo.ContainsKey(name))
				{
					studentInfo.Add(name, new List<decimal>());
				}
				studentInfo[name].Add(grades);
			}
			foreach (var student in studentInfo)
			{
				Console.WriteLine($"{student.Key} -> {string.Join(" ",student.Value)} (avg: {student.Value.Average():f2})");
			}
		}
	}
}
