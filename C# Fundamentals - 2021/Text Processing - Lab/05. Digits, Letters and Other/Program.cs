using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Digits__Letters_and_Other
{
	class Program
	{
		static void Main(string[] args)
		{
			string text = Console.ReadLine();
			string isDigit = string.Empty;
			string isLetters = string.Empty;
			string isSymbols = string.Empty;
			for (int i = 0; i < text.Length; i++)
			{
				if (char.IsDigit(text[i]))
				{
					isDigit += text[i];
				}
				else if (char.IsLetter(text[i]))
				{
					isLetters += text[i];
				}
				else 
				{
					isSymbols += text[i];
				}
			}
			Console.WriteLine(isDigit);
			Console.WriteLine(isLetters);
			Console.WriteLine(isSymbols);
		}
	}
}
