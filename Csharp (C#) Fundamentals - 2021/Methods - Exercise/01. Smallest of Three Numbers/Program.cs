using System;
using System.Linq;


namespace GFG
{

	class Program
	{

		private static void Main(string[] args)
		{
			double firstNumber = double.Parse(Console.ReadLine());//10
			double secondNumber = double.Parse(Console.ReadLine());//5
			double thirdNumber = double.Parse(Console.ReadLine());//2
			double minOne = Math.Min(firstNumber, secondNumber);
			double minTwo = Math.Min(minOne, thirdNumber);
			ChekAndPrintSmalNums(minOne, minTwo);
		}
		public static void ChekAndPrintSmalNums(double minOne, double minTwo)
		{
			if (minOne < minTwo)
			{
				Console.WriteLine(minOne);
			}
			else
			{
				Console.WriteLine(minTwo);
			}
		}

	}
}







