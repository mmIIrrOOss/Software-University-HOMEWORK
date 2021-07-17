using System;

namespace _05._Decrypting_Message
{
	class Program
	{
		static void Main(string[] args)
		{
			int key = int.Parse(Console.ReadLine());
			int lines = int.Parse(Console.ReadLine());
			int sumASCIINum = 0;
			string message = "";
			for (int i = 0; i < lines; i++)
			{
				char symbols = char.Parse(Console.ReadLine());
				sumASCIINum = key + symbols;
				message += Convert.ToChar(sumASCIINum);
			}
			Console.WriteLine(message);
		}
	}
}
