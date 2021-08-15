using System;
using System.Collections.Generic;
using System.Linq;
namespace _07._Predicate_For_Names
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			Predicate<string> isValid = x => x.Length <= n;
			List <string> isValids= Console.ReadLine()
				.Split()
				.Where(x => isValid(x))
				.ToList();
			Console.WriteLine(string.Join(Environment.NewLine,isValids));
		}
	}
}
