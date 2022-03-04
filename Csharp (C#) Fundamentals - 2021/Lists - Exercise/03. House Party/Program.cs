using System;

namespace _03._House_Party
{
	using System.Collections.Generic;
	using System.Linq;
	class Program
	{
		static void Main()
		{
			int numCommand = int.Parse(Console.ReadLine());
			List <string>partyGuest = new List<string> (numCommand); 
			for (int i = 0; i < numCommand; i++)
			{
				List<string> partySplit = Console.ReadLine().Split().ToList();
				if (partySplit[1]==("is")&&partySplit[2]== "going!")
				{
					if (partyGuest.Contains(partySplit[0]))
					{
						Console.WriteLine($"{partySplit[0]} is already in the list!");
					}
					else
					{
						partyGuest.Add(partySplit[0]);
					}
				}
				else if (partySplit[2]==("not"))
				{
					if (!(partyGuest.Contains(partySplit[0])))
					{
						Console.WriteLine($"{partySplit[0]} is not in the list!");
					}
					else
					{
						partyGuest.Remove(partySplit[0]);
					}
				}
			}
			Console.WriteLine(string.Join("\n",partyGuest));
		}
	}
}
