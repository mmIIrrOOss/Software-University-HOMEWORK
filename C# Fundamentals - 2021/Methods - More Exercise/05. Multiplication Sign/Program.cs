using System;

namespace _05._Multiplication_Sign
{
	class Program
	{
		static void Main(string[] args)
		{
			int n1 = int.Parse(Console.ReadLine());
			int n2 = int.Parse(Console.ReadLine());
			int n3 = int.Parse(Console.ReadLine());
			ChekFromPositiveNegativeAndZero(n1, n2, n3);
		}

		private static void ChekFromPositiveNegativeAndZero(int n1, int n2, int n3)
		{
			if (n1<0||n2<0||n3<0)
			{
				Console.WriteLine("negative");
				return;
			}
			else if (n1==0||n2==0||n3==0)
			{
				Console.WriteLine("zero");
				return;
			}
			else
			{
				Console.WriteLine("positive");
				return;
			}
		}
	}
}
