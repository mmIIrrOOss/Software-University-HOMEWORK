using System;

namespace _02._Change_List
{
	using System.Collections.Generic;
	using System.Linq;
	class Program
	{
		static void Main()
		{
			List<int> number = Console.ReadLine().Split().Select(int.Parse).ToList();

			while (true)
			{

				string[] splitCommand = Console.ReadLine().Split();
				if (splitCommand[0] == "end")
				{
					break;
				}
				if (splitCommand[0] == "Delete")
				{
					int splitNum = int.Parse(splitCommand[1]);
					while (number.Contains(splitNum))
					{
						number.Remove(splitNum);
					}
				}
				else if (splitCommand[0] == "Insert")
				{
					int parseNum = int.Parse(splitCommand[1]);
					int index = int.Parse(splitCommand[2]);
					number.Insert(index, parseNum);
				}

			}
			Console.WriteLine(string.Join(" ", number));
		}
	}
}
