using System;
using System.Linq;


namespace AddandSubtract
{

	class Program
	{

		private static void Main()
		{
			int firstNumber = int.Parse(Console.ReadLine());
			int secondNumber = int.Parse(Console.ReadLine());
			long firstFactoriel = GetFactoriel1(firstNumber);
			long secondFactoriel = GetFactoriel2(secondNumber);
			double result = firstFactoriel * 1.0 / secondFactoriel;
			Console.WriteLine($"{result:f2}");
		}

		private static long GetFactoriel1(int firstNumber)
		{
			long one = 1;
			for (int i = 1; i <= firstNumber; i++)
			{
				one = one *= i;
			}
			return one;

		}
		private static long GetFactoriel2(int secondNumber)
		{
			long two = 1;
			for (int i = 1; i <= secondNumber; i++)
			{
				two = two *= i;
			}
			return two;
		}


	}
}








