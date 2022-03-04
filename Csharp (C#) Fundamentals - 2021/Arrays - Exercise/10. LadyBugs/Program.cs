using System;
using System.Linq;

public class Example
{
	public static void Main()
	{
		int fieldSize = int.Parse(Console.ReadLine());
		int[] initialIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
		int[] field = new int[fieldSize];
		for (int i = 0; i < initialIndexes.Length; i++)
		{
			int currentIndex = initialIndexes[i];
			if (currentIndex >= 0 && currentIndex < field.Length)
			{
				field[currentIndex] = 1;

			}
		}
		string command = string.Empty;
		while ((command = Console.ReadLine()) != "end")
		{
			string[] elements = command.Split();
			int ladyBugsIndex = int.Parse(elements[0]);
			string direction = elements[1];
			int flyLenght = int.Parse(elements[2]);
			if (ladyBugsIndex < 0 || ladyBugsIndex > field.Length - 1 || field[ladyBugsIndex] == 0)
			{
				continue;
			}
			field[ladyBugsIndex] = 0;


			if (direction == "right")
			{
				int landIndex = ladyBugsIndex + flyLenght;

				if (landIndex > field.Length - 1)
				{
					continue;
				}
				if (field[landIndex] == 1)
				{
					while (field[landIndex] == 1)
					{
						landIndex += flyLenght;
						if (landIndex > field.Length - 1)
						{
							break;
						}
					}
				}
				if (landIndex >= 0 && landIndex <= field.Length - 1)
				{

					field[landIndex] = 1;
				}
			}
			else if (direction == "left")
			{
				int landIndex = ladyBugsIndex - flyLenght;
				if (landIndex < 0)
				{
					continue;
				}
				if (field[landIndex] == 1)
				{
					while (field[landIndex] == 1)
					{
						landIndex -= flyLenght;
						if (landIndex < 0)
						{
							break;
						}
					}
				}
				if (landIndex >= 0 && landIndex <= field.Length - 1)
				{

					field[landIndex] = 1;
				}
			}


		}

		Console.WriteLine(string.Join(' ', field));
	}
}

