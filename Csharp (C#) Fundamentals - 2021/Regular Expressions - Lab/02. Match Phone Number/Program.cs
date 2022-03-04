using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace _02._Match_Phone_Number
{
	class Program
	{
		static void Main(string[] args)
		{
			string patern = @"( ?\+359 2 \d{3} \d{4}\b)|( ?\+359-2-\d{3}-\d{4}\b)";
			string phoneNums = Console.ReadLine();
			var phoneMatches = Regex.Matches(phoneNums, patern);
			var mathPPhone=phoneMatches.Cast<Match>().Select(x => x.Value.Trim()).ToArray();
			Console.WriteLine(string.Join(", ",mathPPhone));
		}
	}
}
