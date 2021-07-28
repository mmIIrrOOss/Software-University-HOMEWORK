using System;
using System.Collections.Generic;
using System.Linq;


namespace _01._Messaging
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
			string messsage = Console.ReadLine();
			for (int i = 0; i < numbers.Count; i++)
			{
				int currentNumber = numbers[i];
				int index = CalculateIndex(currentNumber);

				char currentChar = GetCharFromMessage(index, messsage);
				Console.Write(currentChar);

				int realIndex = CalculateRealIndex(index,messsage);
				string newMessage = messsage.Remove(realIndex, 1);
				messsage = newMessage;
			}
			Console.WriteLine();
		}

		private static int CalculateRealIndex(int index, string messsage)
		{
			int countiNdex = 0;
			for (int i = 0; i < index; i++)
			{
				countiNdex++;
				if (countiNdex==messsage.Length)
				{
					countiNdex = 0;
				}
			}
			return countiNdex;
		}

		private static char GetCharFromMessage(int index, string messsage)
		{
			int countIndex = 0;
			for (int i = 0; i < index; i++)
			{
				countIndex++;
				if (countIndex==messsage.Length)
				{
					countIndex = 0;
				}
			}
			char currentChar = messsage[countIndex];
			return currentChar;
		}

		private static int CalculateIndex(int number)
		{
			int index = 0;
			while (number > 0)
			{
				int currentNumber = number % 10;
				index += currentNumber;
				number /= 10;
			}
			return index;
		}
	}
}
