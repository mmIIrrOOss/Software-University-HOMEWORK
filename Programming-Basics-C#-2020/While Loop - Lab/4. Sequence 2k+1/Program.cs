using System;

namespace ConsoleApp3
{
	class Program
	{
		static void Main(string[] args)
		{
			double number = double.Parse(Console.ReadLine());
			double k = 1;
			while (k <= number)
			{
				Console.WriteLine(k);
				k = k * 2 + 1;
			}

		}
	}
}
