using System;
using System.Collections.Generic;
namespace _07._SoftUni_Party
{
	class Program
	{
		static void Main(string[] args)
		{
			HashSet<string> set = new HashSet<string>();
			while (true)
			{
				string command = Console.ReadLine();
				if (command=="PARTY")
				{
					break;
				}
				set.Add(command);
			}
			while (true)
			{
				string command = Console.ReadLine();
				if (command == "END")
				{
					break;
				}
				if (set.Contains(command))
				{
					set.Remove(command);
				}
			}
			Console.WriteLine(set.Count);
			foreach (var item in set)
			{
				char[] symbols = item.ToCharArray();
				if (char.IsDigit(symbols[0]))
				{
					Console.WriteLine(item);
				}
			}
			foreach (var item in set)
			{
				char[] symbols = item.ToCharArray();
				if (char.IsLetter(symbols[0]))
				{
					Console.WriteLine(item);
				}
			}
		}
	}
}
