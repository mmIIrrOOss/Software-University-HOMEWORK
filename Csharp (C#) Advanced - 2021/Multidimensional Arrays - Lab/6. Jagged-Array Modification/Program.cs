using System;
using System.Linq;
namespace _6._Jagged_Array_Modification
{
	class Program
	{
		static void Main()
		{
			int lines = int.Parse(Console.ReadLine());
			var jagged = new double[lines][];
			for (int row = 0; row < jagged.Length; row++)
			{
				double[] arr = Console.ReadLine().Split().Select(double.Parse).ToArray();
				jagged[row] = arr;
			}
			while (true)
			{
				string command = Console.ReadLine();
				if (command == "END")
				{
					break;
				}
				string[] split = command.Split();
				int row = int.Parse(split[1]);
				int col = int.Parse(split[2]);
				int value = int.Parse(split[3]);
				if (row<0||row>=lines||col<0||col>=jagged[row].Length)
				{
					Console.WriteLine("Invalid coordinates");
				}
				else if (split[0] == "Add")
				{
					jagged[row][col] += value;
				}
				else if (split[0] == "Subtract")
				{
					jagged[row][col] -= value;
				}
			}
			foreach (var arr in jagged)
			{
				Console.WriteLine(string.Join(" ", arr));
			}
		}
	}
}
