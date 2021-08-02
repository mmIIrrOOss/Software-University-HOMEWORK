using System;

namespace _01._Count_Chars_in_a_String
{
	using System.Collections.Generic;
	using System.Linq;
	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<char, int> countChars = new Dictionary<char, int>();
			string text = Console.ReadLine();
			for (int i = 0; i < text.Length; i++)
			{
				if (!(countChars.ContainsKey(text[i])))
				{
					if (text[i]==' ')
					{
						continue;
					}
					countChars.Add(text[i], 1);
					continue;
				}
				countChars[text[i]]++;
			}
			foreach (var chars in countChars)
			{
				Console.WriteLine($"{chars.Key} -> {chars.Value}");
			}

		}
	}
}
