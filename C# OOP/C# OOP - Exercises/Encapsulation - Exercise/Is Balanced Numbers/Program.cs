using System;

namespace Is_Balanced_Numbers
{
	class Program
	{
		static void Main()
		{
			string nums = Console.ReadLine();
			BalancedNumber(nums);
		}
		static void BalancedNumber(string nums)
		{
			int Leftsum = 0;
			int Rightsum = 0;

			
			for (int i = 0; i < nums.Length / 2; i++)
			{
				int left = int.Parse(nums[i].ToString());
				int right = int.Parse(nums[nums.Length - 1 - i].ToString());
				Leftsum +=  left- 0;
				Rightsum += right - 0;
			}

			if (Leftsum == Rightsum)
			{

				Console.WriteLine("Balanced");
			}
			else
			{
				Console.WriteLine("Not Balanced");
			}

		}
	}

}

