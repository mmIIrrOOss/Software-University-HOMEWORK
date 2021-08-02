using System;
using System.Collections.Generic;
using System.Linq;
namespace _09._ForceBook
{
	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, string> dict = new Dictionary<string, string>();

			while (true)
			{
				string lightDarks = string.Empty;
				string names = string.Empty;
				var split = Console.ReadLine();
				if (split.Contains("Lumpawaroo"))
				{
					break;
				}
				if (split.Contains("|"))
				{
					lightDarks = split.Split(" | ", 2)[0];
					names = split.Split(" | ", 2)[1];
					if (!dict.ContainsKey(lightDarks))
					{
						dict.Add(names, lightDarks);
					}

				}
				else if (split.Contains("->"))
				{
					names = split.Split(" -> ", 2)[0];
					lightDarks = split.Split(" -> ", 2)[1];
					if (dict.ContainsKey(names))
					{
						dict[names] = lightDarks;
					}
					else
					{
						dict.Add(names, lightDarks);
					}
					Console.WriteLine($"{names} joins the {lightDarks} side!");
				}
			}

			foreach (var item in dict.GroupBy(x => x.Value)
									  .OrderByDescending(x => x.Count())
									  .ThenBy(x => x.Key))
			{
				Console.WriteLine($"Side: {item.Key}, Members: {item.Count()}");
				foreach (var member in item.OrderBy(x => x.Key))
				{
					Console.WriteLine($"! {member.Key}");
				}

			}
		}
	}
}
