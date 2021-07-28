using System;
using System.Numerics;

namespace _02._Big_Factorial
{
	class Program
	{
		static void Main(string[] args)
		{
			int N = int.Parse(Console.ReadLine());
			BigInteger factoriel = 1;
			for (int i = 1; i <=N; i++)
			{
				factoriel *= i;
			}
			Console.WriteLine(factoriel);
		}
	}
}
