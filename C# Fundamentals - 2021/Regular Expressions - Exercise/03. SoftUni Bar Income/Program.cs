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
			Dictionary<int, double> priceAndQuantity = new Dictionary<int, double>();
			while (true)
			{
				string input = Console.ReadLine();
				if (input == "end of shift")
				{
					break;
				}
				string clientPattern = @"\%[A-Z{1}][a-z]+\%";
				string productPattern = @"\<[\w]+\>";
				string quantityPattern = @"\|\d+\|";
				string pricePattern = @"\d+\.\d+\$";

				string clientName = (Regex.Matches(input, clientPattern)).ToString();
				string product = (Regex.Matches(input, productPattern)).ToString();
				int quantity = int.Parse(Regex.Matches(input, quantityPattern).ToString());
				int price = int.Parse(Regex.Matches(input, pricePattern).ToString());
			}
		}
	}
}
