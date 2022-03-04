using System;
using System.Collections.Generic;
namespace _06._Wardrobe
{
	class Program
	{
		static void Main(string[] args)
		{
			int lines = int.Parse(Console.ReadLine());
			Dictionary<string, Dictionary<string, int>> dict = new Dictionary<string, Dictionary<string, int>>();
			for (int i = 0; i < lines; i++)
			{
				string[] dress = Console.ReadLine().Split("->",StringSplitOptions.RemoveEmptyEntries);
				string[] dress2 = dress[i].Split(",",StringSplitOptions.RemoveEmptyEntries);
				string color = dress2[0];
				if (dict.ContainsKey(color))
				{
					for (int j = 0; j < dress2.Length; j++)
					{
						string currentItem = dress2[j];
						if (dict[color].ContainsKey(currentItem))
						{
							dict[color][currentItem]++;
						}
						else
						{
							dict[color].Add(currentItem, 1);
						}
					}

				}
				else
				{
					dict.Add(color, new Dictionary<string, int>());
					for (int k = 0; k < dress2.Length; k++)
					{
						string currentItem = dress2[k];
						dict[color].Add(currentItem, 1);
					}
				}
				string[] itemFind = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
				string coloFind = itemFind[0];
				string clothFind = itemFind[1];
				foreach (var item in dict)
				{
					Console.WriteLine($"{item.Key} clothes:");
					foreach (var cloth in item.Value)
					{
						if (item.Key==clothFind&&cloth.Key==clothFind)
						{
							Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
						}
						else
						{
							Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
						}
					}
				}

			}
		}

	}
}


