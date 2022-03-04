using System;
using System.Linq;
public class Example
{
	public static void Main()
	{
		string type = Console.ReadLine();
		string firstValue = Console.ReadLine();
		string secondValue = Console.ReadLine();
		int saveValue = 0;
		int saveValue2 = 0;
		if (type == "int")
		{
			saveValue = int.Parse(firstValue);
			saveValue2 = int.Parse(secondValue);
		}
		else if (type == "string")
		{
			ConvertToIntValue(firstValue, secondValue, saveValue, saveValue2);

		}
		else if (type == "char")
		{
			ConvertToIntValue(firstValue, secondValue, saveValue, saveValue2);
		}
		PrintMaxValue(firstValue, secondValue, saveValue, saveValue2);
	}
	static void ConvertToIntValue(string firstValue, string secondValue, int saveValue, int saveValue2)
	{
		for (int i = 0; i < firstValue.Length; i++)
		{
			saveValue += firstValue[i];
		}
		for (int i = 0; i < secondValue.Length; i++)
		{
			saveValue2 += secondValue[i];
		}

	}
	static void PrintMaxValue(string firstValue, string secondValue, int saveValue, int saveValue2)
	{
		if (saveValue > saveValue2)
		{
			Console.WriteLine(firstValue);
		}
		else
		{
			Console.WriteLine(secondValue);
		}
	}

}