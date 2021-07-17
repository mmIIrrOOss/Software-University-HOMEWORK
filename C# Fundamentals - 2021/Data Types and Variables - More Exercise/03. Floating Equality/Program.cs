using System;

namespace _03._Floating_Equality
{
	class Program
	{
		static void Main(string[] args)
		{
			double floatingNumber = double.Parse(Console.ReadLine());
			double secondFloatingNumber = double.Parse(Console.ReadLine());
			double minimum = 0.000001;
			if (floatingNumber < secondFloatingNumber)
			{
				double temp = floatingNumber;
				floatingNumber = secondFloatingNumber;
				secondFloatingNumber = temp;
			}
			if (floatingNumber-secondFloatingNumber<minimum)
			{
				Console.WriteLine(true.ToString());

			}
			else 
			{
				Console.WriteLine(false.ToString());
			}
			

		}
	}
}
