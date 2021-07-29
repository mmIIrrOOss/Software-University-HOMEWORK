using System;
using System.Collections.Generic;
using System.Linq;
namespace _07._Order_by_Age
{
	class Age
	{
		public string Name { get; set; }
		public string Id { get; set; }
		public int Ages { get; set; }
		public Age(string name,string id,int ages)
		{
			this.Name = name;
			this.Id = id;
			this.Ages = ages;
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			List<Age> saveInfo = new List<Age>();
			while (true)
			{
				string command = Console.ReadLine();
				if (command.Contains("End"))
				{
					break;
				}
				string[] split = command.Split();
				string name = split[0];
				string id = split[1];
				int age = int.Parse(split[2]);
				Age ag = new Age(name, id, age);
				saveInfo.Add(ag);
			}
			foreach (var item in saveInfo.OrderBy(x=>x.Ages))
			{
				Console.WriteLine($"{item.Name} with ID: {item.Id} is {item.Ages} years old.");
			}
		}
	}
}
