using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._Match_Dates
{
	class Program
	{
		static void Main(string[] args)
		{
			string patern = @"(?<day>\d{2})([-|\.|\/])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})";
			string stringDates = Console.ReadLine();
			var dates = Regex.Matches(stringDates,patern);
			foreach (Match item in dates)
			{
				var day = item.Groups["day"].Value;
				var month = item.Groups["month"].Value;
				var year = item.Groups["year"].Value;
				Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
			}
		}
	}
}
