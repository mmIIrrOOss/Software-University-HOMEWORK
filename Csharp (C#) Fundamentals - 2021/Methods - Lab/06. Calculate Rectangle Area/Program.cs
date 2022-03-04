using System;
using System.Linq;

public class Example
{
	public static void Main()
	{
		double width = double.Parse(Console.ReadLine());
		double height = double.Parse(Console.ReadLine());
		PrintArea(width, height);

	}
	static void PrintArea(double width, double height)
	{
		double result = width * height;
		Console.WriteLine(result);
	}


}


