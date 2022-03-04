using System;

namespace _01._Encrypt__Sort_and_Print_Array
{
	class Program
	{
		static void Main(string[] args)
		{

			int lines = int.Parse(Console.ReadLine());
			char[] vowel = { 'a', 'e', 'i', 'o', 'y', 'u' };
			int vowelsum = 0;
			int cantvowel = 0;
			int[] saveScores = new int[lines];
			for (int i = 0; i < lines; i++)
			{
				string random = Console.ReadLine();
				int sum = 0;
				for (int j = 0; j < random.Length; j++)
				{
					char symbol = Convert.ToChar(random[j]);
					switch (symbol)
					{
						case 'a':
						case 'A':
						case 'o':
						case 'O':
						case 'e':
						case 'E':
						case 'i':
						case 'I':
						case 'u':
						case 'U':
							sum += symbol * random.Length;
							break;
						default:
							sum += symbol / random.Length;
							break;
					}
				}
				saveScores[i] = sum;
				sum = 0;

			}
			Array.Sort(saveScores);
			foreach (var elements in saveScores)
			{
				Console.WriteLine(elements);
			}
		}
	}
}
