using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
	class Program
	{
		static void Main(string[] args)
		{
			string pattern = @">>(?<name>[A-Za-z]+)<<(?<price>[\d]+\.?\d*)!(?<quantity>\d+)";
			List<string> saveItem = new List<string>();
			double totalSum = 0;
			while (true)
			{
				string command = Console.ReadLine();
				if (command == "Purchase")
				{
					break;
				}
				Regex regex = new Regex(pattern);
				Match match = regex.Match(command);
				if (match.Success)
				{
					saveItem.Add(match.Groups[1].Value);
					double price = double.Parse(match.Groups["price"].Value);
					int quantity = int.Parse(match.Groups["quantity"].Value);
					totalSum += price * quantity;
				}

			}
			Console.WriteLine($"Bought furniture:");
			if (saveItem.Count > 0)
			{
				Console.WriteLine(string.Join(Environment.NewLine, saveItem));
			}
			Console.WriteLine($"Total money spend: {totalSum:f2}");
		}
	}
}
