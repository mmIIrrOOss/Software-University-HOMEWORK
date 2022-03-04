using System;
using System.Linq;
namespace Matrix_Shuffling
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int rows = arr[0];
			int cols = arr[1];
			string[,] matrix = new string[rows, cols];
			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				string[] nums = Console.ReadLine().
					Split(' ', StringSplitOptions.RemoveEmptyEntries)
					.ToArray();

				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					matrix[row, col] = nums[col];
				}
			}
			while (true)
			{
				string command = Console.ReadLine();
				if (command == "END")
				{
					break;
				}
				string[] split = command.Split();
				if (split[0] == "swap")
				{
					if (split.Length==5)
					{
						int row1 = int.Parse(split[1]);
						int col1 = int.Parse(split[2]);
						int row2 = int.Parse(split[3]);
						int col2 = int.Parse(split[4]);
						if (row1 >= 0 && row1 <=rows
							&& row2 >= 0 && row2 <=rows
							&& col1 >= 0 && col1 <=cols
							&& col2 >= 0 && col2 <=cols)

						{
							string firstElement = matrix[row1, col1];
							string secondElement = matrix[row2, col2];
							matrix[row1, col1] = secondElement;
							matrix[row2, col2] = firstElement;
							PrintMatrix(matrix);
						}
						else
						{
							Console.WriteLine("Invalid input!");
						}
					}
					else
					{
						Console.WriteLine("Invalid input!");
					}
				}
				else
				{
					Console.WriteLine("Invalid input!");
				}
			}

		}
		static void PrintMatrix(string[,] matrix)
		{
			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					Console.Write(matrix[row, col] + " ");
				}
				Console.WriteLine();
			}
		}
	}
}
