using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
			for (int i = 0; i < numbers.Count; i++)
			{
				string[] commandArray = Console.ReadLine().Split();
				if (commandArray[0] == "Add")
				{
					numbers.Add(int.Parse(commandArray[1]));
				}
				else if (commandArray[0] == "Remove")
				{
					numbers.Remove(int.Parse(commandArray[1]));
				}
				else if (commandArray[0] == "RemoveAt")
				{
					numbers.RemoveAt(int.Parse(commandArray[1]));
				}
				else if (commandArray[0] == "Insert")
				{
					numbers.Insert(int.Parse(commandArray[2]),int.Parse(commandArray[1]));
				}
				else if (commandArray[0]=="end")
				{
					break;
				}

			}
			Console.WriteLine(string.Join(" ",numbers));
		}
	}
}
