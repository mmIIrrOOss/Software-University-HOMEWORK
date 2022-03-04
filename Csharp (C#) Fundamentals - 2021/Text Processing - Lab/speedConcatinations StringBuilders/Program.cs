using System;
using System.Diagnostics;
using System.Text;

namespace speedConcatinations_StringBuilders
{
	class Program
	{
		static void Main(string[] args)
		{
			StringBuilder sb = new StringBuilder();
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			for (int i = 0; i < 50000; i++)
			{
				sb.Append(i);
			}
			Console.WriteLine(stopwatch.ElapsedMilliseconds);
			string em = string.Empty;
			new Stopwatch().Start();
			for (int i = 0; i < 50000; i++)
			{
				em += i;
			}
			Console.WriteLine(stopwatch.ElapsedMilliseconds);
		}
	}
}
