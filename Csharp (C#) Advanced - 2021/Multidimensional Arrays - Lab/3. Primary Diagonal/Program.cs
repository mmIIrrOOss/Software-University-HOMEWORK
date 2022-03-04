using System;
using System.Collections.Generic;
using System.Linq;
namespace Demo
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
			int sum = 0;
			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					if (row == col)
					{
						sum += matrix[row, col];
					}
				}
			}
			Console.WriteLine(sum);
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
