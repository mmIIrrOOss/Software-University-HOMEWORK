using System;
using System.Linq;

public class Example
{
	public static void Main()
	{
		int numOfTrains = int.Parse(Console.ReadLine());
		int[] sumOfPeople = new int[numOfTrains];
		int sum = 0;
		for (int i = 0; i < sumOfPeople.Length; i++)
		{
			sumOfPeople[i] = int.Parse(Console.ReadLine());
			sum += sumOfPeople[i];
		}
		Console.WriteLine($"{string.Join(" ", sumOfPeople)}");
		Console.Write($"{sum}");


	}
}

