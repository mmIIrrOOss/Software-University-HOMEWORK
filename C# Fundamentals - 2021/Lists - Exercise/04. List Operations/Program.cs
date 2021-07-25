using System;
namespace _04._List_Operations
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
				string[] command = Console.ReadLine().Split();
				if (command[0] == "End")
				{
					break;
				}
				if (command[0] == "Add")
				{
					int num = int.Parse(command[1]);
					number.Add(num);
				}
				else if (command[0] == "Insert")
				{
					int num  = Math.Abs(int.Parse(command[1]));
					int index =Math.Abs(int.Parse(command[2]));
					if (index >= 0 && index < number.Count)
					{
						number.Insert(index, num);
					}
					else
					{
						Console.WriteLine("Invalid index");
					}
				}
				else if (command[0] == "Remove")
				{
					int index = Math.Abs(int.Parse(command[1]));
					if (index >= 0 && index < number.Count)
					{
						number.RemoveAt(index);

					}
					else
					{
						Console.WriteLine("Invalid index");
					}
				}
				else if (command[1] == "left")
				{
					int index = Math.Abs(int.Parse(command[2]));
					int saveNumPOsition = number[index];
					for (int i = 0; i < index % number.Count; i++)
					{
						int firstNum = number[0];
						number.Add(firstNum);
						number.RemoveAt(0);
					}
				}
				else if (command[1] == "right")
				{
					int index =Math.Abs(int.Parse(command[2]));
					for (int i = 0; i < index % number.Count; i++)
					{
						int lastNum = number[number.Count - 1];
						number.Insert(0, lastNum);
						number.RemoveAt(number.Count - 1);
					}
				}
			}
			Console.WriteLine(string.Join(" ", number));
		}
	}
}
