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
			List<string> saveRemoveNmaes = new List<string>();
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
					string type = TypeParametars(split[1]);
					char parametars = Convert.ToChar(split[2]);
					RemoveNamesAddFilter(parametars, listNames,saveRemoveNmaes);
				}
				else if (split.Contains("Remove filter"))
				{
					string type = TypeParametars(split[1]);
					char parametars = Convert.ToChar(split[2]);
					AddNamesRemoveFilter(parametars, listNames, saveRemoveNmaes);
				}

			}
			Console.WriteLine(string.Join(" ",listNames.OrderByDescending(x=>x)));
		}
		static string TypeParametars(string type)
		{
			switch (type)
			{
				case "Starts with":
					break;
				case "Ends with":
					break;
				case "Length":
					break;
				case "Contains":
					break;
				default:
					break;
			}
			return type;
		}
		static void RemoveNamesAddFilter(char letter, List<string> names,List<string>saveRemoveNames)
		{
			foreach (var name in names)
			{
				if (name.Contains(letter))
				{
					saveRemoveNames.Add(name);
					names.Remove(name);
					break;
				}
			}
		}
		static void AddNamesRemoveFilter(char letter,List<string> name, List<string> saveRemoveNmaes)
		{
			foreach (var item in saveRemoveNmaes)
			{
				if (item.Contains(letter))
				{
					name.Add(item);
					break;
				}
			}
		}
	}
}
