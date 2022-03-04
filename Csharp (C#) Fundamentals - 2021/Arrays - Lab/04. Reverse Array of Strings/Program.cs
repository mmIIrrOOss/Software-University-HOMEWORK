using System;
using System.Linq;

public class Example
{
	public static void Main()
	{
		string[] randomstring = Console.ReadLine()
			.Split();
		for (int i = randomstring.Length - 1; i >= 0; i--)
		{
			Console.Write(randomstring[i] + " ");
		}


	}
}

