using System;

public class Program
{
	public static void Main()
	{

		double convert = double.Parse(Console.ReadLine());
		double inchestosant = convert * 2.54;
		Console.WriteLine(inchestosant);
	}
}