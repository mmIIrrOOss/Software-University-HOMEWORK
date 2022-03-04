using System;

namespace _04._Students
{
	using System.Collections.Generic;
	using System.Linq;

	class Student
	{
		public string Name { get; set; }
		public string LastName { get; set; }
		public int Age { get; set; }
		public string Hometown { get; set; }

	}
	class Program
	{
		static void Main(string[] args)
		{
			List<Student> saveStudents = new List<Student>();
			ReadStudents(saveStudents);
			string town = Console.ReadLine();
			ChekIsEqualsHometown(saveStudents, town);

		}

		private static void ChekIsEqualsHometown(List<Student> saveStudents, string town)
		{
			foreach (Student student in saveStudents)
			{
				if (student.Hometown == town)
				{
					Console.WriteLine($"{student.Name} {student.LastName} is {student.Age} years old.");

				}
			}

		}

		private static void ReadStudents(List<Student> saveStudents)
		{
			while (true)
			{
				string[] studentInfo = Console.ReadLine().Split();
				if (studentInfo[0] == "end")
				{
					break;
				}

				string name = studentInfo[0];
				string lastName = studentInfo[1];
				int age = int.Parse(studentInfo[2]);
				string hometown = studentInfo[3];
				Student students = new Student();
				{
					students.Name = name;
					students.LastName = lastName;
					students.Age = age;
					students.Hometown = hometown;

				}
				saveStudents.Add(students);

			}
		}
	}

}
