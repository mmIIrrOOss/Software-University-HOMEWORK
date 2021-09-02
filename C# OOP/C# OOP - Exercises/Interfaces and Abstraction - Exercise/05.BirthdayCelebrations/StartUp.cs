
namespace FoodShortage
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class StartUp
	{
		public static void Main()
		{
			List<IBirthdatetable> allObject = new List<IBirthdatetable>();
			while (true)
			{
				string typeOfObjectAndInfo = Console.ReadLine();
				if (typeOfObjectAndInfo == "End")
				{
					break;
				}
				else if (typeOfObjectAndInfo.Contains("Robot"))
				{
					continue;
					//string[] splitRobotsInfo = typeOfObjectAndInfo.Split(' ', StringSplitOptions.RemoveEmptyEntries);
					//string typeName = splitRobotsInfo[0];
					//string model = splitRobotsInfo[1];
					//string id = splitRobotsInfo[2];
					//allObject.Add(new Robots(typeName, model, id));
				}
				else if (typeOfObjectAndInfo.Contains("Citizen"))
				{
					string[] splitCitizens = typeOfObjectAndInfo.Split(' ', StringSplitOptions.RemoveEmptyEntries);
					string typeName = splitCitizens[0];
					string name = splitCitizens[1];
					int age = int.Parse(splitCitizens[2]);
					string id = splitCitizens[3];
					string birthdate = splitCitizens[4];
					allObject.Add(new Citizens(typeName, name, age, id, birthdate));
				}
				else if (typeOfObjectAndInfo.Contains("Pet"))
				{
					string[] splitPetInfo = typeOfObjectAndInfo.Split(' ', StringSplitOptions.RemoveEmptyEntries);
					string typeName = splitPetInfo[0];
					string name = splitPetInfo[1];
					string birthdate = splitPetInfo[2];
					allObject.Add(new Pet(typeName, name, birthdate));
				}
			}
			string date = Console.ReadLine();

			List<IBirthdatetable> result = allObject
				.Where(x => x.Birthdate.EndsWith(date))
				.ToList();
			if (result.Count > 0)
			{
				result
			   .ToList()
			   .ForEach(x=>Console.WriteLine(x.Birthdate));
			}
		}
	}
}
