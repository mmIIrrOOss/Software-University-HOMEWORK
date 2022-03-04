using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Merging_Lists
{
	class Program
	{
		static void Main(string[] args)
		{

			int lines = int.Parse(Console.ReadLine());
			List<string> text = new List<string>();
			for (int i = 0; i < lines; i++)
			{
				text.Add(Console.ReadLine());
			}
			text.Sort();
			for (int i = 0; i < text.Count; i++)
			{
				Console.WriteLine($"{i + 1}.{text[i]}");

			}

		}
	}
}
