using System;
using System.Collections.Generic;
using System.Linq;
namespace Nested_Dictionary
{
	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();
			while (true)
			{
				string command = Console.ReadLine();
				if (command=="Revision")
				{
					break;
				}
				string[] split = command.Split(", ");
				string shop = split[0];
				string product = split[1];
				double price = double.Parse(split[2]);
				if (!shops.ContainsKey(shop))
				{
					shops.Add(shop, new Dictionary<string, double>());
				}
				shops[shop].Add(product, price);
			}
			foreach (var key in shops.OrderBy(x=>x.Key))
			{
				Console.WriteLine($"{key.Key}->");
				foreach (var item in key.Value)
				{
					Console.WriteLine($"Product: {item.Key}, Price: {item.Value}");
				}
			}
		}
	}
}
