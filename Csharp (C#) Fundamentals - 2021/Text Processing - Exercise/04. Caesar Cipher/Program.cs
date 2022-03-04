using System;
using System.Collections.Generic;
using System.Linq;
namespace _04._Caesar_Cipher
{
	class Program
	{
		static void Main(string[] args)
		{
			string text = Console.ReadLine();
			string add = string.Empty;
			for (int i = 0; i < text.Length; i++)
			{
				char word = text[i];
				word += (char)3;
				add += word;
			}
			Console.WriteLine(add);

		}
	}
}
