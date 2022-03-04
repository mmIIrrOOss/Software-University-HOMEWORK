using System;
using System.Collections.Generic;
using System.Linq;
namespace _02._Knights_of_Honor
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] names = Console.ReadLine()
				.Split()
				.Select(x => $"Sir {x}")
				.ToArray();
			Console.WriteLine(string.Join(Environment.NewLine,names));
		}
	}
}
