using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
	class Program4
	{
		static void Main(string[] args)
		{
			int[] n = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
			int[,] matrix = new int[n[0], n[1]];
			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				int[] arr = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					matrix[row, col] = arr[col];
				}
			}
			int bestSum = 0;
			int bestRow = 0;
			int bestCol = 0;
			for (int row = 0; row < matrix.GetLength(0) - 1; row++)
			{
				for (int col = 0; col < matrix.GetLength(1) - 1; col++)
				{
					var squareSum = matrix[row, col]
						+ matrix[row, col + 1]
						+ matrix[row + 1, col]
						+ matrix[row + 1, col + 1];
					if (squareSum > bestSum)
					{
						bestSum = squareSum;
						bestRow = row;
						bestCol = col;
					}
				}
			}
			Console.WriteLine("{0} {1}",
			matrix[bestRow, bestCol],
			matrix[bestRow, bestCol + 1]);
			Console.WriteLine("{0} {1}",
				matrix[bestRow + 1, bestCol],
				matrix[bestRow + 1, bestCol + 1]);
			Console.WriteLine(bestSum);

		}
		static void PrintMatrix(int[,] matrix)
		{

			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					Console.Write(matrix[row, col]);
				}
				Console.WriteLine();
			}
		}
	}
}
