using System;
using System.Linq;


namespace GFG
{

	class Program
	{

		private static void Main(string[] args)
		{
			double firstNumber = double.Parse(Console.ReadLine());
			string operators = Console.ReadLine();
			double secondNumber = double.Parse(Console.ReadLine());
			ChecAndPrintOperations(firstNumber, secondNumber, operators);
		}
		static void ChecAndPrintOperations(double firstNumber, double secondNumber, string operators)
		{
			double result = 0;
			if (operators == "+")
			{
				result = firstNumber + secondNumber;
			}
			else if (operators == "-")
			{
				result = firstNumber - secondNumber;
			}
			else if (operators == "*")
			{
				result = firstNumber * secondNumber;
			}
			else if (operators == "/")
			{
				result = firstNumber / secondNumber;
			}
			Console.WriteLine(result);
		}
	}
}







