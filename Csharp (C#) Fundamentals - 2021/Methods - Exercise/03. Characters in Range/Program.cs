using System;
using System.Linq;


namespace GFG
{

	class Program
	{

		private static void Main(string[] args)
		{
			char startSymbols = char.Parse(Console.ReadLine());
			char endSymbols = char.Parse(Console.ReadLine());

			if (startSymbols < endSymbols)
			{
				for (int i = startSymbols + 1; i < endSymbols; i++)
				{
					char convertSymbol = Convert.ToChar(i);
					Console.Write(convertSymbol + " ");

				}
			}
			else
			{
				for (int j = endSymbols + 1; j < startSymbols; j++)
				{
					char convertSymbol = Convert.ToChar(j);
					Console.Write(convertSymbol + " ");

				}
			}




		}

	}
}







