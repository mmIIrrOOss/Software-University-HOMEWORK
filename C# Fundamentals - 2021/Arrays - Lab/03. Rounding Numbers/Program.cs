using System;
using System.Linq;

public class Example
{
	public static void Main()
	{
		double[] nums = Console.ReadLine()
			.Split()
			.Select(double.Parse)
			.ToArray();
		for (int i = 0; i < nums.Length; i++)
		{
			if (nums[i] == 0)
			{
				nums[i] = 0;
			}
			double save = Math.Round(nums[i], MidpointRounding.AwayFromZero);
			Console.WriteLine($"{nums[i]} => {(int)save}");
		}

	}
}

