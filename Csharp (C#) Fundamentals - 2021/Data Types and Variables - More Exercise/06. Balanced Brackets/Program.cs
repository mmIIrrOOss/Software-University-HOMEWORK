using System;

namespace _06._Balanced_Brackets
{
	class Program
	{
		static void Main(string[] args)
		{
			int lines = int.Parse(Console.ReadLine());
			byte count = 0;
			byte secondCount = 0;
			for (int i = 1; i <=lines; i++)
			{
				string text = Console.ReadLine();
				if (text=="(")
				{
					count++;
				}
				else if (text==")")
				{
					secondCount++;
					if (count - secondCount != 0)
					{
						Console.WriteLine("UNBALANCED");
						return;
					}
				}
			}
			if (count==secondCount)
			{
				Console.WriteLine("BALANCED");
			}
			else
			{
				Console.WriteLine("UNBALANCED");
			}
		}
	}
}
