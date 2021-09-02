
namespace BorderControl
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class StartUp
	{
		public static void Main()
		{
			List<IIdentifiable> allObject = new List<IIdentifiable>();
			List<Citizens> citizens = new List<Citizens>();
			while (true)
			{
				string typeOfObjectAndInfo = Console.ReadLine();
				if (typeOfObjectAndInfo == "End")
				{
					break;
				}
				else if (typeOfObjectAndInfo.Contains('-'))
				{
					string[] splitRobotsInfo = typeOfObjectAndInfo.Split(' ', StringSplitOptions.RemoveEmptyEntries);
					string model = splitRobotsInfo[0];
					string id = splitRobotsInfo[1];
					allObject.Add(new Robots(model, id));
				}
				else
				{
					string[] splitCitizens = typeOfObjectAndInfo.Split(' ', StringSplitOptions.RemoveEmptyEntries);
					string name = splitCitizens[0];
					int age = int.Parse(splitCitizens[1]);
					string id = splitCitizens[2];
					allObject.Add(new Citizens(name, age, id));
				}
			}
			string fakeIdNum = Console.ReadLine();

			allObject = allObject
				.Where(x => x.Id.EndsWith(fakeIdNum))
				.ToList();
			if (allObject.Count > 0)
			{
				allObject
				.Where(x => x.Id.EndsWith(fakeIdNum))
				.ToList()
				.ForEach(x => Console.WriteLine(x.Id));
			}

		}
	}
}
