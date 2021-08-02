using System;
using System.Collections.Generic;
using System.Linq;
namespace _03._Legendary_Farming
{
	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, int> materials = new Dictionary<string, int>();
			materials["motes"] = 0;
			materials["shards"] = 0;
			materials["fragments"] = 0;
			Dictionary<string, int> nekviraboti = new Dictionary<string, int>();
			while (materials["motes"] < 250 && materials["shards"] < 250
												&& materials["fragments"] < 250)
			{
				string materialsAndQuantity = Console.ReadLine().ToLower();
				string[] split = materialsAndQuantity.Split();
				for (int i = 0; i < split.Length; i += 2)
				{
					int quatity = int.Parse(split[i]);
					string material = split[i + 1];
					switch (material)
					{
						case "motes":
						case "shards":
						case "fragments":
							materials[material] += quatity;
							break;
						default:
							if (!(nekviraboti.ContainsKey(material)))
							{
								nekviraboti.Add(material, 0);
								nekviraboti[material] += quatity;
								break;
							}
							break;

					}
					if (materials["shards"] >= 250 || materials["fragments"] >= 250 || materials["motes"] >= 250)
						break;
				}
			}
			string legendary =string.Empty; ;
			if (materials["shards"] >= 250)
			{
				legendary = "Shadowmourne";
				materials["shards"] -= 250;
			}
			else if (materials["fragments"] >= 250)
			{
				legendary = "Valanyr";
				materials["fragments"] -= 250;
			}
			else if (materials["motes"] >= 250)
			{
				legendary = "Dragonwrath";
				materials["motes"] -= 250;
			}
			Console.WriteLine($"{legendary} obtained!");
			foreach (var item in materials.OrderByDescending(entry => entry.Value).ThenBy(entry => entry.Key))
			{
				Console.WriteLine($"{item.Key}: {item.Value}");
			}

			foreach (var item in nekviraboti.OrderBy(entry => entry.Key))
			{
				Console.WriteLine($"{item.Key}: {item.Value}");
			}

		}
	}
}
