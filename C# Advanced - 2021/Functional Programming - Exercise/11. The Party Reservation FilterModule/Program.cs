using System;
using System.Collections.Generic;
using System.Linq;
namespace _11._The_Party_Reservation_Filter_Module
{
	class Program
	{
		static void Main(string[] args)
		{
			List<string> listNames = Console.ReadLine()
				.Split()
				.ToList();
			List<string> saveCoomand = new List<string>();
			while (true)
			{
				string command = Console.ReadLine();
				if (command == "Print")
				{
					break;
				}
				string[] split = command.Split(';');
				if (split.Contains("Add filter"))
				{
					saveCoomand.Add(split[1] + " " + split[2]);
				}
				else if (split.Contains("Remove filter"))
				{
					saveCoomand.Remove(split[1] + " " + split[2]);
				}

			}
			foreach (var item in saveCoomand)
			{
				var split = item.Split(" ");
				if (split[0] == "Starts")
				{
					listNames = listNames.Where(p => !p.StartsWith(split[2])).ToList();
				}
				else if (split[0] == "Ends")
				{
					listNames = listNames.Where(p => !p.EndsWith(split[2])).ToList();
				}
				else if (split[0] == "Length")
				{
					listNames = listNames.Where(p => p.Length != int.Parse(split[1])).ToList();
				}
				else if (split[0] == "Contains")
				{
					listNames = listNames.Where(p => !p.Contains(split[1])).ToList();
				}
			}
			if (listNames.Any())
			{
				Console.WriteLine(string.Join(" ", listNames));
			}
		}

	}
}
