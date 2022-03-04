using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
	class Program
	{
		static void Main(string[] args)
		{
			var numLines = Console.ReadLine().Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
			var m = numLines[0];
			var n = numLines[1];
			var nSet = new HashSet<double>();
			var mSet = new HashSet<double>();
			for (int i = 0; i < m; i++)
			{
				var num = double.Parse(Console.ReadLine());
				nSet.Add(num);
			}
			for (int i = 0; i < n; i++)
			{
				var num = double.Parse(Console.ReadLine());
				mSet.Add(num);
			}
			nSet.IntersectWith(mSet);
			Console.WriteLine(string.Join(" ",nSet));
		}
	}
}
