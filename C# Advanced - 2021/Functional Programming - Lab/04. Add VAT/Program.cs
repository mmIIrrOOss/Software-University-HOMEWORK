using System;
using System.Linq;

namespace _04._Add_VAT
{
	class Program
	{
		static void Main(string[] args)
		{
			double[] numbers = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(double.Parse)
				.Select(x =>Math.Round(x += x * 0.20,2))
				.ToArray();
			Console.WriteLine(string.Join(" ",numbers));	
		}
	}
}
