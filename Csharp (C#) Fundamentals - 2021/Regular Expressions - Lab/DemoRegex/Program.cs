using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DemoRegex
{
	class Program
	{
		static void Main(string[] args)
		{
			string text = "Today is 2015-05-11";
			string patern = @"\d{4}-\d{2}-\d{2}";
			Regex regex = new Regex(patern);
			bool contaisValue = regex.IsMatch(text);
			Console.WriteLine(contaisValue);

			string text1 = "Nakov: 123";
			string pattern = @"([A-Z][a-z]+): (\d+)";
			Regex regex1 = new Regex(pattern);
			Match match = regex1.Match(text1);
			Console.WriteLine(match.Groups.Count);
			Console.WriteLine($"Matched text: {match.Groups[0]}");
			Console.WriteLine("Name: {0}",match.Groups[1]);
			Console.WriteLine("Number: {0}",match.Groups[2]);

			string text2 = "Miro: 123, Branson: 456";
			string patterm2 = @"([A-Z][a-z]+): (\d+)";
			Regex regex2 = new Regex(patterm2);
			MatchCollection mat = regex2.Matches(text2);
			Console.WriteLine("Found {0} matches", mat.Count);
			foreach (Match ma in mat)
			{
				Console.WriteLine($"Name: {ma.Groups[1]}");
			}

			string text3 = "Miro: 123, Branson: 456";
			string patter3 = @"\d{3}";
			string replacement = "999";
			Regex regex3 = new Regex(patter3);
			string result = regex3.Replace(text3, replacement);
			Console.WriteLine(result);

			string text4 = "1   2  3  4 5 ";
			string pattern4 = @"\s+";
			string[] results = Regex.Split(text4, pattern4);
			Console.WriteLine(string.Join(", ", results));
		}
	}
}
