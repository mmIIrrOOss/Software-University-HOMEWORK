
namespace ShoppingSpree

{
	using System;
	using System.Collections.Generic;
	
	public class StartUp
	{
		public static void Main()
		{
			Dictionary<string, Person> people = new Dictionary<string, Person>();
			Dictionary<string, Product> products = new Dictionary<string, Product>();
			
			string inputPerson = Console.ReadLine();
			string inputProduct = Console.ReadLine();
			string[] splitPerson = inputPerson.Split(new char[] { ';' });
			string[] splitProduct = inputProduct.Split(new char[] { ';' });
			try
			{
				foreach (var item in splitPerson)
				{
					string[] tokens = item.Split('=');
					string name = tokens[0];
					decimal money = decimal.Parse(tokens[1]);
					Person person = new Person(name, money);
					people[name] = person;
					
				}
				foreach (var item in splitProduct)
				{
					string[] tokens = item.Split('=');
					string name = tokens[0];
					decimal cost = decimal.Parse(tokens[1]);

					Product product = new Product(name, cost);
					products[name] = product;
				}

				string command;
				while ((command = Console.ReadLine()) != "END")
				{
					string[] split = command.Split();
					string personName = split[0];
					string productName = split[1];
					decimal personMoney = people[personName].Money;
					decimal cost = products[productName].Cost;
					if (personMoney - cost < 0)
					{
						Console.WriteLine($"{personName} can't afford {productName}");
					}
					else
					{
						people[personName].Money -= cost;
						Console.WriteLine($"{personName} bought {productName}");
						people[personName].Products.Add(productName);
					}

				}
			}
			catch (ArgumentException ae)
			{
				Console.WriteLine(ae.Message);
				return;
			}
			foreach (var person in people)
			{
				Console.Write($"{person.Key} - ");
				if (person.Value.Products.Count == 0)
				{
					Console.WriteLine("Nothing bought");
				}
				else
				{
					Console.WriteLine(string.Join(", ", person.Value.Products));
				}
			}

		}
	}
}
