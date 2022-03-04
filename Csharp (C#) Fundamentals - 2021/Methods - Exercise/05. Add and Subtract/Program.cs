using System;
using System.Linq;


namespace AddandSubtract
{

	class Program
	{

		private static void Main()
		{
			ReadThreNumbers();
		}

		public static void SubtractInSumNumbers(double firstNumbe, double secondNumber, double thirdNumber)
		{

			double sum = (firstNumbe + secondNumber) - thirdNumber;
			PrintSum(sum);

		}
		private static void ReadThreNumbers()
		{
			double firstNumber = double.Parse(Console.ReadLine());
			double secondNumber = double.Parse(Console.ReadLine());
			double thirdNumber = double.Parse(Console.ReadLine());
			SubtractInSumNumbers(firstNumber, secondNumber, thirdNumber);
		}
		private static void PrintSum(double sum)
		{
			Console.WriteLine(sum);
		}
	}
}

