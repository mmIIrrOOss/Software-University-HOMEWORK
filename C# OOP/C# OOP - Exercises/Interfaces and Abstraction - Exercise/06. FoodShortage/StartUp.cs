
namespace FoodShortage
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class StartUp
	{
		public static void Main()
		{
			int numOfPeople = int.Parse(Console.ReadLine());
			List<IBuyer> buyers = new List<IBuyer>();
			for (int i = 0; i < numOfPeople; i++)
			{
				string[] infoForObject = Console.ReadLine().Split();
				if (infoForObject.Length == 4)
				{
					AddOfCitizen(buyers, infoForObject);
				}
				else if (infoForObject.Length == 3)
				{
					AddOfRebel(buyers, infoForObject);
				}
			}
			string command;

			while ((command = Console.ReadLine()) != "End")
			{
				var buyer = buyers.SingleOrDefault(b => b.Name == command);
				if (buyer != null)
				{
					buyer.BuyFood();
				}
			}
			Console.WriteLine(buyers.Sum(b => b.Food));
		}

		private static void AddOfRebel(List<IBuyer> buyers, string[] infoForObject)
		{
			string name = infoForObject[0];
			int age = int.Parse(infoForObject[1]);
			string group = infoForObject[2];
			buyers.Add(new Rebel(name, age, group));
		}

		private static void AddOfCitizen(List<IBuyer> buyers, string[] infoForObject)
		{
			string name = infoForObject[0];
			int age = int.Parse(infoForObject[1]);
			string id = infoForObject[2];
			string birthdate = infoForObject[3];
			buyers.Add(new Citizens(name, age, id, birthdate));
		}
	}
}
