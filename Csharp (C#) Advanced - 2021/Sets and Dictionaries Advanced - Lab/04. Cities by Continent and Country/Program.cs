using System;
using System.Collections.Generic;
namespace _04._Cities_by_Continent_and_Country
{
	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, Dictionary<string, List<string>>> maps = new Dictionary<string, Dictionary<string, List<string>>>();
			int lines = int.Parse(Console.ReadLine());
			for (int i = 0; i < lines; i++)
			{
				string[] map = Console.ReadLine().Split();
				string continents = map[0];
				string country = map[1];
				string city = map[2];
				if (!maps.ContainsKey(continents))
				{
					maps.Add(continents, new Dictionary<string, List<string>>());
					if (!maps[continents].ContainsKey(country))
					{
						maps[continents].Add(country, new List<string>());
						maps[continents][country].Add(city);
					}
					else
					{
						maps[continents][country].Add(city);
					}
				}
				else
				{
					if (!maps[continents].ContainsKey(country))
					{
						maps[continents].Add(country, new List<string>());
						maps[continents][country].Add(city);
					}
					else
					{
						maps[continents][country].Add(city);
					}
				}
				
			}
			foreach (var item in maps)
			{
				Console.WriteLine($"{item.Key}:");
				foreach (var info in item.Value)
				{
					Console.WriteLine($"{info.Key} -> {string.Join(", ",info.Value)}");
				}
			}
		}
	}
}
