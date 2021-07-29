using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
	class Students
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public double Grades { get; set; }
		public Students(string firstName, string lastName, double grade)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Grades = grade;
		}
		public double getGrade()
		{
			return this.Grades;
		}

		public override string ToString()
		{
			return string.Format(this.FirstName, this.LastName, this.Grades);
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			int numberStudents = int.Parse(Console.ReadLine());
			List<Students> lisStudents = new List<Students>();
			for (int i = 1; i <= numberStudents; i++)
			{
				string[] student = Console.ReadLine().Split();
				string firstName = student[0];
				string lastName = student[1];
				double grades = double.Parse(student[2]);
				Students newStudent = new Students(firstName,lastName,grades);
				lisStudents.Add(newStudent);
			}
			lisStudents.OrderByDescending(t => t.Grades).ThenBy(t => t.FirstName).ToList();
			List<Students> sortedStudents = lisStudents.OrderByDescending(t => t.Grades)
				.ThenBy(t => t.FirstName).ThenBy(t => t.LastName).ToList();

			foreach (Students t in sortedStudents)
			{
				Console.WriteLine($"{t.FirstName} {t.LastName}: {t.Grades:f2}");
			}
		}
	}
}
