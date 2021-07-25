using System;

namespace _01._Train
{
	using System.Collections.Generic;
	using System.Linq;
	class Program
	{
		static void Main()
		{
			List<int> numberTrains = Console.ReadLine().Split().Select(int.Parse).ToList();
			int capacity = int.Parse(Console.ReadLine());
			while (true)
			{

				string[] splitCommand = Console.ReadLine().Split();
				if (splitCommand[0] == "end")
				{
					break;
				}
				if (splitCommand[0] == "Add")
				{
					int passagers = int.Parse(splitCommand[1]);
					numberTrains.Add(passagers);
				}
				else
				{
					int parseNum = int.Parse(splitCommand[0]);
					for (int i = 0; i < numberTrains.Count; i++)
					{
						if ((numberTrains[i] + parseNum) <= capacity)
						{
							numberTrains[i] += parseNum;
							break;
						}

					}
				}

			}
			Console.WriteLine(string.Join(" ", numberTrains));
		}
	}
}
