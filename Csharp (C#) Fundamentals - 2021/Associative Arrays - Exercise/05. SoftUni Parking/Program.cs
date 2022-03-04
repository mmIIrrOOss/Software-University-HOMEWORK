using System;
using System.Collections.Generic;
using System.Linq;
namespace _05._SoftUni_Parking
{
	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, string> saveUser = new Dictionary<string, string>();
			int n = int.Parse(Console.ReadLine());
			for (int i = 0; i < n; i++)
			{
				string[] commands = Console.ReadLine().Split();
				string userName = commands[1];
				if (commands[0] == "register")
				{
					string licenseNumber = commands[2];
					if (!saveUser.ContainsKey(userName))
					{
						saveUser.Add(userName, licenseNumber);
						Console.WriteLine($"{userName} registered {licenseNumber} successfully");
					}
					else
					{
						Console.WriteLine($"ERROR: already registered with plate number {licenseNumber}");
					}
				}
				else if (commands[0] == "unregister")
				{
					if (!saveUser.ContainsKey(userName))
					{
						Console.WriteLine($"ERROR: user {userName} not found");
					}
					else
					{
						saveUser.Remove(userName);
						Console.WriteLine($"{userName} unregistered successfully");
					}
				}

			}
			foreach (var user in saveUser)
			{
				Console.WriteLine($"{user.Key} => {user.Value}");
			}
		}
	}
}
