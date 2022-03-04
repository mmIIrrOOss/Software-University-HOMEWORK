using System;
using System.Linq;

public class Example
{
	public static void Main()
	{
		string random = Console.ReadLine();
		int n = int.Parse(Console.ReadLine());
		SeveralStrings(n, random);

	}
	static void SeveralStrings(int n, string random)
	{
		for (int i = 1; i <= n; i++)
		{
			Console.Write(random);
		}
	}


}


