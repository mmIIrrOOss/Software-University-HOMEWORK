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
			List<Student> addStudent = new List<Student>();
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
				string homeTown = studentInfo[3];

				if (isStudentExisting(addStudent, name, lastName))
				{
					Student student = GetStudent(addStudent, name, lastName, age);
					Student targetStudent = addStudent.FirstOrDefault(x => x.Name == name && x.LastName == lastName);
					addStudent.Remove(targetStudent);
					addStudent.Add(student);

				}
				else
				{

					Student students = new Student();
					{
						students.Name = name;
						students.LastName = lastName;
						students.Age = age;
						students.Hometown = homeTown;

					}
					addStudent.Add(students);
				}
			}
			string filterCity = Console.ReadLine();
			List<Student> filterStudents = addStudent.Where(s => s.Hometown == filterCity).ToList();
			foreach (Student student in filterStudents)
			{
				Console.WriteLine($"{student.Name} {student.LastName} is {student.Age} years old.");
			}

		}

		static Student GetStudent(List<Student> addStudents, string name, string lastName,int age)
		{
			Student existingStudent = null;
			foreach (Student student in addStudents)
			{
				if (student.Name == name && student.LastName == lastName)
				{
					student.Age = age;
					existingStudent = student;
					return existingStudent;
				}
			}
			return existingStudent;
		}

		private static bool isStudentExisting(List<Student> addStudents, string name, string lastName)
		{
			foreach (Student student in addStudents)
			{
				if (student.Name == name && student.LastName == lastName)
				{
					return true;
				}

			}
			return false;
		}
	}

}
