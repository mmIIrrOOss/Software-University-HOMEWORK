using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, Dictionary<string, HashSet<string>>> insta = new Dictionary<string, Dictionary<string, HashSet<string>>>();
			while (true)
			{
				string[] data = Console.ReadLine().Split();
				string vlogger = data[0];
				if (data[0] == "Statistics")
				{
					break;
				}
				string command = data[1];
				if (command.Contains("joined"))
				{
					if (insta.ContainsKey(vlogger) == false)
					{
						insta.Add(vlogger, new Dictionary<string, HashSet<string>>());
						insta[vlogger].Add("followers", new HashSet<string>());
						insta[vlogger].Add("following", new HashSet<string>());
					}

				}
				else if (command.Contains("followed"))
				{
					string member = data[2];
					if (vlogger != member && insta.ContainsKey(vlogger) && insta.ContainsKey(member))
					{
						insta[vlogger]["following"].Add(member);
						insta[member]["followers"].Add(vlogger);
					}
				}
			}
			int count = 1;
			Console.WriteLine($"The V-Logger has a total of {insta.Count} vloggers in its logs.");
			foreach (var vlogger in insta.OrderByDescending(v => v.Value["followers"].Count).ThenBy(v => v.Value["following"].Count))
			{
				Console.WriteLine($"{count}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");

				if (count == 1)
				{
					foreach (string follower in vlogger.Value["followers"].OrderBy(f => f))
					{
						Console.WriteLine($"*  {follower}");
					}
				}

				count++;
			}

		}
	}
}
