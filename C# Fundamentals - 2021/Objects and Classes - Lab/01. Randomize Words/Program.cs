using System;

namespace _01._Randomize_Words
{

	using System.Text;
	using System.Collections.Generic;
	using System.Linq;
	class Program
	{
		static void Main(string[] args)
		{
			

			List<string> elements = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList();
			Random rnd = new Random();
			for (int i = 0; i < elements.Count; i++)
			{
				int pos2 = rnd.Next(0,elements.Count);
				var a = elements[pos2];
				var b = elements[i];
				elements[pos2] = b;
				elements[i] = a;
			}
			Console.WriteLine(string.Join('\n',elements));
			
			
		}
		
	}
}

