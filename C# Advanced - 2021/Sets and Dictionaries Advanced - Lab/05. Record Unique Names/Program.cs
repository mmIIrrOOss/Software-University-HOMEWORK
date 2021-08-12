using System;
using System.Collections.Generic;
namespace _05._Record_Unique_Names
{
	class Program
	{
		static void Main(string[] args)
		{
			HashSet<string> saveName = new HashSet<string>();
			int lines = int.Parse(Console.ReadLine());
			for (int i = 0; i < lines; i++)
			{
				string name = Console.ReadLine();
				saveName.Add(name);
			}
			foreach (var item in saveName)
			{
				Console.WriteLine(item);
			}
		}
	}
}
