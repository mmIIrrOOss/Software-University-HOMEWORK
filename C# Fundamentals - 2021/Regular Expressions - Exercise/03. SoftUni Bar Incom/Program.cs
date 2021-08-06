using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace _03._SoftUni_Bar_Income
{
	class Program
	{
		static void Main(string[] args)
		{

			Dictionary<string, string> nameAndProduct = new Dictionary<string, string>();
			int quantityes = 0;
			int prices = 0;
			double totalPrice = 0;
			while (true)
			{
				string input = Console.ReadLine();
				if (input == "end of shift")
				{
					break;
				}
				string pattern = @"^%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?)\$";
				if (Regex.IsMatch(input, pattern))
				{

					Match match = Regex.Match(input, pattern);
					string name = match.Groups["customer"].Value;
					string product = match.Groups["product"].Value;
					int count = int.Parse(match.Groups["count"].Value);
					double price = double.Parse(match.Groups["price"].Value);
					double money = price * count;
					Console.WriteLine($"{name}: {product} - {money:f2}");
					totalPrice += money;
				}
			}
			Console.WriteLine($"Total income: {totalPrice:f2}");
		}
	}
}