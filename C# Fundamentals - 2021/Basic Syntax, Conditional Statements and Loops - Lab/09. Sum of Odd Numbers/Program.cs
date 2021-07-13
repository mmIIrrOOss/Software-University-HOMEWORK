using System;

namespace single_exam
{
	class Program
	{
		static void Main(string[] args)
		{
			double n = double.Parse(Console.ReadLine());
			double sum = 0;
			for (int i = 1; i <= n; i++)
			{
				Console.WriteLine($"{2 * i - 1}");
				sum += 2 * i - 1;
			}
			Console.WriteLine($"Sum: {sum}");
		}
	}
}
