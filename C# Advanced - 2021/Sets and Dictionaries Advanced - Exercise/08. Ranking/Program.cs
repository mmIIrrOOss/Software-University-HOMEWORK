using System;
using System.Collections.Generic;
namespace _08._Ranking
{
	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, string> data = new Dictionary<string, string>();
			var bestCandidate = new Dictionary<string, Dictionary<string, int>>();
			Dictionary<string, int> listdata = new Dictionary<string, int>();
			var listResult = new Dictionary<string, int>();
			while (true)
			{
				string command = Console.ReadLine();
				if (command == "end of contests")
				{
					break;
				}
				string[] split2 = command.Split(':');
				string cours = split2[0];
				string pass = split2[1];
				data.Add(cours, pass);
			}
			while (true)
			{
				string command = Console.ReadLine();
				if (command == "end of submissions")
				{
					break;
				}
				string[] split = command.Split("=>");
				string cours = split[0];
				string pass = split[1];
				string name = split[2];
				int scores = int.Parse(split[3]);
				if (data.ContainsKey(cours))
				{
					if (data[cours].ContainsKey(pass))
					{
						if (!data.ContainsKey(name))
						{
							data2.Add(name, new Dictionary<string, int>());
							listResult.Add(name, scores);
							bestCandidate[user].Add(contest, points);
						}
						else if (bestCandidate.ContainsKey(user))
						{
							// MISSING VALIDATION
							//Save the user with the contest they take part in
							//(a user can take part in many contests) and the points
							//the user has in the given contest.If you receive the same
							//contest and the same user update the points only if the new ones are
							//more than the older ones.
						}
						else if (!bestCandidate[user].ContainsKey(contest))
						{
							bestCandidate[user].Add(contest, points);
							listResult[user] += points;
						}
					}
				}
			}
		}
	}

}
