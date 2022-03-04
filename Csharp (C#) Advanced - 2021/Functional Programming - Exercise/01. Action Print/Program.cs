using System;
using System.Collections.Generic;
namespace _01._Action_Print
{
	class Program
	{
		static void Main()
		{
			string[] names = Console.ReadLine().Split(" ");
			Action<string[]> printNames = names => Console.WriteLine(string.Join(Environment.NewLine,names));
			printNames(names);
		}
	}
}
