using System;

namespace _02._Center_Point
{
	class Program
	{
		static void Main(string[] args)
		{
			int x1 = int.Parse(Console.ReadLine());
			int y1 = int.Parse(Console.ReadLine());
			int x2 = int.Parse(Console.ReadLine());
			int y2 = int.Parse(Console.ReadLine());
			PrintDecard( x1,  y1, x2, y2);

		}
		static void PrintDecard(int x1, int y1, int x2, int y2)
		{
			int reuslt1 = Math.Abs(x1) + Math.Abs(y1);
			int reuslt2 = Math.Abs(x2) + Math.Abs(y2);
			if (reuslt1 > reuslt2)
			{
				Console.WriteLine($"({reuslt1})");
			}
			else
			{
				Console.WriteLine($"({reuslt2})");
			}
		}
	}
}
