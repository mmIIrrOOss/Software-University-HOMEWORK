using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04._Star_Enigm
{
	class Program
	{

		static void Main(string[] args)
		{

			int num = int.Parse(Console.ReadLine());
			Dictionary<char, int> save = new Dictionary<char, int>();
			List<string> atacked = new List<string>();
			List<string> destroyed = new List<string>();
			for (int i = 0; i < num; i++)
			{
				string crypt = Console.ReadLine();
				string pattern = @"[s, t, a, r, S, T, A, R]";
				int count = Regex.Matches(crypt, pattern).Count;
				string newString = string.Empty;
				for (int j = 0; j < crypt.Length; j++)
				{
					int numSymbol = crypt[j] - count;
					newString += Convert.ToChar(numSymbol);
				}
				string pattern1 = @"(?<name>[A-Za-z]+)[^@:!\->]*:(?<population>\d+)[^@:!\->]*!(?<command>[A|D])![^@:!\->]*\->(?<soldier>\d+)";
				if (Regex.IsMatch(newString, pattern1))
				{
					var match = Regex.Match(newString, pattern1);
					string planet = match.Groups["name"].Value;
					string typePlanet = match.Groups["command"].Value;
					char atack = Convert.ToChar(typePlanet);
					if (!save.ContainsKey(atack))
					{
						save.Add(atack, 0);
						save[atack]++;
					}
					else
					{
						save[atack]++;
					}
					if (atack == 'A')
					{
						atacked.Add(planet);
					}
					else if (atack == 'D')
					{
						destroyed.Add(planet);
					}
				}
			}
			Console.WriteLine($"Attacked planets: {atacked.Count}");
			if (atacked.Count > 0)
			{
				foreach (var item in atacked.OrderBy(x => x))
				{
					Console.WriteLine($"-> {item}");
				}

			}
			Console.WriteLine($"Destroyed planets: {destroyed.Count}");
			if (destroyed.Count > 0)
			{
				foreach (var item in destroyed.OrderBy(x => x))
				{
					Console.WriteLine($"-> {item}");
				}
			}
		}
	}
}
