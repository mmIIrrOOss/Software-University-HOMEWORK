using System;
using System.Collections.Generic;
using System.Linq;
namespace _08._Company_Users
{
	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, List<string>> saveCompany = new Dictionary<string, List<string>>();
			while (true)
			{
				string command = Console.ReadLine();
				if (command=="End")
				{
					break;
				}
				string [] split = command.Split("->");
				string company = split[0];
				string id = split[1];
				if (!saveCompany.ContainsKey(company))
				{
					saveCompany.Add(company,new List<string>());
					saveCompany[company].Add(id);
				}
				else if (!saveCompany[company].Contains(id))
				{
					saveCompany[company].Add(id);
				}
			}
			var sorted = saveCompany.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
			foreach (var item in sorted)
			{
				Console.WriteLine($"{item.Key}");
				foreach (var names in item.Value)
				{
					Console.WriteLine($"--{names}");
				}
			}
		}
	}
}
