using System;
using System.Linq;
class Vacation
{
	static void Main()
	{
		string userName = Console.ReadLine();
		string password = string.Concat(userName.Reverse());
		int countLogin = 0;
		while (true)
		{
			string pass = Console.ReadLine();
			countLogin++;
			if (pass == password)
			{
				break;
			}
			else if (countLogin >= 4)
			{
				Console.WriteLine($"User {userName} blocked!");
				return;
			}
			else
			{
				Console.WriteLine($"Incorrect password. Try again.");
			}
		}
		Console.WriteLine($"User {userName} logged in.");
	}
}