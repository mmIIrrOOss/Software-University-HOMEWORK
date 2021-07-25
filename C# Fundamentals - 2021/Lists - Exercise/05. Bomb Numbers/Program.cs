using System;

namespace _05._Bomb_Numbers
{
	using System.Collections.Generic;
	using System.Linq;
	
	class Program
	{
		static void Main(string[] args)
		{
			List<string> numbers = Console.ReadLine().Split('|',StringSplitOptions.RemoveEmptyEntries).Reverse().ToList();
			string split = string.Join(" ",numbers);
			List<string> result = split.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
			Console.WriteLine(string.Join(" ",result));


			
		}
	}
}
