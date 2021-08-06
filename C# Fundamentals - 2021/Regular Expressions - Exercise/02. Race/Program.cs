using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace _02._Race
{
	class Program
	{
		static void Main(string[] args)
		{
			List<string> people = Console.ReadLine().Split(", ").ToList();
			Dictionary<string, double> save = new Dictionary<string, double>();
			while (true)
			{
				string command = Console.ReadLine();
				if (command == "end of race")
				{
					break;
				}
				string namePatern = @"[A-Za-z]";
				string kmPatern = @"[\d]";
				MatchCollection names = Regex.Matches(command, namePatern);
				MatchCollection kilometers = Regex.Matches(command, kmPatern);
				var name = string.Concat(names);
				var sumKilometers = kilometers.Select(x => int.Parse(x.Value)).Sum();
				if (people.Contains(name))
				{
					if (save.ContainsKey(name))
					{

						save[name] += sumKilometers;
					}
					else
					{
						save.Add(name, sumKilometers); ;
					}
				}
			}
			var sort = save.OrderByDescending(x => x.Value).Take(3).ToList();
			Console.WriteLine($"1st place: {sort[0].Key}");
			Console.WriteLine($"2nd place: {sort[1].Key}");
			Console.WriteLine($"3rd place: {sort[2].Key}");
		}
	}
}
