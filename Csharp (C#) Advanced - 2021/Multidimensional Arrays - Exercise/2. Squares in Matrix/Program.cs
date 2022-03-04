using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int rows = arr[0];
			int cols = arr[1];
			char[,] matrix = new char[rows, cols];
			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				char[] nums = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					matrix[row, col] = nums[col];
				}
			}
			int counter = 0;
			for (int row = 0; row < rows - 1; row++)
			{

				for (int col = 0; col < cols - 1; col++)
				{
					char current = matrix[row, col];

					if (current == matrix[row, col + 1]
						&& current == matrix[row + 1, col]
						&& current == matrix[row + 1, col + 1])
					{
						counter++;
					}
				}
			}
			Console.WriteLine(counter);
		}
	}
}
