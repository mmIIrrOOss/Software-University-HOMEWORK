using System;
using System.Collections.Generic;
using System.Linq;
namespace _02._Character_Multiplier
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] symbols = Console.ReadLine().Split().OrderByDescending(x => x.Length).ToArray();
			string str1 = symbols[0];
			string str2 = symbols[1];
			int totalSum = 0;
			int sum = 0;
			int counter = 0;
			if (str1.Length == str2.Length)
			{
				for (int i = 0; i < str1.Length; i++)
				{
					sum = str1[i] * str2[i];
					totalSum += sum;
				}
			}
			else
			{
				for (int i = 0; i < str2.Length; i++)
				{
					sum = str1[i] * str2[i];
					totalSum += sum;
					counter++;
				}
				if (counter==str2.Length)
				{
					for (int i = counter; i < str1.Length; i++)
					{
						totalSum += str1[i];
					}
				}
			}

			Console.WriteLine(totalSum);
		}

	}
}
