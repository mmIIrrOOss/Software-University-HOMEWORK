using System;

namespace _04._Orders
{
	using System.Collections.Generic;
	using System.Linq;
	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, double[]> products = new Dictionary<string, double[]>();
			while (true)
			{
				string buyCommand = Console.ReadLine();
				if (buyCommand == "buy")
				{
					break;
				}
				string[] splitInfoProducts = buyCommand.Split();
				string nameProduct = splitInfoProducts[0];
				double price = double.Parse(splitInfoProducts[1]);
				double quantity = double.Parse(splitInfoProducts[2]);
				if (!products.ContainsKey(nameProduct))
				{

					products.Add(nameProduct, new double[2]);

				}
				products[nameProduct][0] = price;
				products[nameProduct][1] += quantity;

			}
			foreach (var item in products)
			{
				Console.WriteLine($"{item.Key} -> {(item.Value[0] * item.Value[1]):f2}");
			}
		}
	}
}
