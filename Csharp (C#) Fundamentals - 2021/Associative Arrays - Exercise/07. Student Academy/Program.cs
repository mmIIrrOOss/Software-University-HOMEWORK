using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Student_Academy
{
	class Program
	{
		static void Main(string[] args)
		{
			SortedDictionary<string, double> saveStudentsGrades = new SortedDictionary<string, double>();
			int n = int.Parse(Console.ReadLine());
			double averageStudent = 0;
			for (int i = 0; i < n; i++)
			{
				string studentName = Console.ReadLine();
				double grades = double.Parse(Console.ReadLine()); ;
				if (!saveStudentsGrades.ContainsKey(studentName)&&saveStudentsGrades.Values.Average()>=4.50)
				{
					saveStudentsGrades.Add(studentName, grades);
					
				}
			}
		}
	}
}
