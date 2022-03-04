using System;

namespace _04._Refactoring__Prime_Checker
{
	class Program
	{
		static void Main(string[] args)
		{
			int number = int.Parse(Console.ReadLine());
			for (int i = 2; i <= number; i++)
			{
				bool isPrime = true;
				for (int j = 2; j < i; j++)
				{
					if (i % j == 0)
					{
						isPrime = false;
						break;
					}
				}
				string toUpper = isPrime.ToString().ToLower();
				Console.WriteLine($"{i} -> {toUpper}");
			}
		}
	}

}
