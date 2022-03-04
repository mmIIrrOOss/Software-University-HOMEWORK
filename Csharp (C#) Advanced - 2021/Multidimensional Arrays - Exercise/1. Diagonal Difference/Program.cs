using System;
using System.Linq;
namespace _1._Diagonal_Difference
{
	class Program
	{
		static void Main(string[] args)
		{
			int lines = int.Parse(Console.ReadLine());
			int[,] matrix = new int[lines, lines];
			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					matrix[row, col] = nums[col];
				}
			}
			int sumLeftDiagonal = 0;
			  
			int sumRightDiagonal = 0;
			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				
				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					if (row==col)
					{
						sumLeftDiagonal += matrix[row, col];
					}
					if (col==lines-1-row)
					{
						sumRightDiagonal += matrix[row, col];
					}
				}
			}
			Console.WriteLine(Math.Abs(sumLeftDiagonal-sumRightDiagonal));

		}
		static void PrintMatrix(int [,] matrix)
		{
			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					Console.Write(matrix[row, col]+" ");
				}
				Console.WriteLine();
			}
		}
	}
}
