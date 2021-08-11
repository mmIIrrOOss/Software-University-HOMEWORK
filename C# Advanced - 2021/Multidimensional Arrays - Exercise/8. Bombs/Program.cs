using System;
using System.Linq;
namespace _8._Bombs
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			int[,] matrix = new int[n, n];
			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					matrix[row, col] = arr[col];
				}
			}
			int[] coordinates = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
		}
	}
}
