using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05._Nether_Realms
{
	class Program
	{
		static void Main(string[] args)
		{
			List<string> text = Console.ReadLine()
				.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
				.ToList();
			string patternHealth= @"[0-9-+.\/*]+";
			string patternDamage= @"[0-9-+.]+";
			string atack = @"[^\/*]";
			SortedDictionary<string,List<double>> infoDemons= new SortedDictionary<string, List<double>>();
			for (int i = 0; i < text.Count; i++)
			{
				int heath = 0;
				string demonLetter = Regex.Replace(text[i], patternHealth,"");
				if (demonLetter.Length==0)
				{
					continue;
				}
				foreach (var item in demonLetter)
				{
					heath += (char)item;
				}
				MatchCollection match = Regex.Matches(text[i], patternDamage);
				double damage = 0;
				foreach (Match item in match)
				{
					damage += double.Parse(item.Value);
				}
				string symbols = Regex.Replace(text[i], atack, "");
				foreach (var item in symbols)
				{
					if (item=='*')
					{
						damage *= 2;
					}
					else
					{
						damage /= 2;
					}
				}
				infoDemons.Add(text[i], new List<double>());
				infoDemons[text[i]].Add(heath);
				infoDemons[text[i]].Add(damage);

			}

			foreach (var item in infoDemons)
			{
				Console.WriteLine($"{item.Key} - {item.Value[0]} health, {item.Value[1]:f2} damage");
			}
		}
	}
}
