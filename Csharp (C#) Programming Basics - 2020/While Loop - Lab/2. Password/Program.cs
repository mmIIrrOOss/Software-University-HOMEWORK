using System;

namespace ConsoleApp3
{
	class Program
	{
		static void Main(string[] args)
		{
			string userNmae = Console.ReadLine();
			string password = Console.ReadLine();
			string rePasssword = Console.ReadLine();
			while (rePasssword != password)
			{
				rePasssword = Console.ReadLine();
			}
			Console.WriteLine($"Welcome {userNmae}!");


		}
	}
}
