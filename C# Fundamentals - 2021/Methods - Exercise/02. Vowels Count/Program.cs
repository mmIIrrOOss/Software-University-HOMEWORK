using System;
using System.Linq;


namespace GFG
{

	class Program
	{

		private static void Main(string[] args)
		{
			string random = Console.ReadLine();
			string toLower = random.ToLower();
			char[] isVowels = { 'a', 'e', 'i', 'o', 'u', 'y' };
			byte count = 0;
			for (int i = 0; i < toLower.Length; i++)
			{
				for (int j = 0; j < isVowels.Length; j++)
				{
					char symbols = Convert.ToChar(isVowels[j]);
					//char symbols2 = Convert.ToChar(isVowels[j]);

					if (toLower[i] == isVowels[j])
					{
						count++;
					}
				}
			}
			Console.WriteLine(count);
		}


	}
}







