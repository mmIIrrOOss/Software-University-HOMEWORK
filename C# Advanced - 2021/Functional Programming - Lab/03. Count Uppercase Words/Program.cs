using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
	class Program
	{
		static void Main(string[] args)
		{
			Func<string, bool> upper = text => char.IsUpper(text[0]);
			string text = Console.ReadLine();
			string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
			words = words.Where(upper).ToArray();
			foreach (var item in words)
			{
				Console.WriteLine(item);
			}
				
		}
		
	}
}
