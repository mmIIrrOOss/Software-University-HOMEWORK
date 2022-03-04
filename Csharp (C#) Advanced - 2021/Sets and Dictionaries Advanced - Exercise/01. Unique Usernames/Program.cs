using System;
using System.Collections.Generic;
namespace _01._Unique_Usernames
{
	class Program
	{
		static void Main(string[] args)
		{
			HashSet<string> uniqueUsers = new HashSet<string>();
			int numUsers = int.Parse(Console.ReadLine());
			for (int i = 0; i < numUsers; i++)
			{
				string userName = Console.ReadLine();
				uniqueUsers.Add(userName);
			}
			foreach (var item in uniqueUsers)
			{
				Console.WriteLine(item);
			}
		}
	}
}
