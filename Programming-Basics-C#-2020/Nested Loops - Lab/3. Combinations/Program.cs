using System;

namespace ConsoleApp3
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			int count = 0;
			for (int i = 0; i <= n; i++)
			{
				for (int j = 0; j <= n; j++)
				{
					for (int m = 0; m <= n; m++)
					{
						if (i + j + m == n)
						{
							count++;

						}
					}
				}
			}
			Console.WriteLine(count);
		}
	}
}
