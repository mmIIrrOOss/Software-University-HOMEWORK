using System;

namespace _7._Pascal_Triangle
{
	class Program
	{
		static void Main(string[] args)
		{
			int height = int.Parse(Console.ReadLine());
			long[][] triangle = new long[height][];
			int currentWidth = 1;
			for (long row = 0; row < height; row++)
			{
				triangle[row] = new long[currentWidth];
				long[] currnetRow = triangle[row];
				currnetRow[0] = 1;
				currnetRow[currnetRow.Length - 1] = 1;
				currentWidth++;
				if (currnetRow.Length > 2)
				{
					for (int i = 1; i < currnetRow.Length - 1; i++)
					{
						long[] previewsRow = triangle[row - 1];
						long previewsRowSum = previewsRow[i] + previewsRow[i - 1];
						currnetRow[i] = previewsRowSum;
					}
				}
			}
			foreach (var row in triangle)
			{
				Console.WriteLine(string.Join(" ",row));
			}
		}
	}
}
