using System;
using System.Collections.Generic;
using System.Linq;
namespace _10._SoftUni_Exam_Results
{

	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, List<int>> infoExam = new Dictionary<string, List<int>>();
			Dictionary<string, int> languageSubmitions = new Dictionary<string, int>();
			while (true)
			{
				string command = Console.ReadLine();
				if (command == "exam finished")
				{
					break;
				}
				string[] split = command.Split("-").ToArray();
				if (split.Length > 2)
				{

					string name = split[0];           //Pesho
					string programLang = split[1];   // c#
					int scores = int.Parse(split[2]);// 85
					if (!infoExam.ContainsKey(name))
					{
						infoExam.Add(name, new List<int>());
						infoExam[name].Add(scores);
					}
					else
					{
						infoExam[name].Add(scores);
					}
					if (!languageSubmitions.ContainsKey(programLang))
					{
						languageSubmitions.Add(programLang, 0);
						languageSubmitions[programLang]++;
					}
					else
					{
						languageSubmitions[programLang]++;
					}
				}
				else
				{
					string name = split[0];
					if (infoExam.ContainsKey(name))
					{
						infoExam.Remove(name);
					}
				}

			}
			var sort = infoExam.OrderByDescending(x => x.Value.Max()).ThenBy(x=>x.Key).ToDictionary(x => x.Key, x => x.Value);
			Console.WriteLine($"Results:");
			foreach (var item in sort)
			{
				int max = item.Value.Max();
				Console.WriteLine($"{item.Key} | {max}");
			}
			Console.WriteLine("Submissions:");
			foreach (var item in languageSubmitions.OrderBy(x=>x.Key).ThenByDescending(x=>x.Value).OrderBy(x=>x.Key))
			{
				Console.WriteLine($"{item.Key} - {item.Value}");
			}
		}

	}
}
