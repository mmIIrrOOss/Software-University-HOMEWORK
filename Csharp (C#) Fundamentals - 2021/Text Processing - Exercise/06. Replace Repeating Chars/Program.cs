using System;

namespace _06._Replace_Repeating_Chars
{
	class Program
	{
		static void Main(string[] args)
		{
			string random = Console.ReadLine();
			char lastSymbol = ' ';
			string word = string.Empty;
			for (int i = 0; i < random.Length; i++)
			{
				char symbol = random[i];
				if (symbol!=lastSymbol)
				{
					word += symbol;
					lastSymbol = symbol;
				}
			}
			Console.WriteLine(word);


		}
	}
}
