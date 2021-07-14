using System;
using System.Linq;
class Vacation
{
	static void Main()
	{
		int numLosesGame = int.Parse(Console.ReadLine());
		double headsetPrice = double.Parse(Console.ReadLine());
		double mousePrice = double.Parse(Console.ReadLine());
		double keyboardPrice = double.Parse(Console.ReadLine());
		double displayPrice = double.Parse(Console.ReadLine());

		double headsetCost = (numLosesGame / 2) * headsetPrice;
		double mouseCost = (numLosesGame / 3) * mousePrice;
		double keayboardCost = (numLosesGame / 6) * keyboardPrice;
		double displayCost = (numLosesGame / 12) * displayPrice;
		double expenses = headsetCost + mouseCost + keayboardCost + displayCost;
		Console.WriteLine($"Rage expenses: {expenses:f2} lv.");
	}
}