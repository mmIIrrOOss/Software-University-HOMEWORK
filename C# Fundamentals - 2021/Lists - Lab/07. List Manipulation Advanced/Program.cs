using System;

namespace _07._List_Manipulation_Advanced
{
	using System.Collections.Generic;
	using System.Linq;
	class Program
	{
		static void Main(string[] args)
		{
			List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
			bool change = false;
			while (true)
			{
				string command = Console.ReadLine();
				if (command == "end")
				{
					break;
				}
				string[] splitCommand = command.Split( );
				if (splitCommand[0] == "Add")
				{
					int parse = int.Parse(splitCommand[1]);
					numbers.Add(parse);
					change = true;
				}
				else if (splitCommand[0] == "Remove")
				{
					numbers.Remove(int.Parse(splitCommand[1]));
					change = true;
				}
				else if (splitCommand[0] == "RemoveAt")
				{
					numbers.RemoveAt(int.Parse(splitCommand[1]));
					change = true;
				}
				else if (splitCommand[0] == "Insert")
				{
					numbers.Insert(int.Parse(splitCommand[2]), int.Parse(splitCommand[1]));
					change = true;
				}
				if (splitCommand[0] == "Contains")
				{
					int num = int.Parse(splitCommand[1]);
					if (numbers.Contains(num))
					{
						Console.WriteLine("Yes");
					}
					else
					{
						Console.WriteLine("No such number");
					}
				}
				else if (splitCommand[0] == "PrintEven")
				{
					List<int> evenNumbers = new List<int>();
					for (int i = 0; i < numbers.Count; i++)
					{
						if (numbers[i] % 2 == 0)
						{
							evenNumbers.Add(numbers[i]);
						}
					}
					Console.WriteLine(string.Join(" ", evenNumbers));
				}
				else if (splitCommand[0] == "PrintOdd")
				{
					List<int> OddNumbers = new List<int>();
					for (int i = 0; i < numbers.Count; i++)
					{
						
						if (numbers[i] % 2 !=0)
						{
							OddNumbers.Add(numbers[i]);
						}
					}
					Console.WriteLine(string.Join(" ", OddNumbers));
				}
				else if (splitCommand[0] == "GetSum")
				{
					int getSumOldNumbers = 0;
					for (int i = 0; i < numbers.Count; i++)
					{
						getSumOldNumbers += numbers[i];
					}
					Console.WriteLine(getSumOldNumbers);
				}
				else if (splitCommand[0] == "Filter")
				{
					string getFirstOperator = splitCommand[1];
					int parseNum = int.Parse(splitCommand[2]);//43
					if (getFirstOperator == "<")
					{
						List<int> n = new List<int>();
						for (int i = 0; i < numbers.Count; i++)
						{
							if (numbers[i] < parseNum)
							{
								n.Add(numbers[i]);

							}
						}
						Console.WriteLine(string.Join(" ", n));
					}
					else if (getFirstOperator == ">")
					{
						List<int> n = new List<int>();
						for (int i = 0; i < numbers.Count; i++)
						{
							
							if (numbers[i] > parseNum)
							{
								n.Add(numbers[i]);
							}

						}
						Console.WriteLine(string.Join(" ", n));

					}
					else if (getFirstOperator == "<=")
					{
						List<int> n = new List<int>();
						for (int i = 0; i < numbers.Count; i++)
						{
							
							if (numbers[i] <= parseNum)
							{
								n.Add(numbers[i]);
							}
							
						}
						Console.WriteLine(string.Join(" ",n));
					}
					else if (getFirstOperator == ">=")
					{
						List<int> n = new List<int>();

						for (int i = 0; i < numbers.Count; i++)
						{
							
							if (numbers[i] >= parseNum)
							{
								n.Add(numbers[i]);
							}
							
						}
						Console.WriteLine(string.Join(" ", n));
					}
				}
			}
			if (change==true)
			{
				Console.WriteLine(string.Join(" ",numbers));
			}
		}
	}
}
