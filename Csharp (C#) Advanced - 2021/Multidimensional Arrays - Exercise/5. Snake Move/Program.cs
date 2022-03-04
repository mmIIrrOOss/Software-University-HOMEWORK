using System;
using System.Linq;
namespace _5._Snake_Move
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int rows = input[0];
			int cols = input[1];
			string snake = Console.ReadLine();
			int currentLetter = 0;
			char[,] matrix = new char[rows, cols];
			for (int row = 0; row < rows; row++)
			{
				if (row % 2 == 0)
				{
					for (int col = 0; col < cols; col++)
					{
						matrix[row, col] = snake[currentLetter];
						currentLetter++;
						if (currentLetter == snake.Length)
						{
							currentLetter = 0;
						}
					}
				}
				else
				{
					for (int col = cols - 1; col >=0; col--)
					{
						matrix[row, col] = snake[currentLetter];
						currentLetter++;
						if (currentLetter == snake.Length)
						{
							currentLetter = 0;
						}
					}
				}
			}
			PrintMatrix(matrix);
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
