using System;
namespace _02._Repeat_Strings
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] words = Console.ReadLine().Split();
			string concatination = null;
			foreach (var item in words)
			{
				int miltiply = item.Length;
				for (int i = 0; i < miltiply; i++)
				{
					concatination += item;
				}
			}
			Console.WriteLine(concatination);
		}
	}
}
