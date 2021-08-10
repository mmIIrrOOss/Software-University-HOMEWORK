using System;
using System.Collections.Generic;
using System.Linq;
namespace Demo
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] nums = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
			int[,] matrix = new int[nums[0], nums[1]];
			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				int[] colElements = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					matrix[row, col] = colElements[col];
				}
			}
			int sum = 0;
			foreach (var num in matrix)
			{
				sum += num;
			}
			Console.WriteLine(nums[0]);
			Console.WriteLine(nums[1]);
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
