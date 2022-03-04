using System;
using System.Linq;
class Vacation
{
	static void Main()
	{
		double money = double.Parse(Console.ReadLine());
		int numStudents = int.Parse(Console.ReadLine());
		double numSabers = double.Parse(Console.ReadLine());
		double numRobers = double.Parse(Console.ReadLine());
		double numBelts = double.Parse(Console.ReadLine());
		
		if (numStudents >= 6)
		{
			beltDisscount = numStudents / 6;
			beltsFinalSum = (numStudents - beltDisscount) * numBelts;
		}
		else
		{
			beltsFinalSum = numStudents * numBelts;
		}
		double totalSum = sabersFinalSum + robesFinalSum + beltsFinalSum;
		double change = money - totalSum;
		if (change >= 0)
		{
			Console.WriteLine($"The money is enough - it would cost {totalSum:f2}lv.");
		}
		else
		{
			Console.WriteLine($"Ivan Cho will need {Math.Abs(change):f2}lv more.");
		}



	}
}