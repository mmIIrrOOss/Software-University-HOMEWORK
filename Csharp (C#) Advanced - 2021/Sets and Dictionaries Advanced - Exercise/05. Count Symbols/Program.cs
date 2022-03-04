using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
	class Program
	{
		static void Main(string[] args)
		{
			string text = Console.ReadLine();
			Dictionary<char, int> pairs = new Dictionary<char, int>();
			for (int i = 0; i < text.Length; i++)
			{
				if (!pairs.ContainsKey(text[i]))
				{
					pairs.Add(text[i],1);
				}
				else
				{
					pairs[text[i]]++;
				}
			}
			foreach (var item in pairs.OrderBy(x=>x.Key))
			{
				Console.WriteLine($"{item.Key}: {item.Value} time/s");
			}
			
		}
	}
}
