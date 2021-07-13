using System;

namespace single_exam
{
	class Program
	{
		static void Main(string[] args)
		{
			double number = double.Parse(Console.ReadLine());
			double times = double.Parse(Console.ReadLine());
			do
			{
				Console.WriteLine($"{number} X {times} = {number * times}");
				times++;
			} while (times <= 10);
		}
	}
}
