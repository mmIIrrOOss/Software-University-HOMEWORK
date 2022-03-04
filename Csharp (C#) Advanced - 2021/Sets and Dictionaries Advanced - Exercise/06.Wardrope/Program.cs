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
				string[] colorAndClothes = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
				string[] clothes = colorAndClothes[1].Split(",", StringSplitOptions.RemoveEmptyEntries);
				string color = colorAndClothes[0];
				if (dict.ContainsKey(color))
				{
					for (int j = 0; j < clothes.Length; j++)
					{
						string currentItem = clothes[j];
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
					for (int k = 0; k < clothes.Length; k++)
					{
						string currentItem = clothes[k];
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
			}
			string[] itemFind = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
			string colorFind = itemFind[0];
			string clothFind = itemFind[1];
			foreach (var item in dict)
			{
				Console.WriteLine($"{item.Key} clothes:");

				foreach (var cloth in item.Value)
				{
					if (item.Key == colorFind && cloth.Key == clothFind)
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


