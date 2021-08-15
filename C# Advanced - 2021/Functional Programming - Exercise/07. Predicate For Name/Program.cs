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
			Predicate<string> filterByLengh = x => x.Length <= n;
			Console.ReadLine()
			   .Split()
			   .Where(s => filterByLengh(s))
			   .ToList()
			   .ForEach(Console.WriteLine);
			
		} 
	}
}
