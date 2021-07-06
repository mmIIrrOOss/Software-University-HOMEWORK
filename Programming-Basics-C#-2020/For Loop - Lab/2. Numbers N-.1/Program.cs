using System;


namespace brum
{
	class Program
	{
		static void Main(string[] args)
		{
			int nums = int.Parse(Console.ReadLine());
			for (int i = nums; nums >= 1; nums--)
			{
				Console.WriteLine(nums);
			}
		}
	}
}