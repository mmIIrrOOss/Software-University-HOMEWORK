using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Course_Planning
{
	class Program
	{
		static void Main(string[] args)
		{
			List<string> coursePlaning = Console.ReadLine().Split(", ").ToList();
			while (true)
			{
				string command = Console.ReadLine();
				if (command == "course start")
				{
					break;
				}
				string[] split = command.Split(":");
				if (split[0] == "Add")
				{
					string leassonTitle = split[1];
					if (!coursePlaning.Contains(leassonTitle))
					{
						coursePlaning.Add(leassonTitle);
					}
				}
				else if (split[0] == "Insert")
				{
					string leassonTitle = split[1];
					int index = int.Parse(split[2]);
					if (!coursePlaning.Contains(leassonTitle))
					{
						coursePlaning.Insert(0, leassonTitle);
					}
				}
				else if (split[0] == "Remove")
				{
					string leassonTitle = split[1];
					if (coursePlaning.Contains(leassonTitle)||coursePlaning.Contains(leassonTitle+"-Exercise"))
					{
						coursePlaning.Remove(leassonTitle);
					}
				}
				else if (split[0] == "Swap")
				{
					string leassonTitle = split[1];
					string leassonTitle2 = split[2];
					int index = coursePlaning.IndexOf(leassonTitle);
					int index2 = coursePlaning.IndexOf(leassonTitle2);
					coursePlaning[index] = leassonTitle2;
					coursePlaning[index2] = leassonTitle;
					if (coursePlaning.Contains(leassonTitle + "-Exercise") || coursePlaning.Contains(leassonTitle2 + "-Exercise"))
					{

						int index3 = coursePlaning.IndexOf(leassonTitle2 + "-Exercise");
						int other = index3 - 1;
						string str = coursePlaning[other];
						coursePlaning[other] = leassonTitle2 + "-Exercise";
						coursePlaning[index3] = str;
					}
				}
				else if (split[0] == "Exercise")
				{
					string leassonTitle = split[1];
					if (!coursePlaning.Contains(leassonTitle))
					{
						coursePlaning.Add(leassonTitle + $"-{split[0]}");
					}
					coursePlaning.Add(leassonTitle);
				}
			}
			int count = 1;
			foreach (var item in coursePlaning)
			{
				Console.WriteLine($"{count}.{item}");
				count++;
			}
		}
	}
}
