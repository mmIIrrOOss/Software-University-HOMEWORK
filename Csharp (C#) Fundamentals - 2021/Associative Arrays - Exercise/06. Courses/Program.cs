using System;
using System.Collections.Generic;
using System.Linq;
namespace _06._Courses
{
	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, List<string>> saveCourses = new Dictionary<string, List<string>>();
			while (true)
			{
				string command = Console.ReadLine();
				if (command == "end")
				{
					break;
				}
				string[] split = command.Split(" : ");
				string coursesName = split[0];
				string studentsName = split[1];
				if (!saveCourses.ContainsKey(coursesName))
				{
					saveCourses.Add(coursesName, new List<string> { studentsName });

				}
				else
				{
					saveCourses[coursesName].Add(studentsName);
				}
			}
			Dictionary<string, List<string>> sorted = saveCourses
				.OrderByDescending(x => x.Value.Count())
				.ToDictionary(x => x.Key, x => x.Value);
			foreach (var item in sorted)
			{
				Console.WriteLine($"{item.Key}: {item.Value.Count}");
				var orderlistMembers = item.Value
			 .OrderBy(x => x)
			 .ToList();
				for (int i = 0; i < item.Value.Count; i++)
				{
					Console.WriteLine($"-- {orderlistMembers[i]}");
				}
			}
		}
	}
}
