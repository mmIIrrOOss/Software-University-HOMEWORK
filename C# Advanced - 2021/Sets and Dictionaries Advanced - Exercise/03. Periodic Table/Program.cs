using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			HashSet<string> saveElements = new HashSet<string>();
			for (int i = 0; i < n; i++)
			{
				var elements = Console.ReadLine().Split();
			}
			Console.WriteLine(string.Join(" ",saveElements.OrderBy(x=>x)));
		}
	}
}
