using System;

namespace _02._A_Miner_Task
{
	using System.Collections.Generic;
	using System.Linq;
	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, int> allReasours = new Dictionary<string, int>();
			while (true)
			{
				string resours = Console.ReadLine();
				if (resours == "stop")
				{
					break;
				}
				int quantity = int.Parse(Console.ReadLine());
				if (!(allReasours.ContainsKey(resours)))
				{
					allReasours.Add(resours, quantity);
					continue;
				}
				allReasours[resours] += quantity;

			}
			foreach (var item in allReasours)
			{
				Console.WriteLine($"{item.Key} -> {item.Value}");
			}
		}
	}
}
