using System;

namespace _7._Knight_Game
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			char[,] matrix = new char[n, n];
			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				char[] elements = Console.ReadLine().ToCharArray();
				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					matrix[row, col] = elements[col];
				}
			}
			int countReplaced = 0;
			int rowKiller = 0;
			int colKiller = 0;
			while (true)
			{
				int maxAtacks = 0;
				for (int row = 0; row < n; row++)
				{
					for (int col = 0; col < n; col++)
					{
						char currentSymbol = matrix[row, col];
						int countAtacks = 0;
						if (currentSymbol == 'K')
						{
							countAtacks = GetAttacks(matrix, row, col, countAtacks);
							if (countAtacks > maxAtacks)
							{
								maxAtacks = countAtacks;
								rowKiller = row;
								colKiller = col;
							}
						}
					}
				}
				if (maxAtacks>0)
				{
					matrix[rowKiller, colKiller] = '0';
					countReplaced++;
				}
				else //(maxAtacks <= countReplaced)
				{
					Console.WriteLine(countReplaced);
					break;
				}
			}
			
		}
		static void PrintMatrix(char[,] matrix)
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
		private static int GetAttacks(char[,] matrix, int row, int col, int countAtacks)
		{
			if (isInside(matrix, row - 2, col + 1) && matrix[row - 2, col + 1] == 'K')
			{
				countAtacks++;
			}
			if (isInside(matrix, row - 2, col - 1) && matrix[row - 2, col - 1] == 'K')
			{
				countAtacks++;
			}
			if (isInside(matrix, row + 1, col + 2) && matrix[row + 1, col + 2] == 'K')
			{
				countAtacks++;
			}
			if (isInside(matrix, row + 1, col - 2) && matrix[row + 1, col - 2] == 'K')
			{
				countAtacks++;
			}
			if (isInside(matrix, row - 1, col + 2) && matrix[row - 1, col + 2] == 'K')
			{
				countAtacks++;
			}
			if (isInside(matrix, row - 1, col - 2) && matrix[row - 1, col - 2] == 'K')
			{
				countAtacks++;
			}
			if (isInside(matrix, row + 2, col - 1) && matrix[row + 2, col - 1] == 'K')
			{
				countAtacks++;
			}
			if (isInside(matrix, row + 2, col + 1) && matrix[row + 2, col + 1] == 'K')
			{
				countAtacks++;
			}

			return countAtacks;
		}

		private static bool isInside(char[,] matrix, int targetRow, int targetCol)
		{
			return targetRow >= 0 && targetRow < matrix.GetLength(0)
				&& targetCol >= 0 && targetCol < matrix.GetLength(1);
		}
	}
}
