using System;
using System.Collections.Generic;
using System.Linq;
namespace _01._Count_Real_Numbers
{
	class Program
	{
		static void Main(string[] args)
		{

			//var fruits = new Dictionary<string, double>();
			//fruits["orange"] = 2.20;
			//fruits["apple"] = 1.40;
			//fruits["kiwi"] = 3.20;
			//foreach (var item in fruits)
			//{
			//	Console.WriteLine($"Fruits {item.Key} ==> ${item.Value:f2} price.");
			//}
			//Console.WriteLine();
			//var sortedDict = fruits.OrderByDescending(s=>s.Value+20).Where(s=>s.Value>2);
			//foreach (var item in sortedDict)
			//{
			//	Console.WriteLine($"sorted by {item.Key} ==> ${item.Value:f2} price.");
			//}

			string[] words = Console.ReadLine()
				.Split();
			var result = words.Select(w => w.ToString()+"x").ToArray();
			Console.WriteLine(string.Join(" ",result));
		}
	}
}
