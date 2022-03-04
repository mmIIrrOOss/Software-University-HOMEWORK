using System;
using System.Linq;
namespace _6._Jagged_Array_Manipulator
{
	class Program
	{
		static void Main(string[] args)
		{
			int rows = int.Parse(Console.ReadLine());
			var matrix = new double[rows][];
			for (int row = 0; row < rows; row++)
			{
				double[] arr = Console.ReadLine().Split().Select(double.Parse).ToArray();
				matrix[row] = arr;
			}
			for (int row = 0; row < rows - 1; row++)
			{
				if (matrix[row].Length == matrix[row + 1].Length)
				{
					for (int rowCurrent = row; rowCurrent <= row + 1; rowCurrent++)
					{
						for (int col = 0; col < matrix[rowCurrent].Length; col++)
						{
							matrix[rowCurrent][col] = matrix[rowCurrent][col] * 2;
						}
					}
				}
				else
				{
					for (int rowCurrent = row; rowCurrent <= row + 1; rowCurrent++)
					{
						for (int col = 0; col < matrix[rowCurrent].Length; col++)
						{
							matrix[rowCurrent][col] = matrix[rowCurrent][col] * 0.5;
						}
					}
				}

			}
			while (true)
			{
				string command = Console.ReadLine();
				if (command == "End")
				{
					break;
				}
				string[] split = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
				if (split[0] == "Add")
				{
					int row = int.Parse(split[1]);
					int col = int.Parse(split[2]);
					double value = double.Parse(split[3]);
					if (row >= 0 && row <= matrix.Length && col >= 0 && col <= matrix[row].Length)
					{
						matrix[row][col] += value;
					}
				}
				else if (split[0] == "Subtract")
				{
					int row = int.Parse(split[1]);
					int col = int.Parse(split[2]);
					double value = double.Parse(split[3]);
					if (row >= 0 && row <= matrix.Length && col >= 0 && col <= matrix[row].Length)
					{
						matrix[row][col] -= value;
					}
				}
			}
			foreach (var arr in matrix)
			{
				Console.WriteLine(string.Join(" ", arr));
			}
		}
	}
}
