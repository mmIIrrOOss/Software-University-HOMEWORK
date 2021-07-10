using System;

namespace ConsoleApp3
{
	class Program
	{
		static void Main(string[] args)
		{
			string destination = Console.ReadLine();
			double sumMoney = 0;
			while (destination != "End")
			{
				double bujet = double.Parse(Console.ReadLine());
				while (true)
				{
					double money = double.Parse(Console.ReadLine());
					sumMoney += money;
					if (sumMoney >= bujet)
					{
						Console.WriteLine($"Going to {destination}!");
						break;

					}
				}
				sumMoney = 0;
				destination = Console.ReadLine();
			}


		}
	}
}
