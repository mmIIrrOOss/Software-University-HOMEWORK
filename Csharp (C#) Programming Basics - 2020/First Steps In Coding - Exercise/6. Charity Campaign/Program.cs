using System;
using System.Reflection.PortableExecutable;

namespace zaduljitelna_literatura
{
	class Program
	{
		static void Main(string[] args)
		{
			double Days = double.Parse(Console.ReadLine());
			double pastryCockCount = double.Parse(Console.ReadLine());
			double cakesCount = double.Parse(Console.ReadLine());
			double WaffelsCount = double.Parse(Console.ReadLine());
			double PanCakesCount = double.Parse(Console.ReadLine());

			double totalPriceForCakes = Days * pastryCockCount * cakesCount * 45;
			double totalPriceForWafles = Days * pastryCockCount * WaffelsCount * 5.80;
			double totalPriceForPenCakes = Days * pastryCockCount * PanCakesCount * 3.20;

			double totalIncome = totalPriceForCakes + totalPriceForWafles + totalPriceForPenCakes;

			double expenes = totalIncome / 8;

			double profit = totalIncome - expenes;
			Console.WriteLine(profit);

		}
	}
}