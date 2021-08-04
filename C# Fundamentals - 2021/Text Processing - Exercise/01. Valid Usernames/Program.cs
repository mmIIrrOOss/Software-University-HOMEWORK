using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01._Valid_Usernames
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] userNames = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
				.ToArray();
			bool isValid = false;
			int count = 0;
			for (int i = 0; i < userNames.Length; i++)
			{
				string user = userNames[i];
				if (user.Length >= 3 && user.Length <= 16)
				{
					count = 0;
					foreach (var item in user)
					{
						if (char.IsLetterOrDigit(item) || item == '-' || item == '_')
						{
							count++;
						}
					}
				}
				if (count == user.Length)
				{
					Console.WriteLine(user);
				}
			}
		}
	}
}
