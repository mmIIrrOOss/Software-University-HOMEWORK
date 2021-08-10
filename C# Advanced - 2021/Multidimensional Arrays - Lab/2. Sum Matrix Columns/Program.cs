using System;
using System.Collections.Generic;
using System.Linq;
namespace _2._Sum_Matrix_Columns
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] sym = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
			int[,] matrix = new int[sym[0], sym[1]];
			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				var column = Console.ReadLine().Split().Select(int.Parse).ToArray();
				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					matrix[row, col] = column[col];
				}
			}
			for (int col = 0; col < matrix.GetLength(1); col++)
			{
				int sum = 0;
				for (int row = 0; row < matrix.GetLength(0); row++)
				{
					sum += matrix[row, col];
				}
				Console.WriteLine(sum);
			}

		}
	}
}
