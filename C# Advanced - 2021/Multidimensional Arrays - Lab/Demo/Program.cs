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
			char[,] matrix = new char[n, n];
			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				char[] arr = Console.ReadLine().ToCharArray();
				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					matrix[row, col] = arr[col];
				}
			}
			char symbol = char.Parse(Console.ReadLine());
			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					if (matrix[row,col]==symbol)
					{
						Console.WriteLine($"({row}, {col})");
						return;
					}
				}
			}
			Console.WriteLine($"{symbol} does not occur in the matrix");


		}
		static void PrintMatrix(char[,] matrix)
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
