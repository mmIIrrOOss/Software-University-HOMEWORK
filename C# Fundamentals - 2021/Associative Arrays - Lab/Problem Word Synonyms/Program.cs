using System;
using System.Collections.Generic;

namespace Problem_Word_Synonyms
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			var words = new Dictionary<string, List<string>>();
			for (int i = 0; i < n; i++)
			{
				string word = Console.ReadLine();
				string synonim = Console.ReadLine();

				if (words.ContainsKey(word) == false)
				{

					words.Add(word, new List<string>());
				}
				words[word].Add(synonim);
			}
			foreach (var item in words)
			{
				Console.WriteLine($"{item.Key} - {string.Join(", ",item.Value)}");
			}
		}
	}
}
