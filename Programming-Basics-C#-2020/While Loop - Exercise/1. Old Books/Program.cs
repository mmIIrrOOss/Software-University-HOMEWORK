using System;

namespace ConsoleApp3
{
	class Program
	{
		static void Main(string[] args)
		{
			string favoriteBook = Console.ReadLine();
			int countBook = 0;
			bool isFound = false;
			string nextBookNmaes = Console.ReadLine();
			while (nextBookNmaes != "No More Books")
			{
				countBook++;
				nextBookNmaes = Console.ReadLine();
				if (nextBookNmaes == favoriteBook)
				{
					isFound = true;
					break;
				}
			}
			if (isFound)
			{
				Console.WriteLine($"You checked {countBook} books and found it.");
			}
			else
			{
				Console.WriteLine("The book you search is not here!");
				Console.WriteLine($"You checked {countBook} books.");
			}


		}
	}
}
