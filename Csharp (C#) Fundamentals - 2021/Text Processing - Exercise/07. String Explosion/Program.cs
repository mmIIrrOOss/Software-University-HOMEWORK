using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._String_Explosion
{
	class Program
	{
		static void Main(string[] args)
		{
			string random = Console.ReadLine();
			string save = string.Empty;
			int counter = 0;
			for (int i = 0; i < random.Length; i++)
			{
				char symbol = random[i];
				char digit = random[i];
				if (char.IsDigit(digit) && (counter != digit||counter==digit))
				{
					int parse = Convert.ToInt32(digit.ToString());
					counter++;
					continue;
				}
				if (char.IsLetter(symbol)||symbol=='>')
				{

					save += symbol;
				}
				counter = 0;
			}
			Console.WriteLine(save);
		}
	}
}
