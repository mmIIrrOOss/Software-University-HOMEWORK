using System;

namespace app1
{
	class Program
	{
		static void Main(string[] args)
		{
			double age = double.Parse(Console.ReadLine());
			double washingMachinePrice = double.Parse(Console.ReadLine());
			double toysFromPrice = double.Parse(Console.ReadLine());
			int toysCounter = 0;
			double savedMoney = 0;
			double prevBirthday = 0;
			int stolenLeva = 0;
			for (int currentSpecialDay = 1; currentSpecialDay <= age; currentSpecialDay++)
			{
				if (currentSpecialDay % 2 != 0)
				{
					toysCounter++;
				}
				else
				{
					savedMoney += 10;
					prevBirthday += savedMoney;
					stolenLeva++;
				}
			}
			double totalMoneyFromToys = toysCounter * toysFromPrice;
			double totalSavedMoney = totalMoneyFromToys + prevBirthday - stolenLeva;
			if (totalSavedMoney >= washingMachinePrice)
			{
				Console.WriteLine($"Yes! {totalSavedMoney - washingMachinePrice:f2}");
			}
			else
			{
				Console.WriteLine($"No! {Math.Abs(totalSavedMoney - washingMachinePrice):f2}");
			}
		}
	}
}