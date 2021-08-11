using System;
using System.Linq;
namespace _3._Maximal_Sum
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] lines = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
			int rows = lines[0];
			int cols = lines[1];
			int[,] matrix = new int[rows, cols];
			for (int row = 0; row < rows; row++)
			{
				int[] nums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
				for (int col = 0; col < cols; col++)
				{
					matrix[row, col] = nums[col];
				}
			}
			int bestSum = 0;
			int bestRow = 0;
			int bestCol = 0;
			for (int row = 0; row < matrix.GetLength(0) - 2; row++)
			{

				for (int col = 0; col < matrix.GetLength(1) - 2; col++)
				{
					int currentRowSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
							  + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
							  + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

					if (currentRowSum > bestSum)
					{
						bestSum = currentRowSum;
						bestRow = row;
						bestCol = col;
					}
				}
			}
			Console.WriteLine($"Sum = {bestSum}");
			Console.WriteLine($"{matrix[bestRow, bestCol]} " +
							  $"{matrix[bestRow, bestCol + 1]} " +
							  $"{matrix[bestRow, bestCol + 2]}");

			Console.WriteLine($"{matrix[bestRow + 1, bestCol]} " +
							  $"{matrix[bestRow + 1, bestCol + 1]} " +
							  $"{matrix[bestRow + 1, bestCol + 2]}");

			Console.WriteLine($"{matrix[bestRow + 2, bestCol]} " +
							  $"{matrix[bestRow + 2, bestCol + 1]} " +
							  $"{matrix[bestRow + 2, bestCol + 2]}");
		}
	}
}
