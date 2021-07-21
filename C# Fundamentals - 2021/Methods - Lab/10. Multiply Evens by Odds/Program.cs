using System;
using System.Linq;
public class Example
{
	public static void Main()
	{

		string numbers = Console.ReadLine();
		char[] symbol = numbers.ToCharArray();
		ChekNumbers(numbers, symbol);
	}
	static void ChekNumbers(string numbers, char[] symbol)
	{
		int oddSum = 0;
		int evenSum = 0;
		for (int i = 0; i < numbers.Length; i++)
		{
			string str = symbol[i].ToString();
			if (str == "-")
			{
				continue;
			}
			int n = int.Parse(str);
			if (n % 2 == 0)
			{
				evenSum += n;
			}
			else
			{
				oddSum += n;
			}
		}
		int result = oddSum * evenSum;
		Console.WriteLine(result);

	}

}
