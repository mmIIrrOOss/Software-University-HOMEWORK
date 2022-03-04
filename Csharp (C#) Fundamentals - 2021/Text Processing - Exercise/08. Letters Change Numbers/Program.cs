using System;
using System.Collections.Generic;
using System.Linq;
namespace _08._Letters_Change_Numbers
{
	class Program
	{
		static void Main(string[] args)
		{
			List<char> alphabet = new List<char>()
			{'@','A','B','C','D','E','F','G','H','I','J','K','L','M'
			,'N','O','P','Q','R','S','T','U','V','W','X','Y','Z' };
			List<char> bet = new List<char>
			{
				'@','a','b','c','d','e','f','g','h','i','j','k','l','m'
				,'n','o','p','q','r','s','t','u','v','w','x','y','z'
			};

			double totalSum = 0;
			while (true)
			{

				string[] text = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
				if (text[0]=="End")
				{
					break;
				}
				for (int i = 0; i < text.Length; i++)
				{
					string word = text[i];
					string num = string.Empty;
					string neshto = string.Empty;
					foreach (var nums in word)
					{
						if (char.IsDigit(nums))
						{
							num += nums;
						}
						else
						{
							neshto += nums;
						}
					}
					double number = double.Parse(num);
					if (neshto[0] == char.ToUpper(neshto[0]))
					{
						int index = alphabet.IndexOf(neshto[0]);
						totalSum += number / index;
					}
					else
					{
						int index = bet.IndexOf(neshto[0]);
						totalSum += number * index;
					}
					if (neshto[1] == char.ToUpper(neshto[1]))
					{
						int index = alphabet.IndexOf(neshto[1]);
						totalSum -= index;
					}
					else
					{
						int index = bet.IndexOf(neshto[1]);
						totalSum += index;
					}

				}
			}
			Console.WriteLine($"{totalSum:f2}");

		}

	}
}
