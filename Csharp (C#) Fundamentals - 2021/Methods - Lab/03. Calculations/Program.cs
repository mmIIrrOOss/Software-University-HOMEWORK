using System;
using System.Linq;
public class Example
{
	public static void Main()
	{

		string operations = Console.ReadLine();
		int firstNumber = int.Parse(Console.ReadLine());
		int secondNumber = int.Parse(Console.ReadLine());
		ChekNumbersOperations(operations, firstNumber, secondNumber);
	}
	static void ChekNumbersOperations(string operations, int firstNumber, int secondNumber)
	{
		if (operations == "subtract")
		{
			Console.WriteLine(firstNumber - secondNumber);
		}
		else if (operations == "divide")
		{
			Console.WriteLine(firstNumber / secondNumber);
		}
		else if (operations == "add")
		{
			Console.WriteLine(firstNumber + secondNumber);
		}
		else if (operations == "multiply")
		{
			Console.WriteLine(firstNumber * secondNumber);
		}
	}

}
