
namespace Raiding
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class StartUp
	{
		public static void Main()
		{
			int numLines = int.Parse(Console.ReadLine());
			List<BaseHero> listOfHerous = new List<BaseHero>();
			for (int i = 0; i < numLines; i++)
			{
				string name = Console.ReadLine();
				string type = Console.ReadLine();
				switch (type)
				{
					case "Druid":
						listOfHerous.Add(new Druid(name));
						break;
					case "Paladin":
						listOfHerous.Add(new Paladin(name));
						break;
					case "Rogue":
						listOfHerous.Add(new Rogue(name));
						break;
					case "Warrior":
						listOfHerous.Add(new Warrior(name));
						break;
					default:
						Console.WriteLine("Invalid hero!");
						i--;
						break;
				}
			}
			long bossPower = long.Parse(Console.ReadLine());
			foreach (var item in listOfHerous)
			{
				Console.WriteLine(item.CastAbility());
			}
			long allPowerHero = listOfHerous.Select(x => x.Power).Sum();
			if (allPowerHero >= bossPower)
			{
				Console.WriteLine("Victory!");
			}
			else
			{
				Console.WriteLine("Defeat...");
			}

		}
	}
}
